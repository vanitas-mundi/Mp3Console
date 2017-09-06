Option Explicit On
Option Infer On
Option Strict On

Namespace Windows.Forms

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class EasyLabelControl
			Inherits System.Windows.Forms.UserControl

			'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
			<System.Diagnostics.DebuggerNonUserCode()> _
			Protected Overrides Sub Dispose(ByVal disposing As Boolean)
					Try
							If disposing AndAlso components IsNot Nothing Then
									components.Dispose()
							End If
					Finally
							MyBase.Dispose(disposing)
					End Try
			End Sub

			'Wird vom Windows Form-Designer benötigt.
			Private components As System.ComponentModel.IContainer

			'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
			'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
			'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
			<System.Diagnostics.DebuggerStepThrough()> _
			Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.titleLabel = New System.Windows.Forms.Label()
		Me.editorTextBox = New System.Windows.Forms.TextBox()
		Me.closePanel = New System.Windows.Forms.Panel()
		Me.copiesNumericUpDown = New System.Windows.Forms.NumericUpDown()
		Me.mainToolTip = New System.Windows.Forms.ToolTip(Me.components)
		CType(Me.copiesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'titleLabel
		'
		Me.titleLabel.Dock = System.Windows.Forms.DockStyle.Top
		Me.titleLabel.ForeColor = System.Drawing.Color.White
		Me.titleLabel.Location = New System.Drawing.Point(0, 0)
		Me.titleLabel.Name = "titleLabel"
		Me.titleLabel.Size = New System.Drawing.Size(293, 20)
		Me.titleLabel.TabIndex = 1
		Me.titleLabel.Text = "Title"
		Me.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'editorTextBox
		'
		Me.editorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.editorTextBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.editorTextBox.Location = New System.Drawing.Point(0, 20)
		Me.editorTextBox.Multiline = True
		Me.editorTextBox.Name = "editorTextBox"
		Me.editorTextBox.Size = New System.Drawing.Size(293, 141)
		Me.editorTextBox.TabIndex = 0
		'
		'closePanel
		'
		Me.closePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.closePanel.BackgroundImage = Global.SSP.EasyLabel.My.Resources.Resources.cross12x12
		Me.closePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.closePanel.Location = New System.Drawing.Point(278, 3)
		Me.closePanel.Name = "closePanel"
		Me.closePanel.Size = New System.Drawing.Size(12, 12)
		Me.closePanel.TabIndex = 3
		'
		'copiesNumericUpDown
		'
		Me.copiesNumericUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.copiesNumericUpDown.AutoSize = True
		Me.copiesNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.copiesNumericUpDown.Location = New System.Drawing.Point(229, 1)
		Me.copiesNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.copiesNumericUpDown.Name = "copiesNumericUpDown"
		Me.copiesNumericUpDown.Size = New System.Drawing.Size(41, 16)
		Me.copiesNumericUpDown.TabIndex = 2
		Me.copiesNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'mainToolTip
		'
		Me.mainToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.mainToolTip.UseAnimation = False
		Me.mainToolTip.UseFading = False
		'
		'EasyLabelControl
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.SteelBlue
		Me.Controls.Add(Me.copiesNumericUpDown)
		Me.Controls.Add(Me.closePanel)
		Me.Controls.Add(Me.editorTextBox)
		Me.Controls.Add(Me.titleLabel)
		Me.Name = "EasyLabelControl"
		Me.Size = New System.Drawing.Size(293, 161)
		CType(Me.copiesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

End Sub
			Private WithEvents titleLabel As System.Windows.Forms.Label
			Private WithEvents editorTextBox As System.Windows.Forms.TextBox
		Private WithEvents closePanel As System.Windows.Forms.Panel
	 Private WithEvents copiesNumericUpDown As System.Windows.Forms.NumericUpDown
	 Private WithEvents mainToolTip As System.Windows.Forms.ToolTip

	End Class

End Namespace
