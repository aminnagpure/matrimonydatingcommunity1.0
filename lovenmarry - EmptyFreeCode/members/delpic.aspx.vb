Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Partial Class members_delpic
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""

        Dim myreader As SqlDataReader
        Dim strsql As String = ""
        Dim cc As Boolean
        Dim passw As String = ""
        Dim mainphoto As String = ""
        Dim photoname As String = ""

        strsql = "select photoname,passw,mainphoto from photo where photoid=" & Request.QueryString("pid") & " and pid=" & Session("pid") & ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                photoname = myreader.GetString(0).ToString
                passw = myreader.GetString(1).ToString
                mainphoto = myreader.GetString(2).ToString

                kk = deletephoto(photoname)

            End While
        End If

        ' Response.Write(kk.ToString)


        cc = cf.TaskmembSql("delete from photo where photoid=" & Request.QueryString("pid") & " and pid=" & Session("pid") & "")

        If mainphoto = "Y" Then
            updatemainphoto()
        End If

        If cc = True Then
            Label1.Text = "Photo Deleted Sucessfully"
        End If

        cn.Close()


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove Your Photo?"
        Else
            LinkButton1.Text = ""
        End If
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
    Sub updatemainphoto()
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim photoname As String = ""
        Dim passw As String = ""
        Dim sql As String = ""
        Dim kk As String = ""
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try


            cmd.Connection = cn
            cmd.CommandText = "select top 1 photoname,passw from photo where pid=" & Session("pid") & ""
            myreader = cmd.ExecuteReader

            While myreader.Read
                photoname = myreader.GetValue(0).ToString
                passw = myreader.GetValue(1).ToString
            End While
            myreader.Close()
            cn.Close()

            sql = "update profile set photo='" & photoname & "',photopassw='" & passw & "' where pid=" & Session("pid") & ""



            kk = cf.TaskmembSql(sql)


            '//for photos table
            sql = "update photo set mainphoto='Y' where pid=" & Session("pid") & " and photoname='" & photoname & "'"
            kk = cf.TaskmembSql(sql)


        Catch ex As Exception
            Response.Write(ex.ToString)

        End Try
    End Sub
End Class
