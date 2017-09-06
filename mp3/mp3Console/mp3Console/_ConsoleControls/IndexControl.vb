Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls
Imports SSP.IndexerLibrary

Public Class IndexControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum IndexCommands
    ChangeIndexFolder = 0
    ChangeCurrentIndex = 1
		CreateIndex = 2
		ReduceIndex = 3
		DeleteIndex = 4
		IndexDetails = 5
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _IndexIsChecking As Boolean = False
  Private _Index As SSP.IndexerLibrary.IndexBuilder
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3ConsoleControl.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property

  Public Property Index() As SSP.IndexerLibrary.IndexBuilder
  Get
    Return _Index
  End Get
  Set(ByVal value As SSP.IndexerLibrary.IndexBuilder)
    _Index = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
	Private Sub OnMenuKeyPressed _
	(ByVal sender As Object _
	, ByVal e As BarMenuKeyPressedEventArgs)

		Select Case e.KeyInfo.Key
		Case ConsoleKey.F1
			e.ExitBarMenu = True
			e.ReturnDialogResult = Nothing
			ClearWindow(DirectCast(sender _
			, BarMenu(Of BarMenuDefaultItem(Of IndexCommands))).Bounds _
			, Me.MP3Console.Colors.BackColor)
			Me.MP3Console.HelpViewer.Show(Me)
		End Select
	End Sub

	Private Sub OnFileAddedToIndex _
	(ByVal sender As Object _
	, ByVal e As FileAddedToIndexEventArgs)

		Dim counter = DirectCast(sender, IndexBuilder).IndexData.files.Count.ToString
		WriteXY(counter, 45, 18, Me.MP3Console.Colors)
	End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
	'{Private Methoden}
	Private Function ChangeIndexFolder() As Boolean
		Dim bmi As New BarMenuInfos _
		(Nothing, 1, 14, Me.MP3Console.Colors, 4)
		Dim pp As New PathPicker(bmi)
		pp.Border = False
		Select Case pp.ShowPathPicker()
		Case ConsoleExt.DialogResults.OK
			My.Settings.IndexPath = pp.SelectedPath
			My.Settings.Save()
			Return True
		Case Else
			Return False
		End Select
	End Function

	Private Function SelectIndex() As String
		Return SelectIndex(False)
	End Function

	Private Function SelectIndex(ByVal showNewIndex As Boolean) As String
		If Not My.Computer.FileSystem.DirectoryExists _
		(My.Settings.IndexPath) Then
			If Not ChangeIndexFolder() Then Return ""
		End If

		Dim list = New Generic.List(Of String)

		If showNewIndex Then
			list.Add("<Neuer Index>")
		End If

		For Each file In My.Computer.FileSystem.GetFiles(My.Settings.IndexPath)
			If file.ToLower.EndsWith(".xml") Then
				list.Add(My.Computer.FileSystem.GetName(file).Replace(".xml", ""))
			End If
		Next file

		Dim bmi As New BarMenuInfos _
		(list.ToArray, 1, 14, Me.MP3Console.Colors, 6)
		Dim bm As New BarMenu(Of String)(bmi)
		bm.Border = False
		Select Case bm.ShowMenu
		Case ConsoleExt.DialogResults.OK
			Select Case bm.Value
			Case "<Neuer Index>"
				Dim indexName = GetNewIndexName()
				If indexName = "" Then
					Return ""
				Else
					Return indexName
				End If
			Case Else
				Return bm.Value
			End Select
		Case Else
			Return ""
		End Select

	End Function

	Private Sub IndexDetails()
		WriteXY("Index-Details: Root-Verzeichnisse", 3, 12, _mp3Console.Colors)

		Dim items() As String
		items = Me.Index.IndexData.RootFolders.ToArray

		If items.Count = 0 Then
			items = New String() {"<Kein Root-Verzeichnis gefunden>"}
		End If

		Dim bmi = New BarMenuInfos _
		(items, 1, 14, Me.MP3Console.Colors, 6)

		Dim menu = New BarMenu(Of String)(bmi)
		menu.ShowMenu()
	End Sub

	Private Sub ChangeIndex()
		ChangeIndex(SelectIndex, False)
	End Sub

	Private Sub ChangeIndex _
	(ByVal indexName As String _
	, ByVal ask As Boolean)

		If indexName.Length = 0 Then Exit Sub

		If ask Then
			Dim mb = New SSP.ConsoleExt.Controls.ConsoleMessageBox _
			("Index nachladen", New String() _
			{"Soll der Index nachgeladen werden?"}, 1, 14, 40, _mp3Console.Colors)
			Select Case mb.ShowMessage(MessageBoxTypes.Question)
			Case MessageBoxResults.No
				Exit Sub
			End Select
		End If

		My.Settings.IndexName = indexName
		My.Settings.Save()

		If _IndexIsChecking Then Exit Sub

		Me.MP3Console.PlayerController.Player.Stop()
		LoadIndex()
		Me.MP3Console.PlayerController.PlayNextSong()

		Select Case True
		Case Me.MP3Console.PlayerController.CurrentTitle Is Nothing
			Dim fileName = My.Computer.FileSystem.CombinePath _
			(My.Application.Info.DirectoryPath, "data\error.mp3")
			Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
			id3.Read(fileName)
			Me.MP3Console.PlayerController.CurrentTitle = New SSP.IndexerLibrary.Title(id3)
		End Select

		'Me.MP3Console.PlayerController.Player.FileName _
		'= Me.MP3Console.PlayerController.CurrentTitle.FileName

		_mp3Console.MenuDrawing.DrawTitleInformationBox()
	End Sub

	Private Function GetNewIndexName() As String
		Dim ib = New ConsoleInputBox(Of String) _
		("Indexname", "Bitte Indexnamen eingeben:" _
		, 1, 14, 40, Me.MP3Console.Colors)

		Select Case ib.ShowDialog
		Case ConsoleExt.DialogResults.Cancel
			Return ""
		Case Else
			Return ib.Value
		End Select

	End Function

	Private Sub ReduceIndex()
		If Not My.Computer.FileSystem.DirectoryExists _
		(My.Settings.IndexPath) Then
			If Not ChangeIndexFolder() Then Exit Sub
		End If

		Dim indexName = SelectIndex()
		If indexName = "" Then Exit Sub

		Dim index = New IndexBuilder(indexName, My.Settings.IndexPath)

		If index.IndexData.RootFolders.Count = 0 Then Exit Sub

		Dim bmi = New BarMenuInfos _
		(index.IndexData.RootFolders.ToArray, 1, 14, Me.MP3Console.Colors, 6)
		Dim menu = New BarMenu(Of String)(bmi)

		Select Case menu.ShowMenu()
		Case DialogResults.Cancel
			Exit Sub
		End Select

		index.RemoveRootFolder(menu.Value)

		ChangeIndex(indexName, True)
	End Sub

	Private Sub CreateNewIndex()
		If Not My.Computer.FileSystem.DirectoryExists _
		(My.Settings.IndexPath) Then
			If Not ChangeIndexFolder() Then Exit Sub
		End If

		Dim indexName = SelectIndex(True)
		If indexName = "" Then Exit Sub

		Dim bmi = New BarMenuInfos(1, 15, Me.MP3Console.Colors, 4)

		Dim pp As New PathPicker(bmi, 45)
		pp.Border = False

		WriteXY("Welcher Ordner soll indiziert werden?", 2, 14, Me.MP3Console.Colors)
		Select Case pp.ShowPathPicker
		Case ConsoleExt.DialogResults.Cancel
			Exit Sub
		End Select

		Try
			Dim settings = New HeaderBorderSettings
			settings.HeaderText = "Indexerzeugung"
			settings.X = 1
			settings.Y = 14
			settings.X2 = 78
			settings.Y2 = 22
			settings.ColorSet = Me.MP3Console.Colors
			DrawHeaderBorder(settings)

			Dim newIndex As New SSP.IndexerLibrary.IndexBuilder _
			(indexName, My.Settings.IndexPath)

			AddHandler newIndex.FileAddedToIndex, AddressOf OnFileAddedToIndex

			WriteXY("Indizierte Dateien vor Indizierung: " _
			& newIndex.IndexData.TitleCount _
			, 3, 17, Me.MP3Console.Colors)

			WriteXY("Start der Indizierung - Bitte warten! ... " _
			, 3, 18, Me.MP3Console.Colors)

			newIndex.BuildIndex(pp.SelectedPath)
			newIndex.SaveIndex()

			WriteXY("<fertig>" _
			, 45, 18, Me.MP3Console.Colors)

			WriteXY("Indizierte Dateien nach Indizierung: " _
			& newIndex.IndexData.TitleCount _
			, 3, 19, Me.MP3Console.Colors)
		Catch ex As Exception
			WriteXY("Fehler bei der Indizierung aufgetreten!" _
			, 3, 19, Me.MP3Console.Colors)
		End Try

		WriteXY("<Taste, um fortzufahren ...>" _
		, 3, 21, Me.MP3Console.Colors)

		Console.ReadKey(True)
		ClearWindow(1, 14, 78, 22, Me.MP3Console.Colors.BackColor)

		ChangeIndex(indexName, True)
	End Sub

	Private Sub DeleteIndex()

		Dim index = SelectIndex()
		If index.Length = 0 Then Exit Sub

		Dim mb As ConsoleMessageBox

		If index.ToLower = My.Settings.IndexName.ToLower Then
			mb = New ConsoleMessageBox("Index löschen" _
			, New String() {"Aktueller Index kann nicht gelöscht werden!"} _
			, 1, 14, 50, Me.MP3Console.Colors)
			mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
			Exit Sub
		End If

		mb = New ConsoleMessageBox("Index löschen" _
		, New String() {"Soll der Index wirklich gelöscht werden?"} _
		, 1, 14, 50, Me.MP3Console.Colors)

		Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.Question)
		Case ConsoleExt.MessageBoxResults.Yes
			Try
				My.Computer.FileSystem.DeleteFile _
				(My.Computer.FileSystem.CombinePath(My.Settings.IndexPath, index & ".xsd"))
				My.Computer.FileSystem.DeleteFile _
				(My.Computer.FileSystem.CombinePath(My.Settings.IndexPath, index & ".xml"))
			Catch ex As Exception
				mb = New ConsoleMessageBox("Fehler" _
				, Text.RegularExpressions.Regex.Split(ex.Message, vbCrLf) _
				, 1, 14, 50, Me.MP3Console.Colors)
				mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
			End Try
		End Select
	End Sub

	Private Function IndexNotExists() As Boolean

		If (My.Settings.IndexPath.Length = 0) OrElse (My.Settings.IndexName.Length = 0) Then Return True

		If Not My.Computer.FileSystem.FileExists _
		(My.Computer.FileSystem.CombinePath _
		(My.Settings.IndexPath, My.Settings.IndexName & ".xml")) Then Return True

		If Not My.Computer.FileSystem.FileExists _
		(My.Computer.FileSystem.CombinePath _
		(My.Settings.IndexPath, My.Settings.IndexName & ".xsd")) Then Return True

		Return False
	End Function
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	'{Öffentliche Methoden}
	Public Sub Show() Implements Imp3ConsoleControl.Show
		Dim bmi As New BarMenuInfos _
		(New BarMenuDefaultItem(Of IndexCommands)() _
		{New BarMenuDefaultItem(Of IndexCommands) _
		("Indexverzeichnis wechseln", Nothing, IndexCommands.ChangeIndexFolder) _
		, New BarMenuDefaultItem(Of IndexCommands) _
		("Aktuellen Index wechseln", Nothing, IndexCommands.ChangeCurrentIndex) _
		, New BarMenuDefaultItem(Of IndexCommands) _
		("Index erstellen/ erweitern", Nothing, IndexCommands.CreateIndex) _
		, New BarMenuDefaultItem(Of IndexCommands) _
		("Index reduzieren", Nothing, IndexCommands.ReduceIndex) _
		, New BarMenuDefaultItem(Of IndexCommands) _
		("Index löschen", Nothing, IndexCommands.DeleteIndex) _
		, New BarMenuDefaultItem(Of IndexCommands) _
		("Index-Details", Nothing, IndexCommands.IndexDetails)} _
		, 1, 14, Me.MP3Console.Colors, 6)

		Dim bm As New BarMenu(Of BarMenuDefaultItem(Of IndexCommands))(bmi)
		AddHandler bm.KeyPressed, AddressOf OnMenuKeyPressed

		Dim result As SSP.ConsoleExt.DialogResults
		Do
			Dim borderSettings = New BorderSettings
			borderSettings.X = 1
			borderSettings.Y = 9
			borderSettings.X2 = 78
			borderSettings.Y2 = 13
			borderSettings.ForeColor = Me.MP3Console.Colors.BorderColor
			borderSettings.BackColor = Me.MP3Console.Colors.BackColor
			DrawBorder(borderSettings)

			WriteXY("Indexverzeichnis: " & PathShorten _
			(My.Settings.IndexPath, 50), 3, 10, Me.MP3Console.Colors)
			WriteXY("Aktueller Index:  " & My.Settings.IndexName, 3, 11, Me.MP3Console.Colors)

			Me.MP3Console.MenuDrawing.DrawMenuFooter("Menü Indexverwaltung")
			result = bm.ShowMenu

			If (result = ConsoleExt.DialogResults.OK) _
			AndAlso (bm.Value IsNot Nothing) Then
				Select Case bm.Value.Object
				Case IndexCommands.ChangeIndexFolder
					ChangeIndexFolder()
				Case IndexCommands.ChangeCurrentIndex
					ChangeIndex()
				Case IndexCommands.CreateIndex
					CreateNewIndex()
				Case IndexCommands.ReduceIndex
					ReduceIndex()
				Case IndexCommands.DeleteIndex
					DeleteIndex()
				Case IndexCommands.IndexDetails
					IndexDetails()
				End Select
			End If

		Loop Until result = ConsoleExt.DialogResults.Cancel
		ClearWindow(1, 9, 78, 22, Me.MP3Console.Colors.BackColor)
	End Sub

	Public Sub LoadIndex()
		Me.Index = New SSP.IndexerLibrary.IndexBuilder _
		(My.Settings.IndexName, My.Settings.IndexPath)
	End Sub

	Public Sub CheckIndex()
		If IndexNotExists() Then
			_IndexIsChecking = True

			Dim settings = New HeaderBorderSettings
			settings.HeaderText = "Index"
			settings.X = 1
			settings.Y = 1
			settings.X2 = 78
			settings.Y2 = 8
			settings.ColorSet = Me.MP3Console.Colors
			DrawHeaderBorder(settings)

			'DrawHeaderBorder("Index", 1, 1, 78, 8, Me.MP3Console.Colors)

			WriteXY("Es wurde noch kein Index angegeben!", 3, 4, Me.MP3Console.Colors)
			WriteXY("1. Hinterlegen Sie ein Indexverzeichnis.", 3, 5, Me.MP3Console.Colors)
			WriteXY("2. Erzeugen Sie einen neuen Index.", 3, 6, Me.MP3Console.Colors)
			WriteXY("3. Setzen Sie den aktuellen Index.", 3, 7, Me.MP3Console.Colors)
			Me.Show()
			ClearWindow(1, 1, 78, 8, Me.MP3Console.Colors.BackColor)
		End If
		If IndexNotExists() Then Environment.Exit(0)

		_IndexIsChecking = False
	End Sub
#End Region	'Öffentliche Methoden der Klasse}

End Class
