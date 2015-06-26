Imports System.Data.SqlClient

Partial Class UserComplaints
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblMsg.Text = ""
        If txtComplaints.Text.Contains("http://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If
        If txtComplaints.Text.Contains("https://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtSubject.Text.Contains("http://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If
        If txtSubject.Text.Contains("https://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtName.Text.Contains("http://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtName.Text.Contains("https://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtMobile.Text.Contains("http://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtMobile.Text.Contains("https://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If


        If txtEmailID.Text.Contains("http://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        If txtEmailID.Text.Contains("https://") Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("usedbyscammers.aspx")
        End If

        Dim cmd As New SqlCommand
        cmd.CommandText = "User_Complaints_Add"
        cmd.Parameters.AddWithValue("@UserMobile", txtMobile.Text.Trim)
        cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@ComplaintHead", txtSubject.Text.Trim)
        cmd.Parameters.AddWithValue("@ComplaintDesc", txtComplaints.Text.Trim.Replace(ControlChars.Lf, "<br />"))
        cmd.Parameters.AddWithValue("@ComplaintDate", Date.Now)
        Dim rtn As Integer = cf.ExecuteScalar(cmd, cf.friendshipdb)
        If rtn = 0 Then
            lblMsg.Text = "You Have Already Register This Complaints"
            lblMsg.ForeColor = Drawing.Color.Red
        Else
            lblMsg.Text = "Your Complaint is Register Successfully. Your Complaints Number is " & rtn
            lblMsg.ForeColor = Drawing.Color.Blue
        End If
        GridView1.DataSourceID = ObjectDataSource1.ID
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TextBox1.Text = " 1=1"
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "IDelete" Then
            DelComplaints(e.CommandArgument)
        End If
    End Sub

    Sub DelComplaints(ByVal id As Integer)
        Dim cmd As New SqlCommand
        cmd.CommandText = "UserComplaints_Delete"
        cmd.Parameters.AddWithValue("@ComplaintsID", id)
        Dim rtn As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        If rtn > 0 Then
            GridView1.DataSourceID = ObjectDataSource1.ID
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lnk As LinkButton = DirectCast(e.Row.FindControl("btnDelete"), LinkButton)
                If Session("mrole") = "mod" Then
                    lnk.Visible = True
                End If
            End If
        Catch
        End Try
    End Sub
    Function FormatDate(ByVal d As Date) As String
        FormatDate = Format(d, "MMMM d yyyy") & " " & Format(d, "Long Time")
    End Function
End Class
