Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Data

Partial Class members_ConnectWIthGPlus
    Inherits System.Web.UI.Page

    Public Shared cf As New comonfunctions
    Public Shared IP As String = ""
    Shared refer1 As Integer = 0
    Shared ref1val As Integer = 0
    Public Shared email As String = ""
#Region "Cont"

    <WebMethod()> _
    Public Shared Function ReadContact(ByVal UD As Object) As String
        Try

            Dim dict() As Object = UD("feed")("entry")
            'Dim AllContact As List(Of UserDetails) = New List(Of UserDetails)
            Dim Sender As String = ""
            Try
                Sender = UD("feed")("author")(0)("email")("$t")
            Catch ex As Exception
                Sender = email
            End Try
            For Each o As Object In dict
                Dim cont As New UserDetails
                If o.ContainsKey("gd$email") Then
                    cont.email = o("gd$email")(0)("address") ' dicte(0)("address")
                    cont.fname = o("title")("$t") ' dict1("$t")
                    'AllContact.Add(cont)
                    addhisemails(cont, Sender)
                End If
                Dim dict1 As Dictionary(Of String, Object) = o("title")
            Next
            Return CreateDataSet("Done").GetXml
        Catch ex As Exception
            Return CreateDataSet(ex.Message & " Not Add").GetXml
        End Try
    End Function
#End Region
    <WebMethod()> _
    Public Shared Function ReadData(ByVal UD As Object) As String
        Return candiReg(UD).GetXml
    End Function
    Public Shared Function candiReg(ByVal UD As Object) As DataSet
        Dim D As UserDetails = New UserDetails()
        Try
            D.fname = UD("displayName")
            'Dim dict As Dictionary(Of String, Object) = UD("emails")(0)
            D.email = UD("emails")(0)("value")
            email = D.email
            Try
                D.gender = UD("gender")
            Catch ex As Exception
                D.gender = "Male"
            End Try
            ' D.photo = UD("image")("url")
            'D.cityname = UD("placesLived")(0)("value")
            Dim gender As String = D._gender
            Try
                D.photo = UD("image")("url")
            Catch ex As Exception

            End Try
            Try
                D.GPlusUrl = UD("url")
            Catch ex As Exception
                D.GPlusUrl = ""
            End Try
            Dim C As String = ""
            Try
                'Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
                'C = jss.Serialize(UD)
                C = UD("url")
                ' C = UD("objectType").TOString
            Catch ex As Exception
                C = ex.Message

            End Try
            ' D.dateofbirth = Format(D.dateofbirth, "dd/MM/yyyy hh:mm:ss tt")


            addtocandireg(D)
            Return CreateDataSet("Sync")
            
            'Return CreateDataSet(i)
        Catch ex As Exception
            Dim msg As String = "IP : " & IP & "<br />"
            Try
                msg += UD("message") & "<br />"
            Catch ex1 As Exception

            End Try
            cf.send25("Err", "Err in Plus", "pri.aptekar@gmail.com", ex.Message & msg)
            Return CreateDataSet(ex.Message)
        End Try
        'Return CreateDataSet(UD("ageRange")("min"))
        'CashLocv.Value = dict("HotelListResponse")("cacheLocation")
    End Function
    Shared Sub addtocandireg(ByVal D As UserDetails)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = ""
        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt

        Try

           
            pid = HttpContext.Current.Session("pid")

            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            st1 = "update Profile set GPlusUrl= @GPlusUrl where pid =@pid"

            cmd.Connection = cn
            cmd.CommandText = st1

            cmd.Parameters.AddWithValue("@pid", pid)
            cmd.Parameters.AddWithValue("@GPlusUrl", D.GPlusUrl)
            cf.ExecuteNonQuery(cmd, cf.friendshipdb)

            HttpContext.Current.Session("GPlusUrl") = D.GPlusUrl

            
            cmd.Dispose()
            cn.Close()

            

        Catch ex As Exception
            cn.Close()
            cf.send25("Err", "Err in Plus", "pri.aptekar@gmail.com", ex.Message)
            'HttpContext.Current.Response.Redirect("register.aspx")
        End Try

    End Sub
    Public Shared Function CreateDataSet(ByVal s As String) As DataSet

        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable("pid")
        dt.Columns.Add("pid", GetType(String))
        Dim dr As DataRow
        dr = dt.NewRow
        dr("pid") = s
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)
        Return ds
    End Function
    Shared Sub addhisemails(ByVal cont As UserDetails, ByVal semail As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim st1 As String = ""
        Dim pid As String = ""
        Try

            cn.ConnectionString = cf.websolcon
            cn.Open()

            st1 = "insert into importedemails(email,sendersemail,fname,lovenmarry) values(@email,@sendersemail,@fname,@lovenmarry)"

            cmd.Connection = cn
            cmd.CommandText = st1

            cmd.Parameters.AddWithValue("@email", cont.email)
            cmd.Parameters.AddWithValue("@sendersemail", semail)
            cmd.Parameters.AddWithValue("@fname", cont.fname)
            cmd.Parameters.AddWithValue("@lovenmarry", "Y")

            cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.Server.ScriptTimeout = 500
    End Sub
End Class


