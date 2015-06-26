Imports System.Data
Imports System.Data.SqlClient
Partial Class Forums_deleteSubgroup
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Not (Request.QueryString("id") Is Nothing) Then
                deleteSubgroup(Request.QueryString("id"))
                TD1.InnerHtml = "Deleted Sucessfully"
            End If
        End If

    End Sub
    Sub deleteSubgroup(ByVal str As String)
        Dim cmd As New SqlCommand("usp_DeleteSubGroup_Forum")
        cf.ExecuteNonQuery(cmd)
    End Sub
End Class
