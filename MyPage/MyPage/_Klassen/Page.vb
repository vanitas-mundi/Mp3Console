Option Explicit On 
Option Strict On
Option Infer On

#Region " --------------->> Klasse Page "

<Serializable()> _
Public Class Page

Inherits BCW.Data.MySqlDataClass
Implements BCW.Data.IMySqlDataItem

#Region " -------------->> Implementierung ICustomTypeDescriptor (Sortierung) "

  Implements System.ComponentModel.ICustomTypeDescriptor

  <NonSerialized()> Private _GlobalizedProps As System.ComponentModel.PropertyDescriptorCollection

  Private Sub SetSortOrder _
  (ByVal baseProps As System.ComponentModel.PropertyDescriptorCollection)

    _GlobalizedProps = New  _
    System.ComponentModel.PropertyDescriptorCollection(Nothing)

    _GlobalizedProps.Add(baseProps.Item("PageID"))
    _GlobalizedProps.Add(baseProps.Item("Page"))
    _GlobalizedProps.Add(baseProps.Item("ParentPage"))
    _GlobalizedProps.Add(baseProps.Item("PageOrder"))
    _GlobalizedProps.Add(baseProps.Item("Tag"))
    _GlobalizedProps.Add(baseProps.Item("Title"))
    _GlobalizedProps.Add(baseProps.Item("Text"))
    _GlobalizedProps.Add(baseProps.Item("Year"))
    _GlobalizedProps.Add(baseProps.Item("Created"))

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
  Private Shared _Database As String
  Private _Pages As Pages
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal connectionString As System.String _
  , ByVal id As System.Int32)

    '{Konstruktor}
    MyBase.New _
    (connectionString _
    , _Database _
    , "t_pages")
    Initialize(id)
  End Sub

  Private Sub Initialize(ByVal ID As System.Int32)
    If ID = 0 Then
      Me.Insert()
    Else
      Me.PrimaryKeyValue = ID
    End If
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

  <System.ComponentModel.Category("Eigenschaften")> _
  Public ReadOnly Property PageID As Int32
  Get
    Return CType(Me.PrimaryKeyValue, Int32)
  End Get
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Page() As System.String
  Get
    Try
      Return Me.GetValue("Page").ToString
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("Page", Value)
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften") _
  , System.ComponentModel.TypeConverter(GetType(SSP.MyPage.Windows.Forms.ParentPageTypeConverter))> _
  Public Property ParentPage() As System.String
  Get
    Try
      Return Me.GetValue("ParentPage").ToString
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("ParentPage", Value)
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property PageOrder() As System.Int32
  Get
    Try
      Return CType(Me.GetValue("PageOrder"), Int32)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.Int32)
    Me.Update("PageOrder", Value)
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
  Public WriteOnly Property PageOrder(ByVal SetNextPageOrder As Boolean) As System.Int32
  Set(ByVal Value As System.Int32)

    If SetNextPageOrder Then
      Dim usb = New BCW.Data.MySqlStatementBuilders.UpdateBuilder
      usb.UpadteTables.Add(Me.Database & "." & Me.Table)
      usb.Set.Add("PageOrder = PageOrder + 1")
      usb.Where.Add("(ParentPage = '" & Me.ParentPage & "')")
      usb.Where.Add("AND (PageOrder >= " & Value & ")")

      BCW.Data.MySqlDBResult.ExecuteNonQuery _
      (Me.ConnectionString, usb.ToString)
    End If

    Me.PageOrder = Value
  End Set
  End Property


  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Tag() As System.String
  Get
    Try
      Return Me.GetValue("Tag").ToString
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("Tag", Value)
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Title() As System.String
  Get
    Try
      Return Me.GetValue("Title").ToString
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("Title", Value)
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
  Public Property [Text]() As System.String
  Get
    Try
      Return Me.GetValue("Text").ToString
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.String)
    Me.Update("Text", Value)
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Year() As System.Int32
  Get
    Try
      Return CType(Me.GetValue("Year"), Int32)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.Int32)
    Me.Update("Year", Value)
  End Set
  End Property

  <System.ComponentModel.Category("Eigenschaften")> _
  Public Property Created() As System.DateTime
  Get
    Try
      Return CType(Me.GetValue("Created"), System.DateTime)
    Catch ex As Exception
      Return (Nothing)
    End Try
  End Get
  Set(ByVal Value As System.DateTime)
    Me.Update("Created", Value)
  End Set
  End Property

  Public ReadOnly Property Pages As Pages
  Get
    If (_Pages Is Nothing) OrElse (_Pages.Count = 0) Then
      _Pages = New Pages(Me.ConnectionString, Me.Page)
      _Pages.FillByParentPage()
    End If
    Return _Pages
  End Get
  End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub SetNextPageOrder()
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("IF(MAX(Pageorder) = 0, 0, MAX(Pageorder) + 1) AS NextPageOrder")
    sb.From.Add(Me.Database & "." & Me.Table)
    sb.Where.Add("ParentPage = '" & Me.ParentPage & "'")
    Me.PageOrder = CType(BCW.Data.MySqlDBResult.ExecuteScalar _
    (Me.ConnectionString, sb.ToString), Int32)
  End Sub

  Public Overrides Function ToString() As String
    Try
      Dim pageOrder = Me.BufferedValues("PageOrder").ToString
      If pageOrder = "0" Then
        Return  Me.BufferedValues("Title").ToString _
        & " (" & Me.BufferedValues("Page").ToString & ")"
      Else
        Return pageOrder.PadLeft(3) _
        & " " & Me.BufferedValues("Title").ToString _
        & " (" & Me.BufferedValues("Page").ToString & ")"
      End If
    Catch
      Try
        Dim pageOrder = Me.PageOrder.ToString
        If pageOrder = "0" Then
          Return Me.Title & " (" & Me.Page & ")"
        Else
          Return pageOrder.PadLeft(3) & " " & Me.Title & " (" & Me.Page & ")"
        End If
      Catch
        Return ""
      End Try
    End Try
    Return ""
  End Function

  Public Function IsRootPage() As Boolean
    Try
      Return String.IsNullOrEmpty(Me.BufferedValues.Item("ParentPage").ToString)
    Catch
      Return String.IsNullOrEmpty(Me.ParentPage)
    End Try
  End Function

  Public Shared Function PageExists _
  (ByVal connectionString As String _
  , ByVal parentPage As String _
  , ByVal page As String) As Boolean
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("IF(COUNT(1) = 0, 'False', 'True') AS PageExists")
    sb.From.Add(_Database & ".t_pages")
    sb.Where.Add("(ParentPage = '" & parentPage & "')")
    sb.Where.Add("AND (Page = '" & page & "')")
    Return CType(BCW.Data.MySqlDBResult.ExecuteScalar _
    (connectionString, sb.ToString), Boolean)
  End Function
#End Region 'Öffentliche Methoden der Klasse}

  Private Sub onBeforeDelete _
  (ByVal sender As Object _
  , ByVal e As BCW.Data.BeforeDeleteEventArgs) _
  Handles Me.BeforeDelete

    _Pages = Nothing
    For i = Me.Pages.Count - 1 To 0 Step -1
      Dim p = Me.Pages.Item(i)
      p.Delete()
    Next i
  End Sub
End Class '{Page}
#End Region '{Klasse Page}

