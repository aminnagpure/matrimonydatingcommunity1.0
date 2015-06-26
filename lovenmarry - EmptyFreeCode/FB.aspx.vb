Imports System.Collections.Generic
Imports System.Net
Imports System.IO
Imports Facebook


Partial Class FB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CheckAuthorization()
    End Sub

    Private Sub CheckAuthorization()
        Dim app_id = "378178345583448"
        Dim app_secret = "8202ecb2def5a960985ee8fbb4e1c1a6"
        'Dim app_id = "223111424507846"
        'Dim app_secret = "50e82d24056388d88dad88f0ab969a1f"
        Dim scope = "publish_stream,manage_pages"

        If Request("code") Is Nothing Then
            Response.Redirect(String.Format(
                "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                app_id, Request.Url.AbsoluteUri, scope))
        Else
            Dim tokens As New Dictionary(Of String, String)


            Dim url = String.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request("code").ToString(), app_secret)
            Dim Wrequest As HttpWebRequest = WebRequest.Create(url)

            Using response As HttpWebResponse = Wrequest.GetResponse



                Dim reader As StreamReader = New StreamReader(response.GetResponseStream())

                Dim vals As String = reader.ReadToEnd()

                Dim token As String
                For Each token In vals.Split("&"c)
                    'meh.aspx?token1=steve&token2=jake&...
                    tokens.Add(token.Substring(0, token.IndexOf("=")),
                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1))
                Next
            End Using

            Dim access_token As String = tokens("access_token")

            Dim client = New FacebookClient(access_token)
            Dim reqparm As New Specialized.NameValueCollection
            reqparm.Add("message", "Hello Friends")
            client.Post("/me/feed", New With {.message = "Just Joined  http://www.fastfastmoney.com "})

        End If
    End Sub

End Class
