Option Explicit On 
Option Strict On
Option Infer On

Namespace WebBrain.Windows.Forms

Public Class MainDialog

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
  Private WithEvents mainPropertyGrid As System.Windows.Forms.PropertyGrid
  Private WithEvents mainSplitContainer As System.Windows.Forms.SplitContainer
  Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
  Private WithEvents mainStatusStrip As System.Windows.Forms.StatusStrip
  Private WithEvents mainTreeView As System.Windows.Forms.TreeView
  Private WithEvents newToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents deleteToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents refreshToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents openURLToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents mainPasswordStrengthViewer As BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
  Private WithEvents sep1ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
  Private WithEvents sep2ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
  Private WithEvents hideViewToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents initializeWebMembersToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents sep3ToolStripSeparator As System.Windows.Forms.ToolStripSeparator
  ' Für Windows Form-Designer erforderlich
  Private components As System.ComponentModel.IContainer

  'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
  'Sie kann mit dem Windows Form-Designer modifiziert werden.
  'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDialog))
Me.mainPropertyGrid = New System.Windows.Forms.PropertyGrid
Me.mainSplitContainer = New System.Windows.Forms.SplitContainer
Me.mainTreeView = New System.Windows.Forms.TreeView
Me.mainPasswordStrengthViewer = New BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Me.mainToolStrip = New System.Windows.Forms.ToolStrip
Me.sep1ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
Me.sep2ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
Me.mainStatusStrip = New System.Windows.Forms.StatusStrip
Me.sep3ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
Me.initializeWebMembersToolStripButton = New System.Windows.Forms.ToolStripButton
Me.hideViewToolStripButton = New System.Windows.Forms.ToolStripButton
Me.refreshToolStripButton = New System.Windows.Forms.ToolStripButton
Me.newToolStripButton = New System.Windows.Forms.ToolStripButton
Me.deleteToolStripButton = New System.Windows.Forms.ToolStripButton
Me.openURLToolStripButton = New System.Windows.Forms.ToolStripButton
Me.mainSplitContainer.Panel1.SuspendLayout()
Me.mainSplitContainer.Panel2.SuspendLayout()
Me.mainSplitContainer.SuspendLayout()
Me.mainToolStrip.SuspendLayout()
Me.SuspendLayout()
'
'mainPropertyGrid
'
Me.mainPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainPropertyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainPropertyGrid.HelpVisible = False
Me.mainPropertyGrid.Location = New System.Drawing.Point(0, 0)
Me.mainPropertyGrid.Name = "mainPropertyGrid"
Me.mainPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
Me.mainPropertyGrid.Size = New System.Drawing.Size(384, 194)
Me.mainPropertyGrid.TabIndex = 0
Me.mainPropertyGrid.ToolbarVisible = False
'
'mainSplitContainer
'
Me.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.mainSplitContainer.Location = New System.Drawing.Point(0, 25)
Me.mainSplitContainer.Name = "mainSplitContainer"
'
'mainSplitContainer.Panel1
'
Me.mainSplitContainer.Panel1.Controls.Add(Me.mainTreeView)
'
'mainSplitContainer.Panel2
'
Me.mainSplitContainer.Panel2.Controls.Add(Me.mainPropertyGrid)
Me.mainSplitContainer.Panel2.Controls.Add(Me.mainPasswordStrengthViewer)
Me.mainSplitContainer.Panel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainSplitContainer.Size = New System.Drawing.Size(584, 217)
Me.mainSplitContainer.SplitterDistance = 196
Me.mainSplitContainer.TabIndex = 2
'
'mainTreeView
'
Me.mainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainTreeView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainTreeView.HideSelection = False
Me.mainTreeView.Location = New System.Drawing.Point(0, 0)
Me.mainTreeView.Name = "mainTreeView"
Me.mainTreeView.ShowLines = False
Me.mainTreeView.ShowPlusMinus = False
Me.mainTreeView.ShowRootLines = False
Me.mainTreeView.Size = New System.Drawing.Size(196, 217)
Me.mainTreeView.TabIndex = 1
'
'mainPasswordStrengthViewer
'
Me.mainPasswordStrengthViewer.BestPasswordColor = System.Drawing.Color.Green
Me.mainPasswordStrengthViewer.Dock = System.Windows.Forms.DockStyle.Bottom
Me.mainPasswordStrengthViewer.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainPasswordStrengthViewer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
Me.mainPasswordStrengthViewer.Location = New System.Drawing.Point(0, 194)
Me.mainPasswordStrengthViewer.Name = "mainPasswordStrengthViewer"
Me.mainPasswordStrengthViewer.Password = ""
Me.mainPasswordStrengthViewer.PasswordStrength = 0
Me.mainPasswordStrengthViewer.Size = New System.Drawing.Size(384, 23)
Me.mainPasswordStrengthViewer.TabIndex = 1
Me.mainPasswordStrengthViewer.WeakPasswordColor = System.Drawing.Color.Yellow
'
'mainToolStrip
'
Me.mainToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.initializeWebMembersToolStripButton, Me.hideViewToolStripButton, Me.sep3ToolStripSeparator, Me.refreshToolStripButton, Me.sep1ToolStripSeparator, Me.newToolStripButton, Me.deleteToolStripButton, Me.sep2ToolStripSeparator, Me.openURLToolStripButton})
Me.mainToolStrip.Location = New System.Drawing.Point(0, 0)
Me.mainToolStrip.Name = "mainToolStrip"
Me.mainToolStrip.Size = New System.Drawing.Size(584, 25)
Me.mainToolStrip.TabIndex = 0
Me.mainToolStrip.Text = "ToolStrip1"
'
'sep1ToolStripSeparator
'
Me.sep1ToolStripSeparator.Name = "sep1ToolStripSeparator"
Me.sep1ToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'sep2ToolStripSeparator
'
Me.sep2ToolStripSeparator.Name = "sep2ToolStripSeparator"
Me.sep2ToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'mainStatusStrip
'
Me.mainStatusStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.mainStatusStrip.Location = New System.Drawing.Point(0, 242)
Me.mainStatusStrip.Name = "mainStatusStrip"
Me.mainStatusStrip.Size = New System.Drawing.Size(584, 22)
Me.mainStatusStrip.TabIndex = 1
Me.mainStatusStrip.Text = "StatusStrip1"
'
'sep3ToolStripSeparator
'
Me.sep3ToolStripSeparator.Name = "sep3ToolStripSeparator"
Me.sep3ToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'initializeWebMembersToolStripButton
'
Me.initializeWebMembersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.initializeWebMembersToolStripButton.Image = Global.ssp.My.Resources.Resources.key16x16
Me.initializeWebMembersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.initializeWebMembersToolStripButton.Name = "initializeWebMembersToolStripButton"
Me.initializeWebMembersToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.initializeWebMembersToolStripButton.ToolTipText = "Kennwort neu eingeben"
'
'hideViewToolStripButton
'
Me.hideViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.hideViewToolStripButton.Image = Global.ssp.My.Resources.Resources.eye_brown16x16
Me.hideViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.hideViewToolStripButton.Name = "hideViewToolStripButton"
Me.hideViewToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.hideViewToolStripButton.ToolTipText = "Ansicht ausblenden"
'
'refreshToolStripButton
'
Me.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.refreshToolStripButton.Image = Global.ssp.My.Resources.Resources.arrow_refresh
Me.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.refreshToolStripButton.Name = "refreshToolStripButton"
Me.refreshToolStripButton.Size = New System.Drawing.Size(23, 22)
'
'newToolStripButton
'
Me.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.newToolStripButton.Image = Global.ssp.My.Resources.Resources.add
Me.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.newToolStripButton.Name = "newToolStripButton"
Me.newToolStripButton.Size = New System.Drawing.Size(23, 22)
'
'deleteToolStripButton
'
Me.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.deleteToolStripButton.Image = Global.ssp.My.Resources.Resources.delete
Me.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.deleteToolStripButton.Name = "deleteToolStripButton"
Me.deleteToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.deleteToolStripButton.Text = "ToolStripButton2"
'
'openURLToolStripButton
'
Me.openURLToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.openURLToolStripButton.Image = CType(resources.GetObject("openURLToolStripButton.Image"), System.Drawing.Image)
Me.openURLToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.openURLToolStripButton.Name = "openURLToolStripButton"
Me.openURLToolStripButton.Size = New System.Drawing.Size(23, 22)
'
'MainDialog
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
Me.ClientSize = New System.Drawing.Size(584, 264)
Me.Controls.Add(Me.mainSplitContainer)
Me.Controls.Add(Me.mainStatusStrip)
Me.Controls.Add(Me.mainToolStrip)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Name = "MainDialog"
Me.Text = "WebBrain"
Me.mainSplitContainer.Panel1.ResumeLayout(False)
Me.mainSplitContainer.Panel2.ResumeLayout(False)
Me.mainSplitContainer.ResumeLayout(False)
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
  Private _ConnectionString As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
    Public Sub New()
      '{Konstruktor}
      MyBase.New()
      _ConnectionString = BCW.etc.Functions.DecryptString(My.Settings.ConnectionString)
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
  Private Sub onRefreshClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles refreshToolStripButton.Click

    RefreshMembers()
  End Sub

  Private Sub onNewClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles newToolStripButton.Click
    NewMember()
  End Sub

  Private Sub onMainTreeViewAfterSelect _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.TreeViewEventArgs) _
  Handles mainTreeView.AfterSelect

    mainPropertyGrid.Visible = False
    mainPasswordStrengthViewer.Visible = False

    Select Case True
    Case e.Node Is mainTreeView.Nodes.Item(0)
    Case TypeOf e.Node.Tag Is WebBrainMembers
      InsertMembers(e.Node)
    Case Else
      Dim m = DirectCast(e.Node.Tag, WebBrainMember)
      mainPropertyGrid.SelectedObject = m
      mainPasswordStrengthViewer.Password = m.Pwd
      mainPropertyGrid.Visible = True
      mainPasswordStrengthViewer.Visible = True
    End Select

  End Sub

  Private Sub onDeleteClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles deleteToolStripButton.Click

    DeleteMember()
  End Sub

  Private Sub onPropertyGridPropertyValueChanged _
  (ByVal s As Object _
  , ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) _
  Handles mainPropertyGrid.PropertyValueChanged

    Select Case e.ChangedItem.Label
    Case "Displayname"
      mainTreeView.SelectedNode.Text = e.ChangedItem.Value.ToString
    Case "Pwd"
      mainPasswordStrengthViewer.Password = e.ChangedItem.Value.ToString
    End Select
  End Sub

  Private Sub onOpenURLClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles openURLToolStripButton.Click

    OpenURL()
  End Sub

  Private Sub onDialogLoad _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles Me.Load

    InitializeWebMembers()
  End Sub

  Private Sub onInitializeWebMembersClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) Handles initializeWebMembersToolStripButton.Click


    InitializeWebMembers()
  End Sub

  Private Sub onHideViewClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles hideViewToolStripButton.Click

    mainPropertyGrid.Visible = False
    mainPasswordStrengthViewer.Visible = False
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub InitializeWebMembers()
    Dim encodeString = ""
    Dim ip = New BCW.SelectEntry.Windows.Forms.InputBox(Of String)
    ip.PasswordChar = "*"c

    Select Case ip.ShowDialog("Bitte Kennwort eingeben:", "Kennwort")
    Case System.Windows.Forms.DialogResult.Cancel
      Exit Sub
    End Select

    encodeString = ip.Value

    ssp.WebBrain.WebBrainMember.EncodeString = encodeString
    ssp.WebBrain.WebBrainMembers.EncodeString = encodeString
    RefreshMembers()
  End Sub

  Private Sub RefreshMembers()
    Dim members As New ssp.WebBrain.WebBrainMembers _
    (_ConnectionString)

    mainTreeView.Nodes.Clear()
    mainTreeView.Nodes.Add("-- New --")

    For Each item In members.GetGroupNames
      Dim n = mainTreeView.Nodes.Add(item)
      n.Tag = members
    Next item
  End Sub

  Private Sub InsertMembers(ByVal parentNode As TreeNode)
    If parentNode.Nodes.Count > 0 Then Exit Sub

    Dim members = DirectCast(parentNode.Tag, WebBrainMembers)
    Dim groupName = parentNode.Text
    members.FillByGroupName(groupName)

    For Each m As WebBrainMember In members
      InsertMember(parentNode, m)
    Next m
  End Sub

  Private Function InsertMember _
  (ByVal parentNode As TreeNode _
  , ByVal m As ssp.WebBrain.WebBrainMember) As TreeNode

    Dim n As New TreeNode
    n.Text = m.ToString
    n.Tag = m
    parentNode.Nodes.Add(n)
    Return n
  End Function

  Private Sub DeleteMember()
    If mainTreeView.SelectedNode Is Nothing Then Exit Sub
    If Not TypeOf mainTreeView.SelectedNode.Tag Is WebBrainMember Then Exit Sub

    Select Case MessageBox.Show _
    ("Wirklich löschen?", "Löschen" _
    , MessageBoxButtons.YesNo _
    , MessageBoxIcon.Question)
    Case System.Windows.Forms.DialogResult.Yes
      DirectCast(mainTreeView.SelectedNode.Tag _
      , ssp.WebBrain.WebBrainMember).Delete()
      mainTreeView.SelectedNode.Remove()
    End Select
  End Sub

  Private Sub NewMember()
    If mainTreeView.Nodes.Count = 0 Then Exit Sub

    Dim m As New ssp.WebBrain.WebBrainMember(_ConnectionString, 0)
    m.Displayname = "Neuer Eintrag"
    mainTreeView.SelectedNode = InsertMember(mainTreeView.Nodes.Item(0), m)
    mainTreeView.SelectedNode.EnsureVisible()
  End Sub

  Private Sub OpenURL()
    If mainTreeView.SelectedNode Is Nothing Then Exit Sub

    Process.Start(DirectCast(mainTreeView.SelectedNode.Tag _
    , ssp.WebBrain.WebBrainMember).Url)
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse MainDialog}
End Namespace
