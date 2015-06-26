Imports System.Data
Imports System.Data.SqlClient

Partial Class moderators_addquotes
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub btnshare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnshare.Click
        Dim strupdate As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        strupdate = "insert into tblquotes(quote) values(@quote)"
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try


            cmd.Connection = cn
            cmd.CommandText = strupdate
            cmd.Parameters.AddWithValue("@quote", txtshare.Text)
            cmd.ExecuteNonQuery()

            txtshare.Text = ""
        Catch ex As Exception
            cn.Close()
        End Try

    End Sub
    Protected Sub cusCustom_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cusCustom.ServerValidate
        If (args.Value.Length >= 8) Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If

    End Sub
End Class
