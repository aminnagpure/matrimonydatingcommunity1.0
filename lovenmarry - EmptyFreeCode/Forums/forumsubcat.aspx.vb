Imports System.IO

Partial Class Forums_forumsubcat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtsq.Text = Request.QueryString("id")
        HyperLink1.NavigateUrl = "posttopic.aspx?id=" & Request.QueryString("id") & "&mc=" & Request.QueryString("mc")
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Then
            Dim url As String = TryCast(DataBinder.Eval(e.Item.DataItem, "photo"), String)
            If (url <> "" Or url IsNot Nothing) Then
                Dim img As Image = DirectCast(e.Item.FindControl("imgstart"), Image)
                If img IsNot Nothing Then
                    If File.Exists(Server.MapPath("../App_Themes/Thumbs/" & url)) Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    Else
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If

                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Item.FindControl("imgstart"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If
            End If
        End If

        'Dim itm As RepeaterItem = e.Item

        ''Dim lblimg As String = DirectCast(itm.FindControl("lblimg"), Label).ToString()
        'Dim url As String = TryCast(DataBinder.Eval(itm.DataItem, "photo"), String)
        ''Dim bt1 As Button = DirectCast(itm.FindControl("Button1"), Button)
        ''Dim HprLink1 As New HyperLink
        ''HprLink1 = DirectCast(itm.FindControl("HyperLink1"), HyperLink)
        ''If (Session("role") = "mod") Then
        ''    HprLink1.Visible = True
        ''Else
        ''    HprLink1.Visible = False
        ''End If

        'If (url <> "" Or url IsNot Nothing) Then
        '    Dim img As Image = DirectCast(itm.FindControl("img1"), Image)
        '    If img IsNot Nothing Then
        '        img.ImageUrl = "../App_Themes/Thumbs/" & url
        '    End If
        'End If
        'If (url = "" Or url Is Nothing) Then
        '    Dim img As Image = DirectCast(itm.FindControl("img1"), Image)
        '    If img IsNot Nothing Then
        '        img.ImageUrl = "../App_Themes/no_avatar.gif"
        '    End If
        'End If
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.CssClass = "header1"
        End If

        'Add CSS class on normal row.
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            e.Row.CssClass = "normal1"
        End If

        'Add CSS class on alternate row.
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Alternate Then
            e.Row.CssClass = "alternate1"
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rc As Integer
            Dim strforumqnaid As String
            'Dim i As Integer
            'For i = 0 To GridView1.Rows.Count()
            strforumqnaid = GridView2.DataKeys(e.Row.RowIndex).Value
            'rc = countreply(strforumqnaid)
            Dim lblreply As Label = DirectCast(e.Row.FindControl("lblreply"), Label)
            lblreply.Text = "Reply:- " & rc.ToString()
            ' Next

            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photo"), String)

            If (url <> "" Or url IsNot Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    If File.Exists(Server.MapPath("../App_Themes/Thumbs/" & url)) Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    Else
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If

                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If
            End If

            'If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
            '    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
            '    If img IsNot Nothing Then
            '        img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
            '    End If
            'End If

        End If
    End Sub
End Class
