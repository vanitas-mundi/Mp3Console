Option Explicit On
Option Infer On
Option Strict On

Namespace Windows.Forms

	Public Class EasyLabelDialog

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _controller As EasyLabelController
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
			InitializeComponent()
			_controller = New EasyLabelController(labelsPanel)
			selectedPrinterToolStripLabel.Text = _controller.SelectedPrinter
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
		Private Sub OnLoadClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles loadLabelsToolStripButton.Click

			_controller.Load()
		End Sub

		Private Sub OnSaveClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles saveLabelsToolStripButton.Click

			_controller.Save()
		End Sub

		Private Sub OnAddLabelClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles addLabelToolStripButton.Click

			_controller.AddLabel()
		End Sub

		Private Sub OnPrintLabelsClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles printLabelsToolStripButton.Click

			_controller.PrintLabels()
		End Sub

		Private Sub OnSelectPrinterClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles selectPrinterToolStripButton.Click

			_controller.SelectPrinter()
			selectedPrinterToolStripLabel.Text = _controller.SelectedPrinter
		End Sub

		Private Sub OnSetPageSettingsClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles setPageSettingsToolStripButton.Click

			_controller.SetPageSettings()
		End Sub

		Private Sub OnSelectLabelFormatClick _
		(ByVal sender As Object _
		, ByVal e As EventArgs) _
		Handles selectLabelFormatToolStripButton.Click

			_controller.SelectLabelFormat()
		End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region	'{Öffentliche Methoden der Klasse}

	End Class

End Namespace