Option Explicit On
Option Infer On
Option Strict On

	Public Class FileAddedToIndexEventArgs

		Inherits EventArgs

		Private _fileName As String

		Public Sub New(ByVal fileName As String)
			_fileName = fileName
		End Sub

		Public ReadOnly Property FileName() As String
		Get
			Return _fileName
		End Get
		End Property

	End Class
