Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_removeprofile
    Inherits System.Web.UI.Page
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        Dim cf As New comonfunctions
        Dim myreader As SqlDataReader
        Dim strsql As String = ""

        strsql = "select photoname from photo where pid=" & Request.QueryString("pid") & ""

        cn.ConnectionString = cf.friendshipdb()
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


        If cf.delrecordset("delete from photo where pid=" & Request.QueryString("pid") & "") = True Then
            Label1.Text = "Photos Deleted"
        End If

        kk = cf.delrecordset("delete from profileviews where pidof=" & Request.QueryString("pid") & "")
        kk = cf.delrecordset("delete from profileviews where viewedbyid=" & Request.QueryString("pid") & "")


        If cf.delrecordset("delete from profile where pid=" & Request.QueryString("pid") & "") = True Then
            Label2.Text = "Profile Deleted Successfully"
        End If
        cn.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If

        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove This Profile?"
        Else
            LinkButton1.Text = ""
        End If




    End Sub
   
End Class
