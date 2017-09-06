Option Explicit On
Option Strict On
Option Infer On

Namespace BarMenus

Public Class PathPicker

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Protected _LastSelectedIndex As Int32
  Protected _BarMenuInfos As BarMenuInfos
  Protected _Border As Boolean = True
  Protected _ShortenPathAfter As Int32
  Protected _SelectedPath As String
  Protected _ListFiles As Boolean = False
  Protected _FileName As String
  Protected _Wildcards() As String = New String() {}
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal barMenuInfos As BarMenuInfos)

		Initialize(barMenuInfos, 78 - barMenuInfos.x)
  End Sub

  Public Sub New _
  (ByVal barMenuInfos As BarMenuInfos _
  , ByVal shortenPathAfter As Int32)

    Initialize(barMenuInfos, shortenPathAfter)
  End Sub

  Private Sub Initialize _
  (ByVal barMenuInfos As BarMenuInfos _
  , ByVal shortenPathAfter As Int32)

    _BarMenuInfos = barMenuInfos
    _ShortenPathAfter = shortenPathAfter
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property Border() As Boolean
  Get
    Return _Border
  End Get
  Set(ByVal value As Boolean)
    _Border = value
  End Set
  End Property

  Public Property SelectedPath() As String
  Get
    Return _SelectedPath
  End Get
  Set(ByVal value As String)
    _SelectedPath = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onBarMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.Backspace
      e.ExitBarMenu = True
      e.ReturnDialogResult = DialogResults.OK
      e.ReturnValue = "[..]"
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub ClearSelectedPathDrawing()
    With _BarMenuInfos
      Dim x As Int32 = .x + 1
      Dim y As Int32 = .y + .VisibleItems + 3
      Tools.ClearLine(y, x, x + _ShortenPathAfter, .ColorSet.BackColor)
    End With
  End Sub

  Private Function DrawSelectedPath _
  (ByVal path As String _
  , ByVal showDrives As Boolean) As String

    With _BarMenuInfos
      Dim x As Int32 = .x + 1
      Dim y As Int32 = .y + .VisibleItems + 3

      Tools.ClearLine(y, x, x + _ShortenPathAfter, .ColorSet.BackColor)

      If showDrives Then
        Tools.WriteXY("\", x, y, .ColorSet)
        Return GetDrive(.x, .y)
      Else
        Tools.WriteXY(Tools.PathShorten _
        (path, _ShortenPathAfter), x, y, .ColorSet)
        Return GetSubFolders(path, .x, .y)
      End If
    End With
  End Function

  Private Function GetDrive _
  (ByVal x As Int32 _
  , ByVal y As Int32) As String

    With _BarMenuInfos

      Dim barMenuInfos As New BarMenuInfos _
      (My.Computer.FileSystem.Drives.ToArray _
      , 0, x, y, .ColorSet, .VisibleItems)

      Dim bm As New BarMenu(Of IO.DriveInfo)(barMenuInfos)
      bm.Border = Me.Border
      Select Case bm.ShowMenu()
      Case DialogResults.Cancel
        Return ""
      Case Else
        Return bm.Value.Name
      End Select
    End With
  End Function

  Private Function GetSubFolders _
  (ByVal path As String _
  , ByVal x As Int32 _
  , ByVal y As Int32) As String

    With _BarMenuInfos
      Try
        Dim temp = My.Computer.FileSystem.GetDirectories(path)
        Dim foldersItems As New Generic.List(Of String)
        If Not _ListFiles Then foldersItems.Add("[auswählen]")
        foldersItems.Add("[\..]")
        foldersItems.Add("[..]")

        For Each folder In temp
          If _ListFiles Then
            foldersItems.Add(My.Computer.FileSystem.GetName(folder) & " <DIR>")
          Else
            foldersItems.Add(My.Computer.FileSystem.GetName(folder))
          End If
        Next folder

        If _ListFiles Then
          Select Case _Wildcards.Count
          Case 0
            temp = My.Computer.FileSystem.GetFiles(path)
          Case Else
            temp = My.Computer.FileSystem.FindInFiles _
            (path, "", True, FileIO.SearchOption.SearchTopLevelOnly, _Wildcards)
          End Select

          For Each file In temp
            foldersItems.Add(My.Computer.FileSystem.GetName(file))
          Next file
        End If

        Dim BarMenuInfos = New BarMenuInfos _
        (foldersItems.ToArray _
        , _LastSelectedIndex, x, y, .ColorSet, .VisibleItems)

        Dim bm = New BarMenu(Of String)(BarMenuInfos)
        AddHandler bm.KeyPressed, AddressOf onBarMenuKeyPressed

        bm.Border = Me.Border
        Select Case bm.ShowMenu()
        Case DialogResults.Cancel
          Return ""
        End Select

        _LastSelectedIndex = bm.SelectedIndex

        If _ListFiles Then
          Select Case True
          Case bm.Value.StartsWith("[")
            Return bm.Value
          Case bm.Value.IndexOf(" <DIR>") = -1
            _FileName = My.Computer.FileSystem.CombinePath(path, bm.Value)
            Return "[auswählen]"
          Case Else
            _LastSelectedIndex = 0
            Return bm.Value.Replace(" <DIR>", "")
          End Select
        Else
          _LastSelectedIndex = 0
          Return bm.Value
        End If

      Catch ex As Exception
        Return "\error\"
      End Try
    End With
  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function ShowPathPicker() As DialogResults
    Dim path As String = "\"
    Dim value As String = ""
    Dim ok As Boolean = False
    Dim showDrives As Boolean

    showDrives = True

    If (Not String.IsNullOrEmpty(_SelectedPath)) _
    AndAlso (My.Computer.FileSystem.DirectoryExists(_SelectedPath)) Then
      showDrives = False
      path = _SelectedPath
    End If

    With _BarMenuInfos
      Do
        value = DrawSelectedPath(path, showDrives)
        showDrives = False
        Select Case value
        Case ""
          ClearSelectedPathDrawing()
          Return DialogResults.Cancel
        Case "[\..]"
          path = path.Split("\"c)(0) & "\"
        Case "\error\", "[..]"
          Try
            path = My.Computer.FileSystem.GetParentPath(path)
          Catch ex As Exception
            showDrives = True
          End Try
        Case "[auswählen]"
          _SelectedPath = path
          ClearSelectedPathDrawing()
          Return DialogResults.OK
        Case Else
          path = My.Computer.FileSystem.CombinePath(path, value)
        End Select
      Loop Until ok
    End With
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace
