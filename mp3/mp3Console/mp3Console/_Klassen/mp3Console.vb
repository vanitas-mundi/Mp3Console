Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class mp3Console

  Implements Imp3ConsoleControl

#Region " -------------- Enumerationen der Klasse -------------- "
  Private Enum MainCommands
    Play = 0
    [Next] = 1
    Prev = 2
    VolumeAndSeek = 3
    Effects = 4
    Songtext = 5
    DirectSelection = 6
    Search = 7
    Id3TagEditor = 8
    Administration = 9
    ShowHistory = 10
  End Enum
#End Region

#Region " -------------- Eigenschaften der Klasse -------------- "
  '{Options                           }
  '{/a          Atuoplay              }
  '{/s:minutes  Shutdown nach Minuten }
  '{/r          Reset Configuration   }
  '{/?          Hilfe anzeigen        }
  Private WithEvents _Arguments As New SSP.ConsoleExt.ArgumentsParser _
  (New String() {"a", "s", "r", "?"}, 1, True)

  Private _Initialized As Boolean = False
  Private _MainMenu As BarMenu(Of BarMenuDefaultItem(Of MainCommands))
  Private _Colors As New SSP.ConsoleExt.ColorSet

  Private _HelpViewer As New HelpViewer(Me)
  Private _MenuDrawing As New MenuDrawing(Me)
  Private _PlayerController As New PlayerController(Me)

  Private _AdministrationControl As New AdministrationControl(Me)
  Private _DirectSelectionControl As New DirectSelectionControl(Me)
  Private _EffectsControl As New EffectsControl(Me)
  Private _FavoritesControl As New FavoritesControl(Me)
  Private _Id3TagEditorControl As New Id3EditorControl(Me)
  Private _HistoryControl As New HistoryControl(Me)
  Private _SearchControl As New SearchControl(Me)
  Private _SongTextControl As New SongTextControl(Me)
  Private _VolumeAndSeekControl As New VolumeAndSeekControl(Me)
#End Region

#Region " -------------- Konstruktor/ Destruktor der Klasse -------------- "
  Public Sub New()
    Console.Title = "mp3Console"
    _Colors.BorderColor = CType(My.Settings.BorderColor, ConsoleColor)
    _Colors.ForeColor = CType(My.Settings.ForeColor, ConsoleColor)
    _Colors.BackColor = CType(My.Settings.BackColor, ConsoleColor)
    _Colors.SelectionForeColor = CType(My.Settings.SelectionForeColor, ConsoleColor)
    _Colors.SelectionBackColor = CType(My.Settings.SelectionBackColor, ConsoleColor)
  End Sub
#End Region

#Region " -------------- Zugriffsmethoden der Klasse -------------- "
  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3ConsoleControl.MP3Console
  Get
    Return Me
  End Get
  End Property

  Public ReadOnly Property Arguments As SSP.ConsoleExt.ArgumentsParser
  Get
    Return _Arguments
  End Get
  End Property

  Public ReadOnly Property Colors() As SSP.ConsoleExt.ColorSet
  Get
    Return _Colors
  End Get
  End Property

  Public ReadOnly Property HelpViewer As HelpViewer
  Get
    Return _HelpViewer
  End Get
  End Property

  Public ReadOnly Property MenuDrawing As MenuDrawing
  Get
    Return _MenuDrawing
  End Get
  End Property

  Public ReadOnly Property PlayerController As PlayerController
  Get
    Return _PlayerController
  End Get
  End Property

  Public ReadOnly Property AdministrationControl As AdministrationControl
  Get
    Return _AdministrationControl
  End Get
  End Property

  Public ReadOnly Property DirectSelectionControl As DirectSelectionControl
  Get
    Return _DirectSelectionControl
  End Get
  End Property

  Public ReadOnly Property EffectsControl As EffectsControl
  Get
    Return _EffectsControl
  End Get
  End Property

  Public ReadOnly Property FavoritesControl As FavoritesControl
  Get
    Return _FavoritesControl
  End Get
  End Property

  Public ReadOnly Property FilterControl As FilterControl
  Get
    Return _AdministrationControl.FilterControl
  End Get
  End Property

  Public ReadOnly Property Id3TagEditorControl As Id3EditorControl
  Get
    Return _Id3TagEditorControl
  End Get
  End Property

  Public ReadOnly Property IndexControl As IndexControl
  Get
    Return _AdministrationControl.IndexControl
  End Get
  End Property

  Public ReadOnly Property HistoryControl As HistoryControl
  Get
    Return _HistoryControl
  End Get
  End Property

  Public ReadOnly Property SearchControl As SearchControl
  Get
    Return _SearchControl
  End Get
  End Property

  Public ReadOnly Property SongTextControl As SongTextControl
  Get
    Return _SongTextControl
  End Get
  End Property

  Public ReadOnly Property VolumeAndSeekControl As VolumeAndSeekControl
  Get
    Return _VolumeAndSeekControl
  End Get
  End Property
