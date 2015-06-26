Imports System.Data
Imports System.Data.SqlClient

Partial Class Forums_forumcat
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            fillforumcategory()
        End If
    End Sub
    Sub fillforumcategory()
        Dim tbl As String = ""
        Dim tbl1 As String = ""
        Try


            Dim strsql As String = ""
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim myreader As SqlDataReader
            Dim forumtopid As String = ""
            Dim forumtitle As String = ""
            Dim lastupdate As String = ""
            Dim updatedby As String = ""
            Dim startedby As String = ""
            Dim updatebyid As String = ""
            Dim startedbyid As String = ""
            Dim forumcatid As String = ""
            Dim topicsdescription As String = ""

            cn.ConnectionString = cf.friendshipdb
            cn.Open()
            '// view categories
            strsql = "viewcats " & Request.QueryString("id")

            cmd.CommandText = strsql
            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    forumtopid = myreader.GetValue(0)
                    forumtitle = myreader.GetValue(1)
                    lastupdate = myreader.GetValue(2)
                    updatedby = myreader.GetValue(3)
                    startedby = myreader.GetValue(4)
                    updatebyid = myreader.GetValue(5)
                    startedbyid = myreader.GetValue(6)
                    forumcatid = myreader.GetValue(7)
                    topicsdescription = myreader.GetValue(8)

                    tbl1 = tbl1 & "<tr><td><a href=topics.aspx?id=" & forumtopid & "&mc=" & Request.QueryString("id") & ">" & forumtitle & "</a> <br>" & topicsdescription & "<br><br> </td><td>" & startedby & " </tD</tr>"

                End While

            End If
            tbl = "<table>" & tbl1 & "</table>"
            forumcat.InnerHtml = tbl



            myreader.Close()
            cmd.dispose()
            cn.close()

        Catch ex As Exception
            Response.Write(ex.ToString)


        End Try

    End Sub
End Class
