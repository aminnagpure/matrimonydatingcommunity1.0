Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class moderators_topics
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    'Dim strid As String

    'Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    '    'strid = Request.QueryString("id")
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'If Request.QueryString("id") = "4" Then
            '    Response.Redirect("../sports/Topics.aspx?id=4")
            'End If
            'If Request.QueryString("id") = "3" Then
            '    Response.Redirect("../Politics/Topics.aspx?id=3")
            'End If
            txtCriteria.Text = Request.QueryString("id")

            getGubCAt()
            'This is use for deletequery
            Try
                If Request.QueryString("NewTopic") <> "" Then
                    Label2.Text = "Topic Posted Successfully"
                    Label2.ForeColor = Drawing.Color.Blue
                    Label2.Font.Size = 15

                End If
            Catch
            End Try
            'If Request.Cookies("candiid").Value  IsNot Nothing Then
            '    HyperLink1.Visible = True
            HyperLink1.NavigateUrl = "posttopic.aspx?id=" & Request.QueryString("id") & "&mc=" & Request.QueryString("mc") & "&cid=" & Request.QueryString("cid")
            'Else
            '    HyperLink1.Visible = False
            'End If

            Call FormatDataGridView()
            ' Call checklogindelete()
            If Not IsNothing(Request.QueryString("flag")) Then
                If Request.QueryString("flag") = "Delete" Then
                    forumqnaid.Value = Request.QueryString("forumqnaid")
                    ' Session("forumqnaid.value") = Val(forumqnaid.Value)
                    Call Deletepost()

                    Response.Redirect("~/Forums/topics.aspx?id=" & Request.QueryString("id") & "&mc=" & Request.QueryString("mc") & "&Cid=" & Request.QueryString("Cid"))
                    'Response.Redirect("~/moderators/topics.aspx?id=" & Session("strid") & "&mc=" & Request.QueryString("mc") & " ")
                End If
            End If

        End If
    End Sub
    'This function is use for reply count for each post topic
    Function countreply(ByVal strforumqnaid As String) As Integer

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim cnt As Integer

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select count(answerid) from topicsQnAansw where forumqnaid=@id "
        cmd.Parameters.AddWithValue("@id", strforumqnaid)
        reader = cmd.ExecuteReader()

        While reader.Read
            cnt = reader.GetValue(0)
        End While

        cmd.Dispose()
        cn.Close()

        Return cnt
    End Function

    Protected Sub Deletepost()
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "deleteTopic"
        cmd.CommandType = CommandType.StoredProcedure
        ' delete from forumqandA where  forumqnaid=@id   update forumtopics set latesttopic=convert(varchar(200),k.question),startedbyid=k.startedbyid,updatebyid=k.updatebyid,latesttopicid=k.forumqnaid from forumtopics inner join (Select top 1 * from forumqanda where forumqnaid<>@id and forumtopid in (Select distinct forumtopid from forumqanda where forumqnaid=@id) order by updateddate desc)as k on forumtopics.forumtopid=k.forumtopid"
        cmd.Parameters.AddWithValue("@TopicId", Request.QueryString("TopicId"))
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Label1.Text = "Post Deleted Succesfully"

        Else
            'Response.Redirect("~/moderators/topics.aspx?id='" & Request.QueryString("id") & "' ")
            Label1.Text = "Post not Found"
        End If

        cmd.Dispose()
        cn.Close()

    End Sub
    '' TO display delete button
    Protected Sub FormatDataGridView()
        Dim i As Integer
        If Session("mrole") = "mod" Then
            For i = 0 To GridView1.Rows.Count - 1
                GridView1.Rows(i).Cells(4).Text = "<a style=""font-size: 12px;"" href='topics.aspx?flag=Delete&TopicId=" & GridView1.DataKeys(i).Value & "&id=" & Request.QueryString("id") & "' onclick='return comfirmdel();'>Delete</a>"
            Next
        Else
            GridView1.Columns(4).Visible = False
        End If

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
        If e.Row.RowType = DataControlRowType.DataRow Then
            '  Dim rc As Integer
            Dim strforumqnaid As String
            'Dim i As Integer
            'For i = 0 To GridView1.Rows.Count()
            strforumqnaid = GridView1.DataKeys(e.Row.RowIndex).Value
            'rc = countreply(strforumqnaid)
            'Dim lblreply As Label = DirectCast(e.Row.FindControl("lblreply"), Label)
            'lblreply.Text = "Reply:- " & rc.ToString()
            ' Next

            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photo"), String)

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

            'If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
            '    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
            '    If img IsNot Nothing Then
            '        img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
            '    End If
            'End If

        End If
    End Sub
    Public Function getGubCAt() As String
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = cf.friendshipdb

            Dim strsql As String = "Select SC.SubCatTitle,Sc.SubCatDesc,CONVERT(VARCHAR(20), sc.UpdatedDate, 100) AS  lastupdate ," & _
            "pl.pid,pl.fname,pl.lname,pl.photo,pl.photopassw," & _
            "'' + Convert(varchar(50),(Select count(TopicTitle) from Topic where SC.SubCatId=Topic.SubCatId)) as TopicsCount," & _
            "'' + Convert(varchar(50),(select COUNT(TA.AnsId) from TopicAnswer TA inner join Topic on TA.TopicId= Topic.TopicId where Topic.SubCatId=SC.SubCatId)) as ReplyCount " & _
            "from dbo.SubCategory SC LEFT OUTER JOIN dbo.Profile pl " & _
            "ON SC.CandiId=pl.pid " & _
            " Where  Sc.SubCatId=@mid"
            Dim cmd As New SqlCommand
            cmd.CommandText = strsql
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@mid", Request.QueryString("id"))
            cn.Open()
            cmd.Connection = cn
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            cn.Close()

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1

                    Page.Title = dt.Rows(i)("SubCatTitle")
                    divTopic.InnerHtml = dt.Rows(i)("SubCatTitle")
                    divTopicDesc.InnerHtml = dt.Rows(i)("SubCatDesc")
                    tdstartdate.InnerHtml = dt.Rows(i)("lastupdate")

                    divTotalTopic.InnerHtml = "<br />Total Threads: " & dt.Rows(i)("TopicsCount") & "<br />Total Replies:&nbsp;&nbsp; " & dt.Rows(i)("ReplyCount")
                    divStartedby.InnerHtml = "<a href=""../viewprofile.aspx?pid=" & dt.Rows(i)("pid") & """>" & dt.Rows(i)("fname") & "</a>"
                Next
            End If
            cn.Close()
        Catch ex As Exception

        End Try
        getGubCAt = ""
    End Function
End Class
