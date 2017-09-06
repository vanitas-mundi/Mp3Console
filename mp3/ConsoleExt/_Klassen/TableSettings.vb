Option Explicit On
Option Infer On
Option Strict On

Public Class TableSettings

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _ColWidths As New List(Of Int32)
  Private _RowHeights As New List(Of Int32)
  Private _X As Int32 = 0
  Private _Y As Int32 = 0
  Private _Values As New List(Of String)
  Private _ColPadding As Int32 = 1
  Private _RowPadding As Int32 = 0
  Private _ColorSet As New ColorSet
  Private _BackColor As ConsoleColor = Console.BackgroundColor
  Private _ForeColor As ConsoleColor = Console.ForegroundColor
  Private _BorderStyleType As BorderStyleTypes = BorderStyleTypes.Single
  Private _BorderStyle As BorderStyles = BorderStyles.SingleSymbols
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property ColWidths As List(Of Int32)
  Get
    Return _ColWidths
  End Get
  End Property

  Public ReadOnly Property RowHeights() As List(Of Int32)
  Get
    Return _RowHeights
  End Get
  End Property

  Public ReadOnly Property TableWidth As Int32
  Get
    Return (Aggregate col In _ColWidths Into Sum(col)) + _ColWidths.Count + 1
  End Get
  End Property

  Public ReadOnly Property TableHeight As Int32
  Get
    Return (Aggregate row In _RowHeights Into Sum(row)) + _RowHeights.Count + 1
  End Get
  End Property

  Public Property X As Int32
  Get
    Return _X
  End Get
  Set(value As Int32)
    _X = value
  End Set
  End Property

  Public Property Y As Int32
  Get
    Return _Y
  End Get
  Set(value As Int32)
    _Y = value
  End Set
  End Property

  Public Property Values() As List(Of String)
  Get
    Return _Values
  End Get
  Set(value As List(Of String))
    _Values = value
  End Set
  End Property

  Public Property ColPadding As Int32
  Get
    Return _ColPadding
  End Get
  Set(value As Int32)
    _ColPadding = value
  End Set
  End Property

  Public Property RowPadding As Int32
  Get
    Return _RowPadding
  End Get
  Set(value As Int32)
    _RowPadding = value
  End Set
  End Property

  Public Property ColorSet As ColorSet
  Get
    Return _ColorSet
  End Get
  Set(value As ColorSet)
    _ColorSet = value
    _BackColor = value.BackColor
    _ForeColor = value.ForeColor
  End Set
  End Property

  Public Property BackColor As ConsoleColor
  Get
    Return _BackColor
  End Get
  Set(value As ConsoleColor)
    _BackColor = value
    _ColorSet = New ColorSet(_ColorSet.BorderColor _
    , _ColorSet.ForeColor, value _
    , _ColorSet.SelectionForeColor, _ColorSet.SelectionBackColor)
  End Set
  End Property

  Public Property ForeColor As ConsoleColor
  Get
    Return _ForeColor
  End Get
  Set(value As ConsoleColor)
    _ForeColor = value
    _ColorSet = New ColorSet(_ColorSet.BorderColor _
    , value, _ColorSet.BackColor _
    , _ColorSet.SelectionForeColor, _ColorSet.SelectionBackColor)
  End Set
  End Property

  Public Property BorderStyleType As BorderStyleTypes
  Get
    Return _BorderStyleType
  End Get
  Set(value As BorderStyleTypes)
    _BorderStyleType = value
    Select Case value
    Case BorderStyleTypes.None
      _BorderStyle = BorderStyles.NoneSymbols
    Case BorderStyleTypes.Single
      _BorderStyle = BorderStyles.SingleSymbols
    Case BorderStyleTypes.Double
      _BorderStyle = BorderStyles.DoubleSymbols
    End Select
  End Set
  End Property

  Public ReadOnly Property BorderStyle As BorderStyles
  Get
    Return _BorderStyle
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
