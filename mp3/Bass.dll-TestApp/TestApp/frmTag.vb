Option Infer On

'*** File Details *****************************************************************
'*   File        : frmTag.vb
'*   Author      : Bernd Niedergesaeee used code from Rick Ratayczak
'*   Sorry I am not a VB guy and this is my first VB code ;-)
'*   But it should be a good starting point
'*
'*   Created On  : 10/21/2005
'* 
'*   Requires    : Bass.Net.dll
'*   Type        : VB.NET Class
'*   Description : Stream Example
'*
'* Before using: copy the bass.dll in your bin directory!!!
'**********************************************************************************

Imports Un4seen.Bass
Imports BassTags = Un4seen.Bass.AddOn.Tags.BassTags

Public Class frmTag
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        

        MyBase.New()

        Application.EnableVisualStyles()
        Application.DoEvents()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OFD1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtArtist As System.Windows.Forms.TextBox
    Friend WithEvents txtAlbum As System.Windows.Forms.TextBox
    Friend WithEvents txtGenre As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtTrack As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents tbVolume As System.Windows.Forms.TrackBar
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbLeft As System.Windows.Forms.ProgressBar
    Friend WithEvents pbRight As System.Windows.Forms.ProgressBar
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lAbout As System.Windows.Forms.LinkLabel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnVis As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PictureBoxWave As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.OFD1 = New System.Windows.Forms.OpenFileDialog
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.btnBrowse = New System.Windows.Forms.Button
Me.btnPlay = New System.Windows.Forms.Button
Me.btnStop = New System.Windows.Forms.Button
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.btnVis = New System.Windows.Forms.Button
Me.Label2 = New System.Windows.Forms.Label
Me.txtTitle = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.txtArtist = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.txtAlbum = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.txtGenre = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.txtYear = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.txtTrack = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.txtComment = New System.Windows.Forms.TextBox
Me.tbVolume = New System.Windows.Forms.TrackBar
Me.Label9 = New System.Windows.Forms.Label
Me.lblStatus = New System.Windows.Forms.Label
Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
Me.pbLeft = New System.Windows.Forms.ProgressBar
Me.pbRight = New System.Windows.Forms.ProgressBar
Me.lblInfo = New System.Windows.Forms.Label
Me.lAbout = New System.Windows.Forms.LinkLabel
Me.Label10 = New System.Windows.Forms.Label
Me.PictureBoxWave = New System.Windows.Forms.PictureBox
Me.Button1 = New System.Windows.Forms.Button
Me.ComboBox1 = New System.Windows.Forms.ComboBox
Me.Button2 = New System.Windows.Forms.Button
Me.Button3 = New System.Windows.Forms.Button
Me.Button4 = New System.Windows.Forms.Button
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.TrackBar1 = New System.Windows.Forms.TrackBar
Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
Me.Button5 = New System.Windows.Forms.Button
CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.PictureBoxWave, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'OFD1
'
Me.OFD1.Filter = "Audio Files (*.mp3;*.ogg;*.wma;*.wav)|*.mp3;*.ogg;*.wma;*.wav"
Me.OFD1.Title = "Select Audio File"
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(85, 300)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(200, 20)
Me.TextBox1.TabIndex = 1
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(5, 304)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(63, 13)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Filename:"
'
'btnBrowse
'
Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnBrowse.Location = New System.Drawing.Point(300, 300)
Me.btnBrowse.Name = "btnBrowse"
Me.btnBrowse.Size = New System.Drawing.Size(32, 23)
Me.btnBrowse.TabIndex = 2
Me.btnBrowse.Text = "..."
Me.ToolTip1.SetToolTip(Me.btnBrowse, "Browse For File")
'
'btnPlay
'
Me.btnPlay.Enabled = False
Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnPlay.Location = New System.Drawing.Point(416, 300)
Me.btnPlay.Name = "btnPlay"
Me.btnPlay.Size = New System.Drawing.Size(52, 23)
Me.btnPlay.TabIndex = 3
Me.btnPlay.Text = "Play"
Me.ToolTip1.SetToolTip(Me.btnPlay, "Play")
'
'btnStop
'
Me.btnStop.Enabled = False
Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnStop.Location = New System.Drawing.Point(476, 300)
Me.btnStop.Name = "btnStop"
Me.btnStop.Size = New System.Drawing.Size(52, 23)
Me.btnStop.TabIndex = 4
Me.btnStop.Text = "Stop"
Me.ToolTip1.SetToolTip(Me.btnStop, "Stop")
'
'btnVis
'
Me.btnVis.FlatStyle = System.Windows.Forms.FlatStyle.System
Me.btnVis.Location = New System.Drawing.Point(304, 408)
Me.btnVis.Name = "btnVis"
Me.btnVis.Size = New System.Drawing.Size(220, 23)
Me.btnVis.TabIndex = 30
Me.btnVis.Text = "Show / Hide Visualizations"
Me.ToolTip1.SetToolTip(Me.btnVis, "Show or hide the visualizations")
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(5, 332)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(36, 13)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Title:"
'
'txtTitle
'
Me.txtTitle.Location = New System.Drawing.Point(85, 328)
Me.txtTitle.Name = "txtTitle"
Me.txtTitle.ReadOnly = True
Me.txtTitle.Size = New System.Drawing.Size(200, 20)
Me.txtTitle.TabIndex = 6
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(5, 364)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(42, 13)
Me.Label3.TabIndex = 7
Me.Label3.Text = "Artist:"
'
'txtArtist
'
Me.txtArtist.Location = New System.Drawing.Point(85, 360)
Me.txtArtist.Name = "txtArtist"
Me.txtArtist.ReadOnly = True
Me.txtArtist.Size = New System.Drawing.Size(200, 20)
Me.txtArtist.TabIndex = 8
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(5, 396)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(48, 13)
Me.Label4.TabIndex = 9
Me.Label4.Text = "Album:"
'
'txtAlbum
'
Me.txtAlbum.Location = New System.Drawing.Point(85, 392)
Me.txtAlbum.Name = "txtAlbum"
Me.txtAlbum.ReadOnly = True
Me.txtAlbum.Size = New System.Drawing.Size(200, 20)
Me.txtAlbum.TabIndex = 10
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(5, 428)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(47, 13)
Me.Label5.TabIndex = 11
Me.Label5.Text = "Genre:"
'
'txtGenre
'
Me.txtGenre.Location = New System.Drawing.Point(85, 424)
Me.txtGenre.Name = "txtGenre"
Me.txtGenre.ReadOnly = True
Me.txtGenre.Size = New System.Drawing.Size(200, 20)
Me.txtGenre.TabIndex = 12
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(5, 460)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(38, 13)
Me.Label6.TabIndex = 13
Me.Label6.Text = "Year:"
'
'txtYear
'
Me.txtYear.Location = New System.Drawing.Point(85, 456)
Me.txtYear.Name = "txtYear"
Me.txtYear.ReadOnly = True
Me.txtYear.Size = New System.Drawing.Size(60, 20)
Me.txtYear.TabIndex = 14
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(157, 460)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(44, 13)
Me.Label7.TabIndex = 15
Me.Label7.Text = "Track:"
'
'txtTrack
'
Me.txtTrack.Location = New System.Drawing.Point(245, 456)
Me.txtTrack.Name = "txtTrack"
Me.txtTrack.ReadOnly = True
Me.txtTrack.Size = New System.Drawing.Size(40, 20)
Me.txtTrack.TabIndex = 16
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(5, 488)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(68, 13)
Me.Label8.TabIndex = 17
Me.Label8.Text = "Comment:"
'
'txtComment
'
Me.txtComment.Location = New System.Drawing.Point(85, 488)
Me.txtComment.Name = "txtComment"
Me.txtComment.ReadOnly = True
Me.txtComment.Size = New System.Drawing.Size(200, 20)
Me.txtComment.TabIndex = 18
'
'tbVolume
'
Me.tbVolume.Location = New System.Drawing.Point(304, 352)
Me.tbVolume.Maximum = 100
Me.tbVolume.Name = "tbVolume"
Me.tbVolume.Size = New System.Drawing.Size(220, 45)
Me.tbVolume.TabIndex = 20
Me.tbVolume.TickFrequency = 5
Me.tbVolume.Value = 100
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Location = New System.Drawing.Point(304, 332)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(92, 13)
Me.Label9.TabIndex = 19
Me.Label9.Text = "Volume: 100%"
'
'lblStatus
'
Me.lblStatus.AutoSize = True
Me.lblStatus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblStatus.Location = New System.Drawing.Point(5, 532)
Me.lblStatus.Name = "lblStatus"
Me.lblStatus.Size = New System.Drawing.Size(298, 14)
Me.lblStatus.TabIndex = 23
Me.lblStatus.Text = "Elapsed: 00:00 Remain: 00:00 Total: 00:00"
'
'Timer1
'
Me.Timer1.Interval = 50
'
'pbLeft
'
Me.pbLeft.Location = New System.Drawing.Point(336, 532)
Me.pbLeft.Maximum = 8192
Me.pbLeft.Name = "pbLeft"
Me.pbLeft.Size = New System.Drawing.Size(208, 12)
Me.pbLeft.Step = 0
Me.pbLeft.TabIndex = 24
'
'pbRight
'
Me.pbRight.Location = New System.Drawing.Point(336, 548)
Me.pbRight.Maximum = 8192
Me.pbRight.Name = "pbRight"
Me.pbRight.Size = New System.Drawing.Size(208, 12)
Me.pbRight.Step = 0
Me.pbRight.TabIndex = 25
'
'lblInfo
'
Me.lblInfo.Location = New System.Drawing.Point(304, 440)
Me.lblInfo.Name = "lblInfo"
Me.lblInfo.Size = New System.Drawing.Size(244, 72)
Me.lblInfo.TabIndex = 27
Me.lblInfo.Text = "Information"
Me.lblInfo.Visible = False
'
'lAbout
'
Me.lAbout.AutoSize = True
Me.lAbout.Location = New System.Drawing.Point(348, 304)
Me.lAbout.Name = "lAbout"
Me.lAbout.Size = New System.Drawing.Size(40, 13)
Me.lAbout.TabIndex = 28
Me.lAbout.TabStop = True
Me.lAbout.Text = "About"
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(336, 516)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(100, 16)
Me.Label10.TabIndex = 29
Me.Label10.Text = "Label10"
'
'PictureBoxWave
'
Me.PictureBoxWave.BackColor = System.Drawing.Color.Black
Me.PictureBoxWave.Location = New System.Drawing.Point(12, 272)
Me.PictureBoxWave.Name = "PictureBoxWave"
Me.PictureBoxWave.Size = New System.Drawing.Size(532, 48)
Me.PictureBoxWave.TabIndex = 31
Me.PictureBoxWave.TabStop = False
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(12, 60)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(92, 33)
Me.Button1.TabIndex = 32
Me.Button1.Text = "init"
Me.Button1.UseVisualStyleBackColor = True
'
'ComboBox1
'
Me.ComboBox1.FormattingEnabled = True
Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
Me.ComboBox1.Name = "ComboBox1"
Me.ComboBox1.Size = New System.Drawing.Size(175, 21)
Me.ComboBox1.TabIndex = 33
'
'Button2
'
Me.Button2.Location = New System.Drawing.Point(110, 64)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(71, 25)
Me.Button2.TabIndex = 34
Me.Button2.Text = "pl"
Me.Button2.UseVisualStyleBackColor = True
'
'Button3
'
Me.Button3.Location = New System.Drawing.Point(187, 64)
Me.Button3.Name = "Button3"
Me.Button3.Size = New System.Drawing.Size(80, 28)
Me.Button3.TabIndex = 35
Me.Button3.Text = "||"
Me.Button3.UseVisualStyleBackColor = True
'
'Button4
'
Me.Button4.Location = New System.Drawing.Point(273, 51)
Me.Button4.Name = "Button4"
Me.Button4.Size = New System.Drawing.Size(103, 31)
Me.Button4.TabIndex = 36
Me.Button4.Text = "Button4"
Me.Button4.UseVisualStyleBackColor = True
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(74, 34)
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.Size = New System.Drawing.Size(107, 20)
Me.TextBox2.TabIndex = 37
'
'TrackBar1
'
Me.TrackBar1.Location = New System.Drawing.Point(229, 9)
Me.TrackBar1.Maximum = 100
Me.TrackBar1.Name = "TrackBar1"
Me.TrackBar1.Size = New System.Drawing.Size(299, 45)
Me.TrackBar1.TabIndex = 38
'
'ProgressBar1
'
Me.ProgressBar1.Location = New System.Drawing.Point(382, 51)
Me.ProgressBar1.Name = "ProgressBar1"
Me.ProgressBar1.Size = New System.Drawing.Size(252, 14)
Me.ProgressBar1.TabIndex = 39
'
'ProgressBar2
'
Me.ProgressBar2.Location = New System.Drawing.Point(382, 71)
Me.ProgressBar2.Name = "ProgressBar2"
Me.ProgressBar2.Size = New System.Drawing.Size(252, 11)
Me.ProgressBar2.TabIndex = 40
'
'Button5
'
Me.Button5.Location = New System.Drawing.Point(187, 27)
Me.Button5.Name = "Button5"
Me.Button5.Size = New System.Drawing.Size(36, 27)
Me.Button5.TabIndex = 41
Me.Button5.Text = "Button5"
Me.Button5.UseVisualStyleBackColor = True
'
'frmTag
'
Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
Me.ClientSize = New System.Drawing.Size(646, 105)
Me.Controls.Add(Me.Button5)
Me.Controls.Add(Me.ProgressBar2)
Me.Controls.Add(Me.ProgressBar1)
Me.Controls.Add(Me.TrackBar1)
Me.Controls.Add(Me.TextBox2)
Me.Controls.Add(Me.Button4)
Me.Controls.Add(Me.Button3)
Me.Controls.Add(Me.Button2)
Me.Controls.Add(Me.ComboBox1)
Me.Controls.Add(Me.Button1)
Me.Controls.Add(Me.PictureBoxWave)
Me.Controls.Add(Me.btnVis)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.lAbout)
Me.Controls.Add(Me.lblInfo)
Me.Controls.Add(Me.pbRight)
Me.Controls.Add(Me.pbLeft)
Me.Controls.Add(Me.lblStatus)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.txtComment)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.txtTrack)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.txtYear)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.txtGenre)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.txtAlbum)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.txtArtist)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtTitle)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TextBox1)
Me.Controls.Add(Me.tbVolume)
Me.Controls.Add(Me.btnStop)
Me.Controls.Add(Me.btnPlay)
Me.Controls.Add(Me.btnBrowse)
Me.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.Name = "frmTag"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "BASS .NET Stream Example"
CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.PictureBoxWave, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

