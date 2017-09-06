Public Class natiDialog
  Inherits System.Windows.Forms.Form

#Region " ---------- Vom Designer erstellter Code --------- "
  Private WithEvents decodeKeyLabel As System.Windows.Forms.Label
  Private WithEvents decodeKeyTextBox As System.Windows.Forms.TextBox
  Private WithEvents valueGroupLabel As System.Windows.Forms.Label
  Private WithEvents valueGroupComboBox As System.Windows.Forms.ComboBox
  Private WithEvents rfLabel As System.Windows.Forms.Label
  Private WithEvents rfComboBox As System.Windows.Forms.ComboBox
  Private WithEvents valueLabel As System.Windows.Forms.Label
  Private WithEvents valueTextBox As System.Windows.Forms.TextBox
  Private WithEvents mainToolStrip As System.Windows.Forms.ToolStrip
  Private WithEvents closeToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents copyToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents updateToolStripButton As System.Windows.Forms.ToolStripButton
  Private WithEvents mainFormMenuStrip As System.Windows.Forms.MenuStrip
  Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents importListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents deleteListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents sepToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
  Private WithEvents endToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents exportListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(natiDialog))
Me.decodeKeyLabel = New System.Windows.Forms.Label
Me.decodeKeyTextBox = New System.Windows.Forms.TextBox
Me.valueGroupLabel = New System.Windows.Forms.Label
Me.valueGroupComboBox = New System.Windows.Forms.ComboBox
Me.rfLabel = New System.Windows.Forms.Label
Me.rfComboBox = New System.Windows.Forms.ComboBox
Me.valueLabel = New System.Windows.Forms.Label
Me.valueTextBox = New System.Windows.Forms.TextBox
Me.mainToolStrip = New System.Windows.Forms.ToolStrip
Me.closeToolStripButton = New System.Windows.Forms.ToolStripButton
Me.copyToolStripButton = New System.Windows.Forms.ToolStripButton
Me.updateToolStripButton = New System.Windows.Forms.ToolStripButton
Me.mainFormMenuStrip = New System.Windows.Forms.MenuStrip
Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.importListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.deleteListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.sepToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
Me.endToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.exportListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.mainToolStrip.SuspendLayout()
Me.mainFormMenuStrip.SuspendLayout()
Me.SuspendLayout()
'
'decodeKeyLabel
'
Me.decodeKeyLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.decodeKeyLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.decodeKeyLabel.Location = New System.Drawing.Point(4, 28)
Me.decodeKeyLabel.Name = "decodeKeyLabel"
Me.decodeKeyLabel.Size = New System.Drawing.Size(206, 20)
Me.decodeKeyLabel.TabIndex = 1
Me.decodeKeyLabel.Text = "Schlüssel"
Me.decodeKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'decodeKeyTextBox
'
Me.decodeKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.decodeKeyTextBox.Dock = System.Windows.Forms.DockStyle.Top
Me.decodeKeyTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.decodeKeyTextBox.Location = New System.Drawing.Point(4, 48)
Me.decodeKeyTextBox.Name = "decodeKeyTextBox"
Me.decodeKeyTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
Me.decodeKeyTextBox.Size = New System.Drawing.Size(206, 21)
Me.decodeKeyTextBox.TabIndex = 2
'
'valueGroupLabel
'
Me.valueGroupLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.valueGroupLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.valueGroupLabel.Location = New System.Drawing.Point(4, 69)
Me.valueGroupLabel.Name = "valueGroupLabel"
Me.valueGroupLabel.Size = New System.Drawing.Size(206, 20)
Me.valueGroupLabel.TabIndex = 3
Me.valueGroupLabel.Text = "Institut"
Me.valueGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'valueGroupComboBox
'
Me.valueGroupComboBox.Dock = System.Windows.Forms.DockStyle.Top
Me.valueGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.valueGroupComboBox.Enabled = False
Me.valueGroupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me.valueGroupComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.valueGroupComboBox.FormattingEnabled = True
Me.valueGroupComboBox.Location = New System.Drawing.Point(4, 89)
Me.valueGroupComboBox.Name = "valueGroupComboBox"
Me.valueGroupComboBox.Size = New System.Drawing.Size(206, 21)
Me.valueGroupComboBox.TabIndex = 4
'
'rfLabel
'
Me.rfLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.rfLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.rfLabel.Location = New System.Drawing.Point(4, 110)
Me.rfLabel.Name = "rfLabel"
Me.rfLabel.Size = New System.Drawing.Size(206, 20)
Me.rfLabel.TabIndex = 5
Me.rfLabel.Text = "Reihenfolge"
Me.rfLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'rfComboBox
'
Me.rfComboBox.Dock = System.Windows.Forms.DockStyle.Top
Me.rfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.rfComboBox.Enabled = False
Me.rfComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
Me.rfComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.rfComboBox.FormattingEnabled = True
Me.rfComboBox.Location = New System.Drawing.Point(4, 130)
Me.rfComboBox.Name = "rfComboBox"
Me.rfComboBox.Size = New System.Drawing.Size(206, 21)
Me.rfComboBox.Sorted = True
Me.rfComboBox.TabIndex = 6
'
'valueLabel
'
Me.valueLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.valueLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.valueLabel.Location = New System.Drawing.Point(4, 151)
Me.valueLabel.Name = "valueLabel"
Me.valueLabel.Size = New System.Drawing.Size(206, 20)
Me.valueLabel.TabIndex = 7
Me.valueLabel.Text = "Ergebnis"
Me.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'valueTextBox
'
Me.valueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.valueTextBox.Dock = System.Windows.Forms.DockStyle.Top
Me.valueTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.valueTextBox.Location = New System.Drawing.Point(4, 171)
Me.valueTextBox.Name = "valueTextBox"
Me.valueTextBox.ReadOnly = True
Me.valueTextBox.Size = New System.Drawing.Size(206, 21)
Me.valueTextBox.TabIndex = 8
'
'mainToolStrip
'
Me.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
Me.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
Me.mainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.closeToolStripButton, Me.copyToolStripButton, Me.updateToolStripButton})
Me.mainToolStrip.Location = New System.Drawing.Point(4, 199)
Me.mainToolStrip.Name = "mainToolStrip"
Me.mainToolStrip.Size = New System.Drawing.Size(206, 25)
Me.mainToolStrip.TabIndex = 9
Me.mainToolStrip.Text = "ToolStrip1"
'
'closeToolStripButton
'
Me.closeToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
Me.closeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.closeToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.closeToolStripButton.Image = CType(resources.GetObject("closeToolStripButton.Image"), System.Drawing.Image)
Me.closeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.closeToolStripButton.Name = "closeToolStripButton"
Me.closeToolStripButton.Size = New System.Drawing.Size(56, 22)
Me.closeToolStripButton.Text = "Schließen"
'
'copyToolStripButton
'
Me.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.copyToolStripButton.Enabled = False
Me.copyToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.copyToolStripButton.Image = CType(resources.GetObject("copyToolStripButton.Image"), System.Drawing.Image)
Me.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.copyToolStripButton.Name = "copyToolStripButton"
Me.copyToolStripButton.Size = New System.Drawing.Size(53, 22)
Me.copyToolStripButton.Text = "Kopieren"
'
'updateToolStripButton
'
Me.updateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
Me.updateToolStripButton.Enabled = False
Me.updateToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.updateToolStripButton.Image = CType(resources.GetObject("updateToolStripButton.Image"), System.Drawing.Image)
Me.updateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
Me.updateToolStripButton.Name = "updateToolStripButton"
Me.updateToolStripButton.Size = New System.Drawing.Size(72, 22)
Me.updateToolStripButton.Text = "Konsumieren"
'
'mainFormMenuStrip
'
Me.mainFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
Me.mainFormMenuStrip.Location = New System.Drawing.Point(4, 4)
Me.mainFormMenuStrip.Name = "mainFormMenuStrip"
Me.mainFormMenuStrip.Padding = New System.Windows.Forms.Padding(0)
Me.mainFormMenuStrip.Size = New System.Drawing.Size(206, 24)
Me.mainFormMenuStrip.TabIndex = 0
'
'fileToolStripMenuItem
'
Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.importListToolStripMenuItem, Me.exportListToolStripMenuItem, Me.deleteListToolStripMenuItem, Me.sepToolStripMenuItem, Me.endToolStripMenuItem})
Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
Me.fileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
Me.fileToolStripMenuItem.Text = "Datei"
'
'importListToolStripMenuItem
'
Me.importListToolStripMenuItem.Enabled = False
Me.importListToolStripMenuItem.Name = "importListToolStripMenuItem"
Me.importListToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
Me.importListToolStripMenuItem.Text = "Liste importieren ..."
'
'deleteListToolStripMenuItem
'
Me.deleteListToolStripMenuItem.Enabled = False
Me.deleteListToolStripMenuItem.Name = "deleteListToolStripMenuItem"
Me.deleteListToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
Me.deleteListToolStripMenuItem.Text = "Liste löschen ..."
'
'sepToolStripMenuItem
'
Me.sepToolStripMenuItem.Name = "sepToolStripMenuItem"
Me.sepToolStripMenuItem.Size = New System.Drawing.Size(172, 6)
'
'endToolStripMenuItem
'
Me.endToolStripMenuItem.Name = "endToolStripMenuItem"
Me.endToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
Me.endToolStripMenuItem.Text = "Schließen"
'
'exportListToolStripMenuItem
'
Me.exportListToolStripMenuItem.Enabled = False
Me.exportListToolStripMenuItem.Name = "exportListToolStripMenuItem"
Me.exportListToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
Me.exportListToolStripMenuItem.Text = "Liste exportieren ..."
'
'natiDialog
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(214, 228)
Me.Controls.Add(Me.mainToolStrip)
Me.Controls.Add(Me.valueTextBox)
Me.Controls.Add(Me.valueLabel)
Me.Controls.Add(Me.rfComboBox)
Me.Controls.Add(Me.rfLabel)
Me.Controls.Add(Me.valueGroupComboBox)
Me.Controls.Add(Me.valueGroupLabel)
Me.Controls.Add(Me.decodeKeyTextBox)
Me.Controls.Add(Me.decodeKeyLabel)
Me.Controls.Add(Me.mainFormMenuStrip)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.MainMenuStrip = Me.mainFormMenuStrip
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "natiDialog"
Me.Padding = New System.Windows.Forms.Padding(4)
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "nati.net"
Me.mainToolStrip.ResumeLayout(False)
Me.mainToolStrip.PerformLayout()
Me.mainFormMenuStrip.ResumeLayout(False)
Me.mainFormMenuStrip.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region

