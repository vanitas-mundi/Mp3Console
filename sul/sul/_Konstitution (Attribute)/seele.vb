Namespace Attributes

Public Class seele
  Private _Charisma As RPG.SUL.GameSystem.sulValue
  Private _Autonomie As RPG.SUL.GameSystem.sulValue
  Private _Gottesgunst As RPG.SUL.GameSystem.sulValue
  Private _Mana As RPG.SUL.GameSystem.sulValue
  Private _Magieressistenz As RPG.SUL.GameSystem.sulValue
  Private _KenntnisBonus As RPG.SUL.GameSystem.sulValue

#Region " ------------- Properties ------------>> "
  Public Property Charisma() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Charisma
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Charisma = value
  End Set
  End Property

  Public Property Autonomie() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Autonomie
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Autonomie = value
  End Set
  End Property

  Public Property Gottesgunst() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Gottesgunst
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Gottesgunst = value
  End Set
  End Property

  Public Property Mana() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Mana
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Mana = value
  End Set
  End Property

  Public Property Magieressistenz() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Magieressistenz
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Magieressistenz = value
  End Set
  End Property

  Public Property KenntnisBonus() As RPG.SUL.GameSystem.sulValue
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


