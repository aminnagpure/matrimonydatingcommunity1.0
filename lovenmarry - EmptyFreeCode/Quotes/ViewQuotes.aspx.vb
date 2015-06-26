Imports System.Data
Imports System.Data.SqlClient
Partial Class Quotes_ViewQuotes
    Inherits System.Web.UI.Page

    Public cf As New comonfunctions
    Dim strqid As String
    Dim strsq As String
    Dim iRowCounter As Integer = 0
    Dim iCellCounter As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim oDs As DataSet
            If Not (Request.QueryString("id") Is Nothing) Then
                oDs = executiveRdataset("select top 1 quotesid, Quotessub ,QuotesDesc ,quotespic ,quotesdate  from  tbl_Quotes where quotesid=" & Request.QueryString("id") & " order by quotesdate desc")
            Else
                oDs = executiveRdataset("select top 1 quotesid, Quotessub ,QuotesDesc ,quotespic ,quotesdate  from  tbl_Quotes order by quotesdate desc")
            End If
            lblque.Text = oDs.Tables(0).Rows(0)("Quotessub").ToString
            lblqid.Text = oDs.Tables(0).Rows(0)("quotesid").ToString
            'txtCriteriaComments.Text = " c.picid=" & Request.QueryString("id") & " "
            tdfundescr.InnerHtml = oDs.Tables(0).Rows(0)("QuotesDesc").ToString
            tdPostdate.InnerHtml = "Post Date :" & oDs.Tables(0).Rows(0)("quotesdate").ToString

            Page.Title = oDs.Tables(0).Rows(0)("Quotessub").ToString

            If Session("mrole") IsNot Nothing Then
                If Session("mrole") = "mod" Then
                    btnDel.Visible = True
                Else
                    btnDel.Visible = False
                End If
            Else
                btnDel.Visible = False
            End If


        End If


                loaddetails()

    End Sub
    Sub loaddetails()
        Dim ds As DataSet
        Dim cmd As New SqlCommand
        cmd.CommandText = "usp_get_Quotes_OtherDetails"
        cmd.Parameters.AddWithValue("@id", lblqid.Text)
        cmd.Parameters.AddWithValue("@Logid", IIf(Session("pid") <> Nothing, Session("pid"), 0))
        ds = cf.ExecuteDataset(cmd)
        If (ds.Tables(0).Rows(0)(1).ToString = "") Then
            tdmainimg.InnerHtml = "<a href='../members/viewprofile.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='../App_Themes/no_avatar.gif' style='height:150px;width:150px;border-width:0px;'></a><br>" & ds.Tables(0).Rows(0)(2).ToString
        Else
            tdmainimg.InnerHtml = "<a href='../members/viewprofile.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(1).ToString & "' style='height:150px;width:150px;border-width:0px;'></a><br>" & ds.Tables(0).Rows(0)(2).ToString
        End If

        GridView2.DataSource = ds.Tables(1)
        GridView2.DataBind()
        GridView3.DataSource = ds.Tables(3)
        GridView3.DataBind()




        ds.Dispose()
        cmd.Dispose()

        Dim gg As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        gg = googlecomments.InnerHtml
        gg = Replace(gg, "http://www.yoursite.com", Request.Url.AbsoluteUri)
        googlecomments.InnerHtml = gg

        Dim fbco As String = ""
        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
        fbco = facebookcomment.InnerHtml
        fbco = Replace(fbco, "abcd", Request.Url.AbsoluteUri)
        facebookcomment.InnerHtml = fbco
    End Sub
   
    'Protected Sub Rating1_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs) Handles Rating1.Changed
    '    If Session("pid") Is Nothing Then
    '        'Server.Transfer("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
    '        'Response.Redirect("../login.aspx") ' & "?ReturnUrl=" & Request.RawUrl)
    '        'Call LinkButton1_Click(LinkButton1, eLinkButton)
    '        Exit Sub
    '    End If
    '    Dim strid As String = 0

    '    Dim s1 As String
    '    s1 = e.Value
    '    Dim cmd As New SqlCommand
    '    cmd.CommandText = "usp_Add_Ratting"
    '    cmd.Parameters.AddWithValue("@fk_postId", lblqid.Text)
    '    cmd.Parameters.AddWithValue("@rate", s1)
    '    cmd.Parameters.AddWithValue("@posttype", "Quot")
    '    cmd.Parameters.AddWithValue("@fk_userId", Session("pid"))

    '    cf.ExecuteNonQuery(cmd)
    '    cmd.Dispose()
    '    fillgrid()

    '    loaddetails()
    'End Sub
    Function executiveRdataset(ByVal str As String) As DataSet
        Dim con As New SqlConnection
        Dim ds As DataSet = New DataSet

        con.ConnectionString = cf.friendshipdb

        Dim da As SqlDataAdapter = New SqlDataAdapter(str, con)
        da.Fill(ds)

        con.close()
        Return ds

    End Function




    'Protected Sub OnDelete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
    '    If e.CommandName.Equals("Rdelete") Then
    '        Try
    '            Dim strid As String = e.CommandArgument.ToString()
    '            DeleteAdsbtn(strid)
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Protected Sub DeleteAdsbtn(ByVal strid As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "delete from tbl_Quotes where  quotesid=" & strid & ""
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Response.Redirect("Default.aspx")
            ' Label1.Text = "Post Deleted Succesfully"
        Else
            Response.Redirect("Default.aspx")
            ' Label1.Text = "Post not Found"
        End If

        cmd.Dispose()
        cn.Close()

    End Sub

    
    Protected Sub btnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel.Click
        DeleteAdsbtn(Request.QueryString("id"))
    End Sub
End Class
