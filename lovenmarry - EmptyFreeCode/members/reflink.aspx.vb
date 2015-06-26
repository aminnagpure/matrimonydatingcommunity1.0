
Partial Class members_reflink
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim msg As String = ""
        txtreflink.Text = "http://www." & cf.websitename & "/default.aspx?affid=" & Session("pid")

        msg = "hi there," & vbCrLf & "  join me here"
        msg = msg & vbCrLf & " http://www." & cf.websitename & "/default.aspx?affid=" & Session("pid")
        msg = msg & vbCrLf & vbCrLf & " its a free site, you can send email to other members free"
        msg = msg & vbCrLf & " Join with me here you can find your Buddy"
        msg = msg & vbCrLf & " All Cool People are Registered Here "
        msg = msg & vbCrLf & " Come Join have fun"
        TextBox1.Text = msg
        TD1.InnerText = "You can Point to Any Page just add ?mid=" & Session("pid")
        If Session("pid") IsNot Nothing Then
            Dim sql As String = ""
            sql = "select count(referd) from topearners where mid=" & Session("pid")  '& ""
            lblreferals.Text = cf.MemberCount(sql)
            sql = "select sum(earnedamt) from topearners where pstatus='Pending' and mid=" & Session("pid")  '& ""
            lblmoneyearned.Text = cf.MemberCount(sql)

            sql = "select sum(earnedamt) from topearners where pstatus='Approved' and mid=" & Session("pid")  ' & ""
            lblAmtApproved.Text = cf.MemberCount(sql)

            sql = "select sum(earnedamt) from topearners where pstatus='Paid' and mid=" & Session("pid")  ' & ""
            lblAmountPaid.Text = cf.MemberCount(sql)
        End If
        'TextBox1.Text = "http://www.websolatwork.com/default.aspx?affid=" & Session("pid")
        HyperLink10.NavigateUrl = "~/JoinUs.aspx?affid=" & Session("pid")
    End Sub
End Class
