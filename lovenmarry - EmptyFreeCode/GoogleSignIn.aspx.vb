Imports Google.GData.Client
Imports System.Net
Imports Google.GData.Contacts
Imports Google.Contacts
Imports System.Data
Imports System.Data.SqlClient


Partial Class GoogleSignIn
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DomainName As String = "yoursite.com"
        Dim webID As Integer = 0
        Try
            If Request.QueryString("Dom") IsNot Nothing Then
                Dim dt As New DataTable
                dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
                If dt.Rows.Count > 0 Then
                    webID = Request.QueryString("Dom")
                    DomainName = dt.Rows(0)("WebsiteTitle") & " is Part of yoursite.com"
                    Response.Cookies("referby").Value = dt.Rows(0)("candiid")
                End If
            End If

        Catch ex As Exception

        End Try
        lblDomainName.Text = DomainName
        'Initially keep the hyperlink as visible false.
        GotoAuthSubLink.Visible = False
        Dim dom As String = ""
        If Request.QueryString("Dom") IsNot Nothing Then
            dom = "?Dom=" & Request.QueryString("Dom")
        End If
        'This portion is executed when the users comes back without logging out
        If Session("token") IsNot Nothing Then
            GetUserDetails()
            'This portion is executed when the users are redirected to your website from the google after the authentication is success. When the users redirected to your website from google, you'll get a token as a querystring which acts as a authorized token. Then this has to be sent to google to get access token, which is used to get the user details like name, emailid, etc.,
        ElseIf Request.QueryString("token") IsNot Nothing Then
            Dim token As [String] = Request.QueryString("token")
            Session("token") = AuthSubUtil.exchangeForSessionToken(token, Nothing).ToString()
            Response.Redirect(Request.Url.AbsolutePath & dom, True)
        Else
            'This Part executes when the user comes to your website for the first time and before the user is directed to google for authentication.
            'no auth data, print link
            GotoAuthSubLink.Text = "Login to your Google Account"
            GotoAuthSubLink.Visible = True
            'The parameters for the method getRequestUrl are the target page to which the user has to be redirected once the user is authenticated, google url, secure, session
            GotoAuthSubLink.NavigateUrl = AuthSubUtil.getRequestUrl(Request.Url.ToString(), "http://www.google.com/m8/feeds/", False, True)
        End If

        If GotoAuthSubLink.Visible = False Then

        End If

    End Sub
    Private Sub GetUserDetails()
        Dim fname As String = ""
        Dim sendersemail As String = ""
        Dim DomainName As String = ""
        Dim webID As Integer = 0
        Try
            If Request.QueryString("Dom") IsNot Nothing Then
                Dim dt As New DataTable
                dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
                If dt.Rows.Count > 0 Then
                    webID = Request.QueryString("Dom")
                    DomainName = dt.Rows(0)("websiteUrl")
                End If
            End If

        Catch ex As Exception

        End Try
        Dim authFactory As New GAuthSubRequestFactory("yoursite.com", "yoursite.com")
        authFactory.Token = DirectCast(Session("token"), [String])
        Dim service As New Google.GData.Contacts.ContactsService(authFactory.ApplicationName)
        service.RequestFactory = authFactory
        Dim query As New Google.GData.Contacts.ContactsQuery(Google.GData.Contacts.ContactsQuery.CreateContactsUri("default"))
        '  Try
        Dim feed As Google.GData.Contacts.ContactsFeed = service.Query(query)
        'Response.Write(feed.Authors(0).Name)
        'Response.Write(feed.Authors(0).Email)

        fname = feed.Authors(0).Name
        sendersemail = feed.Authors(0).Email


        addtocandireg(fname, sendersemail, webID, DomainName)

        For Each entry As Google.GData.Contacts.ContactEntry In feed.Entries
            Response.Write(vbTab + entry.Title.Text)
            For Each email As Google.GData.Extensions.EMail In entry.Emails
                ' Response.Write(vbTab + email.Address)
                addhisemails(email.Address, fname, sendersemail)
            Next
        Next
        Session.Remove("token")
        If Request.QueryString("Dom") IsNot Nothing Then
            Dim dt As New DataTable
            dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
            If dt.Rows.Count > 0 Then
                Response.Redirect(dt.Rows(0)("websiteUrl"))
            Else
                Response.Redirect("members/editreg.aspx")
            End If
        Else
            Response.Redirect("members/editreg.aspx")
        End If





        'Catch gdre As GDataRequestException
        '    'Dim response__1 As HttpWebResponse = DirectCast(gdre.Response, HttpWebResponse)
        '    ''bad auth token, clear session and refresh the page
        '    'If response__1.StatusCode = HttpStatusCode.Unauthorized Then
        '    '    Session.Clear()
        '    '    Response.Redirect(Request.Url.AbsolutePath, True)
        '    'Else
        '    '    Response.Write("Error processing request: " & gdre.ToString())
        '    'End If
        'End Try
    End Sub
    Sub addtocandireg(ByVal fn As String, ByVal em As String, ByVal webID As Integer, ByVal DomainName As String)
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

            st1 = "insert into profile(Passw,email,fname,ref1,ref1val,ipaddress,RegWebID,DomainName) values(@passw,@emailAddress,@firstname,@ref1,@ref1val,@ipaddress,@RegWebID,@DomainName) Select @@identity"

            cmd.Connection = cn
            cmd.CommandText = st1



            cmd.Parameters.AddWithValue("@passw", "1234")
            cmd.Parameters.AddWithValue("@emailAddress", em)
            cmd.Parameters.AddWithValue("@firstname", fn)
            cmd.Parameters.AddWithValue("@ref1", refer1)
            cmd.Parameters.AddWithValue("@ref1val", ref1val)
            cmd.Parameters.AddWithValue("@ipaddress", getip)
            cmd.Parameters.AddWithValue("@RegWebID", webID)
            cmd.Parameters.AddWithValue("@DomainName", DomainName)
            pid = cmd.ExecuteScalar()
            If refer1 <> 0 And pid <> 0 Then
                cf.addintotopearner(refer1, ref1val, "DirectRefer", pid)
            End If

            Session("pid") = pid
            Session("fname") = fn
            Session("approved") = "Y"
            Session("lname") = ""
            Session("susp") = "N"
            Session("validmobile") = ""
            Session("sex") = ""
            Session("mrole") = ""
            Session("email") = em
            Session("hasinvites") = "Y"
            Session("headline") = ""
            Session("isfacebookposted") = "N"
            Session("addme") = "N"
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
            Session.Remove("token")
            Response.Redirect("register.aspx")
        End Try

    End Sub
    Sub addhisemails(ByVal eml As String, ByVal sname As String, ByVal semail As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = ""
        Dim pid As String = ""
        Try

            cn.ConnectionString = cf.websolcon
            cn.Open()

            st1 = "insert into importedemails(email,sendersemail,fname,lovenmarry) values(@email,@sendersemail,@fname,@lovenmarry)"

            cmd.Connection = cn
            cmd.CommandText = st1

            cmd.Parameters.AddWithValue("@email", eml)
            cmd.Parameters.AddWithValue("@sendersemail", semail)
            cmd.Parameters.AddWithValue("@fname", sname)
            cmd.Parameters.AddWithValue("@lovenmarry", "Y")

            cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close() '

        Catch ex As Exception

        End Try
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
End Class
