Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.Practices.Unity

Namespace Data

	Public MustInherit Class RepositoryBase(Of T, TContextType As ContextBase)

		Implements IRepositoryBase(Of T)

		Private _container As IUnityContainer

		Public Sub New(ByVal container As IUnityContainer, ByVal contextType As Type)
			_container = container
		End Sub

		Private Function SetStateTo(ByVal items As IEnumerable(Of T), ByVal state As Entity.EntityState) As Int32

			Using context = _container.Resolve(Of TContextType)()
				items.ToList.ForEach(Sub(item) context.Entry(item).State = state)
				context.SaveChanges()
				Return items.Count
			End Using
		End Function

		Public Function Add(ByVal item As T) As Int32 _
		Implements IRepositoryBase(Of T).Add

			Return AddRange(New T() {item})
		End Function

		Public Function AddRange(ByVal items As IEnumerable(Of T)) As Int32 _
		Implements IRepositoryBase(Of T).AddRange

			Return SetStateTo(items, Entity.EntityState.Added)
		End Function

		Public Function Update(ByVal item As T) As Int32 _
		Implements IRepositoryBase(Of T).Update

			Return UpdateRange(New T() {item})
		End Function

		Public Function UpdateRange(ByVal items As IEnumerable(Of T)) As Int32 _
		Implements IRepositoryBase(Of T).UpdateRange

			Return SetStateTo(items, Entity.EntityState.Modified)
		End Function

		Public Function Delete(ByVal item As T) As Int32 _
		Implements IRepositoryBase(Of T).Delete

			Return DeleteRange(New T() {item})
		End Function

		Public Function DeleteRange(ByVal items As IEnumerable(Of T)) As Int32 _
		Implements IRepositoryBase(Of T).DeleteRange

			Return SetStateTo(items, Entity.EntityState.Deleted)
		End Function

		Public MustOverride Function GetAll() As List(Of T) Implements IRepositoryBase(Of T).GetAll
	End Class

End Namespace
