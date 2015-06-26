<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="editreg.aspx.vb" Inherits="moderators_editreg" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

function ismaxlength(obj)
{
var mlength=obj.getAttribute? parseInt(obj.getAttribute("maxlength")) : ""
if (obj.getAttribute && obj.value.length>mlength)
obj.value=obj.value.substring(0,mlength)


}
function textCounter(field, countfield, maxlimit) 
 { 
  if (field.value.length > maxlimit)
   {
    field.value = field.value.substring(0, maxlimit);
   }
  else
   {
    countfield.value = maxlimit - field.value.length;
   }
 }




</script>
    <center>
        <table width="90%">
            <tr>
                <td>
                </td>
                <td align="left">

<asp:Wizard ID="reg" runat="server" ActiveStepIndex="0" Width="50%" style="background-color: inactivecaptiontext" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Login Details">
        <table class="splfordata">
        <tr>
        <td>Password
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpassword"
                ErrorMessage="Password Cannot Be Blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
        <td>
        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        </td>
        </tr>
            <tr>
                <td>
                    Profile Headline<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ControlToValidate="txtheadline" Display="Dynamic" ErrorMessage="Profile Headline Required To Make it Catchy"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtheadline" runat="server"></asp:TextBox>
                </td>
            </tr>
        <tr>
        <td>
        First Name
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfname"
                Display="Dynamic" ErrorMessage="First Name Cannot Be Blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td><td><asp:TextBox ID="txtfname" runat="server"></asp:TextBox></td>
        </tr>
            <tr>
                <td>
                    Last Name<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtlastname" Display="Dynamic" ErrorMessage="Last Name Cannot Be Blank"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <script language='javascript' src="popcalendar.js"></script>
                    Birth Date<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="txtbirthdate" ErrorMessage="Birth Date Cannot Be Blank"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtbirthdate" runat="server"></asp:TextBox>
                       <% If cf.dtformat = "dd/mm/yyyy" Then%>
                     <script language='javascript'>
	if (!document.layers)
		{
		document.write("<input type=button onclick='popUpCalendar(this, aspnetForm.ctl00_ContentPlaceHolder1_reg_txtbirthdate, \"dd/mm/yyyy\")' value='select' style='font-size:12px;font-weight: bold;font-color:black' >")
		}
                            </script>
        <%Else%>
                     <script language='javascript'>
	if (!document.layers)
		{
		document.write("<input type=button onclick='popUpCalendar(this, aspnetForm.ctl00_ContentPlaceHolder1_reg_txtbirthdate, \"mm/dd/yyyy\")' value='select' style='font-size:12px;font-weight: bold;font-color:black' >")
		}
                            </script>

        <% end if %>
                </td>
            </tr>
            <tr>
                <td>
                    Email<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                        Display="Dynamic" ErrorMessage="Email Cannot Be Blank" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                        Display="Dynamic" ErrorMessage="Check Email Address" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Gender<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="gender"
                        Display="Dynamic" ErrorMessage="Gender Required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RadioButtonList ID="gender" runat="server">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    Race</td>
                <td>
                    <asp:DropDownList ID="dpRace" runat="server">
                        <asp:ListItem>NON Caucasian</asp:ListItem>
                        <asp:ListItem>Black</asp:ListItem>
                        <asp:ListItem>Caucasian/White</asp:ListItem>
                        <asp:ListItem>Hispanic</asp:ListItem>
                        <asp:ListItem>Indian</asp:ListItem>
                        <asp:ListItem>Middle Eastern</asp:ListItem>
                        <asp:ListItem>Native American</asp:ListItem>
                        <asp:ListItem>Asian</asp:ListItem>
                        <asp:ListItem>Mixed Race</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Religion</td>
                <td>
                    <asp:DropDownList ID="dpreligion" runat="server">
                        <asp:ListItem>Hindu</asp:ListItem>
                        <asp:ListItem>Christain</asp:ListItem>
                        <asp:ListItem>Muslim</asp:ListItem>
                        <asp:ListItem>Jain</asp:ListItem>
                        <asp:ListItem>Sikh</asp:ListItem>
                        <asp:ListItem>Jew</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td id="TD1" runat="server" visible="False">
                    Caste</td>
                <td>
                    <asp:TextBox ID="txtcaste" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td id="TD2" runat="server" visible="False">
                    Mother Tounge</td>
                <td>
                    <asp:TextBox ID="txtmothertounge" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Purpose</td>
                <td>
                    <asp:DropDownList ID="dppurpose" runat="server">
                        <asp:ListItem>Friendship</asp:ListItem>
                        <asp:ListItem>Dating</asp:ListItem>
                        <asp:ListItem>Marriage</asp:ListItem>
                        <asp:ListItem>Timepass</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Physical Details">
            <table class="splfordata">
                <tr>
                    <td style="width: 100px">
                    Height
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpheight" runat="server">
                            <asp:ListItem Value="1">4.10(1.47 mts)</asp:ListItem>
                            <asp:ListItem Value="2">4.11(1.50 mts)</asp:ListItem>
                            <asp:ListItem Value="3">5.0(1.52 mts)</asp:ListItem>
                            <asp:ListItem Value="4">5.1(1.55 mts)</asp:ListItem>
                            <asp:ListItem Value="5">5.2(1.58 mts)</asp:ListItem>
                            <asp:ListItem Value="6">5.3(1.60 mts)</asp:ListItem>
                            <asp:ListItem Value="7">5.4(1.63 mts)</asp:ListItem>
                            <asp:ListItem Value="8">5.5(1.65 mts)</asp:ListItem>
                            <asp:ListItem Value="9">5.6(1.68 mts)</asp:ListItem>
                            <asp:ListItem Value="10">5.7(1.70 mts)</asp:ListItem>
                            <asp:ListItem Value="11">5.8(1.73 mts)</asp:ListItem>
                            <asp:ListItem Value="12">5.9(1.75 mts)</asp:ListItem>
                            <asp:ListItem Value="13">5.10(1.78 mts)</asp:ListItem>
                            <asp:ListItem Value="14">5.11(1.80 mts)</asp:ListItem>
                            <asp:ListItem Value="15">6.0(1.83 mts)</asp:ListItem>
                            <asp:ListItem Value="16">6.1(1.85 mts)</asp:ListItem>
                            <asp:ListItem Value="17">6.2(1.88 mts)</asp:ListItem>
                            <asp:ListItem Value="18">6.3(1.91 mts)</asp:ListItem>
                            <asp:ListItem Value="19">6.4(1.93 mts)</asp:ListItem>
                            <asp:ListItem Value="20">6.5(1.96 mts)</asp:ListItem>
                            <asp:ListItem Value="21">6.6(1.98 mts)</asp:ListItem>
                            <asp:ListItem Value="22">6.7(2.01 mts)</asp:ListItem>
                            <asp:ListItem Value="23">6.8(2.03 mts)</asp:ListItem>
                            <asp:ListItem Value="24">6.9(2.06 mts)</asp:ListItem>
                            <asp:ListItem Value="25">6.10(2.08 mts)</asp:ListItem>
                            <asp:ListItem Value="26">6.11(2.11 mts)</asp:ListItem>
                            <asp:ListItem Value="27">7.(2.13 mts)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Body Type</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpbodytype" runat="server">
                            <asp:ListItem>Slim</asp:ListItem>
                            <asp:ListItem>Average</asp:ListItem>
                            <asp:ListItem>Athletic</asp:ListItem>
                            <asp:ListItem>Slightly OverWeight</asp:ListItem>
                            <asp:ListItem>Over Weight</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        EyeSight</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpeyesight" runat="server">
                            <asp:ListItem>Clear</asp:ListItem>
                            <asp:ListItem>Glasses</asp:ListItem>
                            <asp:ListItem>Lens</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Skin Color</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpskincolor" runat="server">
                            <asp:ListItem>Dark</asp:ListItem>
                            <asp:ListItem>Fair</asp:ListItem>
                            <asp:ListItem>Very Fair</asp:ListItem>
                            <asp:ListItem>White</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Hair Color</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dphaircolor" runat="server">
                            <asp:ListItem>Black</asp:ListItem>
                            <asp:ListItem>Brown</asp:ListItem>
                            <asp:ListItem>Blond</asp:ListItem>
                            <asp:ListItem>White</asp:ListItem>
                            <asp:ListItem>Red</asp:ListItem>
                            <asp:ListItem>Bald</asp:ListItem>
                            <asp:ListItem>Golden</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Star Sign</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpstarsign" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Aquarius</asp:ListItem>
                            <asp:ListItem>Aries</asp:ListItem>
                            <asp:ListItem>Cancer</asp:ListItem>
                            <asp:ListItem>Capricorn</asp:ListItem>
                            <asp:ListItem>Gemini</asp:ListItem>
                            <asp:ListItem>Leo</asp:ListItem>
                            <asp:ListItem>Libra</asp:ListItem>
                            <asp:ListItem>Pisces</asp:ListItem>
                            <asp:ListItem>Sagittarius</asp:ListItem>
                            <asp:ListItem>Scorpio</asp:ListItem>
                            <asp:ListItem>Taurus</asp:ListItem>
                            <asp:ListItem>Virgo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Marital Status</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpmaritalstatus" runat="server">
                            <asp:ListItem>Never Married</asp:ListItem>
                            <asp:ListItem>Divorced</asp:ListItem>
                            <asp:ListItem>Widow</asp:ListItem>
                            <asp:ListItem>Married But Looking</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep3" runat="server" Title="Professional Details">
            <table class="splfordata">
                <tr>
                    <td style="width: 100px">
                        Education</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpeducation" runat="server">
                            <asp:ListItem>High School</asp:ListItem>
                            <asp:ListItem>Graduate Degree</asp:ListItem>
                            <asp:ListItem>Phd Post doctoral</asp:ListItem>
                            <asp:ListItem>Associated Degree</asp:ListItem>
                            <asp:ListItem>Some College</asp:ListItem>
                            <asp:ListItem>Masters Degree</asp:ListItem>
                            <asp:ListItem>Can Read N Write</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Current Profession</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtprofession" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Annual Income</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtanualincome" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep4" runat="server" Title="Location Details">
            <table class="splfordata">
                <tr>
                    <td style="width: 100px; height: 24px">
                        Country</td>
                    <td style="width: 100px; height: 24px">
                        <asp:DropDownList ID="dpcountry" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        State</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtstate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        City</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Pincode</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtpincode" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep5" runat="server" Title="About me &amp; Partner">
            <table class="splfordata">
                <tr>
                    <td style="width: 100px">
                        About Me<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="aboutme"
                            Display="Dynamic" ErrorMessage="Write atleast 100 Words About Yourself" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        &nbsp;
                    </td>
                    <td style="width: 100px" align="left" valign="top">                        
                        <textarea id="aboutme" runat="server" cols="60" maxlength="700" onkeydown="textCounter(this,this.form.descriptionleft,700);"
                            onkeyup="return ismaxlength(this)" rows="10" style="overflow: hidden"></textarea>
                        Characters Left:<input maxlength="3" name="descriptionleft" readonly="readonly" size="3"
                            style="border-right: 0px; border-top: 0px; font-size: 15px; border-left: 0px;
                            color: #000; border-bottom: 0px; font-family: Arial" value="700" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Looking For
                    </td>
                    <td style="width: 100px">
                        <textarea id="lookingfor" runat="server" cols="60" maxlength="500" onkeydown="textCounter(this,this.form.descriptionleft2,500);"
                            onkeyup="return ismaxlength(this)" rows="10" style="overflow: hidden"></textarea>
                        Characters Left:<input maxlength="3" name="descriptionleft2" readonly="readonly"
                            size="3" style="border-right: 0px; border-top: 0px; font-size: 15px; border-left: 0px;
                            color: #000; border-bottom: 0px; font-family: Arial" value="500" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
            </table>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep6" runat="server" Title="Diet Details">
            <table class="splfordata">
                <tr>
                    <td style="width: 100px">
                        Diet</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpDiet" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Veg</asp:ListItem>
                            <asp:ListItem>Non-Veg</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Drinks</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpDrinks" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Dont Drink</asp:ListItem>
                            <asp:ListItem>Socail Drinking</asp:ListItem>
                            <asp:ListItem>Drinks Like a Fish</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Smoke</td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dpSmoke" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Non-Smoker</asp:ListItem>
                            <asp:ListItem>Social Smoker</asp:ListItem>
                            <asp:ListItem>Smoker</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 21px">
                        Drugs</td>
                    <td style="width: 100px; height: 21px">
                        <asp:DropDownList ID="dpDrugs" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Druggi</asp:ListItem>
                            <asp:ListItem>No Drugs</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </asp:WizardStep>
    </WizardSteps>
    <StepStyle Font-Size="0.8em" ForeColor="#333333" />
    <NavigationStyle BorderColor="White" ForeColor="#0000C0" />
    <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
    <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
    <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
    <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
        Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
</asp:Wizard>

    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label></td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </center>
    <center>
        &nbsp;&nbsp;
<script language="javascript">
   try
    {
    document.aspnetForm.ctl00_ContentPlaceHolder1_reg_txtbirthdate.readOnly=true;
      } 
      catch(e)
    {
    //err
    }
   
   
   </script>
    </center>
</asp:Content>

