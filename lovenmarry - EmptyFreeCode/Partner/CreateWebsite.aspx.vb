Imports System.Data.SqlClient

Partial Class Partner_CreateWebsite
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub btnAd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAd.Click
        Dim cmd As New SqlCommand
        'If ddlCat.SelectedIndex = 0 Then
        '    Exit Sub
        'ElseIf ddlCat.SelectedIndex = 1 Then
        '    cmd.CommandText = "AddClassifiedSite"
        'Else
        cmd.CommandText = "AddDatingSite"
        'End If
        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@WebsiteUrl", txtWebUrl.Text.Trim)
        cmd.Parameters.AddWithValue("@WebsiteTitle", txtWebTitle.Text.Trim)
        cmd.Parameters.AddWithValue("@WebsitePunchline", txtPunchLine.Text.Trim)
        cmd.Parameters.AddWithValue("@Ads1", "") 'txtAd1_ClientID.Text)
        cmd.Parameters.AddWithValue("@Ads2", "") ' txtAd2_ClientID.Text)
        cmd.Parameters.AddWithValue("@Ads3", "") ' txtAd3_ClientID.Text)
        
        Dim i As Integer = cf.ExecuteScalar(cmd, cf.friendshipdb)
        If i > 0 Then
            Response.Redirect("AdSenceCode.aspx?id=" & i)
        End If

    End Sub
End Class
