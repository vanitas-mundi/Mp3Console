Namespace GameSystem

Public Enum Attributes
  Kraft = 0
  Gewandtheit = 1
  Klugheit = 2
  Charisma = 3
  Wahrnehmung = 4
End Enum

Public Class sulValue
  Private _Gesamt As Int32
  Private _Grad As Int32
  Private _MagieBonus As Int32
  Private _Sippenbonus As Int32
  Private _Attributsbonus As Int32
  Private _Basisattribut As Attribute

  Public Overrides Function ToString() As String
    Return Me.Gesamt.ToString
  End Function

#Region " ------------- Properties ------------>> "

  Public ReadOnly Property Gesamt() As Int32
  Get
    Return Me.Grad + Me.Attributsbonus + Me.Sippenbonus + Me.MagieBonus
  End Get
  End Property

  Public Property Grad() As Int32
  Get
    Return _Grad
  End Get
  Set(ByVal value As Int32)
    _Grad = value
  End Set
  End Property

  Public Property MagieBonus() As Int32
  Get
    Return _MagieBonus
  End Get
  Set(ByVal value As Int32)
    _MagieBonus = value
  End Set
  End Property

  Public Property Sippenbonus() As Int32
  Get
    Return _Sippenbonus
  End Get
  Set(ByVal value As Int32)
    _Sippenbonus = value
  End Set
  End Property

  Public Property Attributsbonus() As Int32
  Get
    Return _Attributsbonus
  End Get
  Set(ByVal value As Int32)
    _Attributsbonus = value
  End Set
  End Property

  Public Property Basisattribut() As Attribute
  Get
    Return _Basisattribut
  End Get
  Set(ByVal value As Attribute)
    _Basisattribut = value
  End Set
  End Property

#End Region
End Class

End Namespace