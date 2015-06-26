Imports System.Data

Partial Class members_DefaultMaster
    Inherits System.Web.UI.MasterPage
    Dim cf As New comonfunctions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TH1.InnerHtml = "<font size='5'>" & kkkkkkk.websitename & "</font> <br><font size='2'>" & kkkkkkk.subtitle & "</font>"
        Try
            If Request.QueryString("Dom") IsNot Nothing Then
                If Request.Cookies("Dom") Is Nothing Then

                    Dim dt As New DataTable
                    dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
                    If dt.Rows.Count > 0 Then
                        With dt
                            Response.Cookies("Dom")("ID") = .Rows(0)("WebID")
                            Response.Cookies("Dom")("TiTle") = .Rows(0)("WebsiteTitle")
                            Response.Cookies("Dom")("Quote") = .Rows(0)("WebsitePunchline")
                            If .Rows(0)("pub_id") <> "" Then
                                'div_Ad1.InnerHtml = div_Ad1.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_ad2.InnerHtml = div_ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                ' div_LinkAd.InnerHtml = div_ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_Ad_widwSkyscraper.InnerHtml = div_ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

                            End If
                        End With

                    End If
                End If
            End If
            If Request.Cookies("Dom") IsNot Nothing Then
                'LiteralTitle.Text = Request.Cookies("Dom")("TiTle")
                Page.Title = Request.Cookies("Dom")("TiTle")
                'LiteralQuote.Text = Request.Cookies("Dom")("Quote")
            End If

        Catch ex As Exception

        End Try
        If Request.QueryString("affid") <> "" Then
            Response.Cookies("referby").Value = Request.QueryString("affid")
            Response.Cookies("referby").Expires = DateTime.Now.AddDays(60)

        End If
        If Session("pid") Is Nothing Then
            Response.Redirect("~/login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri)
        End If


        If Session("mrole") = "mod" Then
            modmenu.Visible = True
        Else
            modmenu.Visible = False
        End If


        '  Randomize()
        GetSummary()


    End Sub

    Protected Sub MemberLoginStatus_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberLoginStatus.LoggedOut

        Try
            Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
            Dim L As New LoginIds
            L.Fname = Session("fname")
            L.PID = Session("pid")
            Logins = Application("Ids")
            Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
            If b Then
                Logins.Remove(Logins.Find(Function(x) x.PID.Contains(L.PID)))
            End If
            Application("Ids") = Logins
        Catch ex As Exception

        End Try


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
    Sub GetSummary()
        Try

            'If Session("FB_ID") IsNot Nothing Then
            '    If Session("FB_ID") = "" Then
            '        Lit_Connect_With_FB.Text = "<p></p><div class=""sky-form""><a href=""isfacebookposted.aspx"" class=""button""><i class=""fa fa-fw fa-facebook""></i>Sync With Facebook</a></div>" '"<a class=""btn btn-s-md btn-primary btn-rounded"" href=""isfacebookposted.aspx"">Connect With FB</a>"
            '    End If
            'End If
            'If Session("GPlusUrl") IsNot Nothing Then
            '    If Session("GPlusUrl") = "" Then
            '        Lit_Connect_With_GPlus.Text = "<div class=""sky-form""><a href=""../PlusSignIn.aspx"" class=""button ""><i class=""fa fa-fw fa-google-plus""></i>Sync With Google+</a><p></p></div>"
            '    End If
            'End If
        Catch ex As Exception

        End Try



    End Sub





    Protected Sub MemberLoginStatus_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles MemberLoginStatus.LoggingOut

    End Sub
End Class

