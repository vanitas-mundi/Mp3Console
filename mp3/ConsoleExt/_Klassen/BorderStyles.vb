Option Explicit On
Option Infer On
Option Strict On

Public Enum BorderStyleTypes
  None = 0
  [Single] = 1
  [Double] = 2
End Enum

Public Class BorderStyles

    '┌───┬───┐
    '│   │   │
    '├───┼───┤
    '│   │   │
    '└───┴───┘
    '╔════╦════╗
    '║    ║    ║
    '╠════╬════╣
    '║    ║    ║
    '╚════╩════╝
#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Public Shared NoneSymbols As New BorderStyles(BorderStyleTypes.None)
  Public Shared SingleSymbols As New BorderStyles(BorderStyleTypes.Single)
  Public Shared DoubleSymbols As New BorderStyles(BorderStyleTypes.Double)

  Private _LeftTopCorner As Char
  Private _RightTopCorner As Char
  Private _LeftBottomCorner As Char
  Private _RightBottomCorner As Char
  Private _LeftCrossing As Char
  Private _TopCrossing As Char
  Private _MiddleCrossing As Char
  Private _RightCrossing As Char
  Private _BottomCrossing As Char
  Private _HorizontalLine As Char
  Private _VerticalLine As Char
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal borderType As BorderStyleTypes)
    Select Case borderType
    Case BorderStyleTypes.None
      _LeftTopCorner = " "c
      _RightTopCorner = " "c
      _LeftBottomCorner = " "c
      _RightBottomCorner = " "c
      _LeftCrossing = " "c
      _TopCrossing = " "c
      _MiddleCrossing = " "c
      _RightCrossing = " "c
      _BottomCrossing = " "c
      _HorizontalLine = " "c
      _VerticalLine = " "c
    Case BorderStyleTypes.Single
      _LeftTopCorner = "┌"c
      _RightTopCorner = "┐"c
      _LeftBottomCorner = "└"c
      _RightBottomCorner = "┘"c
      _LeftCrossing = "├"c
      _TopCrossing = "┬"c
      _MiddleCrossing = "┼"c
      _RightCrossing = "┤"c
      _BottomCrossing = "┴"c
      _HorizontalLine = "─"c
      _VerticalLine = "│"c
    Case BorderStyleTypes.Double
      _LeftTopCorner = "╔"c
      _RightTopCorner = "╗"c
      _LeftBottomCorner = "╚"c
      _RightBottomCorner = "╝"c
      _LeftCrossing = "╠"c
      _TopCrossing = "╦"c
      _MiddleCrossing = "╬"c
      _RightCrossing = "╣"c
      _BottomCrossing = "╩"c
      _HorizontalLine = "═"c
      _VerticalLine = "║"c
    End Select
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property LeftTopCorner As Char
  Get
    Return _LeftTopCorner
  End Get
  End Property

  Public ReadOnly Property RightTopCorner As Char
  Get
    Return _RightTopCorner
  End Get
  End Property

  Public ReadOnly Property LeftBottomCorner As Char
  Get
    Return _LeftBottomCorner
  End Get
  End Property

  Public ReadOnly Property RightBottomCorner As Char
  Get
    Return _RightBottomCorner
  End Get
  End Property

  Public ReadOnly Property LeftCrossing As Char
  Get
    Return _LeftCrossing
  End Get
  End Property

  Public ReadOnly Property TopCrossing As Char
  Get
    Return _TopCrossing
  End Get
  End Property

  Public ReadOnly Property MiddleCrossing As Char
  Get
    Return _MiddleCrossing
  End Get
  End Property

  Public ReadOnly Property RightCrossing As Char
  Get
    Return _RightCrossing
  End Get
  End Property

  Public ReadOnly Property BottomCrossing As Char
  Get
    Return _BottomCrossing
  End Get
  End Property

  Public ReadOnly Property HorizontalLine As Char
  Get
    Return _HorizontalLine
  End Get
  End Property

  Public ReadOnly Property VerticalLine As Char
  Get
    Return _VerticalLine
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class
