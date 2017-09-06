Option Explicit On
Option Strict On
Option Infer On

Public Class PageConnection

  Private _Name As String = ""
  Private _Host As String = ""
  Private _UserID As String = ""
  Private _Database As String = ""
  Private _Password As String = ""

  Public Sub New()
  End Sub

  Public Sub New _
  (ByVal name As String _
  , ByVal hostName As String _
  , ByVal userName As String _
  , ByVal database As String)

    _Name = name
    _Host = hostName
    _UserID = userName
    _Database = database
  End Sub

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Name As String
  Get
    Return _Name
  End Get
  Set(ByVal value As String)
    _Name = value
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Host As String
  Get
    Return _Host
  End Get
  Set(ByVal value As String)
    _Host = value
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property UserID As String
  Get
    Return _UserID
  End Get
  Set(ByVal value As String)
    _UserID = value
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Database As String
  Get
    Return "`" & _Database.Replace("`", "") & "`"
  End Get
  Set(ByVal value As String)
    _Database = value
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
  Public Property Password As String
  Get
    Return _Password
  End Get
  Set(ByVal value As String)
    _Password = value
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
  Public ReadOnly Property ConnectionString As String
  Get
    Return "host=" & Me.Host & "; user id=" _
    & Me.UserID & "; password=" & Me.Password _
    & "; Database=" & _Database.Replace("`", "") & ";"
  End Get
  End Property

  Public Overrides Function ToString() As String
    Return Me.Name
  End Function
End Class
