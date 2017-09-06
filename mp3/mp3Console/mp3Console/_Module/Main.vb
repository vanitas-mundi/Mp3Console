Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Module Main
  Public Sub main()
    StartMp3Console()
  End Sub

#Region " --------------->> Private Methoden des Moduls "
  '{Private Methoden}
  Private Sub StartMp3Console()
    Dim mp3Console As New mp3Console
    Console.CursorVisible = False
    Console.BackgroundColor = mp3Console.Colors.BackColor
    Console.Clear()

    Do
      mp3Console.Show()
    Loop Until exitQuery(mp3Console) = ConsoleExt.MessageBoxResults.Yes

    SaveCurrentPosition(mp3Console)
    Console.Clear()
    Console.WriteLine("mp3Console sagt auf Wiedersehen ...")

    Console.CursorVisible = True
  End Sub

  Private Function exitQuery _
  (ByVal mp3Console As mp3Console) As SSP.ConsoleExt.MessageBoxResults

    Dim mb As New ConsoleMessageBox("Programm beenden" _
    , New String() {"mp3Console wirklich beenden?"} _
    , 1, 9, 40, mp3Console.Colors)

    Return mb.ShowMessage(ConsoleExt.MessageBoxTypes.Question)
  End Function

  Private Sub SaveCurrentPosition(ByVal mp3Console As mp3Console)
    Dim mb = New ConsoleMessageBox("Programm beenden" _
    , New String() {"Soll Titel und aktuelle Spielposition gespeichert werden?"} _
    , 1, 9, 65, mp3Console.Colors)

    Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.YesNoCancel)
    Case ConsoleExt.MessageBoxResults.Cancel
      Exit Sub
    Case ConsoleExt.MessageBoxResults.Yes
      My.Settings.LastPlayedSong _
      = mp3Console.PlayerController.Player.FileName

      My.Settings.LastPlayedSongPosition _
      = mp3Console.PlayerController.Player.CurrentPosition
    Case Else
      My.Settings.LastPlayedSong = ""
      My.Settings.LastPlayedSongPosition = "00:00:00"
    End Select
    My.Settings.Save()
  End Sub
#End Region '{Private Methoden des Moduls}

End Module
