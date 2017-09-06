Option Explicit On
Option Infer On
Option Strict On

Imports System.IO

	Public Class DriveChangeWatcherEventArgs

		Inherits EventArgs

		Private _driveInfo As DriveInfo

		Public Sub New(ByVal driveInfo As DriveInfo)
			_driveInfo = driveInfo
		End Sub

		Public ReadOnly Property DriveInfo As DriveInfo
			Get
				Return _driveInfo
			End Get
		End Property
	End Class
