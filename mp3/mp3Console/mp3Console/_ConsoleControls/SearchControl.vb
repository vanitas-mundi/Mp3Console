Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class SearchControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum SearchCommands
    SearchArtist = 0
    SearchAlbum = 1
    SearchTitle = 2
    SearchGenre = 3
    SearchComment = 4
    SearchCatchword = 5
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
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
      , BarMenu(Of BarMenuDefaultItem(Of SearchCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchCatchword)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchTitle)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchArtist)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchAlbum)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchGenre)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SearchCommands)(Nothing, Nothing, SearchCommands.SearchComment)
    End Select
  End Sub

  Private Sub onSearchResultKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Dim bm = DirectCast(sender, BarMenu _
    (Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)))

    Dim title = bm.SelectedItem.Object
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

  Private Sub onSearchResultItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs _
  (Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)))

    Dim bm = DirectCast(sender, BarMenu _
    (Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)))

    Select Case e.Item.Object Is Nothing
    Case True
      Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
      (bm.Bounds.HorizontalEnd + 1, e.Item.DisplayName)
    Case Else
      Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
      (bm.Bounds.HorizontalEnd + 1, e.Item.Object)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub SearchCatchword()

    Dim ib As New ConsoleInputBox(Of String) _
    ("Suchbegriff", "Bitte Suchbegriff oder Teilsuchbegriff eingeben:" _
    , 1, 9, 55, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchCatchword(ib.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub

  Private Sub SearchTitle()

    Dim ib As New ConsoleInputBox(Of String) _
    ("Titelsuche", "Bitte Titel oder Teiltitel eingeben:" _
    , 1, 9, 50, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchTitle(ib.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub

  Private Sub ShowFoundTitles _
  (ByVal list As Generic.List(Of SSP.IndexerLibrary.Title))
    ShowFoundTitles(list, 0)
  End Sub

  Private Sub ShowFoundTitles _
  (ByVal list As Generic.List(Of SSP.IndexerLibrary.Title) _
  , ByVal selectedIndex As Int32)

    Dim titles = New Generic.List(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))
    Dim item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Interpretenübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Albumübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Alle wiedergeben]"
    titles.Add(item)

    For Each title In list
      item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
      item.DisplayName = title.Title
      item.Object = title
      titles.Add(item)
    Next title

    Dim bmi = New BarMenuInfos _
    (titles.ToArray, selectedIndex, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))(bmi)
    AddHandler bm.ItemChanged, AddressOf onSearchResultItemChanged
    AddHandler bm.KeyPressed, AddressOf onSearchResultKeyPressed

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Select Case bm.Value.DisplayName
      Case "[Interpretenübersicht]"
        ShowFoundArtists(list)
      Case "[Albumübersicht]"
        ShowFoundAlbums(list)
      Case "[Alle wiedergeben]"
        Dim titleCount As Int32 = 0

        For Each title In list
          Me.MP3Console.HistoryControl.History.Add(title)
          titleCount += 1
        Next title
        Me.MP3Console.PlayerController.PlayImmediately(titleCount)
        'ShowFoundAlbum(list, selectedTitle, bm.SelectedIndex)
      Case Else
        Me.MP3Console.HistoryControl.History.Add(bm.Value.Object)
        Me.MP3Console.PlayerController.PlayImmediately()
        ShowFoundTitles(list, bm.SelectedIndex)
      End Select
    End Select
  End Sub

  Private Sub ShowFoundArtists(ByVal list As Generic.List(Of SSP.IndexerLibrary.Title))
    Dim titles = New Generic.List(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))
    Dim item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Albumübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Titelübersicht]"
    titles.Add(item)

    Dim ret = From title In list _
    Group By title.Id3.Artist.ToLower Into title = First() _
    Select title

    For Each title In ret
      item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
      item.DisplayName = title.Id3.Artist
      item.Object = title
      titles.Add(item)
    Next title

    Dim bmi = New BarMenuInfos _
    (titles.ToArray, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))(bmi)
    AddHandler bm.ItemChanged, AddressOf onSearchResultItemChanged

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Select Case bm.Value.DisplayName
      Case "[Albumübersicht]"
        ShowFoundAlbums(list)
      Case "[Titelübersicht]"
        ShowFoundTitles(list)
      Case Else
        ret = From title In list _
        Where title.Id3.Artist.ToLower = bm.Value.Object.Id3.Artist.ToLower _
        Select title
        ShowFoundAlbums(ret.ToList)
      End Select
    End Select
  End Sub

  Private Sub ShowFoundAlbums(ByVal list As Generic.List(Of SSP.IndexerLibrary.Title))
    Dim titles = New Generic.List(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))
    Dim item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Interpretenübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Titelübersicht]"
    titles.Add(item)

    Dim ret = From title In list _
    Group By title.Id3.Album.ToLower Into title = First() _
    Select title

    For Each title In ret
      item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
      item.DisplayName = title.Id3.Album
      item.Object = title
      titles.Add(item)
    Next title

    Dim bmi = New BarMenuInfos _
    (titles.ToArray, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))(bmi)
    AddHandler bm.ItemChanged, AddressOf onSearchResultItemChanged

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Select Case bm.Value.DisplayName
      Case "[Interpretenübersicht]"
        ShowFoundArtists(list)
      Case "[Titelübersicht]"
        ShowFoundTitles(list)
      Case Else
        ShowFoundAlbum(list, bm.Value.Object)
      End Select
    End Select
  End Sub

  Private Sub ShowFoundAlbum _
  (ByVal list As Generic.List(Of SSP.IndexerLibrary.Title) _
  , ByVal selectedTitle As SSP.IndexerLibrary.Title)
    ShowFoundAlbum(list, selectedTitle, 0)
  End Sub

  Private Sub ShowFoundAlbum _
  (ByVal list As Generic.List(Of SSP.IndexerLibrary.Title) _
  , ByVal selectedTitle As SSP.IndexerLibrary.Title _
  , ByVal selectedIndex As Int32)

    Dim titles = New Generic.List(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))

    Dim item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Interpretenübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Albumübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Titelübersicht]"
    titles.Add(item)
    item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
    item.DisplayName = "[Alle wiedergeben]"
    titles.Add(item)

    Dim albumTitles = Me.MP3Console.IndexControl.Index.IndexData.GetTitlesByArtistAndAlbum _
    (selectedTitle.Id3.Artist, selectedTitle.Id3.Album)

    For Each title In albumTitles
      item = New BarMenuDefaultItem(Of SSP.IndexerLibrary.Title)
      item.DisplayName = title.ToString
      item.Object = title
      titles.Add(item)
    Next title

    Dim bmi = New BarMenuInfos _
    (titles.ToArray, selectedIndex, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of SSP.IndexerLibrary.Title))(bmi)
    AddHandler bm.ItemChanged, AddressOf onSearchResultItemChanged

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Select Case bm.Value.DisplayName
      Case "[Interpretenübersicht]"
        ShowFoundArtists(list)
      Case "[Albumübersicht]"
        ShowFoundAlbums(list)
      Case "[Titelübersicht]"
        ShowFoundTitles(list)
      Case "[Alle wiedergeben]"
        Dim titleCount As Int32 = 0

        For Each title In albumTitles
          Me.MP3Console.HistoryControl.History.Add(title)
          titleCount += 1
        Next title
        Me.MP3Console.PlayerController.PlayImmediately(titleCount)
        ShowFoundAlbum(list, selectedTitle, bm.SelectedIndex)
      Case Else
        Me.MP3Console.HistoryControl.History.Add(bm.Value.Object)
        Me.MP3Console.PlayerController.PlayImmediately()
        ShowFoundAlbum(list, selectedTitle, bm.SelectedIndex)
      End Select
    End Select
  End Sub

  Private Sub SearchArtist()
    Dim ib As New ConsoleInputBox(Of String) _
    ("Interpretensuch", "Bitte Interpreten oder Teilinterpreten eingeben:" _
    , 1, 9, 55, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchArtist(ib.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub

  Private Sub SearchAlbum()
    Dim ib As New ConsoleInputBox(Of String) _
    ("Albumsuche", "Bitte Albumnamen oder Teilalbumnamen eingeben:" _
    , 1, 9, 55, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchAlbum(ib.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub

  Private Sub SearchGenre()

    Dim genres = Me.MP3Console.IndexControl.Index.IndexData.GetGenresInFilter

    Dim bmiGenres = New BarMenuInfos _
    (genres.ToArray, 1, 9, Me.MP3Console.Colors, 11)

    Dim bmGenres As New BarMenu(Of String)(bmiGenres)

    Select Case bmGenres.ShowMenu
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchGenre(bmGenres.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub

  Private Sub SearchComment()
    Dim ib As New ConsoleInputBox(Of String) _
    ("Kommentarsuche", "Bitte kommentar oder Teilkommentar eingeben:" _
    , 1, 9, 55, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list = Me.MP3Console.IndexControl.Index.IndexData.SearchComment(ib.Value)
    If list.Count = 0 Then Exit Sub

    ShowFoundTitles(list)
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of SearchCommands)() _
    {New BarMenuDefaultItem(Of SearchCommands) _
    ("Suchbegriff      (F2)", Nothing, SearchCommands.SearchCatchword) _
    , New BarMenuDefaultItem(Of SearchCommands) _
    ("Titelsuche       (F3)", Nothing, SearchCommands.SearchTitle) _
    , New BarMenuDefaultItem(Of SearchCommands) _
    ("Interpretensuche (F4)", Nothing, SearchCommands.SearchArtist) _
    , New BarMenuDefaultItem(Of SearchCommands) _
    ("Albumsuche       (F5)", Nothing, SearchCommands.SearchAlbum) _
    , New BarMenuDefaultItem(Of SearchCommands) _
    ("Genresuche       (F6)", Nothing, SearchCommands.SearchGenre) _
    , New BarMenuDefaultItem(Of SearchCommands) _
    ("Kommentarsuche   (F7)", Nothing, SearchCommands.SearchComment)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of SearchCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Suche")
    If (bm.ShowMenu = ConsoleExt.DialogResults.OK) _
    AndAlso (bm.Value IsNot Nothing) Then
      Select Case bm.Value.Object
      Case SearchCommands.SearchCatchword
        SearchCatchword()
      Case SearchCommands.SearchTitle
        SearchTitle()
      Case SearchCommands.SearchArtist
        SearchArtist()
      Case SearchCommands.SearchAlbum
        SearchAlbum()
      Case SearchCommands.SearchGenre
        SearchGenre()
      Case SearchCommands.SearchComment
        SearchComment()
      End Select
    End If
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
