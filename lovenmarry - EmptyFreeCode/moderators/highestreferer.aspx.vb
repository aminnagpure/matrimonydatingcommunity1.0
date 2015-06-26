Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_highestreferer
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions







    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = False Then
            'PopulatePublishersGridView()
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.Text = " r1.pstatus='Pending' and r1.earndate =GETDATE()"
        Else
            TextBox1.Text = " r1.pstatus='Pending'"
        End If
        gridViewPublishers.DataSourceID = ObjectDataSource1.ID
    End Sub
End Class
