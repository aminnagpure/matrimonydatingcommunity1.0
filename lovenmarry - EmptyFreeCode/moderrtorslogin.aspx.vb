Imports System.Data
Imports System.Data.SqlClient
Partial Class moderrtorslogin
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Function checkit(ByVal us As String, ByVal pas As String) As Boolean


        Dim constring As String = ""
        Dim rzlt As String = ""



        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader



        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select userid,username,role from users where username=@username and passw=@passw"
        cmd.Parameters.Add("@username", Data.SqlDbType.VarChar).Value = us
        cmd.Parameters.Add("@passw", Data.SqlDbType.VarChar).Value = pas

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                'Session("userid") = myreader.GetString(0).ToString
                Session("username") = myreader.GetString(1).ToString
                Session("role") = myreader.GetString(2).ToString
                Session("pid") = ""
            End While

            cn.Close()
            Return True
        Else
            cn.Close()
            Return False
        End If




    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim u, p As String
        Dim rslt As Boolean

        u = txtusername.Text.ToString
        p = txtpassword.Text.ToString

        rslt = checkit(u, p)

        If rslt = True Then
            'Session("login") = User.Identity.Name
            '   e.Authenticated = True

            'If u = "girish" Then

            ' Response.Redirect("~/sadmin/editprofile.aspx")
            'Else
            Response.Redirect("~/moderators/default.aspx")
            'End If
            '      Response.Write(User.Identity.Name)
            'Response.Redirect("members/mainmenu.aspx")
        Else
            Label1.Text = "Wrong Username or Password"
            '  e.Authenticated = False
        End If
    End Sub
End Class
