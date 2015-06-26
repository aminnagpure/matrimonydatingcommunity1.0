Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Forums_Default
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Private allProducts As forumsubmain.getSubCategoryDataTable = Nothing
    Protected Function GetProductsInCategory(ByVal categoryID As Integer) As forumsubmain.getSubCategoryDataTable
        ' First, see if we've yet to have accessed all of the product information
        'If allProducts Is Nothing Then
        Dim productAPI As New forumsubcategorycls
        allProducts = productAPI.GetProductsPaged(0, 10, categoryID)
        'End If

        ' Return the filtered view
        allProducts.DefaultView.RowFilter = "CatId= " & categoryID
        Return allProducts
    End Function

    Dim strname As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'lbtsearch.PostBackUrl = " search.aspx?startedby=" & Request.Cookies("firstname").value
            If Request.QueryString("id") IsNot Nothing And Request.QueryString("id") <> "" Then
                'TextBox1.Text = Request.QueryString("id")
            Else
                'TextBox1.Text = 1
            End If

        End If

    End Sub

    Protected Sub disphoto()

        For Each item As RepeaterItem In Repeater1.Items
            Dim rep2 As Repeater = DirectCast(item.FindControl("Repeater2"), Repeater)

            For Each item2 As RepeaterItem In rep2.Items
                Dim imgm As Image = DirectCast(item2.FindControl("imgm"), Image)
                If imgm Is Nothing Then
                    imgm.ImageUrl = "../App_Themes/no_avatar.gif"
                End If

            Next
        Next
    End Sub

    Protected Sub repeater2_databound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim itm As RepeaterItem = e.Item
        'Dim lblimg As String = DirectCast(itm.FindControl("lblimg"), Label).ToString()
        Dim url As String = TryCast(DataBinder.Eval(itm.DataItem, "photo"), String)

        If (url <> "" Or url IsNot Nothing) Then
            Dim img As Image = DirectCast(itm.FindControl("imgstart"), Image)
            If img IsNot Nothing Then
                If File.Exists(Server.MapPath("../App_Themes/" & url)) Then
                    img.ImageUrl = "../App_Themes/" & url
                Else
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If

            End If
        End If
        If (url = "" Or url Is Nothing) Then
            Dim img As Image = DirectCast(itm.FindControl("imgstart"), Image)
            If img IsNot Nothing Then
                img.ImageUrl = "../App_Themes/no_avatar.gif"
            End If
        End If


    End Sub
End Class
