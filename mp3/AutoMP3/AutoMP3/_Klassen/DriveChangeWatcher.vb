Option Explicit On
Option Infer On
Option Strict On

	Public Class DriveChangeWatcher

		Inherits System.Windows.Forms.NativeWindow

		' Das sind die Ereignisse aus WParam.
		' Uns interessiert nur, ob ein Laufwerk hinzugekommen ist oder 
		'  entfernt wurde.
		Public Event DriveArrived _
		(ByVal sender As Object, ByVal e As System.IO.DriveInfo)

		Public Event DriveRemoved _
		(ByVal sender As Object, ByVal e As System.IO.DriveInfo)

		' Die Struktur für OEM.
		' Wird über LParam gefüllt.
		' USB-Sticks laufen alle hier auf.
		Private Structure DEV_BROADCAST_OEM
			Public dbco_size As Integer
			Public dbco_devicetype As Integer
			Public dbco_reserved As Integer
			Public dbco_identifier As Integer
			Public dbco_suppfunc As Integer
		End Structure

		' Die Struktur für Volumes.
		' Wird über LParam gefüllt.
		Private Structure DEV_BROADCAST_VOLUME
			Public dbch_size As Integer
			Public dbch_devicetype As Integer
			Public dbch_reserved As Integer
			Public dbcv_unitmask As Integer
			Public dbcv_flags As Short
		End Structure

		' Die Struktur für den Header.
		' Wird über LParam gefüllt.
		Private Structure DEV_BROADCAST_HDR
			Public dbch_size As Integer
			Public dbch_devicetype As Integer
			Public dbch_reserved As Integer
		End Structure

		' Das sind die Konstanten der Gerätetypen
		' Vorsicht die Gerätetypen Variablen in den Strukturen sind vom Typ Integer.
		' IntelliSense kann das nicht auflösen.
		Private Enum DeviceType
			OEM = 0
			DEVNODE = 1
			VOLUME = 2
			PORT = 3
			NET = 4
			DEVICEINTERFACE = 5
			HANDLE = 6
		End Enum

		' Dies sind die Konstanten für die verschiedenen Geräte - Habe ich zur der 
		' besseren Verwendbarkeit in eine Enum gepackt.(siehe oben)
		' // type of device in DEV_BROADCAST_HDR
		' // OEM- or IHV-defined:
		'   Public Const DBT_DEVTYP_OEM As Integer = &H0&                 
		' Devnode number.
		'   Public Const DBT_DEVTYP_DEVNODE As Integer = &H1&               
		' // Logical volume
		'   Public Const DBT_DEVTYP_VOLUME As Integer = &H2&                
		' // Port (serial or parallel)
		'   Public Const DBT_DEVTYP_PORT As Integer = &H3&                  
		' // Network resource
		'   Public Const DBT_DEVTYP_NET As Integer = &H4&                   
		' // Device interface class
		'   Public Const DBT_DEVTYP_DEVICEINTERFACE As Integer = &H5&       
		' // File system handle
		'   Public Const DBT_DEVTYP_HANDLE As Integer = &H6&                

		' Windowmessage DeviceChange
		Private Const WM_DEVICECHANGE As Integer = &H219

		'Die beiden Ereignisse, die für uns von Bedeutung sind.
		Private Const DBT_DEVICEARRIVAL As Integer = &H8000
		Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004

		' Dies ist der Dreh- und Angelpunkt der Klasse. - Hier bekommen wir die 
		'  Messages mit.
		' In unserm Fall interessiert uns nur die WM_DeviceChange-Nachricht
		Protected Overrides Sub WndProc(ByRef m As Message)
			If m.Msg = WM_DEVICECHANGE Then
				Me.HandleHeader(m)
			End If
			MyBase.WndProc(m)
		End Sub

		' Hier schauen wir erst mal in den Header und verzweigen dementsprechend
		Private Sub HandleHeader(ByRef m As Message)
			Dim header As DEV_BROADCAST_HDR
			Dim objHeader As Object = m.GetLParam(header.GetType)

			If Not IsNothing(objHeader) Then
				'Dient nur zur Kennzeichnung, was nicht implementiert ist
				Dim notSupported As Boolean

				Select Case header.dbch_devicetype
					Case DeviceType.OEM
						Me.HandleOEM(m)
					Case DeviceType.DEVNODE
						notSupported = True
					Case DeviceType.VOLUME
						Me.HandleVolume(m)
					Case DeviceType.PORT
						notSupported = True
					Case DeviceType.NET
						notSupported = True
					Case DeviceType.DEVICEINTERFACE
						notSupported = True
					Case DeviceType.HANDLE
						notSupported = True
				End Select
			End If
		End Sub

		' Das Ereignis betrifft ein Volume
		Private Sub HandleVolume(ByRef m As Message)
			Dim volume As DEV_BROADCAST_VOLUME
			Dim objVolume As Object = m.GetLParam(volume.GetType)

			If IsNothing(objVolume) Then Exit Sub

			volume = DirectCast(objVolume, DEV_BROADCAST_VOLUME)
			Dim di As New IO.DriveInfo(Me.DriveFromMask(volume.dbcv_unitmask))

			' USB-Stick
			If di.DriveType = IO.DriveType.Removable Then
				If CInt(m.WParam) = DBT_DEVICEARRIVAL Then
					RaiseEvent DriveArrived(Me, di)
				End If
			End If

			' USB-Festplatte
			If di.DriveType = IO.DriveType.Fixed Then
				If CInt(m.WParam) = DBT_DEVICEARRIVAL Then
					RaiseEvent DriveArrived(Me, di)
				End If
			End If

			If CInt(m.WParam) = DBT_DEVICEREMOVECOMPLETE Then
				RaiseEvent DriveRemoved(Me, di)
			End If
		End Sub

		' OEM, und was genau?
		' Uns interesieren nur Volumes
		Private Sub HandleOEM(ByRef m As Message)
			Dim oem As DEV_BROADCAST_OEM
			Dim objOem As Object = m.GetLParam(oem.GetType)

			If Not IsNothing(objOem) Then
				oem = DirectCast(objOem, DEV_BROADCAST_OEM)
				If oem.dbco_devicetype = DeviceType.VOLUME Then
					Me.HandleVolume(m)
				End If
			End If
		End Sub

		' Liefert uns den Laufwerksbuchstaben zurück
		Private Function DriveFromMask _
		(ByVal unitmask As Integer) As Char

			For b = 0 To 25
				If (unitmask And CInt(2 ^ b)) <> 0 Then
					Return Chr(65 + b)
				End If
			Next b
			Return Nothing
		End Function

		'#################################################################
		' Wir haben zwei Möglichkeiten der Instanzierung
		'#################################################################
		' Erste Möglichkeit:
		' Wir benötigen das Form in der die Klasse instanziert wird.
		' Und müssen den Handle der Form auf unser NativeWindow setzen.
		'Public Sub New(ByVal form As System.Windows.Forms.Form)
		'		Me.AssignHandle(form.Handle)
		'End Sub
		'Private Sub New()
		'End Sub

		'' Das Handle wieder freigeben.
		'Protected Overrides Sub Finalize()
		'		Me.ReleaseHandle()
		'		MyBase.Finalize()
		'End Sub

		''##################################################################
		'' Zweite Möglichkeit:(Auskommentiert)
		'' Wir machen uns unser eigenes Handle.
		'' In diesen Fall benötigen wir das Form nicht!
		Public Sub New()
			Me.CreateHandle(New CreateParams)
		End Sub

		' Das selbst erstellte Handle zerstören.
		Protected Overrides Sub Finalize()
			Me.DestroyHandle()
			MyBase.Finalize()
		End Sub
	End Class
