Imports System.Data
Imports System.Data.SqlClient

Partial Class moderators_Default
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions



    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim kk As String = ""
    '    Try




    '        kk = cf.update("update profile set isonlinenow='N'")
    '        If kk = "True" Then
    '            Button1.Text = "Users Online Reseted"
    '        End If
    '    Catch ex As Exception
    '        Response.Write(ex.Message)

    '    End Try
    'End Sub


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try

            Dim ds As New DataSet
            Dim cmd As New SqlCommand
            cmd.CommandText = "Moderators_HomePage"
            ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
            'If checklogin() = False Then
            '    '  Response.Redirect("~/adminlogin.aspx")
            '    Exit Sub
            'End If
            If ds.Tables(0).Rows.Count > 0 Then
                lblRegtoday.Text = ds.Tables(0).Rows(0)("regtoday")
                lblUnApproved.Text = ds.Tables(0).Rows(0)("unapprovedprof")
                lblunApprovedPhotos.Text = ds.Tables(0).Rows(0)("unapprovedphotos")
                lblTotMem.Text = ds.Tables(0).Rows(0)("totalmem")
                lblsuspendedcount.Text = ds.Tables(0).Rows(0)("totalsusp")
                lblDoubtfulprofile.Text = ds.Tables(0).Rows(0)("doubtfulprofiles")
                lblYesterday.Text = ds.Tables(0).Rows(0)("YesterdayMem")
            End If


            

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub


End Class

