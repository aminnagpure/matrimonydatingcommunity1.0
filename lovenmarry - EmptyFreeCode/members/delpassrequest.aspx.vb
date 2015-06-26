
Partial Class members_delpassrequest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove Password Request?"
        Else
            LinkButton1.Text = ""
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cf As New comonfunctions
        Dim kk As Boolean
        Dim strsql As String = ""

        strsql = "delete from passwordrequests where requestid='" & Request.QueryString("pid") & "' and topid='" & Session("pid") & "'"
        kk = cf.delrecordset(strsql)
        If kk = True Then
            Label1.Text = "Password Request Removed Succesfully"
        Else
            Label1.Text = " Password Request Block not Found"
        End If
    End Sub
End Class
