Imports System.Data
Imports System.Data.SqlClient

Partial Class Forums_posttopic
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim startedby As String = ""
        If Session("fname") Is Nothing Then
            Session("fname") = cf.getCandiName(Session("pid"))
        ElseIf Session("fname") = "" Then
            Session("fname") = cf.getCandiName(Session("pid"))
        End If

        cmd.CommandType = CommandType.StoredProcedure
        'TextBox1.Text = Replace(TextBox1.Text, vbCrLf, "<br>")
        Try
            startedby = Session("fname")
            cmd.CommandText = "InsertTopic"
            'cmd.CommandText = "usp_insert_ForumTopics"
            cmd.Parameters.AddWithValue("@TopicTitle", txttopic.Text)
            cmd.Parameters.AddWithValue("@TopicDesc", cf.ReplaceBadWords(Replace(TextBox1.Text, vbCrLf, "<br>")))
            cmd.Parameters.AddWithValue("@CatId", Request.QueryString("cid"))
            cmd.Parameters.AddWithValue("@SubCatId", Request.QueryString("id"))
            cmd.Parameters.AddWithValue("@CandiId", Session("pid"))
            cmd.Parameters.AddWithValue("@UpdateCandiName", Session("fname"))
            cmd.Parameters.AddWithValue("@UpdateCandiId", Session("pid"))
            cmd.Parameters.AddWithValue("@StartDate", Date.Now)
            cmd.Parameters.AddWithValue("@UpdateDate", Date.Now)

            Dim i As Integer = cf.ExecuteScalar(cmd, cf.friendshipdb)

            insertUpdateActivity(i, startedby)

            Response.Redirect("topics.aspx?id=" & Request.QueryString("id") & "&mc=" & Request.QueryString("mc") & "&cid=" & Request.QueryString("cid") & "&NewTopic=" & i)

        Catch ex As Exception

            Response.Write(ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("pid") = "" Then
            Session("catId") = Request.QueryString("cid")
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.Url.AbsoluteUri)
        Else
            If Request.QueryString("cid") Is Nothing Then
                Response.Redirect("posttopic.aspx?id=" & Request.QueryString("id") & "&cid=" & Session("catId"))
            End If
            getGubCAt()
        End If
    End Sub

    Public Function getGubCAt() As String
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = cf.friendshipdb
            Dim strsql As String = "Select SC.SubCatTitle,Sc.SubCatDesc,CONVERT(VARCHAR(20), sc.UpdatedDate, 100) AS  lastupdate ," & _
            "CAN.pid ,CAN.fname ,CAN.lname ,CAN.photo,CAN.photopassw," & _
            "'' + Convert(varchar(50),(Select count(TopicTitle) from Topic where SC.SubCatId=Topic.SubCatId)) as TopicsCount," & _
            "'' + Convert(varchar(50),(select COUNT(TA.AnsId) from TopicAnswer TA inner join Topic on TA.TopicId= Topic.TopicId where Topic.SubCatId=SC.SubCatId)) as ReplyCount " & _
            "from dbo.SubCategory SC LEFT OUTER JOIN dbo.Profile CAN " & _
            "ON SC.CatId=CAN.pid " & _
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
                    Page.Title = dt.Rows(i)("SubCatTitle").ToString
                    divTopic.InnerHtml = dt.Rows(i)("SubCatTitle").ToString
                    divTopicDesc.InnerHtml = dt.Rows(i)("SubCatDesc").ToString
                    tdstartdate.InnerHtml = dt.Rows(i)("lastupdate").ToString
                    divTotalTopic.InnerHtml = "<br />Total Threads: " & dt.Rows(i)("TopicsCount") & "<br />Total Replies:&nbsp;&nbsp; " & dt.Rows(i)("ReplyCount")
                Next
            End If
            ' cn.Close()
        Catch ex As Exception

        End Try
        getGubCAt = ""
    End Function
    Sub insertUpdateActivity(ByVal id As Integer, ByVal fn As String)
        Dim act As New SiteAcitvity
        act.candiid = Session("pid")
        act.fn = fn
        act.activitydate = Date.Now
        Dim str As String = ""
        str = "<div><table>"
        str = str & "<tr><td>"
        Dim Subject As String = txttopic.Text
        If Subject.Length > 40 Then
            Subject = Subject.Substring(0, 35)
        Subject = Subject.Substring(0, 35) & "..."
        End If
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has posted a new Topic <a href='http://" & cf.websitename & "/Forums/viewtopic.aspx?tid=" & id & "'>" & Subject & "</a>"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "NewTopic"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub

End Class
