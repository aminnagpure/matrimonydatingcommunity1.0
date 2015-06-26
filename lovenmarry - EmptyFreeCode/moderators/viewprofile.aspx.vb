Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class moderators_viewprofile
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Dim kk As Boolean
    Dim pid As String = ""
    Dim Susp As String = ""
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim msg As String = ""
        kk = cf.update("update profile set Approved='Y' where pid=" & Request.QueryString("pid") & "")


        If kk = True Then
            Button1.Text = "Profile Approved"
            msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
            Button1.Enabled = False
            Button2.Enabled = False
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim k2 As Boolean
        Dim msg As String = ""
        kk = cf.update("update profile set Approved='Y' where pid=" & Request.QueryString("pid") & "")
        k2 = cf.update("update photo set active='Y' where pid=" & Request.QueryString("pid") & "")

        msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename

        If kk = True Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button2.Text = "Profile Approved"
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
        End If
        If k2 = True Then
            Button2.Text = Button2.Text & " " & "with photo"
        End If
    End Sub


    Sub loaddata(ByVal pid As String)

        Dim rzlt As String = ""
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim strsql As String = ""



        ' Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        ' Dim myreader As SqlDataReader
        Dim isdoubtful As String = ""
        Dim ipcountry As String = ""



        'cn.ConnectionString = cf.friendshipdb
        'cn.Open()

        'str1 = "select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityname,whoami,"
        'str2 = " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        'str3 = "education,profession,htname,castename,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        'str4 = "Drink,Drugs,religion,zipcode,isonlinenow,photoname,profile.passw,approved,email,ipaddress from profile left join photo on profile.pid=photo.pid where profile.pid='" & pid & "'"

        'strsql = str1 & str2 & str3 & str4
        strsql = "viewprofileforadmin" '" & pid & "'"

        'cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@pid", pid)
        'cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = pid

        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)



        If ds.Tables(0).Rows.Count > 0 Then


            tdpid.InnerText = ds.Tables(0).Rows(0)(0).ToString
            tdheadline.InnerText = ds.Tables(0).Rows(0)(1).ToString
            tdname.InnerText = ds.Tables(0).Rows(0)(2).ToString & ds.Tables(0).Rows(0)(3).ToString
            Page.Title = tdname.InnerText

            tdage.InnerText = DateDiff(DateInterval.Year, ds.Tables(0).Rows(0)(4), Now.Date)
            tdpurpose.InnerText = ds.Tables(0).Rows(0)(5).ToString
            tdsex.InnerText = ds.Tables(0).Rows(0)(6).ToString
            tdlocation.InnerHtml = ds.Tables(0).Rows(0)(7).ToString & "<br>" & ds.Tables(0).Rows(0)(8).ToString & "<br>" & ds.Tables(0).Rows(0)(9).ToString

            tdaboutme.InnerHtml = cf.BreakWordForWrap(ds.Tables(0).Rows(0)(10).ToString)
            tdlookingfor.InnerHtml = cf.BreakWordForWrap(ds.Tables(0).Rows(0)(11).ToString)

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
            tdonline.InnerText = ds.Tables(0).Rows(0)(34).ToString


            If (ds.Tables(0).Rows(0)(35).ToString = "") Then
                tdimage.InnerHtml = "<img src='../App_Themes/no_avatar.gif'>"
            Else
                If File.Exists(Server.MapPath("../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(35).ToString)) Then
                    tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & pid & "'><img width='200' height='200' src='../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(35).ToString & "'></a>"
                Else
                    tdimage.InnerHtml = "<img src='../App_Themes/no_avatar.gif'>"
                End If
            End If

            tdpassword.InnerHtml = ds.Tables(0).Rows(0)(36).ToString

            If (ds.Tables(0).Rows(0)(37).ToString = "Y") Then
                Button1.Enabled = False
                Button2.Enabled = False
            End If

            tdusername.InnerHtml = ds.Tables(0).Rows(0)(38).ToString
            tdipaddress.InnerText = "Ip Address " & ds.Tables(0).Rows(0)(39).ToString
            Susp = ds.Tables(0).Rows(0)(40).ToString
            isdoubtful = ds.Tables(0).Rows(0)(41).ToString
            ipcountry = ds.Tables(0).Rows(0)(42).ToString
            Button3.PostBackUrl = "editreg.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString
            If ds.Tables(0).Rows(0)(43).ToString = "Y" Then
                btnMarkDefaultpremium.Text = "Premium Member"
                btnMarkDefaultpremium.Enabled = False
                ddlpremiumType.SelectedIndex = ddlpremiumType.Items.IndexOf(ddlpremiumType.Items.FindByValue(ds.Tables(0).Rows(0)("Subs_Plan")))
                ddlpremiumType.Enabled = False
            ElseIf ds.Tables(0).Rows(0)("paid").ToString = "Y" Then
                ddlpremiumType.SelectedIndex = ddlpremiumType.Items.IndexOf(ddlpremiumType.Items.FindByValue(ds.Tables(0).Rows(0)("Subs_Plan")))
                btnMarkDefaultpremium.Text = "Upgrade Plan"
                'btnMarkDefaultpremium.Enabled = False
            End If


        Else

        End If

        cmd.Dispose()
        If isdoubtful = "Y" Then
            lbldoubtful.Text = "This Profile looks Doubtful"
        Else
            lbldoubtful.Text = ""
        End If
        lblipcountry.Text = ipcountry

        '   cn.Close()
    End Sub






    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If


        pid = Request.QueryString("pid").ToString
        loaddata(pid)

        HyperLink1.NavigateUrl = "approveprofile.aspx?pid=" & pid
        HyperLink2.NavigateUrl = "approveprofile.aspx?pid=" & pid & "&photo=Y"
        If Susp = "N" Then
            HyperLink3.NavigateUrl = "suspend.aspx?pid=" & pid
        Else
            HyperLink3.NavigateUrl = "unsuspend.aspx?pid=" & pid
            HyperLink3.Text = "Profile is Suspended, click here to unsuspend"
        End If

        removeprofile.NavigateUrl = "removeprofile.aspx?pid=" & pid
        hyperlinksengmsg.NavigateUrl = "sendmsg.aspx?pid=" & pid

    End Sub




    Protected Sub btnMarkDefaultpremium_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMarkDefaultpremium.Click
        Dim premum As String = "N"
        Dim subs_Plan As Integer = 0
        
        If ddlpremiumType.SelectedValue = "0" Then
            premum = "Y"
            subs_Plan = 0
        ElseIf ddlpremiumType.SelectedValue = "5" Then
            subs_Plan = 5
        ElseIf ddlpremiumType.SelectedValue = "10" Then
            subs_Plan = 10
        End If

        Dim cmd As New SqlCommand
        cmd.CommandText = "Update_Plans"
        cmd.Parameters.AddWithValue("@Premium", premum)
        cmd.Parameters.AddWithValue("@subs_Plan", subs_Plan)
        cmd.Parameters.AddWithValue("@pid", Request.QueryString("pid"))
        Dim i As Integer = cf.ExecuteNonQuery(cmd)
        '
        '
        'If ddlpremiumType.SelectedValue = "0" Then
        '    premum = "premiummem='Y',"
        '    subs_Plan = 0
        'ElseIf ddlpremiumType.SelectedValue = "5" Then
        '    subs_Plan = 5
        'ElseIf ddlpremiumType.SelectedValue = "10" Then
        '    subs_Plan = 10
        'End If

        'kk = cf.update("update profile set paid='Y', Approved='Y' ,hasinvite='Y', " & premum & " prmstartdate=GETDATE(), Subs_Plan=" & subs_Plan & " where pid=" & Request.QueryString("pid") & "")
        If i > 0 Then
            btnMarkDefaultpremium.Enabled = False
            btnMarkDefaultpremium.Text = "Premium Member"
        End If
    End Sub
End Class
