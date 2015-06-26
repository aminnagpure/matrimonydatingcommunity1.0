
Partial Class addjid
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strs As String = ""
        strs = "insert into jeevansathiids(email) values('" & TextBox1.Text & "')"
        cf.TaskmembSql(strs)

    End Sub
End Class
