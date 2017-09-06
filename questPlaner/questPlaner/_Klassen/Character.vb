Public Class Character
  Inherits BCW.Data.MySqlDataClass

#Region " -------------->> Implementierung ICustomTypeDescriptor (Sortierung) "

  Implements System.ComponentModel.ICustomTypeDescriptor

  Private _GlobalizedProps As System.ComponentModel.PropertyDescriptorCollection

  Private Sub SetSortOrder _
  (ByVal baseProps As System.ComponentModel.PropertyDescriptorCollection)

    _GlobalizedProps = New  _
    System.ComponentModel.PropertyDescriptorCollection(Nothing)

    _GlobalizedProps.Add(baseProps.Item("CharacterName"))
    _GlobalizedProps.Add(baseProps.Item("Level"))
    _GlobalizedProps.Add(baseProps.Item("Class"))
    _GlobalizedProps.Add(baseProps.Item("HP"))
    _GlobalizedProps.Add(baseProps.Item("Mana"))
    _GlobalizedProps.Add(baseProps.Item("RK"))

    _GlobalizedProps.Add(baseProps.Item("Strength"))
    _GlobalizedProps.Add(baseProps.Item("Dexterity"))
    _GlobalizedProps.Add(baseProps.Item("Constitution"))
    _GlobalizedProps.Add(baseProps.Item("Intelligence"))
    _GlobalizedProps.Add(baseProps.Item("Wisdom"))
    _GlobalizedProps.Add(baseProps.Item("Charisma"))

    _GlobalizedProps.Add(baseProps.Item("Fortitude"))
    _GlobalizedProps.Add(baseProps.Item("Will"))
    _GlobalizedProps.Add(baseProps.Item("Reflex"))
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

  Private _Vault As VaultEntries

  Public Sub New _
  (ByVal connectionString As String _
  , ByVal characterID As Int32)

    MyBase.New(connectionString, My.Settings.Database, "ddo_characters")
    If characterID = 0 Then
      Me.PrimaryKeyValue = Me.Insert()
    Else
      Me.PrimaryKeyValue = characterID
    End If
  End Sub

  <System.ComponentModel.Browsable(False)> _
  Public ReadOnly Property CharacterID() As Int32
  Get
    Return CType(Me.PrimaryKeyValue, Int32)
  End Get
  End Property

  <System.ComponentModel.DisplayName("Name")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property CharacterName() As String
  Get
    Try
      If Not Me.BufferedValues.Keys.Contains("CharacterName") Then
        Me.BufferedValues.Add("CharacterName" _
        , CType(Me.GetValue("CharacterName"), String))
      End If
      Return Me.BufferedValues.Item("CharacterName").ToString
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("CharacterName", value)
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
  Public Shadows Property UserID() As Int32
  Get
    Try
      Return CType(Me.GetValue("UserID"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("UserID", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Stufe")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Level() As Int32
  Get
    Try
      Return CType(Me.GetValue("Level"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Level", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Charakterklasse(n)")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property [Class]() As String
  Get
    Try
      Return CType(Me.GetValue("Class"), String)
    Catch ex As Exception
      Return ""
    End Try
  End Get
  Set(ByVal value As String)
    Me.Update("Class", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Trefferpunkte")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property HP() As Int32
  Get
    Try
      Return CType(Me.GetValue("HP"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("HP", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Zauberpunkte")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Mana() As Int32
  Get
    Try
      Return CType(Me.GetValue("Mana"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Mana", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Stärke")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Strength() As Int32
  Get
    Try
      Return CType(Me.GetValue("Str"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Str", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Geschicklichkeit")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Dexterity() As Int32
  Get
    Try
      Return CType(Me.GetValue("Dex"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Dex", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Konstitution")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Constitution() As Int32
  Get
    Try
      Return CType(Me.GetValue("Con"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Con", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Intelligenz")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Intelligence() As Int32
  Get
    Try
      Return CType(Me.GetValue("`Int`"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("`Int`", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Weisheit")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Wisdom() As Int32
  Get
    Try
      Return CType(Me.GetValue("Wis"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Wis", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Charisma")> _
  <System.ComponentModel.Category("2. Attribute")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Charisma() As Int32
  Get
    Try
      Return CType(Me.GetValue("Cha"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Cha", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Rüstungsklasse")> _
  <System.ComponentModel.Category("1. Eigenschaften")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property RK() As Int32
  Get
    Try
      Return CType(Me.GetValue("RK"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("RK", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Zähigkeit")> _
  <System.ComponentModel.Category("3. Rettungswürfe")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Fortitude() As Int32
  Get
    Try
      Return CType(Me.GetValue("`For` "), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("`For`", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Reflex")> _
  <System.ComponentModel.Category("3. Rettungswürfe")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Reflex() As Int32
  Get
    Try
      Return CType(Me.GetValue("Ref"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Ref", value)
  End Set
  End Property

  <System.ComponentModel.DisplayName("Willen")> _
  <System.ComponentModel.Category("3. Rettungswürfe")> _
  <System.ComponentModel.Browsable(True)> _
  Public Property Will() As Int32
  Get
    Try
      Return CType(Me.GetValue("Wil"), Int32)
    Catch ex As Exception
      Return 0
    End Try
  End Get
  Set(ByVal value As Int32)
    Me.Update("Wil", value)
  End Set
  End Property

  <System.ComponentModel.Browsable(False)> _
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

  <System.ComponentModel.Browsable(False)> _
  Public Property Picture() As Image
  Get
    Try
      Return Me.GetBitmapValue("Picture")
    Catch ex As Exception
      Return Nothing
    End Try
  End Get
  Set(ByVal value As Image)
    Dim ar = BCW.etc.Transform.ImageToByteArray _
    (value, Drawing.Imaging.ImageFormat.Jpeg)
    Me.UpdateBinary("Picture", ar)
  End Set
  End Property

  Public ReadOnly Property Vault() As VaultEntries
  Get
    If (_Vault Is Nothing) OrElse (_Vault.Count = 0) Then
      _Vault = New VaultEntries(Me.ConnectionString)
      _Vault.FillByCharacter(Me.CharacterID)
    End If
    Return _Vault
  End Get
  End Property

  Public Sub DeleteQuest()
    Dim dsb As New BCW.Data.MySqlStatementBuilders.DeleteBuilder
    dsb.Table = My.Settings.Database & ".ddo_quests_character"
    dsb.Where.Add("CharacterID = " & Me.CharacterID)
    BCW.Data.MySqlDBResult.ExecuteNonQuery(Me.ConnectionString, dsb.ToString)
  End Sub

  Public Overrides Function ToString() As String
    Try
      Return Me.CharacterName
    Catch ex As Exception
      Return ""
    End Try
  End Function

  Private Sub onBeforeCharacterDelete _
  (ByVal sender As Object _
  , ByVal e As BCW.Data.BeforeDeleteEventArgs) _
  Handles Me.BeforeDelete

    Me.DeleteQuest()
    Dim vault As New VaultEntries(Me.ConnectionString)
    vault.FillByCharacter(Me.CharacterID)

    For Each v As VaultEntry In vault
      v.Delete()
    Next v
  End Sub
End Class
