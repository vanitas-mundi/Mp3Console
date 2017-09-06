Option Strict On
Option Explicit On
Option Infer On

Namespace Windows.Forms

''' <summary>
''' 
''' </summary>
''' <remarks>Aufruf: System.ComponentModel.TypeConverter(GetType(SSP.MyPage.Windows.Forms.ParentPageTypeConverter))</remarks>
Public Class ParentPageTypeConverter

Inherits System.ComponentModel.StringConverter

#Region " --------------->> Öffentliche Methoden der Klasse "
  '{Öffentliche Methoden}
  Public Overloads Overrides Function GetStandardValues _
  (ByVal Context As System.ComponentModel.ITypeDescriptorContext) _
  As System.ComponentModel.TypeConverter.StandardValuesCollection

    Dim page = DirectCast(Context.Instance, Page)
    Dim sb = New BCW.Data.MySqlStatementBuilders.SelectBuilder
    sb.Select.Add("Page")
    sb.From.Add(page.Database & "." & page.Table)
    sb.Where.Add("ParentPage = ''")

    Dim list = BCW.Data.MySqlDBResult.GetFieldList _
    (Of String)(page.ConnectionString, sb.ToString)

    list.Add("")
    list.Sort()
    list.Remove(page.Page)

    Return New StandardValuesCollection(list)
  End Function

  Public Overloads Overrides Function GetStandardValuesExclusive _
  (ByVal Context As System.ComponentModel.ITypeDescriptorContext) _
  As System.Boolean

    Return True
  End Function

  Public Overloads Overrides Function GetStandardValuesSupported _
  (ByVal Context As System.ComponentModel.ITypeDescriptorContext) _
  As System.Boolean

    Return True
  End Function

#End Region 'Öffentliche Methoden der Klasse}

End Class '{DefaultsByClass}

End Namespace