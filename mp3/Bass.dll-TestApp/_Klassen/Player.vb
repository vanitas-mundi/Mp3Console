Option Explicit On 
Option Strict On
Option Infer On

Imports Un4seen.Bass
Imports BassTags = Un4seen.Bass.AddOn.Tags.BassTags

Namespace Media

#Region " --------------->> Klasse Player "

Public Class Player

Inherits System.Object

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private WithEvents _TimerDuration As New Timer
  Private WithEvents _TimerLevel As New Timer
  Private _Volume As System.Single = 1
  Private _StreamHandle As Int32 = 0
  Private _FileName As String

  Public Event PositionChanged(ByVal sender As Object, ByVal e As PositionChangedEventArgs)
  Public Event EndOfStream(ByVal sender As Object, ByVal e As EventArgs)
  Public Event LevelChanged(ByVal sender As Object, ByVal e As LevelChangedEventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Shared Sub New()
    BassNet.Registration("VanitasMundi@gmx.de", "2X1732919152223")
  End Sub

  Public Sub New(ByVal deviceIndex As System.Int32)
    '{Konstruktor}
    Initialize(deviceIndex)
  End Sub

  Public Sub New()
    '{Konstruktor}
    Initialize(-1)
  End Sub

  Public Sub Initialize(ByVal deviceIndex As System.Int32)
    '_Volume = Bass.BASS_GetVolume
    Select Case Bass.BASS_Init _
    (deviceIndex _
    , 44100 _
    , BASSInit.BASS_DEVICE_DEFAULT _
    , IntPtr.Zero _
    , Nothing)
    Case True
      _TimerDuration.Interval = 1000
      _TimerDuration.Stop()
      _TimerLevel.Interval = 50
      _TimerLevel.Stop()
    Case False
      MsgBox("BASS Init Error!")
    End Select
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    Dispose()
  End Sub

  Public Sub Dispose()
    Bass.BASS_ChannelStop(_StreamHandle)
    Bass.BASS_StreamFree(_StreamHandle)
    Bass.BASS_Stop()
    Bass.BASS_Free()
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property FileName() As String
  Get
    Return _FileName
  End Get
  Set(ByVal value As String)
    Me.Stop()
    _FileName = value

    _StreamHandle = Bass.BASS_StreamCreateFile _
    (_FileName, 0, 0, BASSFlag.BASS_DEFAULT)

    Select Case _StreamHandle
    Case 0
      MsgBox("Error!")
    End Select
    Me.SetVolume(_Volume)

  End Set
  End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub TimerStart()
    _TimerDuration.Start()
    _TimerLevel.Start()
  End Sub

  Private Sub TimerStop()
    _TimerDuration.Stop()
    _TimerLevel.Stop()
  End Sub

  Private Sub FadeIn()

    For curVolume As Single = 0 To _Volume Step 0.1
      Me.SetVolume(curVolume)
      Threading.Thread.Sleep(50)
    Next curVolume
  End Sub

  Private Sub FadeOut()

    Dim pos As Long = Bass.BASS_ChannelGetPosition(_StreamHandle)

    For curVolume As Single = _Volume To 0 Step -0.1
      Me.SetVolume(curVolume)
      Threading.Thread.Sleep(50)
    Next curVolume

    Threading.Thread.Sleep(200)
    Bass.BASS_ChannelSetPosition(_StreamHandle, pos)
  End Sub

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  Private Sub TimerDuration_Tick _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles _TimerDuration.Tick

    Dim len As System.Double _
    = Bass.BASS_ChannelBytes2Seconds(_StreamHandle _
    , Bass.BASS_ChannelGetLength(_StreamHandle))

    Dim pos As System.Double _
    = Bass.BASS_ChannelBytes2Seconds(_StreamHandle _
    , Bass.BASS_ChannelGetPosition(_StreamHandle))

    RaiseEvent PositionChanged _
    (Me, New PositionChangedEventArgs(_StreamHandle, len, pos))

    If pos < len Then Exit Sub

    TimerStop()
    RaiseEvent EndOfStream(Me, New System.EventArgs)
  End Sub

  Private Sub TimerLevel_Tick _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) Handles _TimerLevel.Tick

    Dim retVal As Int32 = Bass.BASS_ChannelGetLevel(_StreamHandle)
    Dim leftLevel As Int16 _
    = CType(((Un4seen.Bass.Utils.HighWord(retVal) / 4) * 100) / 8192, Int16)

    Dim rightLevel As Int16 _
    = CType(((Un4seen.Bass.Utils.LowWord(retVal) / 4) * 100) / 8192, Int16)

    RaiseEvent LevelChanged(Me _
    , New LevelChangedEventArgs(leftLevel, rightLevel))
  End Sub
#End Region

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Play()

    Select Case _StreamHandle
    Case Is <> 0
      Bass.BASS_ChannelPlay(_StreamHandle, False)
      TimerStart()
      FadeIn()
    End Select
  End Sub

  Public Sub Pause()
    Select Case _StreamHandle
    Case Is <> 0
      TimerStop()
      FadeOut()
      Bass.BASS_ChannelPause(_StreamHandle)
    End Select
  End Sub

  Public Sub [Stop]()
    Select Case _StreamHandle
    Case Is <> 0
      TimerStop()
      Bass.BASS_ChannelStop(_StreamHandle)
    End Select
  End Sub

  Public Sub SetVolume(ByVal volume As System.Single)
    Select Case _StreamHandle
    Case Is <> 0
      Bass.BASS_ChannelSetAttribute(_StreamHandle _
      , Un4seen.Bass.BASSAttribute.BASS_ATTRIB_VOL, volume)
    End Select
  End Sub

  Public Function GetPosition() As Byte
    Return CType((Bass.BASS_ChannelGetPosition(_StreamHandle) * 100) _
    \ Bass.BASS_ChannelGetLength(_StreamHandle), Byte)
  End Function

  Public Sub SetPosition(ByVal percent As System.Byte)

    Select Case _StreamHandle
    Case Is <> 0
      Dim newPos As System.Double _
      = (Bass.BASS_ChannelBytes2Seconds(_StreamHandle _
      , Bass.BASS_ChannelGetLength(_StreamHandle)) * percent) / 100

      Bass.BASS_ChannelSetPosition _
      (_StreamHandle, newPos)
    End Select
  End Sub

  Public Function GetChannelInfo() As String
    Dim ci As New Un4seen.Bass.BASS_CHANNELINFO
    Bass.BASS_ChannelGetInfo(_StreamHandle, ci)
    Return ci.ToString()
  End Function


  Public Shared Function GetSoundDevices() As SoundDevice()
    Dim deviceIndex As Int32 = 1
    Dim info As New Un4seen.Bass.BASS_DEVICEINFO
    Dim list As New System.Collections.Generic.List(Of SoundDevice)

    While Bass.BASS_GetDeviceInfo(deviceIndex, info)
      list.Add(New SoundDevice(info, deviceIndex))
      deviceIndex += 1
    End While

    Return list.ToArray
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Player}
#End Region '{Klasse Player}

End Namespace