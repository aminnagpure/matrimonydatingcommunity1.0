
Partial Class moderators_listofsuspended
    Inherits System.Web.UI.Page

    Public cf As comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = " susp='Y'"
        txtjointype.Text = "left join"
    End Sub
End Class
