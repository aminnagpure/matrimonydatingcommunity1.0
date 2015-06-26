Imports Microsoft.VisualBasic
Imports topearnersTableAdapters.topearnerTableAdapter
<System.ComponentModel.DataObject()> _
Public Class cltopearner
    Private _productsAdapter As topearnersTableAdapters.topearnerTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As topearnersTableAdapters.topearnerTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New topearnersTableAdapters.topearnerTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As topearners.topearnerDataTable
        Adapter.CommandTimeout = 5000
        Return Adapter.GetTopEarners(startRowIndex, 120, sq)
    End Function

   
End Class
