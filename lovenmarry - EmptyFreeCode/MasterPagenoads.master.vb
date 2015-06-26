Imports System.Data

Partial Class MasterPagenoads
    Inherits System.Web.UI.MasterPage
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Request.QueryString("Dom") IsNot Nothing Then
            '    If Request.Cookies("Dom") Is Nothing Then

            Dim dt As New DataTable
            dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
            If dt.Rows.Count > 0 Then
                With dt
                    Response.Cookies("Dom")("ID") = .Rows(0)("WebID")
                    Response.Cookies("Dom")("TiTle") = .Rows(0)("WebsiteTitle")
                    Response.Cookies("Dom")("Quote") = .Rows(0)("WebsitePunchline")
                    Response.Cookies("Dom")("Ad1") = .Rows(0)("pub_id")
                    If .Rows(0)("pub_id") <> "" Then
                        'div_Ad1.InnerHtml = div_Ad1.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        'div_Ad2.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        'div_LinkAd.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        'div_Ad_widwSkyscraper.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

                    End If
                End With

            End If
            '    End If
            'End If
            Dim affid As String = ""
            Try
                If Request.QueryString("affid") <> "" Then

                    affid = "&affid=" & Request.QueryString("affid")

                End If
            Catch ex As Exception

            End Try
            'Dim RegLink As HyperLink = LoginView.FindControl("RegisterLink")
            'RegLink.NavigateUrl = "http://www.yoursite.com/GoogleSignin.aspx?Dom=1" & affid
            'RegLink.Target = "_blank"

            If Request.Cookies("Dom") IsNot Nothing Then
                ' LiteralTitle.Text = Request.Cookies("Dom")("TiTle")
                Page.Title = Request.Cookies("Dom")("TiTle")
                'LiteralQuote.Text = Request.Cookies("Dom")("Quote")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Function getsessionid() As String
        'Dim strpid As String = ""
        getsessionid = ""

        'Try
        'strpid = CType(Session("pid"), String)
        'Catch ex As Exception
        'strpid = ""
        'End Try

    End Function

    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.EventArgs)
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


    End Sub
End Class

