Public Class MainForm
  Private _RenameInfos As New System.Collections.Generic.Dictionary(Of String, String)

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    FolderBrowserDialog1.SelectedPath = TextBox1.Text
    Select Case FolderBrowserDialog1.ShowDialog()
    Case Windows.Forms.DialogResult.Cancel
      Exit Sub
    End Select
    TextBox1.Text = FolderBrowserDialog1.SelectedPath
    My.Settings.Path = TextBox1.Text
    My.Settings.Save()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    TextBox1.Text = My.Settings.Path
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If Not My.Computer.FileSystem.DirectoryExists(TextBox1.Text) Then Exit Sub

    TreeView1.Nodes.Clear()
    TreeView2.Nodes.Clear()
    Label1.Text = "0"
    _RenameInfos = New System.Collections.Generic.Dictionary(Of String, String)
    GetFolders(TextBox1.Text)

    For Each s In _RenameInfos.Keys
      Dim ar = My.Computer.FileSystem.GetName(s).Replace("-", " ").Split(" "c)

      If (ar(0).Length = 4) AndAlso (ar(1).Length = 4) _
      AndAlso (IsNumeric(ar(0))) AndAlso (IsNumeric(ar(1))) Then
        TreeView2.Nodes.Add("Ordner würde nach Umbennennung mit 2 Jahreszahlen beginnen.").Nodes.Add(s)
      Else
        Dim n = TreeView1.Nodes.Add(s, s)
        n.Nodes.Add(_RenameInfos.Item(s))
      End If


    Next

  End Sub

  Private Sub GetFolders(ByVal folder As String)

    CheckFolder(folder)
    For Each subFolder In My.Computer.FileSystem.GetDirectories(folder)
      GetFolders(subFolder)
      CheckFolder(subFolder)
    Next

  End Sub

  Private Sub CheckFolder(ByVal folder As String)
    Dim mp3Files = My.Computer.FileSystem.GetFiles(folder, FileIO.SearchOption.SearchTopLevelOnly, New String() {"*.mp3"})

    Select Case mp3Files.Count
    Case Is = 0
      Exit Sub
    End Select

    Dim name = My.Computer.FileSystem.GetName(folder)
    Dim folderName As String
    Dim newFolderName As String

    Dim id3 As New HundredMilesSoftware.UltraID3Lib.UltraID3
    id3.Read(mp3Files.Item(0))

    Try
      Select Case True
      Case name.ToLower.StartsWith(id3.Year.ToString)
        Exit Sub
      Case name.ToLower.StartsWith("diverse")
        Exit Sub
      Case name.ToLower.StartsWith("cd")
        folder = My.Computer.FileSystem.GetParentPath(folder)
        name = My.Computer.FileSystem.GetName(folder)
        Select Case True
        Case name.ToLower.StartsWith(id3.Year.ToString)
          Exit Sub
        End Select
        folderName = My.Computer.FileSystem.GetParentPath(folder)
        newFolderName = My.Computer.FileSystem.CombinePath(folderName, id3.Year & " " & name)
      Case Else
        folderName = My.Computer.FileSystem.GetParentPath(folder)
        newFolderName = My.Computer.FileSystem.CombinePath(folder, id3.Year & " " & name)
      End Select

      Select Case _RenameInfos.ContainsKey(newFolderName)
      Case False
        _RenameInfos.Add(newFolderName, folder)
        Label1.Text = (CInt(Label1.Text) + 1).ToString
        Me.Refresh()
      End Select

    Catch ex As Exception
      TreeView2.Nodes.Add(ex.Message).Nodes.Add(folder)
    End Try

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    TreeView2.Nodes.Clear()
    Label1.Text = "0"

    If _RenameInfos.Count = 0 Then Exit Sub

    Dim s As String = ""
    For index = _RenameInfos.Keys.Count - 1 To 0 Step -1
      Try
        s = _RenameInfos.Keys(index)
        My.Computer.FileSystem.RenameDirectory(_RenameInfos.Item(s), My.Computer.FileSystem.GetName(s))
        TreeView1.Nodes.RemoveByKey(s)
        _RenameInfos.Remove(s)
        Label1.Text = (CInt(Label1.Text) + 1).ToString
        Me.Refresh()
      Catch ex As Exception
        TreeView2.Nodes.Add(ex.Message).Nodes.Add(s)
      End Try
    Next

  End Sub

  Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick, TreeView2.DoubleClick

    Dim tv = DirectCast(sender, TreeView)

    If tv.SelectedNode Is Nothing Then Exit Sub
    If tv.SelectedNode.Parent Is Nothing Then Exit Sub

    Try
      Process.Start(tv.SelectedNode.Text)
    Catch
      Try
        Process.Start(My.Computer.FileSystem.GetParentPath(tv.SelectedNode.Text))
      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End Try

  End Sub
End Class
