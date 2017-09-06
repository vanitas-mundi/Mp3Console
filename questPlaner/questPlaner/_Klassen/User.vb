Option Explicit On
Option Strict On
Option Infer On

Public Class User
  Inherits BCW.Data.MySqlDataClass

  Public Sub New _
  (ByVal connectionString As String _
  , ByVal userID As Int32)

    MyBase.New(connectionString, My.Settings.Database, "ddo_users")
    If userID = 0 Then
      Me.PrimaryKeyValue = Me.Insert()
    Else
      Me.PrimaryKeyValue = userID
    End If
  End Sub

  Public Shadows ReadOnly Property UserID() As Int32
  Get
    Return CType(Me.PrimaryKeyValue, Int32)
  End Get
  End Property

  Public Property UserName() As String
  Get
    Try
      If Not Me.BufferedValues.Keys.Contains("UserName") Then
        Me.BufferedValues.Add("UserName" _
        , CType(Me.GetValue("UserName"), String))
      End If
      Return Me.BufferedValues.Item("UserName").ToString
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("UserName", value)
  End Set
  End Property

  Public Property Password() As String
  Get
    Try
      Return Me.GetValueOf(Of String)("Password")
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.UpdateMD5("Password", value)
  End Set
  End Property

  ''' <summary>
  ''' Prüft ob das übergebene Kennwort mit dem hinterlegtem überein stimmt.
  ''' </summary>
  Public Function PasswordIs(ByVal password As String) As Boolean

    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("IF(COUNT(1) = 0, ""False"", ""True"") AS PasswordIs")
    sb.From.Add(My.Settings.Database & ".ddo_users")
    sb.Where.Add("(UserID = " & Me.UserID & ")")
    sb.Where.Add("AND (MD5(""" & BCW.etc.Transform.ReplaceEscape _
    (password) & """) = Password)")

    Try
      Return CType(BCW.Data.MySqlDBResult.ExecuteScalar _
      (Me.ConnectionString, sb.ToString), Boolean)
    Catch ex As Exception
      Return False
    End Try
  End Function

  Public Overrides Function ToString() As String
    Try
      Return Me.UserName
    Catch ex As Exception
      Return ""
    End Try
  End Function
End Class
