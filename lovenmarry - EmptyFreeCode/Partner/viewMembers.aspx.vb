Imports System.Data.SqlClient

Partial Class Partner_viewMembers
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Dim queryforentry As String = ""


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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Session("pid") Is Nothing Then
        '    If Session("hasinvites") = "N" Then
        '        Response.Redirect("compulsorySteps.aspx")
        '    ElseIf Session("headline") = "" Then
        '        Response.Redirect("compulsorySteps.aspx")
        '    End If
        'Else
        '    Response.Redirect("../login.aspx")
        'End If

        If Not Page.IsPostBack Then
            If Request.QueryString("id") <> "" Then
                txtquery.Text = " RegWebID=" & Request.QueryString("id")
            Else
                txtquery.Text = " ref1=" & Session("pid")
            End If


        End If
    End Sub
End Class
