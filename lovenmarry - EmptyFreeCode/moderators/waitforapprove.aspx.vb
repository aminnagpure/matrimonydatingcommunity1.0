Imports System.Data
Imports System.Data.SqlClient

Partial Class moderators_waitforapprove
    Inherits System.Web.UI.Page
    Function makequery() As String
        TextBox1.Text = " approved='N' and susp='N' and isdoubtful='N' "
        'Return TextBox1.Text
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            makequery()
        End If
    End Sub
End Class

