
Partial Class members_addme
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsql As String = ""
        strsql = "update [profile] set addme='Y' where pid=" & Session("pid")
        cf.TaskmembSql(strsql)
        Session("addme") = "Y"
    End Sub
End Class
