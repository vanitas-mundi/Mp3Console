Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.Tools

Namespace Controls

Public Class ConsoleMessageBox

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Title As String
  Private _Message() As String
  Private _X As Int32
  Private _Y As Int32
  Private _X2 As Int32
  Private _ColorSet As ColorSet
  Private _WindowHeight As Integer
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal title As String _
  , ByVal message() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32)

    Initialize(title, message, x, y, width, ColorSet.DefaultColorSet)
  End Sub

  Public Sub New _
  (ByVal title As String _
  , ByVal message() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    Initialize(title, message, x, y, width, colorSet)
  End Sub

  Private Sub Initialize _
  (ByVal title As String _
  , ByVal message() As String _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal width As Int32 _
  , ByVal colorSet As ColorSet)

    _Title = title
    _Message = message
    _X = x
    _Y = y
    _X2 = width
    _ColorSet = colorSet
  End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property Message() As String()
  Get
    Return _Message
  End Get
  Set(ByVal value As String())
    _Message = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function ShowMessage _
  (ByVal messageBoxType As SSP.ConsoleExt.MessageBoxTypes) _
  As SSP.ConsoleExt.MessageBoxResults

    Dim visible = Console.CursorVisible
    Console.CursorVisible = False

    Select Case messageBoxType
    Case MessageBoxTypes.InfoBox
      _WindowHeight = 5 + _Message.Count
    Case Else
      _WindowHeight = 7 + _Message.Count
    End Select

    Try
      Dim settings = New HeaderBorderSettings
      settings.HeaderText = _Title
      settings.X = _X
      settings.Y = _Y
      settings.X2 = _X2
      settings.Y2 = _Y + _WindowHeight
      settings.ColorSet = _ColorSet
      DrawHeaderBorder(settings)

      'DrawHeaderBorder(_Title, _X, _Y, _X2, _Y + _WindowHeight, _ColorSet)

      For i = 0 To _Message.Count - 1
        WriteXY(_Message(i), _X + 2, _Y + 4 + i, _ColorSet)
      Next i

      Dim x = _X + 2
      Dim y = _Y + 7 + _Message.Count - 1

      Select Case messageBoxType
      Case MessageBoxTypes.InfoBox
        Return MessageBoxResults.OK
      Case MessageBoxTypes.Message
        WriteXY("<Taste, um fortzufahren ...>", x, y, _ColorSet)
        Console.ReadKey()
        Return MessageBoxResults.OK
      Case MessageBoxTypes.CancelOK
        WriteXY("<OK>=Enter    <Abbrechen>=ESC", x, y, _ColorSet)
        Dim key As ConsoleKey
        Do
          key = Console.ReadKey(True).Key
          Select Case key
          Case ConsoleKey.Enter
            Return MessageBoxResults.OK
          Case ConsoleKey.Escape
            Return MessageBoxResults.Cancel
          End Select
        Loop Until (key = ConsoleKey.Enter) _
        OrElse (key = ConsoleKey.Escape)
      Case MessageBoxTypes.Question
        WriteXY("<Ja>=J    <Nein>=N", x, y, _ColorSet)
        Dim key As ConsoleKey
        Do
          key = Console.ReadKey(True).Key
          Select Case key
          Case ConsoleKey.J
            Return MessageBoxResults.Yes
          Case ConsoleKey.N
            Return MessageBoxResults.No
          End Select
        Loop Until (key = ConsoleKey.J) _
        OrElse (key = ConsoleKey.N)
      Case MessageBoxTypes.YesNoCancel
        WriteXY("<Ja>=J    <Nein>=N    <Abbrechen>=ESC", x, y, _ColorSet)
        Dim key As ConsoleKey
        Do
          key = Console.ReadKey(True).Key
          Select Case key
          Case ConsoleKey.J
            Return MessageBoxResults.Yes
          Case ConsoleKey.N
            Return MessageBoxResults.No
          Case ConsoleKey.Escape
            Return MessageBoxResults.Cancel
          End Select
        Loop Until (key = ConsoleKey.J) _
        OrElse (key = ConsoleKey.N) _
        OrElse (key = ConsoleKey.Escape)
      End Select
    Catch ex As Exception
    Finally
      If Not messageBoxType = MessageBoxTypes.InfoBox Then
        ClearMessageBox()
      End If
      Console.CursorVisible = visible
    End Try

  End Function

  Public Sub ClearMessageBox()
    ClearWindow(_X, _Y, _X2, _Y + _WindowHeight, _ColorSet.BackColor)
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace
