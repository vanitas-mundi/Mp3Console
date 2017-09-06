
Namespace Windows.Forms


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EasyLabelDialog
	Inherits System.Windows.Forms.Form

	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EasyLabelDialog))
		Me.labelsPanel = New System.Windows.Forms.Panel()
		Me.mainToolStrip = New System.Windows.Forms.ToolStrip()
		Me.loadLabelsToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.saveLabelsToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.ioToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.addLabelToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.printLabelsToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.selectedPrinterToolStripLabel = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.selectPrinterToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.setPageSettingsToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.selectLabelFormatToolStripButton = New System.Windows.Forms.ToolStripButton()
		Me.mainStatusStrip = New System.Windows.Forms.StatusStrip()
		Me.mainToolStrip.SuspendLayout()
		Me.SuspendLayout()
		'
		'labelsPanel
		'
		Me.labelsPanel.AutoScroll = True
		Me.labelsPanel.AutoSize = True
		Me.labelsPanel.BackColor = System.Drawing.Color.LightSteelBlue
		Me.labelsPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.labelsPanel.Location = New System.Drawing.Point(0, 25)
		Me.labelsPanel.Name = "labelsPanel"
		Me.labelsPanel.Size = New System.Drawing.Size(659, 326)
		Me.labelsPanel.TabIndex = 3
		'
		'mainToolStrip
		'
		Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadLabelsToolStripButton, Me.saveLabelsToolStripButton, Me.ioToolStripSeparator, Me.addLabelToolStripButton, Me.printLabelsToolStripButton, Me.selectedPrinterToolStripLabel, Me.ToolStripSeparator1, Me.selectPrinterToolStripButton, Me.setPageSettingsToolStripButton, Me.selectLabelFormatToolStripButton})
		Me.mainToolStrip.Location = New System.Drawing.Point(0, 0)
		Me.mainToolStrip.Name = "mainToolStrip"
		Me.mainToolStrip.Size = New System.Drawing.Size(659, 25)
		Me.mainToolStrip.TabIndex = 4
		Me.mainToolStrip.Text = "ToolStrip1"
		'
		'loadLabelsToolStripButton
		'
		Me.loadLabelsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.loadLabelsToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.open16x16
		Me.loadLabelsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.loadLabelsToolStripButton.Name = "loadLabelsToolStripButton"
		Me.loadLabelsToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.loadLabelsToolStripButton.ToolTipText = "Etiketten laden"
		'
		'saveLabelsToolStripButton
		'
		Me.saveLabelsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.saveLabelsToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.save16x16
		Me.saveLabelsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.saveLabelsToolStripButton.Name = "saveLabelsToolStripButton"
		Me.saveLabelsToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.saveLabelsToolStripButton.ToolTipText = "Etikettenansicht speichern"
		'
		'ioToolStripSeparator
		'
		Me.ioToolStripSeparator.Name = "ioToolStripSeparator"
		Me.ioToolStripSeparator.Size = New System.Drawing.Size(6, 25)
		'
		'addLabelToolStripButton
		'
		Me.addLabelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.addLabelToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.add16x16
		Me.addLabelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.addLabelToolStripButton.Name = "addLabelToolStripButton"
		Me.addLabelToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.addLabelToolStripButton.ToolTipText = "Etikett hinzufügen"
		'
		'printLabelsToolStripButton
		'
		Me.printLabelsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.printLabelsToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.print_preview16x16
		Me.printLabelsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.printLabelsToolStripButton.Name = "printLabelsToolStripButton"
		Me.printLabelsToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.printLabelsToolStripButton.ToolTipText = "Etiketten drucken mit Vorschau"
		'
		'selectedPrinterToolStripLabel
		'
		Me.selectedPrinterToolStripLabel.Name = "selectedPrinterToolStripLabel"
		Me.selectedPrinterToolStripLabel.Size = New System.Drawing.Size(86, 22)
		Me.selectedPrinterToolStripLabel.Text = "SelectedPrinter"
		Me.selectedPrinterToolStripLabel.ToolTipText = "Drucker für Druckausgabe"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'selectPrinterToolStripButton
		'
		Me.selectPrinterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.selectPrinterToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.printer_modern16x16
		Me.selectPrinterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.selectPrinterToolStripButton.Name = "selectPrinterToolStripButton"
		Me.selectPrinterToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.selectPrinterToolStripButton.ToolTipText = "Ausgabedrucker wählen"
		'
		'setPageSettingsToolStripButton
		'
		Me.setPageSettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.setPageSettingsToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.page_settings16x16
		Me.setPageSettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.setPageSettingsToolStripButton.Name = "setPageSettingsToolStripButton"
		Me.setPageSettingsToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.setPageSettingsToolStripButton.ToolTipText = "Seitenformat festlegen"
		'
		'selectLabelFormatToolStripButton
		'
		Me.selectLabelFormatToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.selectLabelFormatToolStripButton.Image = Global.SSP.EasyLabel.My.Resources.Resources.label_format16x16
		Me.selectLabelFormatToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.selectLabelFormatToolStripButton.Name = "selectLabelFormatToolStripButton"
		Me.selectLabelFormatToolStripButton.Size = New System.Drawing.Size(23, 22)
		Me.selectLabelFormatToolStripButton.ToolTipText = "Etikettenformat festlegen"
		'
		'mainStatusStrip
		'
		Me.mainStatusStrip.Location = New System.Drawing.Point(0, 351)
		Me.mainStatusStrip.Name = "mainStatusStrip"
		Me.mainStatusStrip.Size = New System.Drawing.Size(659, 22)
		Me.mainStatusStrip.TabIndex = 5
		Me.mainStatusStrip.Text = "StatusStrip1"
		'
		'EasyLabelDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(659, 373)
		Me.Controls.Add(Me.labelsPanel)
		Me.Controls.Add(Me.mainStatusStrip)
		Me.Controls.Add(Me.mainToolStrip)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "EasyLabelDialog"
		Me.Text = "EasyLabel"
		Me.mainToolStrip.ResumeLayout(False)
		Me.mainToolStrip.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

End Sub

Friend WithEvents labelsPanel As System.Windows.Forms.Panel
Friend WithEvents addLabelToolStripButton As System.Windows.Forms.ToolStripButton
Friend WithEvents printLabelsToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents saveLabelsToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents ioToolStripSeparator As System.Windows.Forms.ToolStripSeparator
Private WithEvents loadLabelsToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
Private WithEvents mainStatusStrip As System.Windows.Forms.StatusStrip
Private WithEvents selectedPrinterToolStripLabel As System.Windows.Forms.ToolStripLabel
Private WithEvents selectPrinterToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents selectLabelFormatToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents setPageSettingsToolStripButton As System.Windows.Forms.ToolStripButton
Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class



End Namespace
