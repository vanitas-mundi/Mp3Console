Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class HelpViewer

  Implements Imp3Console

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3Console.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show(ByVal currentControl As Imp3ConsoleControl)
    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Hilfe")

    Dim path = My.Computer.FileSystem.CombinePath _
    (My.Application.Info.DirectoryPath, "hlp")

    Dim filename = ""
    ClearWindow(1, 9, 78, 21)

    Select Case True
    Case TypeOf currentControl Is mp3Console
      filename = My.Computer.FileSystem.CombinePath(path, "main.txt")
    Case TypeOf currentControl Is AdministrationControl
      filename = My.Computer.FileSystem.CombinePath(path, "admin.txt")
    Case TypeOf currentControl Is ColorControl
      filename = My.Computer.FileSystem.CombinePath(path, "color.txt")
    Case TypeOf currentControl Is DirectSelectionControl
      filename = My.Computer.FileSystem.CombinePath(path, "directselection.txt")
    Case TypeOf currentControl Is FavoritesControl
      filename = My.Computer.FileSystem.CombinePath(path, "favorites.txt")
    Case TypeOf currentControl Is FilterControl
      filename = My.Computer.FileSystem.CombinePath(path, "filter.txt")
    Case TypeOf currentControl Is HistoryControl
      filename = My.Computer.FileSystem.CombinePath(path, "history.txt")
    Case TypeOf currentControl Is IndexControl
      filename = My.Computer.FileSystem.CombinePath(path, "index.txt")
    Case TypeOf currentControl Is OutsourcingControl
      filename = My.Computer.FileSystem.CombinePath(path, "removable.txt")
    Case TypeOf currentControl Is SearchControl
      filename = My.Computer.FileSystem.CombinePath(path, "search.txt")
    Case TypeOf currentControl Is VolumeAndSeekControl
      filename = My.Computer.FileSystem.CombinePath(path, "volumeseek.txt")
    Case TypeOf currentControl Is ShutDownControl
      filename = My.Computer.FileSystem.CombinePath(path, "shutdown.txt")
    Case TypeOf currentControl Is SongTextControl
      filename = My.Computer.FileSystem.CombinePath(path, "songtext.txt")
    Case TypeOf currentControl Is SoundCardsControl
      filename = My.Computer.FileSystem.CombinePath(path, "soundcards.txt")
    Case TypeOf currentControl Is VolumeAndSeekControl
      filename = My.Computer.FileSystem.CombinePath(path, "volume.txt")
    Case TypeOf currentControl Is Id3EditorControl
      filename = My.Computer.FileSystem.CombinePath(path, "id3tageditor.txt")
    Case TypeOf currentControl Is EffectsControl
      filename = My.Computer.FileSystem.CombinePath(path, "effects.txt")
    End Select

    Dim help() As String

    If (filename = "") OrElse (Not My.Computer.FileSystem.FileExists(filename)) Then
      help = New String() {"Hilfedatei nicht vorhanden oder Zugriffsfehler!"}
    Else
      Try
        help = Text.RegularExpressions.Regex.Split _
        (My.Computer.FileSystem.ReadAllText(filename).Replace(vbCrLf, vbLf), vbLf)
      Catch ex As Exception
        help = New String() {"Hilfedatei nicht vorhanden oder Zugriffsfehler!"}
      End Try
    End If

    Dim bmi As New BarMenuInfos(help, 1, 9, Me.MP3Console.Colors, 11)
    Dim bm As New BarMenu(Of String)(bmi)
    bm.MaximumWith = 78
    bm.Border = False
    bm.ShowMenu()
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
