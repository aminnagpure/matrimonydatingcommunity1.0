Imports System.Data
Imports System.Data.SqlClient

Partial Class moderators_insertmaincategory
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




        sql = "insert into forumcategory(forumcategoryn,descrip)"
        sql = sql & " values(@forumcategoryn,@descrip)"

        'Response.Write(sql)
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try
            'Session("pid") = "23434"

            cmd.Connection = cn
            cmd.CommandText = sql

            cmd.Parameters.AddWithValue("@forumcategoryn", TextBox1.Text)
            cmd.Parameters.AddWithValue("@descrip", TextBox2.Text)
            cmd.ExecuteNonQuery()


            cn.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            tdmsg.InnerHtml = "Record Saved"
        Catch ex As Exception
            cn.Close()
            Response.Write(ex.ToString)
        End Try


    End Sub
End Class
