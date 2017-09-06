Public Class DiceResults
  Inherits System.Collections.Generic.List(Of Int32)

  Private _Modification As Int32

  Public Property Modification() As Int32
  Get
    Return _Modification
  End Get
  Set(ByVal value As Int32)
    _Modification = value
  End Set
  End Property

  Public Function ToSum() As Int32
    Return Me.ToSum(False)
  End Function

  Public Overloads ReadOnly Property Item _
  (ByVal index As Int32 _
  , ByVal AddModificationToRoll As Boolean) As Int32
  Get
    Select Case AddModificationToRoll
    Case False
      Return Me.Item(index)
    Case Else
      Return Me.Item(index) + Me.Modification
    End Select
  End Get
  End Property

  Public Function ToSum _
  (ByVal AddModificationToAllRolls As Boolean) As Int32
    Select Case AddModificationToAllRolls
    Case False
      Return Me.Sum + Me.Modification
    Case Else
      Return Me.Sum + (Me.Modification * Me.Count)
    End Select
  End Function
End Class

Public Enum DiceTypes
  Dice2 = 0
  Dice3 = 1
  Dice4 = 2
  Dice6 = 3
  Dice8 = 4
  Dice10 = 5
  Dice12 = 6
  Dice20 = 7
  Dice30 = 8
  Dice100 = 9
  Dice1000 = 10
End Enum

Public Class Roll
  Private Shared _DiceGenerator As New System.Random

#Region "  ---------------- Roll Type --------------"
  Public Shared Function Dice2() As Int32
    Return _DiceGenerator.Next(2) + 1
  End Function

  Public Shared Function Dice3() As Int32
    Return _DiceGenerator.Next(3) + 1
  End Function

  Public Shared Function Dice4() As Int32
    Return _DiceGenerator.Next(4) + 1
  End Function

  Public Shared Function Dice6() As Int32
    Return _DiceGenerator.Next(6) + 1
  End Function

  Public Shared Function Dice8() As Int32
    Return _DiceGenerator.Next(8) + 1
  End Function

  Public Shared Function Dice10() As Int32
    Return _DiceGenerator.Next(10) + 1
  End Function

  Public Shared Function Dice12() As Int32
    Return _DiceGenerator.Next(12) + 1
  End Function

  Public Shared Function Dice20() As Int32
    Return _DiceGenerator.Next(20) + 1
  End Function

  Public Shared Function Dice30() As Int32
    Return _DiceGenerator.Next(30) + 1
  End Function

  Public Shared Function Dice100() As Int32
    Return _DiceGenerator.Next(100) + 1
  End Function

  Public Shared Function Dice1000() As Int32
    Return _DiceGenerator.Next(1000) + 1
  End Function
#End Region

#Region "  ---------------- Roll Dice --------------"
  Public Shared Function Dice _
  (ByVal diceCount As Byte _
  , ByVal dicetype As DiceTypes) As Int32

    Dim result As Int32 = 0

    For i = 1 To diceCount
      Select Case dicetype
      Case DiceTypes.Dice2
        result += Dice2()
      Case DiceTypes.Dice3
        result += Dice3()
      Case DiceTypes.Dice4
        result += Dice4()
      Case DiceTypes.Dice6
        result += Dice6()
      Case DiceTypes.Dice8
        result += Dice8()
      Case DiceTypes.Dice10
        result += Dice10()
      Case DiceTypes.Dice12
        result += Dice12()
      Case DiceTypes.Dice20
        result += Dice20()
      Case DiceTypes.Dice30
        result += Dice30()
      Case DiceTypes.Dice100
        result += Dice100()
      Case DiceTypes.Dice1000
        result += Dice1000()
      End Select
    Next i

    Return result
  End Function

  Public Shared Function Dice _
  (ByVal diceCount As Byte _
  , ByVal dicetype As DiceTypes _
  , ByVal modification As Int32) As Int32

    Return Dice(diceCount, dicetype) + modification
  End Function

  Public Shared Function Dice _
  (ByVal diceCount As Byte _
  , ByVal diceSides As Int32) As Int32

    Dim result As Int32 = 0

    For i = 1 To diceCount
      result += _DiceGenerator.Next(diceSides) + 1
    Next i
    Return result
  End Function

  Public Shared Function Dice _
  (ByVal diceCount As Byte _
  , ByVal diceSides As Int32 _
  , ByVal modification As Int32) As Int32

    Return Dice(diceCount, diceSides) + modification
  End Function