#Region " Declarations "

  ' Declarations
  Private strm As Integer = 0 ' Our Stream
  Private RetVal As Int32 = 0 ' Return Value

    ' This variable makes sure our text updates aren't too fast.
    Dim TimeLapse As Integer = 0 ' Elapsed Time Variable
    ' Our visualization object
    Private WF As Un4seen.Bass.Misc.WaveForm

#End Region

#Region " Form Events "

    Private Sub frmTag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub frmTag_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Bass.BASS_ChannelStop(strm)
        Bass.BASS_StreamFree(strm)
        Bass.BASS_Stop()
        Bass.BASS_Free()
    End Sub

#End Region

#Region " Button Click Events "

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim DR As DialogResult = OFD1.ShowDialog(Me)
        If DR <> Windows.Forms.DialogResult.OK Then Exit Sub

        TextBox1.Text = OFD1.FileName
        btnStop_Click(sender, e)

        ' Enable the play button
        btnPlay.Enabled = True
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        Dim CI As New Un4seen.Bass.BASS_CHANNELINFO
        Dim TI As New Un4seen.Bass.AddOn.Tags.TAG_INFO

        ' Loads the stream
        If TextBox1.Text.ToLower().EndsWith(".mp3") Then
            strm = Bass.BASS_StreamCreateFile(TextBox1.Text, 0, 0, BASSFlag.BASS_DEFAULT)
        End If

        ' If there was an error
        If strm = 0 Then
            MsgBox("Error!")
            Exit Sub
        End If

        ' Load ID3 Tag
        If (BassTags.BASS_TAG_GetFromFile(strm, TI)) Then
            txtAlbum.Text = TI.album
            txtArtist.Text = TI.artist
            txtComment.Text = TI.comment
            txtGenre.Text = TI.genre
            txtTitle.Text = TI.title
            txtTrack.Text = TI.track
            txtYear.Text = TI.year
        End If

        ' Render the wave form
        WF = New Un4seen.Bass.Misc.WaveForm(TextBox1.Text, New Un4seen.Bass.Misc.WAVEFORMPROC(AddressOf MyWaveFormCallback), Me)
        WF.RenderStart(True, BASSFlag.BASS_DEFAULT)


        ' Displays the channel info
        Bass.BASS_ChannelGetInfo(strm, CI)

        lblInfo.Text = CI.ToString()
        lblInfo.Visible = True

        ' Plays the stream
        Bass.BASS_ChannelPlay(strm, False)
        Timer1.Enabled = True

    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Bass.BASS_ChannelStop(strm)
        Bass.BASS_StreamFree(strm)

        btnStop.Enabled = False
        btnPlay.Enabled = True
        Timer1.Enabled = False

        lblInfo.Visible = False
    End Sub

