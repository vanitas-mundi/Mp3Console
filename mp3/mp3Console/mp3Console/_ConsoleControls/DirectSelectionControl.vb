Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class DirectSelectionControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum DirectSelectionCommands
    IndexBrowse = 0
    SelectPlayList = 1
    SelectFile = 2
    SelectFolder = 3
    PickRandomAlbum = 4
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _CurrentPath As String = ""
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
      , BarMenu(Of BarMenuDefaultItem(Of DirectSelectionCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of DirectSelectionCommands)(Nothing, Nothing, DirectSelectionCommands.IndexBrowse)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of DirectSelectionCommands)(Nothing, Nothing, DirectSelectionCommands.PickRandomAlbum)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of DirectSelectionCommands)(Nothing, Nothing, DirectSelectionCommands.SelectPlayList)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of DirectSelectionCommands)(Nothing, Nothing, DirectSelectionCommands.SelectFile)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of DirectSelectionCommands)(Nothing, Nothing, DirectSelectionCommands.SelectFolder)
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
      Me.MP3Console.FavoritesControl.AddFavorit(title, FavoritesControl.Rankings.normal)
    Case ConsoleKey.D2, ConsoleKey.NumPad2
      Me.MP3Console.FavoritesControl.AddFavorit(title, FavoritesControl.Rankings.high)
    Case ConsoleKey.D3, ConsoleKey.NumPad3
      Me.MP3Console.FavoritesControl.AddFavorit(title, FavoritesControl.Rankings.higher)
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
    Dim bmi = New BarMenuInfos _
    (Nothing, 1, 9, Me.MP3Console.Colors, 11)

    Dim ib As New CompleteIndexBrowser(Me.MP3Console.indexcontrol.Index, bmi)
    ib.Border = False
    AddHandler ib.KeyPressed, AddressOf onIndexBrowserKeyPressed
    AddHandler ib.ItemChanged, AddressOf onIndexBrowserItemChanged

    Dim ok = False
    Dim reset = True
    Do
      Select Case ib.BrowseIndex(reset)
      Case BrowseTypes.Album
        Me.MP3Console.HistoryControl.History.AddRange(ib.Titles)
        Me.MP3Console.PlayerController.PlayImmediately(ib.Titles.Count)
        reset = False
      Case BrowseTypes.Title
        Me.MP3Console.HistoryControl.History.Add(ib.Title)
        Me.MP3Console.PlayerController.PlayImmediately()
        reset = False
      Case Nothing
        ok = True
      End Select
    Loop Until ok
  End Sub

  Private Function GetRandomAlbum() _
  As HundredMilesSoftware.UltraID3Lib.UltraID3
    Dim genres = Me.MP3Console.FilterControl.GetCurrentGenres
    Select Case genres.Count = 0
    Case True
      Return Me.MP3Console.IndexControl.Index.IndexData.GetRandomTitle().Id3
    Case Else
      Return Me.MP3Console.IndexControl.Index.IndexData.GetRandomTitle(genres.ToArray).Id3
    End Select
  End Function

  Private Sub PickRandomAlbum()

    Dim id3 = GetRandomAlbum()

    Dim mb As New SSP.ConsoleExt.Controls.ConsoleMessageBox _
    ("Zufälliges Album" _
    , New String() {id3.Artist, id3.Album, vbCrLf _
    , "Soll ein neues Album vorgeschlagen werden?"} _
    , 1, 9, 78, Me.MP3Console.Colors)

    Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.YesNoCancel)
    Case ConsoleExt.MessageBoxResults.No
      Dim titleCount As Int32 = 0

      For Each title In _
      Me.MP3Console.IndexControl.Index.IndexData.GetTitlesByArtistAndAlbum _
      (id3.Artist, id3.Album)
        Me.MP3Console.HistoryControl.History.Add(title)
        titleCount += 1
      Next title
      Me.MP3Console.PlayerController.PlayImmediately(titleCount)
    Case ConsoleExt.MessageBoxResults.Yes
      PickRandomAlbum()
    End Select

  End Sub

  Private Sub SelectPlayList()

    Dim count = Me.MP3Console.HistoryControl.History.Count

    Dim bmi = New BarMenuInfos _
    (Nothing, 1, 9, Me.MP3Console.Colors, 10)

    Dim fp As New FilePicker(bmi, New String() {"*.m3u"}, 40)
    fp.Border = False
    Select Case fp.ShowPathPicker
    Case ConsoleExt.DialogResults.OK
      SelectPlayList(fp.FileName, fp.SelectedPath)
    End Select

    If Me.MP3Console.HistoryControl.History.Count = count Then Exit Sub
    Me.MP3Console.PlayerController.PlayNextSong()
  End Sub

  Private Sub AddPlayListToHistory _
  (ByVal path As String _
  , ByVal playlist As Generic.List(Of String))

    For Each file In playlist
      Select Case My.Computer.FileSystem.FileExists(file)
      Case True
        AddFileToPlayList(file)
      Case Else
        file = My.Computer.FileSystem.CombinePath(path, file)
        Select Case My.Computer.FileSystem.FileExists(file)
        Case True
          AddFileToPlayList(file)
        End Select
      End Select
    Next file

  End Sub

  Private Sub AddFileToPlayList(ByVal file As String)
    Dim fi As New System.IO.FileInfo(file)
    Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3

    Select Case fi.Extension.ToLower
    Case ".mp3"
      id3.Read(file)
      Me.MP3Console.HistoryControl.History.Add _
      (New SSP.IndexerLibrary.Title(id3))
    Case ".m3u"
      Dim playlist = Text.RegularExpressions.Regex.Split _
      (My.Computer.FileSystem.ReadAllText _
      (file, Text.Encoding.Default).Replace _
      (vbCrLf, vbLf), vbLf).ToList

      AddPlayListToHistory _
      (My.Computer.FileSystem.GetParentPath(file), playlist)
    End Select
  End Sub

  Private Sub SelectFile()
    Dim count = Me.MP3Console.HistoryControl.History.Count

    Dim bmi = New BarMenuInfos _
    (Nothing, 1, 9, Me.MP3Console.Colors, 10)

    Dim fp As New FilePicker(bmi, New String() {"*.mp3"}, 40)
    fp.Border = False

    Dim ok = False

    Do
      Select Case fp.ShowPathPicker
      Case ConsoleExt.DialogResults.OK
        Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3
        id3.Read(fp.FileName)
        Me.MP3Console.HistoryControl.History.Add _
        (New SSP.IndexerLibrary.Title(id3))
        Me.MP3Console.PlayerController.PlayImmediately()
      Case ConsoleExt.DialogResults.Cancel
        ok = True
      End Select
    Loop Until ok
  End Sub

  Private Sub SelectFolder()
    Dim count = Me.MP3Console.HistoryControl.History.Count

    Dim bmi = New BarMenuInfos _
    (Nothing, 1, 9, Me.MP3Console.Colors, 10)

    Dim pp As New PathPicker(bmi, 40)
    pp.Border = False

    Dim ok = False

    Do
      Dim titleCount As Int32 = 0

      Select Case pp.ShowPathPicker
      Case ConsoleExt.DialogResults.OK
        Dim files = My.Computer.FileSystem.GetFiles _
        (pp.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly _
        , New String() {"*.mp3"})

        For Each file In files
          Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3
          id3.Read(file)
          Me.MP3Console.HistoryControl.History.Add _
          (New SSP.IndexerLibrary.Title(id3))
          titleCount += 1
        Next file
        Me.MP3console.PlayerController.PlayImmediately(titleCount)
      Case ConsoleExt.DialogResults.Cancel
        ok = True
      End Select
    Loop Until ok
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of DirectSelectionCommands)() _
    {New BarMenuDefaultItem(Of DirectSelectionCommands) _
    ("Indexbrowser      (F3)", Nothing, DirectSelectionCommands.IndexBrowse) _
    , New BarMenuDefaultItem(Of DirectSelectionCommands) _
    ("Zufälliges Album  (F4)", Nothing, DirectSelectionCommands.PickRandomAlbum) _
    , New BarMenuDefaultItem(Of DirectSelectionCommands) _
    ("Playlist wählen   (F5)", Nothing, DirectSelectionCommands.SelectPlayList) _
    , New BarMenuDefaultItem(Of DirectSelectionCommands) _
    ("MP3-Datei wählen  (F6)", Nothing, DirectSelectionCommands.SelectFile) _
    , New BarMenuDefaultItem(Of DirectSelectionCommands) _
    ("MP3-Ordner wählen (F7)", Nothing, DirectSelectionCommands.SelectFolder)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of DirectSelectionCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Direktwahl")
    If (bm.ShowMenu = ConsoleExt.DialogResults.OK) _
    AndAlso (bm.Value IsNot Nothing) Then
      Select Case bm.Value.Object
      Case DirectSelectionCommands.IndexBrowse
        IndexBrowser()
      Case DirectSelectionCommands.PickRandomAlbum
        PickRandomAlbum()
      Case DirectSelectionCommands.SelectPlayList
        SelectPlayList()
      Case DirectSelectionCommands.SelectFile
        SelectFile()
      Case DirectSelectionCommands.SelectFolder
        SelectFolder()
      End Select
    End If
  End Sub

  Public Sub SelectPlayList _
  (ByVal fileName As String _
  , ByVal path As String)

    Dim playlist = Text.RegularExpressions.Regex.Split _
    (My.Computer.FileSystem.ReadAllText _
    (fileName, Text.Encoding.Default).Replace _
    (vbCrLf, vbLf), vbLf).ToList
    AddPlayListToHistory(path, playlist)
  End Sub

  Public Sub SelectSong(ByVal fileName As String)

    If Not My.Computer.FileSystem.FileExists(fileName) Then Exit Sub

    Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3
    id3.Read(fileName)
    Me.MP3Console.HistoryControl.History.Add _
    (New SSP.IndexerLibrary.Title(id3))
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
