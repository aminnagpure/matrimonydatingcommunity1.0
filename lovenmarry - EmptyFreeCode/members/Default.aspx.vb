Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.IO
Imports Facebook

Partial Class members_Default
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HyperLink7.NavigateUrl = "viewprofile.aspx?pid=" & Session("pid")

        Try
            LoadSiteActivity()
        Catch ex As Exception

        End Try
        If Not Session("pid") Is Nothing Then
            'If Session("hasinvites") = "N" Then
            '    Response.Redirect("compulsorySteps.aspx")
            'ElseIf Session("headline") = "" Then
            '    Response.Redirect("compulsorySteps.aspx")
            'End If
            HyperLink19.NavigateUrl = "~/JoinUs.aspx?affid=" & Session("pid")
        Else
            Response.Redirect("../login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri)
        End If
        If Request.Cookies("PC") IsNot Nothing Then
            Try
                If Request.Cookies("PC")("P") = "N" Then
                    Response.Redirect("EditReg.aspx?msg=complete your profile#P")
                    Exit Sub
                End If
            Catch ex As Exception

        End Try
            '    Try
            '        If Request.Cookies("PC")("W") = "N" Then
            '            Response.Redirect("EditReg.aspx?msg=complete your profile#W")
            '            Exit Sub
            '        End If
            '    Catch ex As Exception

            'End Try
            '    Try
            '        If Request.Cookies("PC")("M") = "N" Then
            '                Response.Redirect("EditReg.aspx?msg=complete your profile#M")
            '                Exit Sub
            '        End If
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        If Request.Cookies("PC")("A") = "N" Then
            '                Response.Redirect("EditReg.aspx?msg=complete your profile#A")
            '                Exit Sub
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Try
            '    If Request.Cookies("Photo").Value = "N" Then
            '        Response.Cookies("photo").Value = "Y"
            '        'Response.Redirect("uploadphoto.aspx?msg=Upload Photo")
            '        Exit Sub
            '    End If
            'Catch ex As Exception

            'End Try
        End If
        If Session("isfacebookposted") IsNot Nothing Then
            'If Session("isfacebookposted") = "N" Then
            '    Response.Redirect("FacebookUpdate.aspx")
            'End If
        Else
            CheckAuthorization()
        End If
        If Session("addme") IsNot Nothing Then
            If Session("addme") = "N" Then
                Response.Redirect("addme.aspx")
            End If
        End If
        If Not IsPostBack Then
            loadProfileNearMe()

        End If
      End Sub
    Sub LoadSiteActivity()
        Dim pid As Integer = 0
        Try
            Try
                pid = Session("pid")
            Catch ex As Exception

            End Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "Siteactivity_get"
            Dim ds As New DataSet
            ds = cf.ExecuteDataset(cmd)
            GridViewsiteactivity.DataSource = ds.Tables(0)
            GridViewsiteactivity.DataBind()
            gridForums.DataSource = ds.Tables(1)
            gridForums.DataBind()
            gridArticals.DataSource = ds.Tables(3)
            gridArticals.DataBind()
            gridPoll.DataSource = ds.Tables(2)
            gridPoll.DataBind()
        Catch ex As Exception
            cf.send25("Err", "Error in load SiteActivity", "tiwariamitkumar70@gmail.com", ex.Message & vbCrLf & "<br /> PID:" & pid.ToString)
        End Try
    End Sub
#Region "FB"

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


        End If
        Session("isfacebookposted") = "Y"
        Dim strsql As String = ""
        strsql = "update [profile] set facebookpost='Y' where pid=" & Session("pid")
        cf.TaskmembSql(strsql)

    End Sub

#End Region

    Sub loadProfileNearMe()
        Dim pid As Integer = 0
        Try
            Try

                pid = Session("pid")
            Catch ex As Exception

            End Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "get_ProfileNearME"
            cmd.Parameters.AddWithValue("@candiid", pid)
            Dim ds As New DataSet
            ds = cf.ExecuteDataset(cmd)
            dlThumbnails.DataSource = ds.Tables(0)
            dlThumbnails.DataBind()

        Catch ex As Exception
            cf.send25("Err", "Error in Profile Near Me", "tiwariamitkumar70@gmail.com", ex.Message & vbCrLf & "<br /> PID:" & pid.ToString)
        End Try
    End Sub
    Protected Sub dlThumbnails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlThumbnails.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim Photoname As String = TryCast(DataBinder.Eval(e.Item.DataItem, "photoname"), String)
            Dim img As Image = DirectCast(e.Item.FindControl("img"), Image)

            If File.Exists(Server.MapPath("../App_Themes/Thumbs/" & Photoname)) Then
                img.ImageUrl = "../App_Themes/Thumbs/" & Photoname
            Else
                img.ImageUrl = "../App_Themes/no_avatar.gif"
            End If

        End If

    End Sub
    Protected Sub GridViewsiteactivity_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewsiteactivity.RowDataBound, gridForums.RowDataBound, gridArticals.RowDataBound, gridPoll.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "UserPhoto"), String)
            Dim GImg As String = TryCast(DataBinder.Eval(e.Row.DataItem, "Photo"), String)

            If (url <> "" Or url IsNot Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("imgAct"), Image)
                If img IsNot Nothing Then
                    If File.Exists(Server.MapPath("../App_Themes/Thumbs/" & url)) Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    ElseIf GImg <> "" Then
                        img.ImageUrl = GImg
                    End If

                End If
            End If

        End If
    End Sub
