Imports System.Data.SqlClient
Imports Facebook
Imports System.Net
Imports System.IO

Partial Class FBReg
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

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
            End Select
        Next

        If email <> "" Then
            addtocandireg(first_name, email, last_name, id)
            Response.Redirect("members/Default.aspx")
        Else
            ' Response.Write(v.ToString)
        End If
    End Sub


    Sub addtocandireg(ByVal fn As String, ByVal em As String, ByVal last_name As String, ByVal fbid As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt

        Try
            Dim refer1 As Integer = 0
            Dim ref1val As Integer = 0
            If Request.Cookies("referby") Is Nothing Then
                refer1 = 0
                ref1val = 0
            Else
                If IsNumeric(Request.Cookies("referby").Value) Then
                    refer1 = Request.Cookies("referby").Value
                Else
                    refer1 = 0
                End If

                ref1val = cf.ref1val
                If Not IsNumeric(ref1val) Then
                    ref1val = 0
                End If
            End If


            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            st1 = "insert into profile(Passw,email,fname,lname,ref1,ref1val,ipaddress,FB_id) values(@passw,@emailAddress,@firstname,@lname,@ref1,@ref1val,@ipaddress,@FB_id) Select @@identity"

            cmd.Connection = cn
            cmd.CommandText = st1



            cmd.Parameters.AddWithValue("@passw", "1234")
            cmd.Parameters.AddWithValue("@emailAddress", em)
            cmd.Parameters.AddWithValue("@firstname", fn)
            cmd.Parameters.AddWithValue("@ref1", refer1)
            cmd.Parameters.AddWithValue("@ref1val", ref1val)
            cmd.Parameters.AddWithValue("@ipaddress", getip)
            cmd.Parameters.AddWithValue("@lname", last_name)
            cmd.Parameters.AddWithValue("@FB_id", fbid)

            pid = cmd.ExecuteScalar()
            If refer1 <> 0 And pid <> 0 Then
                cf.addintotopearner(refer1, ref1val, "DirectRefer", pid)
            End If

            Session("pid") = pid
            Session("fname") = fn
            Session("approved") = "N"
            Session("lname") = ""
            Session("susp") = "N"
            Session("validmobile") = ""
            Session("sex") = ""
            Session("mrole") = ""
            Session("email") = em
            Session("hasinvites") = "Y"
            Session("headline") = ""
            Session("isfacebookposted") = "N"
            cmd.Dispose()
            cn.Close()

            FormsAuthentication.SetAuthCookie(em, False)

            '// send email
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Dear " & fn & " &nbsp;</td>"
            regmsg = regmsg & "  </tr>"
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Thank you for Registering with us,</td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "<tr>"

            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='20%'>Username :</td>"
            regmsg = regmsg & "<td width='80%'><font color='#FF0000'>" & em & "</font></td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "      <tr>"
            regmsg = regmsg & "        <td align=left>Password :</td>"
            regmsg = regmsg & "        <td align=left><font color='#FF0000'>" & "1234" & "</font><br><br> kindly login and change your password</td>"
            regmsg = regmsg & "</tr>"

            regmsg = regmsg & "   <tr> <td width='100%' height='19' colspan='2' align='center'>&nbsp;</td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Best Luck in Your Search"
            regmsg = regmsg & " </td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "<tr>"

            regmsg = regmsg & "    <td width='100%' height='19' colspan='2' align='center'>&nbsp;</td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Welcome To " & cf.websitename & " <br>"
            regmsg = regmsg & " http://www." & cf.websitename & " </td>"
            regmsg = regmsg & "</tr>"

            rzlt = cf.send25("reg", "Thakyou For Registration", em, regmsg.ToString)
            SendmailtoUser(fn, em)

        Catch ex As Exception
            'Response.Write(em)
            'Response.Write(fn)
            'Response.Write(ex.Message)
            'Response.Redirect("register.aspx")
        End Try

    End Sub
    Sub SendmailtoUser(ByVal fname As String, ByVal toemail As String)
        Dim str As String = ""
        str += "Dear " & fname & "<br /><br />"
        str += "<ul>"
        str += "<li><b>Photo:</b> Add a photo of yourself. People want to know you. friendly photos are helpful in establishing a relationship. (<a href='http://www.yoursite.com/members/uploadphoto.aspx'>Add now</a>).</li>"
        str += "<li><b>Your Details:</b> Update your profile with your details that will help others to find you and know more about you. (<a href='http://www.yoursite.com/members/editreg.aspx'>Add now</a>)</li>"
        'str += "<li><b>Employment History:</b> List your past jobs and internships here. Briefly list your previous responsibilities and achievements. If you have worked for well-known companies, be sure to mention them. (<a href='http://www.websolatwork.com/jobseekers/MyProfile.aspx'>Add now</a>)</li>"
        'str += "<li><b>Projects:</b> Add your project you have done earlier. Mention project URL if possible.</li>"
        str += "</ul>"

        cf.send25("Admin", "Update Your Profile", toemail, str)

        str = ""
        str += "<h3><a href='http://www.yoursite.com/members/Tutorials.aspx'>Watch view tutorials to learn more</h3>"

        cf.send25("Admin", "Learn How to Earn More money", toemail, str)

    End Sub
    Function getip() As String
        Dim ip As String = ""
        Try
            ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If Not String.IsNullOrEmpty(ip) Then
                Dim ipRange As String() = ip.Split(","c)
                Dim le As Integer = ipRange.Length - 1
                Dim trueIP As String = ipRange(le)
            Else
                ip = Request.ServerVariables("REMOTE_ADDR")
            End If

        Catch ex As Exception

        End Try
        getip = ip

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CheckAuthorization()
        End If
    End Sub
    Private Sub CheckAuthorization()
        'Dim app_id = "223111424507846" '"404461319606517"
        'Dim app_secret = "50e82d24056388d88dad88f0ab969a1f" '"2b345694dc30de1f7cc49756b8ccccd2"
        Dim app_id = "404461319606517"
        Dim app_secret = "2b345694dc30de1f7cc49756b8ccccd2"
        Dim scope = "publish_stream,manage_pages,email"

        If Request("code") Is Nothing Then
            Response.Redirect(String.Format(
                "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                app_id, Request.Url.AbsoluteUri, scope))  '& "&ref=facebook"
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

            'client.Post("/me/feed", New With {.message = "Just Joined  ", .picture = "http://jobdhundo.com/logo/Logo.jpg", .description = "Job Search For Freshers", .link = "http://www.jobdhundo.com?ref=facebook"})
            Dim v = client.Get("/me?fields=id,name,email,first_name,last_name") ', New With {.feilds = "id,name,email"})
            AddFacebookData(v)
            'Response.Redirect("De")
        End If
    End Sub
End Class
