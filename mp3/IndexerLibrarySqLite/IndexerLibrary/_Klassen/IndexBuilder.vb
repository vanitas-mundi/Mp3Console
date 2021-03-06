﻿Option Explicit On
Option Strict On
Option Infer On

Imports SSP.IndexerLibrary.IndexDataSet
Imports HundredMilesSoftware.UltraID3Lib

	Public Class IndexBuilder

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
	Private _indexData As New IndexDataSet
	Private _indexName As String
	Private _indexFileName As String

	Private Event FolderFounded _
	(ByVal sender As Object, ByVal e As FolderFoundedEventArgs)
	Public Event IndexChanged _
	(ByVal sender As Object, ByVal e As IndexChangedEventArgs)
	Public Event FileAddedToIndex _
	(ByVal sender As Object, ByVal e As FileAddedToIndexEventArgs)
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
	Public Sub New _
	(ByVal indexName As String _
	, ByVal indexPath As String)

		AddHandler Me.FolderFounded, AddressOf OnFolderFounded

		_indexName = indexName
		_indexFileName = My.Computer.FileSystem.CombinePath _
		(indexPath, _indexName)

		Dim path = My.Computer.FileSystem.GetParentPath(_indexFileName)

		If Not My.Computer.FileSystem.DirectoryExists(path) Then
			My.Computer.FileSystem.CreateDirectory(path)
		End If

		_indexData.DataSetName = _indexName

		Me.LoadIndex()
	End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	Public ReadOnly Property IndexData() As IndexDataSet
	Get
		Return _indexData
	End Get
	End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Ereignismethoden der Klasse "
	Private Sub OnFolderFounded _
	(ByVal sender As Object, ByVal e As FolderFoundedEventArgs)

		Dim lastWriteTime = My.Computer.FileSystem.GetDirectoryInfo(e.Folder).LastWriteTime
		Dim row = _indexData.folders.Rows.Find(e.Folder)

		Select Case row Is Nothing
			Case True
				AddFolderToIndex(e.Folder, lastWriteTime, e.RootFolder)
			Case Else
				Dim indexLastWriteTime = DateTime.Parse _
				(row.Item("last_write_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")

				Dim fileLastWriteTime = DateTime.Parse _
				(lastWriteTime.ToString).ToString("yyyy-MM-dd HH:mm:ss")

				If indexLastWriteTime < fileLastWriteTime Then
					row.Item("last_write_time") = lastWriteTime
					AddFilesToIndex(e.Folder)
				End If
		End Select
	End Sub
#End Region	'{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
	Private Function GetExecuteUpdateResults _
	(ByVal rows As IEnumerable(Of IndexDataSet.filesRow)) As Int32

		If rows.Count > 0 Then SaveIndex()
		Return rows.Count
	End Function

	Private Sub GetFolders(ByVal path As String, ByVal rootFolder As Boolean)

		RaiseEvent FolderFounded(Me, New FolderFoundedEventArgs(path, rootFolder))
		My.Computer.FileSystem.GetDirectories(path).ToList.ForEach(Sub(s) GetFolders(s, False))
	End Sub

	Private Sub LoadIndex()

		If My.Computer.FileSystem.FileExists(_indexFileName & ".xml") Then
			_indexData = New SSP.IndexerLibrary.IndexDataSet
			_indexData.ReadXmlSchema(_indexFileName & ".xsd")
			_indexData.ReadXml(_indexFileName & ".xml")
		End If

		'Remove()
		For i = _indexData.folders.Rows.Count - 1 To 0 Step -1
			Dim rowParent = _indexData.folders.Rows.Item(i)

			If My.Computer.FileSystem.DirectoryExists _
			(rowParent.Item("path").ToString) Then
				Continue For
			End If

			For Each dr As DataRow In rowParent.GetChildRows("path")
				_indexData.files.Rows.Remove(dr)
			Next dr

			_indexData.folders.Rows.Remove(rowParent)
		Next i
	End Sub

	Private Sub AddFolderToIndex _
	(ByVal path As String _
	, ByVal lastWriteTime As DateTime _
	, ByVal rootFolder As Boolean)

		Dim dr = _indexData.folders.NewRow
		dr.Item("path") = path
		dr.Item("root_folder") = rootFolder
		dr.Item("last_write_time") = lastWriteTime
		_indexData.folders.Rows.Add(dr)
		AddFilesToIndex(path)
	End Sub

	Private Sub AddFilesToIndex(ByVal path As String)

		RemoveFilesFromIndex(path, False)
		With My.Computer.FileSystem
			.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly _
			, New String() {"*.mp3"}).ToList.ForEach _
			(Sub(s) AddFileToIndex(s))
		End With
	End Sub

	Private Sub AddFileToIndex(ByVal fileName As String)
		'Dim id3 = New UltraID3
		'id3.Read(fileName)

		'Dim dr = _indexData.files.NewRow
		'dr.Item("path") = My.Computer.FileSystem.GetParentPath(fileName)
		'dr.Item("name") = My.Computer.FileSystem.GetName(fileName)
		'dr.Item("artist") = id3.Artist.ToString
		'dr.Item("album") = id3.Album.ToString
		'dr.Item("title") = id3.Title.ToString
		'dr.Item("track") = id3.TrackNum.ToString
		'dr.Item("year") = id3.Year.ToString
		'dr.Item("comment") = id3.Comments.ToString
		'dr.Item("genre") = id3.Genre.ToString
		'dr.Item("size") = id3.Size.ToString
		'dr.Item("duration") = id3.Duration.ToString.Substring(0, 8)
		'dr.Item("bitrate") = id3.FirstMPEGFrameInfo.Bitrate.ToString

		'_indexData.files.Rows.Add(dr)
		'RaiseEvent IndexChanged _
		'(Me, New IndexChangedEventArgs(id3, IndexChangedActions.Added))

		'RaiseEvent FileAddedToIndex(Me, New FileAddedToIndexEventArgs(fileName))
	End Sub


	Public Sub RemoveRootFolder(ByVal path As String)

		_indexData.folders.Where _
		(Function(item) item.path.ToLower.StartsWith(path.ToLower)).ToList.ForEach _
		(Sub(f) RemoveFilesFromIndex(f.path, True))
		Me.SaveIndex()
	End Sub

	Private Sub RemoveFilesFromIndex _
	(ByVal path As String, ByVal removeFolder As Boolean)

		Dim rowParent = _indexData.folders.Rows.Find(path)
		rowParent.GetChildRows("path").ToList.ForEach(Sub(row) _indexData.files.Rows.Remove(row))
		If removeFolder Then _indexData.folders.Rows.Remove(rowParent)
	End Sub

	Private Function UpdateId3Tag _
	(ByVal row As filesRow _
	, ByVal id3TagField As Id3TagFields _
	, ByVal newValue As Object) As Int32

		'Dim fileName = My.Computer.FileSystem.CombinePath _
		'(row.path, row.name)

		'If Not My.Computer.FileSystem.FileExists(fileName) Then
		'	Return 0
		'End If

		'Try
		'	Dim id3 As New UltraID3
		'	id3.Read(fileName)

		'	Select Case id3TagField
		'		Case Id3TagFields.Album
		'			id3.Album = newValue.ToString
		'			row.album = newValue.ToString
		'		Case Id3TagFields.Artist
		'			id3.Artist = newValue.ToString
		'			row.artist = newValue.ToString
		'		Case Id3TagFields.Comments
		'			id3.Comments = newValue.ToString
		'			row.comment = newValue.ToString
		'		Case Id3TagFields.Genre
		'			Try
		'				id3.Genre = newValue.ToString
		'			Catch ex As Exception
		'				id3.Genre = ""
		'				id3.ID3v23Tag.Genre = newValue.ToString
		'			End Try
		'			row.genre = newValue.ToString
		'		Case Id3TagFields.Title
		'			id3.Title = newValue.ToString
		'			row.title = newValue.ToString
		'		Case Id3TagFields.TrackNum
		'			Try
		'				id3.TrackNum = Short.Parse(newValue.ToString)
		'				row.track = newValue.ToString
		'			Catch ex As Exception
		'				id3.TrackNum = Nothing
		'				row.track = ""
		'			End Try
		'		Case Id3TagFields.Year
		'			Try
		'				id3.Year = Short.Parse(newValue.ToString)
		'				row.year = newValue.ToString
		'			Catch ex As Exception
		'				id3.Year = Nothing
		'				row.year = ""
		'			End Try
		'	End Select
		'	id3.Write()
		'Catch ex As Exception
		'	Return -1
		'End Try

		Return 0
	End Function
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	Public Sub BuildIndex(ByVal path As String)
		GetFolders(path, True)
	End Sub

	Public Sub SaveIndex()
		_indexData.WriteXmlSchema(_indexFileName & ".xsd")
		_indexData.WriteXml(_indexFileName & ".xml")
	End Sub

	Public Function UpdateId3Title _
	(ByVal artist As String _
	, ByVal album As String _
	, ByVal title As String _
	, ByVal id3TagField As Id3TagFields _
	, ByVal newValue As Object) As Int32

		Return GetExecuteUpdateResults(Me.IndexData.files.Rows.Cast(Of filesRow).Where _
		(Function(row) (row.artist.ToLower = artist.ToLower) _
		AndAlso (row.album.ToLower = album.ToLower) _
		AndAlso (row.title.ToLower = title.ToLower)).ToList)
	End Function

	Public Function UpdateId3Album _
	(ByVal artist As String _
	, ByVal album As String _
	, ByVal id3TagField As Id3TagFields _
	, ByVal newValue As Object) As Int32

		Return GetExecuteUpdateResults(Me.IndexData.files.Rows.Cast(Of filesRow).Where _
		(Function(row) (row.artist.ToLower = artist.ToLower) _
		AndAlso (row.album.ToLower = album.ToLower)).ToList)
	End Function

	Public Function UpdateId3Artist _
	(ByVal artist As String _
	, ByVal id3TagField As Id3TagFields _
	, ByVal newValue As Object) As Int32

		Return GetExecuteUpdateResults(Me.IndexData.files.Rows.Cast(Of filesRow).Where _
		(Function(row) (row.artist.ToLower = artist.ToLower)).ToList)
	End Function

	Public Function UpdateId3Genre _
	(ByVal genre As String _
	, ByVal id3TagField As Id3TagFields _
	, ByVal newValue As Object) As Int32

		Return GetExecuteUpdateResults(Me.IndexData.files.Rows.Cast(Of filesRow).Where _
		(Function(row) (row.genre.ToLower = genre.ToLower)).ToList)
	End Function
#End Region	'{Öffentliche Methoden der Klasse}

	End Class


