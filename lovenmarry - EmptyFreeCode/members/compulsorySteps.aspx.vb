
Partial Class members_Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("pid") Is Nothing Then
            'If Session("hasinvites") = "Y" Then
            '    lblInviteStatus.Text = "Step Completed"
            '    lblInviteStatus.ForeColor = Drawing.Color.Green
            '    lnkInvites.Enabled = False
            '    lnkprofile.Enabled = True
            'Else
            '    lblInviteStatus.Text = "Step In-complete"
            '    lblInviteStatus.ForeColor = Drawing.Color.Red
            '    lnkInvites.Enabled = True
            '    lnkprofile.Enabled = False
            'End If

            If Session("headline") <> "" Then
                lblprofileStatus.Text = "Step Copmleted"
                lblprofileStatus.ForeColor = Drawing.Color.Green
                lnkprofile.Enabled = False
            Else
                lblprofileStatus.Text = "Step In-complete"
                lblprofileStatus.ForeColor = Drawing.Color.Red

            End If
        Else
            Response.Redirect("../login.aspx")
        End If
    End Sub
End Class
