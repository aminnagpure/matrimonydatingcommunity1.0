Imports System.Data.SqlClient
Imports System.Data

Partial Class Partner_EditWebsite
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Dim pid As Integer = 0
    Dim webid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getdata()
        End If
    End Sub

    Public Sub getdata()
        ' Dim Cat As String = ""
        Dim str1 As String = ""
        Try
            pid = Session("pid")
            webid = Request.QueryString("id")
            '  Cat = Request.QueryString("Cat")
        Catch ex As Exception

        End Try
        Dim cmd As New SqlCommand
        str1 = "Get_MyWebsitesDetails" '" & pid & "','" & webid & "'"
        cmd.CommandText = str1
        cmd.Parameters.AddWithValue("@candiid", pid)
        cmd.Parameters.AddWithValue("@webid", webid)
        'cmd.Parameters.AddWithValue("@category", Cat)
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)
        Try

            If ds.Tables(0).Rows.Count > 0 Then

                ' lblCategory.Text = Cat
                lblUrl.Text = ds.Tables(0).Rows(0)("WebsiteUrl").ToString
                txtWebTitle.Text = ds.Tables(0).Rows(0)("WebsiteTitle").ToString
                txtPunchLine.Text = ds.Tables(0).Rows(0)("WebsitePunchline").ToString
                'txtWebTitle
                'txtAd1_ClientID.Text = ds.Tables(0).Rows(0)("Ads1_ad_client").ToString
                'txtAd1_Slot.Text = ds.Tables(0).Rows(0)("Ads1_Slot").ToString
                'txtAd2_ClientID.Text = ds.Tables(0).Rows(0)("Ads2_ad_client").ToString
                'txtAd2_Slot.Text = ds.Tables(0).Rows(0)("Ads2_Slot").ToString
                'txtAd3_ClientID.Text = ds.Tables(0).Rows(0)("Ads3_ad_client").ToString
                'txtAd3_Slot.Text = ds.Tables(0).Rows(0)("Ads3_Slot").ToString
            Else
                btnUpdate.Enabled = False
                btnUpdate.Text = "Website Not Found"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim str1 As String = ""

        Dim cmd As New SqlCommand

        'EditDatingSite

        Dim cat As String = ""
        Try
            pid = Session("pid")
            webid = Request.QueryString("id")
            'cat = lblCategory.Text

        Catch ex As Exception

        End Try
        ' If cat.ToUpper = "DATING" Then
        str1 = "EditDatingSite"
        'Else
        'str1 = "EditClassifiedSite"
        ''End If

        Try
            cmd.CommandText = str1
            cmd.Parameters.AddWithValue("@candiid", pid)
            cmd.Parameters.AddWithValue("@webid", webid)
            cmd.Parameters.AddWithValue("@WebTitle", txtWebTitle.Text.Trim)
            cmd.Parameters.AddWithValue("@WebsitePunchline", txtPunchLine.Text.Trim)
            'cmd.Parameters.AddWithValue("@Ads1", txtAd1_ClientID.Text.Trim)
            'cmd.Parameters.AddWithValue("@Ads1_Slot", txtAd1_Slot.Text.Trim)
            'cmd.Parameters.AddWithValue("@Ads2", txtAd2_ClientID.Text.Trim)
            'cmd.Parameters.AddWithValue("@Ads2_Slot", txtAd2_Slot.Text.Trim)
            'cmd.Parameters.AddWithValue("@Ads3", txtAd3_ClientID.Text.Trim)
            ''cmd.Parameters.AddWithValue("WebsitePunchline", txtPunchLine.Text)
            'cmd.Parameters.AddWithValue("@Ads3_Slot", txtAd3_Slot.Text.Trim)

            Dim i As Integer = cf.ExecuteNonQuery(cmd)
        Catch ex As Exception

        End Try
    End Sub
End Class
