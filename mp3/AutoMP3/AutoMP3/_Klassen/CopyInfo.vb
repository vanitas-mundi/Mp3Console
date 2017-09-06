Option Explicit On
Option Infer On
Option Strict On

Imports System.IO

	Public Class CopyInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _destinationPath As String
		Private _sourceFileName As String
		Private _destinationFileName As String
		Private _driveInfo As DriveInfo
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New _
		(ByVal driveInfo As DriveInfo _
		, ByVal sourceFileName As String)

			With My.Computer.FileSystem
				_destinationPath = .CombinePath(driveInfo.Name, ".auto_mp3")
				_sourceFileName = sourceFileName
				_destinationFileName = .CombinePath _
				(_destinationPath, .GetName(_sourceFileName))
				_driveInfo = driveInfo
			End With
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property DriveInfo As DriveInfo
		Get
			Return _driveInfo
		End Get
		End Property

		Public ReadOnly Property DestinationPath As String
		Get
			Return _destinationPath
		End Get
		End Property

		Public ReadOnly Property SourceFileName As String
		Get
			Return _sourceFileName
		End Get
		End Property

		Public ReadOnly Property SourceFileShortName As String
		Get
			Return My.Computer.FileSystem.GetName(_sourceFileName)
		End Get
		End Property

		Public ReadOnly Property DestinationFileName As String
		Get
			Return _destinationFileName
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
