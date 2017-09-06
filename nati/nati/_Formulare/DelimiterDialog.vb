Public Class DelimiterDialog

  Inherits Form

#Region " ---------- Vom Designer erstellter Code --------- "
  Private WithEvents formOKButton As System.Windows.Forms.Button
  Private WithEvents formCancelButton As System.Windows.Forms.Button
  Private WithEvents delimiterComboBox As System.Windows.Forms.ComboBox

  Private Sub InitializeComponent()
Me.formOKButton = New System.Windows.Forms.Button
Me.delimiterComboBox = New System.Windows.Forms.ComboBox
Me.formCancelButton = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'formOKButton
'
Me.formOKButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.formOKButton.Location = New System.Drawing.Point(132, 7)
Me.formOKButton.Name = "formOKButton"
Me.formOKButton.Size = New System.Drawing.Size(70, 28)
Me.formOKButton.TabIndex = 1
Me.formOKButton.Text = "OK"
Me.formOKButton.UseVisualStyleBackColor = True
'
'delimiterComboBox
'
Me.delimiterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.delimiterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me.delimiterComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.delimiterComboBox.FormattingEnabled = True
Me.delimiterComboBox.Items.AddRange(New Object() {"Tabulator", ",", ";", ":"})
Me.delimiterComboBox.Location = New System.Drawing.Point(4, 8)
Me.delimiterComboBox.Name = "delimiterComboBox"
Me.delimiterComboBox.Size = New System.Drawing.Size(122, 21)
Me.delimiterComboBox.TabIndex = 0
'
'formCancelButton
'
Me.formCancelButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.formCancelButton.Location = New System.Drawing.Point(132, 38)
Me.formCancelButton.Name = "formCancelButton"
Me.formCancelButton.Size = New System.Drawing.Size(70, 28)
Me.formCancelButton.TabIndex = 2
Me.formCancelButton.Text = "Abbrechen"
Me.formCancelButton.UseVisualStyleBackColor = True
'
'DelimiterDialog
'
Me.ClientSize = New System.Drawing.Size(206, 71)
Me.Controls.Add(Me.formCancelButton)
Me.Controls.Add(Me.delimiterComboBox)
Me.Controls.Add(Me.formOKButton)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.Name = "DelimiterDialog"
Me.Text = "Bitte Trennzeichen wählen ..."
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

    delimiterComboBox.SelectedIndex = 0
  End Sub

  Public ReadOnly Property Delimiter() As Char
  Get
    Select Case delimiterComboBox.Text
    Case "Tabulator"
      Return CType(vbTab, Char)
    Case Else
      Return CType(delimiterComboBox.Text, Char)
    End Select
  End Get
  End Property
End Class
