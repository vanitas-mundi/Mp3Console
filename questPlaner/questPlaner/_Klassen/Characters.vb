Public Class Characters
  Inherits BCW.Data.MySqlDataClassGenericList(Of Character)

  Public Sub New(ByVal connectionString As String)
    MyBase.New(connectionString)
  End Sub

  Public Sub FillByUser(ByVal userID As Int32)
    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("c._rowid")
    sb.Select.Add("c.CharacterName")
    sb.Select.Add("c.Level")
    sb.Select.Add("c.Class")
    sb.Select.Add("c.HP")
    sb.Select.Add("c.Mana")
    sb.Select.Add("c.Str")
    sb.Select.Add("c.Dex")
    sb.Select.Add("c.Con")
    sb.Select.Add("c.Int")
    sb.Select.Add("c.Wis")
    sb.Select.Add("c.Cha")
    sb.Select.Add("c.RK")
    sb.Select.Add("c.For")
    sb.Select.Add("c.Wil")
    sb.Select.Add("c.Ref")
    sb.Select.Add("c.Comment")
    sb.From.Add(My.Settings.Database & ".ddo_characters c")
    sb.Where.Add("c.UserID = " & userID)
    sb.Order.Add("c.CharacterName")

    Me.Fill(sb.ToString)
  End Sub
End Class
