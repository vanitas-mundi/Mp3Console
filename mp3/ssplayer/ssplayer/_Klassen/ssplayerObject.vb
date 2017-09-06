Option Explicit On
Option Infer On
Option Strict On

Imports SSP.IrrklangPlayer
Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.Tools
Imports System.Text
Imports System.Threading


	Public Class ssplayerObject

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		'l = list sounddevices
		'd = device
		Private WithEvents _arguments As New ArgumentsParser _
		(New String() {"?", "l", "d"}, 0, True)
		Private _player As New PlayerObject
		Private _songIndex As Int32 = -1
		Private _songFileNames As New List(Of String)
		Private _soundDevice As SoundDevice
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
		Private Sub onShowHelpPage _
		(ByVal sender As Object _
		, ByVal e As System.EventArgs) _
		Handles _arguments.ShowHelpPage

			Console.WriteLine("Spielt die übergebenen Sounddateien auf dem festgelegten")
			Console.WriteLine("Ausgabegerät ab.")
			Console.WriteLine("")

			Console.WriteLine("SSPLAYER [/?] [/d:deviceid] [/l] [file1] [file2] [file...]")
			Console.WriteLine("  /?          - Zeigt diese Hilfe an.")
			Console.WriteLine("  /l          - Listet alle vorhandenen Sound Devices.")
			Console.WriteLine("  /d          - Gibt die Device ID an, welche für die")
			Console.WriteLine("                Soundausgabe verwendet wird.")
			Console.WriteLine("                Bei Nichtangabe wird das Default-Device benutzt.")
			Console.WriteLine("  [file]      - Abzuspielende MP3-Datei(en).")

			Console.WriteLine("")
			Console.WriteLine("Beispiel: SSPLAYER ""c:\music\titel1.mp3""")
			Console.WriteLine("Beispiel: SSPLAYER /d:""a35b033f-20fe-46e7-8eff-2587bb5c3156"" ""c:\music\titel1.mp3""")
		End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub Initialize()
			Console.CursorVisible = False
		End Sub

		Private Sub InitializeArguments()

			_arguments.Parse(My.Application.CommandLineArgs.ToArray)

			Select Case True
				Case _arguments.OptionExists("l")
					ListSoundDevices()
				Case _arguments.OptionExists("d")
					_soundDevice = New SoundDevice _
					(_arguments.OptionValue("d"), "")
				Case Else	'Default SoundDevice
					_soundDevice = New SoundDevice("", "")
			End Select

			With My.Computer.FileSystem
				For Each fileName In _arguments.Parameters
					If .FileExists(fileName) Then
						_songFileNames.Add(fileName)
					End If
				Next fileName
			End With
		End Sub

		Private Sub EndProgram(ByVal exitCode As Int32)
			Console.Clear()
			Console.CursorVisible = True
			Environment.Exit(exitCode)
		End Sub

		Private Sub ListSoundDevices()

			Console.Clear()
			WriteXY("Verfügbare Sound Devices:", 0, 0)
			WriteXY("==============================================", 0, 1)

			For Each sd In SoundDevices.Items.Values
				Dim sb = New StringBuilder
				sb.AppendLine("id:" & vbTab & sd.DeviceID)
				sb.AppendLine("name:" & vbTab & sd.Description)
				WriteXY(sb.ToString, 0, Console.CursorTop + 1)
			Next sd

			WriteXY("<Taste, um fortzufahren>", 0, Console.CursorTop + 1)
			Console.ReadKey()
			EndProgram(0)
		End Sub

		Private Function CheckProgramEnded() As Boolean

			Return Console.ReadKey(True).Key = ConsoleKey.Escape
		End Function

		Private Sub WaitUntilKeyPressed()
			While Not Console.KeyAvailable
				System.Windows.Forms.Application.DoEvents()
				Thread.Sleep(500)
				RefreshPlayStatus()
				If _player.AtEndOfSong Then PlayNextSong()
			End While
		End Sub

		Private Sub WaitUntilEscapePressed()
			Dim endProgram = False

			While (Not endProgram)
				WaitUntilKeyPressed()
				endProgram = CheckProgramEnded()
			End While
		End Sub

		Private Sub RefreshPlayStatus()

			With _player.ID3Tag
				WriteXY("Interpret:" & .Artist, 0, 0)
				WriteXY("Album:" & .Album, 0, 1)
				WriteXY("Titel:" & .Title, 0, 2)
				WriteXY(_player.ElapsedTime & "/" & _player.RemainTime, 0, 3)
				WriteXY("<Beenden mit ESC>", 0, 5)
			End With
		End Sub

		Private Sub InitializePlayer()
			_player.InitializePlayer(_soundDevice)
			PlayNextSong()
		End Sub

		Private Sub PlayNextSong()
			Console.Clear()

			_songIndex += 1
			If _songIndex > _songFileNames.Count - 1 Then
				_songIndex = 0
			End If

			_player.FileName = _songFileNames.Item(_songIndex)
			With _player.ID3Tag
				Console.Title = .Artist & " - " & .Title
			End With

			_player.Play()
		End Sub
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Sub Start()
			Initialize()
			InitializeArguments()
			InitializePlayer()
			WaitUntilEscapePressed()
			EndProgram(0)
		End Sub
#End Region	'{Öffentliche Methoden der Klasse}

	End Class
