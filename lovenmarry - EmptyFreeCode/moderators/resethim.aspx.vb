
Partial Class moderators_resethim
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim kk As Boolean
        kk = cf.update("resetuser " & Request.QueryString("pid") & "")
        If kk = True Then
            Label1.Text = "Member Has Been Made Offline"
        End If
    End Sub
End Class
