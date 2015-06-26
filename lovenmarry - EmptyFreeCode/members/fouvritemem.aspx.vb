Imports System.Data
Imports System.Data.SqlClient

Partial Class members_fouvritemem
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
        Else

            label1.Text = "No Favourite Members Found"

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
        makequery = " select distinct memberidfav,pr.fname,pr.lname,(select top 1 photoname from photo where photo.pid=pr.pid) as photoname,photo.passw from profile pr inner join favorities f on pr.pid=f.memberidfav left join photo on pr.pid=photo.pid  where f.pid=" & Session("pid") & ""

    End Function

    Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
                Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photoname"), String)

                If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    End If
                End If

                If (url = "" Or url Is Nothing) Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If
                End If

                If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
                    End If
                End If
            End If
        catch ex as Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            PopulatePublishersGridView()
        End If
    End Sub
End Class


