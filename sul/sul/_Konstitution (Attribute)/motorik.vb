Namespace Attributes

Public Class motorik
  Private _Gewandtheit As RPG.SUL.GameSystem.sulValue
  Private _Ausweichen As RPG.SUL.GameSystem.sulValue
  Private _Bewegungsrate As RPG.SUL.GameSystem.sulValue
  Private _Offensivbonus As RPG.SUL.GameSystem.sulValue
  Private _Defensivbonus As RPG.SUL.GameSystem.sulValue
  Private _KenntnisBonus As RPG.SUL.GameSystem.sulValue

#Region " ------------- Properties ------------>> "
  Public Property Gewandtheit() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Gewandtheit
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Gewandtheit = value
  End Set
  End Property

  Public Property Ausweichen() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Ausweichen
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Ausweichen = value
    Dim sb As New System.Text.StringBuilder

  End Set
  End Property

  Public Property Bewegungsrate() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Bewegungsrate
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Bewegungsrate = value
  End Set
  End Property

  Public Property Offensivbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Offensivbonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Offensivbonus = value
  End Set
  End Property

  Public Property Defensivbonus() As RPG.SUL.GameSystem.sulValue
  Get
    Return _Defensivbonus
  End Get
  Set(ByVal value As RPG.SUL.GameSystem.sulValue)
    _Defensivbonus = value
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
