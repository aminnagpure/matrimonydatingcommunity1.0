Imports System.Data
Imports System.Data.SqlClient

Partial Class pole_polet
    Inherits System.Web.UI.Page

    Dim cf As New comonfunctions
    Dim strqid As String
    Dim strsq As String
    Dim iRowCounter As Integer = 0
    Dim iCellCounter As Integer = 0
    Dim candiid As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("pid") IsNot Nothing Then candiid = Session("pid")
        If Session("pid") Is Nothing Then
            btnSubmit.Attributes.Add("onclick", "GoTo('../Login.aspx?ReturnUrl=" & Request.Url.AbsoluteUri & "')")
        End If
        If Not IsPostBack Then
            Dim oDs As DataSet
            If Not (Request.QueryString("id") Is Nothing) Then
                Try
                    If Request.QueryString("Act") <> "" And Request.QueryString("Act") IsNot Nothing Then
                        Response.Redirect("polet.aspx?id=" & Request.QueryString("id"))
                    End If

                Catch ex As Exception

                End Try

                oDs = executiveRdataset("select top 1 Sno, QsnDesc  from  pole_Que_CreateMaster where Sno=" & Request.QueryString("id") & " order by CreationDate desc")
            Else
                oDs = executiveRdataset("select top 1 Sno ,QsnDesc   from  pole_Que_CreateMaster  order by CreationDate desc")
            End If


            If (oDs.Tables(0).Rows.Count > 0) Then
                lblque.Text = oDs.Tables(0).Rows(0)("QsnDesc").ToString()
                Page.Title = oDs.Tables(0).Rows(0)("QsnDesc").ToString()
                lblqid.Text = oDs.Tables(0).Rows(0)(0).ToString()
                Dim rc As Integer
                Dim oDsRadio As New DataSet
                For rc = 0 To oDs.Tables(0).Rows.Count - 1
                    oDsRadio = executiveRdataset("select OptionValue  from pole_Que_CreateDetail where QuestionId=" & oDs.Tables(0).Rows(rc)(0).ToString() & "")
                Next
                rblist.DataSource = oDsRadio
                rblist.DataTextField = "OptionValue"
                rblist.DataValueField = "OptionValue"
                rblist.DataBind()
                TextBox1.Text = lblqid.Text

                Dim mrol As String = ""
                If Session("mrole") IsNot Nothing Then
                    mrol = Session("mrole")
                End If


                If mrol = "mod" Then
                    GridView1.Columns(0).Visible = True
                    btnDelete.Visible = True
                Else
                    GridView1.Columns(0).Visible = False
                    btnDelete.Visible = False
                End If

            Else
                divPoll.InnerHtml = "<div style='min-height:200px;padding:20px;'><br /><br /><span style='font-size:2em;'>WOOPS! </span><br /><span style='font-size:16px;'>Something is wrong or bad Url </span></div>"
            End If
            If Not (Request.QueryString("id") Is Nothing) Then

            End If
            If oDs.Tables(0).Rows.Count > 0 Then
                txtcriteria1.Text = " c.QueId=" & oDs.Tables(0).Rows(0)(0).ToString() & " "
            Else
                txtcriteria1.Text = " c.QueId=0"
            End If
            fillgrid()
            loaddetails()
            PollGraph.InnerHtml = CreateGraph()



        End If
        'disp()

    End Sub
    Sub loaddetails()
        Try
            Dim ds As DataSet
            Dim cmd As New SqlCommand
            cmd.CommandText = "usp_get_Polling_OtherDetails"
            cmd.Parameters.AddWithValue("@id", lblqid.Text)
            cmd.Parameters.AddWithValue("@Logid", candiid)
            ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
            If Not System.IO.File.Exists(Server.MapPath("../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(1).ToString)) Then
                tdmainimg.InnerHtml = "<a href='../members/viewprofile.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='../App_Themes/no_avatar.gif' style='height:150px;width:150px;border-width:0px;'></a><br>" & ds.Tables(0).Rows(0)(2).ToString
            Else

                tdmainimg.InnerHtml = "<a href='../members/viewprofile.aspx?pid=" & ds.Tables(0).Rows(0)(0).ToString & "'><img src='../App_Themes/Thumbs/" & ds.Tables(0).Rows(0)(1).ToString & "' style='height:150px;width:150px;border-width:0px;'></a><br>" & ds.Tables(0).Rows(0)(2).ToString
            End If
            UserMore.HRef = "Default.aspx?id=" & ds.Tables(0).Rows(0)(0).ToString
            GridView2.DataSource = ds.Tables(1)
            GridView2.DataBind()
            GridView3.DataSource = ds.Tables(3)
            GridView3.DataBind()
            If ds.Tables(2).Rows.Count > 0 Then
                Dim strrate As String = ""
                ' strrate = "<div >Current Rating: " & ds.Tables(2).Rows(0)(3) & "</div>"
                'Dim clas As String = "positive"
                'Dim Rate As Double = Convert.ToDouble(ds.Tables(2).Rows(0)(3))
                'If Rate <= 0 Then
                '    clas = "Negative"
                '    Rate = Rate * -1
                'End If
                'Dim oneImg As Double = 16.2
                'Dim width As Decimal = oneImg * Rate
                'strrate = "<div >Current Rating: <div title='" & cf.retWord(ds.Tables(2).Rows(0)(3)) & "' class='" & clas & " Poll_" & cf.retWord(ds.Tables(2).Rows(0)(3)) & "'>&nbsp;</div></div>"
                'strrate = "<div ><div style='float:left;'>Current Rating: </div><div style='width:" & width & "px;' class='" & clas & "'>&nbsp;</div>"


                'Dim start As Double = 0
                'Dim v1 As Double = Math.Abs(oneImg * Convert.ToDouble(Rate))
                'Dim v2 As Double = Math.Round(oneImg * Convert.ToDouble(Rate), 1)

                'If Math.Abs(Rate) > Math.Round(Rate, 1) Then
                '    start = v1 - v2

                'Else
                '    Dim r As Double = Math.Round(Rate, 2)
                '    Dim abs As Double = Math.Ceiling(Rate)
                '    start = (oneImg / abs) - Math.Ceiling(r)
                '    start = Math.Ceiling(start)
                'End If
                'If Rate <> 0 Then
                '    width = (oneImg * 10) - width - start
                'Else
                '    width = (oneImg * 10) - width
                'End If

                'strrate += "<div class='blank' style='float:left;width:" & width & "px;background-position-x:" & start & "px'>&nbsp;</div></div>"
                If (Session("pid") IsNot Nothing) Then

                    If (ds.Tables(2).Rows(0)(0) > 0) Then
                        btnSubmit.Visible = False
                        txtcomment.ReadOnly = True
                        Try
                            rblist.Enabled = False
                            rblist.SelectedValue = ds.Tables(2).Rows(0)(1)
                            txtcomment.Text = ds.Tables(2).Rows(0)(2)
                            'trRating.Visible = False
                            'strrate += "<div style='float:left;'>You Have Rated: " & ds.Tables(2).Rows(0)(4) & "</div>"
                        Catch ex As Exception
                        End Try
                    Else
                        btnSubmit.Visible = True
                        txtcomment.Visible = True
                    End If
                End If
                div_pollrate.InnerHtml = strrate
            End If


            ds.Dispose()
            cmd.Dispose()
        Catch
        End Try
    End Sub
    Sub fillgrid()
        'Dim cmd As New SqlCommand
        'cmd.CommandText = "polecomments"
        'cmd.Parameters.AddWithValue("@mid", TextBox1.Text)
        'cmd.Parameters.AddWithValue("@useid", candiid)
        'Dim ds As New DataSet
        'ds = cf.ExecuteDataset(cmd, cf.friendshipdb)

        'Dim strco As Long
        'strco = ds.Tables(1).Rows(0)(0).ToString
        ''If strco = 0 Then
        ''    Rating1.ReadOnly = False
        ''    Rating1.CurrentRating = 2
        ''Else
        ''    Label2.Text = "Your Rate : "
        ''    Rating1.ReadOnly = True
        ''    Rating1.CurrentRating = strco
        ''End If
        GridView1.DataSourceID = ObjectDataSource1.ID
        GridView1.DataBind()
    End Sub
    'Protected Sub Rating1_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs) Handles Rating1.Changed
    '    If Session("pid")  Is Nothing Then
    '        'Server.Transfer("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
    '        'Response.Redirect("../login.aspx") ' & "?ReturnUrl=" & Request.RawUrl)
    '        'Call LinkButton1_Click(LinkButton1, eLinkButton)
    '        Exit Sub
    '    End If
    '    Dim strid As String = 0

    '    Dim s1 As String
    '    s1 = e.Value
    '    Dim cmd As New SqlCommand
    '    cmd.CommandText = "usp_Add_Ratting"
    '    cmd.Parameters.AddWithValue("@fk_postId", lblqid.Text)
    '    cmd.Parameters.AddWithValue("@rate", s1)
    '    cmd.Parameters.AddWithValue("@posttype", "Poll")
    '    cmd.Parameters.AddWithValue("@fk_userId", Session("pid") )

    '    cf.ExecuteNonQuery(cmd, cf.friendshipdb)
    '    cmd.Dispose()
    '    fillgrid()
    '    disp()
    '    loaddetails()
    'End Sub
    Function executiveRdataset(ByVal str As String) As DataSet
        Dim con As New SqlConnection
        Dim ds As DataSet = New DataSet

        con.ConnectionString = cf.justviewcon

        Dim da As SqlDataAdapter = New SqlDataAdapter(str, con)
        da.Fill(ds)

        Return ds
        con.Close()
    End Function


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        If Session("pid") Is Nothing Then
            Response.Redirect("../login.aspx" & "?ReturnUrl=" & Request.RawUrl)
        End If
        Try


            Dim strins As String
            strins = "insert into OnlinePoleTest_Master (QueId,QueDesc,poleAns,polecomment,TotalScore,UserScore,CreationLogInId,CreationDate, isapprove) values ( " _
                     & "  @QueId, @QueDesc, @poleAns, @polecomment, 1, 1, @CreationLogInId,@CreationDate, 'N') select @@identity"
            Dim cn As New SqlConnection(cf.friendshipdb)

            cn.Open()

            Dim cmd As New SqlCommand(strins, cn)

            cmd.Parameters.AddWithValue("@QueId", lblqid.Text)
            cmd.Parameters.AddWithValue("@QueDesc", lblque.Text)
            cmd.Parameters.AddWithValue("@poleAns", rblist.SelectedValue)
            cmd.Parameters.AddWithValue("@polecomment", txtcomment.Text.Replace(ControlChars.Lf, "<br />"))
            cmd.Parameters.AddWithValue("@CreationLogInId", Session("pid"))
            cmd.Parameters.AddWithValue("@CreationDate", Date.Now)
            Dim kk As Integer
            kk = cmd.ExecuteScalar()

            Dim strid As String = 0
            insertUpdateActivity(lblqid.Text, Session("fname"))
            'Dim s1 As String

            's1 = ddlRating.SelectedValue
            'If ddlRatingType.SelectedValue = "-" Then
            '    s1 = "-" & ddlRating.SelectedValue
            'End If

            'cmd = New SqlCommand
            'cmd.CommandText = "usp_Add_Ratting"
            'cmd.Parameters.AddWithValue("@fk_postId", lblqid.Text)
            'cmd.Parameters.AddWithValue("@rate", s1)
            'cmd.Parameters.AddWithValue("@posttype", "Poll")
            'cmd.Parameters.AddWithValue("@fk_userId", Session("pid"))

            'cf.ExecuteNonQuery(cmd, cf.friendshipdb)
            cmd.Dispose()



            fillgrid()
            'disp()
            PollGraph.InnerHtml = CreateGraph()
            loaddetails()
            cmd.Dispose()
            cn.Close()
            Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception
            Response.Redirect(Request.Url.AbsoluteUri)
        End Try
    End Sub
    Sub insertUpdateActivity(ByVal id As Integer, ByVal fn As String)
        Dim Subject As String = lblque.Text
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
        str = str & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & act.candiid & "'>" & act.fn & "</a> Answered on Poll Question <a href='" & Request.Url.AbsoluteUri & "'>" & Subject & "</a>"
        str = str & "</td></tr>"
        str = str & "</table></div>"
        act.activity = str
        act.actType = "PollAns"
        act.photo = ""
        act.pk_Id = id
        cf.siteactivity(act)
    End Sub
    Public Sub disp()
        PlaceHolder1.Controls.Clear()
        If lblqid.Text = "" Then
            Exit Sub
        End If
        Dim ds As DataSet = executiveRdataset("select OptionValue  from pole_Que_CreateDetail where QuestionId= " & lblqid.Text & "")

        Dim iCnt As Integer = 0
        Dim cn As New SqlConnection
        cn.ConnectionString = cf.justviewcon
        cn.Open()
        If (ds.Tables.Count > 0) Then

            Dim tblQue As Table = New Table

            Dim rcount As Integer
            For rcount = 0 To ds.Tables(0).Rows.Count - 1


                Dim trQue As TableRow = New TableRow()
                iRowCounter = iRowCounter + 1
                trQue.ID = "Row_" & iRowCounter.ToString()

                Dim tcQue As TableCell = New TableCell
                Dim tcQueNo As TableCell = New TableCell
                Dim tccount As TableCell = New TableCell

                tcQue.BackColor = System.Drawing.Color.LightYellow
                tcQue.ForeColor = System.Drawing.Color.BlueViolet
                tcQue.Font.Bold = True
                tcQue.Text = "<b>" & ds.Tables(0).Rows(rcount)(0).ToString() & "<b>" & " :-  "
                tcQue.Width = Unit.Percentage(99.0)
                iCellCounter = iCellCounter + 1
                tcQue.ID = "Cell_" & iCellCounter.ToString()


                'If (cn.State <> ConnectionState.Open) Then
                'cn.Open()
                'End If

                Dim pa As String = ds.Tables(0).Rows(rcount)(0).ToString()
                Dim strqq As String = "select COUNT(*) from OnlinePoleTest_Master where poleAns = @Ps and QueId=@PQ "
                Dim cmd As New SqlCommand
                cmd.CommandText = strqq
                cmd.Connection = cn
                cmd.Parameters.AddWithValue("@Ps", pa)
                cmd.Parameters.AddWithValue("@PQ", lblqid.Text)

                tccount.BackColor = System.Drawing.Color.Gainsboro
                tccount.ForeColor = System.Drawing.Color.Green
                tccount.Font.Bold = True
                tccount.Text = Convert.ToString(cmd.ExecuteScalar)
                tccount.Width = Unit.Percentage(0.5)
                iCellCounter = iCellCounter + 1
                tccount.ID = "Cell_" & iCellCounter.ToString()


                tcQueNo.Attributes.Add("Valign", "top")
                tcQueNo.BackColor = System.Drawing.Color.Gainsboro
                tcQueNo.ForeColor = System.Drawing.Color.Red
                tcQueNo.Font.Bold = True
                tcQueNo.Width = Unit.Percentage(0.5)
                iCellCounter = iCellCounter + 1
                tcQueNo.ID = "Cell_" & iCellCounter.ToString()
                iCnt = iCnt + 1
                tcQueNo.Text = iCnt.ToString & "):-"

                'Dim lbl1 As Label = New Label
                'lbl1.Text = ds.Tables(0).Rows(rcount)(0).ToString()
                trQue.Cells.Add(tcQueNo)
                trQue.Cells.Add(tcQue)
                trQue.Cells.Add(tccount)
                tblQue.Rows.Add(trQue)
                cmd.Dispose()
            Next
            PlaceHolder1.Controls.Add(tblQue)

        End If

        cn.Close()
    End Sub

    Protected Sub OnDelete(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName.Equals("Rdelete") Then
            Try
                Dim strid As String = e.CommandArgument.ToString()
                DeleteAdsbtn(strid)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub DeleteAdsbtn(ByVal strid As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "Poll_Delete_Poll_Ans" 'delete from OnlinePoleTest_Master where  SNo=" & strid & ";" _
        '& "Delete updateactivity where pk_Id=" & strid & " and actType='Poll'"
        cmd.Parameters.AddWithValue("@AnsID", strid)
        cmd.Parameters.AddWithValue("@PollID", lblqid.Text)
        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.CommandType = CommandType.StoredProcedure
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Response.Redirect("polet.aspx?id=" & Request.QueryString("id"))
            ' Label1.Text = "Post Deleted Succesfully"
        Else
            Response.Redirect("polet.aspx?id=" & Request.QueryString("id"))
            ' Label1.Text = "Post not Found"
        End If
        cmd.Dispose()
        cn.Close()

    End Sub



    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = "" ' TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photo"), String)

            If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    If System.IO.File.Exists(Server.MapPath("../App_Themes/Thumbs/" & url)) Then
                        img.ImageUrl = "../App_Themes/Thumbs/" & url
                    Else
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If
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

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/login.aspx") ' & "?ReturnUrl=" & Request.RawUrl)
    End Sub



    Protected Sub btnReportAbuse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReportAbuse.Click
        Server.Transfer("../ReportAbuse.aspx")
        'Response.Redirect("../ReportAbuse.aspx")
    End Sub
    Function CreateGraph() As String

        If lblqid.Text = "" Then
            CreateGraph = "Record Not Found"
            Exit Function
        End If

        Dim ds As DataSet = executiveRdataset("select OptionValue, (Select COUNT(poleAns) from OnlinePoleTest_Master Where QueId=QuestionId AND poleAns=OptionValue)as 'Poll' from pole_Que_CreateDetail  where QuestionId =" & lblqid.Text)


        Dim table As DataTable
        table = ds.Tables(0)


        Dim sumObject As Object, TotalPoll As Double = 0
        sumObject = table.Compute("Sum(Poll)", "")
        Try
            TotalPoll = Convert.ToDouble(sumObject)
        Catch
            TotalPoll = 0
        End Try

        Dim str As String = ""
        str = "<table border='0' cellpadding='0' cellspacing='0' class='Graphtbl'>"

        Dim Yaxis As String = "<td rowspan='" & ds.Tables(0).Rows.Count * 2 & "' style='width:3px;background:Red;'></td>"
        Dim b As Boolean = True
        str += "<tr><td colspan='3' class='pollsummary'>Poll Summary</td></tr>"

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim s As Double = dr(1)
            Dim Percent As Double = 100 * s / TotalPoll
            If s = 0 Or TotalPoll = 0 Then
                Percent = 0
            End If
            Percent = Math.Round(Percent, 2)
            str += "<tr>"
            str += "<td align='right' class='pollvalue'>" & dr(0) & "</td>"
            If b Then
                str += Yaxis
                b = False
            End If
            str += "<td style='width:350px;'  title='" & dr(0) & " (" & Percent & "%)'><div style='width:" & Percent * 3 & "px;background:blue;'>&nbsp;</div>"
            str += "<div style='width:40px;'>" & Percent & "%</div>"
            str += "</td>"
            str += "</tr>"
            str += "<tr>"
            str += "<td style='line-height: 8px;'>&nbsp;</td>"
            str += "</tr>"
        Next

        str += "<tr><td></td><td class='scal'></td><td class='scal'>&nbsp;</td></tr>"

        str += "</table>"
        CreateGraph = str
    End Function

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim cmd As New SqlCommand
        cmd.CommandText = "Poll_DeletePoll"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@PolId", Request.QueryString("id"))
        cf.ExecuteNonQuery(cmd)
        cmd.Dispose()
        Response.Redirect("Default.aspx")
    End Sub
    
End Class
