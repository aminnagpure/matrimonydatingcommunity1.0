Imports System.Data
Imports System.Data.SqlClient

Partial Class moderators_insertSubCategory
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadCategory()
        End If
    End Sub
    Sub loadCategory()
        Try


            Dim strsql As String = ""

            Dim dt As DataTable

            strsql = "select forumcatid,forumcategoryn from forumcategory"

            Cache.Remove("forumct")

            If Cache("forumct") Is Nothing Then
                Dim connectionString As String = cf.friendshipdb

                Dim accessConnection As SqlConnection = New SqlConnection(connectionString)

                Dim accessCommand As New SqlCommand(strsql, accessConnection)

                Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)
                Dim publishersDataTable As New DataTable("forumct")
                publishersDataAdapter.Fill(publishersDataTable)

                Cache.Insert("forumct", publishersDataTable, Nothing, DateTime.MaxValue, TimeSpan.FromMinutes(50))
                accessConnection.Close()
            End If

            dt = CType(Me.Cache("forumct"), DataTable)
            DropDownList1.DataSource = dt
            DropDownList1.DataValueField = "forumcatid"
            DropDownList1.DataTextField = "forumcategoryn"
            DropDownList1.DataBind()

           

        Catch ex As Exception
            Response.Write(ex.ToString)


        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt As String = ""
        Dim ipadd As String = ""
        Dim doubtfulprofile As String = "Y"
        Dim ipcountry As String = ""




        sql = "insert into forumtopics(forumcatid,forumtitle,topicsdescription)"
        sql = sql & " values(@forumcatid,@forumtitle,@topicsdescription)"

        'Response.Write(sql)
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try
            'Session("pid") = "23434"

            cmd.Connection = cn
            cmd.CommandText = sql

            cmd.Parameters.AddWithValue("@forumcatid", DropDownList1.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@forumtitle", TextBox1.Text)
            cmd.Parameters.AddWithValue("@topicsdescription", TextBox2.Text)
            cmd.ExecuteNonQuery()


            cn.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            tdmsg.InnerHtml = "Record Saved"

        Catch ex As Exception
            cn.Close()
            Response.Write(ex.ToString)
        End Try

    End Sub
End Class
