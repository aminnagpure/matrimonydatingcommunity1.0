Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports Facebook
Imports System.IO

Partial Class viewprofile
    Inherits System.Web.UI.Page
    Dim pid As Integer = 0
    Dim cf As New comonfunctions
    Dim sql As String = ""

    Sub loaddata(ByVal pid As String)
        'Dim constring As String
        Dim rzlt As String = ""
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim strsql As String = ""
        Dim susp As String = ""

        ' constring = cf.friendshipdb

        '  Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        'Dim myreader As SqlDataReader




        ' cn.ConnectionString = constring
        ' cn.Open()
        '
        'str1 = "select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityid,whoami,"
        'str2 = " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        'str3 = "education,profession,htname,castename,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        'str4 = "Drink,Drugs,religion,zipcode,isonlinenow,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw from profile left join photo on profile.pid=photo.pid where profile.pid=@pid"
        If Not IsNumeric(pid) Then
            GoTo lblErr
        End If
        'strsql = str1 & str2 & str3 & str4
        strsql = "viewprofile" ' " & pid & ""
        ' cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@pid", pid)
        'cmd.Parameters.Add("@pid", Data.SqlDbType.VarChar).Value = pid
        Dim ds As New DataSet
        ds = cf.ExecuteDatasetview(cmd)

        If ds.Tables(0).Rows.Count > 0 Then


            'tdpid.InnerText = ds.Tables(0).Rows(0)(0).ToString
            tdheadline.InnerText = ds.Tables(0).Rows(0)(1).ToString
            tdname.InnerHtml = "<span style='font-size: 1.17em;color:#990000;font-weight:bold;'>" & ds.Tables(0).Rows(0)(2).ToString & "</span>  (Lovenmarry ID- " & ds.Tables(0).Rows(0)(0).ToString & ")"
            'Page.Title = ds.Tables(0).Rows(0)(2).ToString '& "  " & ds.Tables(0).Rows(0)(3).ToString
            Page.Title = "Free Dating Site,Which pays its members to refer friends, with over 96000 members"
            tdage.InnerText = "(" & DateDiff(DateInterval.Year, ds.Tables(0).Rows(0)(4), Now.Date) & ") Date of Birth " & ds.Tables(0).Rows(0)(4)
            tdpurpose.InnerText = ds.Tables(0).Rows(0)(5).ToString
            If ds.Tables(0).Rows(0)(6).ToString = "M" Then
                tdsex.InnerText = "Male"
            Else
                tdsex.InnerText = "Female"
            End If

            Dim Loc As String = ""
            If ds.Tables(0).Rows(0)(7).ToString <> "" Then
                Loc = ds.Tables(0).Rows(0)(7).ToString
            End If

            If ds.Tables(0).Rows(0)(8).ToString <> "" Then
                If Loc <> "" Then
                    Loc += ", "
                End If
                Loc += ds.Tables(0).Rows(0)(8).ToString
            End If
            If ds.Tables(0).Rows(0)(38).ToString <> "" Then
                If Loc <> "" Then
                    Loc += ", "
                End If
                Loc += ds.Tables(0).Rows(0)(38).ToString
            End If

            tdlocation.InnerHtml = Loc

            tdaboutme.InnerHtml = "<h3>About Me</h3>" & cf.BreakWordForWrap(ds.Tables(0).Rows(0)(10).ToString)
            tdlookingfor.InnerHtml = "<h3>Looking For</h3>" & cf.BreakWordForWrap(ds.Tables(0).Rows(0)(11).ToString)

            tdregdate.InnerText = ds.Tables(0).Rows(0)(12)
            tdlastvisited.InnerText = ds.Tables(0).Rows(0)(13)
            tdlastupdate.InnerText = ds.Tables(0).Rows(0)(14)
            tdmaritalstatus.InnerText = ds.Tables(0).Rows(0)(15).ToString
            tdmothertounge.InnerText = ds.Tables(0).Rows(0)(16).ToString
            tdincome.InnerText = ds.Tables(0).Rows(0)(17).ToString

            tdeducation.InnerText = ds.Tables(0).Rows(0)(18).ToString

            tdprofession.InnerText = ds.Tables(0).Rows(0)(19).ToString
            tdheight.InnerText = ds.Tables(0).Rows(0)(20).ToString
            tdcaste.InnerText = ds.Tables(0).Rows(0)(21).ToString
            tdeyesight.InnerText = ds.Tables(0).Rows(0)(22).ToString
            tdhaircolor.InnerText = ds.Tables(0).Rows(0)(23).ToString
            tdrace.InnerText = ds.Tables(0).Rows(0)(24).ToString
            tdbodytype.InnerText = ds.Tables(0).Rows(0)(25).ToString
            tdcomplexion.InnerText = ds.Tables(0).Rows(0)(26).ToString
            tdstarsign.InnerText = ds.Tables(0).Rows(0)(27).ToString
            tdsmoke.InnerText = ds.Tables(0).Rows(0)(28).ToString
            tddiet.InnerText = ds.Tables(0).Rows(0)(29).ToString
            tddrinking.InnerText = ds.Tables(0).Rows(0)(30).ToString
            tddrugs.InnerText = ds.Tables(0).Rows(0)(31).ToString
            tdreligion.InnerText = ds.Tables(0).Rows(0)(32).ToString
            tdpincode.InnerText = ds.Tables(0).Rows(0)(33).ToString
            'tdonline.InnerText = ds.Tables(0).Rows(0)(34).ToString
            susp = ds.Tables(0).Rows(0)(37).ToString


            'tdaboutme.NoWrap = False

            If (ds.Tables(0).Rows(0)(36).ToString <> "" And ds.Tables(0).Rows(0)(35).ToString <> "") Then
                tdimage.InnerHtml = "<a href='members/requestphotopassw.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' width='339' height='435'></a>"
                Button1.Visible = True
                photopassw.Visible = True

            ElseIf (ds.Tables(0).Rows(0)(35).ToString = "") Then
                tdimage.InnerHtml = "<img src='App_Themes/no_avatar.gif'>"
            Else
                If File.Exists(Server.MapPath("App_Themes/" & ds.Tables(0).Rows(0)(35).ToString)) Then
                    tdimage.InnerHtml = "<a href='members/photogallery.aspx?pid=" & pid & "'><img style='width:100px' src='App_Themes/" & ds.Tables(0).Rows(0)(35).ToString & "'></a>"
                Else
                    tdimage.InnerHtml = "<img  style='width:100px' src='App_Themes/no_avatar.gif'>"
                End If


            End If
            lblAge.Text = ds.Tables(0).Rows(0)("P_MinAge") & " To " & ds.Tables(0).Rows(0)("P_MaxAge")
            lblHeight.Text = ds.Tables(0).Rows(0)("P_HEight_Name")

            lblReligion.Text = ds.Tables(0).Rows(0)("P_Religion")

            lblCast.Text = ds.Tables(0).Rows(0)("P_cast")
            lblMoherToung.Text = ds.Tables(0).Rows(0)("P_motherTounge")
            lblSkinColor.Text = ds.Tables(0).Rows(0)("P_SkinColor")
            lblHairColor.Text = ds.Tables(0).Rows(0)("P_HairColor")
            lblSmoke.Text = ds.Tables(0).Rows(0)("P_Smoke")
            lblStarSign.Text = ds.Tables(0).Rows(0)("P_StarSign")
            lblBodyType.Text = ds.Tables(0).Rows(0)("P_BodyType")
            lblMstatus.Text = ds.Tables(0).Rows(0)("P_MStatus")
            If ds.Tables(0).Rows(0)("P_Income") <> 0 Then
                lblAnualIncome.Text = Convert.ToDouble(ds.Tables(0).Rows(0)("P_Income"))
            End If
            lblDiet.Text = ds.Tables(0).Rows(0)("P_Diet")
            lblDrinks.Text = ds.Tables(0).Rows(0)("P_Drinks")
            lblDrugs.Text = ds.Tables(0).Rows(0)("P_Drugs")
            lblEducation.Text = ds.Tables(0).Rows(0)("P_Education")
        Else
