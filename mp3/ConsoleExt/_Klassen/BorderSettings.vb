Option Explicit On
Option Infer On
Option Strict On

Public Class BorderSettings

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _X As Int32 = 0
  Private _Y As Int32 = 0
  Private _X2 As Int32 = 0
  Private _Y2 As Int32 = 0
  Private _Bounds As New DialogBounds(0, 0, 0, 0)
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
  Public Property Bounds As DialogBounds
  Get
    Return _Bounds
  End Get
  Set(value As DialogBounds)
    _Bounds = value
    _X = value.x
    _Y = value.y
    _X2 = value.x2
    _Y2 = value.y2
  End Set
  End Property

  Public Property X As Int32
  Get
    Return _X
  End Get
  Set(value As Int32)
    _X = value
    _Bounds = New DialogBounds(value, Me.Y, Me.X2, Me.Y2)
  End Set
  End Property

  Public Property Y As Int32
  Get
    Return _Y
  End Get
  Set(value As Int32)
    _Y = value
    _Bounds = New DialogBounds(Me.X, value, Me.X2, Me.Y2)
  End Set
  End Property

  Public Property X2 As Int32
  Get
    Return _X2
  End Get
  Set(value As Int32)
    _X2 = value
    _Bounds = New DialogBounds(Me.X, Me.Y, value, Me.Y2)
  End Set
  End Property

  Public Property Y2 As Int32
  Get
    Return _Y2
  End Get
  Set(value As Int32)
    _Y2 = value
    _Bounds = New DialogBounds(Me.X, Me.Y, Me.X2, value)
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
