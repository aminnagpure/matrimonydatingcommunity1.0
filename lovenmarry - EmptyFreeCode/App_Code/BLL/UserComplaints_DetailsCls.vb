Imports Microsoft.VisualBasic
Imports UserComplaints_DetailsTableAdapters.User_Complaints_Comments_getTableAdapter

<System.ComponentModel.DataObject()> _
Public Class UserComplaints_DetailsCls

    Private _productsAdapter As UserComplaints_DetailsTableAdapters.User_Complaints_Comments_getTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As UserComplaints_DetailsTableAdapters.User_Complaints_Comments_getTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New UserComplaints_DetailsTableAdapters.User_Complaints_Comments_getTableAdapter

            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As UserComplaints_Details.User_Complaints_Comments_getDataTable
        Return Adapter.GetData(startRowIndex, 120, sq)
    End Function
End Class
