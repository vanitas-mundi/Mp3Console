Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class PlaylistControl

  Implements Imp3ConsoleControl

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
  Implements Imp3ConsoleControl.MP3Console
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
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Playlist")

    Dim bmi = New BarMenuInfos _
    (1, 9, Me.MP3Console.Colors, 9)

    Dim pp As New PathPicker(bmi)

    Select Case pp.ShowPathPicker
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim ib As New ConsoleInputBox(Of String) _
    ("Playlist anlegen", "Name der Playlist:", "playlist.m3u" _
    , 1, 9, 78, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim playListName As String
    If ib.Value.ToLower.EndsWith(".m3u") Then
      playListName = My.Computer.FileSystem.CombinePath(pp.SelectedPath, ib.Value)
    Else
      playListName = My.Computer.FileSystem.CombinePath(pp.SelectedPath, ib.Value & ".m3u")
    End If

    bmi = New BarMenuInfos _
    (Me.MP3Console.HistoryControl.History.ToArray _
    , 0, 1, 9, Me.MP3Console.Colors, 9)

    Dim cbm As New SSP.ConsoleExt.BarMenus.CheckBarMenu _
    (Of SSP.IndexerLibrary.Title)(bmi)

    Select Case cbm.ShowMenu
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim list As New Generic.List(Of String)
    For Each item In cbm.Values
      list.Add(item.FileName)
    Next item

    If list.Count = 0 Then Exit Sub

    Dim message() As String

    Try
      My.Computer.FileSystem.WriteAllText _
      (playListName, String.Join(vbCrLf, list.ToArray), False, Text.Encoding.Default)
      message = New String() {"Playlist wurde angelegt!", PathShorten(playListName, 74)}
    Catch ex As Exception
      message = New String() {"Fehler", StringShorten(ex.Message, 74)}
    End Try

    Dim mb As New ConsoleMessageBox("Playlist anlegen" _
    , message, 1, 9, 78, Me.MP3Console.Colors)

    mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
