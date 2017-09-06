Namespace Attributes

Public Class psyche
  Private _Klugheit As RPG.SUL.GameSystem.sulValue
  Private _Willenskraft As RPG.SUL.GameSystem.sulValue
  Private _Lernbegabung As RPG.SUL.GameSystem.sulValue
  Private _Sprachbegabung As RPG.SUL.GameSystem.sulValue
  Private _Konzentration As RPG.SUL.GameSystem.sulValue
  Private _KenntnisBonus As RPG.SUL.GameSystem.sulValue


#Region " ------------- Properties ------------>> "
  Public Property Klugheit() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Klugheit
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Klugheit = value
  End Set
  End Property

  Public Property Willenskraft() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Willenskraft
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Willenskraft = value
  End Set
  End Property

  Public Property Lernbegabung() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Lernbegabung
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Lernbegabung = value
  End Set
  End Property

  Public Property Sprachbegabung() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Sprachbegabung
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Sprachbegabung = value
  End Set
  End Property

  Public Property Konzentration() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Konzentration
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Konzentration = value
  End Set
  End Property

  Public Property Kenntnisbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _KenntnisBonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _KenntnisBonus = value
  End Set
  End Property

#End Region
End Class

End Namespace


