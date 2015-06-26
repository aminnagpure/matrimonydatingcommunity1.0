Imports System.Collections.Generic
Imports System.Net
Imports System.IO
Imports Facebook
Imports System.Web.Script.Serialization

Partial Class jobseekers_isfacebookposted
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            
            CheckAuthorization()
            
            Response.Redirect("default.aspx")
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    'CheckAuthorization()
    'End Sub
    Private Sub CheckAuthorization()
        Dim app_id = "404461319606517"
        Dim app_secret = "2b345694dc30de1f7cc49756b8ccccd2"
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


            client.Post("/me/feed", New With {.message = "Just Joined  ", .picture = "http://www.yoursite.com/SM63826.jpg", .description = "Love and Marry", .link = "http://www.yoursite.com/FBReg.aspx?affid=" & Session("pid")})
            Session("isfacebookposted") = "Y"
            Dim strsql As String = ""
            strsql = "update [profile] set facebookpost='Y' where pid=" & Session("pid")
            cf.TaskmembSql(strsql)

            Dim v = client.Get("/me?fields=id,name,email,first_name,last_name") ', New With {.feilds = "id,name,email"})
            AddFacebookData(v)

        End If
        

    End Sub
    Sub AddFacebookData(ByVal v)
        'v = v.Replace("{", "")
        'v = v.Replace("}", "")
        'Dim strarrays() As String = v.Split(",")
        Dim mid As Integer = 0
        Try

        Catch ex As Exception

        End Try
        Dim s As String = v.ToString
        Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(s)
        Dim id As String = "" '100000328272034)
        Dim name As String = "" 'Amit Kumar Tiwari
        Dim email As String = "" '- tiwariamitkumar70@yahoo.com
        Dim username As String = ""
        Dim first_name As String = "" '- Amit Kumar
        Dim last_name As String = "" '(-Tiwari)


        For Each item As KeyValuePair(Of String, String) In dict
            Select Case item.Key
                Case Is = "id"
                    id = item.Value
                Case Is = "email"
                    email = item.Value
                Case Is = "first_name"
                    first_name = item.Value
                Case Is = "last_name"
                    last_name = item.Value
                Case Is = "username"
                    username = item.Value
            End Select
        Next

        If id <> "" Then
            Dim strquery As String = "Update profile set FB_ID='" & id & "' where pid=" & Session("pid")
            cf.Taskjobseeker(strquery)
            Session("FB_ID") = id
        Else
            ' Response.Write(v.ToString)
        End If
    End Sub
End Class
