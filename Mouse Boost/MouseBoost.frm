VERSION 5.00
Begin VB.Form frmMain 
   BackColor       =   &H00000000&
   BorderStyle     =   1  'Fest Einfach
   Caption         =   "Olli-Buster"
   ClientHeight    =   2610
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3855
   ClipControls    =   0   'False
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   24
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "MouseBoost.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   MousePointer    =   1  'Pfeil
   ScaleHeight     =   174
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   257
   StartUpPosition =   2  'Bildschirmmitte
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2220
      Left            =   0
      MousePointer    =   1  'Pfeil
      TabIndex        =   2
      Top             =   0
      Width           =   3855
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Start"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   0
      MousePointer    =   1  'Pfeil
      TabIndex        =   4
      Top             =   2235
      Width           =   1095
   End
   Begin VB.TextBox Text1 
      Alignment       =   2  'Zentriert
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   2160
      MousePointer    =   3  'I-Cursor
      TabIndex        =   3
      Text            =   "-noname-"
      Top             =   2235
      Width           =   1695
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   1080
      Top             =   2880
   End
   Begin VB.Label Label2 
      Caption         =   "Name =>"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1320
      MousePointer    =   1  'Pfeil
      TabIndex        =   6
      Top             =   2310
      Width           =   855
   End
   Begin VB.Label Label4 
      Height          =   735
      Left            =   0
      MousePointer    =   1  'Pfeil
      TabIndex        =   5
      Top             =   1920
      Width           =   3975
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "Name =>"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1680
      TabIndex        =   1
      Top             =   3360
      Width           =   855
   End
   Begin VB.Label Label1 
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   1335
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'APIS
Private Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
Private Declare Function IntersectRect Lib "user32" (lpDestRect As RECT, lpSrc1Rect As RECT, lpSrc2Rect As RECT) As Long

'=== DirectDraw-Initialisations-Variablen ===
Dim DX7 As New DirectX7
Dim DD7 As DirectDraw7
Dim SurfaceDesc As DDSURFACEDESC2
Dim PrimarySurface As DirectDrawSurface7
Dim BackBuffer As DirectDrawSurface7
Dim ddPF As DDPIXELFORMAT
Dim back As DirectDrawSurface7
Dim front As DirectDrawSurface7
Dim enemy As DirectDrawSurface7
Dim deadenemy As DirectDrawSurface7
Dim superenemy As DirectDrawSurface7
Dim gun As DirectDrawSurface7
Dim blood As DirectDrawSurface7
Dim patrone As DirectDrawSurface7
Dim menue As DirectDrawSurface7
Dim SrcColorKey As Integer

'Performance und Runtime
Dim running As Boolean
Dim FPSCounter As Single
Dim FPS As Single
Dim FPSTickLast As Long

'Typen Deklaration
Private Type TGegner
 Lebendig As Boolean
 moving As Boolean
 PosX As Integer
 PosY As Integer
 Richtung As Integer
 phase As Integer
 Speed As Integer
 aktivitaet As Integer
 boost As Integer
 dead As Integer
 god As Boolean
End Type

Private Type TBlut
 aktiv As Boolean
 X As Integer
 Y As Integer
 grafik As Integer
 index As Integer
End Type

Private Type messaging
 X As Integer
 Y As Integer
 text As String
 aktiv As Boolean
 dauer As Integer
 mode As Integer
End Type

'************************
Const maxmause = 27
'************************
Const Version = "1.11"
'************************

'Spiel Variablen
Dim aktiv As Boolean
Dim Gegner(maxmause) As TGegner
Dim loch(200) As TBlut
Dim blut(maxmause) As TBlut
Dim gore(maxmause) As TBlut
Dim anzeige(10) As messaging
Dim mx As Integer
Dim my As Integer
Dim EditMode As Boolean
Dim anfangen As Boolean

Dim belebt As Integer
Dim belAct As Integer
Dim belTimer As Integer
Dim rate As Integer
Dim Toleranz As Integer
Dim Streuung As Integer
Dim punkte As Long
Dim zeit As Integer
Dim start As Long
Dim kills As Integer
Dim ammo As Integer
Dim multikill As Integer
Dim killtime As Long
Dim lastkill As Integer
Dim rambo As Boolean
Dim rwert As Long
Dim Plage As Integer
Dim angst As Integer
Dim maxspeed As Integer
Dim alki As Boolean
Dim ScoreSizer As Integer
Dim sniper As Integer
Dim sniperall As Integer
Dim bonus As Integer
Dim sog As Integer
Dim zaehler As Integer
Dim special As Boolean

'Highscore Variablen
Dim highname1 As String
Dim highscore1 As String
Dim highname2 As String
Dim highscore2 As String
Dim highname3 As String
Dim highscore3 As String
Dim cheating As Boolean
Dim Vnummer As String

Private Sub Command1_Click()
 anfangen = True
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
 'Wenn Escape gedrückt wird dann Spiel beenden
 If KeyCode = vbKeyEscape Then
    If Not aktiv Then running = False
    If aktiv Then aktiv = False: zaehler = 0
 End If
End Sub

Private Sub Form_Load()

On Error GoTo beenden

  Me.Show                        'Form anzeigen
  Me.Refresh
  
  EditMode = False
  cheating = False

head:
  
  List1.Clear                    ' Listobjekt leeren
  SaveScore                      ' Highscore laden

  'Highscore anzeigen und warten auf Klick Ereignis
  If Not cheating Then
   List1.AddItem "Highscore"
   List1.AddItem "---------------------------------------------------------------------"
   List1.AddItem "1.     " & highname1 & String(15 - Len(highname1), " ") & highscore1
   List1.AddItem "2.     " & highname2 & String(15 - Len(highname2), " ") & highscore2
   List1.AddItem "3.     " & highname3 & String(15 - Len(highname3), " ") & highscore3
  End If
  If cheating Then
   List1.AddItem "Die Highscore enthält einen"
   List1.AddItem "Fehler! Geben sie mb_reset ein"
   List1.AddItem "um sie neu zu erstellen !"
  End If
  List1.AddItem "---------------------------------------------------------------------"
  
