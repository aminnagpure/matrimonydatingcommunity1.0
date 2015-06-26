Imports System.Data.SqlClient

Partial Class members_awaitingMembers
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadQuery()
        End If
    End Sub
    Sub loadQuery()
        txtCid.Text = Session("pid")
        TextBox2.Text = " profile.pid in(Select distinct candiid from User_Interest WHere IntrestedIn=" & Session("pid") & " and UserResponse='P')"
        gridview1.DataSourceID = ObjectDataSource1.ID
    End Sub
    Protected Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridview1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photopassw"), String)
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

    Protected Sub gridview1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        If e.CommandName = "Y" Or e.CommandName = "N" Then
            UpdateInterest(e.CommandName, e.CommandArgument)
        End If
    End Sub
    Sub UpdateInterest(ByVal UResponse As String, ByVal pid As String)
        Dim cmd As New SqlCommand

        cmd.CommandText = "UpDate_Interest"

        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@Tocandiid", pid)
        cmd.Parameters.AddWithValue("@AddDate", Date.Now)
        cmd.Parameters.AddWithValue("@Response", UResponse)
        ''cmd.Parameters.AddWithValue("@Mess", "")
        Dim i As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
        loadQuery()
    End Sub
End Class
