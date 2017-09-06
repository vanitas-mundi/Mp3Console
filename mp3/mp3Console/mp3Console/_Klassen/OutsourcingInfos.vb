Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class OutsourcingInfos

  Implements Imp3Console

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Path As String
  Private _DriveInfo As IO.DriveInfo
  Private _FreespaceByte As Int64
  Private _FreespaceMB As Int64
  Private _OutsourcingSizeByte As Int64 = 0
  Private _OutsourcingSizeMB As Int64 = 0
  Private _RandomFileNames As Boolean = False
  Private _mp3Console As mp3Console
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
    Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3Console.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property

  Public ReadOnly Property Path() As String
  Get
    Return _Path
  End Get
  End Property

  Public ReadOnly Property DriveInfo() As IO.DriveInfo
  Get
    Return _DriveInfo
  End Get
  End Property

  Public ReadOnly Property FreespaceByte() As Int64
  Get
    Return _FreespaceByte
  End Get
  End Property

  Public ReadOnly Property FreespaceMB() As Int64
  Get
    Return _FreespaceMB
  End Get
  End Property

  Public ReadOnly Property OutsourcingSizeByte() As Int64
  Get
    Return _OutsourcingSizeByte
  End Get
  End Property

  Public ReadOnly Property OutsourcingSizeMB() As Int64
  Get
    Return _OutsourcingSizeMB
  End Get
  End Property

  Public ReadOnly Property RandomFileNames() As Boolean
  Get
    Return _RandomFileNames
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function GetPath() As Int32

    WriteXY("Bitte Auslagerungsverzeichnis wählen!" _
    , 2, 9, Me.MP3Console.Colors)

    Dim bmi = New BarMenuInfos(1, 10, Me.MP3Console.Colors, 9)

    Dim pp As New PathPicker(bmi, 50)
    pp.Border = False
    Select Case pp.ShowPathPicker
    Case ConsoleExt.DialogResults.Cancel
      ClearLine(9, 1, 78, Me.MP3Console.Colors.BackColor)
      Return -1
    Case Else
      ClearLine(9, 1, 78, Me.MP3Console.Colors.BackColor)
      _Path = pp.SelectedPath
      Dim drive = My.Computer.FileSystem.GetDirectoryInfo(_Path).Root.Name
      _DriveInfo = New IO.DriveInfo(drive)
      _FreespaceByte = _DriveInfo.AvailableFreeSpace
      _FreespaceMB = _FreespaceByte \ 1024 \ 1024
      Return 0
    End Select
  End Function

  Public Function GetPathAndOutSourcingSize() As Int32
    Select Case GetPath()
    Case -1
      Return -1
    Case Else

      WriteXY("Wieviel MB an MP3-Dateien sollen ausgelagert werden?" _
      , 2, 9, Me.MP3Console.Colors)

      Dim bmi = New BarMenuInfos(1, 10, Me.MP3Console.Colors, 9)

      bmi = New BarMenuInfos _
      (New String() _
      {_FreespaceMB & " MB" _
      , "16 MB" _
      , "30 MB" _
      , "60 MB" _
      , "120 MB" _
      , "250 MB" _
      , "500 MB" _
      , "1000 MB" _
      , "2000 MB"} _
      , 1, 10, Me.MP3Console.Colors, 10)

      Dim bm As New BarMenu(Of String)(bmi)

      Select Case bm.ShowMenu
      Case ConsoleExt.DialogResults.Cancel
        ClearLine(9, 1, 78, Me.MP3Console.Colors.BackColor)
        Return -1
      Case Else
        ClearLine(9, 1, 78, Me.MP3Console.Colors.BackColor)
        _OutsourcingSizeByte = CType(bm.Value.Replace(" MB", ""), Int64) * 1024 * 1024
        _OutsourcingSizeMB = _OutsourcingSizeByte \ 1024 \ 1024
        Return 0
      End Select

    End Select
  End Function

  Public Function ShowSecurityQuery() As SSP.ConsoleExt.DialogResults
    SSP.ConsoleExt.Tools.ClearWindow _
    (New SSP.ConsoleExt.DialogBounds(1, 9, 78, 21) _
    , Me.MP3Console.Colors.BackColor)

    Dim mb As ConsoleMessageBox

    Select Case _OutsourcingSizeMB
    Case 0
      mb = New ConsoleMessageBox _
      ("Wechselmediumauslagerung", New String() _
      {"Sollen wirklich ausgewählte MP3-Dateien" _
      , "auf das Medium " & _Path _
      , "ausgelagert werden?"}, 1, 9, 50, Me.MP3Console.Colors)
    Case Else
      mb = New ConsoleMessageBox _
      ("Wechselmediumauslagerung", New String() _
      {"Sollen wirklich " & _OutsourcingSizeMB & " an MP3-Dateien" _
      , "auf das Medium " & _Path _
      , "ausgelagert werden?"}, 1, 9, 50, Me.MP3Console.Colors)
    End Select

    Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.Question)
    Case ConsoleExt.MessageBoxResults.No
      Return ConsoleExt.DialogResults.Cancel
    Case Else
      Return ConsoleExt.DialogResults.OK
    End Select
  End Function

  Public Function ShowRandomQuery() As ConsoleExt.MessageBoxResults

    Dim mb = New ConsoleMessageBox _
    ("Wechselmediumauslagerung", New String() _
    {"Sollen zufällige Dateinamen generiert werden?" _
    , "(Für eine zufällige Spielfolge)"} _
    , 1, 9, 50, Me.MP3Console.Colors)

    Dim result = mb.ShowMessage _
    (ConsoleExt.MessageBoxTypes.Question)

    _RandomFileNames = (result = ConsoleExt.MessageBoxResults.Yes)
    Return result
  End Function

  Public Function ShowFolderClearSecurityQuery() As Int32

    Dim mb = New ConsoleMessageBox _
    ("Wechselmediumauslagerung", New String() _
    {"Soll der Ordner" _
    , _Path _
    , "zuvor geleert werden?"}, 1, 9, 50, Me.MP3Console.Colors)

    Select Case mb.ShowMessage(ConsoleExt.MessageBoxTypes.Question)
    Case ConsoleExt.MessageBoxResults.Yes
      Try
        For Each file In My.Computer.FileSystem.GetFiles(_Path)
          Try
            My.Computer.FileSystem.DeleteFile(file)
          Catch ex As Exception
          End Try
        Next file
      Catch ex As Exception
        mb = New ConsoleMessageBox _
        ("Wechselmediumauslagerung" _
        , Text.RegularExpressions.Regex.Split _
        (ex.Message, vbCrLf), 1, 9, 50, Me.MP3Console.Colors)
        mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)
        Return -1
      End Try
    End Select

    Return 0
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class
