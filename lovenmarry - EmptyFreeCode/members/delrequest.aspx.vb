
Partial Class members_delrequest
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim sql As String = ""
        Dim rtn As Integer = 0
        sql = "delete from friendshiprequest where fidreq=" & Request.QueryString("id") & ""
        rtn = cf.TaskmembSql(sql)
        If rtn > 0 Then
            Label1.Text = "Friend Deleted Successfully"
            LinkButton1.Text = ""
        End If
    End Sub
End Class
