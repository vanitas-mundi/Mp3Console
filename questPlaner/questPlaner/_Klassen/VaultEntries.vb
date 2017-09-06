Public Class VaultEntries
  Inherits BCW.Data.MySqlDataClassGenericList(Of VaultEntry)

  Public Sub New(ByVal connectionString As String)
    MyBase.New(connectionString)
  End Sub

  Public Sub FillByCharacter(ByVal characterID As Int32)
    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("_rowid")
    sb.Select.Add("Item")
    sb.Select.Add("Category")
    sb.Select.Add("Comment")
    sb.From.Add(My.Settings.Database & ".ddo_vault")
    sb.Where.Add("CharacterID = " & characterID)

    Me.Fill(sb.ToString)
  End Sub
End Class