#Region " ---------- Eigenschaften --------- "
  Private _ConnectionString As System.String
#End Region

#Region " ---------- Konstruktor/ Destruktor --------- "
  Public Sub New()
    InitializeComponent()
  End Sub

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub
#End Region

#Region " ---------- Zugriffsmethoden --------- "
  Private ReadOnly Property DecodeKey() As String
  Get
    Return decodeKeyTextBox.Text
  End Get
  End Property

  Private ReadOnly Property ValueGroup() As String
  Get
    Return valueGroupComboBox.Text
  End Get
  End Property

  Private ReadOnly Property RF() As String
  Get
    Return rfComboBox.Text
  End Get
  End Property
#End Region

#Region " ---------- Ereignismethoden --------- "
  Private Sub onFormLoad _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles Me.Load

    _ConnectionString = BCW.etc.Functions.DecryptString _
    (My.Settings.ConnectionString)
  End Sub

  Private Sub onDecodeKeyTextBoxValidated _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles decodeKeyTextBox.Validated

    valueGroupComboBox.Items.Clear()
    valueGroupComboBox.Items.AddRange(GetValueGroups)
  End Sub

  Private Sub onValueGroupComboBoxSelectedIndexChanged _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles valueGroupComboBox.SelectedIndexChanged

    rfLabel.Text = "Reihenfolge"
    rfComboBox.Items.Clear()
    rfComboBox.SelectedItem = Nothing
    valueTextBox.Text = ""
    updateToolStripButton.Enabled = False
    copyToolStripButton.Enabled = False
    GetRF()
  End Sub

  Private Sub onRfComboBoxSelectedIndexChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles rfComboBox.SelectedIndexChanged

    If Me.RF = "" Then Exit Sub

    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("DECODE(value,'" & Me.DecodeKey & "')")
      sb.From.Add("t_values")
      sb.Where.Add("(DECODE(valuegroup,'" & Me.DecodeKey & "') = '" & Me.ValueGroup & "')")
      sb.Where.Add("AND (rf = " & Me.RF & ")")

      Using dr As MySql.Data.MySqlClient.MySqlDataReader _
      = BCW.Data.MySqlDBResult.ExecuteReader(_ConnectionString, sb.ToString)
        While dr.Read
          valueTextBox.Text = dr.GetString(0)
        End While
      End Using
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Sub onUpdateToolStripButtonClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles updateToolStripButton.Click

    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.UpdateBuilder
      sb.UpadteTables.Add("t_values")
      sb.Set.Add("checked = 'true'")
      sb.Where.Add("(DECODE(valuegroup,'" & Me.DecodeKey & "') = '" & Me.ValueGroup & "')")
      sb.Where.Add("AND (rf = " & Me.RF & ")")

      BCW.Data.MySqlDBResult.ExecuteNonQuery(_ConnectionString, sb.ToString)
      GetRF()
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Sub onCopyToolStripButtonClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles copyToolStripButton.Click

    My.Computer.Clipboard.SetText(valueTextBox.Text)
  End Sub

  Private Sub onCloseClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles closeToolStripButton.Click, endToolStripMenuItem.Click
    Me.Close()
  End Sub

  Private Sub onImportListClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles importListToolStripMenuItem.Click

    ImportList()
  End Sub

  Private Sub onExportListClick _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles exportListToolStripMenuItem.Click
    ExportList()
  End Sub

  Private Sub onDeleteListClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles deleteListToolStripMenuItem.Click

    DeleteList()
  End Sub

  Private Sub onDecodeKeyTextBoxTextChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles decodeKeyTextBox.TextChanged

    importListToolStripMenuItem.Enabled = decodeKeyTextBox.Text.Length > 0
    exportListToolStripMenuItem.Enabled = decodeKeyTextBox.Text.Length > 0
    deleteListToolStripMenuItem.Enabled = decodeKeyTextBox.Text.Length > 0
    valueGroupComboBox.Enabled = decodeKeyTextBox.Text.Length > 0
    valueGroupComboBox.SelectedItem = Nothing
    rfComboBox.Enabled = False
    rfComboBox.Items.Clear()
    rfComboBox.SelectedItem = Nothing
    rfLabel.Text = "Reihenfolge"
    valueTextBox.Text = ""
    copyToolStripButton.Enabled = False
    updateToolStripButton.Enabled = False
  End Sub

  Private Sub onValueGroupComboBoxTextChanged _
  (ByVal sender As Object _
  , ByVal e As System.EventArgs) _
  Handles valueGroupComboBox.TextChanged

    rfComboBox.Enabled = valueGroupComboBox.Text.Length > 0
    If rfComboBox.Text = "" Then
      rfComboBox.Items.Clear()
      rfLabel.Text = "Reihenfolge"
    End If
    copyToolStripButton.Enabled = valueGroupComboBox.Text.Length > 0
    updateToolStripButton.Enabled = valueGroupComboBox.Text.Length > 0
  End Sub

  Private Sub onValueTextBoxTextChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles valueTextBox.TextChanged

    updateToolStripButton.Enabled = valueTextBox.Text.Length > 0
    copyToolStripButton.Enabled = valueTextBox.Text.Length > 0
  End Sub
