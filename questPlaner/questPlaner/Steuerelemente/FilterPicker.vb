Option Explicit On 
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class FilterPicker

Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "
  Private WithEvents showItemsButton As System.Windows.Forms.Button
  Private WithEvents itemsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
  Private WithEvents selectedItemsLabel As System.Windows.Forms.Label
  Private WithEvents headerLabel As System.Windows.Forms.Label

  ' Für Windows Form-Designer erforderlich
  Private components As System.ComponentModel.IContainer

  'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
  'Sie kann mit dem Windows Form-Designer modifiziert werden.
  'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.showItemsButton = New System.Windows.Forms.Button
Me.itemsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.selectedItemsLabel = New System.Windows.Forms.Label
Me.headerLabel = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'showItemsButton
'
Me.showItemsButton.Cursor = System.Windows.Forms.Cursors.Hand
Me.showItemsButton.Dock = System.Windows.Forms.DockStyle.Right
Me.showItemsButton.FlatAppearance.BorderSize = 0
Me.showItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.showItemsButton.Font = New System.Drawing.Font("Marlett", 10.0!)
Me.showItemsButton.Location = New System.Drawing.Point(166, 2)
Me.showItemsButton.Name = "showItemsButton"
Me.showItemsButton.Size = New System.Drawing.Size(32, 20)
Me.showItemsButton.TabIndex = 0
Me.showItemsButton.Text = "6"
Me.showItemsButton.UseVisualStyleBackColor = True
'
'itemsContextMenuStrip
'
Me.itemsContextMenuStrip.AutoClose = False
Me.itemsContextMenuStrip.Name = "itemsContextMenuStrip"
Me.itemsContextMenuStrip.Size = New System.Drawing.Size(61, 4)
'
'selectedItemsLabel
'
Me.selectedItemsLabel.AutoEllipsis = True
Me.selectedItemsLabel.Dock = System.Windows.Forms.DockStyle.Fill
Me.selectedItemsLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.selectedItemsLabel.Location = New System.Drawing.Point(22, 2)
Me.selectedItemsLabel.Name = "selectedItemsLabel"
Me.selectedItemsLabel.Size = New System.Drawing.Size(144, 20)
Me.selectedItemsLabel.TabIndex = 2
Me.selectedItemsLabel.Text = "<Kein Filter>"
Me.selectedItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'headerLabel
'
Me.headerLabel.AutoEllipsis = True
Me.headerLabel.Dock = System.Windows.Forms.DockStyle.Left
Me.headerLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.headerLabel.Location = New System.Drawing.Point(2, 2)
Me.headerLabel.Name = "headerLabel"
Me.headerLabel.Size = New System.Drawing.Size(20, 20)
Me.headerLabel.TabIndex = 3
Me.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.headerLabel.Visible = False
'
'FilterPicker
'
Me.AutoScroll = True
Me.Controls.Add(Me.selectedItemsLabel)
Me.Controls.Add(Me.headerLabel)
Me.Controls.Add(Me.showItemsButton)
Me.Name = "FilterPicker"
Me.Padding = New System.Windows.Forms.Padding(2)
Me.Size = New System.Drawing.Size(200, 24)
Me.ResumeLayout(False)

End Sub

#End Region

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private WithEvents _Items As New BCW.etc.EventListOf(Of String)
  Private _SelectedItems As New List(Of String)
  Private _Refill As Boolean = True
  Private _Header As String = ""
  Private _HeaderWidth As Int32 = 20
  Public Event SelectedItemsChanged(ByVal sender As Object, ByVal e As EventArgs)
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
  Public ReadOnly Property Items() As BCW.etc.EventListOf(Of String)
  Get
    Return _Items
  End Get
  End Property

  Public ReadOnly Property SelectedItems() As List(Of String)
  Get
    Return _SelectedItems
  End Get
  End Property

  Public Property Header() As String
  Get
    Return _Header
  End Get
  Set(ByVal value As String)
    _Header = value
    headerLabel.Text = value
    headerLabel.Visible = value.Trim.Length > 0
  End Set
  End Property

  Public Property HeaderWidth() As Int32
  Get
    Return _HeaderWidth
  End Get
  Set(ByVal value As Int32)
    _HeaderWidth = value
    headerLabel.Width = value
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

  Private _IsShown As Boolean = False

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showItemsButton.Click

    Select Case _IsShown
    Case True

      GetSelectedItems()
    Case Else
      If _Refill Then
        itemsContextMenuStrip.Items.Clear()

        itemsContextMenuStrip.Items.Add("[Alle selektieren]", Nothing, AddressOf onUnCheckAll)
        itemsContextMenuStrip.Items.Add("-")

        For Each item In _Items
          itemsContextMenuStrip.Items.Add(item, Nothing, AddressOf onContextClick)
        Next item

        itemsContextMenuStrip.Items.Add("-")
        itemsContextMenuStrip.Items.Add("[Filter setzen]", Nothing, AddressOf onOKClicked)
        _Refill = False
      End If

      If itemsContextMenuStrip.Items.Count <= 4 Then Exit Sub

      Dim loc = Me.RectangleToScreen(Me.DisplayRectangle).Location
      loc.X += (Me.Width - itemsContextMenuStrip.Width)
      loc.Y += Me.Height

      itemsContextMenuStrip.Show(loc)
      _IsShown = True
    End Select
  End Sub

  Private Sub onContextClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs)

    Dim item = DirectCast(sender, ToolStripMenuItem)
    item.Checked = Not item.Checked
  End Sub

  Private Sub onUnCheckAll _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs)

    With itemsContextMenuStrip
      If .Items.Count <= 4 Then Exit Sub

      Dim checked = Not DirectCast(.Items.Item(3), ToolStripMenuItem).Checked

      For i = 2 To .Items.Count - 3
        Dim item = DirectCast(.Items.Item(i), ToolStripMenuItem)
        item.Checked = checked
      Next i
    End With
  End Sub

  Private Sub onOKClicked _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs)

    GetSelectedItems()
  End Sub

  Private Sub GetSelectedItems()
    itemsContextMenuStrip.Close()
    _IsShown = False

    Dim ret = From item In itemsContextMenuStrip.Items _
    Where (TypeOf item Is ToolStripMenuItem) _
    AndAlso (DirectCast(item, ToolStripMenuItem).Checked) _
    Order By DirectCast(item, ToolStripMenuItem).Text _
    Select DirectCast(item, ToolStripMenuItem).Text

    _SelectedItems = ret.ToList
    selectedItemsLabel.Text = String.Join(", ", ret.ToArray)
    If selectedItemsLabel.Text.Length = 0 Then
      selectedItemsLabel.Text = "<Kein Filter>"
    End If

    RaiseEvent SelectedItemsChanged(Me, New EventArgs)
  End Sub

  Private Sub _Items_ItemCollectionChanged _
  (ByVal sender As Object _
  , ByVal e As BCW.etc.CollectionChangedEventArgs(Of String)) _
  Handles _Items.ItemCollectionChanged
    _Refill = True
  End Sub

End Class '{Klasse FilterPicker}
End Namespace
