Imports System.Data.SqlClient
Imports System.Data

Partial Class members_PartnerProfile
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateAge()
            'PopulateAgeMax()
            populateMotherToung()
            'getCast()
            Loaddata()
        End If
    End Sub

    Protected Sub ddlAgeMin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAgeMin.SelectedIndexChanged
        PopulateAgeMax()
    End Sub
#Region "Load Default values"

    Sub populateMotherToung()
        'Exit Sub

        Dim North() As String = {"Hindi/ Delhi", "Hindi /Madhya Pradesh / Bundelkhand / Chattisgarhi", "Hindi/U.P./Awadhi/ Bhojpuri/Garhwali", "Punjabi", "Bihari/Maithili/Magahi", "Rajasthani / Marwari / Malwi / Jaipuri", "Haryanvi", "Himachali/Pahari", "Kashmiri/Dogri", "Sindhi", "Urdu"}
        Dim West() As String = {"Marathi", "Gujarati / Kutchi", "Hindi /Madhya Pradesh / Bundelkhand / Chattisgarhi", "Konkani", "Sindhi"}
        Dim South() As String = {"Tamil", "Telugu", "Kannada", "Malayalam", "Tulu", "Urdu"}
        Dim East() As String = {"Bengali", "Oriya", "Assamese", "Sikkim/ Nepali/ Lepcha/ Bhutia/ Limbu"}
        Dim Eng() As String = {"English"}


        Dim item As New ListItem
        item.Text = "Any"
        item.Value = ""
        ddlMotherToung.Items.Add(item)

        item = New ListItem
        item.Text = "North"
        item.Attributes("Group") = "North"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)

        For Each L As String In North
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "North"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "West"
        item.Attributes("Group") = "West"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)

        For Each L As String In West
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "West"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "South"
        item.Attributes("Group") = "South"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)
        For Each L As String In South
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "South"

            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "East"
        item.Attributes("Group") = "East"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "color:gray;font-weight: bold;")
        item.Attributes.Add("disabled", "true")
        ddlMotherToung.Items.Add(item)
        For Each L As String In East
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "East"
            ddlMotherToung.Items.Add(item)
        Next

        item = New ListItem
        item.Text = "-------"
        item.Attributes("Group") = "------"
        item.Attributes.Add("disabled", "disabled")
        item.Attributes.Add("style", "font-weight: bold;")
        item.Attributes.Add("disabled", "true")

        For Each L As String In Eng
            item = New ListItem
            item.Text = L
            item.Attributes("Group") = "Englist"
            ddlMotherToung.Items.Add(item)
        Next

    End Sub
    Sub PopulateAge()
        ddlAgeMin.Items.Clear()
        For x As Integer = 18 To 99
            ddlAgeMin.Items.Add(x)
        Next
    End Sub
    Sub PopulateAgeMax()
        Dim selAge As Integer = ddlAgeMax.SelectedItem.Value
        ddlAgeMax.Items.Clear()
        For x As Integer = ddlAgeMin.SelectedValue + 1 To 99
            ddlAgeMax.Items.Add(x)
        Next
        Dim LI As New ListItem
        LI = ddlAgeMax.Items.FindByText(selAge)
        If ddlAgeMax.Items.Contains(LI) Then
            ddlAgeMax.SelectedIndex = ddlAgeMax.Items.IndexOf(LI)
        End If

    End Sub
    Sub getCast(Optional ByVal Rel As String = "")
        Dim cmd As New SqlCommand
        cmd.CommandText = "Get_Cast_List"
        If Rel <> "" Then
            cmd.Parameters.AddWithValue("@Rel", Rel)
        End If
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)
        ddlCast.DataSource = ds.Tables(0)
        ddlCast.DataTextField = "Cast_N"
        ddlCast.DataValueField = "Cast_N"
        ddlCast.DataBind()

        Dim li As New ListItem
        li.Text = "Any"
        li.Value = ""
        ddlCast.Items.Insert(0, li)
        If Rel = "" Then
            li = New ListItem
            li.Text = "Other"
            li.Value = "0"
            ddlCast.Items.Add(li)
        End If
    End Sub

    Sub Loaddata()
        Dim pid As Integer = 0
        Try
            pid = Session("pid")
        Catch ex As Exception

        End Try
        Dim cmd As New SqlCommand
        cmd.CommandText = "GET_PartenerProfile"
        cmd.Parameters.AddWithValue("@candiid", pid)
        Dim ds As New DataSet
        ds = cf.ExecuteDataset(cmd)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlAgeMin.SelectedIndex = ddlAgeMin.Items.IndexOf(ddlAgeMin.Items.FindByValue(ds.Tables(0).Rows(0)("P_MinAge")))
            PopulateAgeMax()
            ddlAgeMax.SelectedIndex = ddlAgeMax.Items.IndexOf(ddlAgeMax.Items.FindByValue(ds.Tables(0).Rows(0)("P_MaxAge")))
            ddlMinHeight.SelectedIndex = ddlMinHeight.Items.IndexOf(ddlMinHeight.Items.FindByValue(ds.Tables(0).Rows(0)("P_MinHeight")))
            ddlMaxHeight.SelectedIndex = ddlMaxHeight.Items.IndexOf(ddlMaxHeight.Items.FindByValue(ds.Tables(0).Rows(0)("P_MaxHeight")))
            dpreligion.SelectedIndex = dpreligion.Items.IndexOf(dpreligion.Items.FindByValue(ds.Tables(0).Rows(0)("P_Religion")))
            getCast(dpreligion.SelectedItem.Value)
            ddlCast.SelectedIndex = ddlCast.Items.IndexOf(ddlCast.Items.FindByValue(ds.Tables(0).Rows(0)("P_cast")))
            ddlMotherToung.SelectedIndex = ddlMotherToung.Items.IndexOf(ddlMotherToung.Items.FindByText(ds.Tables(0).Rows(0)("P_motherTounge")))
            dpskincolor.SelectedIndex = dpskincolor.Items.IndexOf(dpskincolor.Items.FindByText(ds.Tables(0).Rows(0)("P_SkinColor")))
            dphaircolor.SelectedIndex = dphaircolor.Items.IndexOf(dphaircolor.Items.FindByText(ds.Tables(0).Rows(0)("P_HairColor")))
            dpSmoke.SelectedIndex = dpSmoke.Items.IndexOf(dpSmoke.Items.FindByText(ds.Tables(0).Rows(0)("P_Smoke")))
            dpstarsign.SelectedIndex = dpstarsign.Items.IndexOf(dpstarsign.Items.FindByText(ds.Tables(0).Rows(0)("P_StarSign")))
            dpbodytype.SelectedIndex = dpbodytype.Items.IndexOf(dpbodytype.Items.FindByText(ds.Tables(0).Rows(0)("P_BodyType")))
            dpmaritalstatus.SelectedIndex = dpmaritalstatus.Items.IndexOf(dpmaritalstatus.Items.FindByText(ds.Tables(0).Rows(0)("P_MStatus")))
            If ds.Tables(0).Rows(0)("P_Income") <> 0 Then
                txtanualincome.Text = Convert.ToDouble(ds.Tables(0).Rows(0)("P_Income"))
            End If
            dpDiet.SelectedIndex = dpDiet.Items.IndexOf(dpDiet.Items.FindByText(ds.Tables(0).Rows(0)("P_Diet")))
            dpDrinks.SelectedIndex = dpDrinks.Items.IndexOf(dpDrinks.Items.FindByText(ds.Tables(0).Rows(0)("P_Drinks")))
            dpDrugs.SelectedIndex = dpDrugs.Items.IndexOf(dpDrugs.Items.FindByText(ds.Tables(0).Rows(0)("P_Drugs")))
            dpeducation.SelectedIndex = dpeducation.Items.IndexOf(dpeducation.Items.FindByText(ds.Tables(0).Rows(0)("P_Education")))
        End If

    End Sub