#End Region

#Region " ---------- Private Methoden --------- "
  Private Function GetValueGroups() As System.String()
    Try
      Dim list As New System.Collections.Generic.List(Of String)

      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("DECODE(valuegroup,'" & Me.DecodeKey & "')")
      sb.From.Add("t_values")
      sb.Group.Add("valuegroup")

      Using dr As MySql.Data.MySqlClient.MySqlDataReader _
      = BCW.Data.MySqlDBResult.ExecuteReader(_ConnectionString, sb.ToString)
        While dr.Read
          list.Add(dr.GetString(0))
        End While
      End Using
      Return list.ToArray
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
      Return Nothing
    End Try
  End Function


  Private Sub GetRF()

    rfComboBox.SelectedItem = Nothing
    rfComboBox.Items.Clear()
    valueTextBox.Text = ""

    Try
      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("rf")
      sb.From.Add("t_values")
      sb.Where.Add("(DECODE(valuegroup,'" & Me.DecodeKey & "') = '" & Me.ValueGroup & "')")
      sb.Where.Add("AND (checked = 'false')")

      Using dr As MySql.Data.MySqlClient.MySqlDataReader _
      = BCW.Data.MySqlDBResult.ExecuteReader(_ConnectionString, sb.ToString)
        While dr.Read
          rfComboBox.Items.Add(dr.GetInt32(0).ToString("000"))
        End While
      End Using

      rfLabel.Text = "Reihenfolge (" & rfComboBox.Items.Count & ")"
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Function GetFileName() As String
    Dim d As New System.Windows.Forms.OpenFileDialog
    d.Filter = "csv-Dateien (*.csv)|*.csv|txt-Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
    d.FilterIndex = 1
    d.RestoreDirectory = True

    Select Case d.ShowDialog
    Case Windows.Forms.DialogResult.Cancel
      Return ""
    Case Else
      Return d.FileName
    End Select
  End Function

  Private Function GetSaveFileName() As String
    Dim d As New System.Windows.Forms.SaveFileDialog
    d.Filter = "csv-Dateien (*.csv)|*.csv"
    d.FilterIndex = 1
    'd.CheckFileExists = True
    'd.CheckPathExists = True
    d.RestoreDirectory = True

    Select Case d.ShowDialog
    Case Windows.Forms.DialogResult.Cancel
      Return ""
    Case Else
      Return d.FileName
    End Select
  End Function

  Private Sub ImportList()

    Try
      Dim filename = GetFileName()
      If filename = "" Then Exit Sub

      Dim f As New DelimiterDialog
      Select Case f.ShowDialog
      Case Windows.Forms.DialogResult.Cancel
        Exit Sub
      End Select
      Dim delimiter As Char = f.Delimiter

      Dim valuegroup = InputBox("Bitte Institut eingeben:", "Institut")
      If valuegroup = "" Then Exit Sub

      Dim list = System.Text.RegularExpressions.Regex.Split _
      (My.Computer.FileSystem.ReadAllText(filename), vbCrLf)

      For Each line In list

        Dim values = line.Split(delimiter)

        Dim rf = values(0)
        Dim value = values(1)

        Dim sb As New BCW.Data.MySqlStatementBuilders.InsertBuilder
        sb.Table = "t_values"
        sb.FieldsAndValues.Add("rf", rf)
        sb.FieldsAndValues.Add("value", "ENCODE('" & value & "', '" & Me.DecodeKey & "')")
        sb.FieldsAndValues.Add("valuegroup", "ENCODE('" & valuegroup & "', '" & Me.DecodeKey & "')")
        sb.FieldsAndValues.Add("checked", "'false'")

        BCW.Data.MySqlDBResult.ExecuteNonQuery(_ConnectionString, sb.ToString)
      Next line

      Clear()
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Sub ExportList()
    Try
      Dim f As New ValueGroupSelectDialog
      f.ValueGroups = GetValueGroups()
      Select Case f.ShowDialog()
      Case Windows.Forms.DialogResult.Cancel
        Exit Sub
      End Select

      Dim valuegroup = f.ValueGroup

      Dim filename = GetSaveFileName()
      If filename = "" Then Exit Sub

      Dim fd As New DelimiterDialog
      Select Case fd.ShowDialog
      Case Windows.Forms.DialogResult.Cancel
        Exit Sub
      End Select
      Dim delimiter As Char = fd.Delimiter

      Dim sb As New BCW.Data.MySqlStatementBuilders.SelectBuilder
      sb.Select.Add("rf")
      sb.Select.Add("DECODE(value, '" & Me.DecodeKey & "')")
      sb.Select.Add("Checked")
      sb.From.Add("t_values")
      sb.Where.Add("(DECODE(valuegroup, '" & Me.DecodeKey & "') = '" & valuegroup & "')")

      Select Case MessageBox.Show("Soll komplette Liste exportiert werden?" _
      & vbCrLf & "(Bereits konsumierte werden ansonsten nicht exportiert)" _
      , "Liste exportieren", MessageBoxButtons.YesNo)
      Case Windows.Forms.DialogResult.No
        sb.Where.Add("AND (Checked = 'false')")
      End Select

      sb.Order.Add("rf")

      Dim list As New System.Text.StringBuilder
      list.AppendLine("RF" & delimiter & "Value" & delimiter & "Checked")

      Using dr As MySql.Data.MySqlClient.MySqlDataReader _
      = BCW.Data.MySqlDBResult.ExecuteReader(_ConnectionString, sb.ToString)
        While dr.Read
          list.AppendLine(dr.GetString(0) & delimiter & dr.GetString(1) & delimiter & dr.GetString(2))
        End While
      End Using

      My.Computer.FileSystem.WriteAllText(filename, list.ToString, False)

      Process.Start(filename)
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Sub DeleteList()
    Try
      Dim f As New ValueGroupSelectDialog
      f.ValueGroups = GetValueGroups()
      Select Case f.ShowDialog()
      Case Windows.Forms.DialogResult.Cancel
        Exit Sub
      End Select

      Dim valuegroup = f.ValueGroup

      Using con As New MySql.Data.MySqlClient.MySqlConnection(_ConnectionString)
        con.Open()

        Dim sb As New BCW.Data.MySqlStatementBuilders.DeleteBuilder
        sb.Table = "t_values"
        sb.Where.Add("DECODE(valuegroup, '" & Me.DecodeKey & "') = '" & valuegroup & "'")

        BCW.Data.MySqlDBResult.ExecuteNonQuery(_ConnectionString, sb.ToString)
      End Using

      clear()
    Catch ex As Exception
      BCW.etc.Functions.ShowError(ex)
    End Try
  End Sub

  Private Sub Clear()
    valueGroupComboBox.Items.Clear()
    valueGroupComboBox.Items.AddRange(GetValueGroups)
    rfLabel.Text = "Reihenfolge"
    rfComboBox.Items.Clear()
    rfComboBox.SelectedItem = Nothing
    valueTextBox.Text = ""
    updateToolStripButton.Enabled = False
    copyToolStripButton.Enabled = False
    rfComboBox.Enabled = False
  End Sub
#End Region

End Class
