Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class CompleteIndexBrowser

#Region " ------------ Eigenschaften der Klasse ------------ "
  Private _Index As SSP.IndexerLibrary.IndexBuilder
  Private _BarMenuInfos As BarMenuInfos
  Private _Border As Boolean
  Private _Artist As String = ""
  Private _Album As String = ""
  Private _Title As SSP.IndexerLibrary.Title
  Private _Titles As Generic.List(Of SSP.IndexerLibrary.Title)
  Private _BrowseType As BrowseTypes
  Private _LastSelectedIndex As Int32

  Public Event KeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

  Public Event ItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of SSP.IndexerLibrary.Title))
#End Region

#Region " ------------ Konstruktor der Klasse ------------ "
  Public Sub New _
  (ByVal index As SSP.IndexerLibrary.IndexBuilder _
  , ByVal barMenuInfos As BarMenuInfos)
    _Index = index
    _BarMenuInfos = barMenuInfos
  End Sub

  Public Sub New _
  (ByVal index As SSP.IndexerLibrary.IndexBuilder _
  , ByVal barMenuInfos As BarMenuInfos _
  , ByVal browseType As BrowseTypes)
    _Index = index
    _BarMenuInfos = barMenuInfos
  End Sub
#End Region

#Region " ------------ Zugriffsmethoden der Klasse ------------ "
  Public ReadOnly Property Titles() As Generic.List(Of SSP.IndexerLibrary.Title)
  Get
    Return _Titles
  End Get
  End Property

  Public Property Border() As Boolean
  Get
    Return _Border
  End Get
  Set(ByVal value As Boolean)
    _Border = value
  End Set
  End Property

  Public ReadOnly Property Artist() As String
  Get
    Return _Artist
  End Get
  End Property

  Public ReadOnly Property Album() As String
  Get
    Return _Album
  End Get
  End Property

  Public ReadOnly Property Title() As SSP.IndexerLibrary.Title
  Get
    Return _Title
  End Get
  End Property

#End Region

#Region " ------------ Private Methoden der Klasse ------------ "
  Private Sub GetArtist()

    _BarMenuInfos.SelectedIndex = 0
    Dim list = New Generic.List(Of String)
    list.AddRange(_Index.IndexData.GetAllArtists)
    _BarMenuInfos.Items = list.ToArray

    Dim bm = New BarMenu(Of String)(_BarMenuInfos)
    AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    _Artist = bm.Value
    GetAlbum()
  End Sub

  Private Sub GetAlbum()

    _BarMenuInfos.SelectedIndex = 0
    Dim list = New Generic.List(Of String)
    list.Add("[\]")
    list.Add("[..]")
    list.AddRange(_Index.IndexData.GetAlbumsByArtist(_Artist))
    _BarMenuInfos.Items = list.ToArray

    Dim bm = New BarMenu(Of String)(_BarMenuInfos)
    AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    Select Case bm.Value
    Case "[\]"
      GetArtist()
    Case "[..]"
      GetArtist()
    Case Else
      _Album = bm.Value
      GetTitle()
    End Select
  End Sub

  Private Sub GetTitle()
    GetTitle(0)
  End Sub

  Private Sub GetTitle(ByVal selectedIndex As Int32)

    _BarMenuInfos.SelectedIndex = selectedIndex
    Dim list = New Generic.List(Of SSP.IndexerLibrary.Title)
    list.Add(New SSP.IndexerLibrary.Title("[\]", "[\]", "[\]"))
    list.Add(New SSP.IndexerLibrary.Title("[..]", "[..]", "[..]"))
    list.Add(New SSP.IndexerLibrary.Title("[auswählen]", "[auswählen]", "[auswählen]"))
    list.AddRange(_Index.IndexData.GetTitlesByArtistAndAlbum(_Artist, _Album))
    _BarMenuInfos.Items = list.ToArray

    Dim bm = New BarMenu(Of SSP.IndexerLibrary.Title)(_BarMenuInfos)
    AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed
    AddHandler bm.ItemChanged, AddressOf onBarMenuItemChanged
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    Select Case bm.Value.Title
    Case "[\]"
      GetArtist()
    Case "[..]"
      GetAlbum()
    Case "[auswählen]"
      _BrowseType = BrowseTypes.Album
      _Titles = New Generic.List(Of SSP.IndexerLibrary.Title)
      _Titles.AddRange(_Index.IndexData.GetTitlesByArtistAndAlbum _
      (_Artist, _Album))
      _LastSelectedIndex = bm.SelectedIndex
    Case Else
      _BrowseType = BrowseTypes.Title
      _Title = bm.Value
      _Titles = New Generic.List(Of SSP.IndexerLibrary.Title)
      _Titles.Add(_Title)
      _LastSelectedIndex = bm.SelectedIndex
    End Select
  End Sub

  Private Sub onBarMenuItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of SSP.IndexerLibrary.Title))

    RaiseEvent ItemChanged(sender, e)
  End Sub

  Private Sub onBarMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.Backspace
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK

      Select Case TypeOf sender Is BarMenu(Of String)
      Case True
        e.ReturnValue = "[..]"
      Case False
        e.ReturnValue = New SSP.IndexerLibrary.Title("[..]", "[..]", "[..]")
      End Select
    End Select

    RaiseEvent KeyPressed(sender, e)
  End Sub

#End Region

#Region " ------------ Öffentliche Methoden der Klasse ------------ "
  Public Function BrowseIndex() As BrowseTypes
    Return BrowseIndex(True)
  End Function

  Public Function BrowseIndex(ByVal reset As Boolean) As BrowseTypes
    If reset Then
      GetArtist()
    Else
      Select Case _BrowseType
      Case BrowseTypes.Album
        _BrowseType = Nothing
        GetAlbum()
      Case BrowseTypes.Title
        _BrowseType = Nothing
        GetTitle(_LastSelectedIndex)
      End Select
    End If
    Return _BrowseType
  End Function
#End Region

End Class
