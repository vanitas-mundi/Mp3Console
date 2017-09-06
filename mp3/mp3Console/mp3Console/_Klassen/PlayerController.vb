Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls
Imports SSP.IrrklangPlayer

Public Class PlayerController

  Implements Imp3Console

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _IsPlaying As Boolean = False
  Private _RepeatMode As Boolean = False
  Private _CurrentTitle As SSP.IndexerLibrary.Title
  Private WithEvents _Player As New PlayerObject
  Private WithEvents _Timer As New Timers.Timer
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property RepeatMode As Boolean
  Get
    Return _RepeatMode
  End Get
  Set(ByVal value As Boolean)
    _RepeatMode = value
  End Set
  End Property

  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3Console.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property

  Public ReadOnly Property IsPlaying() As Boolean
  Get
    Return _IsPlaying
  End Get
  End Property

  Public ReadOnly Property Player() As PlayerObject
  Get
    Return _Player
  End Get
  End Property

  Public Property CurrentTitle() As SSP.IndexerLibrary.Title
  Get
    Return _CurrentTitle
  End Get
  Set(ByVal value As SSP.IndexerLibrary.Title)
    _CurrentTitle = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onTimerElapsed _
  (ByVal sender As Object _
  , ByVal e As System.Timers.ElapsedEventArgs) _
  Handles _Timer.Elapsed

    If _Player.AtEndOfSong Then
      PlayNextSong()
    Else
      Dim info As String = ""
      With Me.MP3Console.AdministrationControl.ShutDownControl
        If .ShutDownAt IsNot Nothing Then
          info = " - Systemshutdown " _
          & .ShutDownAt.Value.ToString("yyyy-MM-dd HH:mm:ss")
        End If
      End With

      Select Case Me.IsPlaying
      Case True
        Console.Title = Me.CurrentTitle.Title & " - " _
        & _Player.ElapsedTime _
        & " | " & _Player.RemainTime & info
      Case Else
        Console.Title = Me.CurrentTitle.Title & " - " _
        & _Player.ElapsedTime _
        & " | " & _Player.RemainTime & info
      End Select
    End If
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub InitializePlayerController()
    Me.CurrentTitle = Me.MP3Console.HistoryControl.History.Item _
    (Me.MP3Console.HistoryControl.HistoryIndex)

    Select Case True
    Case Me.CurrentTitle Is Nothing
      Try
        Dim fileName = My.Computer.FileSystem.CombinePath _
        (My.Application.Info.DirectoryPath, "data\error.mp3")
        Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
        id3.Read(fileName)
        Me.CurrentTitle = New SSP.IndexerLibrary.Title(id3)
      Catch ex As Exception
      End Try
    End Select

    _Timer.Interval = 500
    Console.Title = "mp3Console - " & Me.CurrentTitle.Title
    Me.Player.FileName = Me.CurrentTitle.FileName
    _IsPlaying = False
    Me.Player.Volume = My.Settings.CurrentVolume
    _Timer.Start()
  End Sub

  Public Sub RestoreLastPlayedTitle()

    If (My.Settings.LastPlayedSong.Length = 0) _
    OrElse (Not My.Computer.FileSystem.FileExists _
    (My.Settings.LastPlayedSong)) Then Exit Sub

    'Position um 10 Sekunden zurücksetzen
    Dim t = TimeSpan.Parse(My.Settings.LastPlayedSongPosition)
    t = t.Subtract(TimeSpan.Parse("00:00:10"))

    Select Case t.ToString.StartsWith("-")
    Case True
      Me.Player.CurrentPosition = "00:00:00"
    Case Else
      Me.Player.Play()
      Me.Player.CurrentPositionUInt = CUInt(t.TotalSeconds)
      Me.Player.Pause()
    End Select
  End Sub

  Public Sub PlaySong()
    If Me.IsPlaying Then
      _IsPlaying = False
      _Player.Pause()
    Else
      _IsPlaying = True
      _Player.Play()
    End If
    Me.MP3Console.MenuDrawing.DrawTitleInformationBox()
  End Sub

  Public Sub PlayPreviousSong()
    With Me.MP3Console
      _Timer.Stop()
      Me.Player.Stop()

      .MenuDrawing.DrawMainBorder()

      If .HistoryControl.HistoryIndex <= 0 Then
        .HistoryControl.HistoryIndex = .HistoryControl.History.Count
      End If

      .HistoryControl.HistoryIndex -= 1
      Me.CurrentTitle = .HistoryControl.History.Item _
      (.HistoryControl.HistoryIndex)

      .MenuDrawing.DrawTitleInformationBox()

      Console.Title = "mp3Console - " & Me.CurrentTitle.Title
      Me.Player.FileName = Me.CurrentTitle.FileName
      _IsPlaying = True
      Me.Player.Play()
      Me.Player.Volume = My.Settings.CurrentVolume

      _Timer.Start()
    End With
  End Sub

	Public Sub PlayNextSong()
		PlayNextSong(True)
	End Sub


	Public Sub PlayNextSong(ByVal playAfterSelectTitle As Boolean)
		With Me.MP3Console
			_Timer.Stop()
			Me.Player.Stop()
			_IsPlaying = False

			.HistoryControl.ExpandHistory()

			.HistoryControl.HistoryIndex += 1
			Me.CurrentTitle = .HistoryControl.History.Item _
			(.HistoryControl.HistoryIndex)

			Select Case True
			Case Me.CurrentTitle Is Nothing
				Dim fileName = My.Computer.FileSystem.CombinePath _
				(My.Application.Info.DirectoryPath, "data\error.mp3")
				Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
				id3.Read(fileName)
				Me.CurrentTitle = New SSP.IndexerLibrary.Title(id3)
			End Select

			If Not Me.Player.FileName = Me.CurrentTitle.FileName Then
				.MenuDrawing.DrawTitleInformationBox()
				Console.Title = "mp3Console - " & Me.CurrentTitle.Title
				Me.Player.FileName = Me.CurrentTitle.FileName
				If playAfterSelectTitle Then
					_IsPlaying = True
					Me.Player.Play()
				End If
				Me.Player.Volume = My.Settings.CurrentVolume
			End If
			_Timer.Start()
		End With
	End Sub

	Public Sub PlayImmediately()
		PlayImmediately(1)
	End Sub

	Public Sub PlayImmediately(ByVal titleCount As Int32)
		With Me.MP3Console
			.MenuDrawing.ClearAdvancedInformationBox()

			Dim ib As New ConsoleMessageBox("Sofortige Wiedergabe" _
			, New String() {"Titel sofort wiedergegeben werden?"} _
			, 1, 9, 50, .Colors)

			Select Case ib.ShowMessage(ConsoleExt.MessageBoxTypes.YesNoCancel)
			Case ConsoleExt.MessageBoxResults.Yes
				.HistoryControl.HistoryIndex _
				= .HistoryControl.History.Count - (1 + titleCount)
				Me.PlayNextSong()
			Case ConsoleExt.MessageBoxResults.Cancel
				For i = titleCount To 1 Step -1
					.HistoryControl.History.RemoveAt _
					(.HistoryControl.History.Count - 1)
				Next i
			End Select
		End With
	End Sub
#End Region	'Öffentliche Methoden der Klasse}

End Class
