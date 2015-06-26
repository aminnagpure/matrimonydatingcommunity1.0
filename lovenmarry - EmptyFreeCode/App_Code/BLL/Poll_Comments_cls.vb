Imports Microsoft.VisualBasic
Imports Poll_CommentsTableAdapters.polecommentsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class Poll_Comments_cls
    Private _productsAdapter As Poll_CommentsTableAdapters.polecommentsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As Poll_CommentsTableAdapters.polecommentsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New Poll_CommentsTableAdapters.polecommentsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal mid As Integer, ByVal UID As Integer, ByVal startRowIndex As Integer, ByVal maximumRows As Integer) As Poll_Comments.polecommentsDataTable      'Return Adapter.GetCandiData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(mid, UID, startRowIndex, 120)
    End Function




End Class
