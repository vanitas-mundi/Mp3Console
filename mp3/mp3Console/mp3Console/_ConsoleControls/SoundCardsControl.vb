Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls
Imports SSP.IrrklangPlayer

Public Class SoundCardsControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
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
      , BarMenu(Of SoundDevice)).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub SetSoundDevice(ByVal deviceID As String)
    My.Settings.DeviceID = deviceID
    My.Settings.Save()
    Me.MP3Console.PlayerController.Player.InitializePlayer _
    (Me.MP3Console.PlayerController.Player.SoundDevices(deviceID))
    Me.MP3Console.HistoryControl.History.Add _
    (Me.MP3Console.PlayerController.CurrentTitle)
    Me.MP3Console.PlayerController.PlayNextSong()
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show

    Dim list = Me.MP3Console.PlayerController.Player.SoundDevices.Values

    Dim bmi As New BarMenuInfos _
    (list.ToArray, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm As New BarMenu(Of SoundDevice)(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Soundausgabe")

    If (bm.ShowMenu = ConsoleExt.DialogResults.OK) _
    AndAlso (bm.Value IsNot Nothing) Then
      SetSoundDevice(bm.Value.DeviceID)
    End If
  End Sub

  Public Sub InitializeSoundDevice()
    With Me.MP3Console

      Dim count = 0
      Try
        count = .PlayerController.Player.SoundDevices.Count
      Catch ex As Exception
        .PlayerController.Player.InitializePlayer(Nothing)
        Exit Sub
      End Try

      If count <= 1 Then
        .MenuDrawing.DrawMainBorder()
        Dim mb = New ConsoleMessageBox("Sounddevice" _
        , New String() {"Keine installierten Soundgeräte gefunden!"} _
        , 3, 3, 50, Me.MP3Console.Colors)
        mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
        Environment.Exit(0)
      End If

      .MenuDrawing.DrawMainBorder()

      Select Case My.Settings.DeviceID
      Case "[NotSet]"
        Do
          Dim borderSettings = New BorderSettings
          borderSettings.X = 1
          borderSettings.Y = 1
          borderSettings.X2 = 78
          borderSettings.Y2 = 5
          borderSettings.ForeColor = .Colors.BorderColor
          borderSettings.BackColor = .Colors.BackColor
          DrawBorder(borderSettings)

          WriteXY("Bitte Sounddevice wählen!", 3, 3, .Colors)
          Me.Show()
        Loop Until My.Settings.DeviceID <> "[NotSet]"
      End Select

      .PlayerController.Player.InitializePlayer _
      (.PlayerController.Player.SoundDevices(My.Settings.DeviceID))
    End With
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
