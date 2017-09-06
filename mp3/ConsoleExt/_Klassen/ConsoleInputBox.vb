Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.Tools

Namespace Controls

Public Class ConsoleInputBox(Of T)

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Title As String
  Private _Prompt As String
  Private _X As Int32
  Private _Y As Int32
  Private _X2 As Int32
  Private _ColorSet As ColorSet
  Private _AllowNull As Boolean = False
  Private _Value As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal title As String _
  , ByVal prompt As String _
  , ByVal [default] As T _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32)

    Initialize(title, prompt, [default], x, y, width, ColorSet.DefaultColorSet)
  End Sub

  Public Sub New _
  (ByVal title As String _
  , ByVal prompt As String _
  , ByVal [default] As T _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    Initialize(title, prompt, [default], x, y, width, colorSet)
  End Sub

  Public Sub New _
  (ByVal title As String _
  , ByVal prompt As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32)

    Initialize(title, prompt, Nothing, x, y, width, ColorSet.DefaultColorSet)
  End Sub

  Public Sub New _
  (ByVal title As String _
  , ByVal prompt As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    Initialize(title, prompt, Nothing, x, y, width, colorSet)
  End Sub

  Private Sub Initialize _
  (ByVal title As String _
  , ByVal prompt As String _
  , ByVal [default] As T _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    _Title = title
    _Prompt = prompt
    _X = x
    _Y = y
    _X2 = width
    _Value = [default]
    _ColorSet = colorSet
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property Value() As T
  Get
    Return _Value
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function GetInput() As SSP.ConsoleExt.DialogResults
    Dim key As ConsoleKeyInfo
    Dim sb As New System.Text.StringBuilder()
    If _Value IsNot Nothing Then sb.Append(_Value.ToString)

    Do
      WriteRepeater("█"c, _X2 - (_X + 5), _X + 2, _Y + 5 _
      , _ColorSet.BackColor, _ColorSet.ForeColor)

      Console.SetCursorPosition(_X + 2, _Y + 5)
      WriteXY(sb.ToString, _X + 2, _Y + 5, _ColorSet)

      key = Console.ReadKey(True)

      Select Case True
      Case key.Key = ConsoleKey.Backspace
        If sb.Length > 0 Then sb.Remove(sb.Length - 1, 1)
      Case key.Key = 222 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ä
        sb.Append("Ä")
      Case key.Key = 222 AndAlso key.Modifiers = 0  'ä
        sb.Append("ä")
      Case key.Key = 192 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ö
        sb.Append("Ö")
      Case key.Key = 192 AndAlso key.Modifiers = 0  'ö
        sb.Append("ö")
      Case key.Key = 186 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ü
        sb.Append("Ü")
      Case key.Key = 186 AndAlso key.Modifiers = 0  'ü
        sb.Append("ü")
      Case key.Key = 219 AndAlso key.Modifiers = 0 'ß
        sb.Append("ß")
      Case (Char.IsLetterOrDigit(key.KeyChar)) _
      OrElse (Char.IsWhiteSpace(key.KeyChar)) _
      OrElse (Char.IsPunctuation(key.KeyChar))
        If (key.Key <> ConsoleKey.Enter) _
        AndAlso (sb.Length + 1 < _X2 - (_X + 2)) Then
          sb.Append(key.KeyChar)
        End If
      End Select
    Loop Until _
    (key.Key = ConsoleKey.Escape) _
    OrElse ((key.Key = ConsoleKey.Enter) AndAlso (sb.Length > 0)) _
    OrElse ((key.Key = ConsoleKey.Enter) AndAlso ((sb.Length = 0) AndAlso (_AllowNull)))

    Select Case key.Key
    Case ConsoleKey.Escape
      _Value = Nothing
      Return DialogResults.Cancel
    Case Else
      Try
        _Value = CType(CType(sb.ToString, Object), T)
        Return DialogResults.OK
      Catch ex As Exception
        Return ShowDialog()
      End Try
    End Select

  End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function ShowDialog() As SSP.ConsoleExt.DialogResults
    Dim visible = Console.CursorVisible
    Console.CursorVisible = True

    Dim settings = New HeaderBorderSettings
    settings.HeaderText = _Title
    settings.X = _X
    settings.Y = _Y
    settings.X2 = _X2
    settings.Y2 = _Y + 8
    settings.ColorSet = _ColorSet
    DrawHeaderBorder(settings)

    WriteXY(_Prompt, _X + 2, _Y + 3, _ColorSet)
    Dim ret = GetInput()
    ClearWindow(_X, _Y, _X2, _Y + 8, _ColorSet.BackColor)
    Console.CursorVisible = visible
    Return ret
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace
