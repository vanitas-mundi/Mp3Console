'Option Explicit On 
'Option Strict On
'Option Infer On

'Imports HundredMilesSoftware.UltraID3Lib

'Namespace Data

'	Public Class Title

'		Inherits Object
'		Implements IPlayListMember
'		Implements IComparable(Of Title)

'#Region " --------------->> Enumerationen der Klasse "
'#End Region	'{Enumerationen der Klasse}

'#Region " --------------->> Eigenschaften der Klasse "
'		Private _titleId As Int64
'		Private _fileName As String
'		Private _id3 As UltraID3
'		Private _title As String
'		Private _track As String
'#End Region	'{Eigenschaften der Klasse}

'#Region " --------------->> Konstruktor und Destruktor der Klasse "
'#End Region	'{Konstruktor und Destruktor der Klasse}

'#Region " --------------->> Zugriffsmethoden der Klasse "
'		'Public Property TitleId As Int64
'		'Get
'		'	Return _titleId
'		'End Get
'		'Set(value As Int64)
'		'	_titleId = value
'		'End Set
'		'End Property

'		Public Property FileName() As String _
'		Implements IPlayListMember.FileName
'		Get
'			Return _fileName
'		End Get
'		Set(value As String)
'			_fileName = value
'		End Set
'		End Property

'		Public Property Title() As String
'		Get
'			Return _title
'		End Get
'		Set(value As String)
'			_title = value
'		End Set
'		End Property

'		Public Property Track() As String
'		Get
'			Try
'				Return CType(_track, Int32).ToString("00")
'			Catch ex As Exception
'				Return ""
'			End Try
'		End Get
'		Set(value As String)
'			_track = value
'		End Set
'		End Property

'		Public ReadOnly Property Id3() As UltraID3
'		Get
'			Try
'				Return If(My.Computer.FileSystem.FileExists(_fileName), GetId3(_fileName), Nothing)
'			Catch ex As Exception
'				Return Nothing
'			End Try
'		End Get
'		End Property

'		Public ReadOnly Property PlayListMember() As PlayListMemberTypes _
'		Implements IPlayListMember.PlayListMember
'		Get
'			Return PlayListMemberTypes.Title
'		End Get
'		End Property
'#End Region	'{Zugriffsmethoden der Klasse}

'#Region " --------------->> Private Methoden der Klasse "
'	Private Function GetId3(ByVal fileName As String) As UltraID3
'		If _id3 Is Nothing Then
'			_id3 = New UltraID3
'			_id3.Read(fileName)
'		End If
'		Return _id3
'	End Function
'#End Region	'{Private Methoden der Klasse}

'#Region " --------------->> Öffentliche Methoden der Klasse "
'		Public Sub Initialize(ByVal id3 As UltraID3)
'			_id3 = id3
'			Me.Title = id3.Title
'			Me.FileName = id3.FileName
'			Me.Track = id3.TrackNum.ToString
'		End Sub

'		Public Sub Initialize(ByVal fileName As String)
'			Initialize(GetId3(fileName))
'		End Sub

'		Public Overrides Function ToString() As String _
'		Implements IPlayListMember.ToString
'			Select Case Me.Track.Trim.Length
'				Case 0
'					Return Me.Title
'				Case Else
'					Return Me.Track.Trim & " " & Me.Title
'			End Select
'		End Function

'		Public Function CompareTo(ByVal other As Title) As Int32 _
'		Implements System.IComparable(Of Title).CompareTo

'			Return Me.ToString.CompareTo(other.ToString)
'		End Function
'#End Region	'Öffentliche Methoden der Klasse}

'	End Class

'End Namespace
