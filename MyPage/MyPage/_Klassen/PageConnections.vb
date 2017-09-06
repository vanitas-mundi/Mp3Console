Option Explicit On
Option Strict On
Option Infer On

Public Class PageConnections

  Inherits List(Of PageConnection)

  Public Enum fileTypes
    XML = 0
    XSD = 1
  End Enum

  Private _Path As String = ""
  Private _Name As String = ""

  Public Sub New()
    _Path = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData()
    _Name = "PageConnections"
  End Sub

  Public Sub Fill()
    Me.Clear()
    CreateXmlFile()
    Dim dt = New Data.DataTable("page_Connections")
    dt.ReadXmlSchema(GetFilename(fileTypes.XSD))
    dt.ReadXml(GetFilename(fileTypes.XML))

    For Each r As DataRow In dt.Rows
      Me.Add(New PageConnection _
      (r.Item("name").ToString _
      , r.Item("host").ToString _
      , r.Item("user_id").ToString _
      , r.Item("database").ToString))
    Next r
  End Sub

  Private Function GetFilename _
  (ByVal fileType As fileTypes) As String

    Return My.Computer.FileSystem.CombinePath _
    (_Path, _Name & "." & fileType.ToString.ToLower)
  End Function

  Public Function XmlFileExist() As Boolean
    Return (My.Computer.FileSystem.FileExists(GetFilename(fileTypes.XML))) _
    AndAlso (My.Computer.FileSystem.FileExists(GetFilename(fileTypes.XSD)))
  End Function

  Public Function CreateXmlFile() As Boolean

    If XmlFileExist() Then Return True

    Dim dt = New Data.DataTable("page_Connections")
    dt.Columns.Add("name")
    dt.Columns.Add("host")
    dt.Columns.Add("user_id")
    dt.Columns.Add("database")

    Try
      dt.WriteXmlSchema(GetFilename(fileTypes.XSD))
      dt.WriteXml(GetFilename(fileTypes.XML))
    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function

  Public Function Save() As Boolean

    Dim dt = New Data.DataTable("page_Connections")
    dt.Columns.Add("name")
    dt.Columns.Add("host")
    dt.Columns.Add("user_id")
    dt.Columns.Add("database")

    For Each ftpServer In Me
      Dim r = dt.NewRow
      r.Item("name") = ftpServer.Name
      r.Item("host") = ftpServer.Host
      r.Item("user_id") = ftpServer.UserID
      r.Item("database") = ftpServer.database
      dt.Rows.Add(r)
    Next ftpServer

    Try
      dt.WriteXmlSchema(GetFilename(fileTypes.XSD))
      dt.WriteXml(GetFilename(fileTypes.XML))
    Catch ex As Exception
      Return False
    End Try

    Return True
  End Function
End Class
