
Partial Class moderators_PartnersSite
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Approve" Then
            cf.TaskmembSql("Update Datingsite set IsApprove='Y' where candiid=" & e.CommandArgument)
            GridView1.DataSourceID = SqlDataSource1.ID
        End If
    End Sub
End Class