anfang:

  Do
   DoEvents
  Loop Until anfangen = True
  
  'Parameter Abfrage
  If Text1.text = "mb_edmode" Then EditMode = True: anfangen = False
  If Text1.text = "mb_reset" Then punkte = 500: Text1.text = "-noname-": SaveScore: anfangen = False: punkte = 0: List1.Clear: GoTo head
  If Text1.text = "-noname-" Then List1.AddItem "Enter your name !": anfangen = False: GoTo anfang

  'Wenn Highscore verändert wurde dann nicht starten
  If cheating Then GoTo anfang

  'bischen warten
  Dim d As Long
  List1.AddItem "Loading..."
  d = 0
  Do
   DoEvents
   d = d + 1
  Loop Until d = 150000
    
 'Objekte verstecken
  List1.Visible = False
  Text1.Visible = False
  Text1.Enabled = False
  Command1.Visible = False
  Label1.Visible = False
  Label2.Visible = False
  Label3.Visible = False
  Label4.Visible = False
  Label4.Enabled = False
  List1.Enabled = False
  Command1.Enabled = False
  Label1.Enabled = False
  Label2.Enabled = False
  Label3.Enabled = False
  
  Initialization               'DirectDraw initialisieren
  BitmapLaden                  'Laden der Bitmaps
  
  running = True               'Das Programm läuft..
  maus (0)                     'Cursor verstecken
  newgame                      'Neues Spiel starten
    
  Do
   If Not Text1.Enabled Then
    mainloop
    PrimarySurface.Flip Nothing, DDFLIP_WAIT          'Flippen
    ClearBuffer vbBlack                               'Backbuffer löschen
   'Berechnung der Frames per Second
        If FPSCounter = 30 And EditMode Then
            If FPSTickLast <> 0 Then FPS = 1000 * 30 / (GetTime - FPSTickLast) + 1
            FPSTickLast = GetTime
            FPSCounter = 0
        End If
        FPSCounter = FPSCounter + 1
  End If
    DoEvents                                          'Events zulassen
  Loop While running
  
beenden:
   TERMINATE                                          'Beenden

End Sub

Private Sub newgame()
Dim i As Integer
  
'Sprites löschen (loch\gore\blut\anzeige..)
For i = 0 To maxmause
 Gegner(i).Lebendig = False
 gore(i).aktiv = False
 blut(i).aktiv = False
Next i

For i = 0 To 200
 loch(i).aktiv = False
Next i

For i = 0 To 10
 anzeige(i).aktiv = False
Next i
  
'Variablen auf ihren Default Wert setzen..
  bonus = 0
  Toleranz = 0
  punkte = 0
  zeit = 60
  start = Timer
  kills = 0
  belebt = 0
  ammo = 8
  Streuung = 10
  Plage = 4
  ScoreSizer = 1
  aktiv = False
  alki = False
  CreateMice
  angst = 3
  maxspeed = 4
  Timer1.Interval = 100
  sog = False
  alki = False
  rambo = False

End Sub

Private Sub beleben()
'Hier werden die Mäuse belebt
Dim i As Integer
Dim ii As Integer

   For i = 1 To maxmause
    If Gegner(i).Lebendig = False Then
     With Gegner(i)     'wiederbeleben
       For ii = 0 To maxmause
        If blut(ii).aktiv = True Then blut(ii).aktiv = False: GoTo gefunden
       Next ii
gefunden:
       Randomize
       .Lebendig = True
       .moving = True
       .phase = 10
       .Richtung = 1 + Int(Rnd * 7)
       Randomize
       .Speed = Int(Rnd * 4) + 1
       .aktivitaet = 80 - Int(Rnd * 60)
       belebt = belebt + 1
       .dead = True
       .god = False
       Randomize
       ii = Int(Rnd * 27)
       If ii = 7 Then
         .god = True
         .aktivitaet = 30
         .Speed = 5
       End If
       GoTo belebt
      End With
    End If
   Next i

belebt:

End Sub


Private Sub mainloop()
  Dim SrcRect As RECT
  Dim i As Integer
  Dim row As Integer
  Dim line As Integer
  
If Text1.Visible = False Then
'Hintergrundbild zeichnen
    With SrcRect
      .Left = 0: .Right = 1024
      .Top = 0: .Bottom = 768
    End With
    BackBuffer.BltFast 0, 0, back, SrcRect, DDBLTFAST_WAIT
End If

If aktiv Then

'Einschusslöcher zeichnen
For i = 0 To 200
 If loch(i).aktiv Then
   With SrcRect
         .Left = 0: .Right = 10
         .Top = 0: .Bottom = 10
   End With
   BackBuffer.BltFast loch(i).X - 5, loch(i).Y - 5, gun, SrcRect, DDBLTFAST_WAIT Or 1
 End If
Next i
    
'Blut zeichnen
For i = 0 To maxmause
 If blut(i).aktiv Then
   With SrcRect
         .Left = (48 * blut(i).grafik) - 48: .Right = (48 * blut(i).grafik)
         .Top = 0: .Bottom = 48
   End With
   BackBuffer.BltFast blut(i).X - 15, blut(i).Y - 15, blood, SrcRect, DDBLTFAST_WAIT Or 1
 End If
Next i

'mause bewegen
 Enemy_KI

