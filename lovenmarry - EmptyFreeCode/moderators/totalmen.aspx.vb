Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_totalmen
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




    End Sub

    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridViewPublishers.PageIndexChanging
        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
    End Sub

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = cf.friendshipdb

        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)


        Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim jointype As String = ""


        jointype = " Left join"



        sqlQuery = "select distinct profile.pid,profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,photoname,email,profile.passw,ipaddress  from profile" & jointype & " photo on  profile.pid=photo.pid where visibletoall='Y'   " & makequery()

        sqlQuery = sqlQuery & "order by profiledate desc"


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



    Function makequery() As String

        makequery = "" ' sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonlinenow

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
