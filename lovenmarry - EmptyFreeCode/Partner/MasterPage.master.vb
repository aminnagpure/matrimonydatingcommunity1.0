
Partial Class Partner_MasterPage
    Inherits System.Web.UI.MasterPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TH1.InnerHtml = "<font size='5'>" & kkkkkkk.websitename & "</font> <br><font size='2'>" & kkkkkkk.subtitle & "</font>"

        If Request.QueryString("affid") <> "" Then
            Response.Cookies("referby").Value = Request.QueryString("affid")
            Response.Cookies("referby").Expires = DateTime.Now.AddDays(60)

        End If
        'If Session("pid") Is Nothing Then
        '    Response.Redirect("~/login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri)
        'End If


        If Session("mrole") = "mod" Then
            modmenu.Visible = True
        Else
            modmenu.Visible = False
        End If


        '  Randomize()

    End Sub

    Protected Sub MemberLoginStatus_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberLoginStatus.LoggedOut
        Session("pid") = Nothing
        Session("fname") = ""
        Session("approved") = ""
        Session("lname") = ""
        Session("susp") = ""
        Session("validmobile") = ""
        Session("sex") = ""
        Session("mrole") = ""
        Session.Clear()
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub



End Class

