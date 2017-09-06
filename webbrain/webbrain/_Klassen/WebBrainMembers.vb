Option Explicit On 
Option Strict On
Option Infer On

Namespace WebBrain

#Region " --------------->> Klasse WebBrainMembers "

<Serializable()> _
Public Class WebBrainMembers

Inherits BCW.Data.MySqlDataClassGenericList(Of ssp.WebBrain.WebBrainMember)

#Region " -------------->> Implementierung ICustomTypeDescriptor (Sortierung) "

  Implements System.ComponentModel.ICustomTypeDescriptor

  <NonSerialized()> Private _GlobalizedProps As System.ComponentModel.PropertyDescriptorCollection

  Private Sub SetSortOrder _
  (ByVal baseProps As System.ComponentModel.PropertyDescriptorCollection)

    _GlobalizedProps = New  _
    System.ComponentModel.PropertyDescriptorCollection(Nothing)

    '_GlobalizedProps.Add(baseProps.Item("ConnectionString"))

    '_GlobalizedProps.Add(baseProps.Item("PrimaryKeyValue"))
    '_GlobalizedProps.Add(baseProps.Item("UserID"))

    '_GlobalizedProps.Add(baseProps.Item("Database"))
    '_GlobalizedProps.Add(baseProps.Item("Table"))

    '_GlobalizedProps.Add(baseProps.Item("KeyField"))
    '_GlobalizedProps.Add(baseProps.Item("KeyValue"))

  End Sub

  Private Shadows Function GetAttributes() _
  As System.ComponentModel.AttributeCollection _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes

    Return System.ComponentModel.TypeDescriptor.GetAttributes(Me, True)
  End Function

  Private Function GetClassName() As System.String _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName

    Return System.ComponentModel.TypeDescriptor.GetClassName(Me, True)
  End Function

  Private Function GetComponentName() As System.String _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName

    Return System.ComponentModel.TypeDescriptor.GetComponentName(Me, True)
  End Function

  Private Function GetConverter() _
  As System.ComponentModel.TypeConverter _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter

    Return System.ComponentModel.TypeDescriptor.GetConverter(Me, True)
  End Function

  Private Function GetDefaultEvent() _
  As System.ComponentModel.EventDescriptor _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent

    Return System.ComponentModel.TypeDescriptor.GetDefaultEvent(Me, True)
  End Function

  Private Function GetDefaultProperty() _
  As System.ComponentModel.PropertyDescriptor _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty

    Return System.ComponentModel.TypeDescriptor.GetDefaultProperty(Me, True)
  End Function

  Private Function GetEditor(ByVal editorBaseType As System.Type) As System.Object _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor

    Return System.ComponentModel.TypeDescriptor.GetEditor(Me, editorBaseType, True)
  End Function

  Private Overloads Function GetEvents() _
  As System.ComponentModel.EventDescriptorCollection _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents

    Return System.ComponentModel.TypeDescriptor.GetEvents(Me, True)
  End Function

  Private Overloads Function GetEvents1(ByVal attributes() As System.Attribute) _
  As System.ComponentModel.EventDescriptorCollection _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
    Return System.ComponentModel.TypeDescriptor.GetEvents(Me, attributes, True)

  End Function

  Private Overloads Function GetProperties() _
  As System.ComponentModel.PropertyDescriptorCollection _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties

    If (_GlobalizedProps Is Nothing) Then
      Dim baseProps As System.ComponentModel.PropertyDescriptorCollection _
      = System.ComponentModel.TypeDescriptor.GetProperties(Me, True)

      SetSortOrder(baseProps)
    End If
    Return _GlobalizedProps
  End Function

  Private Overloads Function GetProperties1 _
  (ByVal attributes() As System.Attribute) _
  As System.ComponentModel.PropertyDescriptorCollection _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties

    If (_GlobalizedProps Is Nothing) Then
      Dim baseProps As  _
      System.ComponentModel.PropertyDescriptorCollection _
      = System.ComponentModel.TypeDescriptor.GetProperties _
      (Me, attributes, True)

      SetSortOrder(baseProps)
    End If
    Return _GlobalizedProps

  End Function

  Private Function GetPropertyOwner _
  (ByVal pd As System.ComponentModel.PropertyDescriptor) _
  As System.Object _
  Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner

    Return Me
  End Function

#End Region '{Implementierung ICustomTypeDescriptor (Sortierung)}

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Public Shared EncodeString As System.String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal connectionString As System.String)
    '{Konstruktor}
    MyBase.New(connectionString)
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function GetGroupNames() As String()
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("groupname")
    sb.From.Add("t_webbrain")
    sb.Group.Add("groupname")
    sb.Order.Add("groupname")
    Return BCW.Data.MySqlDBResult.GetFieldList(Of String) _
    (Me.ConnectionString, sb.ToString).ToArray
  End Function

  Private Function GetDefaultStatement() As BCW.Data.MySqlStatementBuilders.SelectBuilder
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("_rowid")
    sb.Select.Add("DECODE(displayname,""" & EncodeString & """) AS Displayname")
    sb.Select.Add("DECODE(url,""" & EncodeString & """) AS Url")
    sb.Select.Add("DECODE(login,""" & EncodeString & """) AS Login")
    sb.Select.Add("DECODE(pwd,""" & EncodeString & """) AS Pwd")
    sb.Select.Add("DECODE(comment,""" & EncodeString & """) AS Comment")
    sb.From.Add("t_webbrain")
    sb.Order.Add("displayname")
    Return sb
  End Function

  Public Sub FillByGroupName(ByVal groupName As String)
    Dim sb = GetDefaultStatement()
    sb.Where.Add("groupname = """ & groupName & """")
    MyBase.Fill(sb.ToString)
  End Sub

  Public Sub FillAll()
    Dim sb = GetDefaultStatement()
    MyBase.Fill(sb.ToString)
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class '{WebBrainMembers}
#End Region '{Klasse WebBrainMembers}

End Namespace