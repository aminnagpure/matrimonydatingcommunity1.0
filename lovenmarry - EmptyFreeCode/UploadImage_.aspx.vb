Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Partial Class UploadImage_
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Shared pid As Integer = 0
    Dim Mainphoto As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        'Response.Cookies("photo").Value = "Y"
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""
        Dim mcount As Integer = 0

        Try
            pid = Convert.ToInt32(Request.QueryString("id"))
        Catch ex As Exception

        End Try
        If pid = 0 Then
            Response.Write("Something is wrong")
            Response.End()
            Exit Sub
        End If
        Dim us As Integer = cf.ExecuteScalar("select count(*) from [profile] where pid=" & pid, cf.friendshipdb)
        If us = 0 Then
            Response.Write("Something is wrong")
            Response.End()
            Exit Sub
        End If
        strsql = "select count(*) from photo where pid=" & pid & ""
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        If myreader.HasRows = True Then
            While myreader.Read
                mcount = myreader.GetValue(0)
            End While
        End If

        If mcount >= 15 Then
            upimage.Text = "You Can only Upload 15 Photos"
            upimage.Enabled = False
        End If

        If mcount = 0 Then
            Mainphoto = "Y"
        Else
            Mainphoto = "N"
        End If

        cn.Close()
    End Sub

    Protected Sub upimage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles upimage.Click
        Dim msg As String = ""
        Dim filecopy As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 0

        If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then

            'Dim fn As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim ext As String = ""
            ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)

            Dim SaveLocation As String = Server.MapPath("App_Themes") & "\"
            Try

                If (FileUpload1.PostedFile.ContentType = "image/gif" Or FileUpload1.PostedFile.ContentType = "image/pjpeg" Or FileUpload1.PostedFile.ContentType = "image/jpeg" Or FileUpload1.PostedFile.ContentType = "image/png" Or FileUpload1.PostedFile.ContentType = "image/bmp" Or FileUpload1.PostedFile.ContentType = "image/bitmap" Or FileUpload1.PostedFile.ContentType = "image/jpg" Or FileUpload1.PostedFile.ContentType = "image/tiff") Then

                    msg = addentry(ext)
                    SaveLocation = SaveLocation & msg & "11" & ext
                    filecopy = Server.MapPath("App_Themes") & "\" & msg & ext

                    FileUpload1.PostedFile.SaveAs(SaveLocation)

                    '  watermark(SaveLocation, "aminnn")
                    '  Response.Write("The file has been uploaded.")


                    Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(SaveLocation)
                    'From File
                    Dim height As Integer = objImage.Height
                    'Actual image width
                    Dim width As Integer = objImage.Width
                    'Actual image height
                    If (height >= 500) Then
                        height = 500
                    Else
                        height = height
                    End If
                    If (width >= 450) Then
                        width = 450
                    Else
                        width = width
                    End If

                    Dim bitmapimage As New System.Drawing.Bitmap(objImage, width, height)
                    ' create bitmap with same size of Actual image
                    Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmapimage)
                    'Creates a System.Drawing.Color structure from the four ARGB component
                    '(alpha, red, green, and blue) values. Although this method allows a 32-bit value
                    ' to be passed for each component, the value of each component is limited to 8 bits.
                    'create Brush
                    Dim brush As New SolidBrush(Color.FromArgb(113, 255, 255, 255))

                    x = 10
                    y = objImage.Height / 2
                    'Adding watermark text on image
                    'g.DrawRectangle(Pens.Blue, x, y)
                    'g.Clear(Color.Green)

                    g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
                    g.DrawString(cf.websitename, New Font("Arial", 18, System.Drawing.FontStyle.Bold), brush, x, y)

                    g.DrawString(cf.websitename, New Font("Arial", 18, System.Drawing.FontStyle.Bold), brush, 100, y + 80)

                    'save image with Watermark image/picture
                    'bitmapimage.Save("watermark-image.jpg"); //if u want to save image

                    'Response.ContentType = "image/jpeg"
                    bitmapimage.Save(filecopy, ImageFormat.Jpeg)
                    bitmapimage.Dispose()
                    objImage.Dispose()

                    File.Delete(SaveLocation)

                    uploadimagesThumb(msg & ext)

                    'Label1.Text = "Photo Uploaded"
                    'response.ContentType=
                    TD1.InnerHtml = "<font color='red'>Photo Uploaded Sucessfully </font>"
                Else
                    'Response.Write("file is not an image")
                    Response.Write("<br>file is " & FileUpload1.PostedFile.ContentType)
                End If
            Catch Exc As Exception
                Response.Write("Error: " & Exc.Message)
            End Try
        Else
            Response.Write("Please select a file to upload.")
        End If


    End Sub


    Sub uploadimagesThumb(ByVal imagename As String)
        Dim msg As String = ""
        Dim filecopy As String = ""
        Dim x As Integer = 0
        Dim y As Integer = 0

        'Dim fn As String = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim ext As String = imagename.Substring((imagename.IndexOf(".")))
        msg = imagename.Substring(0, (imagename.IndexOf(".")))

        Dim SaveLocation As String = Server.MapPath("App_Themes\Thumbs") & "\"
        If Not Directory.Exists(SaveLocation) Then
            Directory.CreateDirectory(SaveLocation)
        End If
        Dim ImgLocation As String = Server.MapPath("App_Themes") & "\" & imagename
        Try
            SaveLocation = SaveLocation & msg & ext
            Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(ImgLocation)
            'From File
            Dim height As Integer = objImage.Height
            'Actual image width
            Dim width As Integer = objImage.Width
            'Actual image height
            Dim bitmapimage As New System.Drawing.Bitmap(objImage, 100, 80)
            ' create bitmap with same size of Actual image

            bitmapimage.Save(SaveLocation, ImageFormat.Jpeg)
            bitmapimage.Dispose()
            objImage.Dispose()
            'TD1.InnerHtml = "<font color='red'>Photo Uploaded Sucessfully </font>"
        Catch Exc As Exception
            Response.Write("Error: " & Exc.Message)
        End Try

    End Sub

    Function addentry(ByVal ext1 As String) As String
        Dim uid As String = ""

        Dim strfield As String = ""
        Dim strvalues As String = ""
        Dim strsql As String = ""
        Dim passw As String = ""
        Dim sql As String = ""


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim photoid As String = ""
        Dim photoname As String = ""
        Dim kk As String = ""

        Dim myreader As SqlDataReader

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        strsql = "select passw from photo where pid=" & pid & " and (passw<>'' and passw is not null)"
        cmd2.Connection = cn
        cmd2.CommandText = strsql
        myreader = cmd2.ExecuteReader

        While myreader.Read
            passw = myreader.GetValue(0).ToString
        End While

        myreader.Close()



        uid = cf.generateid





        strfield = " insert into photo(photoname,pid,passw,mainphoto)"
        strvalues = " values(@photoname,@candiid,@passw,@mainphoto)"

        strsql = strfield & strvalues


        cmd.Parameters.AddWithValue("@photoname", uid & ext1)
        cmd.Parameters.AddWithValue("@candiid", pid)
        cmd.Parameters.AddWithValue("@passw", passw)
        cmd.Parameters.AddWithValue("@mainphoto", Mainphoto)

        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.ExecuteNonQuery()
        cn.Close()

        If Mainphoto = "Y" Then
            sql = "update Profile set photo='" & uid & ext1 & "',photopassw='" & passw & "' where pid=" & pid & ""
            'Response.Write(sql)

            kk = cf.TaskmembSql(sql)
            'kk = cf.TaskCvsearch(sql)
        End If


        addentry = uid


    End Function


End Class
