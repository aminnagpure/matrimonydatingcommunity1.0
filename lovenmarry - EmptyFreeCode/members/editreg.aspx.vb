
Imports System.Data
Imports System.Data.SqlClient

Partial Class members_editreg
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

   
    Sub loaddata()
        Dim strsql As String
        Dim da As SqlDataAdapter
        Dim con As New SqlConnection
        Dim ds As New DataSet
        Dim bd As String = ""


        'AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
        con.ConnectionString = cf.friendshipdb
        con.Open()

        'If Session("pid") = "" Then
        'Response.Redirect("login.aspx")
        'End If
        Label1.Text = ""
        strsql = "editreg " & Session("pid") & ""
        'Response.Write(strsql)
        'Response.End()

        Try
            da = New SqlDataAdapter(strsql, con)
            da.Fill(ds, "profile")

            con.Close()

            'Response.Write(strsql)
            'Response.End()

            txtemail.Text = ds.Tables(0).Rows(0).Item("email").ToString
            txtfname.Text = ds.Tables(0).Rows(0).Item("fname").ToString
            txtlastname.Text = ds.Tables(0).Rows(0).Item("lname").ToString
            bd = ds.Tables(0).Rows(0).Item("bdate")
            DropDownList1.Text = Month(bd)
            ddl_year.Text = Year(bd)
            ddldays.Text = Day(bd)
            '     txtbirthdate.Text = ds.Tables(0).Rows(0).Item("bdate")
            txtheadline.Text = ds.Tables(0).Rows(0).Item("headline").ToString
            dpreligion.SelectedValue = ds.Tables(0).Rows(0).Item("religion").ToString
            getCast(dpreligion.SelectedItem.Text)
            ddlCast.SelectedIndex = ddlCast.Items.IndexOf(ddlCast.Items.FindByText(ds.Tables(0).Rows(0).Item("caste").ToString))
            ddlMotherToung.SelectedValue = ds.Tables(0).Rows(0).Item("mothertounge").ToString

            gender.SelectedValue = ds.Tables(0).Rows(0).Item("gender").ToString
            dpRace.SelectedValue = ds.Tables(0).Rows(0).Item("ethnic").ToString

            dppurpose.SelectedValue = ds.Tables(0).Rows(0).Item("purpose").ToString

            dpheight.SelectedValue = ds.Tables(0).Rows(0).Item("height")
            dpbodytype.SelectedValue = ds.Tables(0).Rows(0).Item("wt").ToString
            dpeyesight.SelectedValue = ds.Tables(0).Rows(0).Item("eyesight").ToString
            dphaircolor.SelectedValue = ds.Tables(0).Rows(0).Item("haircolor").ToString
            dpstarsign.SelectedValue = ds.Tables(0).Rows(0).Item("starsign").ToString
            dpmaritalstatus.SelectedValue = ds.Tables(0).Rows(0).Item("maritalstatus").ToString


            dpeducation.SelectedValue = ds.Tables(0).Rows(0).Item("education").ToString
            txtprofession.Text = ds.Tables(0).Rows(0).Item("profession").ToString
            txtanualincome.Text = ds.Tables(0).Rows(0).Item("annualincome").ToString

            '            Response.Write(ds.Tables(0).Rows(0).Item("countryid"))
            '      dpcountry.SelectedIndex = 5
            dpcountry.SelectedValue = ds.Tables(0).Rows(0).Item("countryid")

            dpstate.SelectedValue = ds.Tables(0).Rows(0).Item("stateid").ToString
            fillcities()
            dpCity.SelectedValue = ds.Tables(0).Rows(0).Item("cityid").ToString

            txtpincode.Text = ds.Tables(0).Rows(0).Item("zipcode").ToString
            aboutme.Value = ds.Tables(0).Rows(0).Item("whoami").ToString
            lookingfor.Value = ds.Tables(0).Rows(0).Item("lookingfor").ToString

            txtpassword.Text = ds.Tables(0).Rows(0).Item("passw").ToString
            dpDiet.SelectedValue = ds.Tables(0).Rows(0).Item("diet").ToString
            dpSmoke.SelectedValue = ds.Tables(0).Rows(0).Item("smoke").ToString
            dpDrinks.SelectedValue = ds.Tables(0).Rows(0).Item("drink").ToString
            dpDrugs.SelectedValue = ds.Tables(0).Rows(0).Item("drugs").ToString
            txtmobile.Text = ds.Tables(0).Rows(0).Item("mobile").ToString
            hdnPM.Value = ds.Tables(0).Rows(0).Item("P_motherTounge").ToString
            da.Dispose()

            con.Close()
        Catch ex As Exception
            con.Close()
            Response.Write(ex.ToString)
        End Try


    End Sub

    Protected Sub reg_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles reg.FinishButtonClick

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""
        Dim bd As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        Try



            Dim s1, s2, s3, s4, s5, s6 As String

            s1 = "update profile set fname=@fname,lname=@lname,bdate=@bdate,purpose=@purpose,gender=@gender,email=@email,countryid=@countryid,"
            s2 = "stateid=@stateid,state=@state,cityid=@cityid,cityname=@cityname,whoami=@whoami,lookingfor=@lookingfor,maritalstatus=@maritalstatus,mothertounge=@mothertounge,"
            s3 = "height=@height,annualincome=@annualincome,profession=@profession,passw=@passw,htname=@htname,eyesight=@eyesight,"
            s4 = "wt=@wt,complexion=@complexion,caste=@caste,religion=@religion,zipcode=@zipcode,ethnic=@ethnic,"
            s5 = "countryname=@countryname,lastupdated=getdate(),approved=@approved,starsign=@starsign,haircolor=@haircolor,"
            s6 = "education=@education,smoke=@smoke,drink=@drink,diet=@diet,drugs=@drugs,headline=@headline,mobile=@mobile"

            strsql = s1 & s2 & s3 & s4 & s5 & s6 & " where pid=" & Session("pid") & ""
            'strfield = " insert into profile(pid,fname,lname,bdate,purpose,gender,email,countryid,state,cityname,whoami,lookingfor,maritalstatus,mothertounge,height,annualincome,highestdegree,profession,passw,htname,eyesight,wt,complexion,caste,religion,zipcode)"
            'strvalues = " values(@pi,@fname,@lname,@bdate,@purpose,@gender,@email,@countryid,@state,@cityname,@whoami,@lookingofr,@maritalstatus,@mothertounge,@height,@annualincome,@highestdegree,@profession,@passw,@htname,@eyesight,@wt,@complexion,@caste,@relgion,@zipcode)"

            'strsql = strfield & strvalues

            cmd.Parameters.AddWithValue("@fname", txtfname.Text.ToString)
            cmd.Parameters.AddWithValue("@lname", txtlastname.Text.ToString)
            bd = ddl_year.SelectedItem.Text & "-" & DropDownList1.SelectedValue & "-" & ddldays.SelectedItem.Text
            cmd.Parameters.AddWithValue("@bdate", bd)
            cmd.Parameters.AddWithValue("@purpose", dppurpose.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@gender", gender.SelectedValue.ToString)
            cmd.Parameters.AddWithValue("email", txtemail.Text.ToString)
            cmd.Parameters.AddWithValue("@countryid", dpcountry.SelectedValue)


            cmd.Parameters.AddWithValue("@stateid", dpstate.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@state", dpstate.SelectedItem.Text)

            cmd.Parameters.AddWithValue("@cityid", dpCity.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@cityname", dpCity.SelectedItem.Text)


            cmd.Parameters.AddWithValue("@whoami", Mid(cf.ReplaceBadWords(aboutme.Value.ToString), 1, 700))
            cmd.Parameters.AddWithValue("@lookingfor", Mid(cf.ReplaceBadWords(lookingfor.Value.ToString), 1, 500))
            cmd.Parameters.AddWithValue("@maritalstatus", dpmaritalstatus.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@mothertounge", ddlMotherToung.SelectedItem.Value.ToString)
            cmd.Parameters.AddWithValue("@height", dpheight.SelectedValue)
            cmd.Parameters.AddWithValue("@annualincome", txtanualincome.Text.ToString)
            cmd.Parameters.AddWithValue("@profession", cf.ReplaceBadWords(txtprofession.Text.ToString))
            cmd.Parameters.AddWithValue("@passw", txtpassword.Text.ToString)
            cmd.Parameters.AddWithValue("@htname", dpheight.SelectedItem.Text.ToString)

            cmd.Parameters.AddWithValue("@eyesight", dpeyesight.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@wt", dpbodytype.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@complexion", dpskincolor.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@caste", ddlCast.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@religion", dpreligion.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@zipcode", txtpincode.Text.ToString)
            cmd.Parameters.AddWithValue("@ethnic", dpRace.SelectedItem.Text)

            cmd.Parameters.AddWithValue("@countryname", dpcountry.SelectedItem.Text.ToString)

            '   cmd.Parameters.AddWithValue("@lastupdated", Now.Date)
            If gender.SelectedValue.ToUpper = "F" Then
                cmd.Parameters.AddWithValue("@approved", "N")
                Session("approved") = "N"
            Else
                cmd.Parameters.AddWithValue("@approved", cf.autoapprove)
            End If
            cmd.Parameters.AddWithValue("@starsign", dpstarsign.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@haircolor", dphaircolor.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@education", dpeducation.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@smoke", dpSmoke.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@drink", dpDrinks.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@diet", dpDiet.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@drugs", dpDrugs.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@headline", cf.ReplaceBadWords(txtheadline.Text.ToString))
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text.ToString)


            cmd.Connection = cn
            cmd.CommandText = strsql

            cmd.ExecuteNonQuery()

            Session("headline") = txtheadline.Text
            Response.Cookies("PC")("P") = "Y"
            If gender.SelectedValue.ToUpper = "F" Then
                Label1.Text = "updated Sucessfully, will be waiting for approval, after every edit profile is verified once again"
            Else
                Label1.Text = "updated Sucessfully"
            End If
            If hdnPM.Value = "" Then
                Response.Redirect("PartnerProfile.aspx")
            End If
            cmd.Dispose()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            Response.Write(strsql)
            Response.Write(ex.ToString)
        End Try
        'FormsAuthentication.SetAuthCookie(txtemail.Text, False)
        'Response.Redirect("members/default.aspx")

    End Sub

    
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
     


        Dim Strsql As String = ""

        Strsql = "loadcountry"
        If Not Page.IsPostBack Then
            
            fillstates()
            ' fillcities()

            Populate_YearList()
            populatedays()
            populateMotherToung()
            loaddata()
            CheckPC()

        End If
    End Sub

    Protected Sub dpcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpcountry.SelectedIndexChanged
        Try

            dpstate.Items.Clear()
            dpCity.Items.Clear()
            fillstates()
            fillcities()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub dpstate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpstate.SelectedIndexChanged
        Try

            dpCity.Items.Clear()
            fillcities()
        Catch ex As Exception

        End Try
    End Sub
    Sub fillstates()
        Dim ds1 As New DataSet
        If Cache("chcloadcountry") Is Nothing Then
            ds1 = cf.LoadMasters()
            Cache("chcloadcountry") = ds1
        End If
        ds1 = Cache("chcloadcountry")
        ds1.Tables(1).DefaultView.RowFilter = "countryid=" & dpcountry.SelectedValue
        With dpstate
            .DataSource = ds1.Tables(1)
            .DataValueField = "stateid"
            .DataTextField = "statename"
            .DataBind()
            .Items.Insert(0, "--Select--")
            .Items.Item(0).Value = 0
        End With
    End Sub
    Sub fillcities()
        Dim ds1 As New DataSet
        If Cache("chcloadcountry") Is Nothing Then
            ds1 = cf.LoadMasters()
            Cache("chcloadcountry") = ds1
        End If
        ds1 = Cache("chcloadcountry")
        ds1.Tables(2).DefaultView.RowFilter = "stateid=" & dpstate.SelectedValue
        With dpCity
            .DataSource = ds1.Tables(2)
            .DataValueField = "cityid"
            .DataTextField = "cityname"
            .DataBind()
            .Items.Insert(0, "--Select--")
            .Items.Item(0).Value = 0
        End With
    End Sub

    Sub loadcountry()
        Dim ds1 As New DataSet
        If Cache("chcloadcountry") Is Nothing Then
            ds1 = cf.LoadMasters()
            Cache("chcloadcountry") = ds1
        End If
        ds1 = Cache("chcloadcountry")
        'ds1.Tables(0).DefaultView.RowFilter = "countryid=" & dpcountry.SelectedValue
        With dpcountry
            .DataSource = ds1.Tables(0)
            .DataValueField = "countryid"
            .DataTextField = "countryname"
            .DataBind()
            .Items.Insert(0, "--Select--")
            .Items.Item(0).Value = 0
        End With
    End Sub
    Sub Populate_YearList()
        Dim intYear As Integer

        'Year list can be changed by changing the lower and upper
        'limits of the For statement
        For intYear = DateTime.Now.Year - 58 To DateTime.Now.Year + 8
            ddl_year.Items.Add(intYear)
        Next

        'Make the current year selected item in the list
        ddl_year.Items.FindByValue(DateTime.Now.Year).Selected = "1980"

    End Sub


    Sub populatedays()
        Dim dys As Integer
        Dim i As Integer = 0
        ddldays.Items.Clear()
        dys = System.DateTime.DaysInMonth(ddl_year.Text, DropDownList1.SelectedValue)
        For i = 1 To dys
            ddldays.Items.Add(i)
        Next
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        populatedays()
    End Sub

    Protected Sub ddl_year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_year.SelectedIndexChanged
        populatedays()
    End Sub



    Sub CheckPC()
        If Request.Cookies("PC") IsNot Nothing Then
            Try
                If Request.Cookies("PC")("P") = "N" Then
                    ' lblMsgP.Text = "Complete Your Profile"
                    reg.ActiveStepIndex = 0
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            Try
                If Request.Cookies("PC")("W") = "N" Then
                    reg.ActiveStepIndex = 1
                    'lblMsgW.Text = "Update Your Physical Details"
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            Try
                If Request.Cookies("PC")("M") = "N" Then
                    reg.ActiveStepIndex = 3
                    'lblmsgL.Text = "Update Your Location"
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            Try
                If Request.Cookies("PC")("A") = "N" Then
                    reg.ActiveStepIndex = 4
                    'lblMsgA.Text = "Update About Your Self"
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub dpreligion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpreligion.SelectedIndexChanged
        getCast(dpreligion.SelectedItem.Text)
    End Sub

    Sub getCast(Optional ByVal Rel As String = "")
        Dim cmd As New SqlCommand
        cmd.CommandText = "Get_Cast_List"
        If Rel <> "" Then
            cmd.Parameters.AddWithValue("@Rel", Rel)
        End If
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)
        ddlCast.DataSource = ds.Tables(0)
        ddlCast.DataTextField = "Cast_N"
        ddlCast.DataValueField = "CastID"
        ddlCast.DataBind()
        Dim Li As New ListItem
        Li.Text = "Select Cast"
        Li.Value = ""
        ddlCast.Items.Insert(0, Li)
    End Sub

    Sub populateMotherToung()
        'Exit Sub

        Dim North() As String = {"Hindi/ Delhi", "Hindi /Madhya Pradesh / Bundelkhand / Chattisgarhi", "Hindi/U.P./Awadhi/ Bhojpuri/Garhwali", "Punjabi", "Bihari/Maithili/Magahi", "Rajasthani / Marwari / Malwi / Jaipuri", "Haryanvi", "Himachali/Pahari", "Kashmiri/Dogri", "Sindhi", "Urdu"}
        Dim West() As String = {"Marathi", "Gujarati / Kutchi", "Hindi /Madhya Pradesh / Bundelkhand / Chattisgarhi", "Konkani", "Sindhi"}
        Dim South() As String = {"Tamil", "Telugu", "Kannada", "Malayalam", "Tulu", "Urdu"}
        Dim East() As String = {"Bengali", "Oriya", "Assamese", "Sikkim/ Nepali/ Lepcha/ Bhutia/ Limbu"}
        Dim Eng() As String = {"English"}


        Dim item As New ListItem
        item.Text = ""
        ddlMotherToung.Items.Add(item)

        item = New ListItem
        item.Text = "North"
        item.Attributes("Group") = "North"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)

        For Each L As String In North
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "North"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "West"
        item.Attributes("Group") = "West"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)

        For Each L As String In West
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "West"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "South"
        item.Attributes("Group") = "South"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)
        For Each L As String In South
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "South"

            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "East"
        item.Attributes("Group") = "East"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)
        For Each L As String In East
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "East"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "-------"
        item.Attributes("Group") = "------"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "font-weight: bold;")
        item.Attributes.Add("disabled", "true")

        For Each L As String In Eng
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "Englist"
            ddlMotherToung.Items.Add(item)
        Next

    End Sub

End Class