#End Region

#Region " ------------- Ereignismethoden der Klasse ------------ "
  Private Sub onShowHelpPage _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles _Arguments.ShowHelpPage

    Console.WriteLine("MP3CONSOLE [Dateiname] [/a] [/s:minutes]")
    Console.WriteLine("  [Dateiname] - Abzuspielende MP3-Datei oder Playlist.")
    Console.WriteLine("  /a          - Autoplay. Automatische Wiedergabe nach Programmstart.")
    Console.WriteLine("  /s          - Shutdown. Fährt den Rechner nach [minutes] Minuten herunter.")
    Console.WriteLine("  /r          - Konfiguration zurücksetzen.")
  End Sub

  Private Sub onMainMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.D0, ConsoleKey.NumPad0
      Me.FavoritesControl.RemoveFavorit _
      (Me.PlayerController.CurrentTitle)
      Me.MenuDrawing.DrawTitleInformationBox()
    Case ConsoleKey.D1, ConsoleKey.NumPad1
      Me.FavoritesControl.AddFavorit _
      (Me.PlayerController.CurrentTitle _
      , FavoritesControl.Rankings.normal)
      Me.MenuDrawing.DrawTitleInformationBox()
    Case ConsoleKey.D2, ConsoleKey.NumPad2
      Me.FavoritesControl.AddFavorit _
      (Me.PlayerController.CurrentTitle _
      , FavoritesControl.Rankings.high)
      Me.MenuDrawing.DrawTitleInformationBox()
    Case ConsoleKey.D3, ConsoleKey.NumPad3
      Me.FavoritesControl.AddFavorit _
      (Me.PlayerController.CurrentTitle _
      , FavoritesControl.Rankings.higher)
      Me.MenuDrawing.DrawTitleInformationBox()
    Case ConsoleKey.F1
      e.ExitBarMenu = True
      e.ReturnDialogResult = Nothing
      ClearWindow(DirectCast(sender _
      , BarMenu(Of BarMenuDefaultItem(Of MainCommands))).Bounds, _Colors.BackColor)
      Me.HelpViewer.Show(Me)
    Case ConsoleKey.Spacebar, ConsoleKey.MediaPlay
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Play)
    Case ConsoleKey.LeftArrow, ConsoleKey.NumPad4, ConsoleKey.MediaPrevious
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Prev)
    Case ConsoleKey.RightArrow, ConsoleKey.NumPad6, ConsoleKey.MediaNext
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Next)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Search)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.DirectSelection)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      Me.MenuDrawing.RefreshMainMenu(_MainMenu.Bounds.HorizontalEnd + 1)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.VolumeAndSeek)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Effects)
    Case ConsoleKey.F8
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.ShowHistory)
    Case ConsoleKey.F9
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Songtext)
    Case ConsoleKey.F11
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Id3TagEditor)
    Case ConsoleKey.F12
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of MainCommands)(Nothing, Nothing, MainCommands.Administration)
    Case ConsoleKey.Tab
      Me.PlayerController.RepeatMode = Not Me.PlayerController.RepeatMode
      Me.MenuDrawing.DrawTitleInformationBox()
    End Select
  End Sub
#End Region

