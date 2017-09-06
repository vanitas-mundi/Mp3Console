Option Explicit On 
Option Strict On
Option Infer On

            Imports System.Net.Mail

Namespace Windows.Forms

Public Class MainDialog

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
  Private WithEvents titlePanel As System.Windows.Forms.Panel
  Private WithEvents charactersComboBox As System.Windows.Forms.ComboBox
  Private WithEvents questsDataGridView As System.Windows.Forms.DataGridView
  Private WithEvents ViewerTabControl As Crownwood.Magic.Controls.TabControl
  Private WithEvents questsTabPage As Crownwood.Magic.Controls.TabPage
  Private WithEvents fractionsTabPage As Crownwood.Magic.Controls.TabPage
  Private WithEvents levelFilterPicker As SSP.Windows.Forms.FilterPicker
  Private WithEvents filterToolStrip As System.Windows.Forms.ToolStrip
  Private WithEvents levelToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents groupMembersToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents fractionToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents difficultyToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents fameToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents fameFilterPicker As SSP.Windows.Forms.FilterPicker
  Private WithEvents difficultyFilterPicker As SSP.Windows.Forms.FilterPicker
  Private WithEvents fractionFilterPicker As SSP.Windows.Forms.FilterPicker
  Private WithEvents groupMembersFilterPicker As SSP.Windows.Forms.FilterPicker
  Private WithEvents filterLabel As System.Windows.Forms.Label
  Private WithEvents mainStatusStrip As System.Windows.Forms.StatusStrip
  Private WithEvents countToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
  Private WithEvents fameToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
  Private WithEvents logInButton As System.Windows.Forms.Button
  Private WithEvents passwordTextBox As System.Windows.Forms.TextBox
  Private WithEvents logOutLinkLabel As System.Windows.Forms.LinkLabel
  Private WithEvents userComboBox As System.Windows.Forms.ComboBox
  Private WithEvents fractionFameDataGridView As System.Windows.Forms.DataGridView
  Private WithEvents fractionFameFractionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Private WithEvents fractionFameFameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Private WithEvents mainContextMenuStrip As System.Windows.Forms.ContextMenuStrip
  Private WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents mainFormMenuStrip As System.Windows.Forms.MenuStrip
  Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents endToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents extrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents changePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents characterPropertyGrid As System.Windows.Forms.PropertyGrid
  Friend WithEvents charactersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents newCharacterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents deleteCharaterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mainSplitContainer As System.Windows.Forms.SplitContainer
  Private WithEvents characterTabControl As Crownwood.Magic.Controls.TabControl
  Friend WithEvents characterTabPage As Crownwood.Magic.Controls.TabPage
  Friend WithEvents vaultTabPage As Crownwood.Magic.Controls.TabPage
  Friend WithEvents characterSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents characterCommentGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents characterCommentTextBox As System.Windows.Forms.TextBox
  Friend WithEvents vaultTreeView As System.Windows.Forms.TreeView
  Friend WithEvents vaultSplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents vaultCommentGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents vaultCommentTextBox As System.Windows.Forms.TextBox
  Private WithEvents requestAccountButton As System.Windows.Forms.Button
  Friend WithEvents questIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents questNameEnglishColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents questNameGermanColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents levelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents groupMembersColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fractionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents difficultyComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents fameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fameDifficultyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents urlColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents showUrlColumn As System.Windows.Forms.DataGridViewButtonColumn


