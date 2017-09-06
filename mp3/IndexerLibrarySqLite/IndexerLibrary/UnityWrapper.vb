Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.Practices.Unity

Public Class UnityWrapper

	Private Shared _container As New UnityContainer

	Private Sub New()
	End Sub

	Public Shared Function GetObject(Of T)() As T
		Return _container.Resolve(Of T)()
	End Function

	Public Shared ReadOnly Property Container As UnityContainer
	Get
		Return _container
	End Get
	End Property

End Class
