Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Data.SqlClient

Partial Class Quotes_addQuotes
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Session("pid") Is Nothing Then
                Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
            End If
            If (Session("pid") = "") Then
                Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
            End If

            FillCategory()
        End If
    End Sub
    Sub FillCategory()
        Dim cmd As New SqlCommand("Fill_QuotesCategory")
        With dpCategory
            .DataSource = cf.ExecuteDatareader(cmd)
            .DataValueField = "catid"
            .DataTextField = "category"
            .DataBind()
            .Items.Insert(0, "--Select--")
            .Items.Item(0).Value = 0
        End With
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim msg As String = ""
        Dim filecopy As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim ext As String = ""
        msg = addfunnyimages(ext)
       
        Clear()
     



    End Sub

    Function addfunnyimages(ByVal pid As String) As String
        Dim uid As String = ""
        Dim ipadd As String = ""
        ipadd = getip()

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim photoid As String = ""
        Dim photoname As String = ""
        Dim kk As String = ""
        Dim ds As New DataSet
        uid = cf.generateid

        cmd.Connection = cn
        cmd.CommandText = "usp_add_Quotes"
        cmd.Parameters.AddWithValue("@mid", Session("pid"))
        cmd.Parameters.AddWithValue("@adsubject", cf.ReplaceBadWords(txtsubject.Text))
        cmd.Parameters.AddWithValue("@addescription", cf.ReplaceBadWords(txtdescription.Text.Replace(ControlChars.Lf, "<br />")))
        cmd.Parameters.AddWithValue("@picPhoto", "")
        cmd.Parameters.AddWithValue("@ipaddress", ipadd)
        cmd.Parameters.AddWithValue("@categoryId", dpCategory.SelectedValue)
        ds = cf.ExecuteDataset(cmd)
        kk = ds.Tables(0).Rows(0)(0).ToString
        Session("sesquotes") = kk
        cmd.dispose()
        cn.close()

        addfunnyimages = uid
    End Function

    Sub Clear()
        txtsubject.Text = ""
        txtdescription.Text = ""
        dpCategory.SelectedValue = 0
        Session("sesquotes") = Nothing
    End Sub


    Function getip() As String
        Dim ip As String = ""
        ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If Not String.IsNullOrEmpty(ip) Then
            Dim ipRange As String() = ip.Split(","c)
            Dim le As Integer = ipRange.Length - 1
            Dim trueIP As String = ipRange(le)
        Else
            ip = Request.ServerVariables("REMOTE_ADDR")
        End If
        getip = ip

    End Function


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Session("pid") IsNot Nothing Then
            'If Session("Friendshipzone") = "N" Then
            '    Response.Redirect("../members/dostizone/addprofile.aspx?msg=Activate Your Alc For Friendship Zone")
            'End If
        Else
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If

        If Not Page.IsPostBack Then

        End If
    End Sub



End Class
