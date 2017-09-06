Public Class FtpTabForm
  Inherits BCW.TabbedBrowsing.Windows.Forms.TabForm

#Region " ---------- Designer ---------------- "

  Private WithEvents mainEditorControl As SSP.MyPage.Windows.Forms.EditorControl

  Private Sub InitializeComponent()
Me.mainEditorControl = New SSP.MyPage.Windows.Forms.EditorControl()
Me.SuspendLayout()
'
'mainEditorControl
'
Me.mainEditorControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.mainEditorControl.Location = New System.Drawing.Point(0, 0)
Me.mainEditorControl.Name = "mainEditorControl"
Me.mainEditorControl.Padding = New System.Windows.Forms.Padding(4)
Me.mainEditorControl.Size = New System.Drawing.Size(977, 588)
Me.mainEditorControl.TabIndex = 0
'
'FtpTabForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.ClientSize = New System.Drawing.Size(977, 588)
Me.Controls.Add(Me.mainEditorControl)
Me.Name = "FtpTabForm"
Me.ResumeLayout(False)

End Sub
#End Region

#Region " ---------- Eigenschaften der Klasse ---------------- "
  Private _TextFileDownloadedInfo As BCW.FtpLib.Windows.Forms.TextFileDownloadedEventArgs
#End Region

#Region " ---------- Konstruktor der Klasse ---------------- "
  Public Sub New _
  (ByVal textFileDownloadedInfo _
  As BCW.FtpLib.Windows.Forms.TextFileDownloadedEventArgs)

    MyBase.New()
    InitializeComponent()
    _TextFileDownloadedInfo = textFileDownloadedInfo
    mainEditorControl.Text = _TextFileDownloadedInfo.FileDataString

    mainEditorControl.ToolStrip.Items.Insert _
    (0, New ToolStripButton("Datei speichern" _
    , My.Resources.save16x16, AddressOf onSaveClick))
    Me.SaveEnabled = False

    mainEditorControl.ToolStrip.Items.Insert(1, New ToolStripSeparator)

    AddHandler mainEditorControl.Editor.TextChanged, AddressOf OnEditorTextChanged
  End Sub
#End Region

#Region " ---------- Zugrifsmethoden der Klasse ---------------- "
  Public Property SaveEnabled As Boolean
  Get
    Return mainEditorControl.ToolStrip.Items.Item(0).Enabled
  End Get
  Set(ByVal value As Boolean)
    mainEditorControl.ToolStrip.Items.Item(0).Enabled = value
  End Set
  End Property

  Public Property TextFileDownloadedInfo _
  As BCW.FtpLib.Windows.Forms.TextFileDownloadedEventArgs
  Get
    Return _TextFileDownloadedInfo
  End Get
  Set(ByVal value As BCW.FtpLib.Windows.Forms.TextFileDownloadedEventArgs)
    _TextFileDownloadedInfo = value
  End Set
  End Property

  Public Shadows Property Text As String
  Get
    Return mainEditorControl.Text
  End Get
  Set(ByVal value As String)
    mainEditorControl.Text = value
  End Set
  End Property

#End Region

#Region " ---------- Ereignismethoden der Klasse ---------------- "
  Private Sub onSaveClick _
  (ByVal sender As Object _
  , ByVal e As EventArgs)

    RestoreFile()
    Me.SaveEnabled = False
  End Sub

  Private Sub OnEditorTextChanged _
  (ByVal sender As Object _
  , ByVal e As EventArgs)

    Me.SaveEnabled = True
  End Sub

  Private Sub onTabFormClosing _
  (ByVal sender As Object _
  , ByVal e As System.Windows.Forms.FormClosingEventArgs) _
  Handles Me.FormClosing

    If Me.SaveEnabled Then
      Select Case BCW.etc.Message.Question _
      ("Datei '" & _TextFileDownloadedInfo.FTPfileInfo.Filename _
      & "' noch nicht gespeichert!" & vbCrLf & vbCrLf _
      & "Sollen die Änderungen zuvor gespeichert werden?")
      Case System.Windows.Forms.DialogResult.Yes
        RestoreFile()
      End Select
    End If
  End Sub
#End Region

#Region " ---------- Private Methoden der Klasse ---------------- "
  Private Sub RestoreFile()
    Dim ftpBrowser = New BCW.FtpLib.Windows.Forms.FTPbrowser
    Try
      ftpBrowser.RestoreFile _
      (_TextFileDownloadedInfo.FtpServer _
      , _TextFileDownloadedInfo.FTPfileInfo _
      , mainEditorControl.Text)
    Catch ex As Exception
      BCW.etc.Message.Error("Es ist ein Fehler aufgetreten!")
    End Try
  End Sub
#End Region

End Class
