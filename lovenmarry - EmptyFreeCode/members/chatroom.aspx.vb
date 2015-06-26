
Partial Class members_chatroom
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim kk As String
        'kk = ""

        'Dim photo As String = "no_avatar.gif"




        'If (Not String.IsNullOrEmpty(Session("fname").ToString)) Then
        '    If (Not Request.Cookies("Photo").Value = "N") Then
        '        photo = Request.Cookies("Photo").Value

        '    End If
        '    'imgphot.Value = photo
        '    kk = Session("fname").ToString
        'Else
        '    Response.Redirect("~/login.aspx")
        'End If

        'nameInput.Value = kk
        'hdPhtoname.Value = "<img src='../App_Themes/" & photo & "' width='30px'/>"
    End Sub
End Class
