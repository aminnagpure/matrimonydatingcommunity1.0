
Partial Class Partner_Default
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
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
        End If
    End Sub
End Class
