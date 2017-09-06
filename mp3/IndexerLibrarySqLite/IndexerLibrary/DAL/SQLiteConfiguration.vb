Option Explicit On
Option Infer On
Option Strict On

Imports System.Data.Entity
Imports System.Data.SQLite
Imports System.Data.SQLite.EF6
Imports System.Reflection
Imports System.Data.Entity.Core.Common

Namespace Data

	Public Class SQLiteConfiguration

		Inherits DbConfiguration

		Public Sub New()
			Me.SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance)
			Me.SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance)
			Dim t = Type.GetType("System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6")
			Dim fi = t.GetField("Instance", BindingFlags.NonPublic Or BindingFlags.Static)
			Me.SetProviderServices("System.Data.SQLite", DirectCast(fi.GetValue(Nothing), DbProviderServices))
		End Sub

	End Class

End Namespace

