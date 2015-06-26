Imports Microsoft.VisualBasic
Imports topicrepliesTableAdapters.getTopicAnswerTableAdapter

<System.ComponentModel.DataObject()> _
 Public Class clstopicreplies
    Private _productsAdapter As topicrepliesTableAdapters.getTopicAnswerTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As topicrepliesTableAdapters.getTopicAnswerTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New topicrepliesTableAdapters.getTopicAnswerTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As topicreplies.getTopicAnswerDataTable
        'Return Adapter.GetData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

 
End Class
