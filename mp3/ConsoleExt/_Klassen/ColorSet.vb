Option Explicit On
Option Strict On
Option Infer On

Public Class ColorSet

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Public Shared DefaultColorSet As New ColorSet

  Private _BorderColor As ConsoleColor
  Private _ForeColor As ConsoleColor
  Private _BackColor As ConsoleColor
  Private _SelectionForeColor As ConsoleColor
  Private _SelectionBackColor As ConsoleColor
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
    Initialize(Console.ForegroundColor _
    , Console.ForegroundColor _
    , Console.BackgroundColor _
    , Console.BackgroundColor _
    , Console.ForegroundColor)
  End Sub

  Public Sub New _
  (ByVal borderColor As ConsoleColor _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor _
  , ByVal selectionForeColor As ConsoleColor _
  , ByVal selectionBackColor As ConsoleColor)

    Initialize(borderColor, foreColor, backColor _
    , selectionForeColor, selectionBackColor)
  End Sub

  Private Sub Initialize _
  (ByVal borderColor As ConsoleColor _
  , ByVal foreColor As ConsoleColor _
  , ByVal backColor As ConsoleColor _
  , ByVal selectionForeColor As ConsoleColor _
  , ByVal selectionBackColor As ConsoleColor)

    _BorderColor = BorderColor
    _ForeColor = ForeColor
    _BackColor = BackColor
    _SelectionForeColor = SelectionForeColor
    _SelectionBackColor = SelectionBackColor
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property BorderColor() As ConsoleColor
  Get
    Return _BorderColor
  End Get
  Set(ByVal value As ConsoleColor)
    _BorderColor = value
  End Set
  End Property

  Public Property ForeColor() As ConsoleColor
  Get
    Return _ForeColor
  End Get
  Set(ByVal value As ConsoleColor)
    _ForeColor = value
  End Set
  End Property

  Public Property BackColor() As ConsoleColor
  Get
    Return _BackColor
  End Get
  Set(ByVal value As ConsoleColor)
    _BackColor = value
  End Set
  End Property

  Public Property SelectionForeColor() As ConsoleColor
  Get
    Return _SelectionForeColor
  End Get
  Set(ByVal value As ConsoleColor)
    _SelectionForeColor = value
  End Set
  End Property

  Public Property SelectionBackColor() As ConsoleColor
  Get
    Return _SelectionBackColor
  End Get
  Set(ByVal value As ConsoleColor)
    _SelectionBackColor = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class
