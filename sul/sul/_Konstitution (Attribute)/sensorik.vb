Namespace Attributes

Public Enum Sinne
  Sehen = 0
  Hören = 1
  Riechen = 2
  Schmecken = 3
  Tasten = 4
  Magnetsinn = 5
  Wärmesinn = 6
  Schwingungssinn = 7
  Elektrizitätssinn = 8
  Nachtsicht = 9
  Gefahrengespür = 10
  Magiegespür = 11
End Enum

Public Class sensorik
  Private _Wahrnehmung As RPG.SUL.GameSystem.sulValue
  Private _Aufmerksamkeit As RPG.SUL.GameSystem.sulValue
  Private _Fernkampfschadensbonus As RPG.SUL.GameSystem.sulValue
  Private _Kampfreflexbonus As RPG.SUL.GameSystem.sulValue
  Private _Initiativebonus As RPG.SUL.GameSystem.sulValue
  Private _Kenntnisbonus As RPG.SUL.GameSystem.sulValue

#Region " ------------- Properties ------------>> "
  Public Property Wahrnehmung() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Wahrnehmung
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Wahrnehmung = value
  End Set
  End Property

  Public Property Aufmerksamkeit() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Aufmerksamkeit
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Aufmerksamkeit = value
  End Set
  End Property

  Public Property Fernkampfschadensbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Fernkampfschadensbonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Fernkampfschadensbonus = value
  End Set
  End Property

  ''' <summary>
  ''' Bonus bei kritischen Treffern
  ''' </summary>
  Public Property Kampfreflexbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Kampfreflexbonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Kampfreflexbonus = value
  End Set
  End Property

  Public Property Initiativebonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Initiativebonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Initiativebonus = value
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

