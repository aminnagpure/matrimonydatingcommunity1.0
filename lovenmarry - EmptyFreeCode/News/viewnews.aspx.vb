Imports System.Data
Imports System.Data.SqlClient
Partial Class news_viewnews
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("scammer") IsNot Nothing Then
            Response.Redirect("../usedbyscammers.aspx")
        End If


        Dim kk = Request.QueryString("id")
        If kk IsNot Nothing Then
            If IsNumeric(kk) = True Then
            Else

                Session("scammer") = "yes"
                Response.Redirect("../usedbyscammers.aspx")
                cf.send25("scammer", "attack on lovenmarry", "aminnagpure@gmail.com", Request.QueryString("id"))

            End If
        End If


        TextBox1.Text = Request.QueryString("id")
        ' HyperLink3.NavigateUrl = "postcomment.aspx?id=" & Request.QueryString("id")

        If Not Page.IsPostBack Then
            viewdata()
        End If


    End Sub
    Sub viewdata()
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim strsql As String = ""
        Dim imgurl As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        strsql = "viewnews " & Request.QueryString("id")

        cmd.CommandText = strsql
        cmd.Connection = cn
        myreader = cmd.ExecuteReader


        If myreader.HasRows = True Then
            While myreader.Read
                tdheadline.InnerText = myreader.GetValue(0)
                tdcontent.InnerHtml = myreader.GetValue(1)
                Page.Title = myreader.GetValue(0)
                tddate.InnerText = "Posted on " & myreader.GetValue(2)
                HyperLink1.NavigateUrl = myreader.GetValue(3)
                HyperLink1.Text = myreader.GetValue(3)
                imgurl = myreader.GetValue(4).ToString

                If imgurl = "" Then
                    imgurl = "../App_Themes/no_avatar.gif"
                Else
                    imgurl = "../App_Themes/thumbs/" & imgurl
                End If
                profiledetails.InnerHtml = "<a href='../viewprofile.aspx?pid=" & myreader.GetValue(5).ToString & "'>" & myreader.GetValue(6).ToString & "  " & myreader.GetValue(7).ToString & "</a><br><img src='" & imgurl & "'>"
            End While
        End If
        cmd.Dispose()
        cn.Close()

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "IDelete" Then
            deleterec(e.CommandArgument)
        End If

    End Sub

    Sub deleterec(ByVal reqid As String)
        Dim cmd As New SqlCommand
        cmd.CommandText = "Usp_Delete_News_Commnet"
        cmd.Parameters.AddWithValue("@Id", reqid)
        cf.ExecuteNonQuery(cmd)


        GridView1.DataSourceID = ObjectDataSource1.ID
        GridView1.DataBind()
        cmd.dispose()

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = "" ' TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photo"), String)

            If (url <> "" Or url IsNot Nothing) Then
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




            Dim btuDel As Button
            btuDel = DirectCast(e.Row.FindControl("btnDelete"), Button)
            If Not (btuDel Is Nothing) Then
                Dim str As String = ""
                str = DataBinder.Eval(e.Row.DataItem, "candiid")
                If Session("mrole") Is Nothing Then
                    Session("mrole") = ""
                End If
                If Session("pid") Is Nothing Then
                    Session("pid") = ""
                End If


                If ((Session("mrole") = "mod") Or (Session("pid") = str)) Then
                    If (Session("pid") Is Nothing) Then
                        btuDel.Visible = False
                    Else
                        btuDel.Visible = True
                    End If
                Else
                    btuDel.Visible = False
                End If
            End If

        End If
    End Sub
    Protected Sub btnPostComments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPostComments.Click
        If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim pid As String = ""
        pid = cf.generateid
        Dim sql As String = ""
        Dim email As String = ""
        Dim msg As String = ""
        sql = "insert into newscomments(candiid,comment,newsid) values(@candiid,@comment,@newsid)"
        'Session("pid") = "J201011122437260"
        Try
            If Session("fname") Is Nothing Then
                Session("fname") = cf.getCandiName(Session("pid"))
            ElseIf Session("fname") = "" Then
                Session("fname") = cf.getCandiName(Session("pid"))
            End If

            cn.ConnectionString = cf.friendshipdb
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = sql


            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@comment", txtComments.Text.Trim.Replace(ControlChars.Lf, "<br />"))
            cmd.Parameters.AddWithValue("@newsid", Request.QueryString("id"))
            cmd.ExecuteNonQuery()

            btnPostComments.Enabled = False
            btnPostComments.Text = "Comment Posted"

            cmd.Dispose()
            cn.Close()
            insertUpdateActivity(Request.QueryString("id"), Session("fname"))
            Response.Redirect("viewnews.aspx?id=" & Request.QueryString("id"))

        Catch ex As Exception
            Response.Write(ex.ToString)


        End Try

    End Sub
    Sub insertUpdateActivity(ByVal id As Integer, ByVal fn As String)
        Dim act As New SiteAcitvity
        act.candiid = Session("pid")
        act.fn = fn
        act.activitydate = Date.Now
        Dim str As String = ""
        str = "<div><table>"
        str = str & "<tr><td>"
        Dim Subject As String = txtComments.Text
        If Subject.Length > 40 Then
            Subject = Subject.Substring(0, 35)
            Subject = Subject.Substring(0, 35) & "..."
        End If
        Dim Subject1 As String = tdheadline.InnerText
        If Subject1.Length > 40 Then
            Subject1 = Subject1.Substring(0, 35)
            Subject1 = Subject1.Substring(0, 35) & "..."
        End If

        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has commented <a href='" & Request.Url.AbsoluteUri & "'>" & Subject & "</a> on a Love Articles <a href='" & Request.Url.AbsoluteUri & "'>" & Subject1 & "</a>"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "ArtRep"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub
End Class
