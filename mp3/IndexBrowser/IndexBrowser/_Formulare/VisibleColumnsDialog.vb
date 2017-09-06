Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class VisibleColumnsDialog

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents visibleColumnsGroupBox As System.Windows.Forms.GroupBox
Private WithEvents durationCheckBox As System.Windows.Forms.CheckBox
Private WithEvents sizeCheckBox As System.Windows.Forms.CheckBox
Private WithEvents bitrateCheckBox As System.Windows.Forms.CheckBox
Private WithEvents albumCheckBox As System.Windows.Forms.CheckBox
Private WithEvents trackCheckBox As System.Windows.Forms.CheckBox
Private WithEvents titleCheckBox As System.Windows.Forms.CheckBox
Private WithEvents yearCheckBox As System.Windows.Forms.CheckBox
Private WithEvents pathCheckBox As System.Windows.Forms.CheckBox
Private WithEvents commentCheckBox As System.Windows.Forms.CheckBox
Private WithEvents nameCheckBox As System.Windows.Forms.CheckBox
Private WithEvents genreCheckBox As System.Windows.Forms.CheckBox
Private WithEvents artistCheckBox As System.Windows.Forms.CheckBox
Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
Private WithEvents okToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents cancelToolStripButton As System.Windows.Forms.ToolStripButton
    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisibleColumnsDialog))
