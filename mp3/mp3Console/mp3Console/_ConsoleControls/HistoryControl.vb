Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class HistoryControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _History As New Generic.List(Of SSP.IndexerLibrary.Title)
  Private _HistoryIndex As Int32 = 0
  Private Const _MaximalHistorySize As Int32 = 500
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

  Public ReadOnly Property History() _
  As Generic.List(Of SSP.IndexerLibrary.Title)
  Get
    Return _History
  End Get
  End Property

  Public Property HistoryIndex() As Int32
  Get
    Return _HistoryIndex
  End Get
  Set(ByVal value As Int32)
    _HistoryIndex = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onMenuItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of SSP.IndexerLibrary.Title))

    Dim bm = DirectCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))
    Me.MP3Console.MenuDrawing.DrawAdvancedInformationBox _
    (bm.Bounds.HorizontalEnd + 1, e.Item)
  End Sub

  Private Sub onMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Dim bm = DirectCast(sender, BarMenu(Of SSP.IndexerLibrary.Title))

    Dim title = bm.SelectedItem
    If title Is Nothing Then Exit Sub

    With Me.MP3Console

      Select Case e.KeyInfo.Key
      Case ConsoleKey.F1
        e.ExitBarMenu = True
        e.ReturnDialogResult = Nothing
        ClearWindow(DirectCast(sender _
        , BarMenu(Of SSP.IndexerLibrary.Title)).Bounds _
        , Me.MP3Console.Colors.BackColor)
        .HelpViewer.Show(Me)
      Case ConsoleKey.D0, ConsoleKey.NumPad0
        .FavoritesControl.RemoveFavorit(title)
      Case ConsoleKey.D1, ConsoleKey.NumPad1
        .FavoritesControl.AddFavorit _
        (title, FavoritesControl.Rankings.normal)
      Case ConsoleKey.D2, ConsoleKey.NumPad2
        .FavoritesControl.AddFavorit _
        (title, FavoritesControl.Rankings.high)
      Case ConsoleKey.D3, ConsoleKey.NumPad3
        .FavoritesControl.AddFavorit _
        (title, FavoritesControl.Rankings.higher)
      Case ConsoleKey.Tab
        .PlayerController.RepeatMode = Not .PlayerController.RepeatMode
      Case ConsoleKey.Insert
        AddRandomTrack(bm)
        e.ExitBarMenu = True
        Exit Sub
      Case ConsoleKey.Delete
        RemoveFromHistory(bm)
        e.ExitBarMenu = True
        Exit Sub
      Case ConsoleKey.C
        ClearHistory(bm)
        e.ExitBarMenu = True
        Exit Sub
      Case Else
        Exit Sub
      End Select

      .MenuDrawing.DrawTitleInformationBox()
    End With
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub AddRandomTrack _
  (ByVal bm As BarMenu(Of SSP.IndexerLibrary.Title))

    GetNextTitle()
    bm.Add(Me.History.Item(Me.History.Count - 1), True)
  End Sub

  Private Sub GetNextTitle()
    With Me.MP3Console
      Select Case True
      Case (.FavoritesControl.PlayFavorites = FavoritesControl.Rankings.none) _
      OrElse (.FavoritesControl.Count(.FavoritesControl.PlayFavorites) = 0)
        Dim genres = .FilterControl.GetCurrentGenres()
        Select Case genres.Count = 0
        Case True
          Me.History.Add(.IndexControl.Index.IndexData.GetRandomTitle)
        Case Else
          Me.History.Add(.IndexControl.Index.IndexData.GetRandomTitle _
          (genres.ToArray))
        End Select
      Case Else
        Me.History.Add(.FavoritesControl.GetRandomTitle _
        (.FavoritesControl.PlayFavorites))
      End Select
    End With
  End Sub

  Private Sub RemoveFromHistory _
  (ByVal bm As BarMenu(Of SSP.IndexerLibrary.Title))

    Select Case Me.History.Count
    Case Is <= 1
      ClearHistory(bm)
    Case Else
      Me.History.RemoveAt(bm.SelectedIndex)
      If Me.HistoryIndex > Me.History.Count - 1 Then
        Me.HistoryIndex = Me.History.Count - 1
      End If

      If Me.HistoryIndex > bm.SelectedIndex Then
        Me.HistoryIndex -= 1
      End If

      bm.RemoveAt(bm.SelectedIndex, True)
    End Select
  End Sub

  Private Sub ClearHistory _
  (ByVal bm As BarMenu(Of SSP.IndexerLibrary.Title))
    Me.History.Clear()
    Me.HistoryIndex = -1
    Me.GetNextTitle()
    Me.MP3Console.PlayerController.PlayNextSong()
    bm.Clear()
    bm.Add(Me.History.Item(0), True)
  End Sub

  Private Sub DrawCommandLine()
    WriteXY("<TAB> Repeatmode   <Einfg> Zufallstitel   <Entf> Entfernen   <C> Leeren" _
    , 7, 22, Me.MP3Console.Colors)
  End Sub

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show

    Dim bmi As New SSP.ConsoleExt.BarMenus.BarMenuInfos _
    (Me.History.ToArray _
    , Me.HistoryIndex, 1, 9 _
    , Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of SSP.IndexerLibrary.Title)(bmi)
    AddHandler bm.ItemChanged, AddressOf onMenuItemChanged
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3Console.MenuDrawing.DrawMenuFooter("Menü Spielhistorie")
    DrawCommandLine()

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Me.HistoryIndex = bm.SelectedIndex - 1
      Me.MP3Console.PlayerController.PlayNextSong()
    End Select
    ClearLine(22, 1, 78, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub InitializeHistory()
    Me.HistoryIndex = 0

    If (My.Settings.LastPlayedSong.Length > 0) _
    AndAlso (My.Computer.FileSystem.FileExists _
    (My.Settings.LastPlayedSong)) Then
      Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(My.Settings.LastPlayedSong)
      Me.History.Add _
      (New SSP.IndexerLibrary.Title(id3))
    Else
			GetNextTitle()
    End If
  End Sub

  Public Sub ExpandHistory()
    If Me.HistoryIndex < Me.History.Count - 1 Then Exit Sub

    If Me.MP3Console.PlayerController.RepeatMode Then
      Me.HistoryIndex = -1
      Exit Sub
    End If

    'Prüfen ob _MaximalHistorySize erreicht
    If Me.History.Count > _MaximalHistorySize Then
      Do
        Me.History.RemoveAt(0)
      Loop Until Me.History.Count <= _MaximalHistorySize
      Me.HistoryIndex = Me.History.Count - 1
    End If

    GetNextTitle()
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
