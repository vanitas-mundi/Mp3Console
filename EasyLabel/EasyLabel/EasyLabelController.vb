Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports "
Imports BCW.LabelPrint
Imports BCW.LabelPrint.LabelPrinting.PrintSettingsOptions
Imports SSP.EasyLabel.Windows.Forms
#End Region

Public Class EasyLabelController

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
	Private _labelPrinting As New LabelPrinting
	Private _labelContainer As Control
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
	Public Sub New(ByVal labelContainer As Control)
		_labelContainer = labelContainer
	End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
	Private ReadOnly Property LabelCount As Int32
	Get
		Return _labelContainer.Controls.Count + 1
	End Get
	End Property

	Public ReadOnly Property SelectedPrinter As String
	Get
		Return _labelPrinting.SelectedPrinter
	End Get
	End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
	Private Sub OnCloseClick(sender As Object, e As EventArgs)
		CloseLabel(DirectCast(sender, EasyLabelControl))
	End Sub
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
	Private Sub CloseLabel(ByVal label As EasyLabelControl)
		_labelContainer.Controls.Remove(label)
		Dim labels = GetLabels()
		For i = 0 To labels.Count - 1
			labels(i).Title = "Etikett" & i + 1
		Next i
	End Sub

	Private Function GetLabels() As EasyLabelControl()
		Dim ret = From control In _labelContainer.Controls _
		Order By DirectCast(control, EasyLabelControl).Title _
		Select DirectCast(control, EasyLabelControl)

		Return ret.ToArray
	End Function

	Private Function GetLabelContentByCopies() As String()
		Dim ret = From control In _labelContainer.Controls _
		Order By DirectCast(control, EasyLabelControl).Title _
		Select DirectCast(control, EasyLabelControl).ContentByCopies

		Dim list = New List(Of String)
		For Each item In ret
			list.AddRange(item)
		Next

		Return list.ToArray
	End Function

	Private Function GetLabelInfoList() As List(Of EasyLabelInfo)
		Dim ret = From control In _labelContainer.Controls _
		Order By DirectCast(control, EasyLabelControl).Title _
		Select New EasyLabelInfo _
		(DirectCast(control, EasyLabelControl).Title _
		, DirectCast(control, EasyLabelControl).Content _
		, DirectCast(control, EasyLabelControl).Copies _
		, DirectCast(control, EasyLabelControl).Size _
		, DirectCast(control, EasyLabelControl).Location)

		Return ret.ToList
	End Function

	Private Sub RestoreLabel(ByVal info As EasyLabelInfo)
		Dim label = AddLabel()
		label.Title = info.Title
		label.Content = info.Content
		label.Copies = info.Copies
		label.Size = info.Size
		label.Location = info.location
	End Sub
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
	Public Sub Load()
		_labelContainer.Controls.Clear()

		Dim ofd = New OpenFileDialog
		ofd.AddExtension = True
		ofd.Filter = "EasyLabel-Dateien (*.elf)|*.elf|Alle Dateien (*.*)|*.*"
		ofd.FilterIndex = 1
		ofd.RestoreDirectory = True
		Select Case ofd.ShowDialog
		Case DialogResult.Cancel
			Exit Sub
		End Select

		Try
			Dim data = Serializer.DeSerialize _
			(Of List(Of EasyLabelInfo))(ofd.FileName)

			For Each info In data
				RestoreLabel(info)
			Next info
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Fehler beim Laden" _
			, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Public Sub Save()
		Dim data = GetLabelInfoList()

		Dim sfd = New SaveFileDialog
		sfd.AddExtension = True
		sfd.Filter = "EasyLabel-Dateien (*.elf)|*.elf|Alle Dateien (*.*)|*.*"
		sfd.FilterIndex = 1
		sfd.RestoreDirectory = True
		sfd.OverwritePrompt = True
		Select Case sfd.ShowDialog
		Case DialogResult.Cancel
			Exit Sub
		End Select

		Try
			Serializer.Serialize _
			(Of List(Of EasyLabelInfo))(sfd.FileName, data)
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Fehler beim Speichern" _
			, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Public Function AddLabel() As EasyLabelControl

		Dim label = New EasyLabelControl
		label.Title = "Etikett" & Me.LabelCount

		AddHandler label.CloseClicked, AddressOf OnCloseClick
		_labelContainer.Controls.Add(label)
		label.BringToFront()
		Return label
	End Function

	Public Sub PrintLabels()

		Dim content = GetLabelContentByCopies()
		If content.Count = 0 Then
			Exit Sub
		End If

		_labelPrinting.LabelTexts = content
		_labelPrinting.ShowPrintPreView(SelectPrintStartPosition)
	End Sub

	Public Sub SelectPrinter()
		_labelPrinting.SelectPrinter()
	End Sub

	Public Sub SetPageSettings()
		_labelPrinting.SetPageSettings()
	End Sub

	Public Sub SelectLabelFormat()
		_labelPrinting.SelectLabelFormat()
	End Sub
#End Region	'{Öffentliche Methoden der Klasse}

End Class
