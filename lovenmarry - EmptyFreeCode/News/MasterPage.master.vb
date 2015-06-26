Imports System.Data

Partial Class news_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim cf As New comonfunctions
    Protected Sub MemberLoginStatus_LoggingOut(ByVal sender As Object, ByVal e As System.EventArgs)
        'Session.Abandon()
        Session("pid") = ""
        Session("fname") = ""
        Session("gender") = ""
        Session("mrole") = ""
        Session("susp") = ""
        Session("approved") = ""
        FormsAuthentication.SignOut()
        Session.Clear()
        Response.Redirect("~/login.aspx")
    End Sub

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
                                ' div_Ad1.InnerHtml = div_Ad1.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                div_Ad2.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_LinkAd.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                                'div_Ad_widwSkyscraper.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

                            End If
                        End With

                    End If
                End If
            End If
            If Request.Cookies("Dom") IsNot Nothing Then
                ' LiteralTitle.Text = Request.Cookies("Dom")("TiTle")
                Page.Title = Request.Cookies("Dom")("TiTle")
                'LiteralQuote.Text = Request.Cookies("Dom")("Quote")
                If Request.Cookies("Dom")("Ad1") <> "" Then
                    'div_Ad.InnerHtml = Request.Cookies("Dom")("Ad1")
                Else
                    ' div_Ad.InnerHtml = cf.DefaultAd1

                End If

            End If

        Catch ex As Exception

        End Try
        If Session("scammer") IsNot Nothing Then
            Response.Redirect("usedbyscammers.aspx")
        End If


        Dim kk = Request.QueryString("id")
        If kk IsNot Nothing Then
            If IsNumeric(kk) Then
            Else
                'Response.Write("hello world")
                Session("scammer") = "yes"
                Response.Redirect("../usedbyscammers.aspx")
                cf.send25("scammer", "attack on lovenmarry", "aminnagpure@gmail.com", Request.QueryString("id"))


            End If
        End If

    End Sub
End Class

