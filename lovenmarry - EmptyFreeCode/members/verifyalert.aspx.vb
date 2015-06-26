Imports System.Data
Imports System.Data.SqlClient
Partial Class members_verifyalert
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim strsql As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        strsql = "update alert set verified='Y' where searchno=@searchno and candiid=@candiid"

        cmd.Connection = cn
        cmd.CommandText = strsql

        cmd.Parameters.AddWithValue("@searchno", Request.QueryString("alertid").ToString)
        cmd.Parameters.AddWithValue("@candiid", Request.QueryString("b").ToString)

        kk = cmd.ExecuteNonQuery
        If kk > 0 Then
            Label1.Text = "Email Verified, You Will Be Getting Matching Alerts"
        Else
            Label1.Text = "Alert Not Found"
        End If
        cn.Close()
    End Sub
End Class
