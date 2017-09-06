Option Infer On
Option Explicit On
Option Strict On

Imports System.Reflection
Imports irrklang
Imports HundredMilesSoftware.UltraID3Lib

	Public Class PlayerObject

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
	Private _soundEngine As irrklang.ISoundEngine
	Private _currentSong As irrklang.ISound
	Private _isPaused As Boolean = False
	Private _selectedEffects As New List(Of PlayerEffects)

	Private _fileName As String = ""
	Private _playerIsInitialized As Boolean = False
	Private _id3Tag As New HundredMilesSoftware.UltraID3Lib.UltraID3

	Public Event songEnded(ByVal sender As Object, ByVal e As EventArgs)
	Public Event songChanged(ByVal sender As Object, ByVal e As EventArgs)
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
	Protected Overrides Sub Finalize()
		MyBase.Finalize()
	End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	Public ReadOnly Property SelectectEffects As PlayerEffects()
		Get
			Return _selectedEffects.ToArray
		End Get
	End Property

	Public ReadOnly Property AtEndOfSong As Boolean
		Get
			If _currentSong Is Nothing Then Return False
			Return _currentSong.Finished
		End Get
	End Property

	Public ReadOnly Property SoundDevices() _
	As Dictionary(Of String, SoundDevice)
		Get
			Return SSP.IrrklangPlayer.SoundDevices.Items
		End Get
	End Property

	Public Property FileName() As String
		Get
			Return _fileName
		End Get
		Set(ByVal value As String)
			If _soundEngine IsNot Nothing Then
				_soundEngine.StopAllSounds()
				_fileName = ""
			End If

			With My.Computer.FileSystem
				Select Case .FileExists(value) _
				AndAlso value.ToLower().EndsWith(".mp3")
					Case True
						_fileName = value
						_id3Tag.Read(_fileName)
						RaiseEvent songChanged(Me, New EventArgs)
				End Select
			End With
		End Set
	End Property

	Public ReadOnly Property ID3Tag() As UltraID3
		Get
			Return _id3Tag
		End Get
	End Property

	Public ReadOnly Property PlayerIsInitialized() As Boolean
		Get
			Return _playerIsInitialized
		End Get
	End Property

	Public Property Volume() As Byte
		Get
			Return CType(_soundEngine.SoundVolume * 100, Byte)
		End Get
		Set(ByVal value As Byte)
			If _soundEngine Is Nothing Then Exit Property

			Select Case value
			Case 0 To 100
				_soundEngine.SoundVolume = CType(value, Single) / 100
			End Select
		End Set
	End Property

	Public Property CurrentPositionUInt() As UInteger
		Get
			If _currentSong Is Nothing Then Return 0
			Return CUInt(_currentSong.PlayPosition \ 1000)
		End Get
		Set(ByVal value As UInt32)
			If _currentSong Is Nothing Then Exit Property
			_currentSong.PlayPosition = CUInt(value * 1000)
		End Set
	End Property

	Public Property CurrentPosition() As String
		Get
			Select Case _currentSong Is Nothing
				Case True
					Return "00:00:00"
				Case Else
					Dim total = _currentSong.PlayPosition \ 1000
					Dim hours = total \ 3600
					Dim minutes = (total \ 60) Mod 60
					Dim seconds = (total Mod 3600) Mod 60
					Return hours.ToString("00:") & minutes.ToString("00:") & seconds.ToString("00")
			End Select
		End Get
		Set(ByVal value As String)
			If _currentSong Is Nothing Then Exit Property

			_currentSong.PlayPosition = CUInt(StringToSeconds(value))
		End Set
	End Property

	Public Property CurrentPositionPercentDouble() As Double
		Get
			Select Case _currentSong Is Nothing
				Case True
					Return 0
				Case Else
					Try
						Return (_currentSong.PlayPosition * 100) / _currentSong.PlayLength
					Catch ex As Exception	'Division durch Null
						Return 0
					End Try
			End Select
		End Get
		Set(ByVal value As Double)
			If _currentSong Is Nothing Then Exit Property

			Dim total As Double = _currentSong.PlayLength
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
			Select Case _currentSong Is Nothing
				Case True
					Return 0
				Case Else
					Try
						Return CType((_currentSong.PlayPosition * 100) _
						/ _currentSong.PlayLength, Int32)
					Catch ex As Exception	'Division durch Null
						Return 0
					End Try
			End Select
		End Get
		Set(ByVal value As Int32)
			If _currentSong Is Nothing Then Exit Property

			Dim total = _currentSong.PlayLength
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
			If _currentSong Is Nothing Then Return "00:00:00"
			Return SecondsToString(_currentSong.PlayLength)
		End Get
	End Property

	Public ReadOnly Property ElapsedTime() As String
		Get
			Return Me.CurrentPosition
		End Get
	End Property

	Public ReadOnly Property RemainTime() As String
		Get
			If _currentSong Is Nothing Then Return "00:00:00"
			With _currentSong
				Return (((.PlayLength - .PlayPosition) \ 1000) \ 60).ToString("00") _
				& ":" & (((.PlayLength - .PlayPosition) \ 1000) Mod 60).ToString("00")
			End With
		End Get
	End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
