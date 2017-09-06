Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.IO.Compression
#End Region

Public Class Serializer

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	Public Shared Sub Serialize(Of T) _
	(ByVal compression As Boolean _
	, ByVal path As String _
	, ByVal instance As T)

		Try
			Dim fs As Stream = New FileStream(path, FileMode.OpenOrCreate)
			Dim bf As New BinaryFormatter

			If compression Then
				fs = New GZipStream(fs, CompressionMode.Compress)
			End If

			bf.Serialize(fs, instance)
			fs.Close()
		Catch ex As Exception
			MessageBox.Show(ex.Message, Application.ProductName _
			, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Public Shared Sub Serialize(Of T) _
	(ByVal path As String _
	, ByVal instance As T)

		Serialize(False, path, instance)
	End Sub

	Public Shared Function DeSerialize(Of T) _
	(ByVal compression As Boolean _
	, ByVal path As String _
	, ByVal defaultInstance As T) As T

		Try
			If Not File.Exists(path) Then
				Return defaultInstance
			End If

			Dim fs As Stream = New FileStream(path, FileMode.OpenOrCreate)
			Dim bf As New BinaryFormatter

			If compression Then
				fs = New GZipStream(fs, CompressionMode.Decompress)
			End If

			DeSerialize = CType(bf.Deserialize(fs), T)
			fs.Close()
		Catch ex As Exception
			MessageBox.Show(ex.Message, Application.ProductName, _
			MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Function

	Public Shared Function DeSerialize(Of T) _
	(ByVal path As String _
	, ByVal defaultInstance As T) As T

		Return DeSerialize(Of T)(False, path, defaultInstance)
	End Function

	Public Shared Function DeSerialize(Of T As New) _
	(ByVal path As String) As T

		Return DeSerialize(Of T)(path, New T)
	End Function

	Public Shared Function DeSerialize(Of T As New) _
	(ByVal compression As Boolean _
	, ByVal path As String) As T

		Return DeSerialize(Of T)(compression, path, New T)
	End Function
#End Region	'{Öffentliche Methoden der Klasse}

End Class