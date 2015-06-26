Imports Microsoft.VisualBasic
Imports partnersearchTableAdapters.partnersearchTableAdapter
<System.ComponentModel.DataObject()> _
Public Class classpartnersearch
    Private _productsAdapter As partnersearchTableAdapters.partnersearchTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As partnersearchTableAdapters.partnersearchTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New partnersearchTableAdapters.partnersearchTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
        Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal jointype As String, ByVal sq As String) As partnersearch.partnersearchDataTable
        Adapter.CommandTimeout = 3500
        Return Adapter.GetDatapartners(startRowIndex, 120, jointype, sq)
    End Function

    

End Class