#End Region

#Region " --------------->> Private Methoden der Klasse "
	Private Sub Free()
		If _soundEngine Is Nothing Then Exit Sub
		_soundEngine.StopAllSounds()
		_fileName = ""
	End Sub

	Private Sub EnableEffect _
	(ByVal effect As PlayerEffects)

		If _currentSong Is Nothing Then Exit Sub

		_currentSong.SoundEffectControl.GetType.InvokeMember _
		("Enable" & effect.ToString, BindingFlags.InvokeMethod _
		, Nothing, _currentSong.SoundEffectControl, Nothing)
	End Sub

	Private Sub DisableEffect _
	(ByVal effect As PlayerEffects)

		If _currentSong Is Nothing Then Exit Sub

		_currentSong.SoundEffectControl.GetType.InvokeMember _
		("Disable" & effect.ToString, BindingFlags.InvokeMethod _
		, Nothing, _currentSong.SoundEffectControl, Nothing)
	End Sub
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	Public Sub AddEffect(ByVal effect As PlayerEffects)

		If _selectedEffects.Contains(effect) Then Exit Sub

		_selectedEffects.Add(effect)
		EnableEffect(effect)
	End Sub

	Public Sub RemoveEffect(ByVal effect As PlayerEffects)

		_selectedEffects.Remove(effect)
		DisableEffect(effect)
	End Sub

	Public Shared Function StringToSeconds _
	(ByVal value As String) As Double

		Dim seconds As Double = 0
		Dim f() As String = value.Split(":"c)
		seconds += CType(f(0), Int32) * 3600
		seconds += CType(f(1), Int32) * 60
		seconds += CType(f(2), Int32)
		Return seconds
	End Function

	Public Shared Function SecondsToString _
	(ByVal value As Double) As String

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
			_soundEngine = New irrklang.ISoundEngine _
			(SoundOutputDriver.AutoDetect _
			, SoundEngineOptionFlag.DefaultOptions)
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
				_soundEngine = New ISoundEngine _
				(SoundOutputDriver.AutoDetect _
				, SoundEngineOptionFlag.DefaultOptions)
			Else
				_soundEngine = New irrklang.ISoundEngine _
				(SoundOutputDriver.AutoDetect _
				, SoundEngineOptionFlag.DefaultOptions _
				, soundDevice.DeviceID)
			End If
			Return True
		Catch ex As Exception
			Return False
		End Try
	End Function

	Public Sub Play()

		If _isPaused Then
			_soundEngine.SetAllSoundsPaused(False)
			_isPaused = False
		Else
			If _soundEngine Is Nothing Then Exit Sub

			_currentSong = _soundEngine.Play2D _
			(_fileName, False, False _
			, irrklang.StreamMode.Streaming, True)

			For Each effect In _selectedEffects
				EnableEffect(effect)
			Next effect
		End If
	End Sub

	Public Sub [Stop]()

		If _currentSong Is Nothing Then Exit Sub
		_soundEngine.StopAllSounds()
	End Sub

	Public Sub Pause()

		If _soundEngine Is Nothing Then Exit Sub
		_isPaused = True
		_soundEngine.SetAllSoundsPaused(True)
	End Sub

	Public Sub RePositionStart()

		If _currentSong Is Nothing Then Exit Sub
		_soundEngine.SetAllSoundsPaused(True)
	End Sub

	Public Sub RePositionEnd()

		If _currentSong Is Nothing Then Exit Sub
		_soundEngine.SetAllSoundsPaused(False)
	End Sub

	Public Sub SeekNext(ByVal seconds As Int32)

		If _currentSong Is Nothing Then Exit Sub

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

		If _currentSong Is Nothing Then Exit Sub

		Dim pos = StringToSeconds(Me.CurrentPosition)

		Select Case pos - seconds
		Case Is < 0
			Me.CurrentPosition = SecondsToString(0)
		Case Else
			pos -= seconds
			Me.CurrentPosition = SecondsToString(pos)
		End Select
	End Sub
#End Region	'Öffentliche Methoden der Klasse}

	End Class
