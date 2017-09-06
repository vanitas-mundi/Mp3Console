Option Explicit On
Option Infer On
Option Strict On

Public Class ArgumentsParser

#Region " --------------->> Eigenschaften der Klasse "
  '{Eigenschaften}
  Private _Options As Generic.Dictionary(Of String, String)
  Private _Parameters As Generic.List(Of String)
  Private _AllowedOptions() As String
  Private _ParameterCount As Int32
  Private _OptionalParameters As Boolean = False

  Public Event ShowHelpPage(ByVal sender As Object, ByVal e As EventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
  '{Konstruktor/ Destruktor}
  Public Sub New _
  (ByVal allowedOptions() As String _
  , ByVal parameterCount As Int32)

    Initialize(allowedOptions, parameterCount, False)
  End Sub

  Public Sub New _
  (ByVal allowedOptions() As String _
  , ByVal parameterCount As Int32 _
  , ByVal optionalParameters As Boolean)

    Initialize(allowedOptions, parameterCount, optionalParameters)
  End Sub

  Private Sub Initialize _
  (ByVal allowedOptions() As String _
  , ByVal parameterCount As Int32 _
  , ByVal optionalParameters As Boolean)

    _AllowedOptions = allowedOptions
    For i = 0 To _AllowedOptions.Count - 1
      _AllowedOptions(i) = _AllowedOptions _
      (i).ToLower.Replace("/", "").Replace("-", "")
    Next i
    _ParameterCount = parameterCount
    _OptionalParameters = optionalParameters
  End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
  '{Zugrifsmethoden}
  Public ReadOnly Property OptionValue _
  (ByVal optionName As String) As String
  Get
    Return _Options.Item(optionName.ToLower)
  End Get
  End Property

  Public ReadOnly Property OptionExists _
  (ByVal optionName As String) As Boolean
  Get
    Return _Options.Keys.Contains(optionName.ToLower)
  End Get
  End Property

  Public ReadOnly Property Options() _
  As Generic.Dictionary(Of String, String)
  Get
    Return _Options
  End Get
  End Property

  Public ReadOnly Property Parameters() _
  As Generic.List(Of String)
  Get
    Return _Parameters
  End Get
  End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
  '{Private Methoden}
  Private Sub AddToOptions _
  (ByVal arg As String _
  , ByVal delimiter As Char)

    Dim pos = arg.IndexOf(delimiter)
    Dim key = ""
    Dim value = ""

    Select Case pos
    Case -1
      key = arg.Substring(1).ToLower
    Case Else
      key = arg.Substring(1, pos - 1)
      value = arg.Substring(pos + 1)
    End Select

    If Not _AllowedOptions.Contains(key) Then
      Console.WriteLine("Ungültige Option - """ & key & """.")
      Environment.Exit(0)
    End If

    Select Case True
    Case key = "?"
      RaiseEvent ShowHelpPage(Me, New EventArgs)
      Environment.Exit(0)
    Case Else
      _Options.Add(key, value)
    End Select
  End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Sub Parse(ByVal commandLineArgs() As String)

    _Options = New Generic.Dictionary(Of String, String)
    _Parameters = New Generic.List(Of String)

    For Each arg In commandLineArgs
      Select Case arg.Substring(0, 1)
      Case "/"
        AddToOptions(arg, ":"c)
      Case "-"
        AddToOptions(arg, "="c)
      Case Else
				'If _Parameters.Count >= _ParameterCount Then
				'  Console.WriteLine("Falsche Anzahl Parameter.")
				'  Environment.Exit(0)
				'End If
        _Parameters.Add(arg)
      End Select
    Next arg

    If _OptionalParameters Then Exit Sub

    If _Parameters.Count <> _ParameterCount Then
      Console.WriteLine("Falsche Anzahl Parameter.")
      Environment.Exit(0)
    End If
  End Sub
#End Region 'Öffentliche Methoden der Klasse}

End Class
