Imports System.Data
Imports System.Data.SqlClient

Partial Class sendemail
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim sqlquery As String = ""
        Dim email As String = ""
        Dim fname As String = ""
        Dim passw As String = ""
        Dim msgstring As String = ""
        Dim pid As String = ""
        Dim kk As String = ""

        Try

        
            Response.Write("in page load")
            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            sqlquery = "select top 5 fname,email,passw,pid from profile where msgcycle=0"

            cmd.Connection = cn
            cmd.CommandText = sqlquery

            myreader = cmd.ExecuteReader
            While myreader.Read
                fname = myreader.GetValue(0).ToString
                email = myreader.GetValue(1).ToString
                passw = myreader.GetValue(2).ToString
                pid = myreader.GetValue(3).ToString

                Response.Write("got records")

                msgstring = "hi " & fname
                msgstring = msgstring & " we have over 16000 all newly registered members now <br>"
                msgstring = msgstring & " Just login and Search <br>"
                msgstring = msgstring & " <br> http://www.ek-dujey-key-liye.com <br>"
                msgstring = msgstring & "<br>Your Login Details<br> Username:" & email & "<br> password:" & passw & " <br>"
                msgstring = msgstring & "<br><br>IF you do not want to recive emails from us, delete your alc"

                Response.Write(cf.send25("info", "Hi " & fname, email, msgstring))
                'Response.Write("update profile set msgcycle=1 where pid='" & pid & "'")
                kk = cf.update("update profile set msgcycle=1 where pid='" & pid & "'")


                Response.Write(kk)

            End While

            cn.Close()

        Catch ex As Exception
            Response.Write(ex.ToString)

        End Try
    End Sub
    
End Class
