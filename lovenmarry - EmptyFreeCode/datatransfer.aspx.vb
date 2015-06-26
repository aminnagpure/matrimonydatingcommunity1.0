
Partial Class datatransfer
    Inherits System.Web.UI.Page

    Dim pid As String = ""
    Dim headline As String = ""
    Dim fname As String = ""
    Dim lname As String = ""
    Dim bdate As Date = Date.Now
    Dim purpose As String = ""
    Dim gender As String = ""
    Dim email As String = ""
    Dim countryid As Integer = 1
    Dim countryname As String = ""
    Dim state As String = ""
    Dim cityname As String = ""
    Dim whoami As String = ""
    Dim lookingfor As String = ""
    Dim profiledate As Date = Date.Now
    Dim LastVisited As Date = Date.Now
    Dim lastupdated As Date = Date.Now
    Dim banned As String = ""
    Dim ipaddress As String = ""
    Dim maritalstatus As String = ""
    Dim mothertounge As String = ""
    Dim height As Integer = 1
    Dim annualincome As String = ""
    Dim familydetails As String = ""
    Dim profession As String = ""
    Dim passw As String = ""
    Dim htname As String = ""
    Dim castename As String = ""
    Dim eyesight As String = ""
    Dim wt As String = ""
    Dim complexion As String = ""
    Dim caste As String = ""
    Dim cityid As String = ""
    Dim verifiedemail As String = ""
    Dim religion As String = ""
    Dim zipcode As String = ""
    Dim ref1 As String = ""
    Dim approved As String = ""
    Dim hid As String = ""
    Dim isonlinenow As String = ""
    Dim ethnic As String = ""
    Dim starsign As String = ""
    Dim haircolor As String = ""
    Dim education As String = ""
    Dim nature As String = ""
    Dim smoke As String = ""
    Dim Drink As String = ""
    Dim diet As String = ""
    Dim drugs As String = ""
    Dim children As String = ""
    Dim thoughtsofmarriage As String = ""
    Dim political As String = ""
    Dim visibletoall As String = ""
    Dim ref2 As String = ""
    Dim SqlFinalInsert As String = ""
    Dim sqlcolumns As String = ""
    Dim sqlvalues As String = ""
    Dim photoid As String = ""
    Dim photoname As String = ""
    Dim activ As String = ""




    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'profileTransfer()
        allcountryupdate()

        countrytransfer()
        'phototransfer()

    End Sub
    Sub profileTransfer()
        Try


            Dim cnaccess As New System.Data.OleDb.OleDbConnection
            Dim cmdaccess As New System.Data.OleDb.OleDbCommand
            Dim cmdupdate As New System.Data.OleDb.OleDbCommand
            Dim myreader As System.Data.OleDb.OleDbDataReader
            Dim strsql As String = ""








            'first get profile records
            strsql = "select  pid,headline,fname,lname,bdate,purpose,gender,email,countryid,countryname,state,cityname,whoami,lookingfor,profiledate,LastVisited,lastupdated,banned,ipaddress,maritalstatus,mothertounge,height,annualincome,familydetails,profession,passw,htname,castename,eyesight,wt,complexion,caste,cityid,verifiedemail,religion,zipcode,ref1,approved,hid,isonlinenow,ethnic,starsign,haircolor,education,nature,smoke,Drink,diet,drugs,children,thoughtsofmarriage,political,visibletoall,ref2 from profile where transf='N'"

            cnaccess.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
            cnaccess.Open()

            cmdaccess.Connection = cnaccess
            cmdaccess.CommandText = strsql
            myreader = cmdaccess.ExecuteReader


            While myreader.Read
                pid = myreader.GetValue(0).ToString
                headline = myreader.GetValue(1).ToString
                fname = myreader.GetValue(2).ToString
                lname = myreader.GetValue(3).ToString
                bdate = myreader.GetValue(4).ToString
                If IsDate(bdate) = False Then
                    bdate = Date.Now
                End If
                purpose = myreader.GetValue(5).ToString
                gender = myreader.GetValue(6).ToString
                email = myreader.GetValue(7).ToString
                countryid = myreader.GetValue(8)
                countryname = myreader.GetValue(9).ToString
                state = myreader.GetValue(10).ToString
                cityname = myreader.GetValue(11).ToString
                whoami = myreader.GetValue(12).ToString
                lookingfor = myreader.GetValue(13).ToString
                profiledate = myreader.GetValue(14)
                LastVisited = myreader.GetValue(15)
                lastupdated = myreader.GetValue(16)
                banned = myreader.GetValue(17).ToString
                ipaddress = myreader.GetValue(18).ToString
                maritalstatus = myreader.GetValue(19).ToString
                mothertounge = myreader.GetValue(20).ToString

                If myreader.GetValue(21) IsNot System.DBNull.Value Then
                    height = myreader.GetValue(21)
                Else
                    height = 1
                End If

                annualincome = myreader.GetValue(22).ToString
                familydetails = myreader.GetValue(23).ToString
                profession = myreader.GetValue(24).ToString
                passw = myreader.GetValue(25).ToString
                htname = myreader.GetValue(26).ToString
                castename = myreader.GetValue(27).ToString
                eyesight = myreader.GetValue(28).ToString
                wt = myreader.GetValue(29).ToString
                complexion = myreader.GetValue(30).ToString
                caste = myreader.GetValue(31).ToString
                cityid = myreader.GetValue(32).ToString
                verifiedemail = myreader.GetValue(33).ToString
                religion = myreader.GetValue(34).ToString
                zipcode = myreader.GetValue(35).ToString
                ref1 = myreader.GetValue(36).ToString
                approved = myreader.GetValue(37).ToString
                hid = myreader.GetValue(38).ToString
                isonlinenow = myreader.GetValue(39).ToString
                ethnic = myreader.GetValue(40).ToString
                starsign = myreader.GetValue(41).ToString
                haircolor = myreader.GetValue(42).ToString
                education = myreader.GetValue(43).ToString
                nature = myreader.GetValue(44).ToString
                smoke = myreader.GetValue(45).ToString
                Drink = myreader.GetValue(46).ToString
                diet = myreader.GetValue(47).ToString
                drugs = myreader.GetValue(48).ToString
                children = myreader.GetValue(49).ToString
                thoughtsofmarriage = myreader.GetValue(50).ToString
                political = myreader.GetValue(51).ToString
                visibletoall = myreader.GetValue(52).ToString
                ref2 = myreader.GetValue(53).ToString

                sqlcolumns = "insert into profile(headline,fname,lname,bdate,purpose,gender,email,countryid,countryname,state,cityname,whoami,lookingfor,profiledate,LastVisited,lastupdated,banned,ipaddress,maritalstatus,mothertounge,height,annualincome,familydetails,profession,passw,htname,castename,eyesight,wt,complexion,caste,cityid,verifiedemail,religion,zipcode,ref1,approved,hid,isonlinenow,ethnic,starsign,haircolor,education,nature,smoke,Drink,diet,drugs,children,thoughtsofmarriage,political,visibletoall,ref2) values"
                sqlvalues = "(@headline,@fname,@lname,@bdate,@purpose,@gender,@email,@countryid,@countryname,@state,@cityname,@whoami,@lookingfor,@profiledate,@LastVisited,@lastupdated,@banned,@ipaddress,@maritalstatus,@mothertounge,@height,@annualincome,@familydetails,@profession,@passw,@htname,@castename,@eyesight,@wt,@complexion,@caste,@cityid,@verifiedemail,@religion,@zipcode,@ref1,@approved,@hid,@isonlinenow,@ethnic,@starsign,@haircolor,@education,@nature,@smoke,@Drink,@diet,@drugs,@children,@thoughtsofmarriage,@political,@visibletoall,@ref2)"

                SqlFinalInsert = sqlcolumns & sqlvalues

                insertintoprofile(SqlFinalInsert)

                thenupdate("update profile set transf='Y' where pid='" & pid & "'")


            End While
            countryid = 1
            countryname = ""
            pid = ""

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub
    Sub insertintoprofile(ByVal ss As String)
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand

        Try


            cn.ConnectionString = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = ss


            cmd.Parameters.AddWithValue("@headline", headline)
            cmd.Parameters.AddWithValue("@fname", fname)
            cmd.Parameters.AddWithValue("@lname", lname)
            cmd.Parameters.AddWithValue("@bdate", bdate)
            cmd.Parameters.AddWithValue("@purpose", purpose)
            cmd.Parameters.AddWithValue("@gender", gender)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@countryid", countryid)
            cmd.Parameters.AddWithValue("@countryname", countryname)
            cmd.Parameters.AddWithValue("@state", state)
            cmd.Parameters.AddWithValue("@cityname", cityname)
            cmd.Parameters.AddWithValue("@whoami", whoami)
            cmd.Parameters.AddWithValue("@lookingfor", lookingfor)
            cmd.Parameters.AddWithValue("@profiledate", profiledate)
            cmd.Parameters.AddWithValue("@LastVisited", LastVisited)
            cmd.Parameters.AddWithValue("@lastupdated", lastupdated)
            cmd.Parameters.AddWithValue("@banned", banned)
            cmd.Parameters.AddWithValue("@ipaddress", ipaddress)
            cmd.Parameters.AddWithValue("@maritalstatus", maritalstatus)
            cmd.Parameters.AddWithValue("@mothertounge", mothertounge)
            cmd.Parameters.AddWithValue("@height", height)
            cmd.Parameters.AddWithValue("@annualincome", annualincome)
            cmd.Parameters.AddWithValue("@familydetails", familydetails)
            cmd.Parameters.AddWithValue("@profession", profession)
            cmd.Parameters.AddWithValue("@passw", passw)
            cmd.Parameters.AddWithValue("@htname", htname)
            cmd.Parameters.AddWithValue("@castename", castename)
            cmd.Parameters.AddWithValue("@eyesight", eyesight)
            cmd.Parameters.AddWithValue("@wt", wt)
            cmd.Parameters.AddWithValue("@complexion", complexion)
            cmd.Parameters.AddWithValue("@caste", caste)
            cmd.Parameters.AddWithValue("@cityid", cityid)
            cmd.Parameters.AddWithValue("@verifiedemail", verifiedemail)
            cmd.Parameters.AddWithValue("@religion", religion)
            cmd.Parameters.AddWithValue("@zipcode", zipcode)
            cmd.Parameters.AddWithValue("@ref1", ref1)
            cmd.Parameters.AddWithValue("@approved", approved)
            cmd.Parameters.AddWithValue("@hid", hid)
            cmd.Parameters.AddWithValue("@isonlinenow", isonlinenow)
            cmd.Parameters.AddWithValue("@ethnic", ethnic)
            cmd.Parameters.AddWithValue("@starsign", starsign)
            cmd.Parameters.AddWithValue("@haircolor", haircolor)
            cmd.Parameters.AddWithValue("@education", education)
            cmd.Parameters.AddWithValue("@nature", nature)
            cmd.Parameters.AddWithValue("@smoke", smoke)
            cmd.Parameters.AddWithValue("@Drink", Drink)
            cmd.Parameters.AddWithValue("@diet", diet)
            cmd.Parameters.AddWithValue("@drugs", drugs)
            cmd.Parameters.AddWithValue("@children", children)
            cmd.Parameters.AddWithValue("@thoughtsofmarriage", thoughtsofmarriage)
            cmd.Parameters.AddWithValue("@political", political)
            cmd.Parameters.AddWithValue("@visibletoall", visibletoall)
            cmd.Parameters.AddWithValue("@ref2", ref2)
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub
    Sub countrytransfer()
        Dim cnaccess As New System.Data.OleDb.OleDbConnection
        Dim cmdaccess As New System.Data.OleDb.OleDbCommand
        Dim cmdupdate As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader

        Try


            Dim strsql As String = ""

            strsql = "select COUNTRYID,countryname from country where transf='N'"
            cnaccess.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
            cnaccess.Open()

            cmdaccess.Connection = cnaccess
            cmdaccess.CommandText = strsql
            myreader = cmdaccess.ExecuteReader

            While myreader.Read
                countryid = myreader.GetValue(0)
                countryname = myreader.GetValue(1)
                insertintocountry("insert into country(countryid,countryname) values(@countryid,@countryname)")
                thenupdate("update Country set transf='Y' where countryid=" & countryid & "")
            End While

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub
    Sub insertintocountry(ByVal ss As String)
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand

        Try

            cn.ConnectionString = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = ss
            cmd.Parameters.AddWithValue("@countryid", countryid)
            cmd.Parameters.AddWithValue("@countryname", countryname)


            cmd.ExecuteNonQuery()

            cn.Close()
        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub

    Sub phototransfer()
        Dim cnaccess As New System.Data.OleDb.OleDbConnection
        Dim cmdaccess As New System.Data.OleDb.OleDbCommand
        Dim cmdupdate As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader

        Dim strsql As String = ""

        Try


            strsql = "select photoid,photoname,pid,active from photo where transf='N'"
            cnaccess.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
            cnaccess.Open()

            cmdaccess.Connection = cnaccess
            cmdaccess.CommandText = strsql
            myreader = cmdaccess.ExecuteReader

            While myreader.Read
                photoid = myreader.GetValue(0).ToString
                photoname = myreader.GetValue(1).ToString
                pid = myreader.GetValue(2).ToString
                activ = myreader.GetValue(3).ToString
                insertintophoto("insert into photo(photoid,photoname,pid,active) values(@photoid,@photoname,@pid,@active)")
                thenupdate("update photo set transf='Y' where photoid='" & photoid & "'")
            End While

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub
    Sub insertintophoto(ByVal ss As String)
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand


        cn.ConnectionString = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = ss
        cmd.Parameters.AddWithValue("@photoid", photoid)
        cmd.Parameters.AddWithValue("@photoname", photoname)
        cmd.Parameters.AddWithValue("@pid", pid)
        cmd.Parameters.AddWithValue("@active", activ)


        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Sub thenupdate(ByVal sql As String)
        Dim cmdupdate As New System.Data.OleDb.OleDbCommand
        Dim cnaccess As New System.Data.OleDb.OleDbConnection
        cnaccess.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
        cnaccess.Open()
        cmdupdate.Connection = cnaccess
        cmdupdate.CommandText = sql
        cmdupdate.ExecuteNonQuery()
        cnaccess.Close()


    End Sub
    Sub allcountryupdate()
        Dim cmdupdate As New System.Data.OleDb.OleDbCommand
        Dim cnaccess As New System.Data.OleDb.OleDbConnection
        cnaccess.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
        cnaccess.Open()
        cmdupdate.Connection = cnaccess
        cmdupdate.CommandText = "update Country set transf='N' "
        cmdupdate.ExecuteNonQuery()
        cnaccess.Close()
    End Sub
End Class
