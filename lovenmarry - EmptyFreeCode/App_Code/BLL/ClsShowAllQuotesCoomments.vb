Imports Microsoft.VisualBasic
Imports ShowAllQuotesCoommentsTableAdapters.ShowAllQuotesCommentsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class ClsShowAllQuotesCoomments
    Private _productsAdapter As ShowAllQuotesCoommentsTableAdapters.ShowAllQuotesCommentsTableAdapter = Nothing


    Protected ReadOnly Property Adapter() As ShowAllQuotesCoommentsTableAdapters.ShowAllQuotesCommentsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ShowAllQuotesCoommentsTableAdapters.ShowAllQuotesCommentsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As ShowAllQuotesCoomments.ShowAllQuotesCommentsDataTable
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

 
End Class
