Option Explicit On
Option Infer On
Option Strict On

<Serializable()>
Public Class EasyLabelInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
	Private _title As String
	Private _content As String
	Private _copies As Int32
	Private _size As Size
	Private _location As Point
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
	Public Sub New _
	(ByVal title As String _
	, ByVal content As String _
	, ByVal copies As Int32 _
	, ByVal size As Size _
	, ByVal location As Point)

		_title = title
		_content = content
		_copies = copies
		_size = size
		_location = location
	End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	Public ReadOnly Property Title As String
	Get
		Return _title
	End Get
	End Property

	Public ReadOnly Property Content As String
	Get
		Return _content
	End Get
	End Property

	Public ReadOnly Property Copies As Int32
	Get
		Return _copies
	End Get
	End Property

	Public ReadOnly Property Size As Size
	Get
		Return _size
	End Get
	End Property

	Public ReadOnly Property location As Point
	Get
		Return _location
	End Get
	End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region	'{Öffentliche Methoden der Klasse}

End Class
