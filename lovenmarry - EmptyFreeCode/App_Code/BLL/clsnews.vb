Imports Microsoft.VisualBasic
Imports newsTableAdapters.newspagingTableAdapter
<System.ComponentModel.DataObject()> _
Public Class clsnews

    Private _productsAdapter As newsTableAdapters.newspagingTableAdapter = Nothing


    Protected ReadOnly Property Adapter() As newsTableAdapters.newspagingTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New newsTableAdapters.newspagingTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As news.newspagingDataTable
        'Return Adapter.GetnewsData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetnewsData(startRowIndex, 120, sq)
    End Function

    

End Class
