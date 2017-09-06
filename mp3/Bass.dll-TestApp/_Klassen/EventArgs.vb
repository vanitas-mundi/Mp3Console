Option Explicit On
Option Strict On
Option Infer On

Imports Un4seen.Bass
Imports BassTags = Un4seen.Bass.AddOn.Tags.BassTags

Namespace Media

Public Class PositionChangedEventArgs
  Inherits EventArgs

  Private _CurrentTime As String
  Private _TotalTime As String
  Private _RemainTime As String
  Private _CurrentSeconds As System.Double
  Private _TotalSeconds As System.Double
  Private _RemainSeconds As System.Double
  Private _Percent As System.Double


  Public Sub New(ByVal streamHandle As Int32 _
  , ByVal len As System.Double _
  , ByVal pos As System.Double)

    _TotalSeconds = Bass.BASS_ChannelBytes2Seconds(streamHandle, CType(len, Int64))
    _CurrentSeconds = Bass.BASS_ChannelBytes2Seconds(streamHandle, CType(pos, Int64))
    _RemainSeconds = _TotalSeconds - _CurrentSeconds

    _TotalTime = Un4seen.Bass.Utils.FixTimespan(len, "HHMMSS")
    _CurrentTime = Un4seen.Bass.Utils.FixTimespan(pos, "HHMMSS")
    _RemainTime = Un4seen.Bass.Utils.FixTimespan(len - pos, "HHMMSS")
    _Percent = (pos * 100) / len
  End Sub

  Public ReadOnly Property TotalTime() As System.String
  Get
    Return _TotalTime
  End Get
  End Property

  Public ReadOnly Property CurrentTime() As System.String
  Get
    Return _CurrentTime
  End Get
  End Property

  Public ReadOnly Property RemainTime() As String
  Get
    Return _RemainTime
  End Get
  End Property

  Public ReadOnly Property CurrentSeconds() As System.Double
  Get
    Return _CurrentSeconds
  End Get
  End Property

  Public ReadOnly Property TotalSeconds() As System.Double
  Get
    Return _TotalSeconds
  End Get
  End Property

  Public ReadOnly Property RemainSeconds() As System.Double
  Get
    Return _RemainSeconds
  End Get
  End Property

  Public ReadOnly Property Percent() As System.Double
  Get
    Return _Percent
  End Get
  End Property

End Class

Public Class LevelChangedEventArgs
  Inherits EventArgs

  Private _LeftLevel As Int16
  Private _RightLevel As Int16

  Public Sub New(ByVal leftLevel As Int16, ByVal rightLevel As Int16)
    _LeftLevel = leftLevel
    _RightLevel = rightLevel
  End Sub

  Public ReadOnly Property LeftLevel() As Int16
  Get
    Return _LeftLevel
  End Get
  End Property

  Public ReadOnly Property RightLevel() As Int16
  Get
    Return _RightLevel
  End Get
  End Property
End Class

End Namespace