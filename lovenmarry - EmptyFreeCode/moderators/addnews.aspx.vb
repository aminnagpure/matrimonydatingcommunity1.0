Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_addnews
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim pid As Integer = 0
        Dim regmsg As String = ""
        Dim rzlt As String = ""
        Dim ipadd As String = ""
        Dim doubtfulprofile As String = "Y"
        Dim ipcountry As String = ""
        Dim startedby As String = ""

        sql = "insert into news(newsheadline,newscontent,website)"
        sql = sql & " values(@newsheadline,@newscontent,@website) Select @@IDENTITY"


        'Response.Write(sql)
        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        txtnewscontent.Text = Replace(txtnewscontent.Text, vbCrLf, "<br>")
        Try
            startedby = Session("fname")

            cmd.Connection = cn
            cmd.CommandText = sql


            cmd.Parameters.AddWithValue("@newsheadline", txtheadlines.Text)
            cmd.Parameters.AddWithValue("@newscontent", txtnewscontent.Text)
            cmd.Parameters.AddWithValue("@website", txtwebsite.Text)

            pid = cmd.ExecuteScalar()


            cn.Close()

            If Session("fname") Is Nothing Then
                Session("fname") = cf.getCandiName(Session("pid"))
            ElseIf Session("fname") = "" Then
                Session("fname") = cf.getCandiName(Session("pid"))
            End If
            insertUpdateActivity(pid, Session("fname"))

            Button1.Text = "news posted"
            txtheadlines.Text = ""
            txtnewscontent.Text = ""
            txtwebsite.Text = ""
        Catch ex As Exception
            cn.Close()
            Response.Write(ex.ToString)
        End Try

    End Sub
    Sub insertUpdateActivity(ByVal id As Integer, ByVal fn As String)
        Dim Subject As String = txtheadlines.Text
        If Subject.Length > 40 Then
            Subject = Subject.Substring(0, 35)
            Subject = Subject.Substring(0, 35) & "..."
        End If

        Dim act As New SiteAcitvity
        act.candiid = Session("pid")
        act.fn = fn
        act.activitydate = Date.Now
        Dim str As String = ""
        str = "<div><table>"
        str = str & "<tr><td>"
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has Posted a Love Artical <a href='http://" & cf.websitename & "/news/viewnews.aspx?id=" & id & "'>" & Subject & "</a>"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "Artical"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub
End Class
