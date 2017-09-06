Option Explicit On
Option Strict On
Option Infer On

Namespace BarMenus

Public Class FilePicker
  Inherits PathPicker

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal barMenuInfos As BarMenuInfos)
    MyBase.new(barMenuInfos)
    Initialize(New String() {})
  End Sub

  Public Sub New _
  (ByVal barMenuInfos As BarMenuInfos _
  , ByVal shortenPathAfter As Int32)

    MyBase.new(barMenuInfos, shortenPathAfter)
    Initialize(New String() {})
  End Sub

  Public Sub New _
  (ByVal barMenuInfos As BarMenuInfos _
  , ByVal wildCards() As String)

    MyBase.new(barMenuInfos)
    Initialize(wildCards)
  End Sub

  Public Sub New _
  (ByVal barMenuInfos As BarMenuInfos _
  , ByVal wildCards() As String _
  , ByVal shortenPathAfter As Int32)

    MyBase.new(barMenuInfos, shortenPathAfter)
    Initialize(wildCards)
  End Sub

  Private Sub Initialize _
  (ByVal wildCards() As String)

    _ListFiles = True
    _Wildcards = wildCards
  End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property FileName() As String
  Get
    Return _FileName
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class

End Namespace
