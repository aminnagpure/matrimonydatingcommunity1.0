Imports Microsoft.VisualBasic
Imports PollLoadTableAdapters.ShowAllPollsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class ClsShowAllPoll
    Private _productsAdapter As PollLoadTableAdapters.ShowAllPollsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As PollLoadTableAdapters.ShowAllPollsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New PollLoadTableAdapters.ShowAllPollsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As PollLoad.ShowAllPollsDataTable        'Return Adapter.GetCandiData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

    

End Class
