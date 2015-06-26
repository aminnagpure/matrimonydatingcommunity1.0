Imports System.Data
Imports System.Data.SqlClient


Partial Class members_directmemreferd
    Inherits System.Web.UI.Page

    Public cf As New comonfunctions




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
            TextBox1.Text = " ref1=" & Session("pid") & ""
        End If
    End Sub

    
End Class