#Region "DateFunction"

    Function DateFormatUpdates(ByVal d As Date) As String
        Dim newDate As String = ""
        Dim YY As Integer = d.Year
        Dim MM As Integer = d.Month
        Dim DD As Integer = d.Day
        Dim DateDiff As Integer = 0
        If DD = Date.Now.Day And MM = Date.Now.Month And YY = Date.Now.Year Then
            DateDiff = Date.Now.Hour - d.Hour
            If DateDiff = 0 Then
                DateDiff = Date.Now.Minute - d.Minute
                newDate = DateDiff & " Minutes before"
            Else
                newDate = DateDiff & " Hours before"
            End If

        ElseIf MM = Date.Now.Month And YY = Date.Now.Year Then
            DateDiff = Date.Now.Hour - d.Hour
            If DateDiff < 0 Then
                DateDiff = DateDiff + 24
                newDate = DateDiff
                DateDiff = (Date.Now.Day - d.Day) - 1
            Else
                newDate = DateDiff
                DateDiff = Date.Now.Day - d.Day
            End If
            If DateDiff = 0 Then
                newDate = newDate & " Hours before"
            Else
                newDate = DateDiff & " Day " & newDate & " Hours before"
            End If

        ElseIf YY = Date.Now.Year Then
            DateDiff = Date.Now.Day - d.Day
            If DateDiff < 0 Then
                DateDiff = DateDiff + System.DateTime.DaysInMonth(d.Year, d.Month)
                newDate = DateDiff
                DateDiff = (Date.Now.Month - d.Month) - 1

            Else
                newDate = DateDiff
                DateDiff = Date.Now.Month - d.Month
            End If
            If DateDiff = 0 Then
                DateDiff = Date.Now.Hour - d.Hour
                If DateDiff < 0 Then
                    DateDiff = DateDiff + 24

                End If
                newDate = newDate & " Days " & DateDiff & " Hours before"
            Else
                newDate = DateDiff & " Month " & newDate & " Day before"
            End If

        Else
            DateDiff = Date.Now.Month - d.Month

            If DateDiff <= 0 Then
                DateDiff = DateDiff + 12
                newDate = DateDiff
                DateDiff = (Date.Now.Year - d.Year) - 1
            Else
                newDate = DateDiff
                DateDiff = Date.Now.Year - d.Year
            End If
            If DateDiff = 0 Then
                newDate = newDate & " Month before"
            Else
                newDate = DateDiff & " Year " & newDate & " Month before"
            End If
        End If
        DateFormatUpdates = newDate
    End Function

#End Region
End Class
