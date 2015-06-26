Imports System.Data
Imports System.Data.SqlClient
Partial Class Forums_replytopic
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt As String = ""
        Dim ipadd As String = ""
        Dim doubtfulprofile As String = "Y"
        Dim ipcountry As String = ""
        Dim updatedby As String = ""

        pid = "A" & cf.generateid


        sql = "insert into topicsQnAansw(answerid,forumqnaid,anser,updatebyid,updatedby)"
        sql = sql & " values(@answerid,@forumqnaid,@anser,@updatebyid,@updatedby)"


        'Response.Write(sql)
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        'TextBox1.Text = Replace(TextBox1.Text, vbCrLf, "<br>")

        Try
            'Session("pid") = "23434
            updatedby = Session("fname")

            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = sql

            cmd.Parameters.AddWithValue("@answerid", pid)
            cmd.Parameters.AddWithValue("@forumqnaid", Request.QueryString("id"))
            cmd.Parameters.AddWithValue("@anser", Mid(cf.ReplaceBadWords(Replace(TextBox1.Text, vbCrLf, "<br>")), 1, 5000))
            cmd.Parameters.AddWithValue("@updatebyid", Session("pid"))
            cmd.Parameters.AddWithValue("@updatedby", updatedby)
            cmd.ExecuteNonQuery()


            sql = "update forumqandA set updateddate=getdate(),updatebyid='" & Session("pid") & "',updatedby='" & updatedby & "'  where forumqnaid=" & Request.QueryString("id")
            cf.Taskjobseeker(sql)

            cmd.Dispose()
            cn.Close()

            pid = Request.QueryString("id")
            forumheading(pid)
            Response.Redirect("viewtopic.aspx?id=" & Request.QueryString("id") & "&tid=" & Request.QueryString("tid"))
        Catch ex As Exception
            cn.Close()
            Response.Write(ex.ToString)
        End Try
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If Session("pid") Is Nothing Then

            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If

       
    End Sub

    Sub forumheading(ByVal pid As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""

        Dim regmsg As String = ""
        Dim rzlt As String = ""
        Dim ipadd As String = ""
        Dim doubtfulprofile As String = "Y"
        Dim ipcountry As String = ""
        Dim startedby As String = ""


        sql = "update forumtopics set startedbyid=@postedbyid,updatebyid=@updatebyid,latesttopicid=@topicid"
        sql = sql & "  where forumtopid=" & Request.QueryString("tid")

        'Response.Write(sql)
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try


            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = sql

            'cmd.Parameters.AddWithValue("@forumtopic", txttopic.Text)
            cmd.Parameters.AddWithValue("@postedbyid", Session("pid"))
            cmd.Parameters.AddWithValue("@updatebyid", Session("pid"))
            cmd.Parameters.AddWithValue("@topicid", pid)
            cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close()



        Catch ex As Exception
            cn.Close()
            Response.Write(ex.ToString)
        End Try




    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("pid") Is Nothing Then

            Response.Redirect("~/login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If

        If Session("pid") = "" Then
            Response.Redirect("~/login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
    End Sub
End Class
