Imports Microsoft.VisualBasic
Imports forumdefaultpageTableAdapters.forummainpageTableAdapter

<System.ComponentModel.DataObject()> _
Public Class forummainpagecls
    Private _productsAdapter As forumdefaultpageTableAdapters.forummainpageTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As forumdefaultpageTableAdapters.forummainpageTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New forumdefaultpageTableAdapters.forummainpageTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As forumdefaultpage.forummainpageDataTable
        'Return Adapter.GetData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

    

End Class
