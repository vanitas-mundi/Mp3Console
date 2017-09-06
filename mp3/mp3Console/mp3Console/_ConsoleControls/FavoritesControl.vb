Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class FavoritesControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Public Enum Rankings
    none = 0
    normal = 1
    high = 2
    higher = 3
  End Enum

  Private Enum FavoritesControlCommands
    FavoritesBackup = 0
    FavoritesRestore = 1
    FavoritesView = 2
    FavoritesPlaying = 3
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _RankingNoneGraphic As String = "▒▒▒"
  Private _RankingNormalGraphic As String = "■▒▒"
  Private _RankingHighGraphic As String = "■■▒"
  Private _RankingHigherGraphic As String = "■■■"

  Private _Favorites As New DataTable("favorites")
  Private _Rnd As New System.Random
  Private _Filename As String = My.Computer.FileSystem.CombinePath _
  (My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData _
  , "favorites")
  Private _PlayFavorites As FavoritesControl.Rankings _
  = CType(My.Settings.Ranking, FavoritesControl.Rankings)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
    Create()
    Load()
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

  Public Property PlayFavorites() As FavoritesControl.Rankings
  Get
    Return _PlayFavorites
  End Get
  Set(ByVal value As FavoritesControl.Rankings)
    _PlayFavorites = value
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
      , BarMenu(Of BarMenuDefaultItem(Of FavoritesControlCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    End Select
  End Sub

  Private Sub onViewKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Dim bm = TryCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))
    If bm Is Nothing Then Exit Sub

    Dim title = bm.SelectedItem
    If title Is Nothing Then Exit Sub

    Select Case e.KeyInfo.Key
    Case ConsoleKey.D0, ConsoleKey.NumPad0
      Me.RemoveFavorit(title)
    Case ConsoleKey.D1, ConsoleKey.NumPad1
      Me.AddFavorit(title, FavoritesControl.Rankings.normal)
    Case ConsoleKey.D2, ConsoleKey.NumPad2
      Me.AddFavorit(title, FavoritesControl.Rankings.high)
    Case ConsoleKey.D3, ConsoleKey.NumPad3
      Me.AddFavorit(title, FavoritesControl.Rankings.higher)
    Case Else
      Exit Sub
    End Select

    Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
    (bm.Bounds.HorizontalEnd + 1, title)
    Me.MP3console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Private Sub onViewItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of SSP.IndexerLibrary.Title))

    Dim bm = DirectCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))
    Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
    (bm.Bounds.HorizontalEnd + 1, e.Item)
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub Load()
    Try
      _Favorites = New DataTable("favorites")
      _Favorites.ReadXmlSchema(_Filename & ".xsd")
      _Favorites.ReadXml(_Filename & ".xml")

      Dim removed = False
      For index = _Favorites.Rows.Count - 1 To 0 Step -1
        Dim r = _Favorites.Rows.Item(index)
        If Not My.Computer.FileSystem.FileExists(r.Item("filename").ToString) Then
          _Favorites.Rows.Remove(r)
          removed = True
        End If
      Next index

      If removed Then Save()
    Catch ex As Exception
      Dim mb = New ConsoleMessageBox("Fehler" _
      , Text.RegularExpressions.Regex.Split(ex.Message, vbCrLf) _
      , 1, 9, 78, Me.MP3Console.Colors)
      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
    End Try
  End Sub

  Private Sub Save()
    Try
      _Favorites.WriteXmlSchema(_Filename & ".xsd")
      _Favorites.WriteXml(_Filename & ".xml")
    Catch ex As Exception
      Dim mb = New ConsoleMessageBox("Fehler" _
      , Text.RegularExpressions.Regex.Split(ex.Message, vbCrLf) _
      , 1, 9, 78, Me.MP3Console.Colors)
      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
    End Try
  End Sub

  Private Function findRow _
  (ByVal title As SSP.IndexerLibrary.Title) As DataRow

    Dim filename = title.FileName.ToLower

    Dim ret = From item In _Favorites.Rows _
    Where DirectCast(item, DataRow).Item("filename").ToString.ToLower = filename _
    Select DirectCast(item, DataRow)

    Select Case ret.Count
    Case 0
      Return Nothing
    Case Else
      Return ret(0)
    End Select
  End Function

  Private Sub Create()
    If My.Computer.FileSystem.FileExists(_Filename & ".xml") Then Exit Sub

    _Favorites = New DataTable("favorites")
    _Favorites.Columns.Add("ranking", GetType(Int32))
    _Favorites.Columns.Add("filename")

    Save()
  End Sub

  Private Sub FavoritesPlaying()

    Dim bmi As New BarMenuInfos(New String() _
    {_RankingNoneGraphic, _RankingNormalGraphic _
    , _RankingHighGraphic, _RankingHigherGraphic} _
    , 1, 9, Me.MP3Console.Colors, 11)
    Dim bm As New BarMenu(Of String)(bmi)

    If bm.ShowMenu = ConsoleExt.DialogResults.Cancel Then Exit Sub

    Select Case bm.Value
    Case _RankingNoneGraphic
      Me.PlayFavorites = Rankings.none
      My.Settings.Ranking = 0
    Case _RankingNormalGraphic
      Me.PlayFavorites = Rankings.normal
      My.Settings.Ranking = 1
    Case _RankingHighGraphic
      Me.PlayFavorites = Rankings.high
      My.Settings.Ranking = 2
    Case _RankingHigherGraphic
      Me.PlayFavorites = Rankings.higher
      My.Settings.Ranking = 3
    End Select

    My.Settings.Save()
    Me.MP3Console.PlayerController.PlayNextSong()
  End Sub

  Private Sub FavoritesView()

    Dim ret = From item In _Favorites.Rows _
    Select New SSP.IndexerLibrary.Title _
    (DirectCast(item, DataRow).Item("filename").ToString)

    If ret.Count = 0 Then Exit Sub

    Dim bmi As New BarMenuInfos(ret.ToArray, 1, 9, Me.MP3Console.Colors, 11)
    Dim bm As New BarMenu(Of SSP.IndexerLibrary.Title)(bmi)
    AddHandler bm.KeyPressed, AddressOf onViewKeyPressed
    AddHandler bm.ItemChanged, AddressOf onViewItemChanged

    Dim result = bm.ShowMenu
    ClearWindow(1, 9, 78, 22)
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi As New BarMenuInfos _
    (New BarMenuDefaultItem(Of FavoritesControlCommands)() _
    {New BarMenuDefaultItem(Of FavoritesControlCommands) _
    ("Favoritensicherung anlegen", Nothing, FavoritesControlCommands.FavoritesBackup) _
    , New BarMenuDefaultItem(Of FavoritesControlCommands) _
    ("Favoritensicherung einspielen", Nothing, FavoritesControlCommands.FavoritesRestore) _
    , New BarMenuDefaultItem(Of FavoritesControlCommands) _
    ("Favoritenwiedergabe", Nothing, FavoritesControlCommands.FavoritesPlaying) _
    , New BarMenuDefaultItem(Of FavoritesControlCommands) _
    ("Favoriten anzeigen", Nothing, FavoritesControlCommands.FavoritesView)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of BarMenuDefaultItem(Of FavoritesControlCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Dim result As SSP.ConsoleExt.DialogResults
    Do
      Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Favoritenmenü")
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case FavoritesControlCommands.FavoritesBackup
        Case FavoritesControlCommands.FavoritesRestore
        Case FavoritesControlCommands.FavoritesView
          FavoritesView()
        Case FavoritesControlCommands.FavoritesPlaying
          FavoritesPlaying()
        End Select
      End If

    Loop Until result = ConsoleExt.DialogResults.Cancel
    ClearWindow(1, 9, 78, 22, Me.MP3Console.Colors.BackColor)

  End Sub

  Public Sub AddFavorit _
  (ByVal title As SSP.IndexerLibrary.Title _
  , ByVal ranking As Rankings)

    RemoveFavorit(title)
    Dim r = _Favorites.NewRow
    r.Item("ranking") = ranking
    r.Item("filename") = title.FileName
    _Favorites.Rows.Add(r)
    Save()
  End Sub

  Public Sub RemoveFavorit _
  (ByVal title As SSP.IndexerLibrary.Title)

    Dim r = findRow(title)
    If r Is Nothing Then Exit Sub

    _Favorites.Rows.Remove(r)
    Save()
  End Sub

  Public Function Count() As Int32
    Return _Favorites.Rows.Count
  End Function

  Public Function Count(ByVal minimumRanking As Rankings) As Int32

    If minimumRanking = Rankings.none Then Return 0

    Dim ret = From item In _Favorites.Rows _
    Where CType(DirectCast(item, DataRow).Item("ranking"), Int32) >= minimumRanking _
    Select item

    Return ret.Count
  End Function

  Public Function GetRanking(ByVal title As SSP.IndexerLibrary.Title) As Rankings

    Dim list = From item In _Favorites.Rows _
    Where DirectCast(item, DataRow).Item("filename").ToString.ToLower _
    = title.FileName.ToLower _
    Select CType(DirectCast(item, DataRow).Item("ranking"), Int32)

    Select Case list.Count
    Case 0
      Return Rankings.none
    Case Else
      Return CType(list(0), Rankings)
    End Select
  End Function

  Public Function GetRankingGraphic _
  (ByVal title As SSP.IndexerLibrary.Title) As String

    Return GetRankingGraphic(Me.GetRanking(title))
  End Function

  Public Function GetRankingGraphic _
  (ByVal ranking As Rankings) As String

    Select Case ranking
    Case Rankings.normal
      Return _RankingNormalGraphic
    Case Rankings.high
      Return _RankingHighGraphic
    Case Rankings.higher
      Return _RankingHigherGraphic
    Case Else
      Return _RankingNoneGraphic
    End Select
  End Function

  Public Function GetRandomTitle _
  (ByVal minimumRanking As Rankings) As SSP.IndexerLibrary.Title

    Dim list = From item In _Favorites.Rows _
    Where CType(DirectCast(item, DataRow).Item("ranking"), Int32) >= minimumRanking _
    Select CType(DirectCast(item, DataRow).Item("filename"), String)

    Select Case list.Count
    Case 0
      Return Nothing
    Case Else
      Dim filename = list(_Rnd.Next(list.Count))
      Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(filename)
      Return New SSP.IndexerLibrary.Title(id3)
    End Select
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class
