
Partial Class moderators_doubtful
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = " isdoubtful='Y' and  susp='N'"
    End Sub
    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim sqlcountry As String = ""
        Dim sqlstate As String = ""
        Dim sqlcity As String = ""
        Dim sqlpincode As String = ""
        Dim sqlgender As String = ""
        Dim sqlrace As String = ""
        Dim sqlreligion As String = ""
        Dim sqlstarsign As String = ""
        Dim sqlmaritalstatus As String = ""
        Dim sqlheight As String = ""
        Dim sqlage As String = ""
        Dim sqlmarital As String = ""
        Dim sqlonline As String = ""
        Dim sqlchkphoto As String = ""
        'Dim sqlphoto As String = ""

       
        'txtjointype.Text = " Left join"



        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonline & sqlchkphoto & sqlcity & sqlchkphoto

        TextBox1.Text = makequery
    End Function

End Class
