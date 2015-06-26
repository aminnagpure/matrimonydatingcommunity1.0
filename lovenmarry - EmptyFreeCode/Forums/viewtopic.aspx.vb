Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Forums_viewtopic
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Dim cn As New SqlConnection
    Dim candiid As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCriteria.Text = Request.QueryString("tid")
        'Response.Write(txtCriteria.Text)
        If Session("pid") = "" Then
            btnReplay.Visible = False
            Button3.Attributes.Add("onclick", "GoTo('../Login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri & "')")
            Button3.Visible = True
        Else
            candiid = Convert.ToInt32(Session("pid").ToString)
        End If


        If Not Page.IsPostBack Then
            fillforumcategory()

            'If Not IsNothing(Request.QueryString("flag")) Then
            '    If Request.QueryString("flag") = "Delete" Then
            '        deletecomment()
            '        Response.Redirect("~/Forums/viewtopic.aspx?id=" & Request.QueryString("id") & "")
            '    End If
            'End If

        End If
    End Sub
    Sub fillforumcategory()
        Dim tbl As String = ""
        Dim tbl1 As String = ""
        Try
            Dim strsql As String = ""

            Dim cmd As New SqlCommand
            Dim myreader As SqlDataReader
            Dim forumqnaid As String = ""
            Dim forumtopid As String = ""
            Dim question As String = ""
            Dim questdesc As String = ""
            Dim startedbyid As String = ""
            Dim updatebyid As String = ""
            Dim startedby As String = ""
            Dim updatedby As String = ""
            Dim starteddate As String = ""
            Dim updateddate As String = ""

            cn.ConnectionString = cf.friendshipdb

            strsql = "getTopicDetails"

            cmd.CommandText = strsql
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TopicId", Request.QueryString("tid"))
            cn.Open()
            cmd.Connection = cn
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            cn.Close()

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    forumqnaid = dt.Rows(i)("TopicId")
                    question = dt.Rows(i)("TopicTitle").ToString
                    questdesc = dt.Rows(i)("TopicDesc")

                    forumtopid = dt.Rows(i)("SubCatId")

                    Page.Title = dt.Rows(i)("TopicTitle")

                    startedbyid = dt.Rows(i)("CandiId")
                    startedby = dt.Rows(i)("fname")
                    updatebyid = dt.Rows(i)("UpdateCandiId")
                    updatedby = dt.Rows(i)("UpdateCandiName")
                    starteddate = dt.Rows(i)("StartDate")
                    updateddate = dt.Rows(i)("UpdateDate")
                    'tbl1 = tbl1 & "<tr><td align='top' class='Topic'><span>" & cf.BreakWordForWrap(question) & "</span><br>" & cf.BreakWordForWrap(questdesc) & "<br><br></td><td valign='top'><a href='../viewprofile.aspx?id=" & startedbyid & "'>" & startedby & "</a> </td><td valign='top'>" & starteddate & " </td></tr>"
                    tdstartdate.InnerHtml = starteddate
                    divTopic.InnerHtml = "Thread: " & question
                    divTopicDesc.InnerHtml = questdesc
                    divStartedby.InnerHtml = "<a href=""../viewprofile.aspx?pid=" & startedbyid & """ >" & startedby & "</a>"
                    divTotalTopic.InnerHtml = "<br />Total Threads: " & dt.Rows(i)("TotalThread") & "<br />Total Replies:&nbsp;&nbsp; " & dt.Rows(i)("TotalReplay")
                    If ((Session("mrole") = "mod") Or (candiid = startedbyid)) Then
                        If (Session("pid") Is Nothing) Then
                            btnDelRel.Visible = False
                        Else
                            btnDelRel.Visible = True
                        End If

                    Else
                        btnDelRel.Visible = False
                    End If
                    Dim posterImg As String = "../App_Themes/Thumbs/" & dt.Rows(i)("photo")
                    If System.IO.File.Exists(Server.MapPath(posterImg)) Then
                        imgposter.ImageUrl = posterImg
                    End If
                Next

            End If
            tbl = tbl1 '& replies()
            'forumcat.InnerHtml = "<table style=""Width:100%;""><tr><td align='top' >Topic</td><td align='top'>Started/Updated By</td><td align='top'>Date</td>" & "</td> " & tbl & " </table>"
            ' HyperLink1.NavigateUrl = "posttopic.aspx?id=" & Request.QueryString("id")
            'HyperLink1.NavigateUrl = "replytopic.aspx?id=" & forumqnaid & "&tid=" & Request.QueryString("tid")
            cmd.Dispose()
            cn.Close()
        Catch ex As Exception
            Response.Write(ex.ToString)
            cn.Close()

        End Try

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If Session("pid") Is Nothing Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
        If e.CommandName = "IDelete" Then
            deleterec(e.CommandArgument)
            GridView1.DataSourceID = ObjectDataSource1.ID
            GridView1.DataBind()
        End If
    End Sub
    Sub deleterec(ByVal reqid As String)
        Dim cmd As New SqlCommand
        cmd.CommandText = "deleteAnswer"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@AnsId", reqid)
        cf.ExecuteNonQuery(cmd, cf.friendshipdb)
    End Sub



    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'Add CSS class on header row.
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.CssClass = "header1"
        End If

        'Add CSS class on normal row.
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            e.Row.CssClass = "normal1"
        End If

        'Add CSS class on alternate row.
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Alternate Then
            e.Row.CssClass = "alternate1"
        End If

        Dim pasw As String = "" ' TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
        Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photo"), String)

        If e.Row.RowType = DataControlRowType.DataRow Then


            If (url <> "" Or url IsNot Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    If System.IO.File.Exists(Server.MapPath("../App_Themes/Thumbs/" & url)) Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    Else
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If

                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If
            End If


            Dim btuDel As Button = DirectCast(e.Row.FindControl("btnDelete"), Button)
            If ((Session("mrole") = "mod") Or (candiid = DataBinder.Eval(e.Row.DataItem, "CandiId"))) Then
                btuDel.Visible = True
            Else
                btuDel.Visible = False
            End If



        End If

    End Sub

    Protected Sub btnDelRel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelRel.Click
        If Session("pid") Is Nothing Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
        Dim cmd As New SqlCommand
        cmd.CommandText = "deleteTopic"
        cmd.Parameters.AddWithValue("@TopicId", Request.QueryString("tid"))
        cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        Response.Redirect("topics.aspx?id=" & Request.QueryString("tid"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Session("pid") = "" Then
            Response.Redirect("~/login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If


        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt As String = ""
        Dim ipadd As String = ""
        Dim doubtfulprofile As String = "Y"
        Dim ipcountry As String = ""
        Dim updatedby As String = ""

        'pid = "A" & cf.generateid


        sql = "InsertAnswer"

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        'TextBox1.Text = cf.ReplaceBadWords(Replace(TextBox1.Text, vbCrLf, "<br>"))

        Try
            'Request.Cookies("candiid").Value  = "23434
            updatedby = Session("fname")

            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = sql

            Dim tid As Integer = Request.QueryString("tid")
            Dim tpans As String = Mid(cf.ReplaceBadWords(Replace(TextBox1.Text, vbCrLf, "<br>")), 1, 5000)
            Dim id As Integer = Session("pid")

            cmd.Parameters.AddWithValue("@TopicId", tid)
            cmd.Parameters.AddWithValue("@TopicAns", tpans)
            cmd.Parameters.AddWithValue("@CandiId", id)
            cmd.Parameters.AddWithValue("@AnsDate", Date.Now)
            cmd.Parameters.AddWithValue("@UpdateyByName", updatedby)
            pid = cmd.ExecuteScalar()


            'sql = "update forumqandA set updateddate=getdate(),updatebyid=" & Request.Cookies("candiid").Value  & ",updatedby='" & updatedby & "'  where forumqnaid=" & Request.QueryString("id")
            'cf.Taskjobseeker(sql)
            insertUpdateActivity(pid, updatedby)
            cmd.Dispose()
            cn.Close()

            pid = Request.QueryString("id")
            'forumheading(pid)
            Response.Redirect("viewtopic.aspx?id=" & Request.QueryString("id") & "&tid=" & Request.QueryString("tid"))
        Catch ex As Exception
            cn.Close()
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
        Dim Subject As String = TextBox1.Text
        Dim tid As String = ""
        tid = request.querystring("tid")
        If Subject.Length > 40 Then
            Subject = Subject.Substring(0, 35)
            Subject = Subject.Substring(0, 35) & "..."
        End If
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has replied <a href='http://" & cf.websitename & "/Forums/viewtopic.aspx?tid=" & tid & "'>" & Subject & "</a> on a Topic"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "TopicRep"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub
End Class
