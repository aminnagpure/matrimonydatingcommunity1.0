Imports System.Data


Partial Class Quotes_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim cf As New comonfunctions

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Request.Cookies("Dom") Is Nothing Then

                Dim dt As New DataTable
                dt = cf.GetPartnerWebDetails(Request.QueryString("Dom"))
                If dt.Rows.Count > 0 Then
                    With dt
                        Response.Cookies("Dom")("ID") = .Rows(0)("WebID")
                        Response.Cookies("Dom")("TiTle") = .Rows(0)("WebsiteTitle")
                        Response.Cookies("Dom")("Quote") = .Rows(0)("WebsitePunchline")
                        Response.Cookies("Dom")("Ad1") = .Rows(0)("pub_id")
                        'Response.Cookies("Dom")("Ad2") = .Rows(0)("Ads2_ad_client")
                        'Response.Cookies("Dom")("Ad3") = .Rows(0)("Ads3_ad_client")
                        'If .Rows(0)("pub_id") <> "" Then
                        '    div_Ad1.InnerHtml = div_Ad1.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        '    div_Ad2.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        '    Response.Write(.Rows(0)("pub_id"))
                        '    ' div_LinkAd.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                        '    'div_Ad_widwSkyscraper.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

                        'End If
                    End With

                End If

            End If
            If Request.Cookies("Dom") IsNot Nothing Then
                'LiteralTitle.Text = Request.Cookies("Dom")("TiTle")
                Page.Title = Request.Cookies("Dom")("TiTle")
                ' LiteralQuote.Text = Request.Cookies("Dom")("Quote")
                'If Request.Cookies("Dom")("Ad1") <> "" Then
                '    'div_Ad.InnerHtml = Uri.EscapeDataString(Request.Cookies("Dom")("Ad1"))
                'Else

                '    div_Ad.InnerHtml = cf.DefaultAd1 ' "<script language=""javascript"">document.write( unescape('" & stAd & "' ) );</script>" 'cf.DefaultAd1 'Uri.EscapeDataString()
                'End If
                If Request.Cookies("Dom")("Ad1") <> "" Then
                    'div_Ad1.InnerHtml = div_Ad1.InnerHtml.Replace("9859010456479059", Request.Cookies("Dom")("Ad1"))
                    div_Ad2.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", Request.Cookies("Dom")("Ad1"))
                    'Response.Write(.Rows(0)("pub_id"))
                    ' div_LinkAd.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))
                    'div_Ad_widwSkyscraper.InnerHtml = div_Ad2.InnerHtml.Replace("9859010456479059", .Rows(0)("pub_id"))

                End If
            End If

        Catch ex As Exception

        End Try
        If Request.QueryString("affid") <> "" Then
            Response.Cookies("referby").Value = Request.QueryString("affid")
            Response.Cookies("referby").Expires = DateTime.Now.AddDays(60)

        End If

        If Session("mrole") = "mod" Then
            modmenu.Visible = True
        Else
            modmenu.Visible = False
        End If


    End Sub

    Protected Sub MemberLoginStatus_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberLoginStatus.LoggedOut
        Session("pid") = Nothing
        Session("fname") = ""
        Session("approved") = ""
        Session("lname") = ""
        Session("susp") = ""
        Session("validmobile") = ""
        Session("sex") = ""
        Session("mrole") = ""
        Session.Clear()
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub
    '   Function encode(ByVal str As String) As String

    '       Dim ns = ""
    '       Dim t
    '       Dim chr = ""
    '       Dim cc = ""
    '       Dim tn = ""
    '       For i As Integer = 0 To 256
    '	tn=i.toString(16);
    '           If tn.Length < 2 Then tn = "0" + tn
    '           cc += tn
    '	chr+=unescape('%'+tn)
    '       Next
    'cc=cc.toUpperCase();
    'os.replace(String.fromCharCode(13)+'',"%13");
    'for(q=0;q<os.length;q++){
    '	t=os.substr(q,1);
    '	for(i=0;i<chr.length;i++){
    '		if(t==chr.substr(i,1)){
    '			t=t.replace(chr.substr(i,1),"%"+cc.substr(i*2,2));
    '			i=chr.length;
    '		}
    '	}
    'ns+=t;
    '}
    '                   Return ns


    '   End Function
    Public Function URLEncode(ByVal StringToEncode As String, Optional ByVal _
   UsePlusRatherThanHexForSpace As Boolean = False) As String

        Dim TempAns As String = ""
        Dim CurChr As Integer
        CurChr = 1
        Do Until CurChr - 1 = Len(StringToEncode)
            Select Case Asc(Mid(StringToEncode, CurChr, 1))
                Case 48 To 57, 65 To 90, 97 To 122
                    TempAns = TempAns & Mid(StringToEncode, CurChr, 1)
                Case 32
                    If UsePlusRatherThanHexForSpace = True Then
                        TempAns = TempAns & "+"
                    Else
                        TempAns = TempAns & "%" & Hex(32)
                    End If
                Case Else
                    TempAns = TempAns & "%" & _
                         Format(Hex(Asc(Mid(StringToEncode, _
                         CurChr, 1))), "00")
            End Select

            CurChr = CurChr + 1
        Loop

        URLEncode = TempAns
    End Function


    Public Function URLDecode(ByVal StringToDecode As String) As String

        Dim TempAns As String = ""
        Dim CurChr As Integer

        CurChr = 1

        Do Until CurChr - 1 = Len(StringToDecode)
            Select Case Mid(StringToDecode, CurChr, 1)
                Case "+"
                    TempAns = TempAns & " "
                Case "%"
                    TempAns = TempAns & Chr(Val("&h" & _
                       Mid(StringToDecode, CurChr + 1, 2)))
                    CurChr = CurChr + 2
                Case Else
                    TempAns = TempAns & Mid(StringToDecode, CurChr, 1)
            End Select

            CurChr = CurChr + 1
        Loop

        URLDecode = TempAns
    End Function

End Class