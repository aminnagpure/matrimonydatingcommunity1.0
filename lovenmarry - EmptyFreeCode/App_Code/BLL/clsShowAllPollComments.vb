Imports Microsoft.VisualBasic
Imports ShowAllPollCommentsTableAdapters.ShowAllpollcommentsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class clsShowAllPollComments
    Private _productsAdapter As ShowAllPollCommentsTableAdapters.ShowAllpollcommentsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As ShowAllPollCommentsTableAdapters.ShowAllpollcommentsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New ShowAllPollCommentsTableAdapters.ShowAllpollcommentsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As ShowAllPollComments.ShowAllpollcommentsDataTable        'Return Adapter.GetCandiData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

End Class
