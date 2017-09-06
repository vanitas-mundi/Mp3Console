Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.Tools

Namespace Controls

Public Class ConsoleOptionBox

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Title As String
  Private _OptionStrings As String()
  Private _X As Int32
  Private _Y As Int32
  Private _X2 As Int32
  Private _ColorSet As ColorSet
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal title As String _
  , ByVal optionStrings() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32)

    Initialize(title, optionStrings, x, y, width, ColorSet.DefaultColorSet)
  End Sub

  Public Sub New _
  (ByVal title As String _
  , ByVal optionStrings() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    Initialize(title, optionStrings, x, y, width, colorSet)
  End Sub

  Private Sub Initialize _
  (ByVal title As String _
  , ByVal optionStrings() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    _Title = title
    _OptionStrings = optionStrings
    _X = x
    _Y = y
    _X2 = width
    _ColorSet = colorSet
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function ShowOptions() As SSP.ConsoleExt.OptionBoxResults

    Dim visible = Console.CursorVisible
    Console.CursorVisible = False

    Dim windowHeight = 7 + _OptionStrings.Count

    Try
      Dim settings = New HeaderBorderSettings
      settings.HeaderText = _Title
      settings.X = _X
      settings.Y = _Y
      settings.X2 = _X2
      settings.Y2 = _Y + windowHeight
      settings.ColorSet = _ColorSet
      DrawHeaderBorder(settings)

      'DrawHeaderBorder(_Title, _X, _Y, _X2, _Y + windowHeight, _ColorSet)

      For i = 0 To _OptionStrings.Count - 1
        WriteXY("<" & i + 1 & "> " & _OptionStrings(i), _X + 2, _Y + 4 + i, _ColorSet)
      Next i

      Dim x = _X + 2
      Dim y = _Y + 7 + _OptionStrings.Count - 1

      WriteXY("Bitte wählen (1 - " & _OptionStrings.Count & "):", x, y, _ColorSet)
      Dim key As ConsoleKey
      Dim ok As Boolean = False

      Do
        key = Console.ReadKey(True).Key
        Select Case key
        Case ConsoleKey.D1 To ConsoleKey.D9
          Dim optionResult = CType(key, Int32) - 48
          Select Case optionResult
          Case 1 To _OptionStrings.Count
            ok = True
            Return CType(System.Enum.Parse(GetType(OptionBoxResults) _
            , "Option" & optionResult), OptionBoxResults)
          End Select
        Case ConsoleKey.Escape
          ok = True
          Return OptionBoxResults.Cancel
        End Select
      Loop Until ok

    Catch ex As Exception
    Finally
      ClearWindow(_X, _Y, _X2, _Y + windowHeight, _ColorSet.BackColor)
      Console.CursorVisible = visible
    End Try

  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace
