Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class OutsourcingControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum OutsourcingCommands
    IndexSelection = 0
    RandomSelection = 1
    History = 2
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _Rnd As New Random
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
      , BarMenu(Of BarMenuDefaultItem(Of OutsourcingCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    End Select
  End Sub

  Private Sub onIndexBrowserKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Dim bm = TryCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))
    If bm Is Nothing Then Exit Sub

    Dim title = bm.SelectedItem
    If title Is Nothing Then Exit Sub

    Select Case e.KeyInfo.Key
    Case ConsoleKey.D0, ConsoleKey.NumPad0
      Me.MP3Console.FavoritesControl.RemoveFavorit(title)
    Case ConsoleKey.D1, ConsoleKey.NumPad1
      Me.MP3Console.FavoritesControl.AddFavorit _
      (title, FavoritesControl.Rankings.normal)
    Case ConsoleKey.D2, ConsoleKey.NumPad2
      Me.MP3Console.FavoritesControl.AddFavorit _
      (title, FavoritesControl.Rankings.high)
    Case ConsoleKey.D3, ConsoleKey.NumPad3
      Me.MP3Console.FavoritesControl.AddFavorit _
      (title, FavoritesControl.Rankings.higher)
    Case Else
      Exit Sub
    End Select

    Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
    (bm.Bounds.HorizontalEnd + 1, title)
    Me.MP3console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Private Sub onIndexBrowserItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of SSP.IndexerLibrary.Title))

    Dim bm = DirectCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))
    Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
    (bm.Bounds.HorizontalEnd + 1, e.Item)
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub IndexBrowser()
    Dim oi = New OutsourcingInfos(Me.MP3Console)
    If oi.GetPath() = -1 Then Exit Sub

    Dim bmi = New BarMenuInfos _
    (Nothing, 1, 9, Me.MP3Console.Colors, 11)

    Dim ib As New CompleteIndexBrowser _
    (Me.MP3Console.IndexControl.Index, bmi)

    ib.Border = False
    AddHandler ib.KeyPressed, AddressOf onIndexBrowserKeyPressed
    AddHandler ib.ItemChanged, AddressOf onIndexBrowserItemChanged

    Select Case ib.BrowseIndex()
    Case BrowseTypes.Album, BrowseTypes.Title

      If oi.ShowSecurityQuery = ConsoleExt.DialogResults.Cancel Then Exit Sub
      If oi.ShowFolderClearSecurityQuery = -1 Then Exit Sub

      Dim count As Int32 = 0
      For Each title In ib.Titles

        If Console.KeyAvailable Then
          Dim key = Console.ReadKey(True)
          If key.Key = ConsoleKey.Escape Then Exit For
        End If

        Dim sourceFile = title.FileName
        Dim destinationFile = My.Computer.FileSystem.CombinePath _
        (oi.Path, My.Computer.FileSystem.GetName(sourceFile))

        If My.Computer.FileSystem.FileExists(sourceFile) _
        AndAlso (My.Computer.FileSystem.DirectoryExists(oi.Path)) Then

          Dim borderSettings = New BorderSettings
          borderSettings.X = 1
          borderSettings.Y = 9
          borderSettings.X2 = 78
          borderSettings.Y2 = 20
          borderSettings.ForeColor = Me.MP3Console.Colors.BorderColor
          borderSettings.BackColor = Me.MP3Console.Colors.BackColor
          DrawBorder(borderSettings)

          'DrawBorder _
          '(1, 9, 78, 20 _
          ', Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)

          WriteXY("Kopiere ...", 3, 10, Me.MP3Console.Colors)
          WriteXY(PathShorten(sourceFile, 74), 3, 11, Me.MP3Console.Colors)
          WriteXY("nach ...", 3, 13, Me.MP3Console.Colors)
          WriteXY(PathShorten(destinationFile, 74), 3, 14, Me.MP3Console.Colors)

          WriteXY("<ESC> Abbrechen", 3, 19, Me.MP3Console.Colors)

          Try
            My.Computer.FileSystem.CopyFile(sourceFile, destinationFile)
            count += 1
          Catch ex As Exception
          End Try
        End If
      Next title

      SSP.ConsoleExt.Tools.ClearWindow _
      (1, 9, 78, 20, Me.MP3Console.Colors.BackColor)

      Dim mb = New ConsoleMessageBox _
      ("Wechselmediumauslagerung", New String() _
      {count & " MP3-Dateien wurden kopiert!"}, 1, 9, 50, Me.MP3Console.Colors)

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
    End Select
  End Sub

  Private Sub RandomSelection()

    Dim oi = New OutsourcingInfos(_mp3Console)

    If oi.GetPathAndOutSourcingSize = -1 Then Exit Sub

    If oi.ShowSecurityQuery = ConsoleExt.DialogResults.Cancel Then Exit Sub

    oi.ShowRandomQuery()

    If oi.ShowFolderClearSecurityQuery = -1 Then Exit Sub

    Dim current As Int64 = 0
    Dim i As Int32 = 0

    Do
      If Console.KeyAvailable Then
        Dim key = Console.ReadKey(True)
        If key.Key = ConsoleKey.Escape Then Exit Do
      End If

      Dim title As SSP.IndexerLibrary.Title

      Select Case True
      Case (Me.MP3Console.FavoritesControl.PlayFavorites _
      = FavoritesControl.Rankings.none) _
      OrElse (Me.MP3Console.FavoritesControl.Count _
      (Me.MP3Console.FavoritesControl.PlayFavorites) = 0)

        Dim genres = Me.MP3Console.FilterControl.GetCurrentGenres.ToArray
        Select Case genres.Count = 0
        Case True
          title = Me.MP3Console.IndexControl.Index.IndexData.GetRandomTitle()
        Case Else
          title = Me.MP3Console.IndexControl.Index.IndexData.GetRandomTitle(genres)
        End Select
      Case Else
        title = Me.MP3Console.FavoritesControl.GetRandomTitle _
        (Me.MP3console.FavoritesControl.PlayFavorites)
      End Select

      Dim destinationFile As String

      Select Case oi.RandomFileNames
      Case True
        destinationFile = My.Computer.FileSystem.CombinePath _
        (oi.Path, (_Rnd.Next(99999999) + 1).ToString("00000000") & ".mp3")
      Case Else
        destinationFile = My.Computer.FileSystem.CombinePath _
        (oi.Path, My.Computer.FileSystem.GetName(title.FileName))
      End Select

      If My.Computer.FileSystem.FileExists(destinationFile) Then Continue Do

      Dim fi = New IO.FileInfo(title.FileName)

      If (current + fi.Length) <= oi.OutsourcingSizeByte Then

        Dim borderSettings = New BorderSettings
        borderSettings.X = 1
        borderSettings.Y = 9
        borderSettings.X2 = 78
        borderSettings.Y2 = 20
        borderSettings.ForeColor = Me.MP3Console.Colors.BorderColor
        borderSettings.BackColor = Me.MP3Console.Colors.BackColor
        DrawBorder(borderSettings)

        'DrawBorder _
        '(1, 9, 78, 20 _
        ', Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)

        WriteXY("Kopiere (" _
        & Math.Round(fi.Length / 1024 / 1024, 1) & "MB) ..." _
        , 3, 10, Me.MP3Console.Colors)
        WriteXY(PathShorten(title.FileName, 74), 3, 11, Me.MP3Console.Colors)
        WriteXY("nach ...", 3, 13, Me.MP3Console.Colors)
        WriteXY(PathShorten(destinationFile, 74), 3, 14, Me.MP3Console.Colors)

        WriteXY("Bereits kopiert:", 3, 16, Me.MP3Console.Colors)
        WriteXY(i & " Datei(en) (" _
        & Math.Round(current / 1024 / 1024, 1).ToString & "MB / " _
        & Math.Round(oi.OutsourcingSizeMB, 1).ToString & "MB)" _
        , 3, 17, Me.MP3Console.Colors)

        WriteXY("<ESC> Abbrechen", 3, 19, Me.MP3Console.Colors)

        Try
          My.Computer.FileSystem.CopyFile _
          (title.FileName, destinationFile)
          i += 1
          If i >= Me.MP3Console.IndexControl.Index.IndexData.TitleCount Then Exit Do
          current += fi.Length
        Catch ex As Exception
        End Try
      Else
        current += fi.Length
      End If
    Loop Until current > oi.OutsourcingSizeByte

    SSP.ConsoleExt.Tools.ClearWindow _
    (1, 9, 78, 20, Me.MP3Console.Colors.BackColor)

    Dim mb = New ConsoleMessageBox _
    ("Wechselmediumauslagerung", New String() _
    {i & " MP3-Dateien wurden kopiert!"}, 1, 9, 50, Me.MP3Console.Colors)

    mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
  End Sub

  Private Sub OutsourcingHistorie()

    Dim oi = New OutsourcingInfos(_mp3Console)
    If oi.GetPath() = -1 Then Exit Sub

    Dim bmi = New BarMenuInfos _
    (Me.MP3Console.HistoryControl.History.ToArray _
    , 0, 1, 9, Me.MP3Console.Colors, 9)

    Dim cbm As New SSP.ConsoleExt.BarMenus.CheckBarMenu _
    (Of SSP.IndexerLibrary.Title)(bmi)

    Select Case cbm.ShowMenu
    Case ConsoleExt.DialogResults.OK

      If oi.ShowSecurityQuery = ConsoleExt.DialogResults.Cancel Then Exit Sub
      If oi.ShowFolderClearSecurityQuery = -1 Then Exit Sub

      Dim count As Int32 = 0
      For Each title In cbm.Values

        If Console.KeyAvailable Then
          Dim key = Console.ReadKey(True)
          If key.Key = ConsoleKey.Escape Then Exit For
        End If

        Dim sourceFile = title.FileName
        Dim destinationFile = My.Computer.FileSystem.CombinePath _
        (oi.Path, My.Computer.FileSystem.GetName(sourceFile))

        If My.Computer.FileSystem.FileExists(sourceFile) _
        AndAlso (My.Computer.FileSystem.DirectoryExists(oi.Path)) Then

          Dim borderSettings = New BorderSettings
          borderSettings.X = 1
          borderSettings.Y = 9
          borderSettings.X2 = 78
          borderSettings.Y2 = 20
          borderSettings.ForeColor = Me.MP3Console.Colors.BorderColor
          borderSettings.BackColor = Me.MP3Console.Colors.BackColor
          DrawBorder(borderSettings)

          'DrawBorder _
          '(1, 9, 78, 20 _
          ', Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)

          WriteXY("Kopiere ...", 3, 10, Me.MP3Console.Colors)
          WriteXY(PathShorten(sourceFile, 74), 3, 11, Me.MP3Console.Colors)
          WriteXY("nach ...", 3, 13, Me.MP3Console.Colors)
          WriteXY(PathShorten(destinationFile, 74), 3, 14, Me.MP3Console.Colors)

          WriteXY("<ESC> Abbrechen", 3, 19, Me.MP3Console.Colors)

          Try
            My.Computer.FileSystem.CopyFile(sourceFile, destinationFile)
            count += 1
          Catch ex As Exception
          End Try
        End If
      Next title

      SSP.ConsoleExt.Tools.ClearWindow _
      (1, 9, 78, 20, Me.MP3Console.Colors.BackColor)

      Dim mb = New ConsoleMessageBox _
      ("Wechselmediumauslagerung", New String() _
      {count & " MP3-Dateien wurden kopiert!"}, 1, 9, 50, Me.MP3Console.Colors)

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)

    End Select

  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of OutsourcingCommands)() _
    {New BarMenuDefaultItem(Of OutsourcingCommands) _
    ("Zufällige Auswahl", Nothing, OutsourcingCommands.RandomSelection) _
    , New BarMenuDefaultItem(Of OutsourcingCommands) _
    ("Indexauswahl", Nothing, OutsourcingCommands.IndexSelection) _
    , New BarMenuDefaultItem(Of OutsourcingCommands) _
    ("Spielhistorie", Nothing, OutsourcingCommands.History)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of OutsourcingCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed
    Dim result As SSP.ConsoleExt.DialogResults

    Do
      Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Auslagerung")
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case OutsourcingCommands.RandomSelection
          RandomSelection()
        Case OutsourcingCommands.IndexSelection
          IndexBrowser()
        Case OutsourcingCommands.History
          OutsourcingHistorie()
        End Select
      End If
    Loop Until result = ConsoleExt.DialogResults.Cancel

  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
