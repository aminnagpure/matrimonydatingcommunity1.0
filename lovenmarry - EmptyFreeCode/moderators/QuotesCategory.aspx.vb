Imports System.Data
Imports System.Data.SqlClient
Partial Class moderators_QuotesCategory
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim pid As String = ""
        Dim kk As String = ""
        Dim ipadd As String = ""

        Try

            If check() = False Then
                cn.ConnectionString = cf.friendshipdb
                cn.Open()
                cmd.Connection = cn
                cmd.CommandTimeout = 5000
                sql = "insert into Quotescatmaster([category]) values(ltrim(rtrim(@cat)))"
                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@cat", TextBox1.Text)

                kk = cmd.ExecuteNonQuery()


                cn.Close()
                If kk = "1" Then
                    Button1.Enabled = False
                    Button1.Text = "Category Added Sucessfully"
                    TextBox1.Text = ""
                End If
            End If

        Catch ex As Exception
            Response.Write(ex.Message)
            cn.Close()
        End Try
    End Sub
    Function check() As Boolean
        Dim sql As String = ""
        Dim rtn As Integer = 0
        Label1.Text = ""
        sql = "select count(*) from Quotescatmaster where [category]='" & TextBox1.Text & "'"
        rtn = cf.MemberCount(sql)
        If rtn = 0 Then
            Return False

        Else
            Label1.Text = "Category Already There"
            Return True
        End If

    End Function
End Class
