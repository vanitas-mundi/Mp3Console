Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class MainForm

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents mainStatusStrip As System.Windows.Forms.StatusStrip
Private WithEvents mainTabControl As System.Windows.Forms.TabControl
Private WithEvents ftpTabPage As System.Windows.Forms.TabPage
Private WithEvents ftpSplitContainer As System.Windows.Forms.SplitContainer
Private WithEvents mainFTPbrowser As BCW.FtpLib.Windows.Forms.FTPbrowser
Private WithEvents pagesTabPage As System.Windows.Forms.TabPage
Private WithEvents pagesSplitContainer As System.Windows.Forms.SplitContainer
Private WithEvents editorSplitContainer As System.Windows.Forms.SplitContainer
Private WithEvents pagePropertyGrid As System.Windows.Forms.PropertyGrid
Private WithEvents ftpTabContainer As BCW.TabbedBrowsing.Windows.Forms.TabContainer
Private WithEvents pageEditorControl As SSP.MyPage.Windows.Forms.EditorControl
Private WithEvents PageExplorerControl As SSP.MyPage.Windows.Forms.PageExplorerControl
Friend WithEvents mainFromMenuStrip As System.Windows.Forms.MenuStrip
Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents endToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
Friend WithEvents htmlEditorTabPage As System.Windows.Forms.TabPage
Friend WithEvents mainHtmlEditorControl As SSP.MyPage.Windows.Forms.HtmlEditorControl

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.mainStatusStrip = New System.Windows.Forms.StatusStrip()
Me.mainTabControl = New System.Windows.Forms.TabControl()
Me.ftpTabPage = New System.Windows.Forms.TabPage()
Me.ftpSplitContainer = New System.Windows.Forms.SplitContainer()
Me.mainFTPbrowser = New BCW.FtpLib.Windows.Forms.FTPbrowser()
Me.ftpTabContainer = New BCW.TabbedBrowsing.Windows.Forms.TabContainer()
Me.pagesTabPage = New System.Windows.Forms.TabPage()
Me.mainFromMenuStrip = New System.Windows.Forms.MenuStrip()
Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.endToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
Me.htmlEditorTabPage = New System.Windows.Forms.TabPage()
Me.pagesSplitContainer = New System.Windows.Forms.SplitContainer()
Me.PageExplorerControl = New SSP.MyPage.Windows.Forms.PageExplorerControl()
Me.editorSplitContainer = New System.Windows.Forms.SplitContainer()
Me.pagePropertyGrid = New System.Windows.Forms.PropertyGrid()
Me.pageEditorControl = New SSP.MyPage.Windows.Forms.EditorControl()
Me.mainHtmlEditorControl = New SSP.MyPage.Windows.Forms.HtmlEditorControl()
Me.mainTabControl.SuspendLayout()
Me.ftpTabPage.SuspendLayout()
CType(Me.ftpSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.ftpSplitContainer.Panel1.SuspendLayout()
Me.ftpSplitContainer.Panel2.SuspendLayout()
Me.ftpSplitContainer.SuspendLayout()
Me.pagesTabPage.SuspendLayout()
Me.mainFromMenuStrip.SuspendLayout()
Me.htmlEditorTabPage.SuspendLayout()
CType(Me.pagesSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.pagesSplitContainer.Panel1.SuspendLayout()
Me.pagesSplitContainer.Panel2.SuspendLayout()
Me.pagesSplitContainer.SuspendLayout()
CType(Me.editorSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.editorSplitContainer.Panel1.SuspendLayout()
Me.editorSplitContainer.Panel2.SuspendLayout()
Me.editorSplitContainer.SuspendLayout()
Me.SuspendLayout()
'
'mainStatusStrip
'
Me.mainStatusStrip.Location = New System.Drawing.Point(0, 279)
Me.mainStatusStrip.Name = "mainStatusStrip"
Me.mainStatusStrip.Size = New System.Drawing.Size(561, 22)
Me.mainStatusStrip.TabIndex = 5
Me.mainStatusStrip.Text = "StatusStrip1"
'
'mainTabControl
'
Me.mainTabControl.Controls.Add(Me.ftpTabPage)
Me.mainTabControl.Controls.Add(Me.pagesTabPage)
Me.mainTabControl.Controls.Add(Me.htmlEditorTabPage)
Me.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainTabControl.Location = New System.Drawing.Point(0, 24)
Me.mainTabControl.Name = "mainTabControl"
Me.mainTabControl.SelectedIndex = 0
Me.mainTabControl.Size = New System.Drawing.Size(561, 255)
Me.mainTabControl.TabIndex = 6
'
'ftpTabPage
'
Me.ftpTabPage.Controls.Add(Me.ftpSplitContainer)
Me.ftpTabPage.Location = New System.Drawing.Point(4, 22)
Me.ftpTabPage.Name = "ftpTabPage"
Me.ftpTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.ftpTabPage.Size = New System.Drawing.Size(553, 229)
Me.ftpTabPage.TabIndex = 0
Me.ftpTabPage.Text = "FTP"
Me.ftpTabPage.UseVisualStyleBackColor = True
'
'ftpSplitContainer
'
Me.ftpSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.ftpSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.ftpSplitContainer.Location = New System.Drawing.Point(3, 3)
Me.ftpSplitContainer.Name = "ftpSplitContainer"
'
'ftpSplitContainer.Panel1
'
Me.ftpSplitContainer.Panel1.Controls.Add(Me.mainFTPbrowser)
'
'ftpSplitContainer.Panel2
'
Me.ftpSplitContainer.Panel2.Controls.Add(Me.ftpTabContainer)
Me.ftpSplitContainer.Size = New System.Drawing.Size(547, 223)
Me.ftpSplitContainer.SplitterDistance = 220
Me.ftpSplitContainer.TabIndex = 4
'
'mainFTPbrowser
'
Me.mainFTPbrowser.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainFTPbrowser.Hostname = Nothing
Me.mainFTPbrowser.Location = New System.Drawing.Point(0, 0)
Me.mainFTPbrowser.Name = "mainFTPbrowser"
Me.mainFTPbrowser.Padding = New System.Windows.Forms.Padding(4)
Me.mainFTPbrowser.Password = Nothing
Me.mainFTPbrowser.Size = New System.Drawing.Size(220, 223)
Me.mainFTPbrowser.TabIndex = 6
Me.mainFTPbrowser.UserName = Nothing
'
'ftpTabContainer
'
Me.ftpTabContainer.AutoDockMidiParent = True
Me.ftpTabContainer.AutoScroll = True
Me.ftpTabContainer.BackColor = System.Drawing.Color.DimGray
Me.ftpTabContainer.Dock = System.Windows.Forms.DockStyle.Top
Me.ftpTabContainer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ftpTabContainer.ForeColor = System.Drawing.Color.White
Me.ftpTabContainer.GradiantColorDark = System.Drawing.Color.Black
Me.ftpTabContainer.GradiantColorLight = System.Drawing.Color.DarkGray
Me.ftpTabContainer.IndividualTabPageColor = False
Me.ftpTabContainer.Location = New System.Drawing.Point(0, 0)
Me.ftpTabContainer.Name = "ftpTabContainer"
Me.ftpTabContainer.SelectedTabPage = Nothing
Me.ftpTabContainer.Size = New System.Drawing.Size(323, 24)
Me.ftpTabContainer.TabIndex = 1
'
'pagesTabPage
'
Me.pagesTabPage.Controls.Add(Me.pagesSplitContainer)
Me.pagesTabPage.Location = New System.Drawing.Point(4, 22)
Me.pagesTabPage.Name = "pagesTabPage"
Me.pagesTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.pagesTabPage.Size = New System.Drawing.Size(553, 229)
Me.pagesTabPage.TabIndex = 1
Me.pagesTabPage.Text = "Pages"
Me.pagesTabPage.UseVisualStyleBackColor = True
'
'mainFromMenuStrip
'
Me.mainFromMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
Me.mainFromMenuStrip.Location = New System.Drawing.Point(0, 0)
Me.mainFromMenuStrip.Name = "mainFromMenuStrip"
Me.mainFromMenuStrip.Size = New System.Drawing.Size(561, 24)
Me.mainFromMenuStrip.TabIndex = 7
Me.mainFromMenuStrip.Text = "MenuStrip1"
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
'htmlEditorTabPage
'
Me.htmlEditorTabPage.Controls.Add(Me.mainHtmlEditorControl)
Me.htmlEditorTabPage.Location = New System.Drawing.Point(4, 22)
Me.htmlEditorTabPage.Name = "htmlEditorTabPage"
Me.htmlEditorTabPage.Padding = New System.Windows.Forms.Padding(3)
Me.htmlEditorTabPage.Size = New System.Drawing.Size(553, 229)
Me.htmlEditorTabPage.TabIndex = 2
Me.htmlEditorTabPage.Text = "HTML-Editor"
Me.htmlEditorTabPage.UseVisualStyleBackColor = True
'
'pagesSplitContainer
'
Me.pagesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.pagesSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.pagesSplitContainer.Location = New System.Drawing.Point(3, 3)
Me.pagesSplitContainer.Name = "pagesSplitContainer"
'
'pagesSplitContainer.Panel1
'
Me.pagesSplitContainer.Panel1.Controls.Add(Me.PageExplorerControl)
'
'pagesSplitContainer.Panel2
'
Me.pagesSplitContainer.Panel2.Controls.Add(Me.editorSplitContainer)
Me.pagesSplitContainer.Size = New System.Drawing.Size(547, 223)
Me.pagesSplitContainer.SplitterDistance = 300
Me.pagesSplitContainer.TabIndex = 4
'
'PageExplorerControl
'
Me.PageExplorerControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.PageExplorerControl.Location = New System.Drawing.Point(0, 0)
Me.PageExplorerControl.Name = "PageExplorerControl"
Me.PageExplorerControl.Padding = New System.Windows.Forms.Padding(4)
Me.PageExplorerControl.Size = New System.Drawing.Size(300, 223)
Me.PageExplorerControl.TabIndex = 4
'
'editorSplitContainer
'
Me.editorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
Me.editorSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.editorSplitContainer.Location = New System.Drawing.Point(0, 0)
Me.editorSplitContainer.Name = "editorSplitContainer"
Me.editorSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
'
'editorSplitContainer.Panel1
'
Me.editorSplitContainer.Panel1.Controls.Add(Me.pagePropertyGrid)
'
'editorSplitContainer.Panel2
'
Me.editorSplitContainer.Panel2.Controls.Add(Me.pageEditorControl)
Me.editorSplitContainer.Size = New System.Drawing.Size(243, 223)
Me.editorSplitContainer.SplitterDistance = 180
Me.editorSplitContainer.TabIndex = 0
'
'pagePropertyGrid
'
Me.pagePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
Me.pagePropertyGrid.HelpVisible = False
Me.pagePropertyGrid.Location = New System.Drawing.Point(0, 0)
Me.pagePropertyGrid.Name = "pagePropertyGrid"
Me.pagePropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized
Me.pagePropertyGrid.Size = New System.Drawing.Size(243, 180)
Me.pagePropertyGrid.TabIndex = 2
Me.pagePropertyGrid.ToolbarVisible = False
Me.pagePropertyGrid.Visible = False
'
'pageEditorControl
'
Me.pageEditorControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.pageEditorControl.Location = New System.Drawing.Point(0, 0)
Me.pageEditorControl.Name = "pageEditorControl"
Me.pageEditorControl.Padding = New System.Windows.Forms.Padding(4)
Me.pageEditorControl.Size = New System.Drawing.Size(243, 39)
Me.pageEditorControl.TabIndex = 0
Me.pageEditorControl.Visible = False
'
'mainHtmlEditorControl
'
Me.mainHtmlEditorControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainHtmlEditorControl.Location = New System.Drawing.Point(3, 3)
Me.mainHtmlEditorControl.Name = "mainHtmlEditorControl"
Me.mainHtmlEditorControl.Size = New System.Drawing.Size(547, 223)
Me.mainHtmlEditorControl.TabIndex = 0
'
'MainForm
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(561, 301)
Me.Controls.Add(Me.mainTabControl)
Me.Controls.Add(Me.mainStatusStrip)
Me.Controls.Add(Me.mainFromMenuStrip)
Me.MainMenuStrip = Me.mainFromMenuStrip
Me.Name = "MainForm"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "MyPage"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.mainTabControl.ResumeLayout(False)
Me.ftpTabPage.ResumeLayout(False)
Me.ftpSplitContainer.Panel1.ResumeLayout(False)
Me.ftpSplitContainer.Panel2.ResumeLayout(False)
CType(Me.ftpSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.ftpSplitContainer.ResumeLayout(False)
Me.pagesTabPage.ResumeLayout(False)
Me.mainFromMenuStrip.ResumeLayout(False)
Me.mainFromMenuStrip.PerformLayout()
Me.htmlEditorTabPage.ResumeLayout(False)
Me.pagesSplitContainer.Panel1.ResumeLayout(False)
Me.pagesSplitContainer.Panel2.ResumeLayout(False)
CType(Me.pagesSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.pagesSplitContainer.ResumeLayout(False)
Me.editorSplitContainer.Panel1.ResumeLayout(False)
Me.editorSplitContainer.Panel2.ResumeLayout(False)
CType(Me.editorSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
Me.editorSplitContainer.ResumeLayout(False)
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
    PageExplorerControl.Fill()
    Me.Icon = My.Resources.myPage
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
  Private Sub onEndClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles endToolStripMenuItem.Click

    Me.Close()
  End Sub

  Private Sub onFtpTextFileDownloaded _
  (ByVal sender As Object _
  , ByVal e As BCW.FtpLib.Windows.Forms.TextFileDownloadedEventArgs) _
  Handles mainFTPbrowser.TextFileDownloaded

    Dim tp = New BCW.TabbedBrowsing.Windows.Forms.TabPage(New FtpTabForm(e))
    tp.Header = e.FTPfileInfo.Filename
    tp.Image = My.Resources.page16x16
    tp.Tag = e

    tp.TabForm.Text = e.FileDataString
    tp.TabForm.TopLevel = False
    ftpSplitContainer.Panel2.Controls.Add(tp.TabForm)
    ftpTabContainer.TabPages.Add(tp)
  End Sub

  Private Sub onPageConnectionSelected _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles PageExplorerControl.ConnectionSelected

    pagePropertyGrid.SelectedObject = PageExplorerControl.SelectedConnection
    pageEditorControl.Visible = False
    pagePropertyGrid.Visible = pagePropertyGrid.SelectedObject IsNot Nothing
  End Sub

  Private Sub onPageSelected _
  (ByVal sender As System.Object _
  , ByVal e As SSP.MyPage.Windows.Forms.PageSelectedEventArgs) _
  Handles PageExplorerControl.PageSelected

    pagePropertyGrid.SelectedObject = e.Page
    pageEditorControl.Text = e.Page.Text
    pageEditorControl.Visible = True
    pagePropertyGrid.Visible = True
  End Sub

  Private Sub onPageValueChanged _
  (ByVal s As Object _
  , ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) _
  Handles pagePropertyGrid.PropertyValueChanged

    Select Case True
    Case TypeOf pagePropertyGrid.SelectedObject Is PageConnection
      PageExplorerControl.RestoreConnection()
    Case e.ChangedItem.Label = "Page"
      'Dim page = DirectCast(pagePropertyGrid.SelectedObject, Page)
      'If SSP.MyPage.Page.PageExists _
      '(PageExplorerControl.SelectedConnection.ConnectionString _
      ', page.ParentPage, page.Page) Then
      '  page.Page = e.OldValue.ToString
      '  BCW.etc.Message.Error("Page existiert bereits!")
      'Else
      '  PageExplorerControl.RefreshNodeText()
      'End If
    Case e.ChangedItem.Label = "PageOrder"
      PageExplorerControl.RefreshNodeText()
    Case e.ChangedItem.Label = "Title"
      PageExplorerControl.RefreshNodeText()
    Case e.ChangedItem.Label = "ParentPage"
      PageExplorerControl.RefreshConnection()
    End Select
  End Sub

  Private Sub onPageEditorValidated _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles pageEditorControl.Validated
    SavePageText()
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub SavePageText()
    Dim page = TryCast(pagePropertyGrid.SelectedObject, Page)
    If page Is Nothing Then Exit Sub
    page.Text = pageEditorControl.Text
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse MainForm}
End Namespace
