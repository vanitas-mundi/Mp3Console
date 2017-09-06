Option Explicit On
Option Strict On
Option Infer On

Public Class DialogBounds

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _x As Int32
  Private _y As Int32
  Private _x2 As Int32
  Private _y2 As Int32
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal x As Int32, ByVal y As Int32 _
  , ByVal x2 As Int32, ByVal y2 As Int32)
    _x = x
    _y = y
    _x2 = x2
    _y2 = y2
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property x() As Int32
  Get
    Return _x
  End Get
  End Property

  Public ReadOnly Property y() As Int32
  Get
    Return _y
  End Get
  End Property

  Public ReadOnly Property x2() As Int32
  Get
    Return _x2
  End Get
  End Property

  Public ReadOnly Property y2() As Int32
  Get
    Return _y2
  End Get
  End Property

  Public ReadOnly Property Height() As Int32
  Get
    Return _y2 - y + 1
  End Get
  End Property

  Public ReadOnly Property Width() As Int32
  Get
    Return _x2 - x + 1
  End Get
  End Property

  Public ReadOnly Property HorizontalEnd() As Int32
  Get
    Return Me.Width + Me.x - 1
  End Get
  End Property

  Public ReadOnly Property VerticalEnd() As Int32
  Get
    Return Me.Height + Me.y - 1
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class
