Imports System.Data
Imports System.Data.SqlClient

Partial Class members_sendmsg
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim toemail As String = ""
        Dim strsql As String = ""
        Dim msg As String = ""
        Dim buttonurl As String = ""
        Dim gender As String = ""
        Dim premiummem As String = ""
        Dim contactedmemgender = ""
        Dim paid As String = "N"
        Dim msg_count As Integer = 0
        Dim Subs_Plan As Integer = 0
        Dim Msg_Left As Integer = 0
        Dim TodayMsg As Integer = 0
        Dim mailsent As String = "N"
        Dim susp As String = "N"

        msg = "You have an Email From <br>"
        msg = msg & "<a href='http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & Session("pid") & "'>click to check profile</a>"
        msg = msg & "<br><br> Message Below <br><br>" & TextBox1.Text


        If Session("approved") <> "Y" Then
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "Your Profile is not Approved Yet, Kindly Wait For Your Profile to be Approved and then you can send emails to other members"
            Exit Sub
        End If


        cmd.CommandText = "get_Membership"
        cmd.Parameters.AddWithValue("candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@tocontact", Request.QueryString("pid"))
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd, cf.friendshipdb)
        If ds.Tables(0).Rows.Count > 0 Then
            gender = ds.Tables(0).Rows(0)("gender").ToString
            paid = ds.Tables(0).Rows(0)("Paid").ToString
            premiummem = ds.Tables(0).Rows(0)("premiummem").ToString
            msg_count = ds.Tables(0).Rows(0)("msg_count")
            Subs_Plan = ds.Tables(0).Rows(0)("Subs_Plan")
            Msg_Left = ds.Tables(0).Rows(0)("Msg_Left")
            TodayMsg = ds.Tables(2).Rows(0)("ToDayMsg")
            susp = ds.Tables(0).Rows(0)("susp")
            If susp = "Y" Then
                Session("susp") = "Y"
                Response.Cookies("scammer").Value = "yes"
                Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
                Response.Redirect("../usedbyscammers.aspx")
            End If

        Else
            Exit Sub
        End If
        ' Un Comment below code For Compulsary PremiumShip
        'paid = "Y"
        If ds.Tables(1).Rows.Count > 0 Then
            toemail = ds.Tables(1).Rows(0)("email").ToString
            contactedmemgender = ds.Tables(1).Rows(0)("gender").ToString
        End If
        If gender = "M" And paid = "N" Then
            Response.Redirect("premiummem.aspx")
            Exit Sub
        ElseIf gender = "M" And paid = "Y" Then ' And And premiummem = "N"
            If TodayMsg >= 50 Then
                Label1.Text = "You have Send maximum message For Today. Come Tomorrow to send more Message"
                Label1.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
            Label1.Text = cf.send25("membercontact", "Contact From " & Session("fname"), toemail, msg)
            mailsent = "Y"
        End If
       
        




        If Session("sex") = contactedmemgender Then

            Label1.Text = "Cannot Contact Same Sex Member,Your Gender is " & Session("sex") & " and member to be contacted is also " & contactedmemgender

        Else
            If Session("sex") = "F" Or paid = "Y" Then
                Label1.Text = cf.send25("membercontact", "Contact From " & Session("fname"), toemail, msg)
                mailsent = "Y"
            End If


            Button1.Enabled = False
            cmd = New SqlCommand
            cmd.CommandText = "Add_msg"
            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@Contacted", Request.QueryString("pid"))
            cmd.Parameters.AddWithValue("@User_Message", TextBox1.Text.Trim.Replace(ControlChars.Lf, "<br />"))
            cmd.Parameters.AddWithValue("@ContactON", Date.Now)
            cmd.Parameters.AddWithValue("@MailSend", mailsent)
            Response.Write(mailsent & gender)
            Dim i As Integer = cf.ExecuteNonQuery(cmd, cf.friendshipdb)
            Button1.Text = i
            If i > 0 Then
                Button1.Text = "Message Sent"
            End If
            cmd.Dispose()
        End If


        cn.Close()
    End Sub

   
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
      

       
        
        If Not Page.IsPostBack Then
            '// upload photo check
          
            checkphotos()

        End If

    End Sub

   
    Sub checkphotos()
        Dim strsql As String = ""
        Dim cn As New SqlConnection
        Dim myreader As SqlDataReader
        Dim cmd As New SqlCommand
        Dim gender As String = ""
        Dim photo As String = ""
        strsql = "select gender,photo from profile where pid=" & Session("pid")

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader

        While myreader.Read
            gender = myreader.GetValue(0).ToString
            photo = myreader.GetValue(1).ToString
        End While
        If (gender = "M" And photo = "") Then
            tduploadphoto.Visible = True
            tdmsg.InnerHtml = "Uploading Photo is Compulsory for all males to contact female members"
            'Button1.Enabled = False
        End If

    End Sub
End Class