Me.artistCheckBox = New System.Windows.Forms.CheckBox()
Me.genreCheckBox = New System.Windows.Forms.CheckBox()
Me.nameCheckBox = New System.Windows.Forms.CheckBox()
Me.commentCheckBox = New System.Windows.Forms.CheckBox()
Me.pathCheckBox = New System.Windows.Forms.CheckBox()
Me.yearCheckBox = New System.Windows.Forms.CheckBox()
Me.titleCheckBox = New System.Windows.Forms.CheckBox()
Me.trackCheckBox = New System.Windows.Forms.CheckBox()
Me.albumCheckBox = New System.Windows.Forms.CheckBox()
Me.bitrateCheckBox = New System.Windows.Forms.CheckBox()
Me.sizeCheckBox = New System.Windows.Forms.CheckBox()
Me.durationCheckBox = New System.Windows.Forms.CheckBox()
Me.visibleColumnsGroupBox = New System.Windows.Forms.GroupBox()
Me.mainToolStrip = New System.Windows.Forms.ToolStrip()
Me.okToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.cancelToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.visibleColumnsGroupBox.SuspendLayout()
Me.mainToolStrip.SuspendLayout()
Me.SuspendLayout()
'
'artistCheckBox
'
Me.artistCheckBox.AutoSize = True
Me.artistCheckBox.Location = New System.Drawing.Point(15, 19)
Me.artistCheckBox.Name = "artistCheckBox"
Me.artistCheckBox.Size = New System.Drawing.Size(65, 17)
Me.artistCheckBox.TabIndex = 0
Me.artistCheckBox.Text = "Interpret"
Me.artistCheckBox.UseVisualStyleBackColor = True
'
'genreCheckBox
'
Me.genreCheckBox.AutoSize = True
Me.genreCheckBox.Location = New System.Drawing.Point(15, 111)
Me.genreCheckBox.Name = "genreCheckBox"
Me.genreCheckBox.Size = New System.Drawing.Size(55, 17)
Me.genreCheckBox.TabIndex = 1
Me.genreCheckBox.Text = "Genre"
Me.genreCheckBox.UseVisualStyleBackColor = True
'
'nameCheckBox
'
Me.nameCheckBox.AutoSize = True
Me.nameCheckBox.Location = New System.Drawing.Point(121, 134)
Me.nameCheckBox.Name = "nameCheckBox"
Me.nameCheckBox.Size = New System.Drawing.Size(77, 17)
Me.nameCheckBox.TabIndex = 2
Me.nameCheckBox.Text = "Dateiname"
Me.nameCheckBox.UseVisualStyleBackColor = True
'
'commentCheckBox
'
Me.commentCheckBox.AutoSize = True
Me.commentCheckBox.Location = New System.Drawing.Point(121, 42)
Me.commentCheckBox.Name = "commentCheckBox"
Me.commentCheckBox.Size = New System.Drawing.Size(79, 17)
Me.commentCheckBox.TabIndex = 3
Me.commentCheckBox.Text = "Kommentar"
Me.commentCheckBox.UseVisualStyleBackColor = True
'
'pathCheckBox
'
Me.pathCheckBox.AutoSize = True
Me.pathCheckBox.Location = New System.Drawing.Point(121, 111)
Me.pathCheckBox.Name = "pathCheckBox"
Me.pathCheckBox.Size = New System.Drawing.Size(80, 17)
Me.pathCheckBox.TabIndex = 4
Me.pathCheckBox.Text = "Verzeichnis"
Me.pathCheckBox.UseVisualStyleBackColor = True
'
'yearCheckBox
'
Me.yearCheckBox.AutoSize = True
Me.yearCheckBox.Location = New System.Drawing.Point(15, 134)
Me.yearCheckBox.Name = "yearCheckBox"
Me.yearCheckBox.Size = New System.Drawing.Size(46, 17)
Me.yearCheckBox.TabIndex = 5
Me.yearCheckBox.Text = "Jahr"
Me.yearCheckBox.UseVisualStyleBackColor = True
'
'titleCheckBox
'
Me.titleCheckBox.AutoSize = True
Me.titleCheckBox.Location = New System.Drawing.Point(15, 88)
Me.titleCheckBox.Name = "titleCheckBox"
Me.titleCheckBox.Size = New System.Drawing.Size(46, 17)
Me.titleCheckBox.TabIndex = 6
Me.titleCheckBox.Text = "Titel"
Me.titleCheckBox.UseVisualStyleBackColor = True
'
'trackCheckBox
'
Me.trackCheckBox.AutoSize = True
Me.trackCheckBox.Location = New System.Drawing.Point(15, 65)
Me.trackCheckBox.Name = "trackCheckBox"
Me.trackCheckBox.Size = New System.Drawing.Size(54, 17)
Me.trackCheckBox.TabIndex = 7
Me.trackCheckBox.Text = "Track"
Me.trackCheckBox.UseVisualStyleBackColor = True
'
'albumCheckBox
'
Me.albumCheckBox.AutoSize = True
Me.albumCheckBox.Location = New System.Drawing.Point(15, 42)
Me.albumCheckBox.Name = "albumCheckBox"
Me.albumCheckBox.Size = New System.Drawing.Size(55, 17)
Me.albumCheckBox.TabIndex = 8
Me.albumCheckBox.Text = "Album"
Me.albumCheckBox.UseVisualStyleBackColor = True
'
'bitrateCheckBox
'
Me.bitrateCheckBox.AutoSize = True
Me.bitrateCheckBox.Location = New System.Drawing.Point(121, 88)
Me.bitrateCheckBox.Name = "bitrateCheckBox"
Me.bitrateCheckBox.Size = New System.Drawing.Size(56, 17)
Me.bitrateCheckBox.TabIndex = 9
Me.bitrateCheckBox.Text = "Bitrate"
Me.bitrateCheckBox.UseVisualStyleBackColor = True
'
'sizeCheckBox
'
Me.sizeCheckBox.AutoSize = True
Me.sizeCheckBox.Location = New System.Drawing.Point(121, 65)
Me.sizeCheckBox.Name = "sizeCheckBox"
Me.sizeCheckBox.Size = New System.Drawing.Size(55, 17)
Me.sizeCheckBox.TabIndex = 10
Me.sizeCheckBox.Text = "Größe"
Me.sizeCheckBox.UseVisualStyleBackColor = True
'
'durationCheckBox
'
Me.durationCheckBox.AutoSize = True
Me.durationCheckBox.Location = New System.Drawing.Point(121, 19)
Me.durationCheckBox.Name = "durationCheckBox"
Me.durationCheckBox.Size = New System.Drawing.Size(75, 17)
Me.durationCheckBox.TabIndex = 11
Me.durationCheckBox.Text = "Spiellänge"
Me.durationCheckBox.UseVisualStyleBackColor = True
'
'visibleColumnsGroupBox
'
Me.visibleColumnsGroupBox.Controls.Add(Me.artistCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.durationCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.sizeCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.genreCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.bitrateCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.yearCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.pathCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.titleCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.commentCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.albumCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.nameCheckBox)
Me.visibleColumnsGroupBox.Controls.Add(Me.trackCheckBox)
Me.visibleColumnsGroupBox.Location = New System.Drawing.Point(3, 2)
Me.visibleColumnsGroupBox.Name = "visibleColumnsGroupBox"
Me.visibleColumnsGroupBox.Size = New System.Drawing.Size(219, 163)
Me.visibleColumnsGroupBox.TabIndex = 12
Me.visibleColumnsGroupBox.TabStop = False
'
'mainToolStrip
'
Me.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.okToolStripButton, Me.cancelToolStripButton})
Me.mainToolStrip.Location = New System.Drawing.Point(0, 173)
Me.mainToolStrip.Name = "mainToolStrip"
Me.mainToolStrip.Size = New System.Drawing.Size(227, 25)
Me.mainToolStrip.TabIndex = 13
Me.mainToolStrip.Text = "ToolStrip1"
'
'okToolStripButton
'
Me.okToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
Me.okToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.okToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.okToolStripButton.Name = "okToolStripButton"
Me.okToolStripButton.Size = New System.Drawing.Size(27, 22)
Me.okToolStripButton.Text = "OK"
Me.okToolStripButton.ToolTipText = "Index laden"
'
'cancelToolStripButton
'
Me.cancelToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
Me.cancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.cancelToolStripButton.Image = CType(resources.GetObject("cancelToolStripButton.Image"), System.Drawing.Image)
Me.cancelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.cancelToolStripButton.Name = "cancelToolStripButton"
Me.cancelToolStripButton.Size = New System.Drawing.Size(69, 22)
Me.cancelToolStripButton.Text = "Abbrechen"
'
'VisibleColumnsDialog
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(227, 198)
Me.Controls.Add(Me.mainToolStrip)
Me.Controls.Add(Me.visibleColumnsGroupBox)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.Name = "VisibleColumnsDialog"
Me.ShowInTaskbar = False
Me.Text = "Sichtbare Spalten"
Me.visibleColumnsGroupBox.ResumeLayout(False)
Me.visibleColumnsGroupBox.PerformLayout()
Me.mainToolStrip.ResumeLayout(False)
Me.mainToolStrip.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
    '{Konstruktor}
    MyBase.New()
    InitializeComponent()
  End Sub

  ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  Protected Overrides Sub Finalize()
    '{Destruktor}
    MyBase.Finalize()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
  Private Sub onDialogLoad _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) Handles Me.Load

    LoadVisibleColumns()
  End Sub

  Private Sub onOkClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles okToolStripButton.Click

    SaveVisibleColumns()
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
  End Sub

  Private Sub onCancelClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles cancelToolStripButton.Click

    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub LoadVisibleColumns()
    artistCheckBox.Checked = My.Settings.artistColumnVisible
    albumCheckBox.Checked = My.Settings.albumColumnVisible
    trackCheckBox.Checked = My.Settings.trackColumnVisible
    titleCheckBox.Checked = My.Settings.titleColumnVisible
    genreCheckBox.Checked = My.Settings.genreColumnVisible
    yearCheckBox.Checked = My.Settings.yearColumnVisible
    durationCheckBox.Checked = My.Settings.durationColumnVisible
    commentCheckBox.Checked = My.Settings.commentColumnVisible
    sizeCheckBox.Checked = My.Settings.sizeColumnVisible
    bitrateCheckBox.Checked = My.Settings.bitrateColumnVisible
    pathCheckBox.Checked = My.Settings.pathColumnVisible
    nameCheckBox.Checked = My.Settings.nameColumnVisible
  End Sub

  Private Sub SaveVisibleColumns()
    My.Settings.artistColumnVisible = artistCheckBox.Checked
    My.Settings.albumColumnVisible = albumCheckBox.Checked
    My.Settings.trackColumnVisible = trackCheckBox.Checked
    My.Settings.titleColumnVisible = titleCheckBox.Checked
    My.Settings.genreColumnVisible = genreCheckBox.Checked
    My.Settings.yearColumnVisible = yearCheckBox.Checked
    My.Settings.durationColumnVisible = durationCheckBox.Checked
    My.Settings.commentColumnVisible = commentCheckBox.Checked
    My.Settings.sizeColumnVisible = sizeCheckBox.Checked
    My.Settings.bitrateColumnVisible = bitrateCheckBox.Checked
    My.Settings.pathColumnVisible = pathCheckBox.Checked
    My.Settings.nameColumnVisible = nameCheckBox.Checked
    My.Settings.Save()
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse VisibleColumnsDialog}

End Namespace
