Imports System.Data
Imports System.Data.SqlClient

Partial Class poll_Default
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = " IsApprove='Y'"

        If (Request.QueryString("id") IsNot Nothing) Then
            str += " AND  CreationLogInId=" & Request.QueryString("id") & " "
        End If
        If Session("pid") IsNot Nothing Then
            If Request.QueryString("view") = "Mypoll" Then
                str += " AND sno in(Select Distinct QueId from OnlinePoleTest_Master Where CreationLogInId = " & Session("pid") & ")"
                HyperLink2.Text = "View New Poll"
                HyperLink2.NavigateUrl = "Default.aspx"
                HyperLink2.Width = 192

            Else
                str += " AND sno Not in(Select Distinct QueId from OnlinePoleTest_Master Where CreationLogInId = " & Session("pid") & ")"
            End If
        Else
            HyperLink2.Visible = False
        End If

        TextBox1.Text = str
    End Sub
    Sub fillGrid()
        Dim cmd As New SqlCommand
        cmd.CommandText = "ShowAllPolls"
        cmd.Parameters.AddWithValue("@startRowIndex", 0)
        cmd.Parameters.AddWithValue("@maximumRows", 500)
        cmd.Parameters.AddWithValue("@criteria", TextBox1.Text)
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)

        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()
    End Sub



    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        
    End Sub
End Class
