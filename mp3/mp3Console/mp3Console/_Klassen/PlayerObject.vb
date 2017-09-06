Option Infer On
Option Explicit On
Option Strict On

#Region " --------------->> Klasse BassPlayerObject "

Public Enum PlayerEffects
  ChorusSoundEffect = 0
  CompressorSoundEffect = 1
  DistortionSoundEffect = 2
  EchoSoundEffect = 3
  FlangerSoundEffect = 4
  GargleSoundEffect = 5
  I3DL2ReverbSoundEffect = 6
  ParamEqSoundEffect = 7
  WavesReverbSoundEffect = 8
End Enum


Public Class PlayerObject

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _SoundEngine As irrklang.ISoundEngine
  Private _CurrentSong As irrklang.ISound
  Private _IsPaused As Boolean = False
  Private _SelectedEffects As New List(Of PlayerEffects)

  Private _FileName As String = ""
  Private _PlayerIsInitialized As Boolean = False
  Private _ID3Tag As New HundredMilesSoftware.UltraID3Lib.UltraID3

  Public Event SongEnded(ByVal sender As Object, ByVal e As EventArgs)
  Public Event SongChanged(ByVal sender As Object, ByVal e As EventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property SelectectEffects As PlayerEffects()
  Get
    Return _SelectedEffects.ToArray
  End Get
  End Property

  Public ReadOnly Property AtEndOfSong As Boolean
  Get
    If _CurrentSong Is Nothing Then Return False
    Return _CurrentSong.Finished
  End Get
  End Property

  Public ReadOnly Property SoundDevices() _
  As Dictionary(Of String, SoundDevice)
  Get
    Dim list = New Dictionary(Of String, SoundDevice)

    Dim devices = New irrklang.ISoundDeviceList _
    (irrklang.SoundDeviceListType.PlaybackDevice)

    For i = 0 To devices.DeviceCount - 1
      Dim deviceId = devices.getDeviceID(i)
      list.Add(deviceId, New SoundDevice _
      (deviceId, devices.getDeviceDescription(i)))
    Next i

    Return list
  End Get
  End Property

  Public Property FileName() As String
  Get
    Return _FileName
  End Get
  Set(ByVal value As String)
    If _SoundEngine IsNot Nothing Then
      _SoundEngine.StopAllSounds()
      _FileName = ""
    End If

    Select Case My.Computer.FileSystem.FileExists(value) _
    AndAlso value.ToLower().EndsWith(".mp3")
    Case True
      _FileName = value
      _ID3Tag.Read(_FileName)
      RaiseEvent SongChanged(Me, New EventArgs)
    End Select
  End Set
  End Property

  Public ReadOnly Property ID3Tag() As HundredMilesSoftware.UltraID3Lib.UltraID3
  Get
    Return _ID3Tag
  End Get
  End Property

  Public ReadOnly Property PlayerIsInitialized() As Boolean
  Get
    Return _PlayerIsInitialized
  End Get
  End Property

  Public Property Volume() As Byte
  Get
    Return CType(_SoundEngine.SoundVolume * 100, Byte)
  End Get
  Set(ByVal value As Byte)
    If _SoundEngine Is Nothing Then Exit Property

    Select Case value
    Case 0 To 100
      _SoundEngine.SoundVolume = CType(value, Single) / 100
    End Select
  End Set
  End Property

  Public Property CurrentPositionUInt() As UInteger
  Get
    If _CurrentSong Is Nothing Then Return 0
    Return CUInt(_CurrentSong.PlayPosition \ 1000)
  End Get
  Set(ByVal value As UInt32)
    If _CurrentSong Is Nothing Then Exit Property
    _CurrentSong.PlayPosition = CUInt(value * 1000)
  End Set
  End Property

  Public Property CurrentPosition() As String
  Get
    Select Case _CurrentSong Is Nothing
    Case True
      Return "00:00:00"
    Case Else
      Dim total = _CurrentSong.PlayPosition \ 1000
      Dim hours = total \ 3600
      Dim minutes = (total \ 60) Mod 60
      Dim seconds = (total Mod 3600) Mod 60
      Return hours.ToString("00:") & minutes.ToString("00:") & seconds.ToString("00")
    End Select
  End Get
  Set(ByVal value As String)
    If _CurrentSong Is Nothing Then Exit Property

    _CurrentSong.PlayPosition = CUInt(StringToSeconds(value))
  End Set
  End Property

  Public Property CurrentPositionPercentDouble() As Double
  Get
    Select Case _CurrentSong Is Nothing
    Case True
      Return 0
    Case Else
      Try
        Return (_CurrentSong.PlayPosition * 100) / _CurrentSong.PlayLength
      Catch ex As Exception 'Division durch Null
        Return 0
      End Try
    End Select
  End Get
  Set(ByVal value As Double)
    If _CurrentSong Is Nothing Then Exit Property

    Dim total As Double = _CurrentSong.PlayLength
    Dim pos = value * total / 100
    Select Case pos
    Case Is < 0
      Me.CurrentPosition = "00:00:00"
    Case Is > total
      Me.CurrentPosition = Me.TotalTime
    Case Else
      Me.CurrentPosition = SecondsToString(pos)
    End Select
  End Set
  End Property

  Public Property CurrentPositionPercent() As Int32
  Get
    Select Case _CurrentSong Is Nothing
    Case True
      Return 0
    Case Else
      Try
        Return CType((_CurrentSong.PlayPosition * 100) _
        / _CurrentSong.PlayLength, Int32)
      Catch ex As Exception 'Division durch Null
        Return 0
      End Try
    End Select
  End Get
  Set(ByVal value As Int32)
    If _CurrentSong Is Nothing Then Exit Property

    Dim total = _CurrentSong.PlayLength
    Dim pos = value * total \ 100
    Select Case pos
    Case Is < 0
      Me.CurrentPosition = "00:00:00"
    Case Is > total
      Me.CurrentPosition = Me.TotalTime
    Case Else
      Me.CurrentPosition = SecondsToString(pos)
    End Select
  End Set
  End Property

  Public ReadOnly Property TotalTime() As String
  Get
    If _CurrentSong Is Nothing Then Return "00:00:00"
    Return SecondsToString(_CurrentSong.PlayLength)
  End Get
  End Property

  Public ReadOnly Property ElapsedTime() As String
  Get
    Return Me.CurrentPosition
  End Get
  End Property

  Public ReadOnly Property RemainTime() As String
  Get
    If _CurrentSong Is Nothing Then Return "00:00:00"
    With _CurrentSong
      Return (((.PlayLength - .PlayPosition) \ 1000) \ 60).ToString("00") _
      & ":" & (((.PlayLength - .PlayPosition) \ 1000) Mod 60).ToString("00")
    End With
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
'{Ereignismethoden der Klasse}
#End Region

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub Free()
    If _SoundEngine Is Nothing Then Exit Sub
    _SoundEngine.StopAllSounds()
    _FileName = ""
  End Sub

  Private Sub EnableEffect(ByVal effect As PlayerEffects)
    If _CurrentSong Is Nothing Then Exit Sub
    _CurrentSong.SoundEffectControl.GetType.InvokeMember _
    ("Enable" & effect.ToString, Reflection.BindingFlags.InvokeMethod _
    , Nothing, _CurrentSong.SoundEffectControl, Nothing)
  End Sub

  Private Sub DisableEffect(ByVal effect As PlayerEffects)
    If _CurrentSong Is Nothing Then Exit Sub
    _CurrentSong.SoundEffectControl.GetType.InvokeMember _
    ("Disable" & effect.ToString, Reflection.BindingFlags.InvokeMethod _
    , Nothing, _CurrentSong.SoundEffectControl, Nothing)
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub AddEffect(ByVal effect As PlayerEffects)
    If _SelectedEffects.Contains(effect) Then Exit Sub
    _SelectedEffects.Add(effect)

    EnableEffect(effect)
  End Sub

  Public Sub RemoveEffect(ByVal effect As PlayerEffects)
    _SelectedEffects.Remove(effect)
    DisableEffect(effect)
  End Sub

  Public Shared Function StringToSeconds(ByVal value As String) As Double
    Dim seconds As Double = 0
    Dim f() As String = value.Split(":"c)
    seconds += CType(f(0), Int32) * 3600
    seconds += CType(f(1), Int32) * 60
    seconds += CType(f(2), Int32)
    Return seconds
  End Function

  Public Shared Function SecondsToString(ByVal value As Double) As String
    Dim s As String = ""
    s &= (CType(value, Int32) \ 3600).ToString("00") & ":"
    Dim rest As Double = value Mod 3600
    s &= (CType(rest, Int32) \ 60).ToString("00") & ":"
    rest = rest Mod 60
    s &= rest.ToString("00")
    Return s
  End Function

  Public Function InitializePlayer() As Boolean
    Try
      Free()
      _SoundEngine = New irrklang.ISoundEngine _
      (irrklang.SoundOutputDriver.AutoDetect _
      , irrklang.SoundEngineOptionFlag.DefaultOptions)
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  Public Function InitializePlayer _
  (ByVal soundDevice As SoundDevice) As Boolean

    Try
      Free()
      If soundDevice Is Nothing Then
        _SoundEngine = New irrklang.ISoundEngine _
        (irrklang.SoundOutputDriver.AutoDetect _
        , irrklang.SoundEngineOptionFlag.DefaultOptions)
      Else
        _SoundEngine = New irrklang.ISoundEngine _
        (irrklang.SoundOutputDriver.AutoDetect _
        , irrklang.SoundEngineOptionFlag.DefaultOptions _
        , soundDevice.DeviceID)
      End If
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  Public Sub Play()
    If _IsPaused Then
      _SoundEngine.SetAllSoundsPaused(False)
      _IsPaused = False
    Else
      If _SoundEngine Is Nothing Then Exit Sub
      _CurrentSong = _SoundEngine.Play2D _
      (_FileName, False, False _
      , irrklang.StreamMode.Streaming, True)

      For Each effect In _SelectedEffects
        EnableEffect(effect)
      Next effect
    End If
  End Sub

  Public Sub [Stop]()
    If _CurrentSong Is Nothing Then Exit Sub
    _SoundEngine.StopAllSounds()
  End Sub

  Public Sub Pause()
    If _SoundEngine Is Nothing Then Exit Sub
    _IsPaused = True
    _SoundEngine.SetAllSoundsPaused(True)
  End Sub

  Public Sub RePositionStart()
    If _CurrentSong Is Nothing Then Exit Sub
    _SoundEngine.SetAllSoundsPaused(True)
  End Sub

  Public Sub RePositionEnd()
    If _CurrentSong Is Nothing Then Exit Sub
    _SoundEngine.SetAllSoundsPaused(False)
  End Sub

  Public Sub SeekNext(ByVal seconds As Int32)
    If _CurrentSong Is Nothing Then Exit Sub

    Dim pos = StringToSeconds(Me.CurrentPosition)
    Dim total = StringToSeconds(Me.TotalTime)

    Select Case pos + seconds
    Case Is <= total
      pos += seconds
      Me.CurrentPosition = SecondsToString(pos)
    Case Else
      Me.CurrentPosition = Me.TotalTime
    End Select
  End Sub

  Public Sub SeekPrevious(ByVal seconds As Int32)
    If _CurrentSong Is Nothing Then Exit Sub

    Dim pos = StringToSeconds(Me.CurrentPosition)

    Select Case pos - seconds
    Case Is < 0
      Me.CurrentPosition = SecondsToString(0)
    Case Else
      pos -= seconds
      Me.CurrentPosition = SecondsToString(pos)
    End Select
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
#End Region '{Klasse BassPlayerObject}