#End Region

#Region " Timer Events "

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim tElapsed As Single
        Dim tRemain As Single
        Dim tLength As Single
        Dim pos As Long
        Dim len As Long

        Dim isActive As Un4seen.Bass.BASSActive

        isActive = Bass.BASS_ChannelIsActive(strm)

        If isActive = Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING And btnStop.Enabled = False Then
            btnStop.Enabled = True
            btnPlay.Enabled = False
        ElseIf isActive = Un4seen.Bass.BASSActive.BASS_ACTIVE_STOPPED And btnPlay.Enabled = False Then
            btnStop.Enabled = False
            btnPlay.Enabled = True
            Timer1.Enabled = False
        End If

        If isActive = Un4seen.Bass.BASSActive.BASS_ACTIVE_STOPPED Then Exit Sub

        TimeLapse += 1
        ' Update Every 300ms for status text
        If TimeLapse = 1 Then
            TimeLapse = 0

            len = Bass.BASS_ChannelGetLength(strm)
            pos = Bass.BASS_ChannelGetPosition(strm)

            tLength = CSng(Bass.BASS_ChannelBytes2Seconds(strm, len))
            tElapsed = CSng(Bass.BASS_ChannelBytes2Seconds(strm, pos))
            tRemain = tLength - tElapsed

            lblStatus.Text = "Elapsed: " + Un4seen.Bass.Utils.FixTimespan(tElapsed, "MMSS") + " " + _
             "Remain: " + Un4seen.Bass.Utils.FixTimespan(tRemain, "MMSS") + " " + _
             "Total: " + Un4seen.Bass.Utils.FixTimespan(tLength, "MMSS")
        End If

        ' Get The Level Data
        RetVal = Bass.BASS_ChannelGetLevel(strm)

        ' Update ProgressBars
        'pbLeft.Value = (Un4seen.Bass.Utils.HighWord(RetVal) / 4)
        'pbRight.Value = (Un4seen.Bass.Utils.LowWord(RetVal) / 4)

        ' Get The Level Data
        Bass.BASS_GetVolume()
        Label10.Text = RetVal.ToString()

        ' Draw the wave form position
        DrawWavePosition(pos, len)

    End Sub

#End Region

#Region " Misc Code "

    Private Sub tbVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVolume.Scroll
        ' Sets the volume
        Bass.BASS_ChannelSetAttribute(strm, Un4seen.Bass.BASSAttribute.BASS_ATTRIB_VOL, CSng(tbVolume.Value) / 100.0F)
        Label9.Text = "Volume: " + tbVolume.Value.ToString + "%"
    End Sub

    Private Function GetFileExtension(ByVal filename As String) As String
        'Returns the file extension. e.g. .mp3 or .ogg or .wma
        Dim Z As Integer = InStrRev(filename, ".")

        If Z > 0 Then
            Return Mid(filename, Z).ToLower(System.Globalization.CultureInfo.CurrentCulture)
        Else
            Return filename
        End If

    End Function

    Private Sub MoveDisplayToSecondary(ByVal formDesc As Form)
        For A As Integer = 0 To Screen.AllScreens.Length - 1
            If Screen.AllScreens(A).Primary = False Then
                formDesc.Left = Screen.AllScreens(A).WorkingArea.Left
                formDesc.Top = Screen.AllScreens(A).WorkingArea.Top
                formDesc.Width = Screen.AllScreens(A).WorkingArea.Width
                formDesc.Height = Screen.AllScreens(A).WorkingArea.Height
                formDesc.WindowState = FormWindowState.Maximized
                Exit For
            End If
        Next
    End Sub

