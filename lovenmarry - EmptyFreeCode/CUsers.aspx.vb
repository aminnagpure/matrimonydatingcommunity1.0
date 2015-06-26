
Partial Class CUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Application("Ids") IsNot Nothing Then
                'Response.Write(1 & "<br />")
                Dim Logins As IList(Of LoginIds) = New List(Of LoginIds)
                'Response.Write(2 & "<br />")
                Logins = Application("Ids")
                Response.Write(Logins.Count)
                'Dim i As Integer = 0
                For Each L As LoginIds In Logins
                    Response.Write("<a href=""viewprofile.aspx?pid=" & L.PID & """>" & L.PID & "</a> " & L.Fname & "<br />")
                    'i += 1
                    'Response.Write(i & "<br />")
                Next

            End If
        Catch ex As Exception
            'Dim Logins As IList(Of LoginIds) = New List(Of LoginIds)
            'Application("Ids") = Logins
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
