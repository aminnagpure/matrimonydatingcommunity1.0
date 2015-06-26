Imports System.Data
Imports System.Data.SqlClient
Partial Class news_postcomment
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


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


            cn.ConnectionString = cf.friendshipdb
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = sql


            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@comment", TextBox1.Text)
            cmd.Parameters.AddWithValue("@newsid", Request.QueryString("id"))
            cmd.ExecuteNonQuery()

            Button1.Enabled = False
            Button1.Text = "Comment Posted"

            cmd.dispose()
            cn.close()

            Response.Redirect("viewnews.aspx?id=" & Request.QueryString("id"))

        Catch ex As Exception
            Response.Write(ex.ToString)


        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("pid") <> "" Then

        Else
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
    End Sub
End Class
