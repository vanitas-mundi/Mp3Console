Option Explicit On
Option Strict On
Option Infer On

  Public Enum MessageBoxResults
    OK = 0
    Cancel = 1
    Yes = 2
    No = 3
  End Enum

  Public Enum OptionBoxResults
    Cancel = 0
    Option1 = 1
    Option2 = 2
    Option3 = 3
    Option4 = 4
    Option5 = 5
    Option6 = 6
    Option7 = 7
    Option8 = 8
    Option9 = 9
  End Enum

  Public Enum MessageBoxTypes
    InfoBox = 0
    Message = 1
    Question = 2
    CancelOK = 3
    YesNoCancel = 4
  End Enum

  Public Enum DialogResults
    OK = 0
    Cancel = 1
  End Enum

Namespace BarMenus

Public Class BarMenuKeyPressedEventArgs
  Inherits EventArgs

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _KeyInfo As ConsoleKeyInfo
  Private _ExitBarMenu As Boolean = False
  Private _ReturnValue As Object = Nothing
  Private _ReturnDialogResult As DialogResults = DialogResults.OK
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal keyInfo As ConsoleKeyInfo)
    _KeyInfo = keyInfo
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property KeyInfo() As ConsoleKeyInfo
  Get
    Return _KeyInfo
  End Get
  End Property

  Public Property ExitBarMenu() As Boolean
  Get
    Return _ExitBarMenu
  End Get
  Set(ByVal value As Boolean)
    _ExitBarMenu = value
  End Set
  End Property

  Public Property ReturnValue() As Object
  Get
    Return _ReturnValue
  End Get
  Set(ByVal value As Object)
    _ReturnValue = value
  End Set
  End Property

  Public Property ReturnDialogResult() As DialogResults
  Get
    Return _ReturnDialogResult
  End Get
  Set(ByVal value As DialogResults)
    _ReturnDialogResult = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class

Public Class BarMenuItemChangedEventArgs(Of T)
  Inherits EventArgs

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Item As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal item As T)
    _Item = item
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property Item() As T
  Get
    Return _Item
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class

Public Class BarMenuDefaultItem(Of T)

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _DisplayName As String
  Private _Index As Int32
  Private _Object As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New()
  End Sub

  Public Sub New _
  (ByVal displayName As String _
  , ByVal index As Int32 _
  , ByVal [object] As T)

    _DisplayName = displayName
    _Index = index
    _Object = [object]
  End Sub

  Public Overrides Function ToString() As String
    Return Me.DisplayName
  End Function
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property DisplayName() As String
  Get
    Return _DisplayName
  End Get
  Set(ByVal value As String)
    _DisplayName = value
  End Set
  End Property

  Public Property Index() As Int32
  Get
    Return _Index
  End Get
  Set(ByVal value As Int32)
    _Index = value
  End Set
  End Property

  Public Property [Object]() As T
  Get
    Return _Object
  End Get
  Set(ByVal value As T)
    _Object = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class

End Namespace

