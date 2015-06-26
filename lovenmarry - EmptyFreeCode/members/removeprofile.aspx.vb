Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class members_removeprofile
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim kk As String = ""
        Dim cnstring As String = ""
        Dim cf As New comonfunctions
        Dim myreader As SqlDataReader
        Dim strsql As String = ""

        strsql = "select photoname from photo where pid=" & Session("pid") & ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        If myreader.HasRows = True Then
            While myreader.Read
                kk = deletephoto(myreader.GetString(0).ToString)
            End While
        End If

        Label2.Text = kk


        kk = cf.delrecordset("delete from photo where pid=" & Session("pid") & "")
        If kk = "True" Then
            Label1.Text = "Photo Deleted"
        Else
            Label1.Text = "photo not found"
        End If

        Try
            kk = cf.delrecordset("Delete from siteactivity where candiid =" & Session("pid") & "")
        Catch ex As Exception

        End Try
        kk = cf.delrecordset("delete from profileviews where pidof=" & Session("pid") & "")
        kk = cf.delrecordset("delete from profileviews where viewedbyid=" & Session("pid") & "")
        kk = cf.delrecordset("delete from profile where pid=" & Session("pid") & "")
        kk = cf.delrecordset("delete from topearners where mid=" & Session("pid") & "")

        cn.Close()

        'If kk = "True" Then
        Label2.Text = "Profile Deleted"
        kk = cf.update("update profile set ref1='' where ref1=" & Session("pid") & "")

        Try
            Dim Logins As List(Of LoginIds) = New List(Of LoginIds)
            Dim L As New LoginIds
            L.Fname = Session("fname")
            L.PID = Session("pid")
            Logins = Application("Ids")
            Dim b As Boolean = Logins.Exists(Function(x) x.PID = L.PID)
            If b Then
                Logins.Remove(Logins.Find(Function(x) x.PID.Contains(L.PID)))
            End If
            Application("Ids") = Logins
        Catch ex As Exception

        End Try

        Session.Remove("pid")
        Session.Remove("fname")
        Session.Remove("approved")
        Session.Remove("lname")
        Session.Remove("susp")
        Session.Remove("validmobile")
        Session.Remove("sex")
        Session.Remove("mrole")
        Session.Remove("email")
        Session.Remove("hasinvites")
        Session.Remove("headline")
        Session.Remove("isfacebookposted")
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("../login.aspx")
        ' Else
        'Label2.Text = "Profile not Found"
        'End If


    End Sub

    

    Function deletephoto(ByVal photo As String) As String
        Dim imgfolder As String = ""
        imgfolder = Server.MapPath("..\App_Themes") & "\" & photo
        If File.Exists(imgfolder) Then
            File.Delete(imgfolder)
            Return "photo Deleted"
        Else
            Return "photo not Found"
        End If
    End Function
End Class
