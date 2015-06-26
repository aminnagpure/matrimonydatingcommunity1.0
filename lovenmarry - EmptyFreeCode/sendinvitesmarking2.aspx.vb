Imports System.Data
Imports System.Data.SqlClient

Partial Class sendinvitesmarking2
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cnsqlserver As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim sql As String = ""
        Dim passw As String = ""
        Dim candiid As String = ""

        Dim inviteid As Integer = 0
        Dim companyemail As String = ""
        Dim msgstring As String = ""
        Dim dd As String = ""
        Dim updatesql As String = ""
        Dim sendersemail As String = ""
        Dim fname As String = ""
        Dim lname As String = ""

        'aminsqlconlovenmarry


        cnsqlserver.ConnectionString = cf.friendshipdb
        cnsqlserver.Open()

        sql = "[inviteemailslovenmarry_2]"

        cmd.CommandText = sql
        cmd.commandtimeout = 5000
        cmd.Connection = cnsqlserver
        myreader = cmd.ExecuteReader





        If myreader.HasRows = True Then
            While myreader.Read
                msgstring = ""
                dd = ""
                candiid = myreader.GetValue(0).ToString
                companyemail = myreader.GetValue(1).ToString
                fname = myreader.GetValue(2).ToString
                lname = myreader.GetValue(3).ToString
                sendersemail = myreader.GetValue(4).ToString
                inviteid = myreader.GetValue(5)

                dd = fname & " " & lname & " invites you <br>" & _
     " hey buddy come, join me on this site <br>" & _
     " <A href='http://www.yoursite.com?affid=" & candiid & "'>confirm it </a> <br>" & _
     " here we can send free sms,make friends and also earn money<br> iam here, join me <br><br>" & _
     " you can see members profile http://www.yoursite.com/members/viewprofile.aspx?pid=" & candiid & " <br>" & _
     " sender is registered with us by email " & sendersemail


                msgstring = "<table>"
                msgstring = msgstring & "<tr>"
                msgstring = msgstring & "<td>" & dd & "<br></td></tr>"
                msgstring = msgstring & "<tr>"

                msgstring = msgstring & "<td><br><br>To Disable Recieving Admin Emails <a href='http://www.yoursite.com/stopinvites.aspx?id=" & candiid & "&inid=" & inviteid & "'> Click here </td></tr>"
                msgstring = msgstring & "</table><br> or http://www.yoursite.com/contactus.aspx"

                cf.send25forinvites(fname & " <invite@yoursite.com>", " Hello", companyemail, msgstring)
                Response.Write(companyemail)
                updatesql = "update invites set lovenmarrysent=2 where inviteid=" & inviteid
                'msgstring = "hi amin"

                cf.TaskmembSql(updatesql)

            End While
        End If

        myreader.Close()
        cmd.Dispose()
        cnsqlserver.Close()

    End Sub
End Class
