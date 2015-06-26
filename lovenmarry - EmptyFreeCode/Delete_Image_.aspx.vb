Imports System.IO

Partial Class Delete_Image_
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("Image") IsNot Nothing Then
            Response.Write(deletephoto(Request.QueryString("Image")))
            Response.End()
        End If
    End Sub
    Function deletephoto(ByVal photo As String) As String
        Dim imgfolder As String = ""
        imgfolder = Server.MapPath("App_Themes") & "\" & photo
        If File.Exists(imgfolder) Then
            File.Delete(imgfolder)
            imgfolder = Server.MapPath("App_Themes\Thumbs") & "\" & photo
            If File.Exists(imgfolder) Then
                File.Delete(imgfolder)
            End If
            Return "photo Deleted"
        Else
            Return "photo not Found"
        End If
    End Function
End Class
