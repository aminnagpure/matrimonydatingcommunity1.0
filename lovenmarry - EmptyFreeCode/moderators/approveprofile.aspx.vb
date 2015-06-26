
Partial Class moderators_approveprofile
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = ""
        Dim kk As Boolean
        Dim confast As String = ""
        Dim refid As String = ""
        Dim sql As String = ""

        'confast = "Server=jobdhundoserver; Database=fastfastmoney;User ID=inupdel; Password=gandmasti;Timeout=200;pooling=true; Max Pool Size=200; Trusted_Connection=False"

        kk = cf.update("update profile set Approved='Y', isdoubtful='N', susp='N' where pid=" & Request.QueryString("pid"))


        If kk = True Then
            msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
            msgaa.InnerHtml = "Profile Approved"
        End If

        If Request.QueryString("photo") = "Y" Then
            kk = cf.update("update photo set active='Y' where pid=" & Request.QueryString("pid"))
            msgaa.InnerHtml = "Profile Approved With Photo"
        End If

        sql = "select ref1 from profile where pid=" & Request.QueryString("pid") & ""
        refid = cf.CountRs(sql)

        'sql = "update offersmoneymade set pstatus='Approved' where refby=" & refid & " and mid=" & Request.QueryString("pid") & ""

        'refid = cf.updatefastfastmoney(sql)

    End Sub
End Class
