Imports System.Data
Imports System.Data.SqlClient

Partial Class members_login
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim u, p As String
        Dim rslt As Boolean

        u = Login1.UserName
        p = Login1.Password

        rslt = checkit(u, p)
        If rslt = True And Session("susp") = "Y" Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If


        

        If rslt = True Then

            ' If Session("validmobile").ToString = "N" Then
            FormsAuthentication.SetAuthCookie(Login1.UserName, True)
            'Response.Redirect("validatemobile.aspx")
            'End If

            e.Authenticated = True

            


            Else
                e.Authenticated = False
            End If

    End Sub

    Private Function checkit(ByVal us As String, ByVal pas As String) As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim kk As String = ""



        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        'cmd.Connection = cn
        cmd.CommandText = "mlogin" ' '" & us & "','" & pas & "'"
        cmd.Parameters.Add("@em", SqlDbType.VarChar).Value = us
        cmd.Parameters.Add("@pw", SqlDbType.VarChar).Value = pas
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)

        If ds.Tables(0).Rows.Count > 0 Then

            Session("pid") = ds.Tables(0).Rows(0)(0).ToString
            Session("fname") = ds.Tables(0).Rows(0)(1).ToString
            Session("approved") = ds.Tables(0).Rows(0)(2).ToString
            Session("lname") = ds.Tables(0).Rows(0)(3).ToString
            Session("susp") = ds.Tables(0).Rows(0)(4).ToString
            Session("validmobile") = ds.Tables(0).Rows(0)(5).ToString
            Session("sex") = ds.Tables(0).Rows(0)(6).ToString
            Session("mrole") = ds.Tables(0).Rows(0)(7).ToString
            Session("email") = us
            Session("hasinvites") = ds.Tables(0).Rows(0)(8).ToString
            Session("headline") = ds.Tables(0).Rows(0)(9).ToString
            Session("isfacebookposted") = ds.Tables(0).Rows(0)(10).ToString
            Session("FB_ID") = ds.Tables(0).Rows(0)("FB_ID").ToString
            Session("GPlusUrl") = ds.Tables(0).Rows(0)("GPlusUrl").ToString

            If ds.Tables(0).Rows(0)(3).ToString = "" Then
                Response.Cookies("PC")("P") = "N"
            Else
                Response.Cookies("PC")("P") = "Y"
            End If
            If ds.Tables(0).Rows(0)("wt").ToString = "" Then
                Response.Cookies("PC")("W") = "N"
            Else
                Response.Cookies("PC")("W") = "Y"
            End If
            If ds.Tables(0).Rows(0)("whoami").ToString = "" Then
                Response.Cookies("PC")("A") = "N"
            Else
                Response.Cookies("PC")("A") = "Y"
            End If
            If ds.Tables(0).Rows(0)("mobile").ToString = "" Then
                Response.Cookies("PC")("M") = "N"
            Else
                Response.Cookies("PC")("M") = "Y"
            End If
            If ds.Tables(0).Rows(0)("photo").ToString = "" Then
                Response.Cookies("Photo").Value = "no_avatar.gif"
            End If
            'Session("addme") = myreader.GetString(11).ToString


            cmd2.Connection = cn
            cmd2.CommandText = "upmlogin " & Session("pid") & ""
            cmd2.CommandTimeout = 200
            kk = cmd2.ExecuteNonQuery()
            cn.Close()
            Try
                Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
                Dim L As New LoginIds
                L.Fname = Session("fname")
                L.PID = Session("pid")
                Logins = Application("Ids")
                'Dim b As Boolean = Logins.Contains(New LoginIds With {.PID = L.PID})
                Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
                If Not b Then
                    Logins.Add(L)
                End If
                Application("Ids") = Logins
            Catch ex As Exception

            End Try
            Return True
        Else
            cn.Close()
            Return False
        End If



    End Function
    
    
End Class

