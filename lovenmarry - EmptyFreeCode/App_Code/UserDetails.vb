Imports Microsoft.VisualBasic

Public Class UserDetails
    Sub New()

    End Sub
    Public Property pid As String
    Public Property CANDIidold As String
    Public Property regdate As String
    Public Property Passw As String
    Public Property email As String
    Public Property fname As String
    Public Property lname As String
    Public Property dateofbirth As DateTime
    Public _gender As String
    Public Property gender() As String
        Get
            If _gender.ToUpper = "M" Then
                Return "Male"
            Else
                Return "Female"
            End If
        End Get
        Set(ByVal value As String)
            If value.ToUpper = "MALE" Then
                _gender = "M"
            Else
                _gender = "F"
            End If

        End Set
    End Property
    Public Property address1 As String
    Public Property address2 As String
    Public Property address3 As String
    Public Property pincode As String
    Public Property Telephone As String
    Public Property mobile As String
    Public Property cityid As String
    Public Property cityname As String
    Public Property stateid As String
    Public Property statename As String
    Public Property countryname As String
    Public Property countryid As String
    Public Property education As String
    Public Property TotalExp As String
    Public Property CVlocation As String
    Public Property Enddate As String
    Public Property LastLogin As String
    Public Property imagename As String
    Public Property imageext As String
    Public Property emailverified As String
    Public Property Activated As String
    Public Property Verified As String
    Public Property blocked As String
    Public Property mth As String
    Public Property profiletype As String
    Public Property Friendshipzone As String
    Public Property Remail As String
    Public Property Purpose As String
    Public Property referdby As String
    Public Property referdbyold As String
    Public Property banned As String
    Public Property showgads As String
    Public Property ipaddress As String
    Public Property industryid As String
    Public Property industryname As String
    Public Property jobcategoryid As String
    Public Property jobcategoryname As String
    Public Property designation As String
    Public Property companyname As String
    Public Property keywords As String
    Public Property university As String
    Public Property certification As String
    Public Property certifications As String
    Public Property isbouncing As String
    Public Property adminemails As String
    Public Property Jobalerts As String
    Public Property EmailfromEmployers As String
    Public Property emailsent As String
    Public Property hide As String
    Public Property filextension As String
    Public Property isonlinenow As String
    Public Property photo As String
    Public Property photopassw As String
    Public Property Smsjobalerts As String
    Public Property SmsEmployerAlert As String
    Public Property SmsInspirationalQuotes As String
    Public Property SmsFunnyQuotes As String
    Public Property isValidMobile As String
    Public Property smsOffers As String
    Public Property smsAdmin As String
    Public Property photoapproved As String
    Public Property approvedFProfile As String
    Public Property ipcountry As String
    Public Property isdoubtful As String
    Public Property sponsoremail As String
    Public Property hasinvited As String
    Public Property bayt As String
    Public Property profileheadline As String
    Public Property Ethnicity As String
    Public Property religion As String
    Public Property caste As String
    Public Property starsign As String
    Public Property maritalstatus As String
    Public Property lang As String
    Public Property htid As String
    Public Property htname As String
    Public Property wt As String
    Public Property skincolor As String
    Public Property eyesight As String
    Public Property aboutme As String
    Public Property diet As String
    Public Property drinks As String
    Public Property smoke As String
    Public Property drugs As String
    Public Property Susp As String
    Public Property sponsorsent As String
    Public Property ref1val As String
    Public Property baytmember As String
    Public Property pstatus As String
    Public Property visibleinSearchengine As String
    Public Property showpvtinfo As String
    Public Property schoolname As String
    Public Property schoolyear As String
    Public Property collename As String
    Public Property colyear As String
    Public Property companywebsite As String
    Public Property allowprofilecomments As String
    Public Property FrinedshipRequests As String
    Public Property KnowsEmailCanAdd As String
    Public Property blacklistedemail As String
    Public Property newsnFun As String
    Public Property exportedTowebsol As String
    Public Property mrole As String
    Public Property shine As String
    Public Property referdurl As String
    Public Property bouncemarkexptowebsol As String
    Public Property facebookposted As String
    Public Property FB_ID As String
    Public Property GPlusUrl As String

End Class
Public Class LoginIds
    Public Property PID As String
    Public Property Fname As String

End Class
Public Class SiteAcitvity
    Public Property ActID As Integer
    Public Property candiid As Integer
    Public Property activity As String
    Private Property _date As DateTime
    Public Property activitydate As DateTime
        Get
            If _date = Nothing Then
                Return Date.Now
            Else
                Return _date
            End If

        End Get
        Set(ByVal value As DateTime)
            If value = Nothing Then
                _date = Date.Now
            Else
                _date = value
            End If

        End Set
    End Property
    Public Property pk_Id As Integer
    Public Property actType As String
    Public Property photo As String
    Public Property fn As String
       
End Class