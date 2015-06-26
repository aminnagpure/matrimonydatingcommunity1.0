Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Data
Imports System.Net
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing

Partial Class PlusSignIn
    Inherits System.Web.UI.Page
    Public Shared cf As New comonfunctions
    Public Shared IP As String = ""
    Shared refer1 As Integer = 0
    Shared ref1val As Integer = 0
    Public Shared email As String = ""
#Region "Cont"

    <WebMethod()> _
    Public Shared Function ReadContact(ByVal UD As Object) As String
        Try

            Dim dict() As Object = UD("feed")("entry")
            'Dim AllContact As List(Of UserDetails) = New List(Of UserDetails)
            Dim Sender As String = ""
            Try
                Sender = UD("feed")("author")(0)("email")("$t")
            Catch ex As Exception
                Sender = email
            End Try
            For Each o As Object In dict
                Dim cont As New UserDetails
                If o.ContainsKey("gd$email") Then
                    cont.email = o("gd$email")(0)("address") ' dicte(0)("address")
                    cont.fname = o("title")("$t") ' dict1("$t")
                    'AllContact.Add(cont)
                    addhisemails(cont, Sender)
                End If
                Dim dict1 As Dictionary(Of String, Object) = o("title")
            Next
            Return CreateDataSet("Done").GetXml
        Catch ex As Exception
            Return CreateDataSet(ex.Message & " Not Add").GetXml
        End Try
    End Function
