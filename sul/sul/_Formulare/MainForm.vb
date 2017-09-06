Option Explicit On 
Option Strict On
Option Infer On


Namespace Windows.Forms

Public Class MainForm

Inherits System.Windows.Forms.Form

Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
Friend WithEvents Button1 As System.Windows.Forms.Button
Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
Friend WithEvents Button2 As System.Windows.Forms.Button
Friend WithEvents Button3 As System.Windows.Forms.Button
#Region " Vom Windows Form Designer generierter Code "
    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Button1 = New System.Windows.Forms.Button
Me.DataGridView1 = New System.Windows.Forms.DataGridView
Me.Button2 = New System.Windows.Forms.Button
Me.Button3 = New System.Windows.Forms.Button
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(64, 12)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(64, 20)
Me.TextBox1.TabIndex = 0
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(12, 12)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(46, 35)
Me.Button1.TabIndex = 1
Me.Button1.Text = "Button1"
Me.Button1.UseVisualStyleBackColor = True
'
'DataGridView1
'
Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.DataGridView1.Location = New System.Drawing.Point(21, 79)
Me.DataGridView1.Name = "DataGridView1"
Me.DataGridView1.Size = New System.Drawing.Size(689, 504)
Me.DataGridView1.TabIndex = 2
'
'Button2
'
Me.Button2.Location = New System.Drawing.Point(147, 12)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(76, 30)
Me.Button2.TabIndex = 3
Me.Button2.Text = "load"
Me.Button2.UseVisualStyleBackColor = True
'
'Button3
'
Me.Button3.Location = New System.Drawing.Point(229, 12)
Me.Button3.Name = "Button3"
Me.Button3.Size = New System.Drawing.Size(76, 30)
Me.Button3.TabIndex = 4
Me.Button3.Text = "save"
Me.Button3.UseVisualStyleBackColor = True
'
'MainForm
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(734, 631)
Me.Controls.Add(Me.Button3)
Me.Controls.Add(Me.Button2)
Me.Controls.Add(Me.DataGridView1)
Me.Controls.Add(Me.Button1)
Me.Controls.Add(Me.TextBox1)
Me.Name = "MainForm"
Me.Text = "MainForm"
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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

      ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
      InitializeComponent()

      ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
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
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Dim dt As New DataTable("attributescores")
      dt.Columns.Add("score")
      dt.Columns.Add("Mana")
      dt.Columns.Add("Gottesgunst")
      dt.Columns.Add("Autonomie")
      dt.Columns.Add("Bewegungsrate")
      dt.Columns.Add("Offensivbonus")
      dt.Columns.Add("Defensivbonus")
      dt.Columns.Add("Ausweichen")
      dt.Columns.Add("Lernbegabung")
      dt.Columns.Add("Konzentration")
      dt.Columns.Add("Sprachbegabung")
      dt.Columns.Add("Willenskraft")
      dt.Columns.Add("Tragkraft")
      dt.Columns.Add("Ausdauer")
      dt.Columns.Add("Nahkampfschadensbonus")
      dt.Columns.Add("Konstitution")
      dt.Columns.Add("Kampfreflexbonus")
      dt.Columns.Add("Initiativebonus")
      dt.Columns.Add("Fernkampfschadensbonus")
      dt.Columns.Add("Aufmerksamkeit")
      dt.Columns.Add("Kenntnisbonus")
      dt.Columns.Add("Individualbonus")
      dt.WriteXml("v:\sul\attributescores.xml")
      dt.WriteXmlSchema("v:\sul\attributescores.xsl")


End Sub

Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
  Dim dt As New DataTable
  dt.ReadXmlSchema("v:\sul\attributescores.xsl")
  dt.ReadXml("v:\sul\attributescores.xml")
  DataGridView1.DataSource = dt

End Sub

Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      Dim dt As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
      dt.WriteXml("v:\sul\attributescores.xml")
      dt.WriteXmlSchema("v:\sul\attributescores.xsl")

End Sub
End Class '{Klasse MainForm}
End Namespace
