Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.Practices.Unity

Namespace Data

	Public Class FilesRepository

		Inherits RepositoryBase(Of File, IndexerContext)

		Private _container As IUnityContainer

		Public Sub New(ByVal container As IUnityContainer)
			MyBase.New(container, GetType(IndexerContext))
			_container = container
		End Sub

		Public Overrides Function GetAll() As List(Of File)
			Using context = _container.Resolve(Of IndexerContext)()
				Return context.Files.ToList
			End Using
		End Function

		Public Function GetByTitle(ByVal title As String) As List(Of File)

			Using context = _container.Resolve(Of IndexerContext)()
				Return context.Files.Where(Function(f) f.Title.ToLower = title.ToLower).ToList
			End Using
		End Function

		Public Function GetByAlbum(ByVal album As String) As List(Of File)

			Using context = _container.Resolve(Of IndexerContext)()
				Return context.Files.Where(Function(f) f.Album.ToLower = album.ToLower).ToList
			End Using
		End Function

	End Class

End Namespace