' Für Windows Form-Designer erforderlich
  Private components As System.ComponentModel.IContainer

  'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
  'Sie kann mit dem Windows Form-Designer modifiziert werden.
  'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container()
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDialog))
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.titlePanel = New System.Windows.Forms.Panel()
Me.requestAccountButton = New System.Windows.Forms.Button()
Me.logInButton = New System.Windows.Forms.Button()
Me.passwordTextBox = New System.Windows.Forms.TextBox()
Me.logOutLinkLabel = New System.Windows.Forms.LinkLabel()
Me.userComboBox = New System.Windows.Forms.ComboBox()
Me.charactersComboBox = New System.Windows.Forms.ComboBox()
Me.questsDataGridView = New System.Windows.Forms.DataGridView()
Me.mainContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.ViewerTabControl = New Crownwood.Magic.Controls.TabControl()
Me.questsTabPage = New Crownwood.Magic.Controls.TabPage()
Me.filterToolStrip = New System.Windows.Forms.ToolStrip()
Me.levelToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.groupMembersToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.fractionToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.difficultyToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.fameToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.filterLabel = New System.Windows.Forms.Label()
Me.fractionsTabPage = New Crownwood.Magic.Controls.TabPage()
Me.fractionFameDataGridView = New System.Windows.Forms.DataGridView()
Me.fractionFameFractionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.fractionFameFameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.characterPropertyGrid = New System.Windows.Forms.PropertyGrid()
Me.mainFormMenuStrip = New System.Windows.Forms.MenuStrip()
Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.endToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.charactersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.newCharacterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.deleteCharaterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.extrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.changePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.mainStatusStrip = New System.Windows.Forms.StatusStrip()
Me.countToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
Me.fameToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
Me.mainSplitContainer = New System.Windows.Forms.SplitContainer()
Me.characterTabControl = New Crownwood.Magic.Controls.TabControl()
Me.characterTabPage = New Crownwood.Magic.Controls.TabPage()
Me.characterSplitContainer = New System.Windows.Forms.SplitContainer()
Me.characterCommentGroupBox = New System.Windows.Forms.GroupBox()
Me.characterCommentTextBox = New System.Windows.Forms.TextBox()
Me.vaultTabPage = New Crownwood.Magic.Controls.TabPage()
Me.vaultSplitContainer = New System.Windows.Forms.SplitContainer()
Me.vaultTreeView = New System.Windows.Forms.TreeView()
Me.vaultCommentGroupBox = New System.Windows.Forms.GroupBox()
Me.vaultCommentTextBox = New System.Windows.Forms.TextBox()
Me.fameFilterPicker = New SSP.Windows.Forms.FilterPicker()
Me.difficultyFilterPicker = New SSP.Windows.Forms.FilterPicker()
Me.fractionFilterPicker = New SSP.Windows.Forms.FilterPicker()
Me.groupMembersFilterPicker = New SSP.Windows.Forms.FilterPicker()
Me.levelFilterPicker = New SSP.Windows.Forms.FilterPicker()
Me.questIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.questNameEnglishColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.questNameGermanColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.levelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.groupMembersColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.fractionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.difficultyComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
Me.fameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.fameDifficultyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.urlColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.showUrlColumn = New System.Windows.Forms.DataGridViewButtonColumn()
Me.titlePanel.SuspendLayout()
CType(Me.questsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.mainContextMenuStrip.SuspendLayout()
Me.questsTabPage.SuspendLayout()
Me.filterToolStrip.SuspendLayout()
Me.fractionsTabPage.SuspendLayout()
CType(Me.fractionFameDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.mainFormMenuStrip.SuspendLayout()
Me.mainStatusStrip.SuspendLayout()
CType(Me.mainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.mainSplitContainer.Panel1.SuspendLayout()
Me.mainSplitContainer.Panel2.SuspendLayout()
Me.mainSplitContainer.SuspendLayout()
Me.characterTabPage.SuspendLayout()
CType(Me.characterSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.characterSplitContainer.Panel1.SuspendLayout()
Me.characterSplitContainer.Panel2.SuspendLayout()
Me.characterSplitContainer.SuspendLayout()
Me.characterCommentGroupBox.SuspendLayout()
Me.vaultTabPage.SuspendLayout()
CType(Me.vaultSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.vaultSplitContainer.Panel1.SuspendLayout()
Me.vaultSplitContainer.Panel2.SuspendLayout()
Me.vaultSplitContainer.SuspendLayout()
Me.vaultCommentGroupBox.SuspendLayout()
Me.SuspendLayout()
'
'titlePanel
'
Me.titlePanel.BackColor = System.Drawing.SystemColors.Control
Me.titlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
Me.titlePanel.Controls.Add(Me.requestAccountButton)
Me.titlePanel.Controls.Add(Me.logInButton)
Me.titlePanel.Controls.Add(Me.passwordTextBox)
Me.titlePanel.Controls.Add(Me.logOutLinkLabel)
Me.titlePanel.Controls.Add(Me.userComboBox)
Me.titlePanel.Controls.Add(Me.charactersComboBox)
Me.titlePanel.Dock = System.Windows.Forms.DockStyle.Top
Me.titlePanel.Location = New System.Drawing.Point(0, 0)
Me.titlePanel.Name = "titlePanel"
Me.titlePanel.Size = New System.Drawing.Size(817, 70)
Me.titlePanel.TabIndex = 0
'
'requestAccountButton
'
Me.requestAccountButton.Location = New System.Drawing.Point(2, 43)
Me.requestAccountButton.Name = "requestAccountButton"
Me.requestAccountButton.Size = New System.Drawing.Size(117, 21)
Me.requestAccountButton.TabIndex = 5
Me.requestAccountButton.Text = "Account anfordern"
Me.requestAccountButton.UseVisualStyleBackColor = True
Me.requestAccountButton.Visible = False
'
'logInButton
'
Me.logInButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.logInButton.Location = New System.Drawing.Point(750, 35)
Me.logInButton.Name = "logInButton"
Me.logInButton.Size = New System.Drawing.Size(64, 21)
Me.logInButton.TabIndex = 3
Me.logInButton.Text = "Anmelden"
Me.logInButton.UseVisualStyleBackColor = True
'
'passwordTextBox
'
Me.passwordTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.passwordTextBox.Location = New System.Drawing.Point(629, 37)
Me.passwordTextBox.Name = "passwordTextBox"
Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
Me.passwordTextBox.Size = New System.Drawing.Size(115, 20)
Me.passwordTextBox.TabIndex = 2
'
'logOutLinkLabel
'
Me.logOutLinkLabel.ActiveLinkColor = System.Drawing.Color.White
Me.logOutLinkLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.logOutLinkLabel.AutoSize = True
Me.logOutLinkLabel.BackColor = System.Drawing.Color.DarkRed
Me.logOutLinkLabel.ForeColor = System.Drawing.Color.White
Me.logOutLinkLabel.LinkColor = System.Drawing.Color.White
Me.logOutLinkLabel.Location = New System.Drawing.Point(760, 55)
Me.logOutLinkLabel.Name = "logOutLinkLabel"
Me.logOutLinkLabel.Size = New System.Drawing.Size(54, 13)
Me.logOutLinkLabel.TabIndex = 4
Me.logOutLinkLabel.TabStop = True
Me.logOutLinkLabel.Text = "Abmelden"
Me.logOutLinkLabel.Visible = False
Me.logOutLinkLabel.VisitedLinkColor = System.Drawing.Color.White
'
'userComboBox
'
Me.userComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.userComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.userComboBox.FormattingEnabled = True
Me.userComboBox.Location = New System.Drawing.Point(629, 10)
Me.userComboBox.Name = "userComboBox"
Me.userComboBox.Size = New System.Drawing.Size(185, 21)
Me.userComboBox.TabIndex = 1
'
'charactersComboBox
'
Me.charactersComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.charactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.charactersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.charactersComboBox.FormattingEnabled = True
Me.charactersComboBox.Location = New System.Drawing.Point(384, 3)
Me.charactersComboBox.Name = "charactersComboBox"
Me.charactersComboBox.Size = New System.Drawing.Size(178, 21)
Me.charactersComboBox.TabIndex = 0
Me.charactersComboBox.Visible = False
'
'questsDataGridView
'
Me.questsDataGridView.AllowUserToAddRows = False
Me.questsDataGridView.AllowUserToDeleteRows = False
Me.questsDataGridView.AllowUserToResizeRows = False
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
Me.questsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
Me.questsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
Me.questsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
Me.questsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
Me.questsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
Me.questsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.questsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.questIdColumn, Me.questNameEnglishColumn, Me.questNameGermanColumn, Me.levelColumn, Me.groupMembersColumn, Me.fractionColumn, Me.difficultyComboBoxColumn, Me.fameColumn, Me.fameDifficultyColumn, Me.urlColumn, Me.showUrlColumn})
Me.questsDataGridView.ContextMenuStrip = Me.mainContextMenuStrip
Me.questsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
Me.questsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
Me.questsDataGridView.Location = New System.Drawing.Point(0, 166)
Me.questsDataGridView.Name = "questsDataGridView"
Me.questsDataGridView.RowHeadersVisible = False
Me.questsDataGridView.ShowCellErrors = False
Me.questsDataGridView.ShowCellToolTips = False
Me.questsDataGridView.ShowEditingIcon = False
Me.questsDataGridView.ShowRowErrors = False
Me.questsDataGridView.Size = New System.Drawing.Size(563, 281)
Me.questsDataGridView.TabIndex = 7
'
'mainContextMenuStrip
'
Me.mainContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.copyToolStripMenuItem})
Me.mainContextMenuStrip.Name = "mainContextMenuStrip"
Me.mainContextMenuStrip.Size = New System.Drawing.Size(122, 26)
'
'copyToolStripMenuItem
'
Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
Me.copyToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
Me.copyToolStripMenuItem.Text = "Kopieren"
'
'ViewerTabControl
'
Me.ViewerTabControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.ViewerTabControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways
Me.ViewerTabControl.IDEPixelBorder = True
Me.ViewerTabControl.Location = New System.Drawing.Point(0, 0)
Me.ViewerTabControl.Name = "ViewerTabControl"
Me.ViewerTabControl.SelectedIndex = 0
Me.ViewerTabControl.SelectedTab = Me.questsTabPage
Me.ViewerTabControl.Size = New System.Drawing.Size(567, 474)
Me.ViewerTabControl.TabIndex = 7
Me.ViewerTabControl.TabPages.AddRange(New Crownwood.Magic.Controls.TabPage() {Me.questsTabPage, Me.fractionsTabPage})
'
'questsTabPage
'
Me.questsTabPage.Controls.Add(Me.questsDataGridView)
Me.questsTabPage.Controls.Add(Me.fameFilterPicker)
Me.questsTabPage.Controls.Add(Me.difficultyFilterPicker)
Me.questsTabPage.Controls.Add(Me.fractionFilterPicker)
Me.questsTabPage.Controls.Add(Me.groupMembersFilterPicker)
Me.questsTabPage.Controls.Add(Me.levelFilterPicker)
Me.questsTabPage.Controls.Add(Me.filterToolStrip)
Me.questsTabPage.Controls.Add(Me.filterLabel)
Me.questsTabPage.Location = New System.Drawing.Point(0, 0)
Me.questsTabPage.Name = "questsTabPage"
Me.questsTabPage.Size = New System.Drawing.Size(563, 447)
Me.questsTabPage.TabIndex = 0
Me.questsTabPage.Title = "Abenteuer"
'
'filterToolStrip
'
Me.filterToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.filterToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.levelToolStripButton, Me.groupMembersToolStripButton, Me.fractionToolStripButton, Me.difficultyToolStripButton, Me.fameToolStripButton})
Me.filterToolStrip.Location = New System.Drawing.Point(0, 21)
Me.filterToolStrip.Name = "filterToolStrip"
Me.filterToolStrip.Size = New System.Drawing.Size(563, 25)
Me.filterToolStrip.TabIndex = 6
Me.filterToolStrip.Text = "ToolStrip1"
'
'levelToolStripButton
'
Me.levelToolStripButton.CheckOnClick = True
Me.levelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.levelToolStripButton.Image = CType(resources.GetObject("levelToolStripButton.Image"), System.Drawing.Image)
Me.levelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.levelToolStripButton.Name = "levelToolStripButton"
Me.levelToolStripButton.Size = New System.Drawing.Size(38, 22)
Me.levelToolStripButton.Text = "Stufe"
'
'groupMembersToolStripButton
'
Me.groupMembersToolStripButton.CheckOnClick = True
Me.groupMembersToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.groupMembersToolStripButton.Image = CType(resources.GetObject("groupMembersToolStripButton.Image"), System.Drawing.Image)
Me.groupMembersToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.groupMembersToolStripButton.Name = "groupMembersToolStripButton"
Me.groupMembersToolStripButton.Size = New System.Drawing.Size(50, 22)
Me.groupMembersToolStripButton.Text = "Gruppe"
'
'fractionToolStripButton
'
Me.fractionToolStripButton.CheckOnClick = True
Me.fractionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.fractionToolStripButton.Image = CType(resources.GetObject("fractionToolStripButton.Image"), System.Drawing.Image)
Me.fractionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.fractionToolStripButton.Name = "fractionToolStripButton"
Me.fractionToolStripButton.Size = New System.Drawing.Size(46, 22)
Me.fractionToolStripButton.Text = "Patron"
'
'difficultyToolStripButton
'
Me.difficultyToolStripButton.CheckOnClick = True
Me.difficultyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.difficultyToolStripButton.Image = CType(resources.GetObject("difficultyToolStripButton.Image"), System.Drawing.Image)
Me.difficultyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.difficultyToolStripButton.Name = "difficultyToolStripButton"
Me.difficultyToolStripButton.Size = New System.Drawing.Size(65, 22)
Me.difficultyToolStripButton.Text = "Fortschritt"
'
'fameToolStripButton
'
Me.fameToolStripButton.CheckOnClick = True
Me.fameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.fameToolStripButton.Image = CType(resources.GetObject("fameToolStripButton.Image"), System.Drawing.Image)
Me.fameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.fameToolStripButton.Name = "fameToolStripButton"
Me.fameToolStripButton.Size = New System.Drawing.Size(70, 22)
Me.fameToolStripButton.Text = "Gefälligkeit"
'
'filterLabel
'
Me.filterLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark
Me.filterLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.filterLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.filterLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight
Me.filterLabel.Location = New System.Drawing.Point(0, 0)
Me.filterLabel.Name = "filterLabel"
Me.filterLabel.Size = New System.Drawing.Size(563, 21)
Me.filterLabel.TabIndex = 0
Me.filterLabel.Text = "Filter"
Me.filterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'fractionsTabPage
'
Me.fractionsTabPage.Controls.Add(Me.fractionFameDataGridView)
Me.fractionsTabPage.Location = New System.Drawing.Point(0, 0)
Me.fractionsTabPage.Name = "fractionsTabPage"
Me.fractionsTabPage.Selected = False
Me.fractionsTabPage.Size = New System.Drawing.Size(563, 447)
Me.fractionsTabPage.TabIndex = 1
Me.fractionsTabPage.Title = "Patrone"
'
'fractionFameDataGridView
'
Me.fractionFameDataGridView.AllowUserToAddRows = False
Me.fractionFameDataGridView.AllowUserToDeleteRows = False
Me.fractionFameDataGridView.AllowUserToResizeRows = False
DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
Me.fractionFameDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
Me.fractionFameDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
Me.fractionFameDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
Me.fractionFameDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
Me.fractionFameDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
Me.fractionFameDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.fractionFameDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fractionFameFractionDataGridViewTextBoxColumn, Me.fractionFameFameDataGridViewTextBoxColumn})
Me.fractionFameDataGridView.ContextMenuStrip = Me.mainContextMenuStrip
Me.fractionFameDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
Me.fractionFameDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
Me.fractionFameDataGridView.Location = New System.Drawing.Point(0, 0)
Me.fractionFameDataGridView.Name = "fractionFameDataGridView"
Me.fractionFameDataGridView.RowHeadersVisible = False
Me.fractionFameDataGridView.ShowCellErrors = False
Me.fractionFameDataGridView.ShowCellToolTips = False
Me.fractionFameDataGridView.ShowEditingIcon = False
Me.fractionFameDataGridView.ShowRowErrors = False
Me.fractionFameDataGridView.Size = New System.Drawing.Size(563, 447)
Me.fractionFameDataGridView.TabIndex = 7
'
'fractionFameFractionDataGridViewTextBoxColumn
'
Me.fractionFameFractionDataGridViewTextBoxColumn.DataPropertyName = "Fraction"
Me.fractionFameFractionDataGridViewTextBoxColumn.HeaderText = "Patron"
Me.fractionFameFractionDataGridViewTextBoxColumn.Name = "fractionFameFractionDataGridViewTextBoxColumn"
Me.fractionFameFractionDataGridViewTextBoxColumn.ReadOnly = True
Me.fractionFameFractionDataGridViewTextBoxColumn.Width = 67
'
'fractionFameFameDataGridViewTextBoxColumn
'
Me.fractionFameFameDataGridViewTextBoxColumn.DataPropertyName = "Fame"
Me.fractionFameFameDataGridViewTextBoxColumn.HeaderText = "Gefälligkeit"
Me.fractionFameFameDataGridViewTextBoxColumn.Name = "fractionFameFameDataGridViewTextBoxColumn"
Me.fractionFameFameDataGridViewTextBoxColumn.ReadOnly = True
Me.fractionFameFameDataGridViewTextBoxColumn.Width = 91
'
'characterPropertyGrid
'
Me.characterPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
Me.characterPropertyGrid.HelpVisible = False
Me.characterPropertyGrid.Location = New System.Drawing.Point(0, 0)
Me.characterPropertyGrid.Name = "characterPropertyGrid"
Me.characterPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
Me.characterPropertyGrid.Size = New System.Drawing.Size(242, 310)
Me.characterPropertyGrid.TabIndex = 0
Me.characterPropertyGrid.ToolbarVisible = False
'
'mainFormMenuStrip
'
Me.mainFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.charactersToolStripMenuItem, Me.extrasToolStripMenuItem})
Me.mainFormMenuStrip.Location = New System.Drawing.Point(0, 70)
Me.mainFormMenuStrip.Name = "mainFormMenuStrip"
Me.mainFormMenuStrip.Size = New System.Drawing.Size(817, 24)
Me.mainFormMenuStrip.TabIndex = 8
Me.mainFormMenuStrip.Text = "MenuStrip1"
Me.mainFormMenuStrip.Visible = False
'
'fileToolStripMenuItem
'
Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.endToolStripMenuItem})
Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
Me.fileToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
Me.fileToolStripMenuItem.Text = "Datei"
'
'endToolStripMenuItem
'
Me.endToolStripMenuItem.Name = "endToolStripMenuItem"
Me.endToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
Me.endToolStripMenuItem.Text = "Beenden"
'
'charactersToolStripMenuItem
'
Me.charactersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newCharacterToolStripMenuItem, Me.deleteCharaterToolStripMenuItem})
Me.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem"
Me.charactersToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
Me.charactersToolStripMenuItem.Text = "Charaktere"
'
'newCharacterToolStripMenuItem
'
Me.newCharacterToolStripMenuItem.Name = "newCharacterToolStripMenuItem"
Me.newCharacterToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
Me.newCharacterToolStripMenuItem.Text = "Neuen Charakter anlegen"
'
'deleteCharaterToolStripMenuItem
'
Me.deleteCharaterToolStripMenuItem.Name = "deleteCharaterToolStripMenuItem"
Me.deleteCharaterToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
Me.deleteCharaterToolStripMenuItem.Text = "Aktuellen Character löschen"
'
'extrasToolStripMenuItem
'
Me.extrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.changePasswordToolStripMenuItem})
Me.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem"
Me.extrasToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
Me.extrasToolStripMenuItem.Text = "Extras"
'
'changePasswordToolStripMenuItem
'
Me.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem"
Me.changePasswordToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
Me.changePasswordToolStripMenuItem.Text = "Kennwort ändern ..."
'
'mainStatusStrip
'
Me.mainStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.countToolStripStatusLabel, Me.fameToolStripStatusLabel})
Me.mainStatusStrip.Location = New System.Drawing.Point(0, 544)
Me.mainStatusStrip.Name = "mainStatusStrip"
Me.mainStatusStrip.Size = New System.Drawing.Size(817, 22)
Me.mainStatusStrip.TabIndex = 8
Me.mainStatusStrip.Text = "StatusStrip1"
'
'countToolStripStatusLabel
'
Me.countToolStripStatusLabel.Name = "countToolStripStatusLabel"
Me.countToolStripStatusLabel.Size = New System.Drawing.Size(55, 17)
Me.countToolStripStatusLabel.Text = "Anzahl: 0"
'
'fameToolStripStatusLabel
'
Me.fameToolStripStatusLabel.Name = "fameToolStripStatusLabel"
Me.fameToolStripStatusLabel.Size = New System.Drawing.Size(117, 17)
Me.fameToolStripStatusLabel.Text = "Gesamtgefälligkeit: 0"
'
'mainSplitContainer
'
Me.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.mainSplitContainer.Location = New System.Drawing.Point(0, 70)
Me.mainSplitContainer.Name = "mainSplitContainer"
'
'mainSplitContainer.Panel1
'
Me.mainSplitContainer.Panel1.Controls.Add(Me.characterTabControl)
'
'mainSplitContainer.Panel2
'
Me.mainSplitContainer.Panel2.Controls.Add(Me.ViewerTabControl)
Me.mainSplitContainer.Size = New System.Drawing.Size(817, 474)
Me.mainSplitContainer.SplitterDistance = 246
Me.mainSplitContainer.TabIndex = 9
Me.mainSplitContainer.Visible = False
'
'characterTabControl
'
Me.characterTabControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.characterTabControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways
Me.characterTabControl.IDEPixelBorder = True
Me.characterTabControl.Location = New System.Drawing.Point(0, 0)
Me.characterTabControl.Name = "characterTabControl"
Me.characterTabControl.SelectedIndex = 0
Me.characterTabControl.SelectedTab = Me.characterTabPage
Me.characterTabControl.Size = New System.Drawing.Size(246, 474)
Me.characterTabControl.TabIndex = 11
Me.characterTabControl.TabPages.AddRange(New Crownwood.Magic.Controls.TabPage() {Me.characterTabPage, Me.vaultTabPage})
'
'characterTabPage
'
Me.characterTabPage.Controls.Add(Me.characterSplitContainer)
Me.characterTabPage.Location = New System.Drawing.Point(0, 0)
Me.characterTabPage.Name = "characterTabPage"
Me.characterTabPage.Size = New System.Drawing.Size(242, 447)
Me.characterTabPage.TabIndex = 0
Me.characterTabPage.Title = "Charaktereigenschaften"
'
'characterSplitContainer
'
Me.characterSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.characterSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
Me.characterSplitContainer.Location = New System.Drawing.Point(0, 0)
Me.characterSplitContainer.Name = "characterSplitContainer"
Me.characterSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
'
'characterSplitContainer.Panel1
'
Me.characterSplitContainer.Panel1.Controls.Add(Me.characterPropertyGrid)
'
'characterSplitContainer.Panel2
'
Me.characterSplitContainer.Panel2.Controls.Add(Me.characterCommentGroupBox)
Me.characterSplitContainer.Size = New System.Drawing.Size(242, 447)
Me.characterSplitContainer.SplitterDistance = 310
Me.characterSplitContainer.TabIndex = 10
'
'characterCommentGroupBox
'
Me.characterCommentGroupBox.Controls.Add(Me.characterCommentTextBox)
Me.characterCommentGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
Me.characterCommentGroupBox.Location = New System.Drawing.Point(0, 0)
Me.characterCommentGroupBox.Name = "characterCommentGroupBox"
Me.characterCommentGroupBox.Size = New System.Drawing.Size(242, 133)
Me.characterCommentGroupBox.TabIndex = 9
Me.characterCommentGroupBox.TabStop = False
Me.characterCommentGroupBox.Text = "Bemerkungen"
'
'characterCommentTextBox
'
Me.characterCommentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
Me.characterCommentTextBox.Location = New System.Drawing.Point(3, 19)
Me.characterCommentTextBox.Multiline = True
Me.characterCommentTextBox.Name = "characterCommentTextBox"
Me.characterCommentTextBox.Size = New System.Drawing.Size(236, 111)
Me.characterCommentTextBox.TabIndex = 0
'
'vaultTabPage
'
Me.vaultTabPage.Controls.Add(Me.vaultSplitContainer)
Me.vaultTabPage.Location = New System.Drawing.Point(0, 0)
Me.vaultTabPage.Name = "vaultTabPage"
Me.vaultTabPage.Selected = False
Me.vaultTabPage.Size = New System.Drawing.Size(242, 447)
Me.vaultTabPage.TabIndex = 1
Me.vaultTabPage.Title = "Bankfächer"
'
'vaultSplitContainer
'
Me.vaultSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.vaultSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
Me.vaultSplitContainer.Location = New System.Drawing.Point(0, 0)
Me.vaultSplitContainer.Name = "vaultSplitContainer"
Me.vaultSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
'
'vaultSplitContainer.Panel1
'
Me.vaultSplitContainer.Panel1.Controls.Add(Me.vaultTreeView)
'
'vaultSplitContainer.Panel2
'
Me.vaultSplitContainer.Panel2.Controls.Add(Me.vaultCommentGroupBox)
Me.vaultSplitContainer.Size = New System.Drawing.Size(242, 447)
Me.vaultSplitContainer.SplitterDistance = 310
Me.vaultSplitContainer.TabIndex = 11
'
'vaultTreeView
'
Me.vaultTreeView.Dock = System.Windows.Forms.DockStyle.Fill
Me.vaultTreeView.HideSelection = False
Me.vaultTreeView.LabelEdit = True
Me.vaultTreeView.Location = New System.Drawing.Point(0, 0)
Me.vaultTreeView.Name = "vaultTreeView"
Me.vaultTreeView.Size = New System.Drawing.Size(242, 310)
Me.vaultTreeView.TabIndex = 0
'
'vaultCommentGroupBox
'
Me.vaultCommentGroupBox.Controls.Add(Me.vaultCommentTextBox)
Me.vaultCommentGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
Me.vaultCommentGroupBox.Location = New System.Drawing.Point(0, 0)
Me.vaultCommentGroupBox.Name = "vaultCommentGroupBox"
Me.vaultCommentGroupBox.Size = New System.Drawing.Size(242, 133)
Me.vaultCommentGroupBox.TabIndex = 9
Me.vaultCommentGroupBox.TabStop = False
Me.vaultCommentGroupBox.Text = "Bemerkungen"
'
'vaultCommentTextBox
'
Me.vaultCommentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
Me.vaultCommentTextBox.Location = New System.Drawing.Point(3, 19)
Me.vaultCommentTextBox.Multiline = True
Me.vaultCommentTextBox.Name = "vaultCommentTextBox"
Me.vaultCommentTextBox.Size = New System.Drawing.Size(236, 111)
Me.vaultCommentTextBox.TabIndex = 0
'
'fameFilterPicker
'
Me.fameFilterPicker.AutoScroll = True
Me.fameFilterPicker.Dock = System.Windows.Forms.DockStyle.Top
Me.fameFilterPicker.Header = "Gefälligkeit:"
Me.fameFilterPicker.HeaderWidth = 80
Me.fameFilterPicker.Location = New System.Drawing.Point(0, 142)
Me.fameFilterPicker.Name = "fameFilterPicker"
Me.fameFilterPicker.Padding = New System.Windows.Forms.Padding(2)
Me.fameFilterPicker.Size = New System.Drawing.Size(563, 24)
Me.fameFilterPicker.TabIndex = 4
Me.fameFilterPicker.Visible = False
'
'difficultyFilterPicker
'
Me.difficultyFilterPicker.AutoScroll = True
Me.difficultyFilterPicker.Dock = System.Windows.Forms.DockStyle.Top
Me.difficultyFilterPicker.Header = "Fortschritt:"
Me.difficultyFilterPicker.HeaderWidth = 80
Me.difficultyFilterPicker.Location = New System.Drawing.Point(0, 118)
Me.difficultyFilterPicker.Name = "difficultyFilterPicker"
Me.difficultyFilterPicker.Padding = New System.Windows.Forms.Padding(2)
Me.difficultyFilterPicker.Size = New System.Drawing.Size(563, 24)
Me.difficultyFilterPicker.TabIndex = 3
Me.difficultyFilterPicker.Visible = False
'
'fractionFilterPicker
'
Me.fractionFilterPicker.AutoScroll = True
Me.fractionFilterPicker.Dock = System.Windows.Forms.DockStyle.Top
Me.fractionFilterPicker.Header = "Patron:"
Me.fractionFilterPicker.HeaderWidth = 80
Me.fractionFilterPicker.Location = New System.Drawing.Point(0, 94)
Me.fractionFilterPicker.Name = "fractionFilterPicker"
Me.fractionFilterPicker.Padding = New System.Windows.Forms.Padding(2)
Me.fractionFilterPicker.Size = New System.Drawing.Size(563, 24)
Me.fractionFilterPicker.TabIndex = 2
Me.fractionFilterPicker.Visible = False
'
'groupMembersFilterPicker
'
Me.groupMembersFilterPicker.AutoScroll = True
Me.groupMembersFilterPicker.Dock = System.Windows.Forms.DockStyle.Top
Me.groupMembersFilterPicker.Header = "Gruppe:"
Me.groupMembersFilterPicker.HeaderWidth = 80
Me.groupMembersFilterPicker.Location = New System.Drawing.Point(0, 70)
Me.groupMembersFilterPicker.Name = "groupMembersFilterPicker"
Me.groupMembersFilterPicker.Padding = New System.Windows.Forms.Padding(2)
Me.groupMembersFilterPicker.Size = New System.Drawing.Size(563, 24)
Me.groupMembersFilterPicker.TabIndex = 1
Me.groupMembersFilterPicker.Visible = False
'
'levelFilterPicker
'
Me.levelFilterPicker.AutoScroll = True
Me.levelFilterPicker.Dock = System.Windows.Forms.DockStyle.Top
Me.levelFilterPicker.Header = "Stufe:"
Me.levelFilterPicker.HeaderWidth = 80
Me.levelFilterPicker.Location = New System.Drawing.Point(0, 46)
Me.levelFilterPicker.Name = "levelFilterPicker"
Me.levelFilterPicker.Padding = New System.Windows.Forms.Padding(2)
Me.levelFilterPicker.Size = New System.Drawing.Size(563, 24)
Me.levelFilterPicker.TabIndex = 0
Me.levelFilterPicker.Visible = False
'
'questIdColumn
'
Me.questIdColumn.DataPropertyName = "QuestID"
Me.questIdColumn.HeaderText = "QuestID"
Me.questIdColumn.Name = "questIdColumn"
Me.questIdColumn.ReadOnly = True
Me.questIdColumn.Visible = False
Me.questIdColumn.Width = 55
'
'questNameEnglishColumn
'
Me.questNameEnglishColumn.DataPropertyName = "QuestNameEnglish"
Me.questNameEnglishColumn.HeaderText = "Abenteuername (englisch)"
Me.questNameEnglishColumn.Name = "questNameEnglishColumn"
Me.questNameEnglishColumn.ReadOnly = True
Me.questNameEnglishColumn.Width = 157
'
'questNameGermanColumn
'
Me.questNameGermanColumn.DataPropertyName = "QuestNameGerman"
Me.questNameGermanColumn.HeaderText = "Abenteuername (deutsch)"
Me.questNameGermanColumn.Name = "questNameGermanColumn"
Me.questNameGermanColumn.ReadOnly = True
Me.questNameGermanColumn.Width = 155
'
'levelColumn
'
Me.levelColumn.DataPropertyName = "Level"
Me.levelColumn.HeaderText = "Stufe"
Me.levelColumn.Name = "levelColumn"
Me.levelColumn.ReadOnly = True
Me.levelColumn.Width = 59
'
'groupMembersColumn
'
Me.groupMembersColumn.DataPropertyName = "GroupMembers"
Me.groupMembersColumn.HeaderText = "Gruppe"
Me.groupMembersColumn.Name = "groupMembersColumn"
Me.groupMembersColumn.ReadOnly = True
Me.groupMembersColumn.Width = 71
'
'fractionColumn
'
Me.fractionColumn.DataPropertyName = "Fraction"
Me.fractionColumn.HeaderText = "Patron"
Me.fractionColumn.Name = "fractionColumn"
Me.fractionColumn.ReadOnly = True
Me.fractionColumn.Width = 67
'
'difficultyComboBoxColumn
'
Me.difficultyComboBoxColumn.DataPropertyName = "Difficulty"
Me.difficultyComboBoxColumn.HeaderText = "Fortschritt"
Me.difficultyComboBoxColumn.Items.AddRange(New Object() {"-", "Solo", "Normal", "Schwer", "Elite"})
Me.difficultyComboBoxColumn.Name = "difficultyComboBoxColumn"
Me.difficultyComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
Me.difficultyComboBoxColumn.Width = 86
'
'fameColumn
'
Me.fameColumn.DataPropertyName = "Fame"
Me.fameColumn.HeaderText = "Gefälligkeit"
Me.fameColumn.Name = "fameColumn"
Me.fameColumn.ReadOnly = True
Me.fameColumn.Width = 91
'
'fameDifficultyColumn
'
Me.fameDifficultyColumn.DataPropertyName = "FameDifficulty"
Me.fameDifficultyColumn.HeaderText = "Modifizierte Gefälligkeit"
Me.fameDifficultyColumn.Name = "fameDifficultyColumn"
Me.fameDifficultyColumn.ReadOnly = True
Me.fameDifficultyColumn.Width = 143
'
'urlColumn
'
Me.urlColumn.DataPropertyName = "URL"
Me.urlColumn.HeaderText = "address"
Me.urlColumn.Name = "urlColumn"
Me.urlColumn.ReadOnly = True
Me.urlColumn.Visible = False
Me.urlColumn.Width = 72
'
'showUrlColumn
'
Me.showUrlColumn.HeaderText = "DDO-Wiki"
Me.showUrlColumn.Name = "showUrlColumn"
Me.showUrlColumn.ReadOnly = True
Me.showUrlColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.showUrlColumn.Text = "..."
Me.showUrlColumn.ToolTipText = "Informationen von DDO-Wiki abrufen"
Me.showUrlColumn.UseColumnTextForButtonValue = True
Me.showUrlColumn.Width = 66
'
'MainDialog
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(817, 566)
Me.Controls.Add(Me.mainSplitContainer)
Me.Controls.Add(Me.mainFormMenuStrip)
Me.Controls.Add(Me.titlePanel)
Me.Controls.Add(Me.mainStatusStrip)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Name = "MainDialog"
Me.Text = "questPlaner"
Me.titlePanel.ResumeLayout(False)
Me.titlePanel.PerformLayout()
CType(Me.questsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.mainContextMenuStrip.ResumeLayout(False)
Me.questsTabPage.ResumeLayout(False)
Me.questsTabPage.PerformLayout()
Me.filterToolStrip.ResumeLayout(False)
Me.filterToolStrip.PerformLayout()
Me.fractionsTabPage.ResumeLayout(False)
CType(Me.fractionFameDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.mainFormMenuStrip.ResumeLayout(False)
Me.mainFormMenuStrip.PerformLayout()
Me.mainStatusStrip.ResumeLayout(False)
Me.mainStatusStrip.PerformLayout()
Me.mainSplitContainer.Panel1.ResumeLayout(False)
Me.mainSplitContainer.Panel2.ResumeLayout(False)
CType(Me.mainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.mainSplitContainer.ResumeLayout(False)
Me.characterTabPage.ResumeLayout(False)
Me.characterSplitContainer.Panel1.ResumeLayout(False)
Me.characterSplitContainer.Panel2.ResumeLayout(False)
CType(Me.characterSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.characterSplitContainer.ResumeLayout(False)
Me.characterCommentGroupBox.ResumeLayout(False)
Me.characterCommentGroupBox.PerformLayout()
Me.vaultTabPage.ResumeLayout(False)
Me.vaultSplitContainer.Panel1.ResumeLayout(False)
Me.vaultSplitContainer.Panel2.ResumeLayout(False)
CType(Me.vaultSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.vaultSplitContainer.ResumeLayout(False)
Me.vaultCommentGroupBox.ResumeLayout(False)
Me.vaultCommentGroupBox.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _LogedUser As User
  Private _ConnectionString As String _
  = BCW.etc.Cryptography.DecryptString(My.Settings.ConnectionString)
  Private _Character As Character
  Private _DataTable As DataTable
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
  Public Property Character() As Character
  Get
    Return _Character
  End Get
  Set(ByVal value As Character)
    _Character = value
    characterPropertyGrid.SelectedObject = value
    vaultCommentTextBox.Text = ""
    vaultTreeView.Nodes.Clear()

    If value Is Nothing Then
      characterCommentTextBox.Text = ""
    Else
      characterCommentTextBox.Text = value.Comment
      For Each v As VaultEntry In _Character.Vault
        vaultTreeView.Nodes.Add(v.Item).Tag = v
      Next v
    End If

  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
  Private Sub onFilterSelectedItemsChanged _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles levelFilterPicker.SelectedItemsChanged, groupMembersFilterPicker.SelectedItemsChanged, fractionFilterPicker.SelectedItemsChanged, difficultyFilterPicker.SelectedItemsChanged, fameFilterPicker.SelectedItemsChanged

    GetQuestList()
  End Sub

  Private Sub onTabControlSelectionChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles ViewerTabControl.SelectionChanged

    Select Case ViewerTabControl.SelectedTab Is questsTabPage
    Case True
      GetQuestList()
    Case Else
      GetFractionFame()
    End Select
  End Sub

  Private Sub onFilterShowCheckedChanged _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles levelToolStripButton.CheckStateChanged, groupMembersToolStripButton.CheckStateChanged, fractionToolStripButton.CheckStateChanged, difficultyToolStripButton.CheckStateChanged, fameToolStripButton.CheckStateChanged

    Select Case True
    Case sender Is levelToolStripButton
      levelFilterPicker.Visible = levelToolStripButton.Checked
    Case sender Is groupMembersToolStripButton
      groupMembersFilterPicker.Visible = groupMembersToolStripButton.Checked
    Case sender Is fractionToolStripButton
      fractionFilterPicker.Visible = fractionToolStripButton.Checked
    Case sender Is difficultyToolStripButton
      difficultyFilterPicker.Visible = difficultyToolStripButton.Checked
    Case sender Is fameToolStripButton
      fameFilterPicker.Visible = fameToolStripButton.Checked
    End Select

    Dim toolStripButton = DirectCast(sender, ToolStripButton)
    Select Case toolStripButton.Checked
    Case True
      toolStripButton.Text &= "+"
    Case Else
      toolStripButton.Text = toolStripButton.Text.Replace("+", "")
    End Select

    GetQuestList()
  End Sub

  Private Sub onLogOutClicked _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
  Handles logOutLinkLabel.LinkClicked

    Me.Character = Nothing

    passwordTextBox.Text = ""
    mainSplitContainer.Visible = False
    charactersComboBox.Visible = False
    logOutLinkLabel.Visible = False
    mainFormMenuStrip.Visible = False
    countToolStripStatusLabel.Text = "Anzahl: 0"
    fameToolStripStatusLabel.Text = "Gesamtgefälligkeit: 0"
    userComboBox.Visible = True
    passwordTextBox.Visible = True
    logInButton.Visible = True
    passwordTextBox.Focus()
  End Sub

  Private Sub onLogInClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles logInButton.Click

    CheckLogin()
  End Sub

  Private Sub onPasswordKeyDown _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles passwordTextBox.KeyDown

    Select Case e.KeyCode
    Case Keys.Enter
      CheckLogin()
    End Select
  End Sub

  Private Sub onUserSelectedIndexChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles userComboBox.SelectedIndexChanged

    _LogedUser = DirectCast(userComboBox.SelectedItem, User)

    My.Settings.LastLoginUser = userComboBox.Text
    My.Settings.Save()
    passwordTextBox.Focus()
  End Sub

  Private Sub onMainDialogShown _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles Me.Shown

    passwordTextBox.Focus()
  End Sub

  Private Sub onTitlePanelPaint _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.PaintEventArgs) _
  Handles titlePanel.Paint

    If System.Diagnostics.Debugger.IsAttached Then Exit Sub
    Dim g = e.Graphics

    Using b As New System.Drawing.Drawing2D.LinearGradientBrush _
    (titlePanel.DisplayRectangle, Color.Black _
    , Color.DarkRed, Drawing2D.LinearGradientMode.Vertical)
      g.FillRectangle(b, titlePanel.DisplayRectangle)
    End Using

    g.DrawImage(My.Resources.logo, 4, 2)
  End Sub

  Private Sub onCopyClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles copyToolStripMenuItem.Click

    Dim dgv = DirectCast(mainContextMenuStrip.SourceControl, DataGridView)
    My.Computer.Clipboard.SetDataObject(dgv.GetClipboardContent)
  End Sub

  Private Sub onEndClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles endToolStripMenuItem.Click

    Me.Close()
  End Sub

  Private Sub onChangePasswordClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles changePasswordToolStripMenuItem.Click

    Dim f = New PasswordDialog(_ConnectionString, _LogedUser)
    f.ShowDialog()
  End Sub

  Private Sub onCharacterSelectedIndexChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles charactersComboBox.SelectedIndexChanged

    If charactersComboBox.SelectedItem Is Nothing Then
      Me.Character = Nothing
      _DataTable = Nothing
      questsDataGridView.DataSource = Nothing
      Exit Sub
    End If

    Me.Character = DirectCast(charactersComboBox.SelectedItem, Character)

    Select Case ViewerTabControl.SelectedTab Is questsTabPage
    Case True
      GetQuestList()
    Case Else
      GetFractionFame()
    End Select
  End Sub

  Private Sub onQuestCellClick _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
  Handles questsDataGridView.CellClick

    Select e.ColumnIndex
    Case showUrlColumn.Index
      Process.Start(questsDataGridView.CurrentRow.Cells.Item("urlColumn").Value.ToString)
    End Select
  End Sub

  Private Sub onQuestCellEndEdit _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
  Handles questsDataGridView.CellEndEdit

    UpdateDifficulty _
    (CType(questsDataGridView.Rows.Item(e.RowIndex).Cells.Item("questIdColumn").Value, Int32) _
    , questsDataGridView.Rows.Item(e.RowIndex).Cells.Item(e.ColumnIndex).Value.ToString)
  End Sub

  Private Sub onCellFormatting(ByVal sender As Object, _
  ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
  Handles questsDataGridView.CellFormatting

    Select Case True
    Case questsDataGridView.Columns.Item(e.ColumnIndex).Name _
    = difficultyComboBoxColumn.Name
      If e.Value Is Nothing Then Exit Select

      Select Case e.Value.ToString
      Case "Solo"
        e.CellStyle.ForeColor = Color.DarkBlue
      Case "Normal"
        e.CellStyle.ForeColor = Color.Green
      Case "Schwer"
        e.CellStyle.ForeColor = Color.Orange
      Case "Elite"
        e.CellStyle.ForeColor = Color.DarkRed
      End Select
    End Select
  End Sub

  Private Sub onFormLoad _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles Me.Load

    FillUsers()
    levelFilterPicker.Items.AddRange(GetAllLevels)
    groupMembersFilterPicker.Items.AddRange(GetAllGroupMembers)
    fractionFilterPicker.Items.AddRange(GetAllFractions)
    difficultyFilterPicker.Items.AddRange _
    (New String() {"&-", "Solo", "Normal", "Schwer", "Elite"})
    fameFilterPicker.Items.AddRange(GetAllFame)
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function LoginOK() As Boolean

    If userComboBox.SelectedItem Is Nothing Then Exit Function

    'Dim userName = userComboBox.Text
    Dim password = passwordTextBox.Text

    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("IF(COUNT(1) = 0, ""False"", ""True"") AS LogInOK")
    sb.From.Add(My.Settings.Database & ".ddo_users")
    sb.Where.Add("(UserID = " & _LogedUser.UserID & ")")
    sb.Where.Add("AND (MD5(""" & password & """) = Password)")

    Try
      Return CType(BCW.Data.MySqlDBResult.ExecuteScalar _
      (_ConnectionString, sb.ToString), Boolean)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End Try
  End Function

  Private Sub CheckLogin()
    If Not LoginOK() Then
      passwordTextBox.Text = ""
      MessageBox.Show("Login fehlgeschlagen!", "Login" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    charactersComboBox.Size = userComboBox.Size
    charactersComboBox.Location = userComboBox.Location
    userComboBox.Visible = False
    passwordTextBox.Visible = False
    logInButton.Visible = False
    mainSplitContainer.Visible = True
    charactersComboBox.Visible = True
    logOutLinkLabel.Visible = True
    mainFormMenuStrip.Visible = True
    extrasToolStripMenuItem.Enabled = _LogedUser.UserName.ToLower <> "gast"
    charactersToolStripMenuItem.Enabled = extrasToolStripMenuItem.Enabled
    FillCharacters()
  End Sub

  Private Sub GetFractionFame()
    If _Character Is Nothing Then Exit Sub

    Me.Cursor = Cursors.WaitCursor
    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder

      Dim fameDifficulty As New System.Text.StringBuilder
      fameDifficulty.AppendLine("SUM(CASE")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""S"" THEN Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""N"" THEN Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""H"" THEN 2 * Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""E"" THEN 3 * Fame")
      fameDifficulty.AppendLine(vbTab & "ELSE 0")
      fameDifficulty.Append("END) AS Fame")

      sb.Select.Add("q.Fraction")
      sb.Select.Add(fameDifficulty.ToString)
      sb.From.Add(My.Settings.Database & ".ddo_quests q")
      sb.From.Add("LEFT JOIN " & My.Settings.Database & ".ddo_quests_character qc")
      sb.From.Add("ON q.QuestID = qc.QuestID")
      sb.From.Add("AND qc.CharacterID = """ & _Character.CharacterID & """")
      sb.Group.Add("Fraction")
      sb.Order.Add("Fraction")

      _DataTable = BCW.Data.MySqlDBResult.GetDataTable _
      (_ConnectionString, sb.ToString)

      fractionFameDataGridView.DataSource = _DataTable

      countToolStripStatusLabel.Text = "Anzahl: " & fractionFameDataGridView.Rows.Count

      Dim fame As Int32 = 0
      For Each r As DataGridViewRow In fractionFameDataGridView.Rows
        fame += CType(r.Cells.Item("fractionFameFameDataGridViewTextBoxColumn").Value, Int32)
      Next r

      fameToolStripStatusLabel.Text = "Gesamtgefälligkeit: " & fame
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
      Me.Cursor = Cursors.Default
    End Try

  End Sub

  Private Sub GetQuestList()

    If _Character Is Nothing Then Exit Sub

    Me.Cursor = Cursors.WaitCursor
    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder

      Dim groupMembers As New System.Text.StringBuilder
      groupMembers.AppendLine("CASE")
      groupMembers.AppendLine(vbTab & "WHEN q.SoloOnly = ""Y"" THEN ""Solo""")
      groupMembers.AppendLine(vbTab & "WHEN q.Solo = ""Y"" THEN ""Solo/ Gruppe""")
      groupMembers.AppendLine(vbTab & "WHEN q.Raid = ""Y"" THEN ""Überfall""")
      groupMembers.AppendLine(vbTab & "ELSE ""Gruppe""")
      groupMembers.Append("END AS GroupMembers")

      Dim difficulty As New System.Text.StringBuilder
      difficulty.AppendLine("CASE")
      difficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""S"" THEN ""Solo""")
      difficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""N"" THEN ""Normal""")
      difficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""H"" THEN ""Schwer""")
      difficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""E"" THEN ""Elite""")
      difficulty.AppendLine(vbTab & "ELSE ""-""")
      difficulty.Append("END AS Difficulty")

      Dim fameDifficulty As New System.Text.StringBuilder
      fameDifficulty.AppendLine("CASE")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""S"" THEN Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""N"" THEN Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""H"" THEN 2 * Fame")
      fameDifficulty.AppendLine(vbTab & "WHEN qc.Difficulty = ""E"" THEN 3 * Fame")
      fameDifficulty.AppendLine(vbTab & "ELSE 0")
      fameDifficulty.Append("END AS FameDifficulty")

      sb.Select.Add("q.QuestID")
      sb.Select.Add("q.QuestNameEnglish")
      sb.Select.Add("q.QuestNameGerman")
      sb.Select.Add("q.Level")
      sb.Select.Add(groupMembers.ToString)
      sb.Select.Add("q.Fraction")
      sb.Select.Add(difficulty.ToString)
      sb.Select.Add("q.Fame")
      sb.Select.Add("q.URL")
      sb.Select.Add(fameDifficulty.ToString)

      sb.From.Add(My.Settings.Database & ".ddo_quests q")
      sb.From.Add("LEFT JOIN " & My.Settings.Database & ".ddo_quests_character qc")
      sb.From.Add("ON q.QuestID = qc.QuestID")
      sb.From.Add("AND qc.CharacterID = """ & _Character.CharacterID & """")
      sb.Where.Add("(1 = 1)")
      sb.Where.Add(GetFilter.ToString)
      sb.Order.Add("Level")
      sb.Order.Add("QuestNameGerman")

      _DataTable = BCW.Data.MySqlDBResult.GetDataTable _
      (_ConnectionString, sb.ToString)

      questsDataGridView.DataSource = _DataTable

      countToolStripStatusLabel.Text = "Anzahl: " & questsDataGridView.Rows.Count

      Dim fame As Int32 = 0
      For Each r As DataGridViewRow In questsDataGridView.Rows
        fame += CType(r.Cells.Item("fameDifficultyColumn").Value, Int32)
      Next r

      fameToolStripStatusLabel.Text = "Gesamtgefälligkeit: " & fame
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
      Me.Cursor = Cursors.Default
    End Try
  End Sub

  Private Function GetFilter() As System.Text.StringBuilder
    Dim sb As New System.Text.StringBuilder

    If (levelFilterPicker.Visible) _
    AndAlso (levelFilterPicker.SelectedItems.Count > 0) Then
      sb.AppendLine("AND (q.Level IN(" _
      & String.Join(", ", levelFilterPicker.SelectedItems.ToArray) & "))")
    End If

    With groupMembersFilterPicker
      If (.Visible) _
      AndAlso (.SelectedItems.Count > 0) _
      AndAlso (Not .SelectedItems.Contains("Gruppe")) Then
        Dim groups As New List(Of String)
        If .SelectedItems.Contains("Solo") Then groups.Add("(q.SoloOnly = ""Y"")")
        If .SelectedItems.Contains("Solo/ Gruppe") Then groups.Add("(q.Solo = ""Y"")")
        If .SelectedItems.Contains("Überfall") Then groups.Add("(q.Raid = ""Y"")")
        sb.AppendLine("AND (" & String.Join(" OR ", groups.ToArray) & ")")
      End If
    End With

    If (fractionFilterPicker.Visible) _
    AndAlso (fractionFilterPicker.SelectedItems.Count > 0) Then
      Dim fractions = """" & String.Join _
      (""", """, fractionFilterPicker.SelectedItems.ToArray) & """"
      sb.AppendLine("AND (q.Fraction IN(" & fractions & "))")
    End If

    With difficultyFilterPicker
      If (.Visible) _
      AndAlso (.SelectedItems.Count > 0) Then
        Dim difficulties As New List(Of String)
        If .SelectedItems.Contains("&-") Then difficulties.Add("(qc.Difficulty IS NULL)")
        If .SelectedItems.Contains("Solo") Then difficulties.Add("(qc.Difficulty = ""S"")")
        If .SelectedItems.Contains("Normal") Then difficulties.Add("(qc.Difficulty = ""N"")")
        If .SelectedItems.Contains("Schwer") Then difficulties.Add("(qc.Difficulty = ""H"")")
        If .SelectedItems.Contains("Elite") Then difficulties.Add("(qc.Difficulty = ""E"")")
        sb.AppendLine("AND (" & String.Join(" OR ", difficulties.ToArray) & ")")
      End If
    End With

    If (fameFilterPicker.Visible) _
    AndAlso (fameFilterPicker.SelectedItems.Count > 0) Then
      sb.AppendLine("AND (q.Fame IN(" _
      & String.Join(", ", fameFilterPicker.SelectedItems.ToArray) & "))")
    End If

    Return sb
  End Function

  Private Sub FillCharacters()

    charactersComboBox.Items.Clear()
    charactersComboBox.DisplayMember = "CharacterName"

    Try
      Dim characters = New Characters(_ConnectionString)
      characters.FillByUser(_LogedUser.UserID)
      'Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      'sb.Select.Add("ID")
      'sb.From.Add(My.Settings.Database & ".ddo_characters")
      'sb.Where.Add("UserID = " & _LogedUser.UserID)
      'sb.Order.Add("CharacterName")

      'Using dr = BCW.Data.MySqlDBResult.ExecuteReader _
      '(_ConnectionString, sb.ToString)
      '  While dr.Read
      '    charactersComboBox.Items.Add(New Character(_ConnectionString, dr.GetInt32(0)))
      '  End While
      'End Using

      For Each c As Character In characters
        charactersComboBox.Items.Add(c)
      Next c

      If charactersComboBox.Items.Count = 0 Then Exit Sub

      charactersComboBox.SelectedItem _
      = charactersComboBox.Items.Item(0)

    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Sub UpdateCharacterQuest _
  (ByVal questID As Int32 _
  , ByVal value As String)

    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("IF(COUNT(1) = 0, ""False"", ""True"") AS AlreadyExists")
      sb.From.Add(My.Settings.Database & ".ddo_quests_character qc")
      sb.Where.Add("(qc.QuestID = " & questID & ")")
      sb.Where.Add("AND (qc.CharacterID = """ & _Character.CharacterID & """)")

      Select Case CType(BCW.Data.MySqlDBResult.ExecuteScalar _
      (_ConnectionString, sb.ToString), Boolean)
      Case True
        Dim usb As New BCW.Data.MySqlStatementBuilders.UpdateBuilder
        usb.UpadteTables.Add(My.Settings.Database & ".ddo_quests_character")
        usb.Set.Add("Difficulty = """ & value & """")
        usb.Where.Add("(QuestID = " & questID & ")")
        usb.Where.Add("AND (CharacterID = """ & _Character.CharacterID & """)")
        BCW.Data.MySqlDBResult.ExecuteNonQuery _
        (_ConnectionString, usb.ToString)
      Case Else
        Dim isb As New BCW.Data.MySqlStatementBuilders.InsertBuilder
        isb.Table = My.Settings.Database & ".ddo_quests_character"
        isb.FieldsAndValues.Add("QuestID", questID.ToString)
        isb.FieldsAndValues.Add("CharacterID", """" & _Character.CharacterID & """")
        isb.FieldsAndValues.Add("Difficulty", """" & value & """")
        BCW.Data.MySqlDBResult.ExecuteNonQuery _
        (_ConnectionString, isb.ToString)
      End Select
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub UpdateDifficulty(ByVal questID As Int32, ByVal value As String)
    If _Character Is Nothing Then Exit Sub

    Try
      Select Case value
      Case "-"
        Dim dsb As New BCW.Data.MySqlStatementBuilders.DeleteBuilder
        dsb.Table = My.Settings.Database & ".ddo_quests_character"
        dsb.Where.Add("(QuestID = " & questID & ")")
        dsb.Where.Add("AND (CharacterID = """ & _Character.CharacterID & """)")
        BCW.Data.MySqlDBResult.ExecuteNonQuery _
        (_ConnectionString, dsb.ToString)
      Case "Solo"
        UpdateCharacterQuest(questID, "S")
      Case "Normal"
        UpdateCharacterQuest(questID, "N")
      Case "Schwer"
        UpdateCharacterQuest(questID, "H")
      Case "Elite"
        UpdateCharacterQuest(questID, "E")
      End Select
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub FillUsers()

    userComboBox.Items.Clear()
    userComboBox.DisplayMember = "Key"

    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("UserID")
      sb.From.Add(My.Settings.Database & ".ddo_users")
      sb.Order.Add("UserName")

      Using dr = BCW.Data.MySqlDBResult.ExecuteReader _
      (_ConnectionString, sb.ToString)

        While dr.Read
          Dim user = New User(_ConnectionString, dr.GetInt32(0))
          userComboBox.Items.Add(user)
          If user.UserName = My.Settings.LastLoginUser Then
            userComboBox.SelectedItem = user
          End If
        End While
      End Using
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Function GetAllFractions() As List(Of String)
    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("q.Fraction")
    sb.From.Add(My.Settings.Database & ".ddo_quests q")
    sb.Where.Add("q.Fraction <> ""-""")
    sb.Group.Add("q.Fraction")
    sb.Order.Add("q.Fraction")

    Try
      Return BCW.Data.MySqlDBResult.GetFieldList _
      (Of String)(_ConnectionString, sb.ToString)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return New List(Of String)
    End Try
  End Function

  Private Function GetAllLevels() As List(Of String)
    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("q.Level")
    sb.From.Add(My.Settings.Database & ".ddo_quests q")
    sb.Where.Add("q.Level > 0")
    sb.Group.Add("q.Level")
    sb.Order.Add("q.Level")

    Try
      Return BCW.Data.MySqlDBResult.GetFieldList _
      (Of String)(_ConnectionString, sb.ToString)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return New List(Of String)
    End Try
  End Function

  Private Function GetAllFame() As List(Of String)
    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("q.Fame")
    sb.From.Add(My.Settings.Database & ".ddo_quests q")
    sb.Group.Add("q.Fame")
    sb.Order.Add("q.Fame")

    Try
      Return BCW.Data.MySqlDBResult.GetFieldList _
      (Of String)(_ConnectionString, sb.ToString)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return New List(Of String)
    End Try
  End Function

  Private Function GetAllGroupMembers() As List(Of String)
    Dim groupMembers As New System.Text.StringBuilder
    groupMembers.AppendLine("CASE")
    groupMembers.AppendLine(vbTab & "WHEN q.SoloOnly = ""Y"" THEN ""Solo""")
    groupMembers.AppendLine(vbTab & "WHEN q.Solo = ""Y"" THEN ""Solo/ Gruppe""")
    groupMembers.AppendLine(vbTab & "WHEN q.Raid = ""Y"" THEN ""Überfall""")
    groupMembers.AppendLine(vbTab & "ELSE ""Gruppe""")
    groupMembers.Append("END AS GroupMembers")

    Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add(groupMembers.ToString)
    sb.From.Add(My.Settings.Database & ".ddo_quests q")
    sb.Group.Add("GroupMembers")
    sb.Order.Add("GroupMembers")

    Try
      Return BCW.Data.MySqlDBResult.GetFieldList _
      (Of String)(_ConnectionString, sb.ToString)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return New List(Of String)
    End Try
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

  Private Sub onNewCharacterClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles newCharacterToolStripMenuItem.Click

    Dim name = InputBox("Charakternamen eingeben:", "Neuer Charakter")
    If name.Trim = "" Then Exit Sub

    Try
      Dim c = New Character(_ConnectionString, 0)
      c.CharacterName = name
      c.UserID = _LogedUser.UserID
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Neuer Charakter" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

    FillCharacters()
    For Each item As Character In charactersComboBox.Items
      If item.CharacterName = name Then
        charactersComboBox.SelectedItem = item
        Exit For
      End If
    Next item
  End Sub

  Private Sub onCharacterCommentValidated _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles characterCommentTextBox.Validated

    _Character.Comment = BCW.etc.Transform.ReplaceEscape _
    (characterCommentTextBox.Text)
  End Sub

  Private Sub onDeleteCharaterClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles deleteCharaterToolStripMenuItem.Click

    If _Character Is Nothing Then Exit Sub

    Select Case BCW.etc.Message.Question("Soll " & _Character.CharacterName _
    & " wirklich gelöscht werden?", "Charakter löschen")
    Case System.Windows.Forms.DialogResult.No
      Exit Sub
    End Select

    Try
      _Character.Delete()
    Catch ex As Exception
      BCW.etc.Message.ShowError(ex)
    End Try

    FillCharacters()
  End Sub

Private Sub characterTabControl_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles characterTabControl.SelectionChanged

End Sub

  Private Sub onVaultTreeViewAfterLabelEdit _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) _
  Handles vaultTreeView.AfterLabelEdit

    If vaultTreeView.SelectedNode Is Nothing Then Exit Sub

    DirectCast(vaultTreeView.SelectedNode.Tag, VaultEntry).Item = e.Label
  End Sub

  Private Sub onVaultTreeViewKeyDown _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles vaultTreeView.KeyDown


    Select Case e.KeyCode
    Case Keys.F2
      If vaultTreeView.SelectedNode Is Nothing Then Exit Sub
      vaultTreeView.SelectedNode.BeginEdit()
    Case Keys.Insert
      Dim v = New VaultEntry(_ConnectionString, 0)
      v.CharacterID = _Character.CharacterID
      v.Item = "Neuer Gegenstand"
      vaultTreeView.Nodes.Add(v.Item).Tag = v
      vaultTreeView.SelectedNode = vaultTreeView.Nodes.Item(vaultTreeView.Nodes.Count - 1)
      vaultTreeView.SelectedNode.BeginEdit()
    Case Keys.Delete
      If vaultTreeView.SelectedNode Is Nothing Then Exit Sub
      DirectCast(vaultTreeView.SelectedNode.Tag, VaultEntry).Delete()
      vaultTreeView.SelectedNode.Remove()
    End Select
  End Sub

  Private Sub onVaultCommentTextBoxValidated _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles vaultCommentTextBox.Validated

    If vaultTreeView.SelectedNode Is Nothing Then Exit Sub

    DirectCast(vaultTreeView.SelectedNode.Tag, VaultEntry).Comment _
    = vaultCommentTextBox.Text
  End Sub

  Private Sub onVaultTreeViewAfterSelect _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.TreeViewEventArgs) _
  Handles vaultTreeView.AfterSelect

    If e.Node Is Nothing Then Exit Sub

    vaultCommentTextBox.Text = DirectCast(e.Node.Tag, VaultEntry).Comment
  End Sub

Private Sub requestAccountButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles requestAccountButton.Click

  Dim responseAddress = ""
  Dim strBody = "TEST"


  Dim message As New MailMessage _
  (responseAddress _
  , "namrael@gmx.de" _
  , "Neuer Account" _
  , strBody)

  Dim emailClient As New SmtpClient("mail.gmx.de")
  emailClient.Send(message)

End Sub

Private Sub questsDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles questsDataGridView.CellContentClick

End Sub
End Class '{Klasse MainDialog}
End Namespace
