Option Explicit On
Option Infer On
Option Strict On

Public Class HeaderBorderSettings
  Inherits BorderSettings

#Region " --------------->> Enumerationen der Klasse "
  '{Enumerationen}
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _HeaderText As String = "Header"
  Private _HeaderHeight As Int32 = 1
  Private _BodyText As String = ""
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public Property HeaderText As String
  Get
    Return _HeaderText
  End Get
  Set(value As String)
    _HeaderText = value
  End Set
  End Property

  Public Property HeaderHeight As Int32
  Get
    Return _HeaderHeight
  End Get
  Set(value As Int32)
    _HeaderHeight = value
  End Set
  End Property

  Public Property BodyText As String
  Get
    Return _BodyText
  End Get
  Set(value As String)
    _BodyText = value
  End Set
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
  '{Ereignismethoden}
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
#End Region 'Öffentliche Methoden der Klasse}

End Class
