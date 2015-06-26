Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class members_photogallery
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Private Sub PopulatePublishersGridView(ByVal pass As String)
        Dim connectionString As String = cf.justviewcon
        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)
        Dim sqlQuery As String = ""
        sqlQuery = makequery()
        Dim accessCommand As New SqlCommand(sqlQuery, accessConnection)
        Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)
        Dim publishersDataTable As New DataTable("profile")
        publishersDataAdapter.Fill(publishersDataTable)
        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count
        If dataTableRowCount > 0 Then
            'gridViewPublishers.DataSource = publishersDataTable
            'gridViewPublishers.DataBind()
            If publishersDataTable.Rows(0)("passw") <> "" Then
                If pass <> "" Then
                    If publishersDataTable.Rows(0)("passw") = pass Then
                        GoTo bindList
                    Else
                        lblPError.ForeColor = System.Drawing.Color.Red
                        lblPError.Text = "Wrong Password"
                    End If
                End If
            Else
bindList:
                ListView1.DataSource = publishersDataTable
                ListView1.DataBind()
                photopassw.Visible = False
                Button1.Visible = False
                lblP.Visible = False
                lblPError.Text = ""
            End If
            
        End If
    End Sub
    Function makequery() As String
        If Request.QueryString("pid") <> "" And Request.QueryString("pid") IsNot Nothing Then
            makequery = "photogallery " & Request.QueryString("pid") & "" ' select photoname,photoid,candiid from photos where candiid=" & Request.QueryString("id") & " order by uploaddate desc"
        Else
            makequery = "photogallery " & 0 & "" ' " select photoname,photoid,candiid from photos where candiid=" & Request.Cookies("candiid").Value & " order by uploaddate desc"
        End If
    End Function
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Not Page.IsPostBack Then
                PopulatePublishersGridView("")
                If Request.QueryString("Pic") <> "" Then

                    'TextBox1.Text = Request.QueryString("picid")
                    '  "c.candiid=" & Request.QueryString("id") & " and c.photoid=" &
                    If IsNumeric(Request.QueryString("Pic")) Then
                        showphoto(Request.QueryString("Pic"))
                    End If
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Sub showphoto(ByVal phid As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim sql As String = ""
        Dim a As String = ""
        sql = "select photoname,photoid,pid from photo where photoid=" & phid
        cn.ConnectionString = cf.justviewcon
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = sql
        myreader = cmd.ExecuteReader

        Try

            Dim pid As String = Request.QueryString("pid")
            Dim ImgName As String = ""
            If myreader.HasRows Then
                While myreader.Read
                    a = myreader.GetValue(1).ToString
                    ImgName = myreader.GetValue(0).ToString
                End While
            End If
            cn.Close()
            Dim PhotoUrl As String = ""
            If File.Exists(Server.MapPath("../App_Themes/" & ImgName)) Then
                pic.ImageUrl = "../App_Themes/" & ImgName
                pic.Visible = True
                div_Lnk.InnerHtml = "<link rel='image_src' href='http://www.yoursite.com/App_Themes/" & ImgName & "' />"

                Try
                    PhotoUrl = "&Pic=" & a
                Catch ex As Exception
                End Try
            End If
            Dim gg As String = ""
            'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
            gg = "<script src='https://apis.google.com/js/plusone.js'></script>"
            gg += "                    <g:comments"
            gg += "                        href='http://www.yoursite.com/photogallery.aspx?pid=" & pid & PhotoUrl & "'"
            gg += "                        width='642'"
            gg += "                        first_party_property='BLOGGER'"
            gg += "                        view_type='FILTERED_POSTMOD'>"
            gg += "                    </g:comments>"

            googlecomments.InnerHtml = gg
            Dim fbco As String = ""
            'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
            fbco = facebookcomment.InnerHtml
            fbco = Replace(fbco, "abcd", "http://www.yoursite.com/photogallery.aspx?pid=" & pid & PhotoUrl)
            fbco = "<div class='fb-comments' data-href='http://www.yoursite.com/photogallery.aspx?pid=" & pid & PhotoUrl & "' data-width='470'></div>"
            facebookcomment.InnerHtml = fbco
            'GridView1.DataSourceID = ObjectDataSource1.ID
            viewcomment.Visible = True


        Catch ex As Exception
            'Response.Write(ex.ToString)

            cn.Close()
        End Try
    End Sub

    Sub deleterec(ByVal reqid As String)
        Dim cmd As New SqlCommand
        cmd.CommandText = "Deletephotocomment"
        cmd.Parameters.AddWithValue("@id", reqid)
        cf.ExecuteNonQuery(cmd, cf.justviewcon)
    End Sub
    Protected Sub ListView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles ListView1.ItemCommand
        If e.CommandName = "ShowImg" Then
            'TextBox1.Text = e.CommandArgument
            '  "c.candiid=" & Request.QueryString("id") & " and c.photoid=" &
            showphoto(e.CommandArgument)
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        PopulatePublishersGridView(photopassw.Text)
    End Sub
#Region "Old Gallery"


    'Dim cf As New comonfunctions
    'Dim pid As Integer = 0
    'Private Sub PopulatePublishersGridView()
    '    Dim ds1 As New DataSet
    '    ' If Session("chcPopulatePublishersGridView" & Request.QueryString("pid")) Is Nothing Then
    '    Dim cmd As New SqlCommand
    '    cmd.CommandText = "photogallery"
    '    cmd.Parameters.AddWithValue("@pid", Request.QueryString("pid"))
    '    cmd.CommandType = CommandType.StoredProcedure
    '    ds1 = cf.ExecuteDataset(cmd)
    '    '   Session("chcPopulatePublishersGridView" & Request.QueryString("pid")) = ds1
    '    'End If
    '    'ds1 = Session("chcPopulatePublishersGridView" & Request.QueryString("pid"))
    '    If ds1.Tables(0).Rows.Count > 0 Then
    '        gridViewPublishers.DataSource = ds1.Tables(0)
    '        gridViewPublishers.DataBind()
    '    End If
    'End Sub
    'Private Property GridViewSortDirection() As String
    '    Get
    '        Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))
    '    End Get
    '    Set(ByVal value As String)
    '        ViewState("SortDirection") = value
    '    End Set
    'End Property

    'Private Property GridViewSortExpression() As String
    '    Get
    '        Return IIf(ViewState("SortExpression") = Nothing, String.Empty, ViewState("SortExpression"))
    '    End Get
    '    Set(ByVal value As String)
    '        ViewState("SortExpression") = value
    '    End Set
    'End Property

    'Private Function GetSortDirection() As String
    '    Select Case GridViewSortDirection
    '        Case "ASC"
    '            GridViewSortDirection = "DESC"
    '        Case "DESC"
    '            GridViewSortDirection = "ASC"
    '    End Select
    '    Return GridViewSortDirection
    'End Function

    'Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    'gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), True)
    '    gridViewPublishers.PageIndex = e.NewPageIndex
    '    PopulatePublishersGridView()
    '    'gridViewPublishers.DataBind()
    'End Sub

    'Protected Function SortDataTable(ByVal pdataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView
    '    If Not pdataTable Is Nothing Then
    '        Dim pdataView As New DataView(pdataTable)
    '        If GridViewSortExpression <> String.Empty Then
    '            If isPageIndexChanging Then
    '                pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)
    '            Else
    '                pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())
    '            End If
    '        End If
    '        Return pdataView
    '    Else
    '        Return New DataView()
    '    End If
    'End Function

    'Protected Sub gridViewPublishers_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
    '    GridViewSortExpression = e.SortExpression
    '    Dim pageIndex As Integer = gridViewPublishers.PageIndex
    '    gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), False)
    '    gridViewPublishers.DataBind()
    '    gridViewPublishers.PageIndex = pageIndex
    'End Sub


    'Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
    '    Try

    '        Try
    '            pid = Request.QueryString("pid")
    '        Catch ex As Exception

    '        End Try
    '        If Not Page.IsPostBack Then
    '            PopulatePublishersGridView()
    '            displaydelbtn()
    '            If Not IsNothing(Request.QueryString("flag")) Then
    '                If Request.QueryString("flag") = "Delete" Then
    '                    deletephoto()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Response.Write(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub displaydelbtn()
    '    Dim i As Integer
    '    If Session("mrole") IsNot Nothing Then
    '        If Session("mrole") = "mod" Then
    '            For i = 0 To gridViewPublishers.Rows.Count - 1
    '                gridViewPublishers.Rows(i).Cells(0).Text = "<a href='photogallery.aspx?flag=Delete&photoid=" & gridViewPublishers.DataKeys(i).Value & " &pid=" & Request.QueryString("pid") & "' onclick='return comfirmdel();'>Delete</a>"
    '            Next
    '        Else
    '            gridViewPublishers.Columns(0).Visible = False
    '        End If
    '    End If
    'End Sub

    'Protected Sub deletephoto()
    '    Dim strcon1 As String = cf.friendshipdb()
    '    Dim cmd As New SqlCommand
    '    Dim dc As Integer
    '    Dim strcon As SqlConnection = New SqlConnection(strcon1)
    '    strcon.Open()
    '    cmd.Connection = strcon
    '    cmd.CommandTimeout = 5000
    '    cmd.CommandText = "delete from photo where photoid=" & Request.QueryString("photoid") & ""
    '    dc = cmd.ExecuteNonQuery()
    '    Dim ds As New DataSet
    '    Session("chcPopulatePublishersGridView" & Request.QueryString("pid")) = Nothing

    '    If dc <> 0 Then
    '        Response.Redirect("photogallery.aspx?pid=" & Request.QueryString("pid") & " ")
    '    Else
    '        Response.Redirect("photogallery.aspx?pid=" & Request.QueryString("pid") & " ")
    '    End If
    '    cmd.Dispose()
    '    strcon.Close()
    'End Sub


    'Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim PhotoUrl As String = ""
    '        Try
    '            PhotoUrl = "&Pic=" & TryCast(DataBinder.Eval(e.Row.DataItem, "Photoname"), String)
    '        Catch ex As Exception

    '        End Try
    '        Dim gg As String = ""
    '        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
    '        gg = googlecomments.InnerHtml
    '        gg = Replace(gg, "http://www.yoursite.com", "http://www.yoursite.com/photogallery.aspx?pid=" & pid & PhotoUrl)
    '        googlecomments.InnerHtml = gg

    '        Dim fbco As String = ""
    '        'googlecomments.InnerHtml = "<script src='https://apis.google.com/js/plusone.js'></script><g:comments   href = 'http://www.yoursite.com'  width = '642' first_party_property = 'BLOGGER'    view_type='FILTERED_POSTMOD'></g:comments>"
    '        fbco = facebookcomment.InnerHtml
    '        fbco = Replace(fbco, "abcd", "http://www.yoursite.com/photogallery.aspx?pid=" & pid & PhotoUrl)
    '        facebookcomment.InnerHtml = fbco
    '    End If

    'End Sub
#End Region

   
End Class