'Mäuse zeichnen
  For i = 0 To maxmause
    If Gegner(i).Lebendig Then
        If Gegner(i).Richtung = 1 Then row = 1: line = CLng(Gegner(i).phase / 10)
        If Gegner(i).Richtung = 2 Then row = 2: line = CLng(Gegner(i).phase / 10) + 3
        If Gegner(i).Richtung = 3 Then row = 2: line = CLng(Gegner(i).phase / 10)
        If Gegner(i).Richtung = 4 Then row = 4: line = CLng(Gegner(i).phase / 10) + 3
        If Gegner(i).Richtung = 5 Then row = 3: line = CLng(Gegner(i).phase / 10)
        If Gegner(i).Richtung = 6 Then row = 3: line = CLng(Gegner(i).phase / 10) + 3
        If Gegner(i).Richtung = 7 Then row = 4: line = CLng(Gegner(i).phase / 10)
        If Gegner(i).Richtung = 8 Then row = 1: line = CLng(Gegner(i).phase / 10) + 3
        With SrcRect
          .Left = (line * 48) - 48: .Right = line * 48
          .Top = (row * 48) - 48: .Bottom = row * 48
        End With
     If Gegner(i).dead = False Then
       BackBuffer.BltFast Gegner(i).PosX, Gegner(i).PosY, enemy, SrcRect, DDBLTFAST_WAIT Or 1
     End If
     If Gegner(i).dead Then
       BackBuffer.BltFast Gegner(i).PosX, Gegner(i).PosY, deadenemy, SrcRect, DDBLTFAST_WAIT Or 1
     End If
     If Gegner(i).dead And Gegner(i).god Then
       BackBuffer.BltFast Gegner(i).PosX, Gegner(i).PosY, superenemy, SrcRect, DDBLTFAST_WAIT Or 1
     End If
    End If
  Next i
  
'Blutanimation per Zufall berechnen
'(Muss noch verändert werden , da jetzt noch Kreise für das Blut gezeichnet werden
' und das hier mit SetLockedPixel besser zu lösen wäre...)
If belAct <> 0 Then
BackBuffer.SetForeColor vbRed
BackBuffer.DrawCircle Gegner(belAct).PosX - 1 - belTimer, Gegner(belAct).PosY - 1, 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 1 + belTimer, Gegner(belAct).PosY + 1, 1
BackBuffer.DrawCircle Gegner(belAct).PosX - 1, Gegner(belAct).PosY + 1 + belTimer, 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 1 + belTimer, Gegner(belAct).PosY - 24, 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 48 + belTimer, Gegner(belAct).PosY + 48, 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 48, Gegner(belAct).PosY + 48 + belTimer, 1
BackBuffer.DrawCircle Gegner(belAct).PosX - 2 + belTimer, Gegner(belAct).PosY + 48, 1
For i = 0 To 2
Randomize
BackBuffer.DrawCircle Gegner(belAct).PosX + 48 + Int(Rnd * 5), Gegner(belAct).PosY + 3 + belTimer, 1
BackBuffer.DrawCircle Gegner(belAct).PosX - 2 - belTimer, Gegner(belAct).PosY + 6 + Int(Rnd * 10), 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 48 + Int(Rnd * 5), Gegner(belAct).PosY + belTimer, 1
BackBuffer.DrawCircle Gegner(belAct).PosX + 48 + Int(Rnd * 10), Gegner(belAct).PosY + 24 + Int(Rnd * 5) + belTimer, 1
Randomize
BackBuffer.DrawCircle Gegner(belAct).PosX - belTimer + Int(Rnd * 68), Gegner(belAct).PosY - belTimer + Int(Rnd * 68), 1
BackBuffer.DrawCircle Gegner(belAct).PosX - belTimer + Int(Rnd * 68), Gegner(belAct).PosY - belTimer + Int(Rnd * 68), 1
BackBuffer.DrawCircle Gegner(belAct).PosX - belTimer + Int(Rnd * 68), Gegner(belAct).PosY - belTimer + Int(Rnd * 68), 1
BackBuffer.DrawCircle Gegner(belAct).PosX - belTimer + Int(Rnd * 68), Gegner(belAct).PosY - belTimer + Int(Rnd * 68), 1
Next i
belTimer = belTimer + 1
If belTimer = 40 Then belAct = 0 And belTimer = 0
End If
End If
  
If aktiv = True Or zaehler <> 0 Then
zaehler = zaehler - 1
'anzeige zeichnen
 For i = 0 To 10
  anzeige(i).Y = anzeige(i).Y - 1
  If anzeige(i).aktiv = True Then
    BackBuffer.SetForeColor vbWhite
    BackBuffer.DrawText anzeige(i).X - 1, anzeige(i).Y - 1, anzeige(i).text, False
    If anzeige(i).mode = 2 Then
     BackBuffer.SetForeColor &H808000
    End If
    If anzeige(i).mode = 1 Then
     BackBuffer.SetForeColor &H80&
    End If
    If anzeige(i).mode = 0 Then
     BackBuffer.SetForeColor vbRed
    End If
    BackBuffer.DrawText anzeige(i).X, anzeige(i).Y, anzeige(i).text, False
  End If
 Next i
End If

'Menü zeichnen
If aktiv = False And zaehler = 0 Then
 If Not aktiv Then
   With SrcRect
        .Left = 0: .Right = 487
        .Top = 0: .Bottom = 93
   End With
   BackBuffer.BltFast 260, 470, menue, SrcRect, DDBLTFAST_WAIT
 End If
End If
  
BackBuffer.SetFont Label1.Font
     
'Frames per Second und EditMode anzeige...
  If EditMode Then
    BackBuffer.SetForeColor vbWhite
    BackBuffer.DrawText 10, 20, "FramesPS   : " & Format(FPS, "0.0"), False
    BackBuffer.DrawText 10, 30, "mx         : " & mx, False
    BackBuffer.DrawText 10, 40, "my         : " & my, False
    BackBuffer.DrawText 10, 50, "KillsPS    : " & multikill, False
    BackBuffer.DrawText 10, 60, "LastPoint  : " & lastkill, False
    BackBuffer.DrawText 10, 70, "multikill  : " & multikill, False
    BackBuffer.DrawText 10, 80, "Munition   : " & ammo, False
    BackBuffer.DrawText 10, 90, "Zeit       : " & (Timer - start), False
    BackBuffer.DrawText 10, 100, "Streuung  : " & Streuung, False
    BackBuffer.DrawText 10, 110, "MunitionXL: " & rambo, False
    BackBuffer.DrawText 10, 120, "Alkimode  : " & alki, False
    BackBuffer.DrawText 10, 130, "MaxSpeed  : " & maxspeed, False
    BackBuffer.DrawText 10, 140, "Angst     : " & angst, False
    BackBuffer.DrawText 10, 150, "MaxMäuse  : " & maxmause, False
    BackBuffer.DrawText 10, 160, "Bonus     : " & bonus, False
    BackBuffer.DrawText 10, 170, "SplatterNr: " & belAct, False
    BackBuffer.DrawText 10, 180, "SplatterTi: " & belTimer, False
    BackBuffer.DrawText 10, 190, "Belebt    : " & belebt, False
    BackBuffer.DrawText 10, 200, "ToKill    : " & ((maxmause + 1 + belebt) - kills), False
    BackBuffer.DrawText 10, 210, "BonusPOSS : " & CLng(zeit * (punkte / 175)), False
  End If
    BackBuffer.SetForeColor &H404040
    BackBuffer.DrawText 825, 112, "v" & Version, False

