Module mainModule
		Sub Main()
			Dim amazonLink = "http://www.amazon.de/s/ref=nb_sb_noss_1?__mk_de_DE=%C3%85M%C3%85Z%C3%95%C3%91&url=search-alias%3Ddvd&field-keywords="
			For Each arg In My.Application.CommandLineArgs
				Dim fi = My.Computer.FileSystem.GetFileInfo(arg)
				Dim movieName = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length)
				Process.Start(amazonLink & movieName)
			Next arg
		End Sub
End Module
