Imports Microsoft.VisualBasic
Imports newscommentsTableAdapters.checkNewscommentsTableAdapter

<System.ComponentModel.DataObject()> _
Public Class clsnewscomments
    Private _productsAdapter As newscommentsTableAdapters.checkNewscommentsTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As newscommentsTableAdapters.checkNewscommentsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New newscommentsTableAdapters.checkNewscommentsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As newscomments.checkNewscommentsDataTable
        'Return Adapter.GetnewscommentData(startRowIndex, TotalNumberOfProducts(sq), sq)
        Return Adapter.Getnewscomments(startRowIndex, 120, sq)
    End Function

   

End Class
