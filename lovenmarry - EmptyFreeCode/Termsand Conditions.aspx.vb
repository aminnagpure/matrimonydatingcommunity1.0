
Partial Class Termsand_Conditions
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tdip.InnerHtml = "We Track Each and Every Visitor Your Ip Address is " & Request.ServerVariables("REMOTE_ADDR")
        Label1.Text = cf.websitename
    End Sub
End Class
