Option Explicit On
Option Strict On
Option Infer On

Imports System.Text
Imports SSP.ConsoleExt
Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class MenuDrawing

  Implements Imp3Console

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
  Private _TitleInformationBoxBounds As SSP.ConsoleExt.DialogBounds
  Private _AdvancedInformationBoxBounds As SSP.ConsoleExt.DialogBounds
  Private _SettingsBoxBounds As SSP.ConsoleExt.DialogBounds
  Private _MenuFooterBounds As New SSP.ConsoleExt.DialogBounds(0, 24, 78, 24)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New(ByVal mp3Console As mp3Console)
    _mp3Console = mp3Console
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property MP3Console As mp3Console _
  Implements Imp3Console.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub ClearAboutBox()
    Console.Clear()
  End Sub

  Public Sub DrawAboutBox()
    DrawSplashscreen("<Taste, um fortzufahren>")
    Console.ReadKey()
    DrawMainBorder()
    DrawTitleInformationBox()
  End Sub

  Public Sub ClearSplashScreen()
    Console.Clear()
  End Sub

  Public Sub DrawSplashscreen(ByVal message As String)
    DrawMainBorder()

    Dim sb = New StringBuilder

    sb.AppendLine("                 @    ")
    sb.AppendLine("                #     ")
    sb.AppendLine("     *         #      ")
    sb.AppendLine("      *       ##      ")
    sb.AppendLine("       *      #       ")
    sb.AppendLine("       ***   #        ")
    sb.AppendLine("        *** *#        ")
    sb.AppendLine("         ****         ")
    sb.AppendLine("        *****         ")
    sb.AppendLine("       ******         ")
    sb.AppendLine("      **  ***#        ")
    sb.AppendLine("     *   ****##       ")
    sb.AppendLine("    #    ***  ##      ")
    sb.AppendLine("         **     #     ")
    sb.AppendLine("         *       @    ")
    sb.AppendLine("         *            ")
    sb.AppendLine("         *            ")
    sb.AppendLine("        *             ")
    sb.AppendLine("        *             ")
    sb.AppendLine("        *             ")
    sb.AppendLine("        *             ")
    sb.AppendLine("        *             ")
    WriteXY(sb.ToString, 2, 1, Me.MP3Console.Colors)

    WriteXY("mp3Console 2.0", 25, 2, Me.MP3Console.Colors)
    WriteXY("==============", 25, 3, Me.MP3Console.Colors)
    WriteXY(message, 25, 5, Me.MP3Console.Colors)

    WriteXY("(c) 2010 by Sascha Glinka and SSP", 45, 21, Me.MP3Console.Colors)
    WriteXY("Für meine kleine Göttin", 45, 22, Me.MP3Console.Colors)
  End Sub

  Public Sub ClearMenuFooter()
    ClearWindow(_MenuFooterBounds, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub DrawMenuFooter(ByVal title As String)
    Me.ClearMenuFooter() 'ClearLine(24, 0, 78, Me.MP3Console.Colors.BackColor)
    Dim info As String = ""

    Select Case title
    Case "Hauptmenü"
      info = " - <ESC> Programm beenden   <ENTER> Ausführen   <F1> Hilfe"
    Case Else
      info = " - <ESC> Menü verlassen    <ENTER> Ausführen   <F1> Hilfe"
    End Select

    WriteXY(title & info, 1, 24, Me.MP3Console.Colors)
  End Sub

  Public Sub ClearMainBorder()
    Console.Clear()
  End Sub

  Public Sub DrawMainBorder()
    With (Me.MP3Console)

      Console.Clear()

      Dim borderSettings = New BorderSettings
      borderSettings.X = 0
      borderSettings.Y = 0
      borderSettings.X2 = Console.WindowWidth - 1
      borderSettings.Y2 = Console.WindowHeight - 2
      borderSettings.ForeColor = .Colors.BorderColor
      borderSettings.BackColor = .Colors.BackColor
      borderSettings.BorderStyleType = BorderStyleTypes.Double
      DrawBorder(borderSettings)

      WriteXY(" mp3Console ", 34, 0 _
      , .Colors.BorderColor, .Colors.BackColor)
    End With
  End Sub

  Public Sub ClearTitleInformationBox()
    If _TitleInformationBoxBounds Is Nothing Then Exit Sub
    ClearWindow(_TitleInformationBoxBounds, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub DrawTitleInformationBox()
    With Me.MP3Console

      _TitleInformationBoxBounds = New SSP.ConsoleExt.DialogBounds(1, 1, 78, 8)

      Dim currentTitle = .PlayerController.CurrentTitle
      Dim duration = New Text.StringBuilder
      Dim rankingInfo As String = ""
      If currentTitle IsNot Nothing Then
        duration.Append(currentTitle.Id3.Duration.Hours.ToString("00"))
        duration.Append(":" & currentTitle.Id3.Duration.Minutes.ToString("00"))
        duration.Append(":" & currentTitle.Id3.Duration.Seconds.ToString("00"))

        rankingInfo = Space(1) & "<Ranking: " _
        & .FavoritesControl.GetRankingGraphic(currentTitle) & ">"
        If rankingInfo.EndsWith("Ranking: ") Then rankingInfo = ""
      End If

      Dim settings = New HeaderBorderSettings
      settings.HeaderText = "Titelinfo - " & duration.ToString & rankingInfo
      settings.Bounds = _TitleInformationBoxBounds
      settings.ColorSet = .Colors
      DrawHeaderBorder(settings)

      WriteXY("Interpret:", 3, 4, .Colors.ForeColor, .Colors.BackColor)
      WriteXY("Album:", 3, 5, .Colors.ForeColor, .Colors.BackColor)
      WriteXY("Titel:", 3, 6, .Colors.ForeColor, .Colors.BackColor)
      WriteXY("Genre:", 3, 7, .Colors.ForeColor, .Colors.BackColor)


      Dim infoLine = New Text.StringBuilder

      If .PlayerController.RepeatMode Then infoLine.Append("<Repeat> ")

      Select Case True
      Case Not .FavoritesControl.PlayFavorites = FavoritesControl.Rankings.none
        infoLine.Append("<Favoriten> ")
      Case .FilterControl.UseFilter
        infoLine.Append("<Filter> ")
      End Select

      If .PlayerController.IsPlaying Then
        infoLine.Append("<Wiedergabe> ")
      Else
        infoLine.Append("<Pausiert> ")
      End If

      WriteXY(infoLine.ToString, 78 - infoLine.Length, 2, .Colors.ForeColor, .Colors.BackColor)

      'If .PlayerController.IsPlaying Then
      '  WriteXY("<Wiedergabe>", 65, 2, .Colors.ForeColor, .Colors.BackColor)
      '  Select Case True
      '  Case .FavoritesControl.PlayFavorites <> FavoritesControl.Rankings.none
      '    WriteXY("<Favoriten>", 53, 2, .Colors.ForeColor, .Colors.BackColor)
      '  Case .FilterControl.UseFilter
      '    WriteXY("<Filter>", 56, 2, .Colors.ForeColor, .Colors.BackColor)
      '  End Select
      'Else
      '  WriteXY("<Pausiert>", 67, 2, .Colors.ForeColor, .Colors.BackColor)
      '  Select Case True
      '  Case .FavoritesControl.PlayFavorites <> FavoritesControl.Rankings.none
      '    WriteXY("<Favoriten>", 55, 2, .Colors.ForeColor, .Colors.BackColor)
      '  Case .FilterControl.UseFilter
      '    WriteXY("<Filter>", 58, 2, .Colors.ForeColor, .Colors.BackColor)
      '  End Select
      'End If

      If currentTitle IsNot Nothing Then
        WriteXY(StringShorten(currentTitle.Id3.Artist, 63) _
        , 14, 4, .Colors.ForeColor, .Colors.BackColor)

        If (currentTitle.Id3.Year Is Nothing) _
        OrElse (currentTitle.Id3.Year.ToString.Length = 0) Then
          WriteXY(StringShorten(currentTitle.Id3.Album, 63) _
          , 14, 5, .Colors.ForeColor, .Colors.BackColor)
        Else
          WriteXY(StringShorten(currentTitle.Id3.Album, 56) _
          & " - " & currentTitle.Id3.Year.ToString _
          , 14, 5, .Colors.ForeColor, .Colors.BackColor)
        End If

        Select Case currentTitle.Track
        Case ""
          WriteXY(StringShorten(currentTitle.Id3.Title, 63) _
          , 14, 6, .Colors.ForeColor, .Colors.BackColor)
        Case Else
          WriteXY(StringShorten(currentTitle.Track _
          & " " & currentTitle.Id3.Title, 63) _
          , 14, 6, .Colors.ForeColor, .Colors.BackColor)
        End Select

        WriteXY(StringShorten(currentTitle.Id3.Genre, 50) _
        , 14, 7, .Colors.ForeColor, .Colors.BackColor)
      End If

      WriteXY("Volume:", 65, 7 _
      , .Colors.ForeColor _
      , .Colors.BackColor)
      WriteXY(My.Settings.CurrentVolume.ToString.PadLeft(3) & "%" _
      , 73, 7, .Colors)
    End With
  End Sub

  Public Sub ClearAdvancedInformationBox()
    If _AdvancedInformationBoxBounds Is Nothing Then Exit Sub
    ClearWindow(_AdvancedInformationBoxBounds, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub DrawAdvancedInformationBox _
  (ByVal x As Int32, ByVal infos As Object)

    With Me.MP3Console

      _AdvancedInformationBoxBounds _
      = New SSP.ConsoleExt.DialogBounds(x, 9, 78, 21)

      Dim headerX = x + 2
      Dim valueX = headerX + 2
      Dim maxWidth = 73 - x

      Dim settings = New HeaderBorderSettings
      settings.HeaderText = "Trackinfo | <0-3> = Ranking setzen"
      settings.Bounds = _AdvancedInformationBoxBounds
      settings.ColorSet = .Colors
      DrawHeaderBorder(settings)

      'DrawHeaderBorder("Trackinfo | <0-3> = Ranking setzen" _
      ', _AdvancedInformationBoxBounds, .Colors)

      Select Case True
      Case TypeOf infos Is SSP.IndexerLibrary.Title

        Dim item = DirectCast(infos, SSP.IndexerLibrary.Title)
        If item.Id3 Is Nothing Then Exit Sub

        WriteXY("Interpret:" _
        , headerX, 12, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(StringShorten(item.Id3.Artist, maxWidth) _
        , valueX, 13, .Colors.ForeColor, .Colors.BackColor)

        WriteXY("Album:" _
        , headerX, 14, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(StringShorten(item.Id3.Album, maxWidth) _
        , valueX, 15, .Colors.ForeColor, .Colors.BackColor)

        WriteXY("Titel:" _
        , headerX, 16, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(StringShorten(item.Id3.Title, maxWidth) _
        , valueX, 17, .Colors.ForeColor, .Colors.BackColor)

        WriteXY("Genre:" _
        , headerX, 18, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(StringShorten(item.Id3.Genre, maxWidth) _
        , valueX, 19, .Colors.ForeColor, .Colors.BackColor)

        WriteXY("Ranking: " & .FavoritesControl.GetRankingGraphic(item) _
        , headerX, 20, .Colors.ForeColor, .Colors.BackColor)

      Case TypeOf infos Is String
        WriteXY(StringShorten(infos.ToString, maxWidth) _
        , headerX, 12, .Colors.ForeColor, .Colors.BackColor)
      End Select
    End With
  End Sub

  Public Sub ClearSettingsBox()
    If _SettingsBoxBounds Is Nothing Then Exit Sub
    ClearWindow(_SettingsBoxBounds, Me.MP3Console.Colors.BackColor)
  End Sub

  Public Sub DrawSettingsBox(ByVal x As Int32)
    With Me.MP3Console

      _SettingsBoxBounds = New SSP.ConsoleExt.DialogBounds(x, 9, 78, 21)

      Dim settings = New HeaderBorderSettings
      settings.HeaderText = "Aktuelle Einstellungen"
      settings.Bounds = _SettingsBoxBounds
      settings.ColorSet = .Colors
      DrawHeaderBorder(settings)

      x += 2

      WriteXY("Aktueller Index:" _
      , x, 12, .Colors.ForeColor, .Colors.BackColor)

      WriteXY(StringShorten(My.Settings.IndexName, 77 - x) _
      , x, 13, .Colors.ForeColor, .Colors.BackColor)

      Select Case .FavoritesControl.PlayFavorites
      Case FavoritesControl.Rankings.none
        WriteXY("Aktueller Filter:" _
        , x, 15, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(StringShorten(IIf(My.Settings.FilterName.Length = 0 _
        , "<Keiner>", My.Settings.FilterName).ToString, 77 - x) _
        , x, 16, .Colors.ForeColor, .Colors.BackColor)
      Case Else
        WriteXY("Aktuelle Favoritenwiedergabe:" _
        , x, 15, .Colors.ForeColor, .Colors.BackColor)

        WriteXY(.FavoritesControl.GetRankingGraphic _
        (.FavoritesControl.PlayFavorites) _
        , x, 16, .Colors.ForeColor, .Colors.BackColor)
      End Select

      WriteXY("Aktuelles Ausgabegerät:" _
      , x, 18, .Colors.ForeColor, .Colors.BackColor)

      WriteXY(StringShorten(.PlayerController.Player.SoundDevices.Item _
      (My.Settings.DeviceID).Description, 77 - x) _
      , x, 19, .Colors.ForeColor, .Colors.BackColor)
    End With
  End Sub

  Public Sub RefreshMainMenu(ByVal x As Integer)
    DrawMainBorder()
    DrawTitleInformationBox()
    DrawSettingsBox(x)
  End Sub

#End Region 'Öffentliche Methoden der Klasse}

End Class
