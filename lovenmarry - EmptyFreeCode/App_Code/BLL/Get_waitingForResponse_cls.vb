Imports Microsoft.VisualBasic
Imports Get_waitingForResponseTableAdapters.waitingForResponseTableAdapter

<System.ComponentModel.DataObject()> _
Public Class Get_waitingForResponse_cls
    Private _productsAdapter As Get_waitingForResponseTableAdapters.waitingForResponseTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As Get_waitingForResponseTableAdapters.waitingForResponseTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New Get_waitingForResponseTableAdapters.waitingForResponseTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal jointype As String, ByVal sq As String, ByVal candiid As Integer) As Get_waitingForResponse.waitingForResponseDataTable
        Return Adapter.GetData(startRowIndex, 120, jointype, sq, candiid)

    End Function
End Class
