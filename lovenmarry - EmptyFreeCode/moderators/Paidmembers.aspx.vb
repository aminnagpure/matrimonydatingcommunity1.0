
Partial Class moderators_Paidmembers
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            makequery()
        End If
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

    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim memtype As String = ""
        Dim email As String = ""
        'Dim sqlphoto As String = ""
        txtjointype.Text = " Left join"
        If txtemail.Text.Trim <> "" Then
            email = " AND Email='" & txtemail.Text & "'"
        End If
        If ddlpremiumType.SelectedIndex = 1 Or ddlpremiumType.SelectedIndex = 2 Then
            memtype = " AND Subs_Plan=" & ddlpremiumType.SelectedValue
        ElseIf ddlpremiumType.SelectedIndex = 3 Then
            memtype = " AND premiummem = 'Y'"
        End If
        makequery = " Paid='Y' " & email & memtype
        txtquery.Text = makequery

        Return makequery
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        makequery()
    End Sub

    Protected Sub ddlpremiumType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlpremiumType.SelectedIndexChanged
        makequery()
    End Sub
End Class
