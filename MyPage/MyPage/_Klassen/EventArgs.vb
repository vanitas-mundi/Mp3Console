Option Explicit On
Option Strict On
Option Infer On

Namespace Windows.Forms

Public Class PageSelectedEventArgs
  Inherits EventArgs

  Private _Page As Page

  Public Sub New _
  (ByVal page As Page)

    _Page = page
  End Sub

  Public ReadOnly Property Page As Page
  Get
    Return _Page
  End Get
  End Property
End Class


End Namespace
