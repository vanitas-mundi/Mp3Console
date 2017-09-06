Option Explicit On
Option Infer On
Option Strict On

Imports SSP.ConsoleExt.Tools
Imports System.Text

	Public Class MessageDrawings

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _messages As New Messages
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Messages As Messages
			Get
				Return _messages
			End Get
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Shared Sub DrawInitializeIndex()
			WriteXY(_messages.InitializeIndex, 0, 0)
		End Sub

		Public Shared Sub DrawError(ByVal message As String)
			Console.Clear()
			WriteXY(message, 0, 0)
			WriteXY(_messages.ProgramEnded, 0, 2)
			WriteXY(_messages.AnyKeyToContinue, 0, 4)
			Console.ReadKey()
		End Sub

		Public Shared Sub DrawMainMenu()
			Console.Clear()
			WriteXY(_messages.WaitForRemovable, 0, 0)
			WriteXY(_messages.PressEscapeToEnd, 0, 24)
		End Sub

		Public Shared Sub DrawDetectDevice(ByVal deviceName As String)
			Console.Clear()
			WriteXY(_messages.RemovableDetected(deviceName), 0, 0)
		End Sub

		Public Shared Sub DrawInitializeFolder(ByVal deviceName As String)
			WriteXY(_messages.InitializeFolder(deviceName), 0, 0)
		End Sub

		Public Shared Sub DrawCopyMessage _
		(ByVal copyInfo As CopyInfo)

			WriteXY(_messages.CopyFrom, 0, 2)
			WriteXY(vbTab & copyInfo.SourceFileShortName, 0, 3)
			WriteXY(_messages.CopyTo, 0, 4)
			WriteXY(vbTab & copyInfo.DestinationFileName & " ...", 0, 5)
		End Sub

		Public Shared Sub DrawCopyComplete()
			WriteXY(_messages.CopyCompleted, 0, 7)
			WriteXY(_messages.AnyKeyToContinueOrEscapeToEnd, 0, 9)
		End Sub

		Public Shared Sub DrawHelp()
			WriteXY(_messages.ProgramDescription, 0, Console.CursorTop)
			WriteXY(_messages.ProgramCalling, 0, Console.CursorTop)
			WriteXY(_messages.ProgramCallingSample, 0, Console.CursorTop)
			WriteXY(_messages.AnyKeyToContinue, 0, Console.CursorTop + 2)
			Console.ReadKey()
		End Sub
#End Region	'{Öffentliche Methoden der Klasse}

	End Class
