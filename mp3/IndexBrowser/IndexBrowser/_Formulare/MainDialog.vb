Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class MainDialog

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents endToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Private WithEvents mainFormMenuStrip As System.Windows.Forms.MenuStrip
Private WithEvents mainSplitContainer As System.Windows.Forms.SplitContainer
Private WithEvents mainStatusStrip As System.Windows.Forms.StatusStrip
Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
Private WithEvents loadIndexToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents mainDataGridView As System.Windows.Forms.DataGridView
Private WithEvents mainTreeView As System.Windows.Forms.TreeView
Private WithEvents artistColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents albumColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents trackColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents titleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents genreColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents yearColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents durationColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents commentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents sizeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents bitrateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents pathColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents nameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
Private WithEvents dataGridToolStrip As System.Windows.Forms.ToolStrip
Friend WithEvents quickSearchToolStripLabel As System.Windows.Forms.ToolStripLabel
Private WithEvents quickSearchToolStripTextBox As System.Windows.Forms.ToolStripTextBox
Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
Private WithEvents playColumn As System.Windows.Forms.DataGridViewImageColumn
Private WithEvents titleCountToolStripLabel As System.Windows.Forms.ToolStripLabel
Private WithEvents viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents visibleColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
Friend WithEvents mainTabControl As System.Windows.Forms.TabControl
Friend WithEvents titleCenterTabPage As System.Windows.Forms.TabPage
Friend WithEvents songTextTabPage As System.Windows.Forms.TabPage
Friend WithEvents mainWebBrowser As System.Windows.Forms.WebBrowser
Friend WithEvents id3TagsTabPage As System.Windows.Forms.TabPage
Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  ' Für Windows Form-Designer erforderlich
  Private components As System.ComponentModel.IContainer
    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDialog))
