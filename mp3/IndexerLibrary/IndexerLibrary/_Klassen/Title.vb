Option Explicit On 
Option Strict On
Option Infer On

Imports HundredMilesSoftware.UltraID3Lib

	Public Class Title

		Inherits Object
		Implements IPlayListMember
		Implements IComparable(Of Title)

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
	Private _fileName As String
	Private _id3 As UltraID3
	Private _Title As String
	Private _Track As String
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
	Public Sub New _
	(ByVal title As String _
	, ByVal track As String _
	, ByVal fileName As String)

		Initialize(title, track, fileName, Nothing)
	End Sub

	Public Sub New(ByVal id3 As UltraID3)

		Initialize(id3.Title, id3.TrackNum.ToString, id3.FileName, id3)
	End Sub

	Public Sub New(ByVal fileName As String)
		Dim id3 = New UltraID3
		id3.Read(fileName)
		Initialize(id3.Title, id3.TrackNum.ToString, fileName, id3)
	End Sub

	Private Sub Initialize _
	(ByVal title As String _
	, ByVal track As String _
	, ByVal fileName As String _
	, ByVal id3 As UltraID3)

		_fileName = fileName
		_Title = title
		_Track = track
		_id3 = id3
	End Sub

	Protected Overrides Sub Finalize()
		MyBase.Finalize()
	End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	Public ReadOnly Property FileName() As String _
	Implements IPlayListMember.FileName
	Get
		Return _fileName
	End Get
	End Property

	Public ReadOnly Property Id3() As UltraID3
	Get
		Try
			If Not My.Computer.FileSystem.FileExists(_fileName) Then
				Return Nothing
			End If

			If _id3 Is Nothing Then
				_id3 = New UltraID3
				_id3.Read(_fileName)
			End If
			Return _id3
		Catch ex As Exception
			Return Nothing
		End Try
	End Get
	End Property

	Public ReadOnly Property Title() As String
	Get
		Return _Title
	End Get
	End Property

	Public ReadOnly Property Track() As String
	Get
		Try
			Return CType(_Track, Int32).ToString("00")
		Catch ex As Exception
			Return ""
		End Try
	End Get
	End Property

	Public ReadOnly Property PlayListMember() As PlayListMemberTypes _
	Implements IPlayListMember.PlayListMember
	Get
		Return PlayListMemberTypes.Title
	End Get
	End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	Public Overrides Function ToString() As String _
	Implements IPlayListMember.ToString
		Select Case Me.Track.Trim.Length
			Case 0
				Return Me.Title
			Case Else
				Return Me.Track.Trim & " " & Me.Title
		End Select
	End Function

	Public Function CompareTo(ByVal other As Title) _
	As Integer Implements System.IComparable(Of Title).CompareTo
		Return Me.ToString.CompareTo(other.ToString)
	End Function
#End Region	'Öffentliche Methoden der Klasse}

	End Class
