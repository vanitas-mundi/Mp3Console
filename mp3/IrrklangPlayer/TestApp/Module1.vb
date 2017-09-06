Imports SSP.IrrklangPlayer

	Module Module1

		Sub Main()

			'For Each key In SoundDevices.Items.Keys
			'	Dim sd = SoundDevices.Items(key)
			'	Console.WriteLine(sd.Description & " - " & key)
			'Next

			'Console.ReadKey()

			Dim player = New PlayerObject
			player.InitializePlayer()
			player.FileName = "X:\mp3\archiv-eingang\LDC A1 Die Schwarze Zone.mp3"
			player.Play()

			Console.ReadKey()
		End Sub

	End Module
