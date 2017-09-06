Namespace Attributes

Public Class physis
  Private _Kraft As RPG.SUL.GameSystem.sulValue
  Private _Konstitution As RPG.SUL.GameSystem.sulValue
  Private _Nahkampfschadensbonus As RPG.SUL.GameSystem.sulValue
  Private _Ausdauer As RPG.SUL.GameSystem.sulValue
  Private _Tragkraft As RPG.SUL.GameSystem.sulValue
  Private _KenntnisBonus As RPG.SUL.GameSystem.sulValue


#Region " ------------- Properties ------------>> "
  Public Property Kraft() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Kraft
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Kraft = value
  End Set
  End Property

  Public Property Konstitution() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Konstitution
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Konstitution = value
  End Set
  End Property

  Public Property Nahkampfschadensbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Nahkampfschadensbonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Nahkampfschadensbonus = value
  End Set
  End Property

  Public Property Ausdauer() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Ausdauer
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Ausdauer = value
  End Set
  End Property

  Public Property Tragkraft() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Tragkraft
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Tragkraft = value
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
