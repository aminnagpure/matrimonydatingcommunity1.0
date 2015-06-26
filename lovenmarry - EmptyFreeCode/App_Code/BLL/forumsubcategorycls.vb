Imports Microsoft.VisualBasic
Imports forumsubmainTableAdapters.getSubCategoryTableAdapter

<System.ComponentModel.DataObject()> _
Public Class forumsubcategorycls
    Private _productsAdapter As forumsubmainTableAdapters.getSubCategoryTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As forumsubmainTableAdapters.getSubCategoryTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New forumsubmainTableAdapters.getSubCategoryTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As Integer) As forumsubmain.getSubCategoryDataTable
        '   sq = catid
        Return Adapter.GetData(sq)
    End Function
    'Public catid As Integer = 1


End Class
