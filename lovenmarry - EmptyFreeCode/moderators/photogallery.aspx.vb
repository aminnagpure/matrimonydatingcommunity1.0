Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_photogallery
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions


    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = cf.friendshipdb

        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)



        Dim sqlQuery As String = ""




        sqlQuery = makequery()



        Dim accessCommand As New SqlCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()

        End If


        accessConnection.Close()

    End Sub







    Private Property GridViewSortDirection() As String

        Get

            Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))

        End Get

        Set(ByVal value As String)

            ViewState("SortDirection") = value

        End Set

    End Property



    Private Property GridViewSortExpression() As String

        Get

            Return IIf(ViewState("SortExpression") = Nothing, String.Empty, ViewState("SortExpression"))

        End Get

        Set(ByVal value As String)

            ViewState("SortExpression") = value

        End Set

    End Property



    Private Function GetSortDirection() As String

        Select Case GridViewSortDirection

            Case "ASC"

                GridViewSortDirection = "DESC"



            Case "DESC"

                GridViewSortDirection = "ASC"

        End Select



        Return GridViewSortDirection

    End Function



    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        'gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), True)

        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
        'gridViewPublishers.DataBind()

    End Sub



    Protected Function SortDataTable(ByVal pdataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView

        If Not pdataTable Is Nothing Then

            Dim pdataView As New DataView(pdataTable)

            If GridViewSortExpression <> String.Empty Then

                If isPageIndexChanging Then

                    pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)

                Else

                    pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())

                End If

            End If

            Return pdataView

        Else

            Return New DataView()

        End If

    End Function



    Protected Sub gridViewPublishers_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression

        Dim pageIndex As Integer = gridViewPublishers.PageIndex

        gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), False)

        gridViewPublishers.DataBind()

        gridViewPublishers.PageIndex = pageIndex

    End Sub

    Function makequery() As String
        makequery = " select photoname,photoid,pid from photo where pid=" & Request.QueryString("pid") & ""
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If
        If Not Page.IsPostBack Then


            PopulatePublishersGridView()

            'displaydelbtn()
        End If
    End Sub

    Protected Sub displaydelbtn()
        Dim i As Integer
        If Session("mrole") IsNot Nothing Then
            If Session("mrole") = "mod" Then
                For i = 0 To gridViewPublishers.Rows.Count - 1
                    gridViewPublishers.Rows(i).Cells(0).Text = "<a href='photogallery.aspx?flag=Delete&answerid=" & gridViewPublishers.DataKeys(i).Value & "' &id=" & Request.QueryString("pid") & " onclick='return comfirmdel();'>Delete</a>"
                Next
            Else
                gridViewPublishers.Columns(0).Visible = False
            End If
        End If
    End Sub

End Class
