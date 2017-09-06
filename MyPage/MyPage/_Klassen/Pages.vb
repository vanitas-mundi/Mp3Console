Option Explicit On 
Option Strict On
Option Infer On

#Region " --------------->> Klasse Pages "

<Serializable()> _
Public Class Pages

Inherits BCW.Data.MySqlDataClassGenericList(Of SSP.MyPage.Page)

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private Shared _Database As String
  Private _ParentPage As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal connectionString As System.String _
  , ByVal parentPage As String)
    '{Konstruktor}
    MyBase.New(connectionString)
    _ParentPage = parentPage
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Shared Property DatabaseName As String
  Get
    Return _Database
  End Get
  Set(ByVal Value As System.String)
    _Database = Value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function GetDefaultStatement() _
  As BCW.Data.MySqlStatementBuilders.SelectBuilder
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("p._rowid")
    sb.Select.Add("p.Page")
    sb.Select.Add("p.ParentPage")
    sb.Select.Add("p.PageOrder")
    sb.Select.Add("p.Tag")
    sb.Select.Add("p.Title")
    sb.From.Add(_Database & ".`t_pages` p")
    sb.Order.Add("p.PageOrder")
    sb.Order.Add("p.Title")
    Return sb
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Overrides Function ToString() As String
    Return "Pages"
  End Function

  Public Sub FillByRootPages()
    Dim sb = GetDefaultStatement()
    sb.Where.Add("ParentPage = ''")
    Me.Fill(sb.ToString)
  End Sub

  Public Sub FillByParentPage()
    Dim sb = GetDefaultStatement()
    sb.Where.Add("ParentPage = '" & _ParentPage & "'")
    Me.Fill(sb.ToString)
  End Sub

  Public Sub ReorderPages()
    Me.Clear()
    Me.FillByParentPage()

    Dim i = 0
    For Each p As Page In Me
      i += 1
      p.PageOrder = i
    Next p
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Pages}
#End Region '{Klasse Pages}

