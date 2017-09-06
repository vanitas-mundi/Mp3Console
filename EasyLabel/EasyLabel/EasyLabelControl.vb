Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports BCW.ControlMoveAndResizeLib
#End Region

Namespace Windows.Forms

	Public Class EasyLabelControl

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Public Event CloseClicked _
		(ByVal sender As Object, ByVal e As EventArgs)
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
			InitializeComponent()
			Dim sizeAndMove = New ControlSizeAndMoveClass(Me, titleLabel)
			mainToolTip.SetToolTip(copiesNumericUpDown, "Anzahl Ettikett-Kopien.")
			mainToolTip.SetToolTip(closePanel, "Ettikett entfernen.")
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property Content As String
		Get
			Return editorTextBox.Text
		End Get
		Set(value As String)
			editorTextBox.Text = value
		End Set
		End Property

		Public ReadOnly Property ContentByCopies As String()
		Get
			Dim list = New List(Of String)
			For i = 1 To Me.Copies
				list.Add(Me.Content)
			Next i
			Return list.ToArray
		End Get
		End Property

		Public Property Title As String
		Get
			Return titleLabel.Text
		End Get
		Set(value As String)
			titleLabel.Text = value
		End Set
		End Property

		Public Property Copies As Int32
		Get
			Return CType(copiesNumericUpDown.Value, Int32)
		End Get
		Set(value As Int32)
			copiesNumericUpDown.Value = value
		End Set
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
		Private Sub OnCloseClicked _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles closePanel.Click

			RaiseEvent CloseClicked(Me, New EventArgs)
		End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region	'{Öffentliche Methoden der Klasse}

	End Class

End Namespace