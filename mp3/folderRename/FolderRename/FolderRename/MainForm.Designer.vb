<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
Me.Button1 = New System.Windows.Forms.Button()
Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
Me.TextBox1 = New System.Windows.Forms.TextBox()
Me.Button2 = New System.Windows.Forms.Button()
Me.TreeView1 = New System.Windows.Forms.TreeView()
Me.Button3 = New System.Windows.Forms.Button()
Me.TreeView2 = New System.Windows.Forms.TreeView()
Me.Label1 = New System.Windows.Forms.Label()
Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
Me.Panel1 = New System.Windows.Forms.Panel()
CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SplitContainer1.Panel1.SuspendLayout()
Me.SplitContainer1.Panel2.SuspendLayout()
Me.SplitContainer1.SuspendLayout()
CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SplitContainer2.Panel1.SuspendLayout()
Me.SplitContainer2.Panel2.SuspendLayout()
Me.SplitContainer2.SuspendLayout()
Me.Panel1.SuspendLayout()
Me.SuspendLayout()
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(3, 6)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(86, 29)
Me.Button1.TabIndex = 0
Me.Button1.Text = "Preview"
Me.Button1.UseVisualStyleBackColor = True
'
'TextBox1
'
Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Left
Me.TextBox1.Location = New System.Drawing.Point(0, 0)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.ReadOnly = True
Me.TextBox1.Size = New System.Drawing.Size(213, 20)
Me.TextBox1.TabIndex = 1
'
'Button2
'
Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
Me.Button2.Location = New System.Drawing.Point(213, 0)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(32, 21)
Me.Button2.TabIndex = 2
Me.Button2.Text = "..."
Me.Button2.UseVisualStyleBackColor = True
'
'TreeView1
'
Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
Me.TreeView1.Location = New System.Drawing.Point(0, 0)
Me.TreeView1.Name = "TreeView1"
Me.TreeView1.Size = New System.Drawing.Size(551, 235)
Me.TreeView1.TabIndex = 3
'
'Button3
'
Me.Button3.Location = New System.Drawing.Point(95, 6)
Me.Button3.Name = "Button3"
Me.Button3.Size = New System.Drawing.Size(76, 29)
Me.Button3.TabIndex = 4
Me.Button3.Text = "Rename"
Me.Button3.UseVisualStyleBackColor = True
'
'TreeView2
'
Me.TreeView2.Dock = System.Windows.Forms.DockStyle.Fill
Me.TreeView2.Location = New System.Drawing.Point(0, 0)
Me.TreeView2.Name = "TreeView2"
Me.TreeView2.Size = New System.Drawing.Size(551, 220)
Me.TreeView2.TabIndex = 5
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
Me.Label1.Location = New System.Drawing.Point(538, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(13, 13)
Me.Label1.TabIndex = 6
Me.Label1.Text = "0"
'
'SplitContainer1
'
Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
Me.SplitContainer1.Name = "SplitContainer1"
Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
'
'SplitContainer1.Panel1
'
Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox1)
Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
'
'SplitContainer1.Panel2
'
Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
Me.SplitContainer1.Size = New System.Drawing.Size(551, 488)
Me.SplitContainer1.SplitterDistance = 25
Me.SplitContainer1.TabIndex = 7
'
'SplitContainer2
'
Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
Me.SplitContainer2.Name = "SplitContainer2"
Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
'
'SplitContainer2.Panel1
'
Me.SplitContainer2.Panel1.Controls.Add(Me.TreeView1)
'
'SplitContainer2.Panel2
'
Me.SplitContainer2.Panel2.Controls.Add(Me.TreeView2)
Me.SplitContainer2.Size = New System.Drawing.Size(551, 459)
Me.SplitContainer2.SplitterDistance = 235
Me.SplitContainer2.TabIndex = 8
'
'Panel1
'
Me.Panel1.Controls.Add(Me.Button1)
Me.Panel1.Controls.Add(Me.Button3)
Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
Me.Panel1.Location = New System.Drawing.Point(0, 488)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(551, 44)
Me.Panel1.TabIndex = 8
'
'MainForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(551, 532)
Me.Controls.Add(Me.SplitContainer1)
Me.Controls.Add(Me.Panel1)
Me.Name = "MainForm"
Me.Text = "FolderRename"
Me.SplitContainer1.Panel1.ResumeLayout(False)
Me.SplitContainer1.Panel1.PerformLayout()
Me.SplitContainer1.Panel2.ResumeLayout(False)
CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
Me.SplitContainer1.ResumeLayout(False)
Me.SplitContainer2.Panel1.ResumeLayout(False)
Me.SplitContainer2.Panel2.ResumeLayout(False)
CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
Me.SplitContainer2.ResumeLayout(False)
Me.Panel1.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
