
Partial Class moderators_approvephoto
    Inherits System.Web.UI.Page
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete




        Dim cf As New comonfunctions
        Dim kk As Boolean

        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If

        If Request.QueryString("pid") <> "" Then
            kk = cf.update("approvephoto " & Request.QueryString("pid") & "")
        End If

        If kk = True Then
            Label1.Text = "Photo Approved"
        Else
            Label1.Text = "Photo Not Found"
        End If



    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