#End Region

#Region "  ---------------- Roll Dice List --------------"
  Public Shared Function DiceList _
  (ByVal diceCount As Byte _
  , ByVal dicetype As DiceTypes) As DiceResults

    Dim results As New DiceResults

    For i = 1 To diceCount
      results.Add(Dice(1, dicetype))
    Next i
    Return results
  End Function

  Public Shared Function DiceList _
  (ByVal diceCount As Byte _
  , ByVal dicetype As DiceTypes _
  , ByVal modification As Int32) As DiceResults

    Dim results As DiceResults = DiceList(diceCount, dicetype)
    results.Modification = modification

    Return results
  End Function

  Public Shared Function DiceList _
  (ByVal diceCount As Byte _
  , ByVal diceSides As Int32) As DiceResults

    Dim results As New DiceResults

    For i = 1 To diceCount
      results.Add(Dice(1, diceSides))
    Next i
    Return results
  End Function

  Public Shared Function DiceList _
  (ByVal diceCount As Byte _
  , ByVal diceSides As Int32 _
  , ByVal modification As Int32) As DiceResults

    Dim results As DiceResults = DiceList(diceCount, diceSides)
    results.Modification = modification

    Return results
  End Function
#End Region

#Region "  ---------------- Roll Custom --------------"
  Public Shared Function Custom _
  (ByVal min As Int32 _
  , ByVal max As Int32) As Int32

    Dim randomFactor As Int32 = 0
    Dim result As Int32
    Select Case min
    Case Is < 0
      randomFactor = ((min * -1) + max + 1)
      result = _DiceGenerator.Next(randomFactor) - (min * -1)
    Case Is = 0
      result = _DiceGenerator.Next(max + 1)
    Case Is > 0
      randomFactor = max - min + 1
      result = _DiceGenerator.Next(randomFactor) + min
    End Select

    Return result
  End Function

  Public Shared Function Custom _
  (ByVal diceCount As Byte _
  , ByVal min As Int32 _
  , ByVal max As Int32) As Int32

    Dim result As Int32
    For i = 1 To diceCount
      result += Custom(1, min, max)
    Next i

    Return result
  End Function

  Public Shared Function Custom _
  (ByVal min As Int32 _
  , ByVal max As Int32 _
  , ByVal modification As Int32) As Int32

    Return Custom(min, max) + modification
  End Function

  Public Shared Function Custom _
  (ByVal diceCount As Byte _
  , ByVal min As Int32 _
  , ByVal max As Int32 _
  , ByVal modification As Int32) As Int32

    Return Custom(diceCount, min, max) + modification
  End Function
#End Region

#Region "  ---------------- Roll Custom List --------------"
  Public Shared Function CustomList _
  (ByVal diceCount As Byte _
  , ByVal min As Int32 _
  , ByVal max As Int32) As DiceResults

    Dim results As New DiceResults
    For i = 1 To diceCount
      results.Add(Custom(1, min, max))
    Next i

    Return results
  End Function

  Public Shared Function CustomList _
  (ByVal diceCount As Byte _
  , ByVal min As Int32 _
  , ByVal max As Int32 _
  , ByVal modification As Int32) As DiceResults

    Dim results As DiceResults = CustomList(diceCount, min, max)
    results.Modification = modification

    Return results
  End Function
#End Region

End Class
