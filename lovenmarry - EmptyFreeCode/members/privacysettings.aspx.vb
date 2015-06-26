Imports System.Data
Imports System.Data.SqlClient

Partial Class members_privacysettings
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub chkphotpassword_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkphotpassword.CheckedChanged
        If chkphotpassword.Checked = True Then
            txtphotopassword.Visible = True
            txtphotopassword.ReadOnly = False
        Else
            txtphotopassword.Visible = False
            txtphotopassword.ReadOnly = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim visibleall As String = ""
        Dim photopassw As String = ""
        Dim strsql As String = ""
        Dim k1 As String = ""
        Dim k2 As String = ""
        Dim adminemail As String = ""
        Dim newoffers As String = ""
        Dim matchalert As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        If chkvisibleall.Checked = True Then
            visibleall = "Y"
        Else
            visibleall = "N"
        End If

        If chkMatchAlert.Checked = True Then
            matchalert = "Y"
        Else
            matchalert = "N"
        End If

        If chkphotpassword.Checked = True Then
            photopassw = txtphotopassword.Text
        Else
            photopassw = ""
        End If

        If chkEmailfromAdmin.Checked = True Then
            adminemail = "Y"
        Else
            adminemail = "N"
        End If

        If chkoffers.Checked = True Then
            newoffers = "Y"
        Else
            newoffers = "N"
        End If


        strsql = " update profile set visibletoall=@visibletoall,adminemail=@adminemail,newoffers=@newoffers,matchalert=@matchalert,photopassw=@photopassw where pid=" & Session("pid") & ""

        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@visibletoall", visibleall.ToString)
        cmd.Parameters.AddWithValue("@adminemail", adminemail)
        cmd.Parameters.AddWithValue("@newoffers", newoffers)
        cmd.Parameters.AddWithValue("@matchalert", matchalert)
        cmd.Parameters.AddWithValue("@photopassw", photopassw)
        k1 = cmd.ExecuteNonQuery

        If k1 > 0 Then
            Label1.Text = " Your Profile Settings Updated"
        End If

        'If chkphotpassword.Checked = True Then
        strsql = " update photo set passw=@passw where pid=" & Session("pid") & ""
        cmd2.Connection = cn
        cmd2.CommandText = strsql
        cmd2.Parameters.AddWithValue("@passw", photopassw)

        k2 = cmd2.ExecuteNonQuery

        If k2 > 0 Then
            Label2.Text = "Photo Password Updated"
        Else
            Label2.Text = "No Photo Found to Update with Password"
        End If
        'End If

        cn.Close()


    End Sub

    

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            Dim myreader As SqlDataReader
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand

            Dim cf As New comonfunctions
            Dim visibleall As String = ""
            Dim photopass As String = ""
            Dim strsql As String = ""
            Dim adminemail As String = ""
            Dim newoffers As String = ""
            Dim matchalert As String = ""

            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            strsql = "select visibletoall,photo.passw,adminemail,newoffers,matchalert from profile left join photo on profile.pid=photo.pid where profile.pid=" & Session("pid") & ""

            cmd.Connection = cn
            cmd.CommandText = strsql
            myreader = cmd.ExecuteReader


            If myreader.HasRows Then
                While myreader.Read
                    visibleall = myreader.GetValue(0).ToString
                    photopass = myreader.GetValue(1).ToString
                    adminemail = myreader.GetValue(2).ToString
                    newoffers = myreader.GetValue(3).ToString
                    matchalert = myreader.GetValue(4).ToString

                End While
            End If

            If visibleall = "Y" Then
                chkvisibleall.Checked = True
            End If

            If adminemail = "Y" Then
                chkEmailfromAdmin.Checked = True
            End If

            If newoffers = "Y" Then
                chkoffers.Checked = True
            End If

            If photopass <> "" Then
                chkphotpassword.Checked = True
                txtphotopassword.Visible = True
                txtphotopassword.Text = photopass
            Else
                txtphotopassword.Visible = False
            End If
            If matchalert = "Y" Then
                chkMatchAlert.Checked = True
            End If


            cn.Close()
        End If
    End Sub
End Class
