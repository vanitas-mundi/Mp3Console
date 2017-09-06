Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class VolumeAndSeekControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum VolumeAndSeekCommands
    Increase = 0
    Decrease = 1
    CustomVolume = 2
    SeekForward = 3
    SeekBackward = 4
    EditSeekDistance = 5
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
      , BarMenu(Of BarMenuDefaultItem(Of VolumeAndSeekCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.OemMinus, ConsoleKey.Subtract
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of VolumeAndSeekCommands)(Nothing, Nothing, VolumeAndSeekCommands.Decrease)
    Case ConsoleKey.OemPlus, ConsoleKey.Add
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of VolumeAndSeekCommands)(Nothing, Nothing, VolumeAndSeekCommands.Increase)
    Case ConsoleKey.D0 To ConsoleKey.D9
      Dim value = CType(e.KeyInfo.Key, Int32) - 48
      If value > 0 Then value += 1

      My.Settings.CurrentVolume = CType(value * 10, Byte)
      My.Settings.Save()
      Me.MP3Console.MenuDrawing.DrawTitleInformationBox()
      Me.MP3Console.PlayerController.Player.Volume = My.Settings.CurrentVolume

    Case ConsoleKey.RightArrow, ConsoleKey.NumPad6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of VolumeAndSeekCommands)(Nothing, Nothing, VolumeAndSeekCommands.SeekForward)
    Case ConsoleKey.LeftArrow, ConsoleKey.NumPad4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of VolumeAndSeekCommands)(Nothing, Nothing, VolumeAndSeekCommands.SeekBackward)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub IncreaseVolume()
    Select Case Me.MP3Console.PlayerController.Player.Volume
    Case Is <= 90
      My.Settings.CurrentVolume _
      = CType(((Me.MP3Console.PlayerController.Player.Volume \ 10) * 10) + 10, Byte)
    Case Else
      My.Settings.CurrentVolume = 100
    End Select
    Me.MP3console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Private Sub DecreaseVolume()
    Select Case Me.MP3Console.PlayerController.Player.Volume
    Case Is >= 10
      My.Settings.CurrentVolume _
      = CType(((Me.MP3Console.PlayerController.Player.Volume \ 10) * 10) - 10, Byte)
    Case Else
      My.Settings.CurrentVolume = 0
    End Select
    Me.MP3console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Private Sub SetCustimeVolume()
      Dim ib As New ConsoleInputBox(Of Byte) _
    ("Suchlaufdistanz", "Bitte Lautstärke eingeben (0 - 100):" _
    , 1, 9, 40, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Select Case ib.Value
    Case 0 To 100
      My.Settings.CurrentVolume = CType(ib.Value, Byte)
      Me.MP3console.MenuDrawing.DrawTitleInformationBox()
    End Select
  End Sub

  Private Sub SeekForward()
    With Me.MP3Console.PlayerController
      If SeekDistanceIsPercent() Then
        .Player.CurrentPositionPercentDouble += GetSeekDistance()
      Else
        .Player.CurrentPositionUInt += CUInt(GetSeekDistance())
      End If
    End With
  End Sub

  Private Sub SeekBackward()
    With Me.MP3Console.PlayerController
      If SeekDistanceIsPercent() Then
        .Player.CurrentPositionPercentDouble -= GetSeekDistance()
      Else
        .Player.CurrentPositionUInt -= CUInt(GetSeekDistance())
      End If
    End With
  End Sub

  Private Function SeekDistanceIsPercent() As Boolean
    Return My.Settings.SeekDistance.Contains("%")
  End Function

  Private Sub SetSeekDistance()
    Dim mb = New ConsoleOptionBox("Suchlaufdistanz" _
    , New String() {"Angabe in %", "Angabe in Sekunden"} _
    , 1, 9, 30, Me.MP3Console.Colors)

    Dim extension As String = ""

    Select Case mb.ShowOptions
    Case ConsoleExt.OptionBoxResults.Option1
      extension = "%"
    Case ConsoleExt.OptionBoxResults.Option2
      extension = " Sekunden"
    Case Else
      Exit Sub
    End Select

    Dim ib As New ConsoleInputBox(Of Byte) _
    ("Suchlaufdistanz", "Bitte " & extension.Trim & " eingeben (5 - 100):" _
    , 1, 9, 40, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Select Case ib.Value
    Case 5 To 100
      My.Settings.SeekDistance = ib.Value & extension
      My.Settings.Save()
    End Select
  End Sub

  Private Function GetSeekDistance() As Double
    Select Case SeekDistanceIsPercent()
    Case True
      Return CType(My.Settings.SeekDistance.Replace("%", ""), Int32)
    Case Else
      Dim seconds = CType(My.Settings.SeekDistance.Replace(" Sekunden", ""), Int32)
      Return seconds
    End Select
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of VolumeAndSeekCommands)() _
    {New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Lautstärke erhöhen (+)", Nothing, VolumeAndSeekCommands.Increase) _
    , New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Lautstärke senken  (-)", Nothing, VolumeAndSeekCommands.Decrease) _
    , New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Lautstärke eingeben", Nothing, VolumeAndSeekCommands.CustomVolume) _
    , New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Suchlauf vor    (Pfeil rechts)", Nothing, VolumeAndSeekCommands.SeekForward) _
    , New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Suchlauf zurück (Pfeil links)", Nothing, VolumeAndSeekCommands.SeekBackward) _
    , New BarMenuDefaultItem(Of VolumeAndSeekCommands) _
    ("Suchlaufdistanz (" & My.Settings.SeekDistance & ")" _
    , Nothing, VolumeAndSeekCommands.EditSeekDistance)} _
    , 1, 12, Me.MP3Console.Colors, 6)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of VolumeAndSeekCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed
    Dim result As SSP.ConsoleExt.DialogResults

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Lautst./Suchlauf")

    Do
      SSP.ConsoleExt.Tools.WriteXY _
      ("Lautstärkeschnelltasten (0 - 9)", 2, 10, Me.MP3Console.Colors)
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case VolumeAndSeekCommands.Increase
          IncreaseVolume()
        Case VolumeAndSeekCommands.Decrease
          DecreaseVolume()
        Case VolumeAndSeekCommands.CustomVolume
          SetCustimeVolume()
        Case VolumeAndSeekCommands.SeekForward
          SeekForward()
        Case VolumeAndSeekCommands.SeekBackward
          SeekBackward()
        Case VolumeAndSeekCommands.EditSeekDistance
          SetSeekDistance()
          result = ConsoleExt.DialogResults.Cancel
          Me.Show()
        End Select
        My.Settings.Save()
        Me.MP3Console.PlayerController.Player.Volume = My.Settings.CurrentVolume
      End If
    Loop Until result = ConsoleExt.DialogResults.Cancel

  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
