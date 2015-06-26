Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class members_validatemobile
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadata()
        End If
        'sendsms()
    End Sub
    Sub sendsms(ByVal mobino As String, ByVal validatincode As String)
        'Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String = ""
        Dim username As String = ""
        Dim password As String = ""
        Dim host As String = ""
        Dim originator As String = ""
        Dim validstring As String = ""
        Dim rtn As String = ""

        validstring = "Your Validation Code is " & validatincode & vbCrLf & vbCrLf & "  sent from yoursite.com"

        Try

            rtn = cf.fastsms(mobino, validstring)


            'MessageBox.Show("Response: " & response.StatusDescription)

        Catch ex As Exception
            '  MsgBox(ex.ToString)


            'Label1.Text = ex.ToString
            Label1.Text = url

        End Try
    End Sub
    Sub loadata()
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim strsql As String = ""
        Dim mobileno As String = ""
        Dim validationcode As String = ""
        Dim isvalidmobile As String = ""

        Try


            strsql = "select pid,mobile,isvalidmobile from profile where pid=" & Session("pid") & ""
            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = strsql
            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    validationcode = RandomNumbermobile(9999, 1000)
                    mobileno = myreader.GetValue(1).ToString
                    isvalidmobile = myreader.GetValue(2).ToString
                    txtvalidationcode.Text = validationcode
                    txtmobileno.Text = mobileno
                    If (mobileno <> "" And isvalidmobile = "N") Then
                        sendsms(mobileno, validationcode)
                        Label1.Text = "Validation Code Sent to your mobile " & mobileno
                    End If
                    If isvalidmobile = "Y" Then
                        Label1.Text = "Your Mobile is Already Validated"
                        TextBox1.Visible = False
                        Button1.Visible = False
                    End If
                    If mobileno = "" Then
                        TextBox1.Visible = False
                        Button1.Visible = False
                        Label1.Text = "You Have Not Entered Your Mobile No, Kindly Input Your mobile number, Edit Your Profile and Input Your Mobile Number"
                    End If
                End While
            Else

            End If

            cn.Close()

        Catch ex As Exception
            Label1.Text = ex.ToString
            cn.Close()

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rtn As String = ""
        Dim strSql As String = ""
        'strSql = "select count(*) from candidatesregistration where candiid='" & TextBox1.Text & "' and mobile='" & HiddenField2.Value & "' and candiid='" & Session("pid") & "'"

        'rtn = cf.jobseekercount(strSql)
        If txtvalidationcode.Text = TextBox1.Text Then
            Label1.Text = "Validated Successfully"
            strSql = "update profile set isvalidmobile='Y' where pid=" & Session("pid") & ""
            cf.TaskmembSql(strSql)
            TextBox1.Visible = False
            Button1.Visible = False
        Else
            Label1.Text = "Wrong Validation Code"

        End If
    End Sub

    Private Function RandomNumbermobile(ByVal MaxNumber As Integer, _
   Optional ByVal MinNumber As Integer = 1000) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function

End Class
