

Partial Class thankyou
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsql As String = ""
        Dim msgmem As String = ""
        Dim email As String = ""
        email = Request.Form("email")
        strsql = "update profile set premiummem='Y' where email='" & email & "'"
        Dim rtn As Integer = 0
        rtn = cf.TaskmembSql(strsql)
        If rtn > 0 Then
            Label1.Text = "Your Premium member now"
        Else
            Label1.Text = "kindly contact us if you are not set to premium member"
        End If

        msgmem = "Your yoursite.com alc with email " & email & " <br> is set as premium member <br>for any problems you can contact us back <br>http://www." & cf.websitename
        cf.send25("admin", "Your Alc Set as Premium", email, msgmem)

        'cf.send25("admin", "ipn fired", "aminnagpure@gmail.com", "ipn fired")

    End Sub
End Class
