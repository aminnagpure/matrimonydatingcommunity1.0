Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_membershemade
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = cf.friendshipdb

        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)



        Dim sqlQuery As String = ""



        sqlQuery = "select distinct profile.pid,profile.profiledate,email,profile.passw,fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,photoname,ipaddress  from profile left join photo on  profile.pid=photo.pid where   " & makequery()




        sqlQuery = sqlQuery & " order by Profiledate desc"



        Dim accessCommand As New SqlCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else
            label1.Text = "No Profiles Found"

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



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If Page.IsPostBack = True Then

        'Else


        'End If


    End Sub
    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String



        makequery = " approved='Y' and profile.pid in (Select referd from topearners where mid=" & Request.QueryString("pid") & ") and pstatus='" & Request.QueryString("pstatus") & "'" 'ref1='" & Request.QueryString("pid") & "'

    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If checklogin() = False Then
        '    Response.Redirect("~/modlogin.aspx")
        '    Exit Sub
        'End If

        If Page.IsPostBack = False Then
            PopulatePublishersGridView()
        End If

    End Sub

   
End Class
