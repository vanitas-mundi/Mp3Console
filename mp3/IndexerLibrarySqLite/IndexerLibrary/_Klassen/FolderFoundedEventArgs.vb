Option Explicit On
Option Infer On
Option Strict On

	Public Class FolderFoundedEventArgs

	Inherits EventArgs

		Private _folder As String
		Private _rootFolder As Boolean

		Public Sub New(ByVal path As String, ByVal rootFolder As Boolean)
			_folder = path
			_rootFolder = rootFolder
		End Sub

		Public ReadOnly Property Folder() As String
		Get
			Return _folder
		End Get
		End Property

		Public ReadOnly Property RootFolder As Boolean
		Get
			Return _rootFolder
		End Get
		End Property
	End Class
