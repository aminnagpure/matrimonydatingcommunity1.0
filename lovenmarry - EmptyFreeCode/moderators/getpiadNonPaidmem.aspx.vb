Imports System.Data.SqlClient

Partial Class getpiadNonPaidmem
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Dim queryforentry As String = ""


    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim sqlcountry As String = ""
        Dim sqlstate As String = ""
        Dim sqlcity As String = ""
        Dim sqlpincode As String = ""
        Dim sqlgender As String = ""
        Dim sqlrace As String = ""
        Dim sqlreligion As String = ""
        Dim sqlstarsign As String = ""
        Dim sqlmaritalstatus As String = ""
        Dim sqlheight As String = ""
        Dim sqlage As String = ""
        Dim sqlmarital As String = ""
        Dim sqlonline As String = ""
        Dim sqlchkphoto As String = ""
        Dim sqlpaidonon As String = ""
        'Dim sqlphoto As String = ""

        If dpcountry.Text <> "" Then
            sqlcountry = " profile.approved='Y' and profile.countryid=" & dpcountry.SelectedValue & " "

        End If
        If txtstate.Text <> "" Then
            sqlstate = " and profile.state like '%" & txtstate.Text & "%'"
        End If

        If txtCity.Text <> "" Then
            sqlcity = " and profile.cityid like '%" & txtCity.Text & "%'"
        End If

        If txtpincode.Text <> "" Then
            sqlpincode = " and profile.zipcode like '%" & txtpincode.Text & "%'"
        End If

        If gender.SelectedValue.ToString <> "" Then
            sqlgender = " and profile.gender='" & gender.SelectedValue.ToString & "'"
        End If

        If dpRace.Text <> "" Then
            sqlrace = " and profile.ethnic='" & dpRace.SelectedValue.ToString & "'"
        End If

        If dpreligion.Text <> "" Then
            sqlreligion = " and profile.religion='" & dpreligion.Text & "'"
        End If

        If dpmaritalstatus.SelectedValue <> "" Then
            sqlmarital = " and profile.maritalstatus='" & dpmaritalstatus.SelectedValue & "'"
        End If

        If dpstarsign.Text <> "" Then
            sqlstarsign = " and profile.starsign='" & dpstarsign.Text & "'"
        End If

        If dpheight1.SelectedValue <> "" Then
            sqlheight = " and height>=" & dpheight1.SelectedValue & ""
        End If

        If dpheight2.SelectedValue <> "" Then
            sqlheight = sqlheight & " and height<=" & dpheight2.SelectedValue & ""
        End If

        If dpage1.Text <> "" Then
            sqlage = " and DateDiff(yyyy,profile.bdate,getdate())>=" & dpage1.Text
        End If

        If dpage2.Text <> "" Then
            sqlage = sqlage & " and DateDiff(yyyy,profile.bdate,getdate())<=" & dpage2.Text
        End If

        If chkonlinenow.Checked = True Then
            sqlonline = " and isonlinenow='Y'"
        End If

        If chkphoto.Checked = True Then
            txtjointype.Text = " inner join"
            sqlchkphoto = " and photo<>'' "
        Else
            txtjointype.Text = " Left join"

        End If

        sqlpaidonon = " and premiummem ='" & ddlPaidNone.SelectedItem.Value & "'"


        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonline & sqlchkphoto & sqlcity & sqlchkphoto & sqlpaidonon & " and  mobile<>''"
        txtquery.Text = makequery
        response.write(makequery)
        Return makequery
    End Function
    Function addalertentry(ByVal query As String, ByVal em As String) As String

        Dim cnstring As String = ""

        Dim cc As New comonfunctions
        Dim rzlt As String = ""
        Dim regmsg As String = ""
        Dim uid As String = ""
        Dim strfield As String = ""
        Dim strvalues As String = ""
        Dim StrSql As String = ""

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand




        con.ConnectionString = cf.friendshipdb
        con.Open()

        uid = Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Millisecond

        strfield = " insert into alert(candiid,query,queryname,email,jointype) values("
        strvalues = " @candiid,@query,@queryname,@email,@jointype)"

        StrSql = strfield & strvalues


        If checkingnoofentryies() >= 10 Then
            con.Close()
            addalertentry = "you can only save 10 enteries "
        Else


            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@query", txtquery.Text & "  ")
            cmd.Parameters.AddWithValue("@queryname", txtqueryname.Text.ToString)
            cmd.Parameters.AddWithValue("@email", txtemail.Text.ToString)
            cmd.Parameters.AddWithValue("@jointype", txtjointype.Text)

            cmd.Connection = con
            cmd.CommandText = StrSql
            cmd.ExecuteNonQuery()

            regmsg = "Alert Verification Required <br>"
            regmsg = regmsg & "http://www." & ConfigurationManager.AppSettings("websitename").ToString & "/members/verifyalert.aspx?alertid=" & uid & "&b=" & Session("pid").ToString
            regmsg = regmsg & "<br>You have got this email because you have created Partner alert"

            If txtemail.Text.ToString <> "" Then
                rzlt = cc.send25("alert", "Alert Query Verification", em.ToString, regmsg)
            End If

            cmd.Dispose()
            con.Close()

            addalertentry = "Alert Entry added " & rzlt
        End If


    End Function

    Function checkingnoofentryies() As Integer
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim numbofrows As Integer = 0

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "[alertcount] " & Session("pid") & ""


        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                numbofrows = myreader.GetValue(0).ToString
            End While
            cn.Close()
            Return numbofrows
        Else
            cn.Close()
            Return numbofrows
        End If
    End Function


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        searchform.Visible = False

        ' Session("makequery") = makequery()
        txtquery.Text = makequery()
        searchresults.Visible = True
        If txtqueryname.Text <> "" Then
            addalertentry(queryforentry, txtemail.Text)
        End If

        'gridview1.DataSourceID = ObjectDataSource1.ID
        'gridview1.DataBind()

        ' Response.Redirect("findpartnerlist.aspx")
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = True Then
            searchresults.Visible = True
        Else
            loadcountry()
        End If
    End Sub
    Sub loadcountry()
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""

        strsql = "loadcountry"
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        dpcountry.DataSource = myreader
        dpcountry.DataValueField = "countryid"
        dpcountry.DataTextField = "countryname"
        dpcountry.DataBind()

        cmd.Dispose()
        cn.Close()
    End Sub

    Protected Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridview1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photopassw"), String)
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photoname"), String)

            If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/Thumbs/" & url
                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If
            End If

            If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
                End If
            End If


        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        searchresults.Visible = False
        If Not Session("pid") Is Nothing Then
            If Session("hasinvites") = "N" Then
                '   Response.Redirect("compulsorySteps.aspx")
            ElseIf Session("headline") = "" Then
                '  Response.Redirect("compulsorySteps.aspx")
            End If
        Else
            '    Response.Redirect("../login.aspx")
        End If

        If Not Page.IsPostBack Then
            txtquery.Text = "1<>1"

        End If
    End Sub
End Class