Me.mainToolStrip = New System.Windows.Forms.ToolStrip()
Me.loadIndexToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
Me.mainStatusStrip = New System.Windows.Forms.StatusStrip()
Me.mainSplitContainer = New System.Windows.Forms.SplitContainer()
Me.mainTreeView = New System.Windows.Forms.TreeView()
Me.mainTabControl = New System.Windows.Forms.TabControl()
Me.titleCenterTabPage = New System.Windows.Forms.TabPage()
Me.mainDataGridView = New System.Windows.Forms.DataGridView()
Me.dataGridToolStrip = New System.Windows.Forms.ToolStrip()
Me.quickSearchToolStripLabel = New System.Windows.Forms.ToolStripLabel()
Me.quickSearchToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
Me.titleCountToolStripLabel = New System.Windows.Forms.ToolStripLabel()
Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
Me.songTextTabPage = New System.Windows.Forms.TabPage()
Me.mainWebBrowser = New System.Windows.Forms.WebBrowser()
Me.id3TagsTabPage = New System.Windows.Forms.TabPage()
Me.DataGridView1 = New System.Windows.Forms.DataGridView()
Me.ListBox1 = New System.Windows.Forms.ListBox()
Me.mainFormMenuStrip = New System.Windows.Forms.MenuStrip()
Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.endToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.visibleColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.artistColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.albumColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.trackColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.titleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.genreColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.yearColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.durationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.commentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.sizeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.bitrateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.pathColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.playColumn = New System.Windows.Forms.DataGridViewImageColumn()
Me.mainToolStrip.SuspendLayout()
CType(Me.mainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.mainSplitContainer.Panel1.SuspendLayout()
Me.mainSplitContainer.Panel2.SuspendLayout()
Me.mainSplitContainer.SuspendLayout()
Me.mainTabControl.SuspendLayout()
Me.titleCenterTabPage.SuspendLayout()
CType(Me.mainDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.dataGridToolStrip.SuspendLayout()
Me.songTextTabPage.SuspendLayout()
Me.id3TagsTabPage.SuspendLayout()
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.mainFormMenuStrip.SuspendLayout()
Me.SuspendLayout()
'
'mainToolStrip
'
Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadIndexToolStripButton, Me.ToolStripButton1})
Me.mainToolStrip.Location = New System.Drawing.Point(0, 24)
Me.mainToolStrip.Name = "mainToolStrip"
Me.mainToolStrip.Size = New System.Drawing.Size(668, 25)
Me.mainToolStrip.TabIndex = 0
Me.mainToolStrip.Text = "ToolStrip1"
'
'loadIndexToolStripButton
'
Me.loadIndexToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.loadIndexToolStripButton.Image = Global.SSP.IndexBrowser.My.Resources.Resources.open16x16
Me.loadIndexToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.loadIndexToolStripButton.Name = "loadIndexToolStripButton"
Me.loadIndexToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.loadIndexToolStripButton.ToolTipText = "Index laden"
'
'ToolStripButton1
'
Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
Me.ToolStripButton1.Name = "ToolStripButton1"
Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
Me.ToolStripButton1.Text = "ToolStripButton1"
'
'mainStatusStrip
'
Me.mainStatusStrip.Location = New System.Drawing.Point(0, 342)
Me.mainStatusStrip.Name = "mainStatusStrip"
Me.mainStatusStrip.Size = New System.Drawing.Size(668, 22)
Me.mainStatusStrip.TabIndex = 1
Me.mainStatusStrip.Text = "StatusStrip1"
'
'mainSplitContainer
'
Me.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.mainSplitContainer.Location = New System.Drawing.Point(0, 49)
Me.mainSplitContainer.Name = "mainSplitContainer"
'
'mainSplitContainer.Panel1
'
Me.mainSplitContainer.Panel1.Controls.Add(Me.mainTreeView)
'
'mainSplitContainer.Panel2
'
Me.mainSplitContainer.Panel2.Controls.Add(Me.mainTabControl)
Me.mainSplitContainer.Size = New System.Drawing.Size(668, 293)
Me.mainSplitContainer.SplitterDistance = 222
Me.mainSplitContainer.TabIndex = 2
'
'mainTreeView
'
Me.mainTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainTreeView.HideSelection = False
Me.mainTreeView.Location = New System.Drawing.Point(0, 0)
Me.mainTreeView.Name = "mainTreeView"
Me.mainTreeView.Size = New System.Drawing.Size(222, 293)
Me.mainTreeView.TabIndex = 1
'
'mainTabControl
'
Me.mainTabControl.Controls.Add(Me.titleCenterTabPage)
Me.mainTabControl.Controls.Add(Me.songTextTabPage)
Me.mainTabControl.Controls.Add(Me.id3TagsTabPage)
Me.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainTabControl.Location = New System.Drawing.Point(0, 0)
Me.mainTabControl.Name = "mainTabControl"
Me.mainTabControl.SelectedIndex = 0
Me.mainTabControl.Size = New System.Drawing.Size(442, 293)
Me.mainTabControl.TabIndex = 2
'
'titleCenterTabPage
'
Me.titleCenterTabPage.Controls.Add(Me.mainDataGridView)
Me.titleCenterTabPage.Controls.Add(Me.dataGridToolStrip)
Me.titleCenterTabPage.Location = New System.Drawing.Point(4, 22)
Me.titleCenterTabPage.Name = "titleCenterTabPage"
Me.titleCenterTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.titleCenterTabPage.Size = New System.Drawing.Size(434, 267)
Me.titleCenterTabPage.TabIndex = 0
Me.titleCenterTabPage.Text = "Titel-Center"
Me.titleCenterTabPage.UseVisualStyleBackColor = True
'
'mainDataGridView
'
Me.mainDataGridView.AllowUserToAddRows = False
Me.mainDataGridView.AllowUserToDeleteRows = False
Me.mainDataGridView.AllowUserToResizeRows = False
Me.mainDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
Me.mainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.mainDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainDataGridView.Location = New System.Drawing.Point(3, 28)
Me.mainDataGridView.Name = "mainDataGridView"
Me.mainDataGridView.RowHeadersVisible = False
Me.mainDataGridView.Size = New System.Drawing.Size(428, 236)
Me.mainDataGridView.TabIndex = 0
'
'dataGridToolStrip
'
Me.dataGridToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.dataGridToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.quickSearchToolStripLabel, Me.quickSearchToolStripTextBox, Me.titleCountToolStripLabel, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5})
Me.dataGridToolStrip.Location = New System.Drawing.Point(3, 3)
Me.dataGridToolStrip.Name = "dataGridToolStrip"
Me.dataGridToolStrip.Size = New System.Drawing.Size(428, 25)
Me.dataGridToolStrip.TabIndex = 1
Me.dataGridToolStrip.Text = "ToolStrip1"
'
'quickSearchToolStripLabel
'
Me.quickSearchToolStripLabel.Image = Global.SSP.IndexBrowser.My.Resources.Resources.filter16x16
Me.quickSearchToolStripLabel.Name = "quickSearchToolStripLabel"
Me.quickSearchToolStripLabel.Size = New System.Drawing.Size(98, 22)
Me.quickSearchToolStripLabel.Text = "Schnellsuche: "
'
'quickSearchToolStripTextBox
'
Me.quickSearchToolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.quickSearchToolStripTextBox.Name = "quickSearchToolStripTextBox"
Me.quickSearchToolStripTextBox.Size = New System.Drawing.Size(200, 25)
'
'titleCountToolStripLabel
'
Me.titleCountToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
Me.titleCountToolStripLabel.Name = "titleCountToolStripLabel"
Me.titleCountToolStripLabel.Size = New System.Drawing.Size(13, 22)
Me.titleCountToolStripLabel.Text = "0"
'
'ToolStripButton2
'
Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.ToolStripButton2.Image = Global.SSP.IndexBrowser.My.Resources.Resources.filter_artist16x16
Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
Me.ToolStripButton2.Name = "ToolStripButton2"
Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
Me.ToolStripButton2.Text = "ToolStripButton2"
'
'ToolStripButton3
'
Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.ToolStripButton3.Image = Global.SSP.IndexBrowser.My.Resources.Resources.filter_album16x16
Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
Me.ToolStripButton3.Name = "ToolStripButton3"
Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
Me.ToolStripButton3.Text = "ToolStripButton3"
'
'ToolStripButton4
'
Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.ToolStripButton4.Image = Global.SSP.IndexBrowser.My.Resources.Resources.filter_song16x16
Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
Me.ToolStripButton4.Name = "ToolStripButton4"
Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
Me.ToolStripButton4.Text = "ToolStripButton4"
'
'ToolStripButton5
'
Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.ToolStripButton5.Image = Global.SSP.IndexBrowser.My.Resources.Resources.filter_genre16x16
Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
Me.ToolStripButton5.Name = "ToolStripButton5"
Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
Me.ToolStripButton5.Text = "ToolStripButton5"
'
'songTextTabPage
'
Me.songTextTabPage.Controls.Add(Me.mainWebBrowser)
Me.songTextTabPage.Location = New System.Drawing.Point(4, 22)
Me.songTextTabPage.Name = "songTextTabPage"
Me.songTextTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.songTextTabPage.Size = New System.Drawing.Size(434, 267)
Me.songTextTabPage.TabIndex = 1
Me.songTextTabPage.Text = "Songtext"
Me.songTextTabPage.UseVisualStyleBackColor = True
'
'mainWebBrowser
'
Me.mainWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainWebBrowser.Location = New System.Drawing.Point(3, 3)
Me.mainWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
Me.mainWebBrowser.Name = "mainWebBrowser"
Me.mainWebBrowser.ScriptErrorsSuppressed = True
Me.mainWebBrowser.Size = New System.Drawing.Size(428, 261)
Me.mainWebBrowser.TabIndex = 0
'
'id3TagsTabPage
'
Me.id3TagsTabPage.Controls.Add(Me.DataGridView1)
Me.id3TagsTabPage.Controls.Add(Me.ListBox1)
Me.id3TagsTabPage.Location = New System.Drawing.Point(4, 22)
Me.id3TagsTabPage.Name = "id3TagsTabPage"
Me.id3TagsTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.id3TagsTabPage.Size = New System.Drawing.Size(434, 267)
Me.id3TagsTabPage.TabIndex = 2
Me.id3TagsTabPage.Text = "ID3-Tags"
Me.id3TagsTabPage.UseVisualStyleBackColor = True
'
'DataGridView1
'
Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.DataGridView1.Location = New System.Drawing.Point(6, 81)
Me.DataGridView1.Name = "DataGridView1"
Me.DataGridView1.Size = New System.Drawing.Size(422, 180)
Me.DataGridView1.TabIndex = 1
'
'ListBox1
'
Me.ListBox1.FormattingEnabled = True
Me.ListBox1.Location = New System.Drawing.Point(6, 6)
Me.ListBox1.Name = "ListBox1"
Me.ListBox1.Size = New System.Drawing.Size(266, 69)
Me.ListBox1.TabIndex = 0
'
'mainFormMenuStrip
'
Me.mainFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.viewToolStripMenuItem})
Me.mainFormMenuStrip.Location = New System.Drawing.Point(0, 0)
Me.mainFormMenuStrip.Name = "mainFormMenuStrip"
Me.mainFormMenuStrip.Size = New System.Drawing.Size(668, 24)
Me.mainFormMenuStrip.TabIndex = 3
Me.mainFormMenuStrip.Text = "MenuStrip1"
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
'viewToolStripMenuItem
'
Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.visibleColumnsToolStripMenuItem})
Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
Me.viewToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
Me.viewToolStripMenuItem.Text = "Ansicht"
'
'visibleColumnsToolStripMenuItem
'
Me.visibleColumnsToolStripMenuItem.Name = "visibleColumnsToolStripMenuItem"
Me.visibleColumnsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
Me.visibleColumnsToolStripMenuItem.Text = "Sichtbare Spalten ..."
'
'artistColumn
'
Me.artistColumn.DataPropertyName = "artist"
Me.artistColumn.HeaderText = "Interpret"
Me.artistColumn.Name = "artistColumn"
'
'albumColumn
'
Me.albumColumn.DataPropertyName = "album"
Me.albumColumn.HeaderText = "Album"
Me.albumColumn.Name = "albumColumn"
'
'trackColumn
'
Me.trackColumn.DataPropertyName = "track"
Me.trackColumn.HeaderText = "Track"
Me.trackColumn.Name = "trackColumn"
Me.trackColumn.Width = 40
'
'titleColumn
'
Me.titleColumn.DataPropertyName = "title"
Me.titleColumn.HeaderText = "Titel"
Me.titleColumn.Name = "titleColumn"
'
'genreColumn
'
Me.genreColumn.DataPropertyName = "genre"
Me.genreColumn.HeaderText = "Genre"
Me.genreColumn.Name = "genreColumn"
'
'yearColumn
'
Me.yearColumn.DataPropertyName = "year"
Me.yearColumn.HeaderText = "Jahr"
Me.yearColumn.Name = "yearColumn"
Me.yearColumn.Width = 50
'
'durationColumn
'
Me.durationColumn.DataPropertyName = "duration"
Me.durationColumn.HeaderText = "Spiellänge"
Me.durationColumn.Name = "durationColumn"
Me.durationColumn.Width = 60
'
'commentColumn
'
Me.commentColumn.DataPropertyName = "comment"
Me.commentColumn.HeaderText = "Kommentar"
Me.commentColumn.Name = "commentColumn"
'
'sizeColumn
'
Me.sizeColumn.DataPropertyName = "size"
Me.sizeColumn.HeaderText = "Größe"
Me.sizeColumn.Name = "sizeColumn"
Me.sizeColumn.Width = 70
'
'bitrateColumn
'
Me.bitrateColumn.DataPropertyName = "bitrate"
Me.bitrateColumn.HeaderText = "Bitrate"
Me.bitrateColumn.Name = "bitrateColumn"
Me.bitrateColumn.Width = 40
'
'pathColumn
'
Me.pathColumn.DataPropertyName = "path"
Me.pathColumn.HeaderText = "Verzeichnis"
Me.pathColumn.Name = "pathColumn"
Me.pathColumn.Visible = False
'
'nameColumn
'
Me.nameColumn.DataPropertyName = "name"
Me.nameColumn.HeaderText = "Name"
Me.nameColumn.Name = "nameColumn"
Me.nameColumn.Visible = False
'
'playColumn
'
Me.playColumn.HeaderText = ""
Me.playColumn.Image = CType(resources.GetObject("playColumn.Image"), System.Drawing.Image)
Me.playColumn.Name = "playColumn"
Me.playColumn.Width = 20
'
'MainDialog
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(668, 364)
Me.Controls.Add(Me.mainSplitContainer)
Me.Controls.Add(Me.mainStatusStrip)
Me.Controls.Add(Me.mainToolStrip)
Me.Controls.Add(Me.mainFormMenuStrip)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.KeyPreview = True
Me.MainMenuStrip = Me.mainFormMenuStrip
Me.Name = "MainDialog"
Me.Text = "IndexBrowser"
Me.mainToolStrip.ResumeLayout(False)
Me.mainToolStrip.PerformLayout()
Me.mainSplitContainer.Panel1.ResumeLayout(False)
Me.mainSplitContainer.Panel2.ResumeLayout(False)
CType(Me.mainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.mainSplitContainer.ResumeLayout(False)
Me.mainTabControl.ResumeLayout(False)
Me.titleCenterTabPage.ResumeLayout(False)
Me.titleCenterTabPage.PerformLayout()
CType(Me.mainDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.dataGridToolStrip.ResumeLayout(False)
Me.dataGridToolStrip.PerformLayout()
Me.songTextTabPage.ResumeLayout(False)
Me.id3TagsTabPage.ResumeLayout(False)
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
Me.mainFormMenuStrip.ResumeLayout(False)
Me.mainFormMenuStrip.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum NodeLevels
    Root = 0
    Register = 1
    Artist = 2
    Album = 3
    Title = 4
  End Enum

  Private Enum ColumnNames
    PlayColumn = 0
    ArtistColumn = 1
    AlbumColumn = 2
    TrackColumn = 3
    TitleColumn = 4
    GenreColumn = 5
    YearColumn = 6
    DurationColumn = 7
    CommentColumn = 8
    SizeColumn = 9
    BitrateColumn10
    PathColumn = 11
    NameColumn = 12
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _CurrentIndex As SSP.IndexerLibrary.IndexBuilder
  Private _CurrentFilesTable As SSP.IndexerLibrary.IndexDataSet.fileDataTable
  Private _imageList As New ImageList

  Private Const _LyricsUrl As String = "http://lyrics.wikia.com/"
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
    '{Konstruktor}
    MyBase.New()
    InitializeComponent()

    _imageList.ColorDepth = ColorDepth.Depth32Bit
    _imageList.Images.Add("folder", My.Resources.folder_black16x16)
    _imageList.Images.Add("artist", My.Resources.artist16x16)
    _imageList.Images.Add("album", My.Resources.album16x16)
    _imageList.Images.Add("title", My.Resources.song16x16)
    mainTreeView.ImageList = _imageList
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
  Private Property CellValue _
  (ByVal column As ColumnNames _
  , ByVal rowIndex As Int32) As String
  Get
    Return mainDataGridView.Rows.Item(rowIndex).Cells.Item(column.ToString).Value.ToString()
  End Get
  Set(ByVal value As String)
    mainDataGridView.Rows.Item(rowIndex).Cells.Item(column.ToString).Value = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

  Private Sub ShowSongtext()

    mainWebBrowser.Visible = False

    If mainDataGridView.CurrentCell Is Nothing Then Exit Sub

    Dim artist = Me.CellValue(ColumnNames.ArtistColumn, mainDataGridView.CurrentRow.Index)
    Dim title = Me.CellValue(ColumnNames.TitleColumn, mainDataGridView.CurrentRow.Index)
    Dim url = _LyricsUrl & artist.Replace(" ", "_") & ":" & title.Replace(" ", "_")

    If (mainWebBrowser.Url Is Nothing) _
    OrElse (Not String.Equals _
    (mainWebBrowser.Url.ToString, url _
    , StringComparison.OrdinalIgnoreCase)) Then
      mainWebBrowser.Navigate(url)
    End If

    mainWebBrowser.Visible = True
  End Sub

  Private Sub onLoadIndexClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles loadIndexToolStripButton.Click

    PrepareLoadIndex()
  End Sub

  Private Sub InitializeColumnHeader()
    With Me.mainDataGridView.Columns
      .Clear()
      .Add(Me.playColumn)
      .Add(Me.artistColumn)
      .Add(Me.albumColumn)
      .Add(Me.trackColumn)
      .Add(Me.titleColumn)
      .Add(Me.genreColumn)
      .Add(Me.yearColumn)
      .Add(Me.durationColumn)
      .Add(Me.commentColumn)
      .Add(Me.sizeColumn)
      .Add(Me.bitrateColumn)
      .Add(Me.pathColumn)
      .Add(Me.nameColumn)
    End With
  End Sub

  Private Function GetIndexFileInfo() As IO.FileInfo
    Dim ofd As New System.Windows.Forms.OpenFileDialog
    ofd.CheckFileExists = True
    ofd.CheckPathExists = True

    ofd.Filter = "xml (*.xml)|*.xml"
    ofd.FilterIndex = 1
    ofd.Multiselect = False
    ofd.RestoreDirectory = True
    ofd.ShowHelp = False
    ofd.ShowReadOnly = False
    ofd.SupportMultiDottedExtensions = True
    ofd.Title = "Bitte Index wählen ..."

    Select Case ofd.ShowDialog
    Case System.Windows.Forms.DialogResult.Cancel
      Return Nothing
    Case Else
      Return New IO.FileInfo(ofd.FileName)
    End Select
  End Function

  Private Sub PrepareLoadIndex()
    Dim fi = GetIndexFileInfo()
    If fi Is Nothing Then Exit Sub

    My.Settings.IndexName = fi.Name.Replace(fi.Extension, "")
    My.Settings.IndexPath = fi.DirectoryName
    My.Settings.Save()
    LoadIndex(My.Settings.IndexPath, My.Settings.IndexName)
  End Sub

  Private Sub LoadIndex _
  (ByVal indexPath As String _
  , ByVal indexName As String)

    Try
      _CurrentIndex = New SSP.IndexerLibrary.IndexBuilder _
      (indexName, indexPath)
      _CurrentFilesTable = _CurrentIndex.IndexData.file
      SetView("")
      'mainDataGridView.DataSource = _CurrentFilesTable

      InitializeColumnHeader()
      SetColumnsVisible()

      InsertRegister(indexName)
    Catch ex As Exception
      BCW.etc.Message.Error _
      ("Index-Ladefehler!", "Index laden")
    End Try
  End Sub

  Private Sub onTeeViewAfterSelect _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.TreeViewEventArgs) _
  Handles mainTreeView.AfterSelect

    Select Case CType(e.Node.Tag, NodeLevels)
    Case NodeLevels.Root
      SetView("")
    Case NodeLevels.Register
      InsertArtists(e.Node, CType(e.Node.Text, Char))
      SetView("(artist LIKE '" & e.Node.Text & "*')")
    Case NodeLevels.Artist
      InsertAlbums(e.Node, e.Node.Text)
      SetView("(artist = '" & e.Node.Text & "')")
    Case NodeLevels.Album
      InsertTitles(e.Node, e.Node.Parent.Text, e.Node.Text)
      SetView("(artist = '" & e.Node.Parent.Text _
      & "') AND (album = '" & e.Node.Text & "')")
    Case NodeLevels.Title
      SetView("(artist = '" & e.Node.Parent.Parent.Text _
      & "') AND (album = '" & e.Node.Parent.Text _
      & "') AND (title = '" & e.Node.Text & "')")
    End Select
  End Sub

  Private Sub SetView(ByVal filter As String)
    If _CurrentFilesTable Is Nothing Then Exit Sub
    Dim view = New DataView(_CurrentFilesTable)
    view.RowFilter = filter
    mainDataGridView.DataSource = view
    titleCountToolStripLabel.Text = mainDataGridView.Rows.Count.ToString
  End Sub

  Private Sub InsertRegister(ByVal indexName As String)
    mainTreeView.Nodes.Clear()

    Dim root = mainTreeView.Nodes.Add(indexName)
    root.Tag = NodeLevels.Root
    root.SelectedImageKey = "folder"
    root.ImageKey = "folder"

    For Each s In _CurrentIndex.IndexData.GetRegister
      Dim n = root.Nodes.Add(s)
      n.Tag = NodeLevels.Register
      n.SelectedImageKey = "folder"
      n.ImageKey = "folder"
    Next s
  End Sub

  Private Sub InsertArtists _
  (ByVal parent As TreeNode, ByVal letter As Char)

    If parent.Nodes.Count > 0 Then Exit Sub

    For Each artist In _CurrentIndex.IndexData.GetArtistsByFirstLetter(letter)
      InsertArtist(parent, artist)
    Next artist
  End Sub

  Private Function InsertArtist _
  (ByVal parent As TreeNode, ByVal artist As String) _
  As TreeNode

    Dim n = parent.Nodes.Add(artist)
    n.Tag = NodeLevels.Artist
    n.SelectedImageKey = "artist"
    n.ImageKey = "artist"
    Return n
  End Function

  Private Sub InsertAlbums _
  (ByVal parent As TreeNode, ByVal artist As String)

    If parent.Nodes.Count > 0 Then Exit Sub

    For Each album In _CurrentIndex.IndexData.GetAlbumsByArtist(artist)
      InsertAlbum(parent, album)
    Next album
  End Sub

  Private Function InsertAlbum _
  (ByVal parent As TreeNode, ByVal album As String) _
  As TreeNode

    Dim n = parent.Nodes.Add(album)
    n.Tag = NodeLevels.Album
    n.SelectedImageKey = "album"
    n.ImageKey = "album"
    Return n
  End Function

  Private Sub InsertTitles _
  (ByVal parent As TreeNode _
  , ByVal artist As String _
  , ByVal album As String)

    If parent.Nodes.Count > 0 Then Exit Sub

    For Each title In _
    _CurrentIndex.IndexData.GetTitlesByArtistAndAlbum _
    (artist, album)

      InsertTitle(parent, title)
    Next title
  End Sub

  Private Function InsertTitle _
  (ByVal parent As TreeNode _
  , ByVal title As SSP.IndexerLibrary.Title) _
  As TreeNode

    Dim n = parent.Nodes.Add(title.ToString)
    n.Tag = NodeLevels.Title
    n.SelectedImageKey = "title"
    n.ImageKey = "title"
    Return n
  End Function

  Private Sub onMainDialogKeyUp _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.KeyEventArgs) _
  Handles Me.KeyUp

    Select Case e.KeyCode
    Case Keys.F3
      quickSearchToolStripTextBox.Focus()
      quickSearchToolStripTextBox.SelectAll()
    End Select
  End Sub

  Private Sub onMainDialogShown _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles Me.Shown

    CheckIndex()
  End Sub

  Private Sub CheckIndex()
    If (String.IsNullOrEmpty(My.Settings.IndexPath)) _
    OrElse (String.IsNullOrEmpty(My.Settings.IndexName)) Then Exit Sub

    Dim fileName = My.Computer.FileSystem.CombinePath _
    (My.Settings.IndexPath _
    , My.Settings.IndexName & ".xml")

    If Not My.Computer.FileSystem.FileExists(fileName) Then Exit Sub

    LoadIndex(My.Settings.IndexPath, My.Settings.IndexName)
  End Sub

  Private Sub onEndClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles endToolStripMenuItem.Click
    Me.Close()
  End Sub

  Private Sub onQuickSearchTextChanged _
  (ByVal sender As Object, ByVal e As System.EventArgs) _
  Handles quickSearchToolStripTextBox.TextChanged

    QuickSearch(quickSearchToolStripTextBox.Text)
  End Sub

  Private Sub QuickSearch(ByVal value As String)
    If _CurrentFilesTable Is Nothing Then Exit Sub
    Dim sb = New System.Text.StringBuilder
    sb.Append("(artist LIKE '" & value & "*') ")
    sb.Append("OR (album LIKE '" & value & "*') ")
    sb.Append("OR (title LIKE '" & value & "*') ")
    sb.Append("OR (genre LIKE '" & value & "*')")
    SetView(sb.ToString)
  End Sub

  Private Sub SetColumnsVisible()
    With mainDataGridView.Columns
      .Item("artistColumn").Visible = My.Settings.artistColumnVisible
      .Item("artistColumn").Visible = My.Settings.artistColumnVisible
      .Item("albumColumn").Visible = My.Settings.albumColumnVisible
      .Item("trackColumn").Visible = My.Settings.trackColumnVisible
      .Item("titleColumn").Visible = My.Settings.titleColumnVisible
      .Item("genreColumn").Visible = My.Settings.genreColumnVisible
      .Item("yearColumn").Visible = My.Settings.yearColumnVisible
      .Item("durationColumn").Visible = My.Settings.durationColumnVisible
      .Item("commentColumn").Visible = My.Settings.commentColumnVisible
      .Item("sizeColumn").Visible = My.Settings.sizeColumnVisible
      .Item("bitrateColumn").Visible = My.Settings.bitrateColumnVisible
      .Item("pathColumn").Visible = My.Settings.pathColumnVisible
      .Item("nameColumn").Visible = My.Settings.nameColumnVisible
    End With
  End Sub

  Private Sub ShowVisibleColumns()
    Dim f = New VisibleColumnsDialog
    Select Case f.ShowDialog
    Case System.Windows.Forms.DialogResult.Cancel
      Exit Sub
    End Select
    SetColumnsVisible()
  End Sub

  Private Sub onCellContentClick _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
  Handles mainDataGridView.CellContentClick

    PlayTitle(e.ColumnIndex, e.RowIndex)
  End Sub

  Private Function IsPlayColumn _
  (ByVal columnIndex As Int32) As Boolean

    Return mainDataGridView.Columns.Item(columnIndex) Is playColumn
  End Function

  Private Sub PlayTitle _
  (ByVal columnIndex As Int32 _
  , ByVal rowIndex As Int32)

    If Not IsPlayColumn(columnIndex) Then Exit Sub

    Dim path = Me.CellValue(ColumnNames.PathColumn, rowIndex)
    Dim name = Me.CellValue(ColumnNames.NameColumn, rowIndex)
    Try
      Process.Start(My.Computer.FileSystem.CombinePath(path, name))
    Catch ex As Exception
      BCW.etc.Message.ShowError(ex)
    End Try
  End Sub

  Private Sub onVisibleColumnsClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles visibleColumnsToolStripMenuItem.Click

    ShowVisibleColumns()
  End Sub

  Private Sub onTabControlChanged _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles mainTabControl.SelectedIndexChanged

    Select Case True
    Case mainTabControl.SelectedTab Is titleCenterTabPage
    Case mainTabControl.SelectedTab Is songTextTabPage
      ShowSongtext()
    Case mainTabControl.SelectedTab Is id3TagsTabPage
      ListBox1.Items.Clear()

      Dim ret = From item In mainDataGridView.SelectedCells _
      Select DirectCast(item, DataGridViewCell).RowIndex Distinct

      Dim dt = New DataTable("id3")

      For Each c As DataColumn In _CurrentFilesTable.Columns
        dt.Columns.Add(c.ColumnName)
      Next c

      With mainDataGridView
        For Each rowindex In ret
          ListBox1.Items.Add(Me.CellValue(ColumnNames.NameColumn, rowindex))

          Dim r = mainDataGridView.Rows.Item(rowindex)
          Dim newRow = dt.NewRow

          For i = 1 To dt.Columns.Count - 1

            newRow.Item(i - 1) = r.Cells.Item(i).Value

          Next i
          dt.Rows.Add(newRow)

          DataGridView1.DataSource = dt
       Next rowindex
      End With
    End Select
  End Sub
End Class '{Klasse MainDialog}

End Namespace
