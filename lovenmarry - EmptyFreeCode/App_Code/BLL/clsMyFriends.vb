Imports Microsoft.VisualBasic
Imports myfriendsTableAdapters.myfriendsTableAdapter
<System.ComponentModel.DataObject()> _
Public Class clsMyFriends
    Private _productsAdapter As myfriendsTableAdapters.myfriendsTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As myfriendsTableAdapters.myfriendsTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New myfriendsTableAdapters.myfriendsTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As myfriends.myfriendsDataTable

        Return Adapter.GetFriends(startRowIndex, TotalNumberOfProducts(sq), sq)
    End Function

    Public Function TotalNumberOfProducts(ByVal sq As String) As Integer
        Return Adapter.myfriendsCount(sq)
    End Function
End Class
