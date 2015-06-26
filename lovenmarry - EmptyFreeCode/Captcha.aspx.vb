Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Imaging

Partial Class Captcha
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objBMP As Bitmap = New Bitmap(160, 61)
        'Create Graphics object and assign bitmap object to graphics' object.
        Dim objGraphics As Graphics = Graphics.FromImage(objBMP)
        objGraphics.Clear(Color.Brown)
        objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias
        Dim objFont As Font = New Font("arial", 40, FontStyle.Regular)
        'genetating random 6 digit random number
        Dim randomStr As String = GeneratePassword()
        'set this random number in session
        Session.Add("Captchastr", randomStr)
        objGraphics.DrawString(randomStr, objFont, Brushes.White, 2, 2)
        Response.ContentType = "image/GIF"
        objBMP.Save(Response.OutputStream, ImageFormat.Gif)
        objFont.Dispose()
        objGraphics.Dispose()
        objBMP.Dispose()
    End Sub
    Public Function GeneratePassword() As String
        ' Below code describes how to create random numbers.some of the digits and letters
        ' are ommited because they look same like "i","o","1","0","I","O".
        Dim allowedChars As String = ""

        allowedChars += "2,3,4,5,6,7,8,9"
        Dim sep() As Char = {","c}
        Dim arr() As String = allowedChars.Split(sep)
        Dim passwordString As String = ""
        Dim temp As String
        Dim rand As Random = New Random()
        Dim i As Integer
        For i = 0 To 4 - 1 Step i + 1
            temp = arr(rand.Next(0, arr.Length))
            passwordString += temp
        Next
        Return passwordString
    End Function
End Class
