Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.Practices.Unity

Namespace Data

	Public Class IndexerRepository
		Private _files As FilesRepository
		Private _container As IUnityContainer

		Public Sub New(ByVal container As IUnityContainer)
			_container = container
			_files = New FilesRepository(_container)
		End Sub

		Public ReadOnly Property Files As FilesRepository
		Get
			Return _files
		End Get
		End Property
	End Class

End Namespace
