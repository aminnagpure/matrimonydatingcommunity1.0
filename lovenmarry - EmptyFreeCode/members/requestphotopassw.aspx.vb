Imports System.Data
Imports System.Data.SqlClient

Partial Class members_requestphotopassw
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dorequest()
    End Sub
    Sub dorequest()
        Dim constring As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim kk As String

        Dim cmdprofiledetails As New SqlCommand

        Dim rid As String = ""
        Dim fname As String = ""
        Dim lname As String = ""
        Dim email As String = ""

        Dim passwreqmsg As String = ""

        rid = cf.generateid
        Dim pid As Integer = 0
        Try
            pid = Session("pid")
        Catch ex As Exception

        End Try


        If cf.checkblocked(Request.QueryString("pid"), pid.ToString) = True Then
            Label1.Text = "You Cannot Contact This Person, You are Blocked"
            Exit Sub
        End If


        cn.ConnectionString = cf.friendshipdb
        cn.Open()




        
        If checkphotorequest() > 0 Then
            tdblocked.InnerText = "Photo Request Made Is In Process"



        Else
            


            cmd2.Connection = cn
            cmd2.CommandText = "insert into passwordrequests(frompid,topid,fname,lname) values(@frompid,@topid,@fname,@lname) "

            cmd2.Parameters.AddWithValue("@frompid", pid)
            cmd2.Parameters.AddWithValue("@topid", Request.QueryString("pid").ToString)
            cmd2.Parameters.AddWithValue("@fname", fname.ToString)
            cmd2.Parameters.AddWithValue("@lname", lname.ToString)


            kk = cmd2.ExecuteNonQuery
            If kk > 0 Then
                sendemail()
            End If

        End If

        cn.Close()

    End Sub
    Function checkphotorequest() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As Integer = 0

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        Dim pid As Integer = 0
        Try
            pid = Session("pid")
        Catch ex As Exception

        End Try

        cmd.Connection = cn
        cmd.CommandText = "select count(*) from passwordrequests where frompid=@pid and topid=@pid"
        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = pid
        cmd.Parameters.Add("@topid", SqlDbType.VarChar).Value = Request.QueryString("pid").ToString

        myreader = cmd.ExecuteReader

        While myreader.Read
            kk = myreader.GetValue(0)
        End While

        checkphotorequest = kk

    End Function
    Sub sendemail()
        Dim cmdprofiledetails As New SqlCommand
        Dim myreaderprofile As SqlDataReader
        Dim cn As New SqlConnection
        Dim email As String = ""
        Dim passwreqmsg As String = ""
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmdprofiledetails.Connection = cn
        cmdprofiledetails.CommandText = "select email from profile where pid='" & Request.QueryString("pid").ToString & "'"
        myreaderprofile = cmdprofiledetails.ExecuteReader

        If myreaderprofile.HasRows = True Then
            While myreaderprofile.Read
                email = myreaderprofile.GetString(0).ToString
            End While
        End If

        tdblocked.InnerText = "Photo Request Made"

        passwreqmsg = "<tr><td> "
        passwreqmsg = passwreqmsg & " Password Request has been made by http://www." & cf.websitename & "/viewprofile.aspx?pid=" & Session("pid") & "<br><br>"
        passwreqmsg = passwreqmsg & " you can see the entire list here http://www." & cf.websitename & "/members/reqpasswordlist.aspx <br> <br> You Can Grant and Deny Password Requests</td></tr>"

        If email <> "" Then
            kk = cf.send25("passwordrequest", Session("fname") & " Wants To see your photo", email, passwreqmsg)

            Label1.Text = "Password Request Sent"

        End If
    End Sub
End Class