#End Region

    Private Sub lAbout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lAbout.LinkClicked
        Un4seen.Bass.BassNet.ShowAbout(Me)
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Dim lPos As Long

        lPos = Bass.BASS_ChannelGetPosition(strm)
        lPos += 600000
        Bass.BASS_ChannelSetPosition(strm, lPos)

    End Sub

    Private Sub MyWaveFormCallback(ByVal framesDone As Integer, ByVal framesTotal As Integer, ByVal elapsedTime As TimeSpan, ByVal finished As Boolean)
        If Not WF Is Nothing Then
            Me.PictureBoxWave.BackgroundImage = WF.CreateBitmap(Me.PictureBoxWave.Width, Me.PictureBoxWave.Height, -1, -1, False)
        End If
    End Sub

    Private Sub DrawWavePosition(ByVal pos As Long, ByVal len As Long)

        If len = 0 Or pos < 0 Then
            Me.PictureBoxWave.Image = Nothing
            Return
        End If

        Dim bitmap As Bitmap = Nothing
        Dim g As Graphics = Nothing
        Dim p As Pen = Nothing
        Dim bpp As Double = 0

        bpp = len / CType(Me.PictureBoxWave.Width, Double) ' bytes per pixel

        p = New Pen(Color.Red)
        bitmap = New Bitmap(Me.PictureBoxWave.Width, Me.PictureBoxWave.Height)
        g = Graphics.FromImage(bitmap)
        g.Clear(Color.Black)
        ' position (x) where to draw the line, Integer)
        Dim x As Integer = CInt(CType(Math.Round(pos / bpp), Double))
        g.DrawLine(p, x, 0, x, Me.PictureBoxWave.Height - 1)
        bitmap.MakeTransparent(Color.Black)

        If Not p Is Nothing Then
            p.Dispose()
        End If
        If Not g Is Nothing Then
            g.Dispose()
        End If

        Me.PictureBoxWave.Image = bitmap

    End Sub

  Private WithEvents player As SSP.Media.Player

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Dim dev As SSP.Media.SoundDevice = DirectCast(ComboBox1.SelectedItem, SSP.Media.SoundDevice)

    player = New SSP.Media.Player(dev.DeviceIndex)
    player.FileName = "v:\test.mp3"


    'BassNet.Registration("VanitasMundi@gmx.de", "2X1732919152223")

    'If False = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Me.Handle, Nothing) Then
    '  MsgBox("BASS Init Error!")
    'End If

    'strm = Bass.BASS_StreamCreateFile("v:\test.mp3", 0, 0, BASSFlag.BASS_DEFAULT)

    '' If there was an error
    'If strm = 0 Then
    '  MsgBox("Error!")
    '  Exit Sub
    'End If

    ' '' Displays the channel info
    ''Bass.BASS_ChannelGetInfo(strm, CI)


    '' Plays the stream
    'Bass.BASS_ChannelPlay(strm, False)


  End Sub

  Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
    If ComboBox1.Items.Count > 0 Then Exit Sub

    For Each item In SSP.Media.Player.GetSoundDevices
      ComboBox1.Items.Add(item)
    Next
  End Sub

Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

End Sub

Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        player.Play()

End Sub

Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    player.Pause()
End Sub

  Private Sub player_EndOfStream(ByVal sender As Object, ByVal e As System.EventArgs) Handles player.EndOfStream
    MsgBox("Ende")
  End Sub

  Private Sub player_LevelChanged(ByVal sender As Object, ByVal e As SSP.Media.LevelChangedEventArgs) Handles player.LevelChanged
    Try
      ProgressBar1.Value = e.LeftLevel
      ProgressBar2.Value = e.RightLevel
    Catch ex As Exception

    End Try
  End Sub

Private Sub player_PositionChanged(ByVal sender As Object, ByVal e As SSP.Media.PositionChangedEventArgs) Handles player.PositionChanged
  Me.Text = e.CurrentTime & " | " & e.TotalTime & " | " & e.RemainTime
  TrackBar1.Value = CInt(e.Percent)
End Sub

Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    'player.SetVolume(CType(TextBox2.Text, Single))

End Sub

Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
player.SetPosition(CByte(TrackBar1.Value))
End Sub

Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        player.FileName = "v:\test2.mp3"

End Sub
End Class
