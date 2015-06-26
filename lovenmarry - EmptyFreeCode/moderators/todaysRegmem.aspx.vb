
Partial Class moderators_todaysRegmem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = " convert(date,profiledate)=convert(date,getdate())"
    End Sub
End Class
