Option Explicit On 
Option Strict On
Option Infer On

Namespace WebBrain

#Region " --------------->> Klasse WebBrainMember "

<Serializable()> _
Public Class WebBrainMember

Inherits BCW.Data.MySqlDataClass
Implements BCW.Data.IMySqlDataItem

#Region " -------------->> Implementierung ICustomTypeDescriptor (Sortierung) "

  Implements System.ComponentModel.ICustomTypeDescriptor

  <NonSerialized()> Private _GlobalizedProps As System.ComponentModel.PropertyDescriptorCollection

  Private Sub SetSortOrder _
  (ByVal baseProps As System.ComponentModel.PropertyDescriptorCollection)

    _GlobalizedProps = New  _
    System.ComponentModel.PropertyDescriptorCollection(Nothing)

    _GlobalizedProps.Add(baseProps.Item("ConnectionInfos"))
    _GlobalizedProps.Add(baseProps.Item("GroupName"))
    _GlobalizedProps.Add(baseProps.Item("Displayname"))
    _GlobalizedProps.Add(baseProps.Item("Url"))
    _GlobalizedProps.Add(baseProps.Item("Login"))
    _GlobalizedProps.Add(baseProps.Item("Pwd"))
    _GlobalizedProps.Add(baseProps.Item("Comment"))
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
  (ByVal ConnectionString As System.String _
  , ByVal webBrainID As System.Int32)

    '{Konstruktor}
    MyBase.New _
    (ConnectionString _
    , "usr_web_103_1" _
    , "t_webbrain")
    Initialize(webBrainID)
  End Sub

  Private Sub Initialize(ByVal ID As System.Int32)
    If ID = 0 Then
      Me.Insert()
    Else
      Me.PrimaryKeyValue = ID
    End If
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property WebBrainID() As System.Int32
  Get
    Return CType(Me.PrimaryKeyValue, Int32)
  End Get
  End Property

  <System.ComponentModel.Category("Logininformationen")> _
  Public Property GroupName() As System.String
  Get
    Try
      Return Me.GetValueOf(Of String)("groupname")
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("groupname", Value)
  End Set
  End Property


  <System.ComponentModel.Category("Logininformationen")> _
  Public Property Displayname() As System.String
  Get
    Try
      Return Me.GetValueDecodeOf(Of String)("displayname", EncodeString)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.UpdateEncode("displayname", Value, EncodeString)
  End Set
  End Property

  <System.ComponentModel.Category("Logininformationen")> _
  Public Property Url() As System.String
  Get
    Try
      Return Me.GetValueDecodeOf(Of String)("url", EncodeString)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.UpdateEncode("url", Value, EncodeString)
  End Set
  End Property

  <System.ComponentModel.Category("Logininformationen")> _
  Public Property Login() As System.String
  Get
    Try
      Return Me.GetValueDecodeOf(Of String)("login", EncodeString)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.UpdateEncode("login", Value, EncodeString)
  End Set
  End Property

  <System.ComponentModel.Category("Logininformationen")> _
  Public Property Pwd() As System.String
  Get
    Try
      Return Me.GetValueDecodeOf(Of String)("pwd", EncodeString)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.UpdateEncode("pwd", Value, EncodeString)
  End Set
  End Property

  <System.ComponentModel.TypeConverter(GetType(BCW.UIEditors.UIMemoEditor)) _
  , System.ComponentModel.Category("Logininformationen")> _
  Public Property Comment() As System.String
  Get
    Try
      Return Me.GetValueDecodeOf(Of String)("Comment", EncodeString)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.UpdateEncode("Comment", Value, EncodeString)
  End Set
  End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Overrides Function ToString() As String
    Try
      Return Me.BufferedValues.Item("Displayname").ToString
    Catch ex As Exception
      Try
        Return Me.Displayname
      Catch
        Return Nothing
      End Try
    End Try
    Return ""
  End Function

#End Region 'Öffentliche Methoden der Klasse}

End Class '{WebBrainMember}
#End Region '{Klasse WebBrainMember}

End Namespace