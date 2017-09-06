Option Explicit On
Option Strict On
Option Infer On

Namespace BarMenus

<System.ComponentModel.DefaultProperty("SelectedItem")> _
Public Class BarMenuInfos

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Items() As Object
  Private _SelectedIndex As Int32
  Private _X As Int32
  Private _Y As Int32
  Private _ColorSet As ColorSet
  Private _VisibleItems As Int32
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal visibleItems As Int32)

    Initialize(Nothing, 0, x, y, ColorSet.DefaultColorSet, visibleItems)
  End Sub

  Public Sub New _
  (ByVal items() As Object _
  , ByVal selectedIndex As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal visibleItems As Int32)

    Initialize(items, selectedIndex, x, y, ColorSet.DefaultColorSet, visibleItems)
  End Sub

  Public Sub New _
  (ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)

    Initialize(Nothing, 0, x, y, colorSet, visibleItems)
  End Sub

  Public Sub New _
  (ByVal items() As Object _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)

    Initialize(items, 0, x, y, colorSet, visibleItems)
  End Sub

  Public Sub New _
  (ByVal items() As Object _
  , ByVal selectedIndex As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)

    Initialize(items, selectedIndex, x, y, colorSet, visibleItems)
  End Sub

  Private Sub Initialize _
  (ByVal items() As Object _
  , ByVal selectedIndex As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32 _
  , ByVal colorSet As ColorSet _
  , ByVal visibleItems As Int32)

    _Items = items
    _SelectedIndex = selectedIndex
    _X = x
    _Y = y
    _ColorSet = colorSet
    _VisibleItems = visibleItems
  End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property Items() As Object()
  Get
    Return _Items
  End Get
  Set(ByVal value As Object())
    _Items = value
  End Set
  End Property

  Public Property SelectedIndex() As Int32
  Get
    Return _SelectedIndex
  End Get
  Set(ByVal value As Int32)
    _SelectedIndex = value
  End Set
  End Property

  Public ReadOnly Property x() As Int32
  Get
    Return _X
  End Get
  End Property

  Public ReadOnly Property y() As Int32
  Get
    Return _Y
  End Get
  End Property

  Public ReadOnly Property ColorSet() As ColorSet
  Get
    Return _ColorSet
  End Get
  End Property

  Public ReadOnly Property SelectedItem() As Object
  Get
    Return _Items(_SelectedIndex)
  End Get
  End Property

  Public ReadOnly Property VisibleItems() As Int32
  Get
    Return _VisibleItems
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

End Class

End Namespace
