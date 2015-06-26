Imports Microsoft.VisualBasic
Imports PendingFriendshipRequestTableAdapters.pendingfriendshipRequestTableAdapter
<System.ComponentModel.DataObject()> _
Public Class clspendingFriendsRequest
    Private _productsAdapter As PendingFriendshipRequestTableAdapters.pendingfriendshipRequestTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As PendingFriendshipRequestTableAdapters.pendingfriendshipRequestTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New PendingFriendshipRequestTableAdapters.pendingfriendshipRequestTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal sq As String) As PendingFriendshipRequest.pendingfriendshipRequestDataTable
        Return Adapter.GetPendingFriendsRequests(startRowIndex, TotalNumberOfProducts(sq), sq)
    End Function

    Public Function TotalNumberOfProducts(ByVal sq As String) As Integer
        Return Adapter.pendingfriendshipRequestCount(sq)
    End Function
End Class
