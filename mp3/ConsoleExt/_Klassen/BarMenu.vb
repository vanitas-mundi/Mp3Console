Option Explicit On
Option Strict On
Option Infer On

Namespace BarMenus

Public Class BarMenu(Of T)

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Protected _BarMenuInfos As BarMenuInfos
  Protected _FirstItemIndex As Int32
  Protected _LargestItem As Int32
  Protected _Border As Boolean = True
  Protected _Value As T
  Protected _PositionY As Int32
  Protected _ExitArgs As New BarMenuKeyPressedEventArgs(Nothing)
  Protected _Bounds As DialogBounds
  Protected _MinimumWith As Int32 = 5
  Protected _MaximumWith As Int32 = 40
  Protected _CurrentWith As Int32
  Protected _SelectedItem As T
  Protected _SelectedIndex As Int32
  Protected _InfoLineLength As Int32 = 0

  Public Event KeyPressed _
  (ByVal sender As Object, ByVal e As BarMenuKeyPressedEventArgs)
  Public Event ItemChanged _
  (ByVal sender As Object, ByVal e As BarMenuItemChangedEventArgs(Of T))
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal barMenuInfos As BarMenuInfos)
    _BarMenuInfos = barMenuInfos
    GetLargestItem()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property SelectedItem() As T
  Get
    Return _SelectedItem
  End Get
  End Property

  Public ReadOnly Property SelectedIndex As Int32
  Get
    Return _SelectedIndex
  End Get
  End Property

  Public Property Border() As Boolean
  Get
    Return _Border
  End Get
  Set(ByVal value As Boolean)
    _Border = value
  End Set
  End Property

  Public ReadOnly Property Value() As T
  Get
    Return _Value
  End Get
  End Property

  Public Property MinimumWith() As Int32
  Get
    Return _MinimumWith
  End Get
  Set(ByVal value As Int32)
    _MinimumWith = value
  End Set
  End Property

  Public Property MaximumWith() As Int32
  Get
    Return _MaximumWith
  End Get
  Set(ByVal value As Int32)
    _MaximumWith = value
  End Set
  End Property

  Protected Overridable ReadOnly Property LargestItem() As Int32
  Get
    Return _LargestItem
  End Get
  End Property

  Public ReadOnly Property Bounds() As DialogBounds
  Get
    If _Bounds Is Nothing Then SetCurrentWithAndBounds()
    Return _Bounds
  End Get
  End Property

  Public ReadOnly Property Width() As Int32
  Get
    Return _CurrentWith
  End Get
  End Property

  Public ReadOnly Property Count As Int32
  Get
    Return _BarMenuInfos.Items.Count
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Protected Overridable Sub DrawMenu()
    With _BarMenuInfos

      Dim currentY = .y + 1

      For i = _FirstItemIndex To (_FirstItemIndex + .VisibleItems) - 1
        If i > .Items.Count - 1 Then Exit For
        Dim item = .Items(i)

        Select Case i
        Case .SelectedIndex
          DrawSelectedItem(i, .x, currentY)
        Case Else
          DrawItem(i, .x, currentY)
        End Select

        currentY += 1
      Next i

      _SelectedItem = DirectCast(.Items(.SelectedIndex), T)
      _SelectedIndex = .SelectedIndex
      RaiseEvent ItemChanged(Me _
      , New BarMenuItemChangedEventArgs(Of T)(_SelectedItem))
    End With
  End Sub

  Private Sub SetCurrentWithAndBounds()
    With _BarMenuInfos
      _CurrentWith = If(Me.LargestItem + 4 > _MaximumWith, _MaximumWith, Me.LargestItem + 4)
      _CurrentWith = If(_CurrentWith < _MinimumWith, _MinimumWith, _CurrentWith)
      Dim x2 = _CurrentWith + .x - 1

      _Bounds = New DialogBounds _
      (.x, .y, x2, .y + .VisibleItems + 1)
    End With
  End Sub

  Protected Overridable Sub MenuAction _
  (ByVal keyInfo As ConsoleKeyInfo)

    With _BarMenuInfos
      Select Case keyInfo.Key
      Case ConsoleKey.Home
        .SelectedIndex = 0
        _FirstItemIndex = 0
        DrawMenu()
      Case ConsoleKey.End
        .SelectedIndex = .Items.Count - 1
        _FirstItemIndex = .SelectedIndex - (.VisibleItems - 1)
        If _FirstItemIndex < 0 Then _FirstItemIndex = 0
        DrawMenu()
      Case ConsoleKey.PageUp
        .SelectedIndex -= .VisibleItems
        If .SelectedIndex < 0 Then .SelectedIndex = 0
        _FirstItemIndex = .SelectedIndex
        DrawMenu()
      Case ConsoleKey.PageDown
        .SelectedIndex += .VisibleItems
        If .SelectedIndex > .Items.Count - 1 Then .SelectedIndex = .Items.Count - 1
        _FirstItemIndex = .SelectedIndex - (.VisibleItems - 1)
        If _FirstItemIndex < 0 Then _FirstItemIndex = 0
        DrawMenu()
      Case ConsoleKey.A To ConsoleKey.Z
        For i = 0 To .Items.Count - 1
          If .Items(i).ToString.ToUpper.StartsWith(ChrW(keyInfo.Key)) Then
            .SelectedIndex = i
            Select Case True
            Case .SelectedIndex >= .VisibleItems
              If i + .VisibleItems > .Items.Count - 1 Then
                _FirstItemIndex = .Items.Count - (.VisibleItems)
              Else
                _FirstItemIndex = i
              End If
            Case Else
              _FirstItemIndex = 0
            End Select
            DrawMenu()
            Exit For
          End If
        Next i
      Case ConsoleKey.UpArrow
        MoveBarUp()
      Case ConsoleKey.DownArrow
        MoveBarDown()
      Case ConsoleKey.Enter
        _Value = CType(.SelectedItem, T)
      End Select
    End With

    _ExitArgs = New BarMenuKeyPressedEventArgs(Nothing)

    Dim args = New BarMenuKeyPressedEventArgs(keyInfo)
    RaiseEvent KeyPressed(Me, args)

    If args.ExitBarMenu Then
      _ExitArgs.ExitBarMenu = args.ExitBarMenu
      _ExitArgs.ReturnDialogResult = args.ReturnDialogResult
      _Value = DirectCast(args.ReturnValue, T)
    End If
  End Sub

  Protected Sub MoveBarDown()
    With _BarMenuInfos

      Select Case .SelectedIndex + 1
      Case Is > .Items.Count - 1
        Exit Sub
      Case Is >= (.VisibleItems + _FirstItemIndex)
        .SelectedIndex += 1
        _FirstItemIndex = (.SelectedIndex + 1) - .VisibleItems
        DrawMenu()
      Case Else
        DrawItem(.SelectedIndex, .x, _PositionY)
        .SelectedIndex += 1
        DrawSelectedItem(.SelectedIndex, .x, _PositionY + 1)

        _SelectedItem = DirectCast(.Items(.SelectedIndex), T)
        _SelectedIndex = .SelectedIndex
        RaiseEvent ItemChanged(Me _
        , New BarMenuItemChangedEventArgs(Of T)(_SelectedItem))
      End Select
    End With
  End Sub

  Protected Sub MoveBarUp()
    With _BarMenuInfos
      Select Case .SelectedIndex - 1
      Case Is < 0
        Exit Sub
      Case Is < _FirstItemIndex
        .SelectedIndex -= 1
        _FirstItemIndex = .SelectedIndex
        DrawMenu()
      Case Else
        .SelectedIndex -= 1
        DrawMenu()
      End Select

      _SelectedItem = DirectCast(.Items(.SelectedIndex), T)
      _SelectedIndex = .SelectedIndex
      RaiseEvent ItemChanged(Me _
      , New BarMenuItemChangedEventArgs(Of T)(_SelectedItem))
    End With
  End Sub

  Protected Sub DrawItem _
  (ByVal itemIndex As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32)

    With _BarMenuInfos
      Tools.WriteXY(GetFormatedItem(itemIndex, False), x + 1, y, .ColorSet)
    End With
  End Sub

  Protected Sub DrawSelectedItem _
  (ByVal itemIndex As Int32 _
  , ByVal x As Int32 _
  , ByVal y As Int32)

    _PositionY = y

    With _BarMenuInfos
      Tools.WriteXY(GetFormatedItem(itemIndex, True), x + 1, y _
      , .ColorSet.SelectionForeColor, .ColorSet.SelectionBackColor)
    End With
  End Sub

  Protected Overridable Function GetFormatedItem _
  (ByVal itemIndex As Int32 _
  , ByVal isSelected As Boolean) As String

    With _BarMenuInfos
      Dim max = _CurrentWith - 2
      Dim firstChar = IIf(isSelected, "►", " ").ToString

      Dim sb As New System.Text.StringBuilder _
      (firstChar & .Items(itemIndex).ToString & " ")

      Select Case sb.Length <= max
      Case True
        sb.Append(Space(max - sb.Length))
        Return sb.ToString
      Case Else
        Return SSP.ConsoleExt.Tools.StringShorten(sb.ToString, max - 1) & " "
      End Select
    End With
  End Function

  Protected Sub GetLargestItem()
    With _BarMenuInfos
      _LargestItem = 0

      For Each item In .Items
        Dim len = item.ToString.Length
        If len > _LargestItem Then _LargestItem = len
      Next item
    End With

    If _LargestItem > _MaximumWith Then _LargestItem = _MaximumWith

  End Sub

  Protected Overridable Sub PrintInfoLine(ByVal info As String)
    With _BarMenuInfos
      Dim x = .x + 1
      Dim y = .y + .VisibleItems + 2
      'Tools.ClearWindow(x, y, x + _InfoLineLengtht, y, .ColorSet.BackColor)
      ClearInfoLine()
      Tools.WriteXY(info, x, y, .ColorSet)
      _InfoLineLength = info.Length
    End With
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub ClearInfoLine()
    With _BarMenuInfos
      Tools.ClearLine(.y + .VisibleItems + 2 _
      , .x + 1, .x + 1 + _InfoLineLength, .ColorSet.BackColor)
    End With
  End Sub

  Public Sub ClearBox()
    Tools.ClearWindow _
    (_Bounds.x, _Bounds.y, _Bounds.x2, _Bounds.y2 _
    , _BarMenuInfos.ColorSet.BackColor)
  End Sub

  Public Sub ClearMenu()
    ClearBox()
    ClearInfoLine()
  End Sub

  Public Sub Add(ByVal item As T)
    Add(item, False)
  End Sub

  Public Sub Add(ByVal item As T, ByVal redraw As Boolean)
    With _BarMenuInfos
      Dim list = .Items.ToList
      list.Add(item)
      .Items = list.ToArray

      If .SelectedIndex < 0 Then
        .SelectedIndex = 0
      End If

      If Not redraw Then Exit Sub

      GetLargestItem()
      ShowMenu()
    End With
  End Sub

  Public Sub Remove(ByVal item As T)
    Remove(item, False)
  End Sub

  Public Sub Remove(ByVal item As T, ByVal redraw As Boolean)
    RemoveAt(_BarMenuInfos.Items.ToList.IndexOf(item), redraw)
  End Sub

  Public Sub RemoveAt(ByVal index As Int32)
    RemoveAt(index, False)
  End Sub

  Public Sub RemoveAt(ByVal index As Int32, ByVal redraw As Boolean)
    With _BarMenuInfos
      Dim list = .Items.ToList

      If list.Count > 0 Then
        list.RemoveAt(index)
        .Items = list.ToArray

        If .SelectedIndex > .Items.Count - 1 Then
          .SelectedIndex = .Items.Count - 1
        End If
      End If

      If Not redraw Then Exit Sub

      Me.ClearMenu()
      GetLargestItem()
      ShowMenu()
    End With
  End Sub

  Public Sub Clear()
    Clear(False)
  End Sub

  Public Sub Clear(ByVal redraw As Boolean)
    With _BarMenuInfos
      Dim list = .Items.ToList
      list.Clear()
      .Items = list.ToArray
      .SelectedIndex = -1

      If Not redraw Then Exit Sub

      Me.ClearMenu()
      GetLargestItem()
      ShowMenu()
    End With
  End Sub

  Public Overridable Function ShowMenu() As DialogResults
    Dim visible = Console.CursorVisible
    Console.CursorVisible = False

    With _BarMenuInfos

      SetCurrentWithAndBounds()

      If _Border Then
        Dim borderSettings = New BorderSettings
        borderSettings.Bounds = _Bounds
        borderSettings.ColorSet = .ColorSet
        Tools.DrawBorder(borderSettings)

        'Tools.DrawBorder(_Bounds, .ColorSet.BorderColor, .ColorSet.BackColor)
      End If

      If .SelectedIndex > .VisibleItems - 1 Then
        _FirstItemIndex = .SelectedIndex - (.VisibleItems - 1)
      Else
        _FirstItemIndex = 0
      End If
      If .Items.Count > 0 Then DrawMenu()

      Dim infoLineString = ""

      Dim key As ConsoleKeyInfo
      Do
        Select Case .Items.Count
        Case 0
          infoLineString = "0/0"
       Case Else
          infoLineString = (.SelectedIndex + 1).ToString & "/" & .Items.Count.ToString
        End Select
        PrintInfoLine(infoLineString)

        key = Console.ReadKey(True)
        MenuAction(key)
      Loop Until (key.Key = ConsoleKey.Enter) _
      OrElse (key.Key = ConsoleKey.Escape) _
      OrElse (_ExitArgs.ExitBarMenu)

      Console.CursorVisible = visible

      ClearMenu()

      Select Case True
      Case _ExitArgs.ExitBarMenu
        Return _ExitArgs.ReturnDialogResult
      Case key.Key = ConsoleKey.Enter
        Return DialogResults.OK
      Case key.Key = ConsoleKey.Escape
        Return DialogResults.Cancel
      End Select
    End With
  End Function
#End Region 'Öffentliche Methoden der Klasse}

End Class

End Namespace


