Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class ColorControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
  Private Enum ColorCommands
    UseColorSchema = 0
    ChangeBorderColor = 1
    ChangeForeColor = 2
    ChangeBackColor = 3
    ChangeSelectionForeColor = 4
    ChangeSelectionBackColor = 5
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _ColorSchemas As New Dictionary(Of String, SSP.ConsoleExt.ColorSet)
  Private _ColorPreview As SSP.ConsoleExt.Controls.ConsoleMessageBox
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
    InitializeColorSchemas()
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3ConsoleControl.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onColorSchemaPreviewItemChanged _
  (ByVal sender As Object _
  , ByVal e As BarMenuItemChangedEventArgs(Of String))

    Dim bm = DirectCast(sender, SSP.ConsoleExt.BarMenus.BarMenu(Of String))

    Dim x = bm.Bounds.x + bm.Bounds.Width + 1
    Dim y = bm.Bounds.y
    Dim w = x + 35

    _ColorPreview = New SSP.ConsoleExt.Controls.ConsoleMessageBox _
    ("Vorschau", New String() {"Farbschema '" & e.Item & "'"} _
    , x, y, w, _ColorSchemas.Item(e.Item))

    _ColorPreview.ShowMessage(ConsoleExt.MessageBoxTypes.InfoBox)
  End Sub

  Private Sub onMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.F1
      e.ExitBarMenu = True
      e.ReturnDialogResult = Nothing
      ClearWindow(DirectCast(sender _
      , BarMenu(Of BarMenuDefaultItem(Of ColorCommands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.UseColorSchema)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.ChangeBorderColor)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.ChangeForeColor)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.ChangeBackColor)
    Case ConsoleKey.F6
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.ChangeSelectionForeColor)
    Case ConsoleKey.F7
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of ColorCommands)(Nothing, Nothing, ColorCommands.ChangeSelectionBackColor)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub InitializeColorSchemas()
    _ColorSchemas.Add("Black Shadow" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.Black _
    , .ForeColor = ConsoleColor.DarkGreen _
    , .BorderColor = ConsoleColor.DarkCyan _
    , .SelectionBackColor = ConsoleColor.Red _
    , .SelectionForeColor = ConsoleColor.Yellow})

    _ColorSchemas.Add("SSI Tibute" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.Black _
    , .ForeColor = ConsoleColor.Green _
    , .BorderColor = ConsoleColor.DarkGray _
    , .SelectionBackColor = ConsoleColor.White _
    , .SelectionForeColor = ConsoleColor.Black})

    _ColorSchemas.Add("Turbo Pascal" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.DarkBlue _
    , .ForeColor = ConsoleColor.White _
    , .BorderColor = ConsoleColor.White _
    , .SelectionBackColor = ConsoleColor.Cyan _
    , .SelectionForeColor = ConsoleColor.Black})

    _ColorSchemas.Add("Norton Commander" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.DarkBlue _
    , .ForeColor = ConsoleColor.Cyan _
    , .BorderColor = ConsoleColor.Cyan _
    , .SelectionBackColor = ConsoleColor.DarkCyan _
    , .SelectionForeColor = ConsoleColor.Black})

    _ColorSchemas.Add("Prompt" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.Black _
    , .ForeColor = ConsoleColor.Gray _
    , .BorderColor = ConsoleColor.Gray _
    , .SelectionBackColor = ConsoleColor.Gray _
    , .SelectionForeColor = ConsoleColor.Black})

    _ColorSchemas.Add("DOS Shell" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.White _
    , .ForeColor = ConsoleColor.Black _
    , .BorderColor = ConsoleColor.Black _
    , .SelectionBackColor = ConsoleColor.Black _
    , .SelectionForeColor = ConsoleColor.White})

    _ColorSchemas.Add("Retro Blue" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.DarkBlue _
    , .ForeColor = ConsoleColor.Yellow _
    , .BorderColor = ConsoleColor.Gray _
    , .SelectionBackColor = ConsoleColor.DarkYellow _
    , .SelectionForeColor = ConsoleColor.Blue})

   _ColorSchemas.Add("Retro Yellow" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.Black _
    , .ForeColor = ConsoleColor.Yellow _
    , .BorderColor = ConsoleColor.DarkYellow _
    , .SelectionBackColor = ConsoleColor.DarkYellow _
    , .SelectionForeColor = ConsoleColor.Black})

    _ColorSchemas.Add("Prompt Invert" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.Gray _
    , .ForeColor = ConsoleColor.Black _
    , .BorderColor = ConsoleColor.Black _
    , .SelectionBackColor = ConsoleColor.Black _
    , .SelectionForeColor = ConsoleColor.Gray})

    _ColorSchemas.Add("Coma Tunnel" _
    , New SSP.ConsoleExt.ColorSet With _
    {.BackColor = ConsoleColor.DarkCyan _
    , .ForeColor = ConsoleColor.DarkBlue _
    , .BorderColor = ConsoleColor.Black _
    , .SelectionBackColor = ConsoleColor.Magenta _
    , .SelectionForeColor = ConsoleColor.White})
  End Sub

  Private Sub SelectColorSchema()

    Dim bmi = New BarMenuInfos(_ColorSchemas.Keys.ToArray _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of String)(bmi)
    AddHandler bm.ItemChanged, AddressOf onColorSchemaPreviewItemChanged

    Select Case bm.ShowMenu()
    Case ConsoleExt.DialogResults.OK
      Dim colorset = _ColorSchemas.Item(bm.Value)
      My.Settings.BackColor = colorset.BackColor
      Me.MP3Console.Colors.BackColor = colorset.BackColor
      My.Settings.ForeColor = colorset.ForeColor
      Me.MP3Console.Colors.ForeColor = colorset.ForeColor
      My.Settings.BorderColor = colorset.BorderColor
      Me.MP3Console.Colors.BorderColor = colorset.BorderColor
      My.Settings.SelectionBackColor = colorset.SelectionBackColor
      Me.MP3Console.Colors.SelectionBackColor = colorset.SelectionBackColor
      My.Settings.SelectionForeColor = colorset.SelectionForeColor
      Me.MP3Console.Colors.SelectionForeColor = colorset.SelectionForeColor
      My.Settings.Save()
      Me.MP3console.MenuDrawing.DrawMainBorder()
    End Select
    _ColorPreview.ClearMessageBox()
  End Sub

  Private Sub ChangeColor(ByVal command As ColorCommands)
    Dim cp As New ColorPicker(2, 4, Me.MP3Console.Colors)
    Me.MP3console.MenuDrawing.DrawMainBorder()
    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Farbverwaltung")
    WriteXY("Bitte neuen Farbwert wählen!", 2, 2, Me.MP3Console.Colors)

    Select Case command
    Case ColorCommands.ChangeBorderColor
      WriteXY("Rahmenfarbe", 2, 1, Me.MP3Console.Colors)
      If cp.SelectColor = ConsoleExt.DialogResults.OK Then
        Me.MP3Console.Colors.BorderColor = cp.SelectedColor
        My.Settings.BorderColor = cp.SelectedColor
      End If
    Case ColorCommands.ChangeForeColor
      WriteXY("Schriftfarbe", 2, 1, Me.MP3Console.Colors)
      If cp.SelectColor = ConsoleExt.DialogResults.OK Then
        Me.MP3Console.Colors.ForeColor = cp.SelectedColor
        My.Settings.ForeColor = cp.SelectedColor
      End If
    Case ColorCommands.ChangeBackColor
      WriteXY("Hintergrundfarbe", 2, 1, Me.MP3Console.Colors)
      If cp.SelectColor = ConsoleExt.DialogResults.OK Then
        Me.MP3Console.Colors.BackColor = cp.SelectedColor
        My.Settings.BackColor = cp.SelectedColor
      End If
    Case ColorCommands.ChangeSelectionForeColor
      WriteXY("Auswahlschriftfarbe", 2, 1, Me.MP3Console.Colors)
      If cp.SelectColor = ConsoleExt.DialogResults.OK Then
        Me.MP3Console.Colors.SelectionForeColor = cp.SelectedColor
        My.Settings.SelectionForeColor = cp.SelectedColor
      End If
    Case ColorCommands.ChangeSelectionBackColor
      WriteXY("Auswahlhintergrundfarbe", 2, 1, Me.MP3Console.Colors)
      If cp.SelectColor = ConsoleExt.DialogResults.OK Then
        Me.MP3Console.Colors.SelectionBackColor = cp.SelectedColor
        My.Settings.SelectionBackColor = cp.SelectedColor
      End If
    End Select
    My.Settings.Save()
    Me.MP3console.MenuDrawing.DrawMainBorder()
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of ColorCommands)() _
    {New BarMenuDefaultItem(Of ColorCommands) _
    ("Farbschema verwenden           (F2)", Nothing, ColorCommands.UseColorSchema) _
    , New BarMenuDefaultItem(Of ColorCommands) _
    ("Rahmenfarbe ändern             (F3)", Nothing, ColorCommands.ChangeBorderColor) _
    , New BarMenuDefaultItem(Of ColorCommands) _
    ("Schriftfarbe ändern            (F4)", Nothing, ColorCommands.ChangeForeColor) _
    , New BarMenuDefaultItem(Of ColorCommands) _
    ("Hintergrundfarbe ändern        (F5)", Nothing, ColorCommands.ChangeBackColor) _
    , New BarMenuDefaultItem(Of ColorCommands) _
    ("Auswahlschriftfarbe ändern     (F6)", Nothing, ColorCommands.ChangeSelectionForeColor) _
    , New BarMenuDefaultItem(Of ColorCommands) _
    ("Auswahlhintergrundfarbe ändern (F7)", Nothing, ColorCommands.ChangeSelectionBackColor)} _
    , 2, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of ColorCommands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed

    bm.Border = False
    Dim result As SSP.ConsoleExt.DialogResults

    Do
      Me.MP3Console.MenuDrawing.DrawTitleInformationBox()

      Dim borderSettings = New BorderSettings
      borderSettings.X = 1
      borderSettings.Y = 9
      borderSettings.X2 = 40
      borderSettings.Y2 = 21
      borderSettings.ForeColor = Me.MP3Console.Colors.BorderColor
      borderSettings.BackColor = Me.MP3Console.Colors.BackColor
      DrawBorder(borderSettings)

      'DrawBorder(1, 9, 40, 21 _
      ', Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)

      WriteXY("■", 2, 11, Me.MP3Console.Colors.BorderColor, Me.MP3Console.Colors.BackColor)
      WriteXY("■", 2, 12, Me.MP3Console.Colors.ForeColor, Me.MP3Console.Colors.BackColor)
      WriteXY("■", 2, 13, Me.MP3Console.Colors.BackColor, Me.MP3Console.Colors.BackColor)
      WriteXY("■", 2, 14, Me.MP3Console.Colors.SelectionForeColor, Me.MP3Console.Colors.BackColor)
      WriteXY("■", 2, 15, Me.MP3Console.Colors.SelectionBackColor, Me.MP3Console.Colors.BackColor)

      Me.MP3Console.MenuDrawing.DrawMenuFooter("Menü Farbverwaltung")
      result = bm.ShowMenu
      If result = ConsoleExt.DialogResults.OK Then
        If bm.Value IsNot Nothing Then
          Select Case bm.Value.Object
          Case ColorCommands.UseColorSchema
            SelectColorSchema()
          Case Else
            ChangeColor(bm.Value.Object)
          End Select
        End If
      End If

    Loop Until result = ConsoleExt.DialogResults.Cancel
    ClearWindow(1, 9, 40, 21, Me.MP3Console.Colors.BackColor)
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
