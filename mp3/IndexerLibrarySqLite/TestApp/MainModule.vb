Option Explicit On
Option Infer On
Option Strict On

Imports SSP.IndexerLibrary
Imports SSP.IndexerLibrary.Data

Module MainModule

	Sub Main()

		Dim context = New IndexerContext

		Dim file = New File
		'file.FileId
		'file.Folder
		file.Album = "Maskenhaft"
		file.Artist = "ASP"
		file.Bitrate = "128"
		file.Comment = "Super"
		file.Duration = "04:34"
		file.Genre = "Neue Deutsche Härte"
		file.Name = "01-Maskenhaft.mp3"
		file.Path = "c:\mp3\a\asp\maskenhaft"
		file.Size = "1234563"
		file.Title = "Maskenhaft"
		file.Track = "01"
		file.Year = "2013"

		context.Files.Add(file)
		context.SaveChanges()

		Console.Write("hehe")
		Console.ReadKey()
	End Sub

	Private Sub Old()
		'Dim i = New SSP.IndexerLibrary.IndexBuilder("xxx", "x:\temp")

		'Console.WriteLine(i.IndexData.RootFolders.Count)
		'Console.WriteLine(i.IndexData.folders.Count)

		'For Each item In i.IndexData.RootFolders()
		'	Console.WriteLine(item)
		'Next

		Console.ReadKey()
		'i.BuildIndex("x:\temp\mp31")
		'i.BuildIndex("x:\temp\mp32")
		'i.SaveIndex()
		'Console.Write("ready")
		'Console.ReadKey()
	End Sub
End Module
