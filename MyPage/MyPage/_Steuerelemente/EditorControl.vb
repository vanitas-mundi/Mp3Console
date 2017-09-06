Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class EditorControl

Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents zoom400PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoom300PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoom200PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoom150PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoom100PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoom50PercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents zoomToolStripSplitButton As System.Windows.Forms.ToolStripSplitButton
Friend WithEvents commandsToolStrip As System.Windows.Forms.ToolStrip
Private WithEvents editorRichTextBox As System.Windows.Forms.RichTextBox
Private WithEvents undoToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents redoToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents firstToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.commandsToolStrip = New System.Windows.Forms.ToolStrip()
Me.zoomToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
Me.zoom50PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.zoom100PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.zoom150PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.zoom200PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.zoom300PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.zoom400PercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.firstToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
Me.undoToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.redoToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.editorRichTextBox = New System.Windows.Forms.RichTextBox()
Me.commandsToolStrip.SuspendLayout()
Me.SuspendLayout()
'
'commandsToolStrip
'
Me.commandsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.commandsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.zoomToolStripSplitButton, Me.firstToolStripSeparator, Me.undoToolStripButton, Me.redoToolStripButton})
Me.commandsToolStrip.Location = New System.Drawing.Point(4, 4)
Me.commandsToolStrip.Name = "commandsToolStrip"
Me.commandsToolStrip.Size = New System.Drawing.Size(284, 25)
Me.commandsToolStrip.TabIndex = 9
'
'zoomToolStripSplitButton
'
Me.zoomToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.zoomToolStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.zoom50PercentToolStripMenuItem, Me.zoom100PercentToolStripMenuItem, Me.zoom150PercentToolStripMenuItem, Me.zoom200PercentToolStripMenuItem, Me.zoom300PercentToolStripMenuItem, Me.zoom400PercentToolStripMenuItem})
Me.zoomToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.zoomToolStripSplitButton.Name = "zoomToolStripSplitButton"
Me.zoomToolStripSplitButton.Size = New System.Drawing.Size(51, 22)
Me.zoomToolStripSplitButton.Text = "100%"
'
'zoom50PercentToolStripMenuItem
'
Me.zoom50PercentToolStripMenuItem.Name = "zoom50PercentToolStripMenuItem"
Me.zoom50PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom50PercentToolStripMenuItem.Text = "50%"
'
'zoom100PercentToolStripMenuItem
'
Me.zoom100PercentToolStripMenuItem.Name = "zoom100PercentToolStripMenuItem"
Me.zoom100PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom100PercentToolStripMenuItem.Text = "100%"
'
'zoom150PercentToolStripMenuItem
'
Me.zoom150PercentToolStripMenuItem.Name = "zoom150PercentToolStripMenuItem"
Me.zoom150PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom150PercentToolStripMenuItem.Text = "150%"
'
'zoom200PercentToolStripMenuItem
'
Me.zoom200PercentToolStripMenuItem.Name = "zoom200PercentToolStripMenuItem"
Me.zoom200PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom200PercentToolStripMenuItem.Text = "200%"
'
'zoom300PercentToolStripMenuItem
'
Me.zoom300PercentToolStripMenuItem.Name = "zoom300PercentToolStripMenuItem"
Me.zoom300PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom300PercentToolStripMenuItem.Text = "300%"
'
'zoom400PercentToolStripMenuItem
'
Me.zoom400PercentToolStripMenuItem.Name = "zoom400PercentToolStripMenuItem"
Me.zoom400PercentToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
Me.zoom400PercentToolStripMenuItem.Text = "400%"
'
'firstToolStripSeparator
'
Me.firstToolStripSeparator.Name = "firstToolStripSeparator"
Me.firstToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'undoToolStripButton
'
Me.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.undoToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.undo16x16
Me.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.undoToolStripButton.Name = "undoToolStripButton"
Me.undoToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.undoToolStripButton.ToolTipText = "Rückgängig"
'
'redoToolStripButton
'
Me.redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.redoToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.redo16x16
Me.redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.redoToolStripButton.Name = "redoToolStripButton"
Me.redoToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.redoToolStripButton.ToolTipText = "Wiederholen"
'
'editorRichTextBox
'
Me.editorRichTextBox.AcceptsTab = True
Me.editorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.editorRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
Me.editorRichTextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.editorRichTextBox.HideSelection = False
Me.editorRichTextBox.Location = New System.Drawing.Point(4, 29)
Me.editorRichTextBox.Name = "editorRichTextBox"
Me.editorRichTextBox.Size = New System.Drawing.Size(284, 240)
Me.editorRichTextBox.TabIndex = 10
Me.editorRichTextBox.Text = ""
'
'EditorControl
'
Me.Controls.Add(Me.editorRichTextBox)
Me.Controls.Add(Me.commandsToolStrip)
Me.Name = "EditorControl"
Me.Padding = New System.Windows.Forms.Padding(4)
Me.Size = New System.Drawing.Size(292, 273)
Me.commandsToolStrip.ResumeLayout(False)
Me.commandsToolStrip.PerformLayout()
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
    editorRichTextBox.SelectionTabs = New Integer() _
    {20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300 _
    , 320, 340, 360, 380, 400, 420, 440, 460, 480, 500, 520, 540, 560, 580, 600}

  End Sub

  ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Shadows Property Text As String
  Get
    Return editorRichTextBox.Text
  End Get
  Set(ByVal value As String)
    editorRichTextBox.Text = value
  End Set
  End Property

  Public ReadOnly Property ToolStrip As System.Windows.Forms.ToolStrip
  Get
    Return commandsToolStrip
  End Get
  End Property

  Public ReadOnly Property Editor As System.Windows.Forms.RichTextBox
  Get
    Return editorRichTextBox
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
  Private Sub onUndoClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles undoToolStripButton.Click

    If editorRichTextBox.CanUndo Then editorRichTextBox.Undo()
  End Sub

  Private Sub onRedoClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles redoToolStripButton.Click

    If editorRichTextBox.CanRedo Then editorRichTextBox.Redo()
  End Sub

  Private Sub onZoomItemClicked _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) _
  Handles zoomToolStripSplitButton.DropDownItemClicked

    Select Case True
    Case e.ClickedItem Is zoom50PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 0.5
    Case e.ClickedItem Is zoom100PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 1
    Case e.ClickedItem Is zoom150PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 1.5
    Case e.ClickedItem Is zoom200PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 2
    Case e.ClickedItem Is zoom300PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 3
    Case e.ClickedItem Is zoom400PercentToolStripMenuItem
      editorRichTextBox.ZoomFactor = 4
    End Select
    zoomToolStripSplitButton.Text = e.ClickedItem.Text
  End Sub

#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse EditorControl}
End Namespace
