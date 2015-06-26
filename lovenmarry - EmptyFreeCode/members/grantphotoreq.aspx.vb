Imports System.Data
Imports System.Data.SqlClient

Partial Class members_grantphotoreq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim cf As New comonfunctions
        Dim sql As String = ""
        Dim myreader As SqlDataReader
        Dim myreader2 As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim email As String = ""
        Dim passw As String = ""
        Dim regmsg As String = ""
        Dim msg As String = ""




        Try
            sql = "select email from profile where pid=" & Request.QueryString("pid") & ""
            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = sql
            myreader = cmd.ExecuteReader



            If myreader.HasRows = True Then
                While myreader.Read
                    email = myreader.GetString(0).ToString
                End While
            End If

            '//after getting email send the password
            sql = "select top 1 passw from photo where pid=" & Session("pid") & " "
            cmd2.Connection = cn
            cmd2.CommandText = sql

            myreader2 = cmd2.ExecuteReader

            If myreader2.HasRows = True Then
                While myreader2.Read
                    passw = myreader2.GetValue(0).ToString
                End While
            End If

            regmsg = "<tr><td> " & Session("fname").ToString & " had given you photo password"
            regmsg = regmsg & "<br> Your Photo Password Request Granted <br> you can see <br> http://www." & cf.websitename & "/viewprofile.aspx?pid=" & Session("pid")
            regmsg = regmsg & "<br> Password is " & passw & "</td></tr>"

            msg = cf.send25("requestgranted", "Photo Password Request Granted", email, regmsg)


            passw = cf.delrecordset("delete from passwordrequests where frompid=" & Request.QueryString("pid").ToString & " and topid=" & Session("pid").ToString & "")

            Label1.Text = msg

            cn.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
End Class
