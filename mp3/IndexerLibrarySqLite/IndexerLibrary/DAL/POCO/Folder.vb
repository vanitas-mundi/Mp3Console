Option Explicit On
Option Infer On
Option Strict On

Namespace Data

	Public Class Folder
		Public Property FolderId As Int64
		Public Property IndexName As String
		Public Property Path As String
		Public Property RootFolderPath As String
		Public Property LastWriteTime As String
		'Public Property Files As List(Of File)
	End Class

End Namespace
