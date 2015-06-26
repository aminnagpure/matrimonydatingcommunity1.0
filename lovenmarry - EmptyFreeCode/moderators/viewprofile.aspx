<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="viewprofile.aspx.vb" Inherits="moderators_viewprofile" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
&nbsp; &nbsp;
    <br />
    <center>
    <table id="viewp" runat="server" class="splfordata" width="90%">
        <tr>
            <td id="Td1" runat="server" colspan="2">
                <asp:HyperLink ID="removeprofile" runat="server">Delete Profile</asp:HyperLink>
             
                </td>
        </tr>
        <tr>
            <td id="Td2" runat="server" colspan="2">
            </td>
        </tr>
        <tr>
            <td id="Td3" runat="server" colspan="2">
                <asp:HyperLink ID="HyperLink3" runat="server">Suspend Profile</asp:HyperLink></td>
        </tr>
        <tr>
            <td id="Td4" runat="server" colspan="2">
            </td>
        </tr>
        <tr>
            <td id="Td5" runat="server" colspan="2">
                <asp:Label ID="lbldoubtful" runat="server" Text="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblipcountry" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td id="Td6" runat="server" colspan="2">
            </td>
        </tr>
        <tr>
            <td id="Td7" runat="server" colspan="2">
                <asp:HyperLink ID="hyperlinksengmsg" runat="server">Send Message</asp:HyperLink></td>
        </tr>
    <tr>
    <td colspan="2" id="tdheadline" runat="server"></td>
    </tr>
        <tr>
            <td id="tdipaddress" runat="server" colspan="2">
            </td>
        </tr>
        <tr>
            <td valign="top">
            
                <table>
                    <tr>
                        <td id="TD8">
                            Username</td>
                        <td id="tdusername" runat="server" style="width: 3px">
                            rt</td>
                    </tr>
                    <tr>
                        <td>
                            Password</td>
                        <td id="tdpassword" runat="server" style="width: 3px">
                            ty</td>
                    </tr>
                <tr>
                <td>Profile Id</td>
                <td runat="server" id="tdpid" style="width: 3px"></td>
                </tr>
                    <tr>
                        <td  align="left">
                            Reg Date</td>
                        <td  runat="server" id="tdregdate" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Visited Date</td>
                        <td  id="tdlastvisited" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Last Update</td>
                        <td  id="tdlastupdate" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Name</td>
                        <td  id="tdname" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top">
                            Age</td>
                        <td  id="tdage" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left">
                            Sex</td>
                        <td  id="tdsex" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Purpose</td>
                        <td id="tdpurpose" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Education</td>
                        <td  id="tdeducation" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Profession</td>
                        <td id="tdprofession" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Annual Income</td>
                        <td id="tdincome" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Religion</td>
                        <td id="tdreligion" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" id="TD9" runat="server" visible="false">
                            Caste</td>
                        <td  id="tdcaste" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            Location</td>
                        <td  id="tdlocation" runat="server" style="width: 3px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            Pin</td>
                        <td id="tdpincode" runat="server" style="width: 3px">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table>
                    <tr>
                        <td id="Td10" runat="server" colspan="2" valign="top">
                            <asp:HyperLink ID="HyperLink1" runat="server">Approve Profile</asp:HyperLink>     
                        </td>
                    </tr>
                    <tr>
                        <td id="Td11" runat="server" colspan="2" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td id="Td12" runat="server" colspan="2" valign="top">
                        <asp:HyperLink ID="HyperLink2" runat="server">Approve Profile With Photo</asp:HyperLink>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" id="tdimage" runat="server">
                        
                            </td>
                    </tr>
                    <tr>
                        <td id="Td17" runat="server" colspan="2" valign="top">
                            <asp:DropDownList runat="server" ID="ddlpremiumType">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="5">Rs. 250</asp:ListItem>
                                <asp:ListItem Value="10">Rs. 450</asp:ListItem>
                                <asp:ListItem Value="0">Rs. 4750</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlpremiumType" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Plan" Display="Dynamic" SetFocusOnError="true" ValidationGroup="PR"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Button ID="btnMarkDefaultpremium" runat="server" Text="Update Default premiumship" ValidationGroup="PR"/></td>
                    </tr>
                    <tr>
                        <td id="Td13" runat="server" colspan="2" valign="top">
                            <asp:Button ID="Button1" runat="server" Text="Approve Profile" /></td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="favcell" runat="server" style="width: 173px">
                            &nbsp;<asp:Button ID="Button2" runat="server" Text="Approve with Photo" /></td>
                        <td id="Td14" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 173px" valign="top">
                            <asp:Button ID="Button3" runat="server" Text="Edit Profile" /></td>
                        <td id="Td15" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" valign="top" style="width: 173px">
                            Race</td>
                        <td  align="left" id="tdrace" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 173px">
                            Star Sign</td>
                        <td  align="left" id="tdstarsign" runat="server" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Diet</td>
                        <td id="tddiet" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Smoke</td>
                        <td id="tdsmoke" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Drinking</td>
                        <td id="tddrinking" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Drugs</td>
                        <td id="tddrugs" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Height</td>
                        <td id="tdheight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Body Type</td>
                        <td id="tdbodytype" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Eye Sight</td>
                        <td id="tdeyesight" runat="server" align="left"  valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Complexion</td>
                        <td id="tdcomplexion" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Hair Color</td>
                        <td id="tdhaircolor" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Marital Status</td>
                        <td align="left"  valign="top" id="tdmaritalstatus" runat="server">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            First Language</td>
                        <td id="tdmothertounge" runat="server" align="left"   valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left"  valign="top" style="width: 173px">
                            Online Now</td>
                        <td id="tdonline" runat="server" align="left"     valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="tdblocked" runat="server" style="width: 173px">
                            </td>
                        <td id="Td16" runat="server" align="left" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:750px;" valign="top" align="left" id="tdaboutme" runat="server">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="word-wrap:break-word;word-break:break-all;width:750px;" valign="top" align="left" id="tdlookingfor" runat="server">
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

