Imports System.IO
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Imaging

Partial Class get_Image_url_
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim imagename As String = ""
            Dim size As String = ""
            Try
                imagename = Request.QueryString("image")
                size = Request.QueryString("size")
            Catch ex As Exception

            End Try
            If size IsNot Nothing Then
                If size.ToLower = "thumb" Then
                    If File.Exists(Server.MapPath("App_Themes/Thumbs/" & imagename)) Then
                        Dim objBMP2 As Bitmap = New Bitmap(Server.MapPath("App_Themes/Thumbs/" & imagename))
                        Response.ContentType = "image/GIF"
                        objBMP2.Save(Response.OutputStream, ImageFormat.Gif)
                        objBMP2.Dispose()
                        Response.End()

                    End If
                    'ElseIf IsNumeric(size) Then
                    '    If File.Exists(Server.MapPath("App_Themes/" & imagename)) Then
                    '        Dim H As Integer = Convert.ToInt32(size)
                    '        Dim bm_source As New Bitmap(Server.MapPath("App_Themes/" & imagename))
                    '        Dim resc As New Drawing.RectangleF(0, 0, H, H)
                    '        Dim v As New Bitmap =bm_source.Clone(resc, ImageFormat.Gif)

                    '        Response.ContentType = "image/GIF"
                    '        bm_source.Save(Response.OutputStream, ImageFormat.Gif)
                    '        bm_source.Dispose()
                    '        Response.End()

                End If
            End If

            If File.Exists(Server.MapPath("App_Themes/" & imagename)) Then
                Dim objBMP1 As Bitmap = New Bitmap(Server.MapPath("App_Themes/" & imagename))
                Response.ContentType = "image/GIF"
                objBMP1.Save(Response.OutputStream, ImageFormat.Gif)
                objBMP1.Dispose()
                Response.End()
            Else
                GoTo noImage
            End If



            Exit Sub
noImage:
            Dim objBMP As Bitmap = New Bitmap(Server.MapPath("App_Themes/avatar.gif"))
            Response.ContentType = "image/GIF"
            objBMP.Save(Response.OutputStream, ImageFormat.Gif)
            objBMP.Dispose()
            Response.End()

        End If
    End Sub
    
End Class
