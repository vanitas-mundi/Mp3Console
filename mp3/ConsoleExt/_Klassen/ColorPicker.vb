Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.Tools

Namespace Controls

Public Class ColorPicker

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _X As Int32
  Private _Y As Int32
  Private _Border As Boolean = True
  Private _ColorSet As ColorSet
  Private _VisibleItems As Int32
  Private _SelectedColor As ConsoleColor
  Private _ColorNames As String() _
  = New String() _
  {"Schwarz" _
  , "Dunkelblau" _
  , "Dunkelgrün" _
  , "Dunkelzyan" _
  , "Dunkelrot" _
  , "Dunkelmagenta" _
  , "Dunkelgelb" _
  , "Grau" _
  , "Dunkelgrau" _
  , "Blau" _
  , "Grün" _
  , "Zyan" _
  , "Rot" _
  , "Magenta" _
  , "Gelb" _
  , "Weiß"}
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)

    Initialize(x, y, colorSet, visibleItems)
  End Sub

  Public Sub New _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet)

    Initialize(x, y, colorSet, 16)
  End Sub

  Public Sub New _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal visibleItems As Int32)

    Initialize(x, y, ColorSet.DefaultColorSet, visibleItems)
  End Sub

  Public Sub New(ByVal x As Int32, ByVal y As Int32)
    Initialize(x, y, ColorSet.DefaultColorSet, 16)
  End Sub

  Private Sub Initialize _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)
    _X = x
    _Y = y
    _ColorSet = colorSet
    _VisibleItems = visibleItems
  End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property SelectedColor() As ConsoleColor
  Get
    Return _SelectedColor
  End Get
  End Property

  Public Property Border() As Boolean
  Get
    Return _Border
  End Get
  Set(ByVal value As Boolean)
    _Border = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Function SelectColor() As DialogResults

    Dim bmi As New BarMenus.BarMenuInfos _
    (_ColorNames, _X, _Y, _ColorSet, _VisibleItems)

    If _Border Then
      Dim borderSettings = New BorderSettings
      borderSettings.X = _X - 1
      borderSettings.Y = _Y
      borderSettings.X = 18
      borderSettings.X = _Y + _VisibleItems + 1
      borderSettings.ForeColor = _ColorSet.ForeColor
      borderSettings.BackColor = _ColorSet.BackColor
      DrawBorder(borderSettings)
    End If

    Dim bm = New BarMenus.BarMenu(Of String)(bmi)

    For i = 0 To 15
      Dim color = CType(System.Enum.Parse _
      (GetType(ConsoleColor), i.ToString), ConsoleColor)
      WriteXY("■", _X, _Y + i + 1, color, _ColorSet.BackColor)
    Next i

    bm.Border = False
    Select Case bm.ShowMenu()
    Case DialogResults.OK
      Select Case bm.Value
      Case "Schwarz"
        _SelectedColor = ConsoleColor.Black
      Case "Dunkelblau"
        _SelectedColor = ConsoleColor.DarkBlue
      Case "Dunkelgrün"
        _SelectedColor = ConsoleColor.DarkGreen
      Case "Dunkelzyan"
        _SelectedColor = ConsoleColor.DarkCyan
      Case "Dunkelrot"
        _SelectedColor = ConsoleColor.DarkRed
      Case "Dunkelmagenta"
        _SelectedColor = ConsoleColor.DarkMagenta
      Case "Dunkelgelb"
        _SelectedColor = ConsoleColor.DarkYellow
      Case "Grau"
        _SelectedColor = ConsoleColor.Gray
      Case "Dunkelgrau"
        _SelectedColor = ConsoleColor.DarkGray
      Case "Blau"
        _SelectedColor = ConsoleColor.Blue
      Case "Grün"
        _SelectedColor = ConsoleColor.Green
      Case "Zyan"
        _SelectedColor = ConsoleColor.Cyan
      Case "Rot"
        _SelectedColor = ConsoleColor.Red
      Case "Magenta"
        _SelectedColor = ConsoleColor.Magenta
      Case "Gelb"
        _SelectedColor = ConsoleColor.Yellow
      Case "Weiß"
        _SelectedColor = ConsoleColor.White
      End Select
      ClearWindow(_X - 1, _Y, 18, _Y + _VisibleItems + 1, _ColorSet.BackColor)
      Return DialogResults.OK
    Case Else
      ClearWindow(_X - 1, _Y, 18, _Y + _VisibleItems + 1, _ColorSet.BackColor)
      Return DialogResults.Cancel
    End Select
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace
