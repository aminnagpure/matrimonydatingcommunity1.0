Imports Microsoft.VisualBasic
Imports forumtopicsTableAdapters.getTopicsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class clsForumtopics
    Private _productsAdapter As forumtopicsTableAdapters.getTopicsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As forumtopicsTableAdapters.getTopicsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New forumtopicsTableAdapters.getTopicsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As forumtopics.getTopicsDataTable
        'Return Adapter.Getforumtopics(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

    

End Class