If Text1.Enabled = False Then
'stats 3D
   If punkte < 0 Then punkte = 0
    BackBuffer.SetFont Me.Font
    BackBuffer.SetForeColor vbWhite
    BackBuffer.DrawText 211, 701, punkte, False
    BackBuffer.DrawText 481, 701, zeit, False
    BackBuffer.SetForeColor &HC0&
    BackBuffer.DrawText 480, 700, zeit, False
    BackBuffer.SetForeColor &H404040
    BackBuffer.DrawText 210, 700, punkte, False

      With SrcRect
          .Left = 5 * 48: .Right = 6 * 48
          .Top = 2 * 48: .Bottom = 3 * 48
      End With
      BackBuffer.BltFast 150, 690, enemy, SrcRect, DDBLTFAST_WAIT Or 1
  For i = 1 To ammo
        With SrcRect
          .Left = 0: .Right = 34
          .Top = 0: .Bottom = 56
        End With
       BackBuffer.BltFast 710 + (i * 20), 695, patrone, SrcRect, DDBLTFAST_WAIT Or 1
  Next i
    
 'alkoholeinfluss ....     (alkiMode = Fadenkreuz wackelt)
   If alki = True Then
    Randomize
    mx = mx + (2 - Int(Rnd * 5))
    my = my + (2 - Int(Rnd * 5))
   End If
    
 'Fadenkreuz zeichnen
    BackBuffer.SetForeColor vbBlack
    BackBuffer.setDrawWidth 2
    BackBuffer.DrawCircle mx, my, 10 + (Streuung - 10)
    BackBuffer.DrawCircle mx, my, 20 + (Streuung - 10)
    BackBuffer.DrawLine mx - 25 - (Streuung - 10), my, mx - 3, my
    BackBuffer.DrawLine mx + 3, my, mx + 25 + (Streuung - 10), my
    BackBuffer.DrawLine mx, my - 25 - (Streuung - 10), mx, my - 3
    BackBuffer.DrawLine mx, my + 3, mx, my + 25 + (Streuung - 10)
       
End If

'Mäuse wiederbeleben
rate = rate + Plage
If rate >= 500 Then beleben: rate = 0
    
End Sub

Private Sub CreateMice()
'Mäuse erstellen
Dim i As Integer
 For i = 0 To maxmause
  With Gegner(i)
     Randomize
     .Lebendig = True
     .moving = True
     .dead = False
     .god = False
     .phase = 10
     .PosX = 120 + Int(Rnd * 700)
     .PosY = 120 + Int(Rnd * 480)
     .Richtung = 1 + Int(Rnd * 7)
     Randomize
     .Speed = Int(Rnd * maxspeed) + 1
     .aktivitaet = 80 - Int(Rnd * 60)
  End With
  Next i
End Sub

Private Sub Enemy_KI()
'Hier steht die "Intelligenz" der Mäuse... ;-)
Dim i As Integer
Dim zfl As Integer

For i = 0 To maxmause
  If Gegner(i).Lebendig And Gegner(i).moving And aktiv Then
    With Gegner(i)
    
    'Zufallsänderung der Richtung
      Randomize
      zfl = Int(Rnd * .aktivitaet)
      If zfl = 4 Then .Richtung = .Richtung + Int(Rnd * 3)
      If zfl = 3 Then .Richtung = .Richtung - Int(Rnd * 3)
        If .Richtung > 8 Then .Richtung = 1
        If .Richtung < 1 Then .Richtung = 8
       
    'vor Fadenkreuz weglaufen...
    If Not sog Then
     If .PosY > 110 And .PosY < 590 And .PosY < my + 100 And .PosY > my And .PosX > mx - 25 And .PosX < mx + 25 Then .Richtung = 5: .boost = angst
     If .PosY > 110 And .PosY < 590 And .PosY < my And .PosY > my - 100 And .PosX > mx - 25 And .PosX < mx + 25 Then .Richtung = 1: .boost = angst
     If .PosX > 140 And .PosX < 810 And .PosX < mx + 100 And .PosX > mx And .PosY > my - 25 And .PosY < my + 25 Then .Richtung = 3: .boost = angst
     If .PosX > 140 And .PosX < 810 And .PosX < mx And .PosX > mx - 100 And .PosY > my - 25 And .PosY < my + 25 Then .Richtung = 7: .boost = angst
    End If
    If sog Then
     If .PosY > 110 And .PosY < 590 And .PosY < my + 100 And .PosY > my And .PosX > mx - 25 And .PosX < mx + 25 Then .Richtung = 1: .boost = angst
     If .PosY > 110 And .PosY < 590 And .PosY < my And .PosY > my - 100 And .PosX > mx - 25 And .PosX < mx + 25 Then .Richtung = 5: .boost = angst
     If .PosX > 140 And .PosX < 810 And .PosX < mx + 100 And .PosX > mx And .PosY > my - 25 And .PosY < my + 25 Then .Richtung = 7: .boost = angst
     If .PosX > 140 And .PosX < 810 And .PosX < mx And .PosX > mx - 100 And .PosY > my - 25 And .PosY < my + 25 Then .Richtung = 3: .boost = angst
    End If
    
    'Ränder nicht übertreten
      Randomize
      If .PosX > 830 Then .Richtung = 8 - Int(Rnd * 3)
      If .PosY > 610 Then .Richtung = 1 + Int(Rnd * 2)
      If .PosY < 90 Then .Richtung = 6 - Int(Rnd * 3)
      If .PosX < 120 Then .Richtung = 2 + Int(Rnd * 3)
      
     'Koordinaten verändern
      If .Richtung = 1 Then .PosY = .PosY - .Speed - .boost:   .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 2 Then .PosY = .PosY - .Speed - .boost: .PosX = .PosX + .Speed + .boost: .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 3 Then .PosX = .PosX + .Speed + .boost:  .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 4 Then .PosY = .PosY + .Speed + .boost: .PosX = .PosX + .Speed + .boost: .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 5 Then .PosY = .PosY + .Speed + .boost:  .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 6 Then .PosY = .PosY + .Speed + .boost: .PosX = .PosX - .Speed - .boost: .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 7 Then .PosX = .PosX - .Speed - .boost:  .phase = .phase + 1: If .phase = 30 Then .phase = 10
      If .Richtung = 8 Then .PosY = .PosY - .Speed - .boost: .PosX = .PosX - .Speed - .boost: .phase = .phase + 1: If .phase = 30 Then .phase = 10
    
      .boost = .boost - 1
      If .boost < 0 Then .boost = 0
    
    End With
  End If
