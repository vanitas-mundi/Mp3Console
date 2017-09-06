Option Explicit On
Option Infer On
Option Strict On

Imports SSP.IndexerLibrary.Data
Imports Microsoft.Practices.Unity


Module MainModule

	Public Sub Main()
		UnityWrapper.Container.RegisterType(Of IndexerContext)()
		UnityWrapper.Container.RegisterInstance(New IndexerRepository(UnityWrapper.Container))
		Dim rep = UnityWrapper.GetObject(Of IndexerRepository)()

		rep.Files.Add(GenerateFile)
		rep.Files.GetAll.ForEach(Sub(f) Console.WriteLine(f.Title))
		Console.ReadKey()
	End Sub

	Private Sub GetData()
		Dim context = New IndexerContext
		context.Files.ToList.ForEach(Sub(f) Console.WriteLine(f.Name))

	End Sub

	Private Function GenerateFiles(ByVal n As Int32) As List(Of File)
		Dim files = New List(Of File)

		For i = 1 To n
			files.Add(GenerateFile)
		Next

		Return files
	End Function

	Private Function GenerateFile() As File
		Dim rnd As New Random

		Dim file = New File
		file.IndexName = "all"
		file.Track = rnd.Next(25).ToString("00")
		file.Title = "Titel-" & Guid.NewGuid.ToString
		file.Name = file.Track & "-" & file.Title & ".mp3"

		file.Album = "Album-" & Guid.NewGuid.ToString
		file.Artist = "Interpret-" & Guid.NewGuid.ToString

		file.Bitrate = "128"

		file.Comment = ""
		file.Duration = rnd.Next(10).ToString("00") & ":" & rnd.Next(60).ToString("00")
		file.Genre = "Neue Deutsche Härte"

		file.Path = "c:\mp3\a\" & file.Artist & "\" & file.Album
		file.Size = (rnd.Next(99999999) + 60000).ToString

		file.Year = "20" & rnd.Next(15).ToString("00")
		Return file
	End Function


End Module
