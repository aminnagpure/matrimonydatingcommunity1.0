
Partial Class contactus
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblstatus.Text = ""

        If Session("Captchastr") <> txtCaptcha.Text Then
            lblstatus.Text = "Code Does not Match, Try Again! "

            Exit Sub
        Else
            lblstatus.Text = ""
        End If
        Dim cf As New comonfunctions
        Dim ipadd As String = ""
        Dim ipcountry As String = ""
        Dim content As String = ""

        Try
            ipadd = getip()
            ipcountry = cf.gethiscountrybyip(ipadd)
            content = "mail from " & txtname.Text & "<br>email " & txtemail.Text & "<br><br>Sub: " & txtSub.Text.Trim & "<br />" & txtcomments.Text.Replace(ControlChars.Lf, "<br />")
            content = content & "<br><br> from ipaddress " & ipadd & " <br> ipcountry" & ipcountry
            lblstatus.Text = cf.send25("contactus", "Email from " & cf.websitename, "aminnagpure@gmail.com", content)
            txtcomments.Text = ""
            txtSub.Text = ""
            txtemail.Text = ""
            txtname.Text = ""
        Catch ex As Exception
            lblstatus.Text = ex.ToString
        End Try
    End Sub
    Function getip() As String
        Dim ip As String = ""
        ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If Not String.IsNullOrEmpty(ip) Then
            Dim ipRange As String() = ip.Split(","c)
            Dim le As Integer = ipRange.Length - 1
            Dim trueIP As String = ipRange(le)
        Else
            ip = Request.ServerVariables("REMOTE_ADDR")
        End If
        getip = ip

    End Function
End Class
