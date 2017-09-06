Option Explicit On
Option Infer On
Option Strict On

Imports System.Data.Entity
Imports System.Data.Common

Namespace Data

	Public MustInherit Class ContextBase

		Inherits DbContext
		Implements IContextBase

		Public Sub New(ByVal dbConnection As DbConnection)
			MyBase.New(dbConnection, True)
			Me.Configuration.LazyLoadingEnabled = False
		End Sub

	 Public MustOverride ReadOnly Property DbSets As Dictionary(Of Type, DbSet) Implements IContextBase.DbSets
	End Class

End Namespace


