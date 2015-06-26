
Partial Class moderators_logout
    Inherits System.Web.UI.Page
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Session("username") = ""
        Session("role") = ""
        Response.Redirect("../default.aspx")
        Session("pid") = ""
        Session.Abandon()
    End Sub
End Class
