
Imports SSP.IndexerLibrary

Module Module1



	Sub Main()


		Dim i = New SSP.IndexerLibrary.IndexBuilder("xxx", "x:\temp")

		Console.WriteLine(i.IndexData.RootFolders.Count)
		Console.WriteLine(i.IndexData.folders.Count)

		For Each item In i.IndexData.RootFolders()
			Console.WriteLine(item)
		Next

		Console.ReadKey()
		'i.BuildIndex("x:\temp\mp31")
		'i.BuildIndex("x:\temp\mp32")
		'i.SaveIndex()
		'Console.Write("ready")
		'Console.ReadKey()
	End Sub
End Module
