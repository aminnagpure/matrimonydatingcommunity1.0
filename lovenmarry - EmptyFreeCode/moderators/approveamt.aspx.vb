Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_approveamt
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim payid As String = ""

        Dim cf As New comonfunctions
        Dim kk As Boolean
        Dim msg As String = ""
        Dim totalamt As Decimal = 0

        Dim sqlinsert As String = ""
        Dim pid As String = ""


        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If

        pid = Request.QueryString("pid")

        payid = cf.generateid
        totalamt = cf.unpaidmoneydirect(pid)
        sqlinsert = "insert into paymentApproved(payid,pid,amtapproved) values('" & payid & "','" & pid & "'," & totalamt & ")"


        'Response.Write(sqlinsert)
        'Response.End()



        If Request.QueryString("pid") <> "" Then
            kk = cf.update("update profile set Paid='Y' where ref1=" & pid & "  and paid='N'")
            cn.ConnectionString = cf.friendshipdb

            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = sqlinsert
            cmd.ExecuteNonQuery()
        End If

        If kk = True Then
            Label1.Text = "Amt Approved"
            msg = "Congrats<br>Your Amount Due has been Approved <br> Happy Refering <br><br> http://www." & cf.websitename
            '   cf.sendemailtouser(Request.QueryString("pid"), "Amount Approved", msg)

        Else
            Label1.Text = "User Not Found"
        End If



    End Sub

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
