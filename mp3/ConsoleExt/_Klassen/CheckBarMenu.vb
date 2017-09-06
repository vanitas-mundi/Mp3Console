Option Explicit On
Option Strict On
Option Infer On

Namespace BarMenus

Public Class CheckBarMenu(Of T)

Inherits BarMenu(Of T)

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _SelectedItems As New Generic.List(Of Int32)
  Private _Values As T()
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal barMenuInfos As BarMenuInfos)
    MyBase.New(barMenuInfos)
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property Checked(ByVal itemIndex As Int32) As Boolean
  Get
    Return _SelectedItems.Contains(itemIndex)
  End Get
  Set(ByVal value As Boolean)
    If value Then
      If Not _SelectedItems.Contains(itemIndex) Then _SelectedItems.Add(itemIndex)
    Else
      If _SelectedItems.Contains(itemIndex) Then _SelectedItems.Remove(itemIndex)
    End If
  End Set
  End Property

  Public Property Checked(ByVal item As T) As Boolean
  Get
    Dim itemIndex = Array.IndexOf(_BarMenuInfos.Items, item)
    Return _SelectedItems.Contains(itemIndex)
  End Get
  Set(ByVal value As Boolean)
    Dim itemIndex = Array.IndexOf(_BarMenuInfos.Items, item)

    If value Then
      If Not _SelectedItems.Contains(itemIndex) Then _SelectedItems.Add(itemIndex)
    Else
      If _SelectedItems.Contains(itemIndex) Then _SelectedItems.Remove(itemIndex)
    End If
  End Set
  End Property

  Public ReadOnly Property Values() As T()
  Get
    Return _Values
  End Get
  End Property

  Protected Overrides ReadOnly Property LargestItem() As Integer
    Get
      Return MyBase.LargestItem + 4
    End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Protected Overrides Function GetFormatedItem _
  (ByVal itemIndex As Integer _
  , ByVal isSelected As Boolean) As String

    Dim max = _CurrentWith - 2
    Dim item As String = ""

    If _SelectedItems.Contains(itemIndex) Then
      item = " [x]" & MyBase.GetFormatedItem(itemIndex, isSelected)
    Else
      item = " [ ]" & MyBase.GetFormatedItem(itemIndex, isSelected)
    End If

    If item.Length > max Then
      If item.TrimEnd.Length > max Then
        Return SSP.ConsoleExt.Tools.StringShorten _
        (item, max - 1) & " "
      Else
        Return item.Substring(1, max)
      End If
    Else
      Return item
    End If
  End Function

  Protected Overrides Sub MenuAction _
  (ByVal keyInfo As ConsoleKeyInfo)

    MyBase.MenuAction(keyInfo)

    With _BarMenuInfos
      Select Case keyInfo.Key
      Case ConsoleKey.Enter
        Dim list As New Generic.List(Of T)
        For Each itemIndex In _SelectedItems
          list.Add(DirectCast(.Items(itemIndex), T))
        Next itemIndex
        _Values = list.ToArray
      Case ConsoleKey.Spacebar
        If _SelectedItems.Contains(.SelectedIndex) Then
          _SelectedItems.Remove(.SelectedIndex)
        Else
          _SelectedItems.Add(.SelectedIndex)
        End If
        DrawSelectedItem(.SelectedIndex, .x, _PositionY)
      Case ConsoleKey.Delete
        _SelectedItems.Clear()
        DrawMenu()
      Case ConsoleKey.Insert
        _SelectedItems.Clear()
        For i As Int32 = 0 To _BarMenuInfos.Items.Count - 1
          _SelectedItems.Add(i)
        Next i
        DrawMenu()
      End Select
    End With
  End Sub
#End Region '{Private Methoden der Klasse}

End Class

End Namespace
