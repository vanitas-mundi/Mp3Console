Option Explicit On
Option Infer On
Option Strict On

Imports System.Data.Entity

Namespace Data

	Public Interface IContextBase
		ReadOnly Property DbSets As Dictionary(Of Type, DbSet)
	End Interface

End Namespace

