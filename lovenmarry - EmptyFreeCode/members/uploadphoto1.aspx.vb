Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Data.SqlClient



Partial Class members_uploadphoto
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Response.Write(Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Millisecond)
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""
        Dim mcount As Integer = 0

        strsql = "select count(*) from photo where pid=" & Session("pid") & ""
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

        If mcount >= 5 Then
            upimage.Text = "You Can only Upload 5 Photos"
            upimage.Enabled = False
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

            Dim SaveLocation As String = Server.MapPath("..\App_Themes") & "\"
            Try

                If (FileUpload1.PostedFile.ContentType = "image/gif" Or FileUpload1.PostedFile.ContentType = "image/pjpeg" Or FileUpload1.PostedFile.ContentType = "image/jpeg" Or FileUpload1.PostedFile.ContentType = "image/png" Or FileUpload1.PostedFile.ContentType = "image/bmp" Or FileUpload1.PostedFile.ContentType = "image/bitmap" Or FileUpload1.PostedFile.ContentType = "image/jpg" Or FileUpload1.PostedFile.ContentType = "image/tiff") Then

                    msg = addentry(ext)
                    SaveLocation = SaveLocation & msg & "11" & ext
                    filecopy = Server.MapPath("..\App_Themes") & "\" & msg & ext

                    FileUpload1.PostedFile.SaveAs(SaveLocation)

                    '  watermark(SaveLocation, "aminnn")
                    '  Response.Write("The file has been uploaded.")


                    Dim objImage As System.Drawing.Image = System.Drawing.Image.FromFile(SaveLocation)
                    'From File
                    Dim height As Integer = objImage.Height
                    'Actual image width
                    Dim width As Integer = objImage.Width
                    'Actual image height
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
                    bitmapimage.Save(filecopy)
                    bitmapimage.Dispose()
                    objImage.Dispose()

                    File.Delete(SaveLocation)
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

    Function addentry(ByVal ext1 As String) As String
        Dim uid As String = ""

        Dim strfield As String = ""
        Dim strvalues As String = ""
        Dim strsql As String = ""
        Dim passw As String = ""


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand

        Dim photoid As String = ""
        Dim photoname As String = ""

        Dim myreader As SqlDataReader

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        strsql = "select passw from photo where pid=" & Session("pid") & " and (passw<>'' and passw is not null)"
        cmd2.Connection = cn
        cmd2.CommandText = strsql
        myreader = cmd2.ExecuteReader

        While myreader.Read
            passw = myreader.GetValue(0).ToString
        End While

        myreader.Close()

        

        uid = Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Millisecond





        strfield = " insert into photo(photoname,pid,passw)"
        strvalues = " values(@photoname,@pid,@passw)"

        strsql = strfield & strvalues


        cmd.Parameters.AddWithValue("@photoname", uid & ext1)
        cmd.Parameters.AddWithValue("@pid", Session("pid"))
        cmd.Parameters.AddWithValue("@passw", passw)

        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.ExecuteNonQuery()

        addentry = uid
        cn.Close()

    End Function

   
    
    

End Class
