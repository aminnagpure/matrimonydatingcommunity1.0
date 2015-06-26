Imports System.Data
Imports System.Data.SqlClient
Partial Class canvas_Default
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write(ffbookfun())
    End Sub
    Function ffbookfun() As String
        Dim FBAppID As String, FBSecret As String
        FBAppID = "404461319606517"
        FBSecret = "2b345694dc30de1f7cc49756b8ccccd2"

        Dim FBCookie = HttpContext.Current.Request.Cookies("fbs_" + FBAppID)
        If FBCookie Is Nothing Then
            Return ""

        End If

        Dim FBCookieString As String = FBCookie.Value.ToString
        FBCookieString = FBCookieString.Substring(1, FBCookieString.Length - 2) 'remove the quotes at the beginning and end
        Dim Sig As String = ""
        Dim UserID As String = ""
        Dim Payload = ""
        For Each FBKey In FBCookieString.Split("&")
            Dim EqPos As Integer = FBKey.IndexOf("=")
            Dim Key As String = FBKey.Substring(0, EqPos)
            Dim Value = HttpContext.Current.Server.UrlDecode(FBKey.Substring(EqPos + 1))
            If Key = "sig" Then Sig = Value Else Payload += HttpContext.Current.Server.UrlDecode(FBKey)
            If Key = "uid" Then UserID = Value
        Next
        If Sig <> "" Then
            If Sig.ToUpper <> System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Payload + FBSecret, "MD5") Then
                Return ""
            Else
                Return UserID.ToString()
            End If
        End If
    End Function
End Class
