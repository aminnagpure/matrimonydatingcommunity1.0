
Partial Class stopinvites
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rtn As String = ""
        Dim sql As String = ""
        sql = "update [profile] set isbouncing=1 where email='" & TextBox1.Text & "'"
        rtn = cf.TaskmembSql(sql)
        ' Response.Write(sql)

        If rtn > 0 Then
            Label2.Text = "Email Blocked Sucessfully"
        Else
            Label2.Text = "Email Address not found, kindly contact us using contact us page"
        End If
    End Sub

End Class
