
Partial Class moderators_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim kkkkk As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("mrole") <> "mod" Then
            Response.Redirect("../login.aspx")
        End If
        'Session("username") = myreader.GetString(1).ToString
        'Session("role") = myreader.GetString(2).ToString
        'TH1.InnerHtml = "<font size='5'>" & kkkkk.websitename.ToString & "</font> <br><font size='2'>" & kkkkk.subtitle.ToString & "</font>"
    End Sub

   
    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("pid") = Nothing
        Session("fname") = ""
        Session("approved") = ""
        Session("lname") = ""
        Session("susp") = ""
        Session("validmobile") = ""
        Session("sex") = ""
        Session("mrole") = ""
        Session.Abandon()
        Response.Redirect("../default.aspx")

    End Sub
End Class

