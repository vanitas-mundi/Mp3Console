Option Explicit On
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class PasswordDialog

Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "
Private WithEvents newPWDPasswordStrengthViewer As BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Private WithEvents oldPWDTextBox As System.Windows.Forms.TextBox
Private WithEvents oldPWDLabel As System.Windows.Forms.Label
Private WithEvents mainOKButton As System.Windows.Forms.Button
Private WithEvents newPWDLabel As System.Windows.Forms.Label
Private WithEvents newPWDTextBox As System.Windows.Forms.TextBox
Private WithEvents retypePWDLabel As System.Windows.Forms.Label
Private WithEvents retypePWDTextBox As System.Windows.Forms.TextBox
Private WithEvents oldPWDPasswordStrengthViewer As BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Private WithEvents retypePWDPasswordStrengthViewer As BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Private WithEvents mainCancelButton As System.Windows.Forms.Button
  ' Für Windows Form-Designer erforderlich
  Private components As System.ComponentModel.IContainer

  'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
  'Sie kann mit dem Windows Form-Designer modifiziert werden.
  'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.newPWDPasswordStrengthViewer = New BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Me.oldPWDTextBox = New System.Windows.Forms.TextBox
Me.oldPWDLabel = New System.Windows.Forms.Label
Me.mainOKButton = New System.Windows.Forms.Button
Me.newPWDLabel = New System.Windows.Forms.Label
Me.newPWDTextBox = New System.Windows.Forms.TextBox
Me.retypePWDLabel = New System.Windows.Forms.Label
Me.retypePWDTextBox = New System.Windows.Forms.TextBox
Me.oldPWDPasswordStrengthViewer = New BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Me.retypePWDPasswordStrengthViewer = New BCW.PasswordStrength.Windows.Forms.PasswordStrengthViewer
Me.mainCancelButton = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'newPWDPasswordStrengthViewer
'
Me.newPWDPasswordStrengthViewer.AutoScroll = True
Me.newPWDPasswordStrengthViewer.BestPasswordColor = System.Drawing.Color.Green
Me.newPWDPasswordStrengthViewer.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.newPWDPasswordStrengthViewer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
Me.newPWDPasswordStrengthViewer.Location = New System.Drawing.Point(172, 72)
Me.newPWDPasswordStrengthViewer.Name = "newPWDPasswordStrengthViewer"
Me.newPWDPasswordStrengthViewer.Padding = New System.Windows.Forms.Padding(2)
Me.newPWDPasswordStrengthViewer.Password = ""
Me.newPWDPasswordStrengthViewer.PasswordStrength = 0
Me.newPWDPasswordStrengthViewer.Size = New System.Drawing.Size(145, 22)
Me.newPWDPasswordStrengthViewer.TabIndex = 5
Me.newPWDPasswordStrengthViewer.TabStop = False
Me.newPWDPasswordStrengthViewer.WeakPasswordColor = System.Drawing.Color.Yellow
'
'oldPWDTextBox
'
Me.oldPWDTextBox.Location = New System.Drawing.Point(12, 27)
Me.oldPWDTextBox.Name = "oldPWDTextBox"
Me.oldPWDTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
Me.oldPWDTextBox.Size = New System.Drawing.Size(154, 20)
Me.oldPWDTextBox.TabIndex = 1
'
'oldPWDLabel
'
Me.oldPWDLabel.AutoSize = True
Me.oldPWDLabel.Location = New System.Drawing.Point(12, 11)
Me.oldPWDLabel.Name = "oldPWDLabel"
Me.oldPWDLabel.Size = New System.Drawing.Size(78, 13)
Me.oldPWDLabel.TabIndex = 0
Me.oldPWDLabel.Text = "Altes Kennwort"
'
'mainOKButton
'
Me.mainOKButton.Location = New System.Drawing.Point(239, 168)
Me.mainOKButton.Name = "mainOKButton"
Me.mainOKButton.Size = New System.Drawing.Size(78, 30)
Me.mainOKButton.TabIndex = 10
Me.mainOKButton.Text = "OK"
Me.mainOKButton.UseVisualStyleBackColor = True
'
'newPWDLabel
'
Me.newPWDLabel.AutoSize = True
Me.newPWDLabel.Location = New System.Drawing.Point(12, 58)
Me.newPWDLabel.Name = "newPWDLabel"
Me.newPWDLabel.Size = New System.Drawing.Size(86, 13)
Me.newPWDLabel.TabIndex = 3
Me.newPWDLabel.Text = "Neues Kennwort"
'
'newPWDTextBox
'
Me.newPWDTextBox.Location = New System.Drawing.Point(12, 74)
Me.newPWDTextBox.Name = "newPWDTextBox"
Me.newPWDTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
Me.newPWDTextBox.Size = New System.Drawing.Size(154, 20)
Me.newPWDTextBox.TabIndex = 4
'
'retypePWDLabel
'
Me.retypePWDLabel.AutoSize = True
Me.retypePWDLabel.Location = New System.Drawing.Point(12, 106)
Me.retypePWDLabel.Name = "retypePWDLabel"
Me.retypePWDLabel.Size = New System.Drawing.Size(146, 13)
Me.retypePWDLabel.TabIndex = 6
Me.retypePWDLabel.Text = "Neues Kennwort wiederholen"
'
'retypePWDTextBox
'
Me.retypePWDTextBox.Location = New System.Drawing.Point(12, 122)
Me.retypePWDTextBox.Name = "retypePWDTextBox"
Me.retypePWDTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
Me.retypePWDTextBox.Size = New System.Drawing.Size(154, 20)
Me.retypePWDTextBox.TabIndex = 7
'
'oldPWDPasswordStrengthViewer
'
Me.oldPWDPasswordStrengthViewer.AutoScroll = True
Me.oldPWDPasswordStrengthViewer.BestPasswordColor = System.Drawing.Color.Green
Me.oldPWDPasswordStrengthViewer.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.oldPWDPasswordStrengthViewer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
Me.oldPWDPasswordStrengthViewer.Location = New System.Drawing.Point(172, 27)
Me.oldPWDPasswordStrengthViewer.Name = "oldPWDPasswordStrengthViewer"
Me.oldPWDPasswordStrengthViewer.Padding = New System.Windows.Forms.Padding(2)
Me.oldPWDPasswordStrengthViewer.Password = ""
Me.oldPWDPasswordStrengthViewer.PasswordStrength = 0
Me.oldPWDPasswordStrengthViewer.Size = New System.Drawing.Size(145, 22)
Me.oldPWDPasswordStrengthViewer.TabIndex = 2
Me.oldPWDPasswordStrengthViewer.TabStop = False
Me.oldPWDPasswordStrengthViewer.WeakPasswordColor = System.Drawing.Color.Yellow
'
'retypePWDPasswordStrengthViewer
'
Me.retypePWDPasswordStrengthViewer.AutoScroll = True
Me.retypePWDPasswordStrengthViewer.BestPasswordColor = System.Drawing.Color.Green
Me.retypePWDPasswordStrengthViewer.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.retypePWDPasswordStrengthViewer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
Me.retypePWDPasswordStrengthViewer.Location = New System.Drawing.Point(172, 120)
Me.retypePWDPasswordStrengthViewer.Name = "retypePWDPasswordStrengthViewer"
Me.retypePWDPasswordStrengthViewer.Padding = New System.Windows.Forms.Padding(2)
Me.retypePWDPasswordStrengthViewer.Password = ""
Me.retypePWDPasswordStrengthViewer.PasswordStrength = 0
Me.retypePWDPasswordStrengthViewer.Size = New System.Drawing.Size(145, 22)
Me.retypePWDPasswordStrengthViewer.TabIndex = 8
Me.retypePWDPasswordStrengthViewer.TabStop = False
Me.retypePWDPasswordStrengthViewer.WeakPasswordColor = System.Drawing.Color.Yellow
'
'mainCancelButton
'
Me.mainCancelButton.Location = New System.Drawing.Point(155, 168)
Me.mainCancelButton.Name = "mainCancelButton"
Me.mainCancelButton.Size = New System.Drawing.Size(78, 30)
Me.mainCancelButton.TabIndex = 9
Me.mainCancelButton.Text = "Abbrechen"
Me.mainCancelButton.UseVisualStyleBackColor = True
'
'PasswordDialog
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(327, 211)
Me.Controls.Add(Me.mainCancelButton)
Me.Controls.Add(Me.retypePWDPasswordStrengthViewer)
Me.Controls.Add(Me.oldPWDPasswordStrengthViewer)
Me.Controls.Add(Me.retypePWDLabel)
Me.Controls.Add(Me.retypePWDTextBox)
Me.Controls.Add(Me.newPWDLabel)
Me.Controls.Add(Me.newPWDTextBox)
Me.Controls.Add(Me.mainOKButton)
Me.Controls.Add(Me.oldPWDLabel)
Me.Controls.Add(Me.oldPWDTextBox)
Me.Controls.Add(Me.newPWDPasswordStrengthViewer)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
Me.Name = "PasswordDialog"
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Kennwort ändern"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _User As User
  Private _ConnectionString As String = ""
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal connectionString As String _
  , ByVal user As User)
    '{Konstruktor}
    MyBase.New()
    InitializeComponent()
    _User = user
    _ConnectionString = connectionString
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
  Private Sub passwordsTextChanged _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles oldPWDTextBox.TextChanged _
  , newPWDTextBox.TextChanged _
  , retypePWDTextBox.TextChanged

    Select Case True
    Case sender Is oldPWDTextBox
      oldPWDPasswordStrengthViewer.Password = oldPWDTextBox.Text
    Case sender Is newPWDTextBox
      newPWDPasswordStrengthViewer.Password = newPWDTextBox.Text
    Case sender Is retypePWDTextBox
      retypePWDPasswordStrengthViewer.Password = retypePWDTextBox.Text
    End Select
  End Sub

  Private Sub onCancelClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles mainCancelButton.Click

    Me.Close()
  End Sub

  Private Sub onOKClick _
  (ByVal sender As System.Object _
  , ByVal e As System.EventArgs) _
  Handles mainOKButton.Click

    If changePWDOK Then Me.Close()
  End Sub
#End Region '{Private Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function changePWDOK() As Boolean
    Try
      If Not _User.PasswordIs(oldPWDTextBox.Text) Then
        MessageBox.Show("Altes Kennwort stimmt nicht mit Eingabe überein!" _
        , "Kennwort ändern", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If

      If newPWDTextBox.Text.Trim = "" Then
        MessageBox.Show("Bitte geben Sie ein neues Kennwort ein!" _
        , "Kennwort ändern", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If

      If newPWDTextBox.Text <> retypePWDTextBox.Text Then
        MessageBox.Show("Neues Kennwort stimmt Kennwortwiederholung überein!" _
        , "Kennwort ändern", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If

      _User.Password = newPWDTextBox.Text

      MessageBox.Show("Kennwort wurde geändert!", "Kennwort ändern" _
      , MessageBoxButtons.OK, MessageBoxIcon.Information)

      Return True
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Fehler" _
      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End Try
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class '{Klasse PasswordDialog}
End Namespace
