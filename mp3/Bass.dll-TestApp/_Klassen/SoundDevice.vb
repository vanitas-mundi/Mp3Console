Option Explicit On 
Option Strict On
Option Infer On

Imports Un4seen.Bass
Imports BassTags = Un4seen.Bass.AddOn.Tags.BassTags

Namespace Media

#Region " --------------->> Klasse SoundDevice "

Public Class SoundDevice

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Info As Un4seen.Bass.BASS_DEVICEINFO
  Private _DeviceIndex As Int32 = -1
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}

  Public Sub New _
  (ByVal info As Un4seen.Bass.BASS_DEVICEINFO _
  , ByVal deviceIndex As Int32)

    _Info = info
    _DeviceIndex = deviceIndex
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property Info() As Un4seen.Bass.BASS_DEVICEINFO
  Get
    Return _Info
  End Get
  End Property

  Public ReadOnly Property DeviceIndex() As Int32
  Get
    Return _DeviceIndex
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Overloads Overrides Function ToString() As String
    Return Me.Info.name
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

#End Region '{Klasse SoundDevice}

End Namespace