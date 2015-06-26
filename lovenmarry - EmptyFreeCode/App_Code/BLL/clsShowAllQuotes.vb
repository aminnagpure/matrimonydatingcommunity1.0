Imports Microsoft.VisualBasic
Imports showAllQuotesTableAdapters.ShowAllQuotesTableAdapter

<System.ComponentModel.DataObject()> _
Public Class clsShowAllQuotes
    Private _productsAdapter As showAllQuotesTableAdapters.ShowAllQuotesTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As showAllQuotesTableAdapters.ShowAllQuotesTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New showAllQuotesTableAdapters.ShowAllQuotesTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As showAllQuotes.ShowAllQuotesDataTable        'Return Adapter.GetCandiData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

   

End Class
