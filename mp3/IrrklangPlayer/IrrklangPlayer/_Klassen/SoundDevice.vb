Option Explicit On
Option Strict On
Option Infer On

	Public Class SoundDevice

#Region " --------------->> Eigenschaften der Klasse "
		Private _deviceID As String
		Private _description As String
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
		End Sub

		Public Sub New _
		(ByVal deviceID As String _
		, ByVal description As String)

			Initialize(deviceID, description)
		End Sub

		Public Sub Initialize _
		(ByVal deviceID As String _
		, ByVal description As String)

			_deviceID = deviceID
			_description = description
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property DeviceID As String
			Get
				Return _deviceID
			End Get
			Set(ByVal value As String)
				_deviceID = value
			End Set
		End Property

		Public Property Description As String
			Get
				Return _description
			End Get
			Set(ByVal value As String)
				_description = value
			End Set
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return Me.Description
		End Function
#End Region	'Öffentliche Methoden der Klasse}

	End Class


