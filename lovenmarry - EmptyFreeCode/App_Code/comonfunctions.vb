Imports System.Net.Mail
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient





Public Class comonfunctions


    Public Function send25(ByVal fromemail As String, ByVal subject As String, ByVal toas As String, ByVal tmsg As String) As String


        Dim client As New SmtpClient("mail.yoursite.com") 'your SMTP server
        client.UseDefaultCredentials = False

        'Your username and password to login
        client.Credentials = New Net.NetworkCredential("memreq@yoursite.com", "Amin1234*")
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        Dim Mail As New MailMessage(fromemail & "@yoursite.com", toas, subject, tmsg)
        Mail.IsBodyHtml = True


        client.Send(Mail)
    End Function
    Public Function sendMail(ByVal fromemail As String, ByVal subject As String, ByVal toas As String, ByVal tmsg As String, Optional ByVal fname As String = "Mem") As String


        Dim client As New SmtpClient("mail.yoursite.com") 'your SMTP server
        client.UseDefaultCredentials = False

        'Your username and password to login
        client.Credentials = New Net.NetworkCredential("memreq@yoursite.com", "Amin1234*")
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        Dim Mail As New MailMessage(fname & "<" & "membercontact@yoursite.com>", toas, subject, tmsg)
        Mail.IsBodyHtml = True


        client.Send(Mail)
    End Function
    Sub send25forinvites(ByVal fromemail As String, ByVal subject As String, ByVal toas As String, ByVal tmsg As String)


        Dim client As New SmtpClient("mail.yoursite.com") 'your SMTP server
        client.UseDefaultCredentials = False
        Try
            'Your username and password to login
            client.Credentials = New Net.NetworkCredential("memreq@yoursite.com", "Z9f7oS493")
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            Dim Mail As New MailMessage(fromemail, toas, subject, tmsg)
            Mail.IsBodyHtml = True




            client.Send(Mail)


        Catch ex As Exception

        End Try        '
    End Sub
    Function emailserver() As String
        emailserver = "mail.yoursite.com"

    End Function



    Sub logoffuser(ByVal pid As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Try

            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = "update profile set isonlinenow='N' where pid=" & pid & ""


            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception

        End Try


    End Sub
    Function ExecuteDataset(ByVal sql As SqlCommand, ByVal constr As String) As DataSet
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = constr
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter(sql)
        da.Fill(kk)
        ExecuteDataset = kk
        sql.Parameters.Clear()
        cn.Close()
        sql.Parameters.Clear()
        Return ExecuteDataset
    End Function
    Function getCandiName(ByVal candiid As String) As String
        Dim cn As New SqlConnection
        cn.ConnectionString = friendshipdb()
        cn.Open()
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "Select fname from Profile Where pid=" & candiid
        getCandiName = cmd.ExecuteScalar()
        cn.Close()
    End Function
    Function ExecuteNonQuery(ByVal sql As SqlCommand, ByVal constr As String) As String
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = constr
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Dim i As Integer = sql.ExecuteNonQuery()
        cn.Close()
        Return i
    End Function
    Function ExecuteScalar(ByVal sql As SqlCommand, ByVal constr As String) As String
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = constr
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Return Convert.ToString(sql.ExecuteScalar())
        cn.Close()
    End Function
    Function Taskjobseeker(ByRef str As String) As String
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim rtn As Integer

        Try


            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = str
            cmd.CommandTimeout = 5000
            rtn = cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close()
            Taskjobseeker = rtn
        Catch ex As Exception
            cn.Close()
            Taskjobseeker = 0
        End Try
    End Function
    Function generateid() As String
        generateid = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond & RandomNumber(20)
    End Function

    Function checkblocked(ByVal pidiftheuserblockedtheContactor As String, ByVal sessionpid As String) As Boolean
        Dim strsql As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader

        Dim kk As String = ""

        cn.ConnectionString = friendshipdb()
        cn.Open()

        If sessionpid = "" Then
            sessionpid = "0"
        End If
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select * from blacklisted where pid=" & pidiftheuserblockedtheContactor & " and memberidblocked=" & sessionpid & ""
        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            cn.Close()
            Return True

        Else
            cn.Close()
            Return False
        End If

    End Function
    Function websitename() As String
        websitename = ConfigurationManager.AppSettings("websitename").ToString
    End Function

    Function friendshipdb() As String
        friendshipdb = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString
    End Function

    Function justviewcon() As String
        justviewcon = ConfigurationManager.ConnectionStrings("justview").ConnectionString
    End Function
   
    Function websolcon() As String
        websolcon = ConfigurationManager.ConnectionStrings("websolcon").ConnectionString
    End Function

    Function delrecordset(ByVal strsql As String) As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""


        cn.ConnectionString = friendshipdb()
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = strsql
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            cn.Close()
            Return True
        Else
            cn.Close()
            Return False
        End If


    End Function

    Function update(ByVal strsql As String) As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""


        cn.ConnectionString = friendshipdb()
        cn.Open()

        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = strsql
        kk = cmd.ExecuteNonQuery()

        cmd.Dispose()
        cn.Close()

        If kk > 0 Then

            Return True
        Else

            Return False
        End If


    End Function

    Function CountRs(ByVal strsql As String) As String

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As String = ""
        Try

            cn.ConnectionString = friendshipdb()
            cn.Open()

            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = strsql
            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    kk = myreader.GetValue(0)
                End While

                CountRs = kk
            Else

                CountRs = "0"

            End If

            cmd.Dispose()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            CountRs = "0"

        End Try

    End Function

    Function adminemail() As String
        adminemail = ConfigurationManager.AppSettings("adminemail").ToString
    End Function



    Public Function BreakWordForWrap(ByVal StringToBreak As String) As String
        If String.IsNullOrEmpty(StringToBreak) Then
            Return (String.Empty)
        End If
        Dim pattern As String = "(\S{20})(\S)"
        Dim regex As New Regex(pattern, RegexOptions.IgnoreCase)
        'return regex.Replace(StringToBreak, @"$1 $2"); //for space...or use "$1<wbr>$2"
        Return (regex.Replace(StringToBreak, "$1<br/>$2"))
    End Function

    Public Function totalmembersonline() As String
        Try
            totalmembersonline = CountRs("select count(*) from profile where isonlinenow='Y' and approved='Y'")
        Catch ex As Exception
            totalmembersonline = "0"

        End Try
    End Function
    Sub Writeerrlog(ByVal pth As String, ByVal mm As String)

        Dim fp As StreamWriter

        Try
            fp = File.CreateText(pth)
            fp.WriteLine(mm)

            fp.Close()
        Catch err As Exception




        End Try

    End Sub
    Function dtformat() As String
        Dim vl As String = ""
        'adminemail = ConfigurationManager.GetSection("culture").ToString
        vl = ConfigurationManager.AppSettings("dtformat").ToString
        If vl = "he-IL" Then
            dtformat = "dd/mm/yyyy"
        Else
            dtformat = "mm/dd/yyyy"
        End If

    End Function
    Function subtitle() As String
        Try
            subtitle = ConfigurationManager.AppSettings("subtitle").ToString
        Catch ex As Exception
            subtitle = ""
        End Try
    End Function
    Function firealert() As String
        Try
            firealert = ConfigurationManager.AppSettings("emailalerts").ToString
        Catch ex As Exception
            firealert = "5"
        End Try
    End Function




    Function autoapprove() As String
        autoapprove = ConfigurationManager.AppSettings("autoapprove").ToString
    End Function

    Sub sendemailtouser(ByVal userid As String, ByVal subj As String, ByVal emmsg As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim strSql As String = ""
        Dim kk As String = ""

        Try


            strSql = "select email from profile where pid=" & userid & ""
            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = strSql

            myreader = cmd.ExecuteReader
            While myreader.Read
                kk = send25("approved", subj, myreader.GetValue(0).ToString, emmsg)
            End While

            cmd.Dispose()
            cn.Close()

        Catch ex As Exception
            cmd.Dispose()
            cn.Close()
        End Try

    End Sub
    Function convertdateforsql(ByVal st As String) As String
        If dtformat() = "dd/mm/yyyy" Then
            st = Mid(st, 7, 4) & "/" & Mid(st, 4, 2) & "/" & Mid(st, 1, 2)
        End If

        If dtformat() = "mm/dd/yyyy" Then
            st = Mid(st, 7, 4) & "/" & Mid(st, 1, 2) & "/" & Mid(st, 4, 2)
        End If

        convertdateforsql = st
    End Function
    'Sub addviewentry(ByVal viewdby As String, ByVal viewdof As String, ByVal ipofviewer As String)
    '    Dim cn As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim sql As String = ""
    '    Dim cnt As Integer = 0

    '    If checkviewentry(viewdby, viewdof) > 0 Then
    '        sql = "update profileviews set vieweddate=getdate() where viewedbyid=" & viewdby & " and  pidof='" & viewdof & "'"
    '    Else
    '        sql = "insert into profileviews(viewedbyid,pidof,ipaddress) values(" & viewdby & "," & viewdof & ",'" & ipofviewer & "')"
    '    End If
    '    cn.ConnectionString = friendshipdb()
    '    cn.Open()
    '    cmd.Connection = cn
    '    cmd.CommandTimeout = 5000
    '    cmd.CommandText = sql
    '    cmd.ExecuteNonQuery()
    '    cmd.Dispose()
    '    cn.Close()

    'End Sub
    Sub addviewentry(ByVal viewdby As String, ByVal viewdof As String, ByVal ipofviewer As String)
        'Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        'Dim cnt As Integer = 0

        ' If checkviewentry(viewdby, viewdof) > 0 Then
        sql = "AddProfileview" '"update profileviews set vieweddate=getdate() where viewedbyid=" & viewdby & " and  pidof='" & viewdof & "'"
        'Else
        'sql = "insert into profileviews(viewedbyid,pidof,ipaddress) values(" & viewdby & "," & viewdof & ",'" & ipofviewer & "')"
        'End If
        'cn.ConnectionString = friendshipdb()
        'cn.Open()
        'cmd.Connection = cn
        cmd.CommandTimeout = 5000

        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("@viewdby", viewdby)
        cmd.Parameters.AddWithValue("@viewdofid", viewdof)
        cmd.Parameters.AddWithValue("@ipAddress", ipofviewer)
        ExecuteNonQuery(cmd, friendshipdb)
        'cmd.ExecuteNonQuery()
        cmd.Dispose()
        'cn.Close()

    End Sub
    Function checkviewentry(ByVal viewbyid As String, ByVal viewdofid As String) As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Integer = 0
        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select count(*) from profileviews  where viewedbyid=" & viewbyid & " and pidof=" & viewdofid & ""
        myreader = cmd.ExecuteReader

        While myreader.Read
            cnt = myreader.GetValue(0)
        End While
        cmd.Dispose()
        cn.Close()

        checkviewentry = cnt
    End Function

    Function ref1val() As Decimal
        ref1val = 10 'ConfigurationManager.AppSettings("ref1val").ToString
    End Function
    Function ref2val() As Decimal
        ref2val = 0 'ConfigurationManager.AppSettings("ref2val").ToString
    End Function

    Function directmemref(ByVal ref1 As String) As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Integer = 0
        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select count(*) from profile  where ref1=" & ref1 & ""
        myreader = cmd.ExecuteReader

        While myreader.Read
            cnt = myreader.GetValue(0)
        End While
        cmd.Dispose()
        cn.Close()

        directmemref = cnt
    End Function




    Function unpaidmoneydirect(ByVal pid As String) As Decimal
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Decimal = 0

        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select sum(ref1val) from profile  where ref1=" & pid & ""
        myreader = cmd.ExecuteReader

        While myreader.Read
            If IsDBNull(myreader.GetValue(0)) Then
                cnt = 0
            Else
                cnt = myreader.GetValue(0)
            End If
        End While
        cmd.Dispose()
        cn.Close()

        unpaidmoneydirect = cnt

    End Function

    Function affprogram() As String
        affprogram = ConfigurationManager.AppSettings("affprogram").ToString
    End Function

    Function ForAdminunpaidmoneydirect() As Decimal
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Decimal = 0

        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandText = "select sum(ref1val) from profile where paid='N' "
        myreader = cmd.ExecuteReader

        While myreader.Read
            If IsDBNull(myreader.GetValue(0)) Then
                cnt = 0
            Else
                cnt = myreader.GetValue(0)
            End If
        End While
        cmd.Dispose()
        cn.Close()

        ForAdminunpaidmoneydirect = cnt

    End Function

    Function gethiscountrybyip(ByVal ipadd As String) As String
        Dim dottedip As String
        Dim Dot2LongIP As Double
        Dim PrevPos As Double
        Dim pos As Double
        Dim num As Double
        Dim i As Integer = 0
        dottedip = ipadd

        Try

            For i = 1 To 4
                pos = InStr(PrevPos + 1, dottedip, ".", 1)
                If i = 4 Then
                    pos = Len(dottedip) + 1
                End If
                num = Int(Mid(dottedip, PrevPos + 1, pos - PrevPos - 1))
                PrevPos = pos
                Dot2LongIP = ((num Mod 256) * (256 ^ (4 - i))) + Dot2LongIP
            Next

            ipadd = Dot2LongIP



            Dim cn As New System.Data.OleDb.OleDbConnection
            Dim cmd As New System.Data.OleDb.OleDbCommand
            Dim myreader As System.Data.OleDb.OleDbDataReader
            Dim constring As String = ""
            Dim countryname As String = ""

            constring = ConfigurationManager.ConnectionStrings("iptocountry").ConnectionString
            cn.ConnectionString = constring
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 5000
            cmd.CommandText = "SELECT countryname from [ip-to-country] WHERE (([BeginingIP] <= " & ipadd & ") AND ([EndingIP] >=" & ipadd & " )) "

            myreader = cmd.ExecuteReader
            While myreader.Read
                countryname = myreader.GetValue(0)
            End While

            gethiscountrybyip = countryname
            myreader.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception
            gethiscountrybyip = ""
        End Try

    End Function

    Function isdoubtful(ByVal ipcountry As String) As String
        If ipcountry = "" Or ipcountry = "NIGERIA" Or ipcountry = "SENEGAL" Then
            isdoubtful = "Y"
        Else
            isdoubtful = "N"
        End If
    End Function

    
    Public Function RandomNumber(ByVal MaxNumber As Integer, _
        Optional ByVal MinNumber As Integer = 0) As Integer

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
    Function TaskmembSql(ByVal str As String) As String
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim rtn As String = ""
        Try


            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandTimeout = 4000
            cmd.CommandText = str
            rtn = cmd.ExecuteNonQuery()

            cmd.Dispose()
            cn.Close()
            TaskmembSql = rtn
        Catch ex As Exception
            cn.Close()
            TaskmembSql = 0

        End Try

    End Function

    Sub addintotopearner(ByVal mid As String, ByVal earnamt As String, ByVal source As String, ByVal refdwhom As String)
        Dim eif As String = ""
        Dim sql As String = ""
        eif = generateid()
        sql = "insert into topearners(mid,earnedamt,source,referd) values(" & mid & "," & earnamt & ",'" & source & "','" & refdwhom & "')"
        eif = TaskmembSql(sql)
    End Sub


   
    Function fastsms(ByVal mobino As String, ByVal validatincode As String) As String
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim url As String = ""
        Dim username As String = ""
        Dim password As String = ""
        Dim host As String = ""
        Dim originator As String = ""
        Dim validstring As String = ""



        Try

            host = "http://enterprise.smsgupshup.com/GatewayAPI"
            originator = "06201234567"
            username = "2000042412"
            password = "CFFwiF1pD"

            url = host + "/rest?&" _
                    & "method=SendMessage" _
                    & "&send_to=" + HttpUtility.UrlEncode(mobino) _
                    & "&msg=" + HttpUtility.UrlEncode(validatincode) _
                    & "&userid=" & HttpUtility.UrlEncode(username) _
                    & "&auth_scheme=plain" _
                    & "&password=" + HttpUtility.UrlEncode(password)





            request = DirectCast(WebRequest.Create(url), HttpWebRequest)

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            Return response.ToString
            'MessageBox.Show("Response: " & response.StatusDescription)

        Catch ex As Exception
            '  MsgBox(ex.ToString)
            Return ex.ToString

        End Try
    End Function

    Function ExecuteDataset(ByVal sql As SqlCommand) As DataSet
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = friendshipdb()
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure

        Dim da As New SqlDataAdapter(sql)
        da.Fill(kk)
        ExecuteDataset = kk
        sql.Parameters.Clear()
        cn.Close()
        sql.Parameters.Clear()
        Return ExecuteDataset
    End Function
    Function ExecuteDatasetview(ByVal sql As SqlCommand) As DataSet
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = justviewcon()
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure

        Dim da As New SqlDataAdapter(sql)
        da.Fill(kk)
        ExecuteDatasetview = kk
        sql.Parameters.Clear()
        cn.Close()
        sql.Parameters.Clear()
        Return ExecuteDatasetview
    End Function
    Function ExecuteDatareader(ByVal sql As SqlCommand) As SqlDataReader
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = friendshipdb()
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Return sql.ExecuteReader
    End Function
    Function ExecuteNonQuery(ByVal sql As SqlCommand) As String
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = friendshipdb()
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Dim i As Integer = sql.ExecuteNonQuery()
        cn.Close()
        Return i
    End Function


    Function LoadMasters() As DataSet
        Dim cmd As New SqlCommand
        Dim strsql As String = ""
        'strsql = "select top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active='Y')as photoname ,photo.passw,fname,profiledate  from profile left  join photo on  profile.pid=photo.pid where visibletoall='Y' and approved='Y' and isonlinenow='Y' "
        strsql = "Usp_County_State_City_Master"
        cmd.CommandText = strsql
        cmd.CommandTimeout = 5000
        LoadMasters = ExecuteDataset(cmd)
        Return LoadMasters
    End Function

    Function MemberCount(ByVal sql As String) As String

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As String = ""


        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        Try
            cmd.CommandText = sql
            myreader = cmd.ExecuteReader

            While myreader.Read
                kk = myreader.GetValue(0)
            End While

            myreader.Close()
            cn.Close()

            MemberCount = kk

        Catch ex As Exception
            MemberCount = 0
            cn.Close()
        End Try
    End Function

    Public Function ReplaceBadWords(ByVal str As String) As String
        If str <> "" Then
            'Dim pattern As String = "( *damn | *dyke | *fuck* | *shit* | @$$ | ahole  | amcik | andskota | anus  | arschloch | arse* | ash0le  | ash0les  | asholes  | ass  | Ass Monkey  | Assface  | assh0le  | assh0lez  | asshole  | assholes  | assholz  | assrammer | asswipe  | ayir | azzhole  | b!+ch | b!tch | b00b* | b00bs | b17ch | b1tch | bassterds  | bastard  | bastards  | bastardz  | basterds  | basterdz  | bi+ch | bi7ch | Biatch  | bitch  | bitch* | bitches  | Blow Job  | blowjob | boffing  | boiolas | bollock* | boobs | breasts | buceta | butt-pirate | butthole  | buttwipe  | c0ck  | c0cks  | c0k  | cabron | Carpet Muncher  | cawk  | cawks  | cazzo | chink | chraa | chuj | cipa | clit | clits | cnts  | cntz  | cock  | Cock* | cock-head  | cock-sucker  | cockhead  | cocks  | CockSucker  | crap  | cum  | cunt | cunt* | cunts  | cuntz  | d4mn | daygo | dego | dick  | dick* | dike* | dild0  | dild0s  | dildo  | dildos  | dilld0  | dilld0s  | dirsa | dominatricks  | dominatrics  | dominatrix  | dupa | dyke  | dziwka | ejackulate | ejakulate | Ekrem* | Ekto | enculer | enema  | f u c k  | f u c k e r  | faen | fag  | fag* | fag1t  | faget  | fagg1t  | faggit  | faggot  | fagit  | fags  | fagz  | faig  | faigs  | fanculo | fanny | fart  | fatass | fcuk | feces | feg | Felcher | ficken | fitt* | Flikker | flipping the bird  | foreskin | Fotze | Fu(* | fuck | fucker  | fuckin  | fucking  | fucks  | Fudge Packer  | fuk  | fuk* | Fukah  | Fuken  | fuker  | Fukin  | Fukk  | Fukkah  | Fukken  | Fukker  | Fukkin  | futkretzn | fux0r | g00k  | gay  | gayboy  | gaygirl  | gays  | gayz  | God-damned  | gook | guiena | h00r  | h0ar  | h0r | h0re  | h4x0r | hell | hells  | helvete | hoar  | hoer | hoer* | honkey | hoor  | hoore  | hore | Huevon | hui | injun | jackoff  | jap  | japs  | jerk-off  | jisim  | jism | jiss  | jizm  | jizz  | kanker* | kawk | kike | klootzak | knob  | knobs  | knobz  | knulle | kraut | kuk | kuksuger | kunt  | kunts  | kuntz  | Kurac | kurwa | kusi* | kyrpa* | l3i+ch | l3itch | Lesbian  | lesbo | Lezzian  | Lipshits  | Lipshitz  | mamhoon | masochist  | masokist  | massterbait  | masstrbait  | masstrbate  | masterbaiter  | masterbat* | masterbat3 | masterbate  | masterbates  | masturbat* | masturbate | merd* | mibun | mofo | monkleigh | Motha Fucker  | Motha Fuker  | Motha Fukkah  | Motha Fukker  | Mother Fucker  | Mother Fukah  | Mother Fuker  | Mother Fukkah  | Mother Fukker  | mother-fucker  | motherfucker | mouliewop | muie | mulkku | muschi | Mutha Fucker  | Mutha Fukah  | Mutha Fuker  | Mutha Fukkah  | Mutha Fukker  | n1gr  | nastt  | nazi | nazis | nepesaurio | nigga | nigger | nigger* | nigger;  | nigur;  | niiger;  | niigr;  | nutsack | orafis  | orgasim;  | orgasm  | orgasum  | oriface  | orifice  | orifiss  | orospu | p0rn | packi  | packie  | packy  | paki  | pakie  | paky  | paska* | pecker  | peeenus  | peeenusss  | peenus  | peinus  | pen1s  | penas  | penis  | penis-breath  | penus  | penuus  | perse | Phuc  | Phuck  | Phuk  | Phuker  | Phukker  | picka | pierdol* | pillu* | pimmel | pimpis | piss* | pizda | polac  | polack  | polak  | Poonani  | poontsee | poop | porn | pr0n | pr1c  | pr1ck  | pr1k  | preteen | pula | pule | pusse  | pussee  | pussy  | puta | puto | puuke  | puuker  | qahbeh | queef* | queer  | queers  | queerz  | qweers  | qweerz  | qweir  | rautenberg | recktum  | rectum  | retard  | s.o.b. | sadist  | scank  | schaffer | scheiss* | schlampe | schlong  | schmuck | screw | screwing  | scrotum | semen  | sex  | sexy  | sh!+ | Sh!t  | sh!t* | sh1t  | sh1ter  | sh1ts  | sh1tter  | sh1tz  | sharmuta | sharmute | shemale | shi+ | shipal | shit | shits  | shitter  | Shitty  | Shity  | shitz  | shiz | Shyt  | Shyte  | Shytty  | Shyty  | skanck  | skank  | skankee  | skankey  | skanks  | Skanky  | skribz | skurwysyn | slut | sluts  | Slutty  | slutz  | smut | son-of-a-bitch  | sphencter | spic | spierdalaj | splooge | suka | teets | teez | testical | testicle | testicle* | tit  | tits | titt | titt* | turd  | twat | va1jina  | vag1na  | vagiina  | vagina  | vaj1na  | vajina  | vittu | vullva  | vulva  | w00se | w0p  | wank | wank* | wetback* | wh00r  | wh0re  | whoar | whore | wichser | wop* | xrated  | xxx | yed | zabourah )"
            Dim pattern As String = "(damn|dyke|fuck|shit|ahole|amcik|andskota|anus|arschloch|arse|ash0le|ash0les|asholes|ass|AssMonkey|Assface|assh0le|assh0lez|asshole|assholes|assholz|assrammer|asswipe|ayir|azzhole|bassterds|bastard|bastards|bastardz|basterds|basterdz|Biatch|bitch|bitch|bitches|BlowJob|blowjob|boffing|boiolas|bollock|boobs|breasts|buceta|butt-pirate|butthole|buttwipe|c0ck|c0cks|c0k|cabron|CarpetMuncher|cawk|cawks|cazzo|chink|chraa|chuj|cipa|clit|clits|cnts|cntz|cock|Cock|cock-head|cock-sucker|cockhead|cocks|CockSucker|crap|cum|cunt|cunt|cunts|cuntz|d4mn|daygo|dego|dick|dick|dike|fuck|fucker|fag|fart|fatass|fcuk|feces|feg|Felcher|ficken|fitt|Flikker|flippingthebird|foreskin|Fotze|fuck|fucker|fuckin|fucking|fucks|FudgePacker|fuk|Fukah|Fuken|fuker|Fukin|Fukk|Fukkah|Fukken|Fukker|Fukkin|guiena|hoor|lootzak|knob|knobs|knobz|knulle|kraut|kuk|kuksuger|kunt|kunts|kuntz|Kurac|kurwa|kusi|kyrpa|lesbo|Lezzian|Lipshits|Lipshitz|mamhoon|masochist|masokist|massterbait|masstrbait|masstrbate|masterbaiter|masterbat|masterbat3|masterbate|masterbates|masturbat|masturbate|merd|mibun|mofo|monkleigh|MothaFucker|MothaFuker|MothaFukkah|MothaFukker|MotherFucker|MotherFukah|MotherFuker|MotherFukkah|MotherFukker|mother-fucker|motherfucker|mouliewop|muie|mulkku|muschi|MuthaFucker|MuthaFukah|MuthaFuker|MuthaFukkah|MuthaFukker|n1gr|nastt|nazi|nazis|nepesaurio|nigga|nigger|nigger*|nigger;|nigur;|niiger;|niigr;|nutsack|orafis|orgasim;|orgasm|orgasum|oriface|orifice|orifiss|orospu|p0rn|packi|packie|packy|paki|pakie|paky|paska*|pecker|peeenus|peeenusss|peenus|peinus|pen1s|penas|penis|penis-breath|penus|penuus|perse|Phuc|Phuck|Phuk|Phuker|Phukker|picka|pierdol*|pillu*|pimmel|pimpis|piss*|pizda|polac|polack|polak|Poonani|poontsee|poop|porn|pr0n|pr1c|pr1ck|pr1k|preteen|pula|pule|pusse|pussee|pussy|puta|puto|puuke|puuker|qahbeh|queef*|queer|queers|queerz|qweers|qweerz|qweir|rautenberg|recktum|rectum|retard|s.o.b.|sadist|scank|schaffer|scheiss*|schlampe|schlong|schmuck|screw|screwing|scrotum|semen|sex|sexy|sh!+|Sh!t|sh!t*|sh1t|sh1ter|sh1ts|sh1tter|sh1tz|sharmuta|sharmute|shemale|shi+|shipal|shit|shits|shitter|Shitty|Shity|shitz|shiz|Shyt|Shyte|Shytty|Shyty|skanck|skank|skankee|skankey|skanks|Skanky|skribz|skurwysyn|slut|sluts|Slutty|slutz|smut|son-of-a-bitch|sphencter|spic|spierdalaj|splooge|suka|teets|teez|testical|testicle|testicle*|tit|tits|titt|titt*|turd|twat|va1jina|vag1na|vagiina|vagina|vaj1na|vajina|vittu|vullva|vulva|w00se|w0p|wank|wank*|wetback*|wh00r|wh0re|whoar|whore|wichser|wop*|xrated|xxx|yed|zabourah)"
            str = Regex.Replace(str, pattern, String.Empty, RegexOptions.IgnoreCase)
            '
        End If
        Return str.Trim
    End Function
    Function ExecuteDataTable(ByVal sql As SqlCommand, ByVal constr As String) As DataTable
        Dim cn As New SqlConnection
        Dim kk As New DataTable
        cn.ConnectionString = constr
        cn.Open()
        sql.Connection = cn
        sql.CommandTimeout = 5000
        sql.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter(sql)
        da.Fill(kk)
        ExecuteDataTable = kk
        sql.Parameters.Clear()
        cn.Close()
        sql.Parameters.Clear()
        Return ExecuteDataTable
    End Function
    Function GetPartnerWebDetails(ByVal id As Integer) As DataTable
        Dim dt As New DataTable
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "get_SiteDetails"
            cmd.Parameters.AddWithValue("@webid", id)
            dt = ExecuteDataTable(cmd, friendshipdb)
        Catch ex As Exception

        End Try
        Return dt
    End Function
   
    Function siteactivity(ByVal act As SiteAcitvity) As Integer
        Try
            Dim cmd As New SqlCommand
            Dim sql As String = ""
            sql = "SiteActivity_Add"
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@candiid", act.candiid)
            cmd.Parameters.AddWithValue("@activity", act.activity)
            cmd.Parameters.AddWithValue("@photo", act.photo)
            cmd.Parameters.AddWithValue("@pk_Id", act.pk_Id)
            cmd.Parameters.AddWithValue("@actType", act.actType)
            cmd.Parameters.AddWithValue("@activitydate", act.activitydate)
            siteactivity = ExecuteScalar(cmd, friendshipdb)
        Catch ex As Exception
            send25("Err", "Err in Plus", "tiwariamitkumar70@gmail.com", ex.Message)
            siteactivity = 0
        End Try
    End Function
    Function ExecuteScalar(ByVal str As String, ByVal constr As String) As String
        Dim cn As New SqlConnection
        Dim kk As New DataSet
        cn.ConnectionString = constr
        Dim cmd As New SqlCommand
        cn.Open()
        cmd.Connection = cn
        cmd.CommandTimeout = 5000
        cmd.CommandType = CommandType.Text
        cmd.commandText = str
        Dim i As String = cmd.ExecuteScalar()
        cn.Close()
        ExecuteScalar = i
    End Function
End Class
