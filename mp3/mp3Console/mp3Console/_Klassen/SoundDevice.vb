Option Explicit On
Option Strict On
Option Infer On

Public Class SoundDevice
#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _DeviceID As String
  Private _Description As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
  End Sub

  Public Sub New(ByVal deviceID As String, ByVal description As String)
    _DeviceID = deviceID
    _Description = description
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property DeviceID As String
  Get
    Return _DeviceID
  End Get
  Set(ByVal value As String)
    _DeviceID = value
  End Set
  End Property

  Public Property Description As String
  Get
    Return _Description
  End Get
  Set(ByVal value As String)
    _Description = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Overrides Function ToString() As String
    Return Me.Description
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class


