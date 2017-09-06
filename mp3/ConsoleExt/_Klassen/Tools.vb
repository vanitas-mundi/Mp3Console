Option Explicit On
Option Strict On
Option Infer On

Imports System.Text

Public Class Tools
 'http://www.i8086.de/zeichensatz/code-page-850.html
 '█▄▀‗▬■×«»►◄▒▓©↕

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Shared Sub WriteXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor)

    Console.ForegroundColor = foreColor
    Console.BackgroundColor = backColor

    Dim ar = System.Text.RegularExpressions.Regex.Split(s, vbCrLf)

    For i = 0 To ar.Count - 1
      Console.SetCursorPosition(x, y + i)
      Console.Write(ar(i))
    Next

    Console.ResetColor()
  End Sub

  Public Shared Sub WriteXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32)

    WriteXY(s, x, y, Console.ForegroundColor, Console.BackgroundColor)
  End Sub

  Public Shared Sub WriteXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet)

    WriteXY(s, x, y, colorSet.ForeColor, colorSet.BackColor)
  End Sub

  Public Shared Sub WriteLineXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor)

    WriteXY(s, x, y, foreColor, backColor)
    Console.WriteLine("")
  End Sub

  Public Shared Sub WriteLineXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet)

    WriteLineXY(s, x, y, colorSet.ForeColor, colorSet.BackColor)
  End Sub

  Public Shared Sub WriteLineXY _
  (ByVal s As String _
  , ByVal x As Int32 _
  , ByVal y As Int32)

    WriteXY(s, x, y)
    Console.WriteLine("")
  End Sub

  Public Shared Sub WriteLine _
  (ByVal s As String _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor)

    WriteXY(s, Console.CursorLeft, Console.CursorTop, foreColor, backColor)
    Console.WriteLine("")
  End Sub

  Public Shared Sub WriteLine _
  (ByVal s As String _
  , ByVal colorSet As ColorSet)

    WriteLine(s, colorSet.ForeColor, colorSet.BackColor)
  End Sub

  Public Shared Sub Write _
  (ByVal s As String _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor)

    WriteXY(s, Console.CursorLeft, Console.CursorTop, foreColor, backColor)
  End Sub

  Public Shared Sub Write _
  (ByVal s As String _
  , ByVal colorSet As ColorSet)

    Write(s, colorSet.ForeColor, colorSet.BackColor)
  End Sub

  Public Shared Sub ClearWindow _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal x2 As Int32 _
  , ByVal y2 As Int32)

    ClearWindow(x, y, x2, y2, Console.BackgroundColor)
  End Sub

  Public Shared Sub ClearWindow _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal x2 As Int32 _
  , ByVal y2 As Int32 _
  , ByVal color As ConsoleColor)

    For posY = y To y2
      WriteXY(Space(x2 - x + 1), x, posY, color, color)
    Next posY
  End Sub

  Public Shared Sub ClearWindow _
  (ByVal bounds As DialogBounds)

    ClearWindow(bounds.x, bounds.y, bounds.x2, bounds.y2, Console.BackgroundColor)
  End Sub

  Public Shared Sub ClearWindow _
  (ByVal bounds As DialogBounds _
  , ByVal color As ConsoleColor)

    ClearWindow(bounds.x, bounds.y, bounds.x2, bounds.y2, color)
  End Sub

  Public Shared Sub ClearLine _
  (ByVal y As Int32 _
  , ByVal x As Int32 _
  , ByVal x2 As Int32 _
  , ByVal color As ConsoleColor)

    WriteRepeater(" "c, (x2 - x) + 1, x, y, color, color)
  End Sub

  Public Shared Sub ClearLine _
  (ByVal y As Int32 _
  , ByVal x As Int32 _
  , ByVal x2 As Int32)

    ClearLine(y, x, x2, Console.BackgroundColor)
  End Sub

  Public Shared Sub ClearLine _
  (ByVal y As Int32 _
  , ByVal color As ConsoleColor)

    ClearLine(y, 0, Console.WindowWidth - 1, color)
  End Sub

  Public Shared Sub ClearLine _
  (ByVal y As Int32)

    ClearLine(y, 0, Console.WindowWidth - 1, Console.BackgroundColor)
  End Sub

  Public Shared Sub WriteRepeater _
  (ByVal c As Char _
  , ByVal loops As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal backGroundColor As ConsoleColor _
  , ByVal foreGroundColor As ConsoleColor)

    WriteXY(Space(loops).Replace(" ", c), x, y _
    , foreGroundColor, backGroundColor)
  End Sub

  Public Shared Sub WriteRepeater _
  (ByVal c As Char _
  , ByVal loops As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32)

    WriteRepeater(c, loops, x, y _
    , Console.BackgroundColor, Console.ForegroundColor)
  End Sub

  Public Shared Sub DrawBorder _
  (ByVal settings As BorderSettings)

    Tables.DrawBorder(settings)
  End Sub

  Public Shared Sub DrawHeaderBorder _
  (ByVal settings As HeaderBorderSettings)

    With settings
      Dim tableSettings = New TableSettings
      tableSettings.ColWidths.Add((.X2 - .X) - 1)
      tableSettings.RowHeights.Add(.HeaderHeight)
      tableSettings.RowHeights.Add((.Y2 - .Y) - (.HeaderHeight + 2))
      tableSettings.BorderStyleType = .BorderStyleType
      tableSettings.X = .X
      tableSettings.Y = .Y
      tableSettings.ColorSet = .ColorSet
      tableSettings.Values.Add(.HeaderText)
      tableSettings.Values.Add(.BodyText)
      Tables.ShowTable(tableSettings)
      Console.SetCursorPosition(.X + 2, .Y + .HeaderHeight + 2)
    End With
  End Sub

  ''' <summary>
  ''' Kürzt den übergebenen String auf auf die angegebene Länge.
  ''' </summary>
  Public Shared Function StringShorten _
  (ByVal s As String _
  , ByVal len As Integer) As String

    Select Case s.Length
    Case Is <= len
      Return s
    Case Else
      Return s.Substring(0, len - 3) & "..."
    End Select
  End Function

  ''' <summary>
  ''' Kürzt den übergebenen Pfad auf auf die angegebene Länge.
  ''' </summary>
  Public Shared Function PathShorten _
  (ByVal path As String _
  , ByVal len As Integer) As String

    Dim pathParts() = Split(path, "\")
    Dim pathBuild = New StringBuilder(path.Length)
    Dim lastPart = pathParts(pathParts.Length - 1)
    Dim prevPath = ""

    'Erst prüfen ob der komplette String evtl. bereits kürzer als die Maximallänge ist
    If path.Length < len Then Return path

    For i As Integer = 0 To pathParts.Length - 1
      pathBuild.Append(pathParts(i) & "\")
      If (pathBuild.ToString & "...\" & lastPart).Length >= len Then
        Return prevPath
      Else
        prevPath = pathBuild.ToString & "...\" & lastPart
      End If
    Next i
    Return prevPath
  End Function

  ''' <summary>
  ''' Zeichnet ein horizontales Lineal
  ''' </summary>
  Public Shared Sub DrawRulerHorizontal _
  (ByVal x As Int32, ByVal y As Int32, ByVal len As Int32)

    Dim sb = New StringBuilder

    For i = 0 To len - 1
      Select Case True
      Case (i + 1) Mod 10 = 0
        sb.Append(((i + 1) \ 10).ToString)
      Case (i + 1) Mod 5 = 0
        sb.Append("|")
      Case Else
        sb.Append(".")
      End Select
    Next i

    WriteXY(sb.ToString, x, y)
  End Sub

  ''' <summary>
  ''' Zeichnet ein vertikales Lineal
  ''' </summary>
  Public Shared Sub DrawRulerVertical _
  (ByVal x As Int32, ByVal y As Int32, ByVal len As Int32)

      For i = 0 To len - 1
      Select Case True
      Case (i + 1) Mod 10 = 0
        WriteXY(((i + 1) \ 10).ToString, x, y + i)
      Case (i + 1) Mod 5 = 0
        WriteXY("-", x, y + i)
      Case Else
        WriteXY(".", x, y + i)
      End Select
    Next i
  End Sub

#End Region 'Öffentliche Methoden der Klasse}

End Class
