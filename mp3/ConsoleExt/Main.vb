Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Controls

Module Main

  Sub Main()
    For i = 0 To 60
      WriteXY(".", i, 1)
    Next

    WriteXY("1", 0, 0)
    WriteXY("|", 0, 1)

    WriteXY("10", 9, 0)
    WriteXY("|", 9, 1)

    WriteXY("20", 19, 0)
    WriteXY("|", 19, 1)

    WriteXY("30", 29, 0)
    WriteXY("|", 29, 1)

    WriteXY("40", 39, 0)
    WriteXY("|", 39, 1)

    WriteXY("50", 49, 0)
    WriteXY("|", 49, 1)

    WriteXY(",", 4, 1)
    WriteXY(",", 14, 1)
    WriteXY(",", 24, 1)
    WriteXY(",", 34, 1)
    WriteXY(",", 44, 1)
    WriteXY(",", 54, 1)


    Dim s = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    's = "Bert"
    Dim bmi = New SSP.ConsoleExt.BarMenus.BarMenuInfos(New String() {s, s, s, s, s}, 0, 0, 2, 4)
    Dim cbm = New SSP.ConsoleExt.BarMenus.CheckBarMenu(Of String)(bmi)

    cbm.ShowMenu()

  End Sub

End Module
