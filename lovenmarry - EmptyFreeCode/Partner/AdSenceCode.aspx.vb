Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Data

Partial Class Partner_AdSenceCode
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMsg.Text = ""
        If txtPub.Text.Trim <> "" Then
            If Not IsNumeric(txtPub.Text.Trim) Then
                lblMsg.ForeColor = Drawing.Color.Red
                lblMsg.Text = "Enter Only Numeric Part Underline in Image"
                Exit Sub
            End If

        End If
        Dim str As String = "" 'Update_ClassifiedAdsence" '"Update DatingSite set Ads1_ad_client=Ads1_ad_client,Ads2_ad_client=Ads2_ad_client,Ads3_ad_client = Ads3_ad_client where webid=@webid"
        'If Request.QueryString("Cat").ToUpper = "DATING" Then
        str = "Update_DatingAdsence"
        'End If
        Dim cmd As New SqlCommand
        cmd.CommandText = str
        cmd.Parameters.AddWithValue("@webid", Request.QueryString("id"))
        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@Ads1_ad_client", "") ' txtAd1_ClientID.Text)
        cmd.Parameters.AddWithValue("@Ads2_ad_client", "") ' txtAd2_ClientID.Text)
        cmd.Parameters.AddWithValue("@Ads3_ad_client", "") 'txtAd3_ClientID.Text)
        cmd.Parameters.AddWithValue("@Ads4_ad_client", "") 'txtAd4_ClientID.Text)
        cmd.Parameters.AddWithValue("@pub_id", txtPub.Text.Trim)
        Dim i As Integer = cf.ExecuteNonQuery(cmd)
        If i > 0 Then

        End If
    End Sub
    Public Sub getdata()
        Dim PID As Integer = 0
        Dim Cat As String = ""
        Dim str1 As String = ""
        Dim webid As Integer = 0
        Try
            PID = Session("pid")
            webid = Request.QueryString("id")
            Cat = Request.QueryString("Cat")
        Catch ex As Exception

        End Try
        Dim cmd As New SqlCommand

        str1 = "Get_MyWebsitesDetails" '" & pid & "','" & webid & "'"
        cmd.CommandText = str1
        cmd.Parameters.AddWithValue("@candiid", PID)
        cmd.Parameters.AddWithValue("@webid", webid)
        'cmd.Parameters.AddWithValue("@category", Cat)
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)
        Try
            If ds.Tables(0).Rows.Count > 0 Then

                'txtWebTitle
                'txtAd1_ClientID.Text = ds.Tables(0).Rows(0)("Ads1_ad_client").ToString
                'txtAd1_Slot.Text = ds.Tables(0).Rows(0)("Ads1_Slot").ToString
                'txtAd2_ClientID.Text = ds.Tables(0).Rows(0)("Ads2_ad_client").ToString
                'txtAd2_Slot.Text = ds.Tables(0).Rows(0)("Ads2_Slot").ToString
                'txtAd3_ClientID.Text = ds.Tables(0).Rows(0)("Ads3_ad_client").ToString
                'txtAd3_Slot.Text = ds.Tables(0).Rows(0)("Ads3_Slot").ToString
                txtPub.Text = ds.Tables(0).Rows(0)("pub_id")
            Else
                btnUpdate.Enabled = False
                btnUpdate.Text = "Website Not Found"
            End If



        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getdata()
        End If
    End Sub
End Class
