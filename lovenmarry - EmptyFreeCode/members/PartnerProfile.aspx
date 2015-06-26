<%@ Page Title="My Desired Partner Profile" Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="PartnerProfile.aspx.vb" Inherits="members_PartnerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<table>
<tr>
    <td colspan="2"><center><h2>My Partner Profile</h2></center></td>
</tr>
     <tr>
                                            <td>
                                                Religion
                                            </td>
                                            <td>
                                            <asp:UpdatePanel runat="server" ID="updateCast">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="dpreligion" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="">Any</asp:ListItem>
                                                        <asp:ListItem>Hindu</asp:ListItem>
                                                        <asp:ListItem>Christian</asp:ListItem>
                                                        <asp:ListItem>Muslim</asp:ListItem>
                                                        <asp:ListItem>Jain</asp:ListItem>
                                                        <asp:ListItem>Sikh</asp:ListItem>
                                                        <asp:ListItem>Jew</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="TD1" runat="server" >
                                                Caste
                                            </td>
                                            <td>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCast" runat="server">
                                                       <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="TD2" runat="server">
                                                Mother Tounge
                                            </td>
                                            <td>
                                            
                                                 <asp:DropDownList ID="ddlMotherToung" runat="server">
                                                      
                                                    </asp:DropDownList>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td>
                                               Height
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMinHeight" runat="server" Width="109">
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
                                                To
                                                <asp:DropDownList ID="ddlMaxHeight" runat="server" Width="109">
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
                                                    <asp:ListItem Value="27" Selected="True">7.(2.13 mts)</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Age
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                
                                                <asp:DropDownList ID="ddlAgeMin" runat="server" AutoPostBack="True" Width="109">
                                                    <asp:ListItem>18</asp:ListItem>
                                                </asp:DropDownList>
                                                To
                                                <asp:DropDownList ID="ddlAgeMax" runat="server" Width="109">
                                                    <asp:ListItem>18</asp:ListItem>
                                                </asp:DropDownList>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                                
                                        <tr>
                                            <td>
                                                Body Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpbodytype" runat="server">
                                                    <asp:ListItem Value="">Any</asp:ListItem>
                                                    <asp:ListItem>Slim</asp:ListItem>
                                                    <asp:ListItem>Average</asp:ListItem>
                                                    <asp:ListItem>Athletic</asp:ListItem>
                                                    <asp:ListItem>Slightly OverWeight</asp:ListItem>
                                                    <asp:ListItem>Over Weight</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Skin Color
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpskincolor" runat="server">
                                                    <asp:ListItem Value="">Any</asp:ListItem>
                                                    <asp:ListItem>Dark</asp:ListItem>
                                                    <asp:ListItem>Fair</asp:ListItem>
                                                    <asp:ListItem>Very Fair</asp:ListItem>
                                                    <asp:ListItem>White</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Hair Color
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dphaircolor" runat="server">
                                                    <asp:ListItem Value="">Any</asp:ListItem>
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
                                            <td>
                                                Star Sign
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpstarsign" runat="server">
                                                    <asp:ListItem Value="">Any</asp:ListItem>
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
                                            <td>
                                                Marital Status
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpmaritalstatus" runat="server">
                                                    <asp:ListItem Value=""></asp:ListItem>
                                                    <asp:ListItem>Never Married</asp:ListItem>
                                                    <asp:ListItem>Divorced</asp:ListItem>
                                                    <asp:ListItem>Widow</asp:ListItem>
                                                    <asp:ListItem>Married But Looking</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Annual Income
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtanualincome" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Education
                                            </td>
                                            <td>
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
                                            <td>
                                                Diet
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpDiet" runat="server">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Veg</asp:ListItem>
                                                    <asp:ListItem>Non-Veg</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Drinks
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpDrinks" runat="server">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Dont Drink</asp:ListItem>
                                                    <asp:ListItem>Socail Drinking</asp:ListItem>
                                                    <asp:ListItem>Drinks Like a Fish</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Smoke
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpSmoke" runat="server">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Non-Smoker</asp:ListItem>
                                                    <asp:ListItem>Social Smoker</asp:ListItem>
                                                    <asp:ListItem>Smoker</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Drugs
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dpDrugs" runat="server">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>Druggi</asp:ListItem>
                                                    <asp:ListItem>No Drugs</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td><asp:Button Text="Save" ID="btnSave" runat="server"/></td>
                                        </tr>
</table>
</div>
</asp:Content>

