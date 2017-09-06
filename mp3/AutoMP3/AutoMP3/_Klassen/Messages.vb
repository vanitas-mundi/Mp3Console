Option Explicit On
Option Infer On
Option Strict On

Imports System.Text

	Public Class Messages

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property InitializeIndexError As String
			Get
				Return "Index-Initialisierung - Ein Fehler ist aufgetreten!"
			End Get
		End Property

		Public ReadOnly Property CopyError As String
			Get
				Return "Kopiervorgang - Es ist ein Fehler aufgetreten!"
			End Get
		End Property

		Public ReadOnly Property AnyKeyToContinue As String
			Get
				Return "<Taste, um fortzufahren>"
			End Get
		End Property

		Public ReadOnly Property InitializeIndex As String
			Get
				Return "Initialisiere Index ..."
			End Get
		End Property

		Public ReadOnly Property ProgramEnded As String
			Get
				Return "Programm wurde beendet!"
			End Get
		End Property

		Public ReadOnly Property WaitForRemovable As String
			Get
				Return "Warte auf Wechseldatenträger ..."
			End Get
		End Property

		Public ReadOnly Property PressEscapeToEnd As String
			Get
				Return "<Beenden mit ESC>"
			End Get
		End Property

		Public ReadOnly Property RemovableDetected _
		(ByVal deviceName As String) As String
			Get
				Return "Wechseldatenträger " & deviceName & " entdeckt!"
			End Get
		End Property

		Public ReadOnly Property InitializeFolder _
		(ByVal deviceName As String) As String
			Get
				With My.Computer.FileSystem
					Return "Initialisiere Ordner " _
					& .CombinePath(deviceName, ".auto_mp3") & "!"
				End With
			End Get
		End Property

		Public ReadOnly Property CopyFrom As String
			Get
				Return "Kopiere"
			End Get
		End Property

		Public ReadOnly Property CopyTo As String
			Get
				Return "nach"
			End Get
		End Property

		Public ReadOnly Property CopyCompleted As String
			Get
				Return "Kopiervorgang abgeschlossen!"
			End Get
		End Property

		Public ReadOnly Property AnyKeyToContinueOrEscapeToEnd As String
			Get
				Return "<Taste, um fortzufahren - Beenden mit ESC>"
			End Get
		End Property

		Public ReadOnly Property ProgramDescription As String
			Get
				Dim sb = New StringBuilder
				sb.AppendLine("Prüft, ob ein Wechseldatenträger verbunden wird")
				sb.AppendLine("und kopiert darauf eine zufällige mp3-Datei")
				sb.AppendLine("in den Ordner .mp3_auto.")
				sb.AppendLine("Der Ordner wird zuvor gelöscht. Die Datei wird")
				sb.AppendLine("anhand des angegebenen Indexes ermittelt.")
				sb.AppendLine("")
				Return sb.ToString
			End Get
		End Property

		Public ReadOnly Property ProgramCalling As String
			Get
				Dim sb = New StringBuilder
				sb.AppendLine("AUTO_MP3 [Indexverzeichnis] [Indexname] [/?]")
				sb.AppendLine("  [Indexverzeichnis] - Verzeichnis in welchem der Index zu finden ist.")
				sb.AppendLine("  [Indexname]        - Name des indexes.")
				sb.AppendLine("  /?                 - Zeigt diese Hilfe an.")
				sb.AppendLine("")
				Return sb.ToString
			End Get
		End Property

		Public ReadOnly Property ProgramCallingSample As String
			Get
				Return "Beispiel: AUTO_MP3 ""c:\mp3\index"" ""myindex"""
			End Get
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region	'{Öffentliche Methoden der Klasse}

	End Class
