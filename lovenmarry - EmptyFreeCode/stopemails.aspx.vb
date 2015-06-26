
Partial Class stopemails
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rtn As String = ""
        Dim sql As String = ""
        sql = "update invites set isdeleted='Y' where email='" & TextBox1.Text & "'"
        rtn = cf.TaskmembSql(sql)

        If rtn > 0 Then
            Label2.Text = "Email Blocked Sucessfully"
        Else
            Label2.Text = "Email Address not found, kindly contact us using contact us page"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim rtn As String = ""
        'Dim sql As String = ""
        ''sql = "select email from invites where inviteid=" & Request.QueryString("id")
        ''rtn = cf.CountRs(sql)
        ''  TextBox1.Text = Request.QueryString("email")
    End Sub
End Class
