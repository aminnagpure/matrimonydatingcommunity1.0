Imports System.Data
Imports System.Data.SqlClient

Partial Class members_delalert
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""



        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "delete from alert where searchno=@alid and candiid=@pid"
        cmd.Parameters.AddWithValue("@alid", Request.QueryString("alid").ToString)
        cmd.Parameters.AddWithValue("@pid", Session("pid").ToString)
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Label1.Text = "Alert Removed Succesfully"
        Else
            Label1.Text = " alert not Found"
        End If

        cn.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Delete Your Alert?"
        Else
            LinkButton1.Text = ""
        End If
    End Sub
End Class