Next i

End Sub

Sub Initialization()
'DirectX Initialisieren..
  Set DD7 = DX7.DirectDrawCreate("")
  DD7.SetCooperativeLevel Me.hWnd, DDSCL_EXCLUSIVE Or DDSCL_FULLSCREEN Or DDSCL_ALLOWREBOOT
  DD7.SetDisplayMode 1024, 768, 16, 0, DDSDM_DEFAULT
  With SurfaceDesc
    .lFlags = DDSD_CAPS Or DDSD_BACKBUFFERCOUNT
    .ddsCaps.lCaps = DDSCAPS_PRIMARYSURFACE Or DDSCAPS_FLIP Or DDSCAPS_COMPLEX
    .lBackBufferCount = 1
  End With
  Set PrimarySurface = DD7.CreateSurface(SurfaceDesc)
  SurfaceDesc.ddsCaps.lCaps = DDSCAPS_BACKBUFFER
  Set BackBuffer = PrimarySurface.GetAttachedSurface(SurfaceDesc.ddsCaps)
  PrimarySurface.GetPixelFormat ddPF
End Sub

Sub BitmapLaden()
'Bilder laden
  Dim BmpDesc As DDSURFACEDESC2
  Dim ColorKey As DDCOLORKEY
      
  BmpDesc.lFlags = DDSD_CAPS Or DDSD_HEIGHT Or DDSD_WIDTH
  BmpDesc.ddsCaps.lCaps = DDSCAPS_OFFSCREENPLAIN

  BmpDesc.lWidth = 1024
  BmpDesc.lHeight = 768
  Set back = DD7.CreateSurfaceFromFile(App.Path & "\scr\1.mb", BmpDesc)
  
  BmpDesc.lWidth = 288
  BmpDesc.lHeight = 192
  Set enemy = DD7.CreateSurfaceFromFile(App.Path & "\scr\7.mb", BmpDesc)
  
  BmpDesc.lWidth = 288
  BmpDesc.lHeight = 192
  Set deadenemy = DD7.CreateSurfaceFromFile(App.Path & "\scr\3.mb", BmpDesc)
  
  BmpDesc.lWidth = 288
  BmpDesc.lHeight = 192
  Set superenemy = DD7.CreateSurfaceFromFile(App.Path & "\scr\9.mb", BmpDesc)
  
  BmpDesc.lWidth = 10
  BmpDesc.lHeight = 10
  Set gun = DD7.CreateSurfaceFromFile(App.Path & "\scr\4.mb", BmpDesc)

  BmpDesc.lWidth = 240
  BmpDesc.lHeight = 48
  Set blood = DD7.CreateSurfaceFromFile(App.Path & "\scr\2.mb", BmpDesc)
  
  BmpDesc.lWidth = 34
  BmpDesc.lHeight = 56
  Set patrone = DD7.CreateSurfaceFromFile(App.Path & "\scr\8.mb", BmpDesc)
  
  BmpDesc.lWidth = 487
  BmpDesc.lHeight = 93
  Set menue = DD7.CreateSurfaceFromFile(App.Path & "\scr\6.mb", BmpDesc)
  
  ColorKey.high = vbWhite
  ColorKey.low = vbWhite
  
  'Ränder unsichtbar machen
  enemy.SetColorKey DDCKEY_SRCBLT, ColorKey
  deadenemy.SetColorKey DDCKEY_SRCBLT, ColorKey
  superenemy.SetColorKey DDCKEY_SRCBLT, ColorKey
  gun.SetColorKey DDCKEY_SRCBLT, ColorKey
  blood.SetColorKey DDCKEY_SRCBLT, ColorKey
  patrone.SetColorKey DDCKEY_SRCBLT, ColorKey
  
End Sub

Sub TERMINATE()
'Programm beenden..
  Set back = Nothing
  Set enemy = Nothing
  Set deadenemy = Nothing
  Set gun = Nothing
  Set blood = Nothing
  Set patrone = Nothing
  Set superenemy = Nothing
  DD7.RestoreDisplayMode
  DD7.SetCooperativeLevel Me.hWnd, DDSCL_NORMAL
  Set PrimarySurface = Nothing
  Set DD7 = Nothing
  Set DX7 = Nothing
  maus (1)
 '..und wieder in die Form
  Me.WindowState = 0
  Me.Width = 3945
  Me.Height = 2985
  List1.Visible = True
  Text1.Visible = True
  Text1.Enabled = True
  Command1.Visible = True
  Label1.Visible = True
  Label2.Visible = True
  Label3.Visible = True
  Label4.Visible = True
  Label4.Enabled = True
  List1.Enabled = True
  Command1.Enabled = True
  Label1.Enabled = True
  Label2.Enabled = True
  Label3.Enabled = True
  anfangen = False
  Call Form_Load
End Sub

Sub ClearBuffer(Color As Long)
'Bildschirm leeren
  Dim DestRect As RECT
  With DestRect
    .Bottom = 768
    .Left = 0
    .Right = 1024
    .Top = 0
  End With
  BackBuffer.BltColorFill DestRect, Color
End Sub