#End Region
    <WebMethod()> _
    Public Shared Function ReadData(ByVal UD As Object) As String
        Return candiReg(UD).GetXml
    End Function
    Public Shared Function candiReg(ByVal UD As Object) As DataSet
        Dim D As UserDetails = New UserDetails()
        Try
            D.fname = UD("displayName")
            'Dim dict As Dictionary(Of String, Object) = UD("emails")(0)
            D.email = UD("emails")(0)("value")
            email = D.email
            Try
                D.gender = UD("gender")
            Catch ex As Exception
                D.gender = "Male"
            End Try
            ' D.photo = UD("image")("url")
            'D.cityname = UD("placesLived")(0)("value")
            Dim gender As String = D._gender
            Try
                D.photo = UD("image")("url")
            Catch ex As Exception

            End Try
            Try
                D.GPlusUrl = UD("url")
            Catch ex As Exception
                D.GPlusUrl = ""
            End Try
            Dim C As String = ""
            Try
                'Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
                'C = jss.Serialize(UD)
                C = UD("url")
                ' C = UD("objectType").TOString
            Catch ex As Exception
                C = ex.Message

            End Try
            ' D.dateofbirth = Format(D.dateofbirth, "dd/MM/yyyy hh:mm:ss tt")
            Dim i As Integer = Login(D)

            If i = 0 Then
                addtocandireg(D)
                Return CreateDataSet("New")
            Else
                Return CreateDataSet("Login")
            End If
            'Return CreateDataSet(i)
        Catch ex As Exception
            Dim msg As String = "IP : " & IP & "<br />"
            Try
                msg += UD("message") & "<br />"
            Catch ex1 As Exception

            End Try
            cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", ex.Message & msg)
            Return CreateDataSet(ex.Message)
        End Try
        'Return CreateDataSet(UD("ageRange")("min"))
        'CashLocv.Value = dict("HotelListResponse")("cacheLocation")
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.Server.ScriptTimeout = 500
        IP = getip()
        If Request.Cookies("referby") Is Nothing Then
            referby.Value = ""
        Else
            referby.Value = Request.Cookies("referby").Value
        End If
    End Sub
    Shared Sub addtocandireg(ByVal D As UserDetails)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt

        Try

            If HttpContext.Current.Request.Cookies("referby") Is Nothing Then
                refer1 = 0
                ref1val = 0
            Else
                If IsNumeric(HttpContext.Current.Request.Cookies("referby").Value) Then
                    refer1 = HttpContext.Current.Request.Cookies("referby").Value
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

            st1 = "insert into profile(Passw,email,fname,ref1,ref1val,gender,ipaddress,approved,hasInvited,GPlusUrl) values(@passw,@email,@firstname,@ref1,@ref1val,@gender,@ipaddress,@approved,@hasInvited,@GPlusUrl) Select @@identity"

            cmd.Connection = cn
            cmd.CommandText = st1



            cmd.Parameters.AddWithValue("@passw", "1234")
            cmd.Parameters.AddWithValue("@email", D.email)
            cmd.Parameters.AddWithValue("@firstname", D.fname)
            cmd.Parameters.AddWithValue("@ref1", refer1)
            cmd.Parameters.AddWithValue("@ref1val", ref1val)
            cmd.Parameters.AddWithValue("@gender", D._gender)
            cmd.Parameters.AddWithValue("@ipaddress", getip)
            cmd.Parameters.AddWithValue("@GPlusUrl", D.GPlusUrl)
            If D._gender.ToUpper = "F" Then
                cmd.Parameters.AddWithValue("@approved", "N")
            Else
                cmd.Parameters.AddWithValue("@approved", cf.autoapprove)
            End If
            cmd.Parameters.AddWithValue("@hasInvited", "Y")
            pid = cmd.ExecuteScalar()
            If refer1 <> 0 And pid <> 0 Then
                cf.addintotopearner(refer1, ref1val, "DirectRefer", pid)
            End If

            HttpContext.Current.Session("pid") = pid
            HttpContext.Current.Session("fname") = D.fname
            HttpContext.Current.Session("GPlusUrl") = D.GPlusUrl

            If D._gender.ToUpper = "F" Then
                HttpContext.Current.Session("approved") = "N"
            Else
                HttpContext.Current.Session("approved") = "Y"
            End If


            HttpContext.Current.Session("lname") = ""
            HttpContext.Current.Session("susp") = "N"
            HttpContext.Current.Session("validmobile") = ""
            HttpContext.Current.Session("sex") = ""
            HttpContext.Current.Session("mrole") = ""
            HttpContext.Current.Session("email") = D.lname

            HttpContext.Current.Session("hasinvites") = "Y"
            HttpContext.Current.Session("headline") = ""
            HttpContext.Current.Session("isfacebookposted") = "N"
            HttpContext.Current.Session("addme") = "N"



            cmd.Dispose()
            cn.Close()

            Try
                upimage(D, pid)
            Catch ex As Exception

                cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", ex.Message)
            End Try

            Try
                Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
                Dim L As New LoginIds
                L.Fname = D.fname
                L.PID = pid
                Logins = HttpContext.Current.Application("Ids")
                'Dim b As Boolean = Logins.Contains(New LoginIds With {.PID = L.PID})
                Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
                If Not b Then
                    Logins.Add(L)
                End If
                HttpContext.Current.Application("Ids") = Logins
            Catch ex As Exception

            End Try
            Try
                Dim act As New SiteAcitvity
                act.candiid = pid
                act.actType = "Reg"
                act.fn = D.fname
                act.photo = D.photo
                insertUpdateActivity(act)
            Catch ex As Exception

            End Try
            FormsAuthentication.SetAuthCookie(D.email, False)
            ' send email
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Dear " & D.fname & " &nbsp;</td>"
            regmsg = regmsg & "  </tr>"
            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Thank you for Registering with us,</td>"
            regmsg = regmsg & "</tr>"
            regmsg = regmsg & "<tr>"

            regmsg = regmsg & "<tr>"
            regmsg = regmsg & "<td width='20%'>Username :</td>"
            regmsg = regmsg & "<td width='80%'><font color='#FF0000'>" & D.email & "</font></td>"
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

            rzlt = cf.send25("reg", "Thakyou For Registration", D.email, regmsg.ToString)
            SendmailtoUser(D.fname, D.email)

        Catch ex As Exception
            cn.Close()
            cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", ex.Message)
            'HttpContext.Current.Response.Redirect("register.aspx")
        End Try

    End Sub


    Shared Function getip() As String
        Dim ip As String = ""
        ip = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If Not String.IsNullOrEmpty(ip) Then
            Dim ipRange As String() = ip.Split(","c)
            Dim le As Integer = ipRange.Length - 1
            Dim trueIP As String = ipRange(le)
        Else
            ip = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")
        End If
        getip = ip

    End Function

    Public Shared Function CreateDataSet(ByVal s As String) As DataSet

        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable("pid")
        dt.Columns.Add("pid", GetType(String))
        Dim dr As DataRow
        dr = dt.NewRow
        dr("pid") = s
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)
        Return ds
    End Function
    Shared Sub addhisemails(ByVal cont As UserDetails, ByVal semail As String)

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

            cmd.Parameters.AddWithValue("@email", cont.email)
            cmd.Parameters.AddWithValue("@sendersemail", semail)
            cmd.Parameters.AddWithValue("@fname", cont.fname)
            cmd.Parameters.AddWithValue("@lovenmarry", "Y")

            cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close() '

        Catch ex As Exception
            cn.Close()
        End Try
    End Sub
    Public Shared Function Login(ByVal D As UserDetails) As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = "Select * from [profile] where email='" & D.email & "'"

        Dim ds As New DataSet
        Try

            cn.ConnectionString = cf.friendshipdb
            cn.Open()
            cmd.CommandText = st1
            cmd.Connection = cn
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            cn.Close()
            If ds.Tables(0).Rows.Count > 0 Then


                HttpContext.Current.Session("pid") = ds.Tables(0).Rows(0)("pid").ToString
                HttpContext.Current.Session("fname") = ds.Tables(0).Rows(0)("fname").ToString
                HttpContext.Current.Session("approved") = ds.Tables(0).Rows(0)("approved").ToString
                HttpContext.Current.Session("lname") = ds.Tables(0).Rows(0)("lname").ToString
                HttpContext.Current.Session("susp") = ds.Tables(0).Rows(0)("susp").ToString
                HttpContext.Current.Session("validmobile") = ds.Tables(0).Rows(0)("isvalidmobile").ToString
                HttpContext.Current.Session("sex") = ds.Tables(0).Rows(0)("gender").ToString
                HttpContext.Current.Session("mrole") = ds.Tables(0).Rows(0)("mrole").ToString
                HttpContext.Current.Session("email") = D.email
                HttpContext.Current.Session("hasinvites") = ds.Tables(0).Rows(0)("hasInvited").ToString
                HttpContext.Current.Session("headline") = ds.Tables(0).Rows(0)("headline").ToString
                HttpContext.Current.Session("isfacebookposted") = ds.Tables(0).Rows(0)("facebookpost").ToString
                If ds.Tables(0).Rows(0)("lname").ToString = "" Then
                    HttpContext.Current.Response.Cookies("PC")("P") = "N"
                Else
                    HttpContext.Current.Response.Cookies("PC")("P") = "Y"
                End If
                If ds.Tables(0).Rows(0)("wt").ToString = "" Then
                    HttpContext.Current.Response.Cookies("PC")("W") = "N"
                Else
                    HttpContext.Current.Response.Cookies("PC")("W") = "Y"
                End If
                If ds.Tables(0).Rows(0)("whoami").ToString = "" Then
                    HttpContext.Current.Response.Cookies("PC")("A") = "N"
                Else
                    HttpContext.Current.Response.Cookies("PC")("A") = "Y"
                End If
                If ds.Tables(0).Rows(0)("mobile").ToString = "" Then
                    HttpContext.Current.Response.Cookies("PC")("M") = "N"
                Else
                    HttpContext.Current.Response.Cookies("PC")("M") = "Y"
                End If
                If ds.Tables(0).Rows(0)("photo").ToString = "" Then
                    HttpContext.Current.Response.Cookies("Photo").Value = "N"
                End If

                FormsAuthentication.SetAuthCookie(D.email, False)
                Try
                    Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
                    Dim L As New LoginIds
                    L.Fname = HttpContext.Current.Session("fname")
                    L.PID = HttpContext.Current.Session("pid")
                    Logins = HttpContext.Current.Application("Ids")
                    'Dim b As Boolean = Logins.Contains(New LoginIds With {.PID = L.PID})
                    Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
                    If Not b Then
                        Logins.Add(L)
                    End If
                    HttpContext.Current.Application("Ids") = Logins
                Catch ex As Exception

                End Try
                Return ds.Tables(0).Rows(0)("pid")
            Else
                Return 0
            End If

        Catch
            cn.Close()
            Return 0
        End Try

    End Function
    Shared Sub SendmailtoUser(ByVal fname As String, ByVal toemail As String)
        Try

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

        Catch ex As Exception

        End Try
    End Sub
    Shared Sub insertUpdateActivity(ByVal act As SiteAcitvity)
        Dim str As String = ""
        str = "<div><table>"
        str = str & "<tr><td>"
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has Join Lovenmarry"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.pk_Id = act.candiid
        cf.siteactivity(act)
    End Sub

    Shared Sub upimage(ByVal D As UserDetails, ByVal pid As Integer)

        Try
        Dim msg As String = ""
        Dim filecopy As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 0
            Dim ext As String = "jpg"

            Dim ImageName As String = addentry("." & ext, pid)
            If ImageName = "" Then
                Exit Sub
            End If
            Dim Client As New WebClient
            Dim Destination As String = HttpContext.Current.Server.MapPath("App_Themes/") & ImageName
            Client.DownloadFile(D.photo.Replace("?sz=50", ""), Destination)
            Client.Dispose()

            'Dim fn As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)


            uploadimagesThumb(ImageName, Destination)


        Catch Exc As Exception

            cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", Exc.Message)
        End Try


    End Sub
    Shared Function addentry(ByVal ext1 As String, ByVal pid As Integer) As String
        Try


            Dim uid As String = ""

            Dim strfield As String = ""
            Dim strvalues As String = ""
            Dim strsql As String = ""
            Dim passw As String = ""
            Dim sql As String = ""


            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand


            Dim photoid As String = ""
            Dim photoname As String = ""
            Dim kk As String = ""

            
            uid = cf.generateid





            strfield = " insert into photo(photoname,pid,passw,mainphoto)"
            strvalues = " values(@photoname,@candiid,@passw,@mainphoto)"

            strsql = strfield & strvalues


            cmd.Parameters.AddWithValue("@photoname", uid & ext1)
            cmd.Parameters.AddWithValue("@candiid", pid)
            cmd.Parameters.AddWithValue("@passw", passw)
            cmd.Parameters.AddWithValue("@mainphoto", "Y")

            cmd.Connection = cn
            cmd.CommandText = strsql
            cmd.ExecuteNonQuery()
            cn.Close()


            sql = "update Profile set photo='" & uid & ext1 & "',photopassw='" & passw & "' where pid=" & pid & ""


            kk = cf.TaskmembSql(sql)

            addentry = uid
        Catch ex As Exception
            Return ""
            cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", ex.Message)
        End Try
    End Function
    Shared Sub uploadimagesThumb(ByVal imagename As String, ByVal Loc As String)
        Dim msg As String = ""
        Dim filecopy As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 0

        'Dim fn As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim ext As String = imagename.Substring((imagename.IndexOf(".")))
        msg = imagename.Substring(0, (imagename.IndexOf(".")))

        Dim SaveLocation As String = Loc & "\Thumbs" & "\"
        If Not Directory.Exists(SaveLocation) Then
            Directory.CreateDirectory(SaveLocation)
        End If
        Dim ImgLocation As String = Loc & "\" & imagename
        Try
            SaveLocation = SaveLocation & msg & ext
            Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(ImgLocation)
            'From File
            Dim height As Integer = objImage.Height
            'Actual image width
            Dim width As Integer = objImage.Width
            'Actual image height
            Dim bitmapimage As New System.Drawing.Bitmap(objImage, 100, 80)
            ' create bitmap with same size of Actual image

            bitmapimage.Save(SaveLocation, ImageFormat.Jpeg)
            bitmapimage.Dispose()
            objImage.Dispose()
            'TD1.InnerHtml = "<font color='red'>Photo Uploaded Sucessfully </font>"
        Catch Exc As Exception

            cf.send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", Exc.Message)
        End Try

    End Sub
End Class
