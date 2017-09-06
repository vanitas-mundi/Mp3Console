Option Explicit On
Option Strict On
Option Infer On

Imports SSP.ConsoleExt.BarMenus
Imports SSP.ConsoleExt.Tools
Imports SSP.ConsoleExt.Controls

Public Class Id3EditorControl

  Implements Imp3ConsoleControl

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
 Private Enum Id3Commands
    CurrentTitle = 0
    CurrentAlbum = 1
    CurrentArtist = 2
    CurrentGenre = 3
  End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _mp3Console As mp3Console
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
  Implements Imp3ConsoleControl.MP3Console
  Get
    Return _mp3Console
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
  '{Ereignismethoden}
  Private Sub onMenuKeyPressed _
  (ByVal sender As Object _
  , ByVal e As BarMenuKeyPressedEventArgs)

    Select Case e.KeyInfo.Key
    Case ConsoleKey.F1
      e.ExitBarMenu = True
      e.ReturnDialogResult = Nothing
      ClearWindow(DirectCast(sender _
      , BarMenu(Of BarMenuDefaultItem(Of Id3Commands))).Bounds _
      , Me.MP3Console.Colors.BackColor)
      Me.MP3console.HelpViewer.Show(Me)
    Case ConsoleKey.F2
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of Id3Commands)(Nothing, Nothing, Id3Commands.CurrentTitle)
    Case ConsoleKey.F3
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of Id3Commands)(Nothing, Nothing, Id3Commands.CurrentAlbum)
    Case ConsoleKey.F4
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of Id3Commands)(Nothing, Nothing, Id3Commands.CurrentArtist)
    Case ConsoleKey.F5
      e.ExitBarMenu = True
      e.ReturnValue = New SSP.ConsoleExt.BarMenus.BarMenuDefaultItem _
      (Of Id3Commands)(Nothing, Nothing, Id3Commands.CurrentGenre)
    End Select
  End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Function GetId3TagField() _
  As SSP.IndexerLibrary.Id3TagFields

    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields)() _
    {New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Interpret", Nothing, IndexerLibrary.Id3TagFields.Artist) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Album", Nothing, IndexerLibrary.Id3TagFields.Album) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Titel", Nothing, IndexerLibrary.Id3TagFields.Title) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Track", Nothing, IndexerLibrary.Id3TagFields.TrackNum) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Genre", Nothing, IndexerLibrary.Id3TagFields.Genre) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Jahr", Nothing, IndexerLibrary.Id3TagFields.Year) _
    , New BarMenuDefaultItem(Of SSP.IndexerLibrary.Id3TagFields) _
    ("Kommentar", Nothing, IndexerLibrary.Id3TagFields.Comments)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem _
    (Of SSP.IndexerLibrary.Id3TagFields))(bmi)

    Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Id3-Tag-Editor")
    Select Case bm.ShowMenu
    Case ConsoleExt.DialogResults.OK
      Return bm.Value.Object
    Case Else
      Return IndexerLibrary.Id3TagFields.None
   End Select

  End Function

  Private Sub EditCurrentTitle()

    Dim id3TagField = GetId3TagField()

    If id3TagField = IndexerLibrary.Id3TagFields.None Then Exit Sub

    Dim ib As New ConsoleInputBox(Of String) _
    ("Id3-Tag-Titel", "Neuer Wert:", 1, 9, 78, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim mb As New ConsoleMessageBox("Id3-Tag-Titel", Nothing _
    , 1, 9, 60, Me.MP3Console.Colors)

    With Me.MP3Console.PlayerController
      Select Case Me.MP3console.IndexControl.Index.UpdateId3Title _
      (.CurrentTitle.Id3.Artist _
      , .CurrentTitle.Id3.Album _
      , .CurrentTitle.Id3.Title _
      , id3TagField _
      , ib.Value)
      Case -1
        mb.Message = New String() {"Es trat ein Fehler auf!" _
        , "Der Index muss ggf. neu generiert werden!"}
      Case Else
        mb.Message = New String() {"Id3-Tag wurde erfolgreich aktualisiert!"}
      End Select

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)

      Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(.CurrentTitle.FileName)

      .CurrentTitle = New SSP.IndexerLibrary.Title(id3)
      Me.MP3console.MenuDrawing.DrawTitleInformationBox()
    End With
  End Sub

  Private Sub EditCurrentAlbum()
    Dim id3TagField = GetId3TagField()

    If id3TagField = IndexerLibrary.Id3TagFields.None Then Exit Sub

    Dim ib As New ConsoleInputBox(Of String) _
    ("Id3-Tag-Album", "Neuer Wert:", 1, 9, 78, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim mb As New ConsoleMessageBox("Id3-Tag-Album", Nothing _
    , 1, 9, 60, Me.MP3Console.Colors)

    With Me.MP3Console.PlayerController
      Dim result = Me.MP3Console.IndexControl.Index.UpdateId3Album _
      (.CurrentTitle.Id3.Artist _
      , .CurrentTitle.Id3.Album _
       , id3TagField _
      , ib.Value)

      Select Case result
      Case -1
        mb.Message = New String() {"Es trat ein Fehler auf!" _
        , "Der Index muss ggf. neu generiert werden!"}
      Case Else
        mb.Message = New String() {result & " Id3-Tag(s) wurde(n) erfolgreich aktualisiert!"}
      End Select

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)

      Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(.CurrentTitle.FileName)

      .CurrentTitle = New SSP.IndexerLibrary.Title(id3)
      Me.MP3console.MenuDrawing.DrawTitleInformationBox()
    End With
  End Sub

  Private Sub EditCurrentArtist()
    Dim id3TagField = GetId3TagField()

    If id3TagField = IndexerLibrary.Id3TagFields.None Then Exit Sub

    Dim ib As New ConsoleInputBox(Of String) _
    ("Id3-Tag-Interpret", "Neuer Wert:", 1, 9, 78, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim mb As New ConsoleMessageBox("Id3-Tag-Interpret", Nothing _
    , 1, 9, 60, Me.MP3Console.Colors)

    With Me.MP3Console.PlayerController
      Dim result = Me.MP3Console.IndexControl.Index.UpdateId3Artist _
      (.CurrentTitle.Id3.Artist _
       , id3TagField _
      , ib.Value)

      Select Case result
      Case -1
        mb.Message = New String() {"Es trat ein Fehler auf!" _
        , "Der Index muss ggf. neu generiert werden!"}
      Case Else
        mb.Message = New String() _
        {result & " Id3-Tag(s) wurde(n) erfolgreich aktualisiert!"}
      End Select

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)

      Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(.CurrentTitle.FileName)

      .CurrentTitle = New SSP.IndexerLibrary.Title(id3)
      Me.MP3console.MenuDrawing.DrawTitleInformationBox()
    End With
  End Sub

  Private Sub EditCurrentGenre()
    Dim id3TagField = GetId3TagField()

    If id3TagField = IndexerLibrary.Id3TagFields.None Then Exit Sub

    Dim ib As New ConsoleInputBox(Of String) _
    ("Id3-Tag-Genre", "Neuer Wert:", 1, 9, 78, Me.MP3Console.Colors)

    Select Case ib.ShowDialog
    Case ConsoleExt.DialogResults.Cancel
      Exit Sub
    End Select

    Dim mb As New ConsoleMessageBox("Id3-Tag-Genre", Nothing _
    , 1, 9, 60, Me.MP3Console.Colors)

    With Me.MP3Console.PlayerController
      Dim result = Me.MP3Console.IndexControl.Index.UpdateId3Genre _
      (.CurrentTitle.Id3.Genre _
       , id3TagField _
      , ib.Value)

      Select Case result
      Case -1
        mb.Message = New String() {"Es trat ein Fehler auf!" _
        , "Der Index muss ggf. neu generiert werden!"}
      Case Else
        mb.Message = New String() {result & " Id3-Tag(s) wurde(n) erfolgreich aktualisiert!"}
      End Select

      mb.ShowMessage(ConsoleExt.MessageBoxTypes.Message)

      Dim id3 = New HundredMilesSoftware.UltraID3Lib.UltraID3
      id3.Read(.CurrentTitle.FileName)

      .CurrentTitle = New SSP.IndexerLibrary.Title(id3)
      Me.MP3console.MenuDrawing.DrawTitleInformationBox()
    End With
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Show() Implements Imp3ConsoleControl.Show
    Dim bmi = New BarMenuInfos _
    (New BarMenuDefaultItem(Of Id3Commands)() _
    {New BarMenuDefaultItem(Of Id3Commands) _
    ("ID3 aktueller Titel     (F2)", Nothing, Id3Commands.CurrentTitle) _
    , New BarMenuDefaultItem(Of Id3Commands) _
    ("ID3 aktuelles Album     (F3)", Nothing, Id3Commands.CurrentAlbum) _
    , New BarMenuDefaultItem(Of Id3Commands) _
    ("ID3 aktueller Interpret (F4)", Nothing, Id3Commands.CurrentArtist) _
    , New BarMenuDefaultItem(Of Id3Commands) _
    ("ID3 aktuelles Genre     (F5)", Nothing, Id3Commands.CurrentGenre)} _
    , 1, 9, Me.MP3Console.Colors, 11)

    Dim bm = New BarMenu(Of BarMenuDefaultItem(Of Id3Commands))(bmi)
    AddHandler bm.KeyPressed, AddressOf onMenuKeyPressed
    Dim result As SSP.ConsoleExt.DialogResults

    Do
      Me.MP3console.MenuDrawing.DrawMenuFooter("Menü Id3-Tag-Editor")
      result = bm.ShowMenu

      If (result = ConsoleExt.DialogResults.OK) _
      AndAlso (bm.Value IsNot Nothing) Then
        Select Case bm.Value.Object
        Case Id3Commands.CurrentTitle
          EditCurrentTitle()
        Case Id3Commands.CurrentAlbum
          EditCurrentAlbum()
        Case Id3Commands.CurrentArtist
          EditCurrentArtist()
        Case Id3Commands.CurrentGenre
          EditCurrentGenre()
        End Select
      End If
    Loop Until result = ConsoleExt.DialogResults.Cancel
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
