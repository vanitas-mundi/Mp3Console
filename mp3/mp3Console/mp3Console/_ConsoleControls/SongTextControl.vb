Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class SongTextControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum SongTextCommands
    ActiveSong = 0
    ArchivSelect = 1
    UserInput = 2
    ActiveSongCover = 3
    ArchivSelectCover = 4
    UserInputCover = 5
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private Const _LyricsUrl As String = "http://lyrics.wikia.com/"
  Private Const _CoverUrl As String = "http://www.albumart.org/index.php"
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
      , BarMenu(Of BarMenuDefaultItem(Of SongTextCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.ActiveSong)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.ArchivSelect)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.UserInput)
    Case ConsoleKey.F8
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.ActiveSongCover)
    Case ConsoleKey.F9
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.ArchivSelectCover)
    Case ConsoleKey.F10
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of SongTextCommands)(Nothing, Nothing, SongTextCommands.UserInputCover)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub ShowSongtext _
  (ByVal artist As String _
  , ByVal title As String)

    If title Is Nothing Then Exit Sub

    Try
      Dim url = _LyricsUrl _
      & artist.Replace(" ", "_") & ":" _
      & title.Replace(" ", "_")
      Process.Start(url)
    Catch ex As Exception
      Dim mb = New SSP.ConsoleExt.Controls.ConsoleMessageBox _
      ("Songtext", New String() {ex.Message} _
      , 1, 9, 50, Me.MP3Console.Colors)
      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
    End Try
  End Sub

  Private Sub ShowCover _
  (ByVal artist As String _
  , ByVal title As String)

    If title Is Nothing Then Exit Sub

    Try
      Dim url = _CoverUrl & "?srchkey=" _
      & (artist.Replace(" ", "+")) & "+" _
      & (title.Replace(" ", "+")) _
      & "&itempage=1&newsearch=1&searchindex=Music"
      Process.Start(url)
    Catch ex As Exception
      Dim mb = New SSP.ConsoleExt.Controls.ConsoleMessageBox _
      ("Cover", New String() {ex.Message} _
      , 1, 9, 50, Me.MP3Console.Colors)
      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
    End Try
  End Sub

  Private Sub ShowSongtext()
    ShowSongtext(Me.MP3Console.PlayerController.CurrentTitle.Id3.Artist _
    , Me.MP3Console.PlayerController.CurrentTitle.Id3.Title)
  End Sub

  Private Sub ShowCover()
    ShowCover(Me.MP3Console.PlayerController.CurrentTitle.Id3.Artist _
    , Me.MP3Console.PlayerController.CurrentTitle.Id3.Title)
  End Sub

  Private Sub ArchivSelectAndShowSongText()
    Dim bmi As New BarMenuInfos(1, 9, Me.MP3Console.Colors, 11)
    Dim ib As New IndexBrowser _
    (Me.MP3Console.IndexControl.Index, bmi, BrowseTypes.Title)

    Select Case ib.BrowseIndex
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    ShowSongtext(ib.Title.Id3.Artist, ib.Title.Id3.Title)
  End Sub

  Private Sub ArchivSelectAndShowCover()
    Dim bmi As New BarMenuInfos(1, 9, Me.MP3Console.Colors, 11)
    Dim ib As New IndexBrowser _
    (Me.MP3Console.IndexControl.Index, bmi, BrowseTypes.Title)

    Select Case ib.BrowseIndex
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    ShowCover(ib.Title.Id3.Artist, ib.Title.Id3.Title)
  End Sub

  Private Sub UserInputAndShowSongText()

    Dim ib As New ConsoleInputBox(Of String) _
    ("Interpret", "Bitte Interpret eingeben:" _
    , 1, 9, 50, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim artist = ib.Value

    ib = New ConsoleInputBox(Of String) _
    ("Titel", "Bitte Titel eingeben:" _
    , 1, 9, 50, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim title = ib.Value

    ShowSongtext(artist, title)
  End Sub

  Private Sub UserInputAndShowCover()

    Dim ib As New ConsoleInputBox(Of String) _
    ("Interpret", "Bitte Interpret eingeben:" _
    , 1, 9, 50, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim artist = ib.Value

    ib = New ConsoleInputBox(Of String) _
    ("Titel", "Bitte Titel eingeben:" _
    , 1, 9, 50, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim title = ib.Value

    ShowCover(artist, title)
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of SongTextCommands)() _
    {New BarMenuDefaultItem(Of SongTextCommands) _
    ("Aktueller Titel         (F5)", Nothing, SongTextCommands.ActiveSong) _
    , New BarMenuDefaultItem(Of SongTextCommands) _
    ("Indexauswahl            (F6)", Nothing, SongTextCommands.ArchivSelect) _
    , New BarMenuDefaultItem(Of SongTextCommands) _
    ("Benutzereingabe         (F7)", Nothing, SongTextCommands.UserInput) _
    , New BarMenuDefaultItem(Of SongTextCommands) _
    ("Aktueller Titel - Cover (F8)", Nothing, SongTextCommands.ActiveSongCover) _
    , New BarMenuDefaultItem(Of SongTextCommands) _
    ("Indexauswahl - Cover    (F9)", Nothing, SongTextCommands.ArchivSelectCover) _
    , New BarMenuDefaultItem(Of SongTextCommands) _
    ("Benutzereingabe - Cover (F10)", Nothing, SongTextCommands.UserInputCover)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of SongTextCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Songtext")
    If (bm.ShowMenu = ConsoleExt.DialogResults.OK) _
    AndAlso (bm.Value IsNot Nothing) Then
      Select Case bm.Value.Object
      Case SongTextCommands.ActiveSong
        ShowSongtext()
      Case SongTextCommands.ArchivSelect
        ArchivSelectAndShowSongText()
      Case SongTextCommands.UserInput
        UserInputAndShowSongText()
      Case SongTextCommands.ActiveSongCover
        ShowCover()
      Case SongTextCommands.ArchivSelectCover
        ArchivSelectAndShowCover()
      Case SongTextCommands.UserInputCover
        UserInputAndShowCover()
      End Select
    End If

  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class