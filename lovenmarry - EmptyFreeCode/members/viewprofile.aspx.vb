Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class viewprofile
    Inherits System.Web.UI.Page
    Dim pid As String = ""
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

        Dim cmd As New SqlCommand
        
        If Not IsNumeric(pid) Then
            GoTo lblErr
        End If

        strsql = "viewprofile" ' " & pid & ""

        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@pid", pid)

        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)

        If ds.Tables(0).Rows.Count > 0 Then
            cf.addviewentry(Session("pid"), pid, getip())
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
                tdimage.InnerHtml = "<a href='requestphotopassw.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='../App_Themes/request-photo-large-1.gif' width='339' height='435'></a>"
                Button1.Visible = True
                photopassw.Visible = True

            ElseIf (ds.Tables(0).Rows(0)(35).ToString = "") Then
                tdimage.InnerHtml = "<img src='../App_Themes/no_avatar.gif'>"
            Else
                If File.Exists(Server.MapPath("../App_Themes/" & ds.Tables(0).Rows(0)(35).ToString)) Then
                    Dim pc As Integer = getphotocount()
                    Dim pcstr As String = ""
                    If pc > 1 Then
                        pcstr = ds.Tables(0).Rows(0)("fname").ToString & " has " & pc - 1 & " More Photos<br /><br />"
                    End If
                    tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & pid & "'><img style='width:100px' src='../App_Themes/" & ds.Tables(0).Rows(0)(35).ToString & "'></a><br />" & pcstr
                ElseIf File.Exists(Server.MapPath("../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(35).ToString)) Then
                    Dim pc As Integer = getphotocount()
                    Dim pcstr As String = ""
                    If pc > 1 Then
                        pcstr = ds.Tables(0).Rows(0)("fname").ToString & " has " & pc - 1 & " More Photos<br /><br />"
                    End If
                    tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & pid & "'><img style='width:100px' src='../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(35).ToString & "'></a><br />" & pcstr

                Else
                    tdimage.InnerHtml = "<img  style='width:100px' src='../App_Themes/no_avatar.gif'>"
                End If


            End If
            If tdsex.InnerText = "Male" And ds.Tables(0).Rows(0)("FB_ID") <> "" Then
                Lit_FBProfile.Text = " <div style=""margin-bottom:2px;float:left;text-align:left;padding-left:2px;"" >" & _
                "<br />" & _
                 "<h6><a href='https://facebook.com/" & ds.Tables(0).Rows(0)("FB_ID") & "' title=""Facebook Profile""><img class=""FB_Ico"" style=""width:48px;"" src=""../images/fb_icon.png"" alt=""Facebook Profile"">&nbsp;" & ds.Tables(0).Rows(0)("fname") & "</a></h6>" & _
                 "</div>"
                'Lit_FB_Follow.Text = "<div class=""fb-follow"" data-href=""https://facebook.com/" & .Rows(0)("FB_ID") & """ data-width=""400px"" data-colorscheme=""light"" data-layout=""standard"" data-show-faces=""true""></div>"
            End If

            If tdsex.InnerText = "Male" And ds.Tables(0).Rows(0)("GPlusUrl") <> "" Then

                Lit_Gplus.Text = " <div style=""margin-bottom:2px;float:left;text-align:left;padding-left:2px;"" >" & _
                "<br />" & _
                 "<h6><a href='" & ds.Tables(0).Rows(0)("GPlusUrl") & "' target=""_blank"" title=""GPlus Profile""><img class=""FB_Ico"" style=""width:48px;"" src=""../images/GPlusimg_48.png"" alt=""GPlus Profile"">&nbsp;" & ds.Tables(0).Rows(0)("fname") & "</a></h6>" & _
                 "</div>"
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
            Label1.Text = "[Profile Suspended for being Fake]This Person has been marked as Nigerian Scammer by the website admin, kindly avoid contact with him,we have kept the profile on site, so that you can see it"
        End If

        'cn.Close()
        Dim gg As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        gg = googlecomments.InnerHtml
        gg = Replace(gg, "http://www.yoursite.com", "http://www.yoursite.com/viewprofile.aspx?pid=" & Request.QueryString("pid"))
        googlecomments.InnerHtml = gg

        Dim fbco As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        fbco = facebookcomment.InnerHtml
        fbco = Replace(fbco, "abcd", "http://www.yoursite.com/viewprofile.aspx?pid=" & Request.QueryString("pid"))
        facebookcomment.InnerHtml = fbco

       




    End Sub





    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kk As String = ""
        Dim constring As String



        kk = photopassw.Text.ToString
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim myreader As SqlDataReader

        constring = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString


        cn.ConnectionString = constring
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select photoname from photo where passw=@passw and pid=@pid"
        cmd.Parameters.AddWithValue("@passw", kk)
        cmd.Parameters.AddWithValue("@pid", Request.QueryString("pid"))

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & Request.QueryString("pid") & "'><img width='339' height='435' src='../App_Themes/Thumbs/" & myreader.GetValue(0).ToString & "'></a>"
                Button1.Visible = False
                photopassw.Visible = False

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
            pid = Request.QueryString("pid")
            checKInterest()
            loaddata(pid)
            btnContact.PostBackUrl = "sendmsg.aspx?pid=" & pid
        End If
    End Sub
    Function getphotocount() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim photoreader As SqlDataReader
        Dim photocount As Integer = 0
        cn.ConnectionString = cf.friendshipdb
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
#Region "Express And Check Interest"
    Protected Sub btnExpressInterest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpressInterest.Click
        btnExpressInterest.Enabled = False
        Dim cmd As New SqlCommand
        pid = Request.QueryString("pid")
        cmd.CommandText = "Express_Interest"

        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@Tocandiid", pid)
        cmd.Parameters.AddWithValue("@AddDate", Date.Now)
        cmd.Parameters.AddWithValue("@interestedFor", ddlInterestOf.SelectedItem.Text)
        Dim i As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        If i > 0 Then
            btnExpressInterest.Text = "Express Successfully"
            Dim email As String = cf.CountRs("Select email from profile Where pid=" & pid)
            Dim msg As String = ""
            msg = Session("fname") & " is Interested for " & ddlInterestOf.SelectedItem.Text & " With You<br />"
            msg += "<a href='http://www." & cf.websitename & "/members/viewprofile.aspx?pid=" & Session("pid") & "'>Click Here</a> To view Profile<br /><br />"
            msg += "<a href='http://www." & cf.websitename & "/members/awaitingMembers.aspx'>Check All</a> members who are interested in your profile"
            cf.sendMail("contact", "Interested in your Profile", email, msg, Session("fname"))
        End If


    End Sub



    Sub checKInterest()
        If Session("pid") = Request.QueryString("pid") Then
            btnExpressInterest.Visible = False
            ddlInterestOf.Visible = False
            lblIntFor.Visible = False
            btnContact.Visible = False
            btnExpressInterestP.Visible = False
            btnAccept.Visible = False
            BtnNotInterested.Visible = False
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        pid = Request.QueryString("pid")
        cmd.CommandText = "checKInterest"
        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@Tocandiid", pid)
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)

        Dim Paid As String = ""
        Dim Premium As String = ""
        Dim gender As String = ""
        Dim Togender As String = ""
        Dim total_ As Integer = 0
        If ds.Tables(2).Rows.Count > 0 Then
            Paid = ds.Tables(2).Rows(0)("paid").ToString
            Premium = ds.Tables(2).Rows(0)("premiummem").ToString
            gender = ds.Tables(2).Rows(0)("gender").ToString()
            total_ = ds.Tables(2).Rows(0)("totalInterest")
        End If
        If ds.Tables(3).Rows.Count > 0 Then
            
            Togender = ds.Tables(3).Rows(0)("gender").ToString()

        End If
        If gender = Togender Then
            btnExpressInterest.Visible = False
            btnExpressInterestP.Visible = False
            ddlInterestOf.Visible = False
            lblIntFor.Visible = False
            btnContact.Visible = False
            btnAccept.Visible = False
            BtnNotInterested.Visible = False
            Exit Sub
        End If
        'If gender = "M" Then
        '    btnExpressInterest.Visible = False
        '    ddlInterestOf.Visible = False
        '    lblIntFor.Visible = False
        '    btnContact.Visible = False

        'End If

        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0)("candiid") = Session("pid") Then
                If ds.Tables(0).Rows(0)("UserResponse") = "P" Then
                    btnAccept.Visible = False
                    BtnNotInterested.Visible = False
                    btnExpressInterest.Enabled = False
                    btnExpressInterest.Text = "You Have Expressed Interest On " & ds.Tables(0).Rows(0)("InterestDate")
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                ElseIf ds.Tables(0).Rows(0)("UserResponse") = "N" Then
                    btnAccept.Visible = False
                    BtnNotInterested.Visible = False
                    btnExpressInterest.Enabled = False
                    btnExpressInterest.Text = "This Person is not Interested In you"
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                ElseIf ds.Tables(0).Rows(0)("UserResponse") = "Y" Then
                    btnAccept.Visible = False
                    BtnNotInterested.Visible = False
                    btnExpressInterest.Enabled = False
                    btnExpressInterest.Text = "This Person is Accepted Interest In you"
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                End If
            ElseIf ds.Tables(0).Rows(0)("IntrestedIn") = Session("pid") Then
                ddlInterestOf.Visible = True
                lblIntFor.Visible = True
                If ds.Tables(0).Rows(0)("UserResponse") = "Y" Then
                    btnAccept.Visible = False
                    BtnNotInterested.Visible = False
                    btnExpressInterest.Enabled = False
                    btnExpressInterest.Text = "You Have Accepted Interest In This Person"
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                ElseIf ds.Tables(0).Rows(0)("UserResponse") = "P" Then
                    btnAccept.Visible = True
                    BtnNotInterested.Visible = True
                    btnExpressInterest.Visible = False
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                ElseIf ds.Tables(0).Rows(0)("UserResponse") = "N" Then
                    btnAccept.Visible = False
                    BtnNotInterested.Visible = False
                    btnExpressInterest.Enabled = False
                    btnExpressInterest.Text = "You are not Interested In This Profile"
                    ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                    ddlInterestOf.Enabled = False
                End If

            End If
        Else
            If ds.Tables(1).Rows(0)("ToDayInterest") >= 50 Then
                btnExpressInterest.Enabled = False
                btnExpressInterest.Text = "You can only Express Interest 50 members a day"
                'ddlInterestOf.SelectedIndex = ddlInterestOf.Items.IndexOf(ddlInterestOf.Items.FindByText(ds.Tables(0).Rows(0)("InterestFor")))
                ddlInterestOf.Enabled = False
            End If
            If gender = "M" And Paid = "N" Then
                'Response.Redirect("premiummem.aspx")
                'If total_ >= 0 Then
                '    btnAccept.Visible = False
                '    BtnNotInterested.Visible = False
                btnExpressInterest.Visible = False
                btnExpressInterestP.Visible = True
                '    Exit Sub
                'End If
            End If
            btnAccept.Visible = False
            BtnNotInterested.Visible = False
        End If
    End Sub
#End Region
#Region "User Response"
    Protected Sub btnAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        UpdateInterest("Y")
    End Sub

    Protected Sub BtnNotInterested_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNotInterested.Click
        UpdateInterest("N")
    End Sub



    ''' <summary>
    ''' Update User Response
    ''' </summary>
    ''' <param name="UResponse">Y For Accept And N For Not Interested</param>
    ''' <remarks></remarks>

    Sub UpdateInterest(ByVal UResponse As String)
        Dim cmd As New SqlCommand
        pid = Request.QueryString("pid")
        cmd.CommandText = "UpDate_Interest"

        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@Tocandiid", pid)
        cmd.Parameters.AddWithValue("@AddDate", Date.Now)
        cmd.Parameters.AddWithValue("@Response", UResponse)
        ''cmd.Parameters.AddWithValue("@Mess", "")
        Dim i As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        checKInterest()
    End Sub

#End Region
#Region "IP Address"

    ''' <summary>
    ''' Return IP Address of User
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

#End Region
End Class
