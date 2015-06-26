Imports System.Data
Imports System.Data.SqlClient

Partial Class forgotpass
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As SqlDataReader
        Dim passw As String = ""
        Dim regmsg As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""

        Try
            strsql = "select passw from profile where email='" & TextBox1.Text.ToString & "'"

            cn.ConnectionString = cf.friendshipdb()
            cn.Open()


            cmd.Connection = cn
            cmd.CommandText = strsql


            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    passw = myreader.GetValue(0).ToString
                End While
                regmsg = "Your Password is <br><br>"
                regmsg = regmsg & "Your Login is:=" & TextBox1.Text.ToString
                regmsg = regmsg & " <br>and password is " & passw
                regmsg = regmsg & "<br><br>" & cf.websitename




                cf.send25("forgotpass", "Your Password", TextBox1.Text.ToString, regmsg)
                Label1.Text = "Your Password is sent to your email id.  Kindly Ckeck Spam also!!!"
            Else
                Label1.Text = "no alc found"
            End If

            myreader.Close()
            cn.Close()

        Catch ex As Exception

            Label1.Text = ex.ToString
        End Try
    End Sub
End Class
