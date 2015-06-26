
Partial Class moderators_suspend
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = ""
        Dim kk As Boolean
        kk = cf.update("suspendprofile '" & Request.QueryString("pid") & "'")


        If kk = True Then
            msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
            msgaa.InnerHtml = "Profile Suspended"
        End If
    End Sub
End Class