Function GetTime() As Long
  GetTime = DX7.TickCount
End Function

Sub maus(xx)
'Cursor ein\aus-schalten
If xx = 0 Then
 Dim rwert As Long
  Do
   rwert = ShowCursor(0)
  Loop Until rwert < 0
End If
If xx = 1 Then
  Do
   rwert = ShowCursor(1)
  Loop Until rwert > -1
End If
End Sub

Private Sub Form_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Dim i As Integer
Dim ii As Boolean
Dim iii As Integer
Dim aw As Boolean
Dim lk As Integer
Dim rectCenter As RECT
Dim rectMoving As RECT
Dim rectOverlap As RECT


If Not aktiv Then
'Klick menü abfragen
  If X > 300 And X < 460 And Y > 500 And Y < 540 Then newgame: aktiv = True
  If X > 530 And X < 660 And Y > 500 And Y < 540 Then TERMINATE
End If


If aktiv Then
'Mäuse killen..
 aw = False
 lastkill = 0

 If Button = vbLeftButton And ammo > 0 Then
   For i = 0 To maxmause
     If Gegner(i).Lebendig = True Then
         With rectCenter
                .Left = Gegner(i).PosX + Toleranz + 24
                .Right = Gegner(i).PosX + (48 - (Toleranz * 2))
                .Top = Gegner(i).PosY + Toleranz + 24
                .Bottom = Gegner(i).PosY + (48 - (Toleranz * 2))
            End With
            With rectMoving
                .Left = X - (20 - Toleranz) - Streuung
                .Right = X + (20 - Toleranz) + Streuung
                .Top = Y - (20 - Toleranz) - Streuung
                .Bottom = Y + (20 - Toleranz) + Streuung
            End With
     
        If IntersectRect(rectOverlap, rectCenter, rectMoving) Then
          Gegner(i).Lebendig = False
          ii = True
            belAct = i
            belTimer = 0
            '***********************************************************************
             lk = (8 + (Gegner(i).Speed ^ 2) * 2)  'Hier werden die Punkte berechnet
            '***********************************************************************
             If Gegner(i).dead Then lk = CLng(lk / 6)
             lk = lk * ScoreSizer
             If Gegner(i).god Then lk = 0: special = True
              punkte = punkte + lk
              lastkill = lastkill + lk
              kills = kills + 1
              sniper = sniper + 1
              If aw = False Then ammo = ammo - 1: aw = True
              multikill = multikill + 1
              If multikill = 1 Then killtime = Timer
          For iii = 0 To maxmause
            If blut(iii).aktiv = False Then
               blut(iii).X = Gegner(i).PosX + 20
               blut(iii).Y = Gegner(i).PosY + 20
               Randomize
               blut(iii).grafik = Int(Rnd * 5) + 1
               blut(iii).aktiv = True
               gore(iii).X = Gegner(i).PosX
               gore(iii).Y = Gegner(i).PosY
               Randomize
               gore(iii).grafik = Int(Rnd * 3) + 1
               gore(iii).index = Int(Rnd * 20) + 1
               gore(iii).aktiv = True
            GoTo weiter2
          End If
         Next iii
        End If
weiter2:
     End If
   Next i

     If lastkill <> 0 Then
         For iii = 0 To 10
            If anzeige(iii).aktiv = False Then
             punkte = punkte + CLng((lastkill / 100) * 5)
             anzeige(iii).text = lastkill + CLng((lastkill / 100) * 5)
             anzeige(iii).X = X
             anzeige(iii).Y = Y
             anzeige(iii).mode = 0
             anzeige(iii).aktiv = True
             anzeige(iii).dauer = 5
             GoTo weiter3
            End If
          Next iii
     End If
weiter3:

    If ii = False And ammo > 0 Then
     For i = 0 To 200
       If loch(i).aktiv = False Then
         If X < 900 And X > 110 And Y > 80 And Y < 650 Then
           loch(i).X = X
           loch(i).Y = Y
           loch(i).aktiv = True
           sniper = 0
           ammo = ammo - 1
           GoTo weiter
         End If
       End If
     Next i
    End If
  
weiter:
 If rambo = True Then ammo = 8
 End If

 If Button = vbRightButton And ammo = 0 Then
   punkte = punkte - 8
 ammo = 8
 End If
End If

End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
'Aktuelle Koordinaten in mx und my speichern
mx = X
my = Y
End Sub

Private Sub SaveScore()
'Hier werden die ersten drei in der Highscore gespeichert und die Highscore
'verschlüsselt
Dim schlussel1 As Integer
Dim zufall1 As Integer
Dim fletter1 As Integer
Dim schlussel2 As Integer
Dim zufall2 As Integer
Dim fletter2 As Integer
Dim schlussel3 As Integer
Dim zufall3 As Integer
Dim fletter3 As Integer
Dim Hversion As String
Dim lastname As String

Dim i As Integer
Dim q As Integer
Dim p As Integer

'einladen..
Open App.Path & "/score.dat" For Input As #1
  Input #1, lastname, Vnummer
  Input #1, highname1, highscore1, schlussel1, zufall1, fletter1
  Input #1, highname2, highscore2, schlussel2, zufall2, fletter2
  Input #1, highname3, highscore3, schlussel3, zufall3, fletter3
Close #1


If Text1.text = "-noname-" Then Text1.text = lastname

highscore1 = (highscore1 - 234) / 2
highscore2 = (highscore2 - 234) / 2
highscore3 = (highscore3 - 234) / 2

cheating = False

'Verschlüsseln
If Vnummer <> Version Then cheating = True
If schlussel1 <> ((((highscore1 - 450) * 3) - 33 - Asc(highname1)) Xor 33) + (Len(highname1) ^ 2) + (zufall1 - fletter1) Then cheating = True
If schlussel2 <> ((((highscore2 - 450) * 3) - 33 - Asc(highname2)) Xor 33) + (Len(highname2) ^ 2) + (zufall2 - fletter2) Then cheating = True
If schlussel3 <> ((((highscore3 - 450) * 3) - 33 - Asc(highname3)) Xor 33) + (Len(highname3) ^ 2) + (zufall3 - fletter3) Then cheating = True

'und schreiben...
If punkte > highscore1 Then
 highname3 = highname2
 highname2 = highname1
 highname1 = Text1.text
 highscore3 = highscore2
 highscore2 = highscore1
 highscore1 = punkte
 Randomize
 zufall1 = 255 + Int(Rnd * 300)
 zufall2 = 255 + Int(Rnd * 300)
 zufall3 = 255 + Int(Rnd * 300)
 fletter1 = Asc(highname1)
 fletter2 = Asc(highname2)
 fletter3 = Asc(highname3)
 schlussel1 = ((((highscore1 - 450) * 3) - 33 - Asc(highname1)) Xor 33) + (Len(highname1) ^ 2) + (zufall1 - fletter1)
 schlussel2 = ((((highscore2 - 450) * 3) - 33 - Asc(highname2)) Xor 33) + (Len(highname2) ^ 2) + (zufall2 - fletter2)
 schlussel3 = ((((highscore3 - 450) * 3) - 33 - Asc(highname3)) Xor 33) + (Len(highname3) ^ 2) + (zufall3 - fletter3)
  Open App.Path & "/score.dat" For Output As #1
   Write #1, Text1.text
   Write #1, Version
   Write #1, highname1
   Write #1, (highscore1 * 2) + 234
   Write #1, schlussel1
   Write #1, zufall1
   Write #1, fletter1
   Write #1, highname2
   Write #1, (highscore2 * 2) + 234
   Write #1, schlussel2
   Write #1, zufall2
   Write #1, fletter2
   Write #1, highname3
   Write #1, (highscore3 * 2) + 234
   Write #1, schlussel3
   Write #1, zufall3
   Write #1, fletter3
  Close #1
  GoTo gesichert
End If

If punkte > highscore2 Then
 highname3 = highname2
 highname2 = Text1.text
 highscore3 = highscore2
 highscore2 = punkte
 Randomize
 zufall1 = 255 + Int(Rnd * 300)
 zufall2 = 255 + Int(Rnd * 300)
 zufall3 = 255 + Int(Rnd * 300)
 fletter1 = Asc(highname1)
 fletter2 = Asc(highname2)
 fletter3 = Asc(highname3)
 schlussel1 = ((((highscore1 - 450) * 3) - 33 - Asc(highname1)) Xor 33) + (Len(highname1) ^ 2) + (zufall1 - fletter1)
 schlussel2 = ((((highscore2 - 450) * 3) - 33 - Asc(highname2)) Xor 33) + (Len(highname2) ^ 2) + (zufall2 - fletter2)
 schlussel3 = ((((highscore3 - 450) * 3) - 33 - Asc(highname3)) Xor 33) + (Len(highname3) ^ 2) + (zufall3 - fletter3)
  Open App.Path & "/score.dat" For Output As #1
   Write #1, Text1.text
   Write #1, Version
   Write #1, highname1
   Write #1, (highscore1 * 2) + 234
   Write #1, schlussel1
   Write #1, zufall1
   Write #1, fletter1
   Write #1, highname2
   Write #1, (highscore2 * 2) + 234
   Write #1, schlussel2
   Write #1, zufall2
   Write #1, fletter2
   Write #1, highname3
   Write #1, (highscore3 * 2) + 234
   Write #1, schlussel3
   Write #1, zufall3
   Write #1, fletter3
  Close #1
  GoTo gesichert
End If

If punkte > highscore3 Then
 highname3 = Text1.text
 highscore3 = punkte
 Randomize
 zufall1 = 255 + Int(Rnd * 300)
 zufall2 = 255 + Int(Rnd * 300)
 zufall3 = 255 + Int(Rnd * 300)
 fletter1 = Asc(highname1)
 fletter2 = Asc(highname2)
 fletter3 = Asc(highname3)
 schlussel1 = ((((highscore1 - 450) * 3) - 33 - Asc(highname1)) Xor 33) + (Len(highname1) ^ 2) + (zufall1 - fletter1)
 schlussel2 = ((((highscore2 - 450) * 3) - 33 - Asc(highname2)) Xor 33) + (Len(highname2) ^ 2) + (zufall2 - fletter2)
 schlussel3 = ((((highscore3 - 450) * 3) - 33 - Asc(highname3)) Xor 33) + (Len(highname3) ^ 2) + (zufall3 - fletter3)
  Open App.Path & "/score.dat" For Output As #1
   Write #1, Text1.text
   Write #1, Version
   Write #1, highname1
   Write #1, (highscore1 * 2) + 234
   Write #1, schlussel1
   Write #1, zufall1
   Write #1, fletter1
   Write #1, highname2
   Write #1, (highscore2 * 2) + 234
   Write #1, schlussel2
   Write #1, zufall2
   Write #1, fletter2
   Write #1, highname3
   Write #1, (highscore3 * 2) + 234
   Write #1, schlussel3
   Write #1, zufall3
   Write #1, fletter3
  Close #1
  GoTo gesichert
End If

If punkte = 500 Then
 highname3 = "-noname-"
 highname2 = "-noname-"
 highname1 = "-noname-"
 highscore3 = 500
 highscore2 = 600
 highscore1 = 700
 Randomize
 zufall1 = 255 + Int(Rnd * 300)
 zufall2 = 255 + Int(Rnd * 300)
 zufall3 = 255 + Int(Rnd * 300)
 fletter1 = Asc(highname1)
 fletter2 = Asc(highname2)
 fletter3 = Asc(highname3)
 schlussel1 = ((((highscore1 - 450) * 3) - 33 - Asc(highname1)) Xor 33) + (Len(highname1) ^ 2) + (zufall1 - fletter1)
 schlussel2 = ((((highscore2 - 450) * 3) - 33 - Asc(highname2)) Xor 33) + (Len(highname2) ^ 2) + (zufall2 - fletter2)
 schlussel3 = ((((highscore3 - 450) * 3) - 33 - Asc(highname3)) Xor 33) + (Len(highname3) ^ 2) + (zufall3 - fletter3)
  Open App.Path & "/score.dat" For Output As #1
   Write #1, "-noname-"
   Write #1, Version
   Write #1, highname1
   Write #1, (highscore1 * 2) + 234
   Write #1, schlussel1
   Write #1, zufall1
   Write #1, fletter1
   Write #1, highname2
   Write #1, (highscore2 * 2) + 234
   Write #1, schlussel2
   Write #1, zufall2
   Write #1, fletter2
   Write #1, highname3
   Write #1, (highscore3 * 2) + 234
   Write #1, schlussel3
   Write #1, zufall3
   Write #1, fletter3
  Close #1
  GoTo gesichert
End If

gesichert:
End Sub

Private Sub Form_Unload(Cancel As Integer)
 anfangen = False
 End
End Sub

Private Sub Text1_KeyDown(KeyCode As Integer, Shift As Integer)
 If KeyCode = vbKeyReturn Then Call Command1_Click
End Sub

Private Sub Timer1_Timer()
'Zeit wird gezählt und einige Ereignisse abgefragt
Dim i As Integer
Dim rate As Integer
If aktiv = True Then


 zeit = 60 - CLng(Timer - start)
 If zeit < 1 Then zeit = 0


 If anzeige(7).aktiv = False Then ScoreSizer = 1
 Randomize
 i = Int(Rnd * 35) + 1
 If i = 15 Then
   Randomize
   i = Int(Rnd * 10) + 1
   If i = 3 Then
     Randomize
     i = Int(Rnd * 4) + 1
       If i = 2 Then
        ScoreSizer = 2
        anzeige(7).aktiv = True
        anzeige(7).dauer = 20
        anzeige(7).X = 380
        anzeige(7).Y = 380
        anzeige(7).mode = 1
        anzeige(7).text = "3sec. DoubleScore!"
       End If
       If i = 3 Then
        ScoreSizer = 3
        anzeige(7).aktiv = True
        anzeige(7).dauer = 20
        anzeige(7).X = 380
        anzeige(7).Y = 380
        anzeige(7).mode = 1
        anzeige(7).text = "3sec. TripleScore!"
       End If
   End If
 End If

 If special = True Then
    Randomize
    i = Int(Rnd * 5) + 1
     If i = 1 Then
      Randomize
      i = Int(Rnd * 5) + 1
      punkte = punkte + (i * 25)
      anzeige(8).text = (i * 25) & " Extra Points!"
     End If
     If i = 3 Then
      Randomize
      i = Int(Rnd * 6) + 1
      start = start + i
      anzeige(8).text = i & " Sec. Extra!"
     End If
     If i = 2 Then
      alki = True
      anzeige(8).text = "Drunken??"
     End If
     If i = 4 Then
      Randomize
      i = Int(Rnd * 10) + 1
      punkte = punkte + (i * 25)
      anzeige(8).text = (i * 25) & " Extra Points!"
     End If
     If i = 5 Then
      punkte = CLng(punkte / 2)
      anzeige(8).text = "Half Score.."
     End If
       special = False
       anzeige(8).aktiv = True
       anzeige(8).dauer = 10
       anzeige(8).X = mx
       anzeige(8).Y = my
       anzeige(8).mode = 2
 End If

 If kills >= (maxmause + 1 + belebt) Or zeit <= 0 Then
  bonus = CLng(zeit * (punkte / 175))
  punkte = punkte + bonus
  anzeige(7).aktiv = True
  anzeige(7).dauer = 10
  anzeige(7).X = 410
  anzeige(7).Y = 400
  anzeige(7).mode = 1
  anzeige(7).text = "Zeitbonus " & bonus
  SaveScore
  zaehler = 100
  aktiv = False
 End If
  
 If (60 - (Timer - start)) > 14.9 And (60 - (Timer - start)) < 15 Then
  anzeige(9).aktiv = True
  anzeige(9).dauer = 10
  anzeige(9).X = 430
  anzeige(9).Y = 400
  anzeige(9).mode = 1
  anzeige(9).text = "Hurry up..."
  angst = angst + 2
 End If

'Bonus für alle getöteten Mäuse in einer Sekunde...
If Timer - killtime > 1 Then
    
    If lastkill = 0 Then Randomize: lastkill = Int(Rnd * 30)

    If multikill >= 7 Then
      punkte = punkte + 50 + (lastkill * 5)
      anzeige(10).aktiv = True
      anzeige(10).dauer = 10
      anzeige(10).X = mx
      anzeige(10).Y = my
      anzeige(10).mode = 1
      anzeige(10).text = "BloodSuck " & (50 + (lastkill * 5))
      Streuung = Streuung + 10
      angst = angst + 2
      multikill = 0
     End If
     
    If multikill >= 5 Then
      punkte = punkte + 30 + (lastkill * 3)
      anzeige(10).aktiv = True
      anzeige(10).dauer = 10
      anzeige(10).X = mx
      anzeige(10).Y = my
      anzeige(10).mode = 1
      anzeige(10).text = "Ultrakill " & (30 + (lastkill * 3))
      angst = angst + 1
      multikill = 0
     End If
     
     If multikill >= 3 Then
      punkte = punkte + 15 + (lastkill * 2)
      anzeige(10).aktiv = True
      anzeige(10).dauer = 10
      anzeige(10).X = mx
      anzeige(10).Y = my
      anzeige(10).mode = 1
      anzeige(10).text = "Multikill " & (15 + (lastkill * 2))
      multikill = 0
     End If
  multikill = 0
 
 End If

 If sniper >= 8 Then
  punkte = punkte + (20 + ((sniper + sniperall) * 7))
  anzeige(8).aktiv = True
  anzeige(8).dauer = 10
  anzeige(8).X = mx
  anzeige(8).Y = my
  anzeige(8).mode = 1
  anzeige(8).text = "Killing Spread !" & (20 + ((sniper + sniperall) * 7))
  multikill = 0
  sniperall = sniperall + sniper
  alki = True
  sniper = 0
 End If
 
 End If
 
 For i = 0 To 10
  If anzeige(i).aktiv = True Then
   If anzeige(i).dauer < 1 Then anzeige(i).aktiv = False
   anzeige(i).dauer = anzeige(i).dauer - 1
  End If
 Next i
End Sub
