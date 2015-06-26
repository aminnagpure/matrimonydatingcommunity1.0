Imports System.Data

Partial Class poll_MasterPageWOLogin
    Inherits System.Web.UI.MasterPage
    Dim cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                                'div_Ad2.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_LinkAd.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_Ad_widwSkyscraper.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

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
        If Not Page.IsPostBack Then

            If Request.QueryString("affid") <> "" Then
                Response.Cookies("referby").Value = Request.QueryString("affid")
                Response.Cookies("referby").Expires = DateTime.Now.AddDays(60)

            End If


            If Session("mrole") = "mod" Then
                modmenu.Visible = True
            Else
                modmenu.Visible = False
            End If


            '  Randomize()
        End If

    End Sub
    Protected Sub MemberLoginStatus_LoggingOut(ByVal sender As Object, ByVal e As System.EventArgs)
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

        Response.Redirect("~/login.aspx")
    End Sub

End Class

