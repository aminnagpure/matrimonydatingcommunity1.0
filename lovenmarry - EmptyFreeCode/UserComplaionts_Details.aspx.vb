Imports System.Data.SqlClient
Imports System.Data

Partial Class UserComplaionts_Details
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblMsg.Text = ""
        Dim cmd As New SqlCommand
        cmd.CommandText = "User_Complaints_VerifyUser"
        cmd.Parameters.AddWithValue("@mobile", txtMobile.Text)
        cmd.Parameters.AddWithValue("@EmailID", txtEmailID.Text)
        'cmd.Parameters.AddWithValue("@ComplaintsID", Request.QueryString("id"))
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0)("ComplaintID") = Request.QueryString("id") Then
                div_User_Details.Visible = False
                div_CommentsBox.Visible = True
                txtName.Text = ds.Tables(0).Rows(0)("UserName").ToString
            Else
                lblMsg.Text = "This Complaint is Not made by You"
                lblMsg.ForeColor = Drawing.Color.Blue
                div_User_Details.Visible = True
                div_CommentsBox.Visible = False
            End If
        Else
            lblMsg.Text = "There is no Complaints By You"
            lblMsg.ForeColor = Drawing.Color.Blue
            div_User_Details.Visible = True
            div_CommentsBox.Visible = False
        End If

    End Sub

    Protected Sub btnComments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComments.Click
        Dim cmd As New SqlCommand
        cmd.Parameters.AddWithValue("@ComplaintsID", Request.QueryString("id"))
        cmd.Parameters.AddWithValue("@Comments", txtComplaints.Text.Trim.Replace(ControlChars.Lf, "<br />"))
        If Session("mrole") = "mod" Then
            If Session("pid") IsNot Nothing Then
                If Session("pid").ToString <> "" Then
                    cmd.Parameters.AddWithValue("@CommentsBy", Session("pid").ToString)
                    cmd.Parameters.AddWithValue("@IsAdmin", "Y")
                Else
                    GoTo Login
                End If
            Else
Login:
                Response.Redirect("Login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri)
            End If
        End If
        cmd.CommandText = "User_Complaints_Comments_Add"
        cmd.Parameters.AddWithValue("@CommentsByName", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@CommentsDate", Date.Now)
        If CheckBox1.Checked Then
            cmd.Parameters.AddWithValue("@Resolved", "Y")
        End If
        Dim rtn As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        If rtn > 0 Then
            GridView1.DataSourceID = ObjectDataSource1.ID
            txtComplaints.Text = ""
            btnComments.Enabled = False
        End If
        If Session("mrole") = "mod" Then
            sendmailtoUser()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("mrole") = "mod" Then
                If Session("pid") IsNot Nothing Then
                    If Session("pid").ToString <> "" Then
                        If Session("fname") Is Nothing Then
                            Session("fname") = cf.getCandiName(Session("pid").ToString)
                        End If
                        If Session("fname").ToString = "" Then
                            Session("fname") = cf.getCandiName(Session("pid").ToString)
                        End If
                        txtName.Text = Session("fname").ToString
                        If Session("email") IsNot Nothing Then
                            txtEmailMod.Text = Session("email")
                        End If
                        lblEmailMod.Visible = True
                        lblMobileMod.Visible = True
                        txtEmailMod.Visible = True
                        txtMobileMod.Visible = True
                        div_User_Details.Visible = False
                        div_CommentsBox.Visible = True
                    Else
                        GoTo Login
                    End If
                Else
Login:
                    div_User_Details.Visible = True
                    div_CommentsBox.Visible = False
                End If
            End If
        End If
        Dim cmd As New SqlCommand
        cmd.CommandText = "User_Complaints_VerifyUser"
        cmd.Parameters.AddWithValue("@ComplaintsID", Request.QueryString("id"))
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
        If ds.Tables(0).Rows.Count > 0 Then
            HiddenField1.Value = ds.Tables(0).Rows(0)("ComplaintHead")
            tdCompH.InnerHtml = "<div class='Content1'><span class =""name""><strong>Sub : " & ds.Tables(0).Rows(0)("ComplaintHead").ToString & "</strong></span></div><hr class ='line1'/>"
            Dim s As String = "<div class=""Content1"">Description</div><div class=""name"">" & ds.Tables(0).Rows(0)("ComplaintDesc").ToString & ""
            If Session("mrole") = "mod" Then
                HiddenField2.Value = ds.Tables(0).Rows(0)("EmailID").ToString
                s += "<br /><br /><span class='Content1'>Email ID: </span>" & ds.Tables(0).Rows(0)("EmailID").ToString
                s += "<br /><span class='Content1'>Contact : </span>" & ds.Tables(0).Rows(0)("UserMobile").ToString
            End If
            s += "</div>"
            tdCopmD.InnerHtml = s
            tdCompBy.InnerHtml = "<div class=""inforow"" ><span class =""name""><strong><span class='Content1'>By :</span>" & ds.Tables(0).Rows(0)("UserName").ToString & "</strong></span><span class='time' style=""float:right;"">On : " & ds.Tables(0).Rows(0)("ComplaintDate") & "</span></div>"
        Else
            HiddenField1.Value = "No Complaints Found"
            btnSubmit.Enabled = False
            btnComments.Enabled = False
        End If
        Page.Title = HiddenField1.Value
        TextBox1.Text = " CC.ComplaintsID=" & Request.QueryString("id")
    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "IDelete" Then
            DelComplaints(e.CommandArgument)
        End If
    End Sub

    Sub DelComplaints(ByVal id As Integer)
        Dim cmd As New SqlCommand
        cmd.CommandText = "UserComplaints_Comments_Delete"
        cmd.Parameters.AddWithValue("@CommentID", id)
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
    Sub sendmailtoUser()
        Dim strMail As String = "Hi, This is " & txtName.Text & " <br /><br />,"
        strMail += txtComplaints.Text.Trim.Replace(ControlChars.Lf, "<br />")
        strMail += "<br /><br />"
        strMail += "You May Contact Me on <br />" & txtEmailMod.Text
        If txtMobileMod.Text <> "" Then
            strMail += "<br />" & txtMobileMod.Text
        End If
        strMail += "<br />For Any Other assistance"
        cf.send25("Admin", "Regarding Your Comilaint: " & HiddenField1.Value, HiddenField2.Value, strMail)
    End Sub
End Class
