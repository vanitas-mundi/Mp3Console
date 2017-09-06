Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls
Imports SSP.IrrklangPlayer

Public Class EffectsControl

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
      , BarMenu(Of BarMenuDefaultItem(Of PlayerEffects))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.ChorusSoundEffect)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.CompressorSoundEffect)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.DistortionSoundEffect)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.EchoSoundEffect)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.FlangerSoundEffect)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.GargleSoundEffect)
    Case ConsoleKey.F8
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.I3DL2ReverbSoundEffect)
    Case ConsoleKey.F9
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.ParamEqSoundEffect)
    Case ConsoleKey.F10
      e.ExitBarMenu = True
      e.ReturnDialogResult = ConsoleExt.DialogResults.OK
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of PlayerEffects)("", -1, PlayerEffects.WavesReverbSoundEffect)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub AddRemoveEffect(ByVal effect As PlayerEffects)

    If Not Me.MP3console.PlayerController.Player.SelectectEffects.Contains(effect) Then
      Me.MP3Console.PlayerController.Player.AddEffect(effect)
    Else
      Me.MP3Console.PlayerController.Player.RemoveEffect(effect)
    End If
  End Sub

  Private Function GetEffectName _
  (ByVal effect As PlayerEffects, ByVal fKey As Byte) As String

    Dim value = ""
    Select Case Me.MP3Console.PlayerController.Player.SelectectEffects.Contains(effect)
    Case True
      value = "* " & effect.ToString
    Case Else
      value = "  " & effect.ToString
    End Select

    value &= Space(25 - value.Length) & "<F" & fKey & ">"
    Return value
  End Function

  Private Function GetGui(ByVal selectedIndex As Int32) _
  As BarMenu(Of BarMenuDefaultItem(Of PlayerEffects))

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of PlayerEffects)() _
    {New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.ChorusSoundEffect, 2) _
    , Nothing, PlayerEffects.ChorusSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.CompressorSoundEffect, 3) _
    , Nothing, PlayerEffects.CompressorSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.DistortionSoundEffect, 4) _
    , Nothing, PlayerEffects.DistortionSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.EchoSoundEffect, 5) _
    , Nothing, PlayerEffects.EchoSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.FlangerSoundEffect, 6) _
    , Nothing, PlayerEffects.FlangerSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.GargleSoundEffect, 7) _
    , Nothing, PlayerEffects.GargleSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.I3DL2ReverbSoundEffect, 8) _
    , Nothing, PlayerEffects.I3DL2ReverbSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.ParamEqSoundEffect, 9) _
    , Nothing, PlayerEffects.ParamEqSoundEffect) _
    , New BarMenuDefaultItem(Of PlayerEffects) _
    (GetEffectName(PlayerEffects.WavesReverbSoundEffect, 10) _
    , Nothing, PlayerEffects.WavesReverbSoundEffect)} _
    , selectedIndex, 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of PlayerEffects))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed
    Return bm
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bm = GetGui(0)
    Dim result As SSP.ConsoleExt.DialogResults

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Effekte")

    Do
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        AddRemoveEffect(bm.Value.Object)
      End If
      bm = GetGui(bm.SelectedIndex)
    Loop Until result = ConsoleExt.DialogResults.Cancel
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
