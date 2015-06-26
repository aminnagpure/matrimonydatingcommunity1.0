Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Partial Class JoinUs
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Sub loaddata()

        Dim pid As String = "0"
        Dim fname As String = "Amit"
        Dim lname As String = "Tiwari"

        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        'pid = Request.QueryString("affid")
        If Request.QueryString("affid") IsNot Nothing Then
            pid = Request.QueryString("affid").ToString
        End If
        tdimage.InnerHtml = "<img src='App_Themes/no_avatar.gif' width='100' height='100' >"

        cmd.CommandTimeout = 900
        cmd.CommandText = "viewprofile" '"select firstname,convert(varchar(10),dateofbirth,103) as dateofbirth,gender,countryname, statename, cityname, photoname, p.passw, aboutme,education,designation, companyname,TotalExp,mth,schoolname,photo,schoolyear,collename,colyear,profileheadline,companywebsite, allowprofilecomments, FrinedshipRequests, KnowsEmailCanAdd, emailAddress from candidatesRegistration c left join  photos p on c.candiid=p.candiid and p.mainphoto='Y'  where c.candiid=" & pid
        cmd.Parameters.AddWithValue("@pid", pid)
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
        If ds.Tables(0).Rows.Count > 0 Then
            fname = ds.Tables(0).Rows(0)("fname").ToString
            lname = ds.Tables(0).Rows(0)("lname").ToString



            If ds.Tables(0).Rows(0)("Photoname").ToString = "" Then
                tdimage.InnerHtml = "<img src='App_Themes/no_avatar.gif'>"
            Else
                If File.Exists(Server.MapPath("App_Themes/" & ds.Tables(0).Rows(0)("photoname").ToString)) Then
                    tdimage.InnerHtml = "<img width='100' height='100' src='App_Themes/" & ds.Tables(0).Rows(0)("photoname").ToString & "'>" '</a>"
                Else
                    tdimage.InnerHtml = "<img width='100' height='100' src='App_Themes/no_avatar.gif'>"
                End If

            End If
        End If
        Page.Title = "Join with me, All Cool People are Registered Here Come Join have fun"
        tdMsg.InnerHtml = "Hi friends, This is " & fname & " " & lname & " <br />I have register on yoursite.com. You can join me <a href='http://www.yoursite.com/PlusSignIn.aspx?affid=" & pid & "'>here</a>."
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loaddata()
        End If
    End Sub
End Class
