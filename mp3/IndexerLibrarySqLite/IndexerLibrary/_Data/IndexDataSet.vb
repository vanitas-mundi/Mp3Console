Option Explicit On
Option Strict On
Option Infer On

Imports System.Text
Imports SSP.IndexerLibrary.Data

Partial Public Class IndexDataSet

#Region " --------------->> Enumerationen der Klasse "
		Public Enum AlbumOrders
			Album = 0
			Year = 1
		End Enum
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _randomGenerator As New System.Random
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property TitleCount() As Int32
			Get
				Return Me.files.Rows.Count
			End Get
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Function SoundEx(ByVal word As String) As String
			Return SoundEx(word, 4)
		End Function

		Private Function SoundEx _
		(ByVal word As String _
		, ByVal length As Integer) As String

			Dim value = ""
			Dim size = word.Length

			' Make sure the word is at least two characters in length
			If size > 1 Then

				' Convert the word to all uppercase
				word = word.ToUpper()
				' Conver to the word to a character array for faster processing
				Dim chars = word.ToCharArray()

				' Buffer to build up with character codes
				Dim buffer = New StringBuilder
				buffer.Length = 0

				' The current and previous character codes
				Dim prevCode = 0
				Dim currCode = 0

				' Append the first character to the buffer
				buffer.Append(chars(0))

				' Prepare variables for loop
				Dim i As Int32
				Dim loopLimit = size - 1

				' Loop through all the characters and convert them to the proper character code
				For i = 1 To loopLimit
					Select Case chars(i)
						Case "A"c, "E"c, "I"c, "O"c, "U"c, "H"c, "W"c, "Y"c
							currCode = 0
						Case "B"c, "F"c, "P"c, "V"c
							currCode = 1
						Case "C"c, "G"c, "J"c, "K"c, "Q"c, "S"c, "X"c, "Z"c
							currCode = 2
						Case "D"c, "T"c
							currCode = 3
						Case "L"c
							currCode = 4
						Case "M"c, "N"c
							currCode = 5
						Case "R"c
							currCode = 6
					End Select

					' Check to see if the current code is the same as the last one
					If (currCode <> prevCode) Then
						' Check to see if the current code is 0 (a vowel); do not proceed
						If (currCode <> 0) Then
							buffer.Append(currCode)
						End If
					End If

					' If the buffer size meets the length limit, then exit the loop
					If (buffer.Length = length) Then Exit For
				Next i

				' Padd the buffer if required
				size = buffer.Length
				If (size < length) Then
					buffer.Append("0"c, (length - size))
				End If

				' Set the return value
				value = buffer.ToString()
			End If

			' Return the computed soundex
			Return value
		End Function
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'{Öffentliche Methoden}
		Public Sub LoadIndex(ByVal indexName As String)
			Dim path = My.Computer.FileSystem.CombinePath _
			(My.Application.Info.DirectoryPath, "index")

			Me.ReadXmlSchema _
			(My.Computer.FileSystem.CombinePath(path, indexName & ".xsd"))

			Me.ReadXml _
			(My.Computer.FileSystem.CombinePath(path, indexName & ".xml"))
		End Sub

		Public Function GetRandomTitle() As Title

			If Me.files.Rows.Count = 0 Then Return Nothing

			Dim rid = _randomGenerator.Next(0, Me.files.Rows.Count - 1)
			Dim row = Me.files.Rows.Item(rid)

			Dim path = My.Computer.FileSystem.CombinePath _
			(row.Item("path").ToString _
			, row.Item("name").ToString)

			'hack
			Return Nothing
			'New Title _
			'(row.Item("title").ToString _
			', row.Item("track").ToString, path)
		End Function

		Public Function GetRandomTitle _
		(ByVal genres() As String) As Title

			Dim list = New List(Of DataRow)

			For Each s In genres
				Dim genre = s
				Dim ret = From r In Me.files _
				Where DirectCast(r, DataRow).Item("genre").ToString = genre _
				Select DirectCast(r, DataRow)
				list.AddRange(ret.ToList)
			Next s

			If list.Count = 0 Then Return Nothing

			Dim rid = _randomGenerator.Next(0, list.Count - 1)
			Dim row = list.Item(rid)

			Dim path = My.Computer.FileSystem.CombinePath _
			(row.Item("path").ToString _
			, row.Item("name").ToString)

			'hack
			Return Nothing
			'New Title _
			'(row.Item("title").ToString _
			', row.Item("track").ToString, path)
		End Function

		Public Function GetRegister() As List(Of String)

			Dim ret = From item In Me.files.Rows _
			Order By DirectCast(item, filesRow).artist _
			Select (DirectCast(item, filesRow).artist & " ") _
			.Substring(0, 1).ToUpper.Trim Distinct

			Return ret.ToList
		End Function

		Public Function GetAllArtists() As List(Of String)

			Dim ret = From item In Me.files.Rows _
			Group By DirectCast(item, filesRow).artist.ToLower Into item = First() _
			Order By DirectCast(item, filesRow).artist _
			Select DirectCast(item, filesRow).artist

			Return ret.ToList
		End Function

		Public Function GetArtistsByFirstLetter _
		(ByVal letter As Char) As List(Of String)

			Dim ret = From item In Me.files.Rows _
			Group By DirectCast(item, filesRow).artist.ToLower Into item = First() _
			Where DirectCast(item, filesRow).artist.ToUpper.StartsWith(letter) _
			Order By DirectCast(item, filesRow).artist _
			Select DirectCast(item, filesRow).artist

			Return ret.ToList
		End Function

		Public Function GetAlbumsByArtist _
		(ByVal artist As String) As List(Of String)

			artist = artist.ToLower
			Dim ret = From item In Me.files.Rows _
			Where DirectCast(item, filesRow).artist.ToLower = artist _
			Group By DirectCast(item, filesRow).album.ToLower Into item = First() _
			Order By DirectCast(item, filesRow).year, DirectCast(item, filesRow).album _
			Select DirectCast(item, filesRow).album

			Return ret.ToList
		End Function

		Public Function GetAlbumsByArtist _
		(ByVal artist As String _
		, ByVal albumOrders As AlbumOrders) As List(Of String)

			Select Case albumOrders
			Case IndexDataSet.AlbumOrders.Year
				Return GetAlbumsByArtist(artist)
			Case Else
				artist = artist.ToLower
				Dim ret = From item In Me.files.Rows _
				Where DirectCast(item, filesRow).artist.ToLower = artist _
				Group By DirectCast(item, filesRow).album.ToLower Into item = First() _
				Order By DirectCast(item, filesRow).album _
				Select DirectCast(item, filesRow).album

				Return ret.ToList
			End Select
		End Function

		Public Function GetTitlesByArtistAndAlbum _
		(ByVal artist As String _
		, ByVal album As String) As List(Of Title)

			artist = artist.ToLower
			album = album.ToLower
			'hack 
			Return Nothing
			'Try
			'	Return (From item In Me.files.Rows _
			'	Where (DirectCast(item, filesRow).artist.ToLower = artist) _
			'	AndAlso (DirectCast(item, filesRow).album.ToLower = album) _
			'	Order By CType(DirectCast(item, filesRow).track, Int32).ToString("000") _
			'	, DirectCast(item, filesRow).title _
			'	Select New Title _
			'	(DirectCast(item, filesRow).title _
			'	, DirectCast(item, filesRow).track _
			'	, My.Computer.FileSystem.CombinePath _
			'	(DirectCast(item, filesRow).path _
			'	, DirectCast(item, filesRow).name))).ToList
			'Catch ex As Exception
			'	Return (From item In Me.files.Rows _
			'	Where (DirectCast(item, filesRow).artist.ToLower = artist) _
			'	AndAlso (DirectCast(item, filesRow).album.ToLower = album) _
			'	Select New Title _
			'	(DirectCast(item, filesRow).title _
			'	, DirectCast(item, filesRow).track _
			'	, My.Computer.FileSystem.CombinePath _
			'	(DirectCast(item, filesRow).path _
			'	, DirectCast(item, filesRow).name))).ToList
			'End Try
		End Function

		Public Function SearchComment _
		(ByVal comment As String) As List(Of Title)

			comment = comment.ToLower

			'hack
			Return Nothing
			'Try
			'	Return (From item In Me.files.Rows _
			'	Where (DirectCast(item, filesRow).comment.ToLower Like "*" & comment & "*") _
			'	Order By CType(DirectCast(item, filesRow).track, Int32).ToString("000") _
			'	, DirectCast(item, filesRow).title _
			'	Select New Title _
			'	(DirectCast(item, filesRow).title _
			'	, DirectCast(item, filesRow).track _
			'	, My.Computer.FileSystem.CombinePath _
			'	(DirectCast(item, filesRow).path _
			'	, DirectCast(item, filesRow).name))).ToList
			'Catch ex As Exception
			'	Return (From item In Me.files.Rows _
			'	Where (DirectCast(item, filesRow).comment.ToLower Like "*" & comment & "*") _
			'	Select New Title _
			'	(DirectCast(item, filesRow).title _
			'	, DirectCast(item, filesRow).track _
			'	, My.Computer.FileSystem.CombinePath _
			'	(DirectCast(item, filesRow).path _
			'	, DirectCast(item, filesRow).name))).ToList
			'End Try
		End Function

		Public Function GetTitle _
		(ByVal artist As String _
		, ByVal album As String _
		, ByVal title As String) As Title

			artist = artist.ToLower
			album = album.ToLower
			title = title.ToLower

			'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where (DirectCast(item, filesRow).artist.ToLower = artist) _
			'AndAlso (DirectCast(item, filesRow).album.ToLower = album) _
			'AndAlso (DirectCast(item, filesRow).title.ToLower = title) _
			'Order By CType(DirectCast(item, filesRow).track, Int32).ToString("000") _
			', DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Select Case ret.Count
			'Case 0
			'	Return Nothing
			'Case Else
			'	Return ret.ToList.Item(0)
			'End Select
		End Function

		Public Function GetSoundexMatchTitles() _
		As List(Of List(Of Title))

			Dim list = New Dictionary(Of String, List(Of Title))

			For Each row As DataRow In Me.files.Rows
				Dim soundExCode = Me.SoundEx _
				(row.Item("title").ToString _
				, row.Item("title").ToString.Length)

				Dim path = My.Computer.FileSystem.CombinePath _
				(row.Item("path").ToString, row.Item("name").ToString)

				'hack
				Return Nothing
			'	Dim t As New Title _
			'	(row.Item("title").ToString _
			'	, row.Item("track").ToString _
			'	, path)

			'	Select Case list.ContainsKey(soundExCode)
			'	Case False
			'		list.Add(soundExCode, New List(Of Title))
			'	End Select
			'	list.Item(soundExCode).Add(t)
			Next row

			'Dim returnList = New List(Of List(Of Title))

			'For Each item In list.Values
			'	If item.Count > 1 Then
			'		returnList.Add(item)
			'	End If
			'Next item

			'returnList.Sort()
			'Return returnList
		End Function

		Public Function GetTitlesByFilter _
		(ByVal filter As String) As List(Of Title)

			Dim list = New List(Of Title)
			Dim dv = New DataView _
			(Me.files, filter, "", DataViewRowState.CurrentRows)

			'hack 
			Return Nothing
			'For Each row As DataRow In dv.ToTable.Rows
			'	Dim path = My.Computer.FileSystem.CombinePath _
			'	(row.Item("path").ToString, row.Item("name").ToString)

			'	Dim t = New Title _
			'	(row.Item("title").ToString _
			'	, row.Item("track").ToString _
			'	, path)

			'	list.Add(t)
			'Next row

			'list.Sort()
			'Return list
		End Function

		Public Function GetTitlesAll() As List(Of Title)

			'hack 
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Order By CType(DirectCast(item, filesRow).track, Int32).ToString("000") _
			', DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function GetGenresInFilter() As List(Of String)

			Dim ret = From row In Me.files.Rows _
			Order By CType(DirectCast(row, DataRow).Item("genre"), String) _
			Select CType(DirectCast(row, DataRow).Item("genre"), String) Distinct

			Return ret.ToList
		End Function

		Public Function SearchTitle _
		(ByVal title As String) As List(Of Title)

			'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where DirectCast(item, filesRow).title.ToLower Like "*" & title.ToLower & "*" _
			'Order By DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function SearchArtist _
		(ByVal artist As String) As List(Of Title)

			'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where DirectCast(item, filesRow).artist.ToLower Like "*" & artist.ToLower & "*" _
			'Order By DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function SearchAlbum _
		(ByVal album As String) As List(Of Title)

		'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where DirectCast(item, filesRow).album.ToLower Like "*" & album.ToLower & "*" _
			'Order By DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function SearchGenre _
		(ByVal genre As String) As List(Of Title)

			'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where DirectCast(item, filesRow).genre.ToLower = genre.ToLower _
			'Order By DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function SearchCatchword _
		(ByVal catchword As String) As List(Of Title)

			catchword = catchword.ToLower

			'hack
			Return Nothing

			'Dim ret = From item In Me.files.Rows _
			'Where (DirectCast(item, filesRow).artist.ToLower Like "*" & catchword.ToLower & "*") _
			'Or (DirectCast(item, filesRow).album.ToLower Like "*" & catchword.ToLower & "*") _
			'Or (DirectCast(item, filesRow).title.ToLower Like "*" & catchword.ToLower & "*") _
			'Or (DirectCast(item, filesRow).comment.ToLower Like "*" & catchword.ToLower & "*") _
			'Or (DirectCast(item, filesRow).genre.ToLower Like "*" & catchword.ToLower & "*") _
			'Or (DirectCast(item, filesRow).year = catchword.ToLower) _
			'Order By DirectCast(item, filesRow).title _
			'Select New Title _
			'(DirectCast(item, filesRow).title _
			', DirectCast(item, filesRow).track _
			', My.Computer.FileSystem.CombinePath _
			'(DirectCast(item, filesRow).path _
			', DirectCast(item, filesRow).name))

			'Return ret.ToList
		End Function

		Public Function RootFolders() As List(Of String)
			Return (From item In Me.folders _
			Where item.root_folder.ToLower = "true" _
			Select item.path).ToList
		End Function
#End Region	'Öffentliche Methoden der Klasse}

	End Class








