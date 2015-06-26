Imports Microsoft.VisualBasic
Imports awaitingMembersTableAdapters.waitingmembersTableAdapter

<System.ComponentModel.DataObject()> _
Public Class awaiting_Members_cls

    Private _productsAdapter As awaitingMembersTableAdapters.waitingmembersTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As awaitingMembersTableAdapters.waitingmembersTableAdapter
        Get
            If _productsAdapter Is Nothing Then
                _productsAdapter = New awaitingMembersTableAdapters.waitingmembersTableAdapter
            End If
            Return _productsAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, False)> _
    Public Function GetProductsPaged(ByVal startRowIndex As Integer, ByVal maximumRows As Integer, ByVal jointype As String, ByVal sq As String, ByVal candiid As Integer) As awaitingMembers.waitingmembersDataTable
        Return Adapter.GetData(startRowIndex, 120, jointype, sq, candiid)

    End Function

End Class
