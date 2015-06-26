Imports System.Data
Imports System.Data.SqlClient

Partial Class pole_CreateQue
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("pid") Is Nothing Or Session("pid") = "") Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
        If Session("pid") = 0 Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
        If Not Page.IsPostBack Then
            BindQue()
        End If
    End Sub


    Protected Sub ddloption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddloption.SelectedIndexChanged

        Dim dtText As New DataTable
        Dim drow As DataRow

        dtText.Columns.Add("SNo")

        Dim icount As Integer = 0
        If (ddloption.SelectedIndex > 0) Then
            icount = Convert.ToInt32(ddloption.SelectedValue)
        End If

        Dim iTxt As Integer
        For iTxt = 0 To icount - 1
            drow = dtText.NewRow
            drow(0) = (iTxt + 1).ToString
            dtText.Rows.Add(drow)
        Next

        gvOption.DataSource = dtText
        gvOption.DataBind()



        'If (ddloption.SelectedIndex > 0) Then

        '    trOptAns.Visible = True

        'Else
        '    trOptAns.Visible = False

        'End If


    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim strq As String = ""
        Dim strcorrectOp As String = ""
        Dim strop As String = ""
        Dim strtextOp As String = ""
        Dim strResult As String = ""

        strq = txtQue.Text.ToString().Trim().Replace("\r\n", "<br>")


        If (btnSubmit.Text = "Submit") Then

            strop = ddloption.SelectedValue.ToString()
            'Dim txt As TextBox


            'If (rbtnQ1.Checked = True) Then
            '    strcorrectOp = "Option1"

            '    'txt = DirectCast(gvOption.Rows(0).FindControl("txttext"), TextBox)
            '    'strcorrectOp = txt.Text

            'ElseIf (rbtnQ2.Checked = True) Then
            '    strcorrectOp = "Option2"

            '    'txt = DirectCast(gvOption.Rows(1).FindControl("txttext"), TextBox)
            '    'strcorrectOp = txt.Text

            'ElseIf (rbtnQ3.Checked = True) Then
            '    strcorrectOp = "Option3"
            '    'txt = DirectCast(gvOption.Rows(2).FindControl("txttext"), TextBox)
            '    'strcorrectOp = txt.Text

            'ElseIf (rbtnQ4.Checked = True) Then
            '    strcorrectOp = "Option4"

            '    'txt = DirectCast(gvOption.Rows(3).FindControl("txttext"), TextBox)
            '    'strcorrectOp = txt.Text
            'ElseIf (rbtnQ5.Checked = True) Then
            '    strcorrectOp = "Option5"

            'ElseIf (rbtnQ6.Checked = True) Then
            '    strcorrectOp = "Option6"


            'End If



            'code for executive master table
            'to write below function
            'cf.executivemethod() like
            Dim con As New SqlConnection
            'Dim strmaster1 As String
            'Dim strmaster2 As String
            'Dim strmaster3 As String
            Dim cmd As New SqlCommand

            con.ConnectionString = cf.friendshipdb
            con.Open()

            'generate Question id
            'Dim strqidcount As String = ""
            Dim strqueid As String = ""

            cmd.CommandText = "Usp_AddPoll_Question"


            cmd.Parameters.AddWithValue("@strq", strq.Trim)
            cmd.Parameters.AddWithValue("@strop", strop)
            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@CDate", Date.Now)

            Dim ds As New DataSet
            ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
            strqueid = ds.Tables(0).Rows(0)(0).ToString
            '      Insert Into  Quiz_tblQsnCreationMaster (QuestionId, QsnDesc, NoOfOptions, CorrectOption,  Marks, CreationloginId)    
            '      Values (@RefID, @QsnDesc, @NoOfOptions, @CorrectOption,  @Marks, @CreationloginId)

            'code for insert detail record (option)in table
            Dim i As Integer
            Dim strdetail As String = ""
            For i = 0 To gvOption.Rows.Count - 1
                strtextOp = DirectCast(gvOption.Rows(i).FindControl("txttext"), TextBox).Text.ToString()
                strdetail = "Insert Into  pole_Que_CreateDetail (QuestionId, optionorder, OptionValue, CreationloginId) Values(@strqueid, '" & i + 1 & "', @strtextOp,@Role)"
                Dim dcmd As New SqlCommand(strdetail, con)
                dcmd.Parameters.AddWithValue("@strqueid", strqueid)
                dcmd.Parameters.AddWithValue("@strtextOp", strtextOp.Trim)
                dcmd.Parameters.AddWithValue("@Role", Session("pid"))
                dcmd.ExecuteNonQuery()
            Next
            insertUpdateActivity(strqueid, Session("fname"))
            'insertsiteActivity(strqueid)
            txtQue.Text = ""
            'txtmark.Text = ""
            ddloption.SelectedIndex = -1
            'trOptAns.Visible = False
            ' trgrid.Visible = False
            BindQue()

            Response.Redirect("CreateQue.aspx")
        End If

    End Sub
    
    Public Sub BindQue()
        TextBox1.Text = " pole_Que_CreateMaster.CreationloginId=" & Session("pid")
        'Dim con As New SqlConnection
        'Dim dt As DataTable = New DataTable

        'con.ConnectionString = cf.conpatahai
        'Dim strq As String = ""
        Dim mrol As String = ""
        If Session("mrole") IsNot Nothing Then
            mrol = Session("mrole")
        End If

        If Not (mrol = "") Then
            HyperLink1.Visible = True
            If Request.QueryString("view") = "All" Then
                TextBox1.Text = " 1=1"
                HyperLink1.Text = "View My Poll Question"
                HyperLink1.NavigateUrl = "CreateQue.aspx"
                HyperLink1.Width = 175
            End If
        End If


        ''Dim cmd As New SqlCommand(strq)
        'Dim da As SqlDataAdapter = New SqlDataAdapter(strq, con)

        'da.Fill(dt)

        'GridView1.DataSource = dt
        'GridView1.DataBind()


    End Sub

    Function executiveRdatatable(ByVal str As String) As DataTable
        Dim con As New SqlConnection
        Dim dt As DataTable = New DataTable

        con.ConnectionString = cf.friendshipdb

        Dim da As SqlDataAdapter = New SqlDataAdapter(str, con)
        da.Fill(dt)

        Return dt

    End Function


    Protected Sub OnDelete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        'If e.CommandName.Equals("Rdelete") Then
        Try
            Dim strid As String = e.CommandArgument.ToString()
            Dim strmq As String
            Dim strdq As Integer = strid
            strmq = strid
            DeleteQuestion(strmq)

            'strdq = "delete from pole_Que_CreateMaster where  sno='" & strid & "'"
            'DeleteQuestion(strdq)

            Response.Redirect("CreateQue.aspx")
            'DeleteNews(strid)
            'Deletecomments(strid)
        Catch ex As Exception

        End Try
        'End If
    End Sub

    Protected Sub DeleteQuestion(ByVal str As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "Del_Poll_Ques"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Pid", str)
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            'Response.Redirect("viewnews.aspx?id=" & Request.QueryString("id"))
            ' Label1.Text = "Post Deleted Succesfully"
        Else
            'Response.Redirect("totalunapproveads.aspx")
            ' Label1.Text = "Post not Found"
        End If
        cmd.Dispose()
        cn.Close()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        Dim btuDel As New LinkButton
        btuDel = DirectCast(e.Row.FindControl("lnkdel"), LinkButton)
        If Not (btuDel Is Nothing) Then
            Dim str As Integer = 0
            str = DataBinder.Eval(e.Row.DataItem, "CreationloginId")
            Dim mrol As String = ""
            If Session("mrole") IsNot Nothing Then
                mrol = Session("mrole")
            End If

            If ((mrol = "mod") Or (Session("pid") = str)) Then
                If (Session("pid") Is Nothing) Then
                    btuDel.Visible = False

                Else
                    btuDel.Visible = True
                End If
            Else
                btuDel.Visible = False
            End If
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Delete" Then
            Try
                Dim strid As String = e.CommandArgument.ToString()



                DeleteQuestion(strid)




                Response.Redirect("CreateQue.aspx")
                'DeleteNews(strid)
                'Deletecomments(strid)
            Catch ex As Exception

            End Try
        End If

    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Default.aspx")
    End Sub
    Sub insertUpdateActivity(ByVal id As Integer, ByVal fn As String)
        Dim Subject As String = txtQue.Text
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
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> has Posted a Poll Question <a href='http://" & cf.websitename & "/poll/polet.aspx?id=" & id & "'>" & Subject & "</a>"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "Poll"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub
End Class
