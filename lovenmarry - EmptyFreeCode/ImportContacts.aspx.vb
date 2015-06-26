Imports System.IO
Imports System.Data.SqlClient

Partial Class ImportContacts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ReadJsonFile()
        End If
    End Sub
    Sub ReadJsonFile()
        Dim Source_Dir As String = HttpContext.Current.Server.MapPath("Contacts/")
        Dim strFiles() As String
        strFiles = Directory.GetFiles(Source_Dir, "*.json")
        For Each files As String In strFiles
            Dim str As String = ""
            If File.Exists(files) Then
                Dim Lines() As String = IO.File.ReadAllLines(files)
                For Each f As String In Lines
                    str += f '& ControlChars.Lf
                Next
            End If


            'Dim AllContact As List(Of UserDetails) = New List(Of UserDetails)
            Dim Sender As String = ""
            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim dict1 As Object = jss.Deserialize(Of Object)(str)
            Try
                Sender = dict1("feed")("author")(0)("email")("$t")
            Catch ex As Exception
                Sender = ""
            End Try
            Dim dict() As Object
            Try
                dict = dict1("feed")("entry")
                'Dim Obj As Object = dict
                For Each o As Object In dict
                    Dim cont As New UserDetails
                    If o.ContainsKey("gd$email") Then
                        cont.email = o("gd$email")(0)("address") ' dicte(0)("address")
                        cont.fname = o("title")("$t") ' dict1("$t")
                        'AllContact.Add(cont)
                        addhisemails(cont, Sender)
                    End If
                    '    Dim dict1 As Dictionary(Of String, Object) = o("title")
                Next
                Response.Write("<br />Imported " & Sender)
            Catch ex As Exception
                Response.Write("<br />Not Imported " & Sender)
            End Try

           
            
            'Try
            '    Sender = UD("feed")("author")(0)("email")("$t")
            'Catch ex As Exception
            '    Sender = email
            'End Try
            File.Delete(files)
        Next
    End Sub

    Dim cf As New comonfunctions
    Sub addhisemails(ByVal cont As UserDetails, ByVal semail As String)

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
            cn.Close() '

        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

End Class
