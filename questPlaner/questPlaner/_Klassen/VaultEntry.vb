Option Explicit On
Option Strict On
Option Infer On

Public Class VaultEntry
  Inherits BCW.Data.MySqlDataClass

  Public Sub New _
  (ByVal connectionString As String _
  , ByVal vaultID As Int32)

    MyBase.New(connectionString, My.Settings.Database, "ddo_vault")
    If vaultID = 0 Then
      Me.PrimaryKeyValue = Me.Insert()
    Else
      Me.PrimaryKeyValue = vaultID
    End If
  End Sub

  Public Shadows ReadOnly Property ValutID() As Int32
  Get
    Return CType(Me.PrimaryKeyValue, Int32)
  End Get
  End Property

  Public Property CharacterID() As Int32
  Get
    Try
      Return CType(Me.GetValue("CharacterID"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("CharacterID", value)
  End Set
  End Property

  Public Property Item() As String
  Get
    Try
      If Not Me.BufferedValues.Keys.Contains("Item") Then
        Me.BufferedValues.Add("Item" _
        , CType(Me.GetValue("Item"), String))
      End If
      Return Me.BufferedValues.Item("Item").ToString
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("Item", value)
  End Set
  End Property

  Public Property Category() As String
  Get
    Try
      Return CType(Me.GetValue("Category"), String)
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("Category", value)
  End Set
  End Property

  Public Property Comment() As String
  Get
    Try
      Return CType(Me.GetValue("Comment"), String)
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("Comment", value)
  End Set
  End Property

  Public Overrides Function ToString() As String
    Try
      Return Me.Item
    Catch ex As Exception
      Return ""
    End Try
  End Function
End Class
