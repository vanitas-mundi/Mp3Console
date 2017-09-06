Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class AdministrationControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum AdministrationCommands
    FilterControl = 0
    FavoritesControl = 1
    IndexControl = 2
    SoundcardsControl = 3
    Outsourcing = 4
    Playlist = 5
    ShutDownControl = 6
    ColorControl = 7
    Info = 8
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _IndexControl As IndexControl
  Private _FilterControl As FilterControl
  Private _SoundcardsControl As SoundCardsControl
  Private _OutsourcingControl As OutsourcingControl
  Private _PlayListControl As PlaylistControl
  Private _ShutDownControl As ShutDownControl
  Private _ColorControl As ColorControl
  Private _mp3Console As mp3Console
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
    _FilterControl = New FilterControl(_mp3Console)
    _IndexControl = New IndexControl(_mp3Console)
    _SoundcardsControl = New SoundCardsControl(_mp3Console)
    _OutsourcingControl = New OutsourcingControl(_mp3Console)
    _PlayListControl = New PlaylistControl(_mp3Console)
    _ShutDownControl = New ShutDownControl(_mp3Console)
    _ColorControl = New ColorControl(_mp3Console)
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

  Public ReadOnly Property ShutDownControl() As ShutDownControl
  Get
    Return _ShutDownControl
  End Get
  End Property

  Public ReadOnly Property FilterControl As FilterControl
  Get
    Return _FilterControl
  End Get
  End Property

  Public ReadOnly Property SoundCardsControl As SoundCardsControl
  Get
    Return _SoundcardsControl
  End Get
  End Property

  Public ReadOnly Property IndexControl As IndexControl
  Get
    Return _IndexControl
  End Get
  End Property

  Public ReadOnly Property OutsourcingControl As OutsourcingControl
  Get
    Return _OutsourcingControl
  End Get
  End Property

  Public ReadOnly Property PlayListControl As PlaylistControl
  Get
    Return _PlayListControl
  End Get
  End Property

  Public ReadOnly Property ColorControl As ColorControl
  Get
    Return _ColorControl
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
      , BarMenu(Of BarMenuDefaultItem(Of AdministrationCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.FilterControl)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.FavoritesControl)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.IndexControl)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.SoundcardsControl)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.Outsourcing)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.Playlist)
    Case ConsoleKey.F8
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.ShutDownControl)
    Case ConsoleKey.F9
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.ColorControl)
    Case ConsoleKey.F12
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of AdministrationCommands)(Nothing, Nothing _
      , AdministrationCommands.Info)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of AdministrationCommands)() _
    {New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Filterverwaltung         (F2) ->", Nothing, AdministrationCommands.FilterControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Favoritenverwaltung      (F3) ->", Nothing, AdministrationCommands.FavoritesControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Indexverwaltung          (F4) ->", Nothing, AdministrationCommands.IndexControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Soundausgabe             (F5) ->", Nothing, AdministrationCommands.SoundcardsControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Wechselmediumauslagerung (F6) ->", Nothing, AdministrationCommands.Outsourcing) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Palylist anlegen         (F7) ->", Nothing, AdministrationCommands.Playlist) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Systemshutdown           (F8) ->", Nothing, AdministrationCommands.ShutDownControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Farbverwaltung           (F9) ->", Nothing, AdministrationCommands.ColorControl) _
    , New BarMenuDefaultItem(Of AdministrationCommands) _
    ("Info                     (12)", Nothing, AdministrationCommands.Info)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of AdministrationCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Verwaltung")

    If (bm.ShowMenu = ConsoleExt.DialogResults.OK) _
    AndAlso (bm.Value IsNot Nothing) Then
      Select Case bm.Value.Object
      Case AdministrationCommands.FilterControl
        _FilterControl.Show()
      Case AdministrationCommands.FavoritesControl
        Me.MP3Console.FavoritesControl.Show()
      Case AdministrationCommands.IndexControl
        _IndexControl.Show()
      Case AdministrationCommands.SoundcardsControl
        _SoundcardsControl.Show()
      Case AdministrationCommands.Outsourcing
        _OutsourcingControl.Show()
      Case AdministrationCommands.Playlist
        _PlayListControl.Show()
      Case AdministrationCommands.ShutDownControl
        _ShutDownControl.Show()
      Case AdministrationCommands.ColorControl
        _ColorControl.Show()
      Case AdministrationCommands.Info
        Me.MP3Console.MenuDrawing.DrawAboutBox()
      End Select
    End If
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
