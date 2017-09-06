Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

<System.ComponentModel.DefaultEvent("PageSelected")> _
Public Class PageExplorerControl

Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents explorerTreeView As System.Windows.Forms.TreeView
Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
Private WithEvents addToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents deleteToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents connectionToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents firstToolStripSeparator As System.Windows.Forms.ToolStripSeparator
Private WithEvents refreshToolStripButton As System.Windows.Forms.ToolStripButton
Private WithEvents secondToolStripSeparator As System.Windows.Forms.ToolStripSeparator
Private WithEvents thirdToolStripSeparator As System.Windows.Forms.ToolStripSeparator
Private WithEvents reorderToolStripButton As System.Windows.Forms.ToolStripButton
    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PageExplorerControl))
Me.explorerTreeView = New System.Windows.Forms.TreeView()
Me.mainToolStrip = New System.Windows.Forms.ToolStrip()
Me.connectionToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.firstToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
Me.refreshToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.secondToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
Me.addToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.deleteToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.thirdToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
Me.reorderToolStripButton = New System.Windows.Forms.ToolStripButton()
Me.mainToolStrip.SuspendLayout()
Me.SuspendLayout()
'
'explorerTreeView
'
Me.explorerTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.explorerTreeView.Dock = System.Windows.Forms.DockStyle.Fill
Me.explorerTreeView.HideSelection = False
Me.explorerTreeView.Location = New System.Drawing.Point(4, 29)
Me.explorerTreeView.Name = "explorerTreeView"
Me.explorerTreeView.Size = New System.Drawing.Size(284, 240)
Me.explorerTreeView.TabIndex = 5
'
'mainToolStrip
'
Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.connectionToolStripButton, Me.firstToolStripSeparator, Me.refreshToolStripButton, Me.secondToolStripSeparator, Me.addToolStripButton, Me.deleteToolStripButton, Me.thirdToolStripSeparator, Me.reorderToolStripButton})
Me.mainToolStrip.Location = New System.Drawing.Point(4, 4)
Me.mainToolStrip.Name = "mainToolStrip"
Me.mainToolStrip.Size = New System.Drawing.Size(284, 25)
Me.mainToolStrip.TabIndex = 7
'
'connectionToolStripButton
'
Me.connectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.connectionToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.connect16x16
Me.connectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.connectionToolStripButton.Name = "connectionToolStripButton"
Me.connectionToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.connectionToolStripButton.Text = "Verbindung herstellen"
'
'firstToolStripSeparator
'
Me.firstToolStripSeparator.Name = "firstToolStripSeparator"
Me.firstToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'refreshToolStripButton
'
Me.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.refreshToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.refresh16x16
Me.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.refreshToolStripButton.Name = "refreshToolStripButton"
Me.refreshToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.refreshToolStripButton.ToolTipText = "Aktualisieren"
'
'secondToolStripSeparator
'
Me.secondToolStripSeparator.Name = "secondToolStripSeparator"
Me.secondToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'addToolStripButton
'
Me.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.addToolStripButton.Image = CType(resources.GetObject("addToolStripButton.Image"), System.Drawing.Image)
Me.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.addToolStripButton.Name = "addToolStripButton"
Me.addToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.addToolStripButton.ToolTipText = "FTP-Verzeichnis anlegen"
'
'deleteToolStripButton
'
Me.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.deleteToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.remove16x16
Me.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.deleteToolStripButton.Name = "deleteToolStripButton"
Me.deleteToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.deleteToolStripButton.ToolTipText = "FTP-Verzeichnis löschen"
'
'thirdToolStripSeparator
'
Me.thirdToolStripSeparator.Name = "thirdToolStripSeparator"
Me.thirdToolStripSeparator.Size = New System.Drawing.Size(6, 25)
'
'reorderToolStripButton
'
Me.reorderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.reorderToolStripButton.Image = Global.SSP.MyPage.My.Resources.Resources.reorder16x16
Me.reorderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.reorderToolStripButton.Name = "reorderToolStripButton"
Me.reorderToolStripButton.Size = New System.Drawing.Size(23, 22)
Me.reorderToolStripButton.ToolTipText = "PageOrder für alle Pages durchgängig setzen"
'
'PagesExplorerControl
'
Me.Controls.Add(Me.explorerTreeView)
Me.Controls.Add(Me.mainToolStrip)
Me.Name = "PagesExplorerControl"
Me.Padding = New System.Windows.Forms.Padding(4)
Me.Size = New System.Drawing.Size(292, 273)
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
  Private _Root As TreeNode
  Private _PageConnections As New PageConnections
  Private _ImageList As New ImageList

  Public Event PageSelected(ByVal sender As Object, ByVal e As PageSelectedEventArgs)
  Public Event ConnectionSelected(ByVal sender As Object, ByVal e As EventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
    '{Konstruktor}
    MyBase.New()
    InitializeComponent()
    _ImageList.ColorDepth = ColorDepth.Depth32Bit
    _ImageList.Images.Add("connections", My.Resources.databases16x16)
    _ImageList.Images.Add("connect", My.Resources.connect16x16)
    _ImageList.Images.Add("disconnect", My.Resources.disconnect16x16)
    _ImageList.Images.Add("page", My.Resources.page16x16)
    explorerTreeView.ImageList = _ImageList
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
  Private Property ConnectionOpen As Boolean
  Get
    Return Not String.IsNullOrEmpty _
    (Me.SelectedConnection.Password)
  End Get
  Set(ByVal value As Boolean)
    If Not value Then Me.SelectedConnection.Password = ""

    If value Then
      connectionToolStripButton.Image = My.Resources.disconnect16x16
      connectionToolStripButton.ToolTipText = "Verbindung trennen"
      addToolStripButton.Visible = True
      thirdToolStripSeparator.Visible = True
      reorderToolStripButton.Visible = True
      explorerTreeView.SelectedNode.ImageKey = "connect"
      explorerTreeView.SelectedNode.SelectedImageKey = "connect"
    Else
      connectionToolStripButton.Image = My.Resources.connect16x16
      connectionToolStripButton.ToolTipText = "Verbindung herstellen"
      addToolStripButton.Visible = False
      thirdToolStripSeparator.Visible = False
      reorderToolStripButton.Visible = False
      explorerTreeView.SelectedNode.ImageKey = "disconnect"
      explorerTreeView.SelectedNode.SelectedImageKey = "disconnect"
      explorerTreeView.SelectedNode.Nodes.Clear()
    End If

    connectionToolStripButton.Visible = True
    firstToolStripSeparator.Visible = True
  End Set
  End Property

  Public ReadOnly Property SelectedConnection As PageConnection
  Get
    Return TryCast(GetConnectionNode.Tag, PageConnection)
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
  Private Sub onExplorerAfterSelect _
  (ByVal sender As System.Object _
  , ByVal e As System.Windows.Forms.TreeViewEventArgs) _
  Handles explorerTreeView.AfterSelect

    ActionSelection(e.Node)
  End Sub

  Private Sub onAddClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles addToolStripButton.Click

    Add()
  End Sub

  Private Sub onDeleteClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles deleteToolStripButton.Click

    Delete()
  End Sub

  Private Sub onConnectionStateChangedClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles connectionToolStripButton.Click

    ConnectionStateChanged()
  End Sub

  Private Sub onRefreshClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles refreshToolStripButton.Click

    RefreshView()
  End Sub

  Private Sub onReorderClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles reorderToolStripButton.Click

    ReorderPageOrders()
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function GetConnectionNode() As TreeNode
    Dim n = explorerTreeView.SelectedNode
    For i = explorerTreeView.SelectedNode.Level - 1 To 1 Step -1
      n = n.Parent
    Next i
    Return n
  End Function

  Private Sub InsertRootPages _
  (ByVal parentNode As TreeNode _
  , ByVal connection As PageConnection)

    If parentNode.Nodes.Count > 0 Then Exit Sub

    If String.IsNullOrEmpty(connection.Password) Then Exit Sub

    Try
      SSP.MyPage.Pages.DatabaseName = connection.Database
      SSP.MyPage.Page.DatabaseName = connection.Database
      Dim pages = New Pages(connection.ConnectionString, "")
      pages.FillByRootPages()

      For Each p As Page In pages
        InsertPage(parentNode, p)
      Next p
    Catch ex As Exception
      Me.ConnectionOpen = False
      BCW.etc.Message.Error("Verbindung fehlgeschlagen!" & vbCrLf & vbCrLf _
      & "Bitte überprüfen Sie Verbindungsparameter und Kennwort!")
    End Try
  End Sub

  Private Sub InsertPages _
  (ByVal parentNode As TreeNode _
  , ByVal parentPage As SSP.MyPage.Page)

    If parentNode.Nodes.Count > 0 Then Exit Sub

    SSP.MyPage.Pages.DatabaseName = Me.SelectedConnection.Database
    SSP.MyPage.Page.DatabaseName = Me.SelectedConnection.Database

    For Each page As SSP.MyPage.Page In parentPage.Pages
      InsertPage(parentNode, page)
    Next page

  End Sub

  Private Function InsertPage _
  (ByVal parentNode As TreeNode _
  , ByVal page As SSP.MyPage.Page) As TreeNode

    Dim n = parentNode.Nodes.Add(page.ToString)
    n.SelectedImageKey = "page"
    n.ImageKey = "page"
    n.Tag = page
    Return n
  End Function

  Private Sub ActionSelection(ByVal n As TreeNode)
    addToolStripButton.Visible = False
    deleteToolStripButton.Visible = False
    connectionToolStripButton.Visible = False
    firstToolStripSeparator.Visible = False
    thirdToolStripSeparator.Visible = False
    reorderToolStripButton.Visible = False

    Dim obj = n.Tag

    Select Case True
    Case n Is _Root
      addToolStripButton.Visible = True
      addToolStripButton.ToolTipText = "Neue Verbindung anlegen"
      RaiseEvent ConnectionSelected(Me, New EventArgs)
    Case TypeOf obj Is PageConnection
      AfterConnectionSelect(n, DirectCast(obj, PageConnection))
    Case TypeOf obj Is Page
      thirdToolStripSeparator.Visible = True
      reorderToolStripButton.Visible = True
      addToolStripButton.Visible = TypeOf n.Parent.Tag Is PageConnection
      addToolStripButton.ToolTipText = "Neue Seite anlegen"
      deleteToolStripButton.Visible = True
      deleteToolStripButton.ToolTipText = "Seite löschen"
      Dim page = DirectCast(obj, Page)
      RaiseEvent PageSelected(Me, New PageSelectedEventArgs(page))
      InsertPages(n, page)
    End Select
  End Sub

  Private Sub AfterConnectionSelect _
  (ByVal n As TreeNode _
  , ByVal connection As PageConnection)

    Me.ConnectionOpen = Not String.IsNullOrEmpty(connection.Password.ToString)
    addToolStripButton.ToolTipText = "Neue Hauptseite anlegen"
    deleteToolStripButton.Visible = True
    deleteToolStripButton.ToolTipText = "Verbindung löschen"

    RaiseEvent ConnectionSelected(Me, New EventArgs)
    InsertRootPages(n, connection)
  End Sub

  Private Sub Delete()

    Dim n = explorerTreeView.SelectedNode
    Select Case True
    Case n Is Nothing
    Case TypeOf n.Tag Is PageConnection
      DeleteConnection()
    Case TypeOf n.Tag Is Page
      DeletePage()
    End Select
  End Sub

  Private Sub DeleteConnection()
    Select Case BCW.etc.Message.Question("Soll die Verbindung '" _
    & Me.SelectedConnection.Name & "' wirklich gelöscht werden?" _
    , "Verbindung löschen")
    Case DialogResult.No
      Exit Sub
    End Select

    _PageConnections.Remove(Me.SelectedConnection)
    _PageConnections.Save()
    explorerTreeView.SelectedNode.Remove()
    explorerTreeView.SelectedNode = _Root
  End Sub

  Private Sub DeletePage()
    Dim n = explorerTreeView.SelectedNode
    Dim page = DirectCast(n.Tag, Page)

    Select Case BCW.etc.Message.Question("Soll die Page '" _
    & page.ToString & "' wirklich gelöscht werden?" _
    , "Page löschen")
    Case DialogResult.No
      Exit Sub
    End Select

    page.Delete()
    explorerTreeView.SelectedNode = n.Parent
    explorerTreeView.SelectedNode.EnsureVisible()
    n.Remove()
  End Sub

  Private Sub Add()
    Dim n = explorerTreeView.SelectedNode

    Select Case True
    Case n Is Nothing
    Case n Is _Root
      AddConnection()
    Case TypeOf n.Tag Is PageConnection
      AddPage("")
    Case TypeOf n.Tag Is Page
      AddPage(DirectCast(n.Tag, Page).Page)
    End Select
  End Sub

  Private Sub AddConnection()
    Dim connection = New PageConnection _
    ("Neue Verbindung", "", "", "")

    _PageConnections.Add(connection)
    _PageConnections.Save()

    Dim node = _Root.Nodes.Add(connection.ToString)
    node.Tag = connection
    node.SelectedImageKey = "disconnect"
    node.ImageKey = "disconnect"
    explorerTreeView.SelectedNode = node
    node.EnsureVisible()
  End Sub

  Private Sub AddPage(ByVal parentPage As String)

    Dim ib = New BCW.SelectEntry.Windows.Forms.InputBox(Of String)

    Select Case ib.ShowDialog _
    ("Bitte Namen der Page eingeben:", "Name der Page", "_new_page")
    Case DialogResult.Cancel
      Exit Sub
    End Select
    Dim name = ib.Value

    Select Case ib.ShowDialog _
    ("Bitte Titel der Page eingeben:", "Name der Page", "Neue Seite")
    Case DialogResult.Cancel
      Exit Sub
    End Select
    Dim title = ib.Value

    SSP.MyPage.Page.DatabaseName = Me.SelectedConnection.Database
    SSP.MyPage.Pages.DatabaseName = Me.SelectedConnection.Database

    If SSP.MyPage.Page.PageExists _
    (Me.SelectedConnection.ConnectionString _
    , parentPage, name) Then
      BCW.etc.Message.Error("Page existiert bereits!", "Neue Page")
      Exit Sub
    End If

    Dim page = New Page(Me.SelectedConnection.ConnectionString, 0)
    page.Page = name
    page.Title = title
    page.Year = DateTime.Now.Year
    If Not String.IsNullOrEmpty(parentPage) Then
      page.ParentPage = parentPage
      page.SetNextPageOrder()
    End If

    Dim n = InsertPage(explorerTreeView.SelectedNode, page)
    explorerTreeView.SelectedNode = n
    n.EnsureVisible()
  End Sub

  Private Sub ConnectionStateChanged()
    If Me.ConnectionOpen Then
      Me.ConnectionOpen = False
    Else
      Dim ip = New BCW.SelectEntry.Windows.Forms.InputBox(Of String)
      ip.PasswordChar = "*"c
      Select Case ip.ShowDialog _
      ("Bitte Kennwort eingeben:" _
      , "Verbindungskennwort")
      Case DialogResult.Cancel
        Exit Sub
      End Select

      Me.SelectedConnection.Password = ip.Value
      Me.ConnectionOpen = True
      InsertRootPages(explorerTreeView.SelectedNode, Me.SelectedConnection)
    End If
  End Sub

  Private Sub RefreshView()
    explorerTreeView.SelectedNode.Nodes.Clear()
    Select Case True
    Case explorerTreeView.SelectedNode Is _Root
      Fill()
    Case TypeOf explorerTreeView.SelectedNode.Tag Is PageConnection
      ActionSelection(explorerTreeView.SelectedNode)
    Case TypeOf explorerTreeView.SelectedNode.Tag Is Page
      Dim page = DirectCast(explorerTreeView.SelectedNode.Tag, Page)
      page.Pages.Clear()
      ActionSelection(explorerTreeView.SelectedNode)
    End Select
  End Sub

  Private Sub ReorderPageOrders()
    Dim n = explorerTreeView.SelectedNode
    Select Case True
    Case TypeOf n.Tag Is PageConnection
      Dim pages = New Pages(Me.SelectedConnection.ConnectionString, "")
      pages.ReorderPages()
    Case TypeOf n.Tag Is Page
      Dim page = DirectCast(n.Tag, Page)
      page.Pages.ReorderPages()
    End Select
    RefreshView()
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Fill()

    explorerTreeView.Nodes.Clear()

    _Root = explorerTreeView.Nodes.Add("Verbindungen")
    _Root.ImageKey = "connections"
    _Root.SelectedImageKey = "connections"

    _PageConnections.Fill()

    For Each connection In _PageConnections
      Dim n = _Root.Nodes.Add(connection.ToString)
      n.Tag = connection
      n.ImageKey = "disconnect"
      n.SelectedImageKey = "disconnect"
    Next connection

    _Root.Expand()
    explorerTreeView.SelectedNode = _Root
  End Sub

  Public Sub RestoreConnection()
    _PageConnections.Save()
    explorerTreeView.SelectedNode.Text = Me.SelectedConnection.Name
  End Sub

  Public Sub RefreshNodeText()
    Dim n = explorerTreeView.SelectedNode
    Dim page = TryCast(n.Tag, Page)
    If page Is Nothing Then Exit Sub
    n.Text = page.ToString
  End Sub

  Public Sub RefreshConnection()
    Dim n = GetConnectionNode()
    n.Nodes.Clear()
    ActionSelection(n)
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse PagesExplorerControl}
End Namespace
