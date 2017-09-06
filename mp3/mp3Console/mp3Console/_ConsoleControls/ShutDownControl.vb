Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class ShutDownControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum ShutDownCommands
    AddShutDown = 0
    RemoveShutDown = 1
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private WithEvents _ShutDownTimer As New Timers.Timer
  Private _mp3Console As mp3Console
  Private _ShutDownAt As DateTime? = Nothing
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

  Public ReadOnly Property ShutDownAt() As DateTime?
  Get
    Return _ShutDownAt
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
      , BarMenu(Of BarMenuDefaultItem(Of ShutDownCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ShutDownCommands)(Nothing, Nothing, ShutDownCommands.AddShutDown)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ShutDownCommands)(Nothing, Nothing, ShutDownCommands.RemoveShutDown)
    End Select
  End Sub

  Private Sub onShutDownTimerElapsed _
  (ByVal sender As Object _
  , ByVal e As System.Timers.ElapsedEventArgs) _
  Handles _ShutDownTimer.Elapsed

    _ShutDownTimer.Stop()
    BCW.ShutDown.WindowsController.ExitWindows _
    (BCW.ShutDown.RestartOptions.ShutDown, True)
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub AddShutDown()
    Dim ib As New ConsoleInputBox(Of Double)("Systemshutdown" _
    , "In wievielen Miuten soll das System herunter gefahren werden?" _
    , 60, 1, 9, 65, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.OK
      StartShutDown(ib.Value)
    End Select
  End Sub

  Private Sub RemoveShutDown()
    _ShutDownAt = Nothing
    _ShutDownTimer.Stop()
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of ShutDownCommands)() _
    {New BarMenuDefaultItem(Of ShutDownCommands) _
    ("Shutdown setzen    (F2)", Nothing, ShutDownCommands.AddShutDown) _
    , New BarMenuDefaultItem(Of ShutDownCommands) _
    ("Shutdown abbrechen (F3)", Nothing, ShutDownCommands.RemoveShutDown)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of ShutDownCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed
    Dim result As SSP.ConsoleExt.DialogResults

    Do
      Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Shutdown")
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case ShutDownCommands.AddShutDown
          AddShutDown()
        Case ShutDownCommands.RemoveShutDown
          RemoveShutDown()
        End Select
      End If
    Loop Until result = ConsoleExt.DialogResults.Cancel
  End Sub

  Public Sub InitializeShutDownArgument()
    With Me.MP3Console
      If .Arguments.OptionExists("s") Then
        Try
          Dim minutes = CType(.Arguments.OptionValue("s"), Double)
          Me.StartShutDown(minutes)
        Catch ex As Exception
        End Try
      End If
      If .Arguments.OptionExists("a") Then .PlayerController.PlaySong()
    End With
  End Sub

  Public Sub StartShutDown(ByVal startInMinutes As Double)
    _ShutDownAt = DateTime.Now.AddMinutes(startInMinutes)
    _ShutDownTimer.Interval = startInMinutes * 60000
    _ShutDownTimer.Start()
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