lblErr:
            viewp.Visible = False
            lit_NotFound.Text = "<h2>Profile Removed Or Not Available Or Restricted By Privacy setting</h2>"
            Exit Sub
        End If

        If susp = "Y" Then
            Label1.Text = "This Person has been marked as Nigerian Scammer by the website admin, kindly avoid contact with him,we have kept the profile on site, so that you can see it"
        End If
        Dim website As String = "http://www.yoursite.com"
        website = Request.Url.Host
        'cn.Close()
        Dim gg As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        gg = googlecomments.InnerHtml
        gg = Replace(gg, "http://www.yoursite.com", website & "/viewprofile.aspx?pid=" & Request.QueryString("pid"))
        googlecomments.InnerHtml = gg

        Dim fbco As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        fbco = facebookcomment.InnerHtml
        fbco = Replace(fbco, "abcd", website & "/viewprofile.aspx?pid=" & Request.QueryString("pid"))
        facebookcomment.InnerHtml = fbco
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kk As String = ""
        Dim constring As String

        Response.Redirect("members/viewprofile.aspx?pid=" & Request.QueryString("pid"))

        kk = photopassw.Text.ToString
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand

        Dim myreader As System.Data.OleDb.OleDbDataReader

        constring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString


        cn.ConnectionString = constring
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select photoname from photo where passw=@passw and pid=@pid"
        cmd.Parameters.Add("@passw", Data.OleDb.OleDbType.VarChar).Value = kk
        cmd.Parameters.Add("@pid", Data.OleDb.OleDbType.VarChar).Value = Request.QueryString("pid")

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                If File.Exists(Server.MapPath("App_Themes/" & myreader.GetValue(0).ToString)) Then
                    tdimage.InnerHtml = "<a href='members/photogallery.aspx?pid=" & Request.QueryString("pid") & "'><img width='200'  src='App_Themes/" & myreader.GetValue(0).ToString & "'></a>"
                    Button1.Visible = False
                    photopassw.Visible = False
                Else
                    tdimage.InnerHtml = "<img width='200'  src='App_Themes/no_avatar.gif'>"
                End If

            End While
        Else
            tdimage.InnerHtml = "Wrong Password"
            photopassw.Text = "Type Correct Password"
            Button1.Visible = True
            photopassw.Visible = True
        End If
        cn.Close()

    End Sub

    Protected Sub btnContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContact.Click

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack = True Then
            Button1.Visible = False
            photopassw.Visible = False
            Try
                pid = Request.QueryString("pid")
            Catch ex As Exception

            End Try

            loaddata(pid)
            btnContact.PostBackUrl = "members/sendmsg.aspx?pid=" & pid
            Try
                Dim Durl As String = Request.Url.AbsoluteUri
                'If Request.QueryString("ref") IsNot Nothing Then
                '    If Request.QueryString("ref") = "facebook" Then
                '        CheckAuthorization()
                '    End If

                'End If
                'If Request.QueryString("code") IsNot Nothing Then
                '    If Request.QueryString("code") <> "" Then
                '        CheckAuthorization()
                '    End If
                'End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Function getphotocount() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim photoreader As SqlDataReader
        Dim photocount As Integer = 0
        cn.ConnectionString = cf.justviewcon
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from photo where pid='" & Request.QueryString("pid") & "'"

        photoreader = cmd.ExecuteReader
        While photoreader.Read
            photocount = photoreader.GetValue(0)
        End While

        getphotocount = photocount
        cn.Close()
    End Function

    


    'Dim v = client.Get("/me?fields=id,name,email,first_name,last_name") ', New With {.feilds = "id,name,email"})
    'AddFacebookData(v)
    'Response.Redirect("De")
       
End Class
