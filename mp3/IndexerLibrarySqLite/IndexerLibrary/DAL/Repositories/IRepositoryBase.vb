Option Explicit On
Option Infer On
Option Strict On

Namespace Data

	Public Interface IRepositoryBase(Of T)
		Function Add(ByVal item As T) As Int32
		Function AddRange(ByVal items As IEnumerable(Of T)) As Int32
		Function Update(ByVal item As T) As Int32
		Function UpdateRange(ByVal items As IEnumerable(Of T)) As Int32
		Function Delete(ByVal item As T) As Int32
		Function DeleteRange(ByVal items As IEnumerable(Of T)) As Int32
		Function GetAll() As List(Of T)
	End Interface

End Namespace

