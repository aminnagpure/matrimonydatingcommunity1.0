Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_payhim
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlinsert As String
        Dim rtn As Integer = 0
        sqlinsert = "update topearners set pstatus='Paid' where mid=" & txtAffid.Text & " and pstatus='Approved'"

        rtn = cf.update(sqlinsert)
        If rtn > 0 Then
            Label1.Text = "updated topearners"
        End If
        sqlinsert = "update profile set pstatus='Paid' where pstatus='Approved' and ref1=" & txtAffid.Text & ""
        rtn = cf.update(sqlinsert)
        If rtn > 0 Then
            Label2.Text = "updated profile"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            loaddata()
        End If

    End Sub
    Sub loaddata()
        Dim sql As String = ""
        Dim pid As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim myreader As SqlDataReader



        pid = Request.QueryString("id")


        sql = "select pid,email,fname,lname from profile where pid=" & pid & ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.CommandText = sql
        cmd.Connection = cn
        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                txtAffid.Text = myreader.GetString(0)
                txtAffEmail.Text = myreader.GetString(1)
                txtAffname.Text = myreader.GetString(2).ToString & myreader.GetString(3).ToString
                txtpaidto.Text = myreader.GetString(2).ToString & myreader.GetString(3).ToString

            End While


        End If




        cmd.Dispose()
        cn.Close()




        sql = "select sum(earnedamt) from topearners where mid=" & pid & " and pstatus='Approved'"




        txtPayAmount.Text = cf.CountRs(sql)



    End Sub
End Class
