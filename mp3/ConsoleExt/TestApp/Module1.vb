﻿Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.Tools

Module Module1

  Sub Main()

    Console.BackgroundColor = ConsoleColor.Red
    Console.Clear()
    Console.BackgroundColor = ConsoleColor.Green

    'Dim settingsBoxBounds = New DialogBounds(0, 0, 10, 10)

    'Dim settings = New HeaderBorderSettings
    'settings.X = 0
    'settings.Y = 0
    'settings.X2 = 10
    'settings.Y2 = 10
    'settings.HeaderText = "Hallo"
    ''settings.Bounds = settingsBoxBounds
    'settings.ForeColor = ConsoleColor.Yellow
    'settings.BackColor = ConsoleColor.Blue
    'DrawHeaderBorder(settings)

    Dim ib = New Controls.ConsoleInputBox(Of String) _
    ("Title", "prompt", 0, 0, 30)
    ib.ShowDialog()


    DrawRulerHorizontal(0, 5, 60)
    DrawRulerVertical(5, 0, 20)

    Console.ReadKey()
  End Sub

End Module
