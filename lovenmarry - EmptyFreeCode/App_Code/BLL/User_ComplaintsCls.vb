Imports Microsoft.VisualBasic
Imports User_ComplaintsTableAdapters.User_Complaints_getTableAdapter

<System.ComponentModel.DataObject()> _
Public Class User_ComplaintsCls
    Private _productsAdapter As User_ComplaintsTableAdapters.User_Complaints_getTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As User_ComplaintsTableAdapters.User_Complaints_getTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New User_ComplaintsTableAdapters.User_Complaints_getTableAdapter

            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As User_Complaints.User_Complaints_getDataTable
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function

End Class
