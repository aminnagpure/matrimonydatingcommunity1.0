Imports System.Data
Imports System.Data.SqlClient

Partial Class members_profileviewedbyyou
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridViewPublishers.PageIndexChanging
        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
    End Sub

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = cf.friendshipdb()

        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)


        '      Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim jointype As String = ""



        sqlQuery = "select distinct profile.pid,profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw,vieweddate  from profile left join photo on  profile.pid=photo.pid inner join profileviews on profileviews.pidof=profile.pid  where profile.visibletoall='Y' and approved='Y' and viewedbyid='" & Session("pid") & "' "

        sqlQuery = sqlQuery & " order by vieweddate desc"


        Dim accessCommand As New SqlCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else

            label1.Text = "No Profile Viewed"

        End If

        accessConnection.Close()


    End Sub







    Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
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
    End Sub


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = False Then
            PopulatePublishersGridView()
        End If
    End Sub
End Class
