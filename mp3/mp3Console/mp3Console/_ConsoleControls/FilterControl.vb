Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class FilterControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum FilterCommands
    ChangeFilterFolder = 0
    RemoveFilter = 1
    ChangeCurrentFilter = 2
    CreateFilter = 3
    DeleteFilter = 4
    FilterDetails = 5
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _UseFilter As Boolean = False
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

  Public Property UseFilter() As Boolean
  Get
    Return _UseFilter
  End Get
  Set(ByVal value As Boolean)
    _UseFilter = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.F1
      e.ExitBarMenu = True
      e.ReturnDialogResult = Nothing
      ClearWindow(DirectCast(sender _
      , BarMenu(Of BarMenuDefaultItem(Of FilterCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function ChangeFilterFolder() As Boolean
    Dim bmi As New BarMenuInfos _
    (Nothing, 1, 14, Me.MP3Console.Colors, 4)
    Dim pp As New PathPicker(bmi)
    pp.Border = False
    Select Case pp.ShowPathPicker()
    Case ConsoleExt.DialogResults.OK
      My.Settings.FilterPath = pp.SelectedPath
      My.Settings.Save()
      Return True
    Case Else
      Return False
    End Select
  End Function

  Private Function GetFilterItems() As Generic.List(Of String)

    Dim list = New Generic.List(Of String)

    If My.Settings.FilterName.Length = 0 Then Return list

    Dim filename = My.Computer.FileSystem.CombinePath _
    (My.Settings.FilterPath, My.Settings.FilterName & ".fil")

    If Not My.Computer.FileSystem.FileExists(filename) Then Return list

    Try
      list = Text.RegularExpressions.Regex.Split _
      (My.Computer.FileSystem.ReadAllText _
      (filename, System.Text.Encoding.Default).Replace _
      (vbCrLf, vbLf), vbLf).ToList

      Dim ret = From item In list _
      Where item.Trim.Length > 0 _
      Select item

      Return ret.ToList
    Catch ex As Exception
      Return list
    End Try
  End Function

  Private Sub ShowFilterDetails()
    Dim bmi As New BarMenuInfos _
    (GetFilterItems.ToArray, 1, 14, Me.MP3Console.Colors, 5)
    Dim bm As New BarMenu(Of String)(bmi)
    bm.Border = False

    bm.ShowMenu()
  End Sub

  Private Sub ChangeFilter()
    Dim filter = SelectFilter()
    If filter.Length > 0 Then

      My.Settings.Filter.Clear()

      My.Settings.FilterName = filter
      My.Settings.Save()
      LoadFilter()

      Me.MP3Console.PlayerController.PlayNextSong()
      Me.MP3Console.MenuDrawing.DrawTitleInformationBox()
    End If
  End Sub

  Private Sub RemoveFilter()
    My.Settings.Filter.Clear()
    My.Settings.FilterName = ""
    My.Settings.Save()
    Me.UseFilter = False
    Me.MP3Console.PlayerController.PlayNextSong()
    Me.MP3Console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Private Sub CreateNewFilter()
    If Not My.Computer.FileSystem.DirectoryExists _
    (My.Settings.FilterPath) Then
      If Not ChangeFilterFolder() Then Exit Sub
    End If

    Dim ib As New ConsoleInputBox(Of String) _
    ("Filtername", "Bitte Filternamen eingeben:" _
    , 1, 14, 40, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim filterName = ib.Value
    Dim genres = Me.MP3Console.IndexControl.Index.IndexData.GetGenresInFilter.ToArray

    Dim bmi As New SSP.ConsoleExt.BarMenus.BarMenuInfos _
    (genres, 1, 14, Me.MP3Console.Colors, 6)

    Dim cbm As New SSP.ConsoleExt.BarMenus.CheckBarMenu(Of String)(bmi)
    cbm.MaximumWith = 50

    Dim fileName = My.Computer.FileSystem.CombinePath _
    (My.Settings.FilterPath, filterName & ".fil")
    If My.Computer.FileSystem.FileExists(fileName) Then
      Try
        Dim list = Text.RegularExpressions.Regex.Split _
        (My.Computer.FileSystem.ReadAllText(fileName).Replace _
        (vbCrLf, vbLf), vbLf)
        For Each item In list
          cbm.Checked(item) = True
        Next item
      Catch ex As Exception
      End Try
    End If

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Filterverwaltung")

    Select Case cbm.ShowMenu()
    Case ConsoleExt.DialogResults.OK

      If cbm.Values.Count > 0 Then
        Dim sb As New Text.StringBuilder
        For Each item In cbm.Values
          sb.AppendLine(item)
        Next item

        Try
          My.Computer.FileSystem.WriteAllText _
          (fileName, sb.ToString, False, Text.Encoding.Default)
        Catch ex As Exception
          WriteXY("Fehler bei der Filtererzeugung!" _
          , 3, 21, Me.MP3Console.Colors)
          Console.ReadKey(True)
        End Try
      End If
    End Select

    ClearWindow(1, 14, 78, 22, Me.MP3Console.Colors.BackColor)
  End Sub

  Private Function SelectFilter() As String
    If Not My.Computer.FileSystem.DirectoryExists _
    (My.Settings.FilterPath) Then
      If Not ChangeFilterFolder() Then Return ""
    End If

    Dim list = New Generic.List(Of String)
    For Each file In My.Computer.FileSystem.GetFiles(My.Settings.FilterPath)
      If file.ToLower.EndsWith(".fil") Then
        list.Add(My.Computer.FileSystem.GetName(file).Replace(".fil", ""))
      End If
    Next file

    Dim bmi As New BarMenuInfos _
    (list.ToArray, 1, 14, Me.MP3Console.Colors, 6)
    Dim bm As New BarMenu(Of String)(bmi)
    bm.Border = False
    Select Case bm.ShowMenu
    Case ConsoleExt.DialogResults.OK
      Return bm.Value
    Case Else
      Return ""
    End Select

  End Function

  Private Sub DeleteFilter()

    Dim filter = SelectFilter()
    If filter.Length = 0 Then Exit Sub

    Dim mb As ConsoleMessageBox

    If filter.ToLower = My.Settings.FilterName.ToLower Then
      mb = New ConsoleMessageBox("Filter löschen" _
      , New String() {"Aktueller Filter kann nicht gelöscht werden!"} _
      , 1, 14, 50, Me.MP3Console.Colors)
      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
      Exit Sub
    End If

    mb = New ConsoleMessageBox("Filter löschen" _
    , New String() {"Soll der Filter wirklich gelöscht werden?"} _
    , 1, 14, 50, Me.MP3Console.Colors)

    Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.Question)
    Case ConsoleExt.MessageBoxResults.Yes
      Try
        My.Computer.FileSystem.DeleteFile _
        (My.Computer.FileSystem.CombinePath(My.Settings.FilterPath, filter & ".fil"))
      Catch ex As Exception
        mb = New ConsoleMessageBox("Fehler" _
        , Text.RegularExpressions.Regex.Split(ex.Message, vbCrLf) _
        , 1, 14, 50, Me.MP3Console.Colors)
        mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
      End Try
    End Select
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi As New BarMenuInfos _
    (New BarMenuDefaultItem(Of FilterCommands)() _
    {New BarMenuDefaultItem(Of FilterCommands) _
    ("Filterdetails", Nothing, FilterCommands.FilterDetails) _
    , New BarMenuDefaultItem(Of FilterCommands) _
    ("Filterverzeichnis wechseln", Nothing, FilterCommands.ChangeFilterFolder) _
    , New BarMenuDefaultItem(Of FilterCommands) _
    ("Aktuellen Filter entfernen", Nothing, FilterCommands.RemoveFilter) _
    , New BarMenuDefaultItem(Of FilterCommands) _
    ("Aktuellen Filter wechseln", Nothing, FilterCommands.ChangeCurrentFilter) _
    , New BarMenuDefaultItem(Of FilterCommands) _
    ("Neuen Filter erstellen", Nothing, FilterCommands.CreateFilter) _
    , New BarMenuDefaultItem(Of FilterCommands) _
    ("Filter löschen", Nothing, FilterCommands.DeleteFilter)} _
    , 1, 14, Me.MP3Console.Colors, 6)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of FilterCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

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

      'DrawBorder(1, 9, 78, 13, Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)
      WriteXY("Filterverzeichnis: " & PathShorten(My.Settings.FilterPath, 50), 3, 10, Me.MP3Console.Colors)
      WriteXY("Aktueller Filter:  " & My.Settings.FilterName, 3, 11, Me.MP3Console.Colors)

      Me.MP3Console.MenuDrawing.DrawMenuFooter("Menü Filterverwaltung")
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case FilterCommands.ChangeFilterFolder
          ChangeFilterFolder()
        Case FilterCommands.RemoveFilter
          RemoveFilter()
        Case FilterCommands.ChangeCurrentFilter
          ChangeFilter()
        Case FilterCommands.CreateFilter
          CreateNewFilter()
        Case FilterCommands.DeleteFilter
          DeleteFilter()
        Case FilterCommands.FilterDetails
          ShowFilterDetails()
        End Select
      End If

    Loop Until result = ConsoleExt.DialogResults.Cancel
    ClearWindow(1, 9, 78, 22, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub InitializeFilter()
    If My.Settings.Filter IsNot Nothing Then Exit Sub

    My.Settings.Filter = New System.Collections.Specialized.StringCollection
  End Sub

  Public Sub LoadFilter()
    My.Settings.Filter.Clear()
    My.Settings.Filter.AddRange(GetFilterItems.ToArray)
    Me.UseFilter = My.Settings.Filter.Count > 0
  End Sub

  Public Function GetCurrentGenres() As List(Of String)
    Select Case Me.UseFilter
    Case False
      Return New List(Of String)
    Case Else
      Dim genres = New Generic.List(Of String)
      For Each s In My.Settings.Filter
        genres.Add(s)
      Next s
      Return genres
    End Select
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class
