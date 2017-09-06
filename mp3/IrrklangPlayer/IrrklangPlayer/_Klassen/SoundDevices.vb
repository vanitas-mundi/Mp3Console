Option Explicit On
Option Infer On
Option Strict On

Imports System.Reflection
Imports irrklang
Imports HundredMilesSoftware.UltraID3Lib

Public Class SoundDevices

	Public Shared ReadOnly Property Items() _
	As Dictionary(Of String, SoundDevice)
		Get
			Dim list = New Dictionary(Of String, SoundDevice)

			Dim devices = New ISoundDeviceList _
			(SoundDeviceListType.PlaybackDevice)

			For i = 0 To devices.DeviceCount - 1
				Dim deviceId = devices.getDeviceID(i)
				list.Add(deviceId, New SoundDevice _
				(deviceId, devices.getDeviceDescription(i)))
			Next i

			Return list
		End Get
	End Property
End Class
