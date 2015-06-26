Imports System.Net
Imports System.IO
Imports System.Web.Services
Imports System.Xml

Partial Class ReadContact
    Inherits System.Web.UI.Page
#Region "Cont"

    <WebMethod()> _
    Public Shared Function ReadContact(ByVal UD As Object) As String
        Try

            'Dim dict() As Object = UD '("feed") '("entry")
            'Dim AllContact As List(Of UserDetails) = New List(Of UserDetails)
            Dim Sender As String = ""

            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim C As String = jss.Serialize(UD)
            Try
                Sender = UD("feed")("author")(0)("email")("$t")
            Catch ex As Exception
                Sender = RandName()
            End Try
            'For Each o As Object In dict
            '    Dim cont As New UserDetails
            '    If o.ContainsKey("gd$email") Then
            '        cont.email = o("gd$email")(0)("address") ' dicte(0)("address")
            '        cont.fname = o("title")("$t") ' dict1("$t")
            '        'AllContact.Add(cont)
            '        'addhisemails(cont, Sender)
            '    End If
            '    Dim dict1 As Dictionary(Of String, Object) = o("title")
            'Next
            ' SendRequest("ReadContact.aspx"
            Dim path As String = HttpContext.Current.Server.MapPath("Contacts/") ' & RandName() & ".json"

            'Dim s As String = C.ToString
            'Dim jsss As New System.Web.Script.Serialization.JavaScriptSerializer()
            'Dim dict1 As Object = jss.Deserialize(Of Object)(s)

            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            path = path & Sender & ".json"
            Dim str As String = C
            Dim sw1 As New StreamWriter(path, False)
            Try
                sw1.WriteLine(str)
                sw1.Close()
                sw1 = Nothing
            Catch ex As Exception

                sw1.Close()
            End Try

            Return "" 'CreateDataSet("Done").GetXml
        Catch ex As Exception
            Return "" 'CreateDataSet(ex.Message & " Not Add").GetXml
        End Try
    End Function


   



#End Region

    Shared Function RandName() As String
        Dim d As Date = Date.Now
        RandName = d.Year & "_" & d.Month & "_" & d.Day & "_" & d.Hour & "_" & d.Minute & "_" & d.Second & "_" & d.Millisecond & "_" & rnd()
    End Function
    Shared Function rnd() As String
        Dim r As New Random
        rnd = r.Next(100, 500)
    End Function
End Class
