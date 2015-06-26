
Partial Class moderators_approveLead
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        Dim rtn As Integer = 0
        sql = "update profile set pstatus='Approved' where pid=" & Request.QueryString("id") & ""
        rtn = cf.TaskmembSql(sql)
        If rtn > 0 Then
            Label1.Text = "Updated Main Profile"
        End If
        sql = "update topearners set pstatus='Approved' where referd=" & Request.QueryString("id") & ""
        rtn = cf.TaskmembSql(sql)
        If rtn > 0 Then
            Label2.Text = "Updated affmoney"
        End If
    End Sub
End Class
