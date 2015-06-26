Imports System.Data
Imports System.Data.SqlClient


Partial Class members_runalert
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    



    


    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If Page.IsPostBack = True Then
        ' searchresults.Visible = True
        ' searchform.Visible = False
        If Request.QueryString("alid") <> "" Then
            If Page.IsPostBack = False Then
                'PopulatePublishersGridView()
                makequery()
            End If
        Else
            Label1.Text = "Alert id not found"
        End If
        'Else

        ' searchresults.Visible = False
        ' searchform.Visible = True
        ' End If


    End Sub
    Function makequery() As String
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select query,jointype from alert where candiid=@pid and searchno=@searchno"
        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = Session("pid")
        cmd.Parameters.Add("@searchno", SqlDbType.VarChar).Value = Request.QueryString("alid").ToString

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                'kk = myreader.GetString(0).ToString
                TextBox1.Text = myreader.GetString(0).ToString
                txtjointype.Text = myreader.GetString(1).ToString
            End While

            
            Return kk
        Else
            Return "no such alert found"
        End If

        
        cn.Close()

    End Function

    Protected Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridview1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photoname"), String)

            If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/Thumbs/" & url
                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/no_avatar.gif"
                End If
            End If

            If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
                End If
            End If


        End If
    End Sub

  
    
  
End Class