#End Region
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cmd As New SqlCommand
        Dim incom As Double = 0
        Try
            incom = Convert.ToDouble(txtanualincome.Text.Trim)
        Catch ex As Exception

        End Try
        cmd.CommandText = "Update_PartenerProfile"
        cmd.Parameters.AddWithValue("@candiid", Session("pid"))
        cmd.Parameters.AddWithValue("@P_BodyType", dpbodytype.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Diet", dpDiet.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Drinks", dpDrinks.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Drugs", dpDrugs.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Education ", dpeducation.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_HairColor ", dphaircolor.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Income", incom)
        cmd.Parameters.AddWithValue("@P_MStatus", dpmaritalstatus.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_MaxAge ", ddlAgeMax.SelectedItem.Value)
        cmd.Parameters.AddWithValue("@P_MaxHeight ", ddlMaxHeight.SelectedItem.Value)
        cmd.Parameters.AddWithValue("@P_MinAge ", ddlAgeMin.SelectedItem.Value)
        cmd.Parameters.AddWithValue("@P_MinHeight ", ddlMinHeight.SelectedItem.Value)
        cmd.Parameters.AddWithValue("@P_Religion", dpreligion.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_SkinColor", dpskincolor.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_Smoke", dpSmoke.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_StarSign", dpstarsign.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_cast", ddlCast.SelectedItem.Value)
        cmd.Parameters.AddWithValue("@P_motherTounge", ddlMotherToung.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@P_HEight_Name", ddlMinHeight.SelectedItem.Text & " To " & ddlMaxHeight.SelectedItem.Text)
        Dim i As Integer = cf.ExecuteNonQuery(cmd)
        btnSave.Text = "Updated sucessfully"
        Response.Redirect("default.aspx")

    End Sub

    Protected Sub dpreligion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpreligion.SelectedIndexChanged
        getCast(dpreligion.SelectedItem.Value)
    End Sub
End Class