#Region " -------------- Private Methoden der Klasse -------------- "
  Private Sub ResetConfiguartion()
    My.Settings.Reset()
    My.Settings.Save()
  End Sub

  Private Sub InitializeArguments()
    If _Arguments.Parameters.Count = 0 Then Exit Sub

    Dim fileName = _Arguments.Parameters.Item(0).ToLower
    If Not My.Computer.FileSystem.FileExists(fileName) Then Exit Sub

    Select Case True
    Case fileName.EndsWith(".mp3")
      _DirectSelectionControl.SelectSong(fileName)
      Me.HistoryControl.HistoryIndex += 1
    Case fileName.EndsWith(".m3u")
      _DirectSelectionControl.SelectPlayList _
      (fileName, My.Computer.FileSystem.GetParentPath(fileName))
      Me.HistoryControl.HistoryIndex += 1
    End Select
  End Sub

  Private Sub InitializeMainMenu()

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of MainCommands)() _
    {New BarMenuDefaultItem(Of MainCommands) _
    ("Wiedergabe/Pause  (Leertaste)", Nothing, MainCommands.Play) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Nächster Titel    (Pfeil rechts)", Nothing, MainCommands.Next) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Vorheriger Titel  (Pfeil links)", Nothing, MainCommands.Prev) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Lautstärke/ Suchlauf (F6) ->", Nothing, MainCommands.VolumeAndSeek) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Effekte              (F7) ->", Nothing, MainCommands.Effects) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Suche                (F3) ->", Nothing, MainCommands.Search) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Direktwahl           (F4) ->", Nothing, MainCommands.DirectSelection) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Historie anzeigen    (F8) ->", Nothing, MainCommands.ShowHistory) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Songtext/Cover       (F9) ->", Nothing, MainCommands.Songtext) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("ID3-Tag-Editor       (F11) ->", Nothing, MainCommands.Id3TagEditor) _
    , New BarMenuDefaultItem(Of MainCommands) _
    ("Verwaltung           (F12) ->", Nothing, MainCommands.Administration)} _
    , 1, 9, Me.Colors, 11)

    _MainMenu = New BarMenu(Of BarMenuDefaultItem(Of MainCommands))(bmi)
    AddHandler _MainMenu.KeyPressed, AddressOf onMainMenuKeyPressed
  End Sub

  Private Sub InitialzeMp3Console()
		_Arguments.Parse(My.Application.CommandLineArgs.ToArray)
    If _Arguments.OptionExists("r") Then ResetConfiguartion()

    Me.IndexControl.CheckIndex()

    Me.MenuDrawing.DrawSplashscreen("Lade Index ...")

    Me.FilterControl.InitializeFilter()
    Me.FilterControl.LoadFilter()

    Me.IndexControl.LoadIndex()

		Me.HistoryControl.InitializeHistory()
    InitializeArguments()

    Me.AdministrationControl.SoundCardsControl.InitializeSoundDevice()

    Me.PlayerController.InitializePlayerController()

    Me.PlayerController.RestoreLastPlayedTitle()

    Me.AdministrationControl.ShutDownControl.InitializeShutDownArgument()

    Me.MenuDrawing.DrawMainBorder()
    Me.MenuDrawing.DrawTitleInformationBox()
    _Initialized = True
  End Sub
#End Region

#Region " -------------- Öffentliche Methoden der Klasse -------------- "
  Public Sub Show() Implements Imp3ConsoleControl.Show

    If Not _Initialized Then
      InitialzeMp3Console()
      InitializeMainMenu()
    End If

    Dim result As SSP.ConsoleExt.DialogResults

    Do
      Me.MenuDrawing.DrawMenuFooter("Hauptmenü")

      Me.MenuDrawing.DrawSettingsBox(_MainMenu.Bounds.HorizontalEnd + 1)

      result = _MainMenu.ShowMenu

      Me.MenuDrawing.ClearSettingsBox()

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (_MainMenu.Value IsNot Nothing) Then
        Select Case _MainMenu.Value.Object
        Case MainCommands.Play
          Me.PlayerController.PlaySong()
        Case MainCommands.Next
          Me.PlayerController.PlayNextSong()
        Case MainCommands.Prev
          Me.PlayerController.PlayPreviousSong()
        Case MainCommands.VolumeAndSeek
          _VolumeAndSeekControl.Show()
        Case MainCommands.Effects
          _EffectsControl.Show()
        Case MainCommands.Songtext
          _SongTextControl.Show()
        Case MainCommands.DirectSelection
          _DirectSelectionControl.Show()
        Case MainCommands.Search
          _SearchControl.Show()
        Case MainCommands.Id3TagEditor
          _Id3TagEditorControl.Show()
        Case MainCommands.Administration
          _AdministrationControl.Show()
        Case MainCommands.ShowHistory
          _HistoryControl.Show()
        End Select
      End If
    Loop Until result = ConsoleExt.DialogResults.Cancel
  End Sub
#End Region

End Class
