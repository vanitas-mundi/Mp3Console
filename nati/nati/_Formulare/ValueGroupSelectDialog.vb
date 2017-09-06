Public Class ValueGroupSelectDialog

  Inherits Form

#Region " ---------- Vom Designer erstellter Code --------- "
  Private WithEvents formOKButton As System.Windows.Forms.Button
  Private WithEvents formCancelButton As System.Windows.Forms.Button
  Private WithEvents ValueGroupsComboBox As System.Windows.Forms.ComboBox

  Private Sub InitializeComponent()
Me.formOKButton = New System.Windows.Forms.Button
Me.ValueGroupsComboBox = New System.Windows.Forms.ComboBox
Me.formCancelButton = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'formOKButton
'
Me.formOKButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.formOKButton.Location = New System.Drawing.Point(132, 7)
Me.formOKButton.Name = "formOKButton"
Me.formOKButton.Size = New System.Drawing.Size(70, 28)
Me.formOKButton.TabIndex = 0
Me.formOKButton.Text = "OK"
Me.formOKButton.UseVisualStyleBackColor = True
'
'ValueGroupsComboBox
'
Me.ValueGroupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ValueGroupsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me.ValueGroupsComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ValueGroupsComboBox.FormattingEnabled = True
Me.ValueGroupsComboBox.Items.AddRange(New Object() {"Tabulator", ",", ";", ":"})
Me.ValueGroupsComboBox.Location = New System.Drawing.Point(4, 8)
Me.ValueGroupsComboBox.Name = "ValueGroupsComboBox"
Me.ValueGroupsComboBox.Size = New System.Drawing.Size(122, 21)
Me.ValueGroupsComboBox.TabIndex = 4
'
'formCancelButton
'
Me.formCancelButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.formCancelButton.Location = New System.Drawing.Point(132, 38)
Me.formCancelButton.Name = "formCancelButton"
Me.formCancelButton.Size = New System.Drawing.Size(70, 28)
Me.formCancelButton.TabIndex = 5
Me.formCancelButton.Text = "Abbrechen"
Me.formCancelButton.UseVisualStyleBackColor = True
'
'ListSelectDialog
'
Me.ClientSize = New System.Drawing.Size(206, 71)
Me.Controls.Add(Me.formCancelButton)
Me.Controls.Add(Me.ValueGroupsComboBox)
Me.Controls.Add(Me.formOKButton)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.Name = "ListSelectDialog"
Me.Text = "Bitte Institut wählen ..."
Me.ResumeLayout(False)

End Sub
#End Region

  Public Sub New()
    InitializeComponent()
  End Sub

  Private Sub onCancelButtonClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles formCancelButton.Click

    Me.DialogResult = Windows.Forms.DialogResult.Cancel
  End Sub

  Private Sub onOKButtonClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles formOKButton.Click

    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

  Private Sub onFormLoad _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles MyBase.Load

    If ValueGroupsComboBox.Items.Count > 0 Then
      ValueGroupsComboBox.SelectedIndex = 0
    End If
  End Sub

  Private _ValueGroup() As String

  Public Property ValueGroups() As String()
  Get
    Return _ValueGroup
  End Get
  Set(ByVal value As String())
    _ValueGroup = value
    ValueGroupsComboBox.Items.Clear()
    ValueGroupsComboBox.Items.AddRange(_ValueGroup)
  End Set
  End Property

  Public ReadOnly Property ValueGroup() As String
  Get
    Return ValueGroupsComboBox.Text
  End Get
  End Property
End Class
