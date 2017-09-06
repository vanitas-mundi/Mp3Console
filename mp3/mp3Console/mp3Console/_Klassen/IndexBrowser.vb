Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Enum BrowseTypes
  Artist = 0
  Album = 1
  Title = 2
End Enum


Public Class IndexBrowser

#Region " ------------ Eigenschaften der Klasse ------------ "
  Private _Index As SSP.IndexerLibrary.IndexBuilder
  Private _BarMenuInfos As BarMenuInfos
  Private _Border As Boolean
  Private _Letter As String = ""
  Private _Artist As String = ""
  Private _Album As String = ""
  Private _Title As SSP.IndexerLibrary.Title
  Private _Titles As New Generic.List(Of SSP.IndexerLibrary.Title)
  Private _BrowseType As BrowseTypes = BrowseTypes.Title
  Private _Path As String = ""

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
    _BrowseType = browseType
  End Sub
#End Region

#Region " ------------ Zugriffsmethoden der Klasse ------------ "
  Public Property Path() As String
  Get
    Return _Path
  End Get
  Set(ByVal value As String)
    _Path = value
  End Set
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

  Public ReadOnly Property Titles() As Generic.List(Of SSP.IndexerLibrary.Title)
  Get
    Return _Titles
  End Get
  End Property
#End Region

#Region " ------------ Private Methoden der Klasse ------------ "
  Private Sub PrepareBrowsing()
    _Title = Nothing

    Dim pathParts = _Path.Split("\"c)
    Select Case pathParts.Count
    Case 1
      GetRegister()
    Case 2
      _Letter = pathParts(0)
      GetArtist()
    Case 3
      Select Case _BrowseType
      Case BrowseTypes.Artist
        _Letter = pathParts(0)
        GetArtist()
      Case Else
        _Letter = pathParts(0)
        _Artist = pathParts(1)
        GetAlbum()
      End Select
    Case 4
      Select Case _BrowseType
      Case BrowseTypes.Artist
        _Letter = pathParts(0)
        GetArtist()
      Case BrowseTypes.Album
        _Letter = pathParts(0)
        _Artist = pathParts(1)
        GetAlbum()
      Case Else
        _Letter = pathParts(0)
        _Artist = pathParts(1)
        _Album = pathParts(2)
        GetTitle()
      End Select
    End Select
  End Sub

  Private Sub GetRegister()
    _BarMenuInfos.SelectedIndex = 0
    Dim list As New Generic.List(Of String)
    list.AddRange(_Index.IndexData.GetRegister)
    _BarMenuInfos.Items = list.ToArray
    Dim bm As New BarMenu(Of String)(_BarMenuInfos)
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    _Letter = CType(bm.Value, Char)
    GetArtist()
  End Sub

  Private Sub GetArtist()

    _BarMenuInfos.SelectedIndex = 0
    Dim list = New Generic.List(Of String)
    list.Add("[\]")
    list.Add("[..]")
    list.AddRange(_Index.IndexData.GetArtistsByFirstLetter(CType(_Letter, Char)))
    _BarMenuInfos.Items = list.ToArray

    Dim bm = New BarMenu(Of String)(_BarMenuInfos)
    AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    Select Case bm.Value
    Case "[\]", "[..]"
      GetRegister()
    Case Else
      Select Case _BrowseType
      Case BrowseTypes.Artist
        _Artist = bm.Value
      Case Else
        _Artist = bm.Value
        GetAlbum()
      End Select
    End Select
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
      GetRegister()
    Case "[..]"
      GetArtist()
    Case Else
      _Album = bm.Value
      Select Case _BrowseType
      Case BrowseTypes.Title
        GetTitle()
      Case Else
        _Titles = New Generic.List(Of SSP.IndexerLibrary.Title)
        _Titles.AddRange(_Index.IndexData.GetTitlesByArtistAndAlbum _
        (_Artist, _Album))
      End Select
    End Select
  End Sub

  Private Sub GetTitle()

    _BarMenuInfos.SelectedIndex = 0
    Dim list = New Generic.List(Of SSP.IndexerLibrary.Title)
    list.Add(New SSP.IndexerLibrary.Title("[\]", "[\]", "[\]"))
    list.Add(New SSP.IndexerLibrary.Title("[..]", "[..]", "[..]"))
    list.AddRange(_Index.IndexData.GetTitlesByArtistAndAlbum(_Artist, _Album))
    _BarMenuInfos.Items = list.ToArray

    Dim bm = New BarMenu(Of SSP.IndexerLibrary.Title)(_BarMenuInfos)
    AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed
    AddHandler bm.ItemChanged, AddressOf onBarMenuItemChanged
    bm.Border = Border

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    Select Case bm.Value.Title
    Case "[\]"
      GetRegister()
    Case "[..]"
      GetAlbum()
    Case Else
      _Title = bm.Value
    End Select
  End Sub


  Public Sub onBarMenuItemChanged _
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
  Public Function BrowseIndex() As SSP.ConsoleExt.DialogResults
    PrepareBrowsing()

    Select Case _BrowseType
    Case BrowseTypes.Artist
      If _Artist Is Nothing OrElse _Artist.Length = 0 Then
        Return ConsoleExt.DialogResults.Cancel
      Else
        _Path = _Letter & "\" & _Artist
        Return ConsoleExt.DialogResults.OK
      End If
    Case BrowseTypes.Album
      If _Album Is Nothing OrElse _Album.Length = 0 Then
        Return ConsoleExt.DialogResults.Cancel
      Else
        _Path = _Letter & "\" & _Artist & "\" & _Album
        Return ConsoleExt.DialogResults.OK
      End If
    Case BrowseTypes.Title
      If _Title Is Nothing Then
        Return ConsoleExt.DialogResults.Cancel
      Else
        _Path = _Letter & "\" & _Artist & "\" & _Album & "\" & _Title.Track
        Return ConsoleExt.DialogResults.OK
      End If
    Case Else
      If _Titles.Count = 0 Then
        Return ConsoleExt.DialogResults.Cancel
      Else
        _Path = _Letter & "\" & _Artist & "\" & _Album & "\Title"
        Return ConsoleExt.DialogResults.OK
      End If
    End Select
  End Function
#End Region

End Class
