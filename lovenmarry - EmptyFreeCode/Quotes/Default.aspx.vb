
Partial Class Quotes_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If (Request.QueryString("id") Is Nothing) Then
                TextBox1.Text = " 1=1 "
            Else
                TextBox1.Text = "  tbl_Quotes.candiid=" & CInt(Request.QueryString("id")) & " "
            End If

        End If
    End Sub
End Class
