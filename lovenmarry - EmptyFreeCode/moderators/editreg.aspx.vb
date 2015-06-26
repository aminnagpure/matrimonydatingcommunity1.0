Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_editreg
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions




    Sub loaddata()
        Dim strsql As String
        Dim da As SqlDataAdapter
        Dim con As New SqlConnection
        Dim ds As New DataSet


        'AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
        con.ConnectionString = cf.friendshipdb
        con.Open()

        'If Session("pid") = "" Then
        'Response.Redirect("login.aspx")
        'End If
        Label1.Text = ""
        strsql = "select top 1 * from profile where pid=" & Request.QueryString("pid") & ""
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

            txtbirthdate.Text = ds.Tables(0).Rows(0).Item("bdate")
            txtheadline.Text = ds.Tables(0).Rows(0).Item("headline").ToString

            txtcaste.Text = ds.Tables(0).Rows(0).Item("caste").ToString
            txtmothertounge.Text = ds.Tables(0).Rows(0).Item("mothertounge").ToString

            gender.SelectedValue = ds.Tables(0).Rows(0).Item("gender").ToString
            dpRace.SelectedValue = ds.Tables(0).Rows(0).Item("ethnic").ToString
            dpreligion.SelectedValue = ds.Tables(0).Rows(0).Item("religion").ToString
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

            txtstate.Text = ds.Tables(0).Rows(0).Item("state").ToString
            txtcity.Text = ds.Tables(0).Rows(0).Item("cityid").ToString
            txtpincode.Text = ds.Tables(0).Rows(0).Item("zipcode").ToString
            aboutme.Value = ds.Tables(0).Rows(0).Item("whoami").ToString
            lookingfor.Value = ds.Tables(0).Rows(0).Item("lookingfor").ToString

            txtpassword.Text = ds.Tables(0).Rows(0).Item("passw").ToString
            dpDiet.SelectedValue = ds.Tables(0).Rows(0).Item("diet").ToString
            dpSmoke.SelectedValue = ds.Tables(0).Rows(0).Item("smoke").ToString
            dpDrinks.SelectedValue = ds.Tables(0).Rows(0).Item("drink").ToString
            dpDrugs.SelectedValue = ds.Tables(0).Rows(0).Item("drugs").ToString



        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try


    End Sub

    Protected Sub reg_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles reg.FinishButtonClick
        Dim cnstring As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""

        cnstring = cf.friendshipdb
        cn.ConnectionString = cnstring
        cn.Open()


        Try



            Dim s1, s2, s3, s4, s5, s6 As String

            s1 = "update profile set fname=@fname,lname=@lname,bdate=@bdate,purpose=@purpose,gender=@gender,email=@email,countryid=@countryid,"
            s2 = "state=@state,cityid=@cityid,whoami=@whoami,lookingfor=@lookingfor,maritalstatus=@maritalstatus,mothertounge=@mothertounge,"
            s3 = "height=@height,annualincome=@annualincome,profession=@profession,passw=@passw,htname=@htname,eyesight=@eyesight,"
            s4 = "wt=@wt,complexion=@complexion,caste=@caste,religion=@religion,zipcode=@zipcode,ethnic=@ethnic,"
            s5 = "countryname=@countryname,lastupdated=@lastupdated,approved='Y',starsign=@starsign,haircolor=@haircolor,"
            s6 = "education=@education,smoke=@smoke,drink=@drink,diet=@diet,drugs=@drugs,headline=@headline"

            strsql = s1 & s2 & s3 & s4 & s5 & s6 & " where pid=" & Request.QueryString("pid") & ""
            'strfield = " insert into profile(pid,fname,lname,bdate,purpose,gender,email,countryid,state,cityname,whoami,lookingfor,maritalstatus,mothertounge,height,annualincome,highestdegree,profession,passw,htname,eyesight,wt,complexion,caste,religion,zipcode)"
            'strvalues = " values(@pi,@fname,@lname,@bdate,@purpose,@gender,@email,@countryid,@state,@cityname,@whoami,@lookingofr,@maritalstatus,@mothertounge,@height,@annualincome,@highestdegree,@profession,@passw,@htname,@eyesight,@wt,@complexion,@caste,@relgion,@zipcode)"

            'strsql = strfield & strvalues

            cmd.Parameters.AddWithValue("@fname", txtfname.Text.ToString)
            cmd.Parameters.AddWithValue("@lname", txtlastname.Text.ToString)
            cmd.Parameters.AddWithValue("@bdate", cf.convertdateforsql(txtbirthdate.Text.ToString))
            cmd.Parameters.AddWithValue("@purpose", dppurpose.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@gender", gender.SelectedValue.ToString)
            cmd.Parameters.AddWithValue("email", txtemail.Text.ToString)
            cmd.Parameters.AddWithValue("@countryid", dpcountry.SelectedValue)


            cmd.Parameters.AddWithValue("@state", txtstate.Text.ToString)
            cmd.Parameters.AddWithValue("@cityid", txtcity.Text.ToString)

            cmd.Parameters.AddWithValue("@whoami", Mid(aboutme.Value.ToString, 1, 700))
            cmd.Parameters.AddWithValue("@lookingfor", Mid(lookingfor.Value.ToString, 1, 500))
            cmd.Parameters.AddWithValue("@maritalstatus", dpmaritalstatus.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@mothertounge", txtmothertounge.Text.ToString)
            cmd.Parameters.AddWithValue("@height", dpheight.SelectedValue)
            cmd.Parameters.AddWithValue("@annualincome", txtanualincome.Text.ToString)
            cmd.Parameters.AddWithValue("@profession", txtprofession.Text.ToString)
            cmd.Parameters.AddWithValue("@passw", txtpassword.Text.ToString)
            cmd.Parameters.AddWithValue("@htname", dpheight.SelectedItem.Text.ToString)

            cmd.Parameters.AddWithValue("@eyesight", dpeyesight.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@wt", dpbodytype.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@complexion", dpskincolor.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@caste", txtcaste.Text.ToString)
            cmd.Parameters.AddWithValue("@religion", dpreligion.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@zipcode", txtpincode.Text.ToString)
            cmd.Parameters.AddWithValue("@ethnic", dpRace.SelectedItem.Text)

            cmd.Parameters.AddWithValue("@countryname", dpcountry.SelectedItem.Text.ToString)

            cmd.Parameters.AddWithValue("@lastupdated", Now.Date)
            cmd.Parameters.AddWithValue("@starsign", dpstarsign.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@haircolor", dphaircolor.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@education", dpeducation.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@smoke", dpSmoke.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@drink", dpDrinks.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@diet", dpDiet.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@drugs", dpDrugs.SelectedItem.Text.ToString)
            cmd.Parameters.AddWithValue("@headline", txtheadline.Text.ToString)

            cmd.Connection = cn
            cmd.CommandText = strsql

            cmd.ExecuteNonQuery()

            Label1.Text = "updated Sucessfully"
            cn.Close()
        Catch ex As Exception
            Response.Write(strsql)
            Response.Write(ex.ToString)
        End Try
        'FormsAuthentication.SetAuthCookie(txtemail.Text, False)
        'Response.Redirect("members/default.aspx")

    End Sub


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim strsql As String = ""

        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If

        If Not Page.IsPostBack Then
            Dim myreader As SqlDataReader

            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand

            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            strsql = "select countryid,countryname from country"

            cmd.Connection = cn
            cmd.CommandText = strsql

            myreader = cmd.ExecuteReader


            dpcountry.DataSource = myreader
            dpcountry.DataValueField = "countryid"
            dpcountry.DataTextField = "countryname"
            dpcountry.DataBind()

            loaddata()
            cn.Close()
        End If

    End Sub

End Class
