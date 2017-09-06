Option Explicit On
Option Infer On
Option Strict On

Imports System.Threading
Imports SSP.IndexerLibrary
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt
Imports System.IO

	Public Class AutoMP3Object

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		'{/?          Hilfe anzeigen        }
		Private WithEvents _arguments As New ArgumentsParser _
		(New String() {"?"}, 2, False)
		Private _driveWatcher As DriveChangeWatcher
		Private _copying As Boolean = False
		Private _index As IndexBuilder
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
		Private Sub OnArrived _
		(ByVal sender As Object _
		, ByVal e As DriveInfo)

			CopyMP3File(e)
		End Sub

		Private Sub OnShowHelpPage _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles _arguments.ShowHelpPage

			MessageDrawings.DrawHelp()
			EndProgram(0)
		End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub EndProgram(ByVal exitCode As Int32)
			Console.Clear()
			Console.CursorVisible = True
			Environment.Exit(exitCode)
		End Sub

		Private Sub initializeIndex()
			_arguments.Parse(My.Application.CommandLineArgs.ToArray)
			Dim path = _arguments.Parameters.Item(0)
			Dim indexName = _arguments.Parameters.Item(1)

			With My.Computer.FileSystem
				If Not .FileExists(.CombinePath(path, indexName & ".xml")) Then
					MessageDrawings.DrawError(MessageDrawings.Messages.InitializeIndexError)
					EndProgram(-1)
				End If
			End With

			MessageDrawings.DrawInitializeIndex()

			Try
				_index = New IndexBuilder(indexName, path)
			Catch ex As Exception
					MessageDrawings.DrawError(MessageDrawings.Messages.InitializeIndexError)
				EndProgram(-1)
			End Try
		End Sub

		Private Sub InitializeDriveWatcher()

			_driveWatcher = New DriveChangeWatcher
			AddHandler _driveWatcher.DriveArrived, AddressOf OnArrived
		End Sub

		Private Function CheckProgramEnded() As Boolean

			Return Console.ReadKey(True).Key = ConsoleKey.Escape
		End Function

		Private Sub WaitUntilKeyPressed()
			While Not Console.KeyAvailable
				Application.DoEvents()
				Thread.Sleep(500)
			End While
		End Sub

		Private Sub WaitUntilEscapePressed()
			Dim endProgram = False

			MessageDrawings.DrawMainMenu()

			While (Not endProgram) AndAlso (Not _copying)
				WaitUntilKeyPressed()
				MessageDrawings.DrawMainMenu()
				endProgram = CheckProgramEnded()
			End While
		End Sub

		Private Function RemovableDriveIsReady _
		(ByVal driveInfo As DriveInfo) As Boolean

			Return (driveInfo.DriveType = DriveType.Removable) _
			AndAlso (driveInfo.IsReady)
		End Function

		Private Sub CreateDestinationFolder _
		(ByVal copyInfo As CopyInfo)

			MessageDrawings.DrawInitializeFolder(copyInfo.DriveInfo.Name)

			With My.Computer.FileSystem
				If .DirectoryExists(copyInfo.DestinationPath) Then
					.DeleteDirectory(copyInfo.DestinationPath _
					, FileIO.DeleteDirectoryOption.DeleteAllContents)
				End If

				.CreateDirectory(copyInfo.DestinationPath)
			End With
		End Sub

		Private Sub CopyToRemovableDrive(ByVal copyInfo As CopyInfo)

			MessageDrawings.DrawCopyMessage(copyInfo)
			With My.Computer.FileSystem
				.CopyFile(copyInfo.SourceFileName, copyInfo.DestinationFileName)
			End With
		End Sub

		Private Sub CopyMP3File(ByVal driveInfo As DriveInfo)

			If Not RemovableDriveIsReady(driveInfo) Then Exit Sub

			_copying = True

			Try
				MessageDrawings.DrawDetectDevice(driveInfo.Name)
				Dim copyInfo = New CopyInfo _
				(driveInfo, _index.IndexData.GetRandomTitle.FileName)

				CreateDestinationFolder(copyInfo)
				CopyToRemovableDrive(copyInfo)
				MessageDrawings.DrawCopyComplete()
			Catch ex As Exception
				MessageDrawings.DrawError(MessageDrawings.Messages.CopyError)
				EndProgram(-1)
			End Try

			_copying = False
		End Sub
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Sub StartAutoMP3()
			Console.CursorVisible = False
			Console.Clear()
			initializeIndex()
			InitializeDriveWatcher()
			WaitUntilEscapePressed()
			EndProgram(0)
		End Sub
#End Region	'{Öffentliche Methoden der Klasse}

	End Class
