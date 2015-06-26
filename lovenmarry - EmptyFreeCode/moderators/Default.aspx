<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="moderators_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 273px;
        }
        .style2
        {
            width: 281px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<div id="aa">
    <table border='2'>
        <%--<tr>
            <td class="style1">
            </td>
            <td style="width: 276px">
            </td>
            <td>
       </td>
            <td style="width: 3px">
            </td>
        </tr>--%>
        <tr>
            <td class="style1">
                <table>
                    <tr>
                        <th>Payments Pending
                        </th>
                    </tr>
                    <tr>
                        <td>
                            Toal Payment Pending</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink12" runat="server" 
                                NavigateUrl="~/moderators/highestreferer.aspx">Highest Referer(Pending Approval)</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink13" runat="server" 
                                NavigateUrl="~/moderators/paymentapproved.aspx">Payment Approved</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Masters</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink17" runat="server" 
                                NavigateUrl="~/moderators/insertmaincategory.aspx">Add Forum Category</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink18" runat="server" 
                                NavigateUrl="~/moderators/insertSubCategory.aspx">Add Forum Sub Category</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink19" runat="server" 
                                NavigateUrl="~/moderators/addnews.aspx">Add Love Articles Category</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink20" runat="server" 
                                NavigateUrl="~/moderators/QuotesCategory.aspx">Add Love Quotes Category</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Partners</th>
                            
                    </tr>
                    <tr>
                        <td>
                            <a href="PartnersSite.aspx">View Partners</a></td>
                    </tr>
                </table>
            </td>
            <td class="style1">
            
                <table>
                    <tr >
                        <th class="style1">
                            Profiles</th>
                    </tr>
                    <tr>
                        <td>
                        <%-- <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl="~/moderators/totalmen.aspx">Total Members</asp:HyperLink>--%>
                            <asp:HyperLink ID="HyperLink2" runat="server" 
                                NavigateUrl="~/moderators/totalmember.aspx">Total Members</asp:HyperLink> &nbsp; [<asp:Label ID="lblTotMem" runat="server" Text="Label"></asp:Label>] </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink7" runat="server" 
                                NavigateUrl="~/moderators/todaysRegmem.aspx">Registerd Today</asp:HyperLink> &nbsp; [<asp:Label ID="lblRegtoday" runat="server"></asp:Label>]
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                NavigateUrl="~/moderators/todaysRegmem.aspx?type=1">Registerd Yesterday</asp:HyperLink> [<asp:Label ID="lblYesterday" runat="server"></asp:Label>]
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink8" runat="server" 
                                NavigateUrl="~/moderators/waitforapprove.aspx">UnApproved Profiles</asp:HyperLink>&nbsp; [<asp:Label ID="lblUnApproved" runat="server"></asp:Label>]
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink9" runat="server" 
                                NavigateUrl="~/moderators/totalunapprovedphotos.aspx">Unapproved Photos</asp:HyperLink>&nbsp; [<asp:Label ID="lblunApprovedPhotos" runat="server"></asp:Label>]</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink16" runat="server" 
                                NavigateUrl="~/moderators/doubtful.aspx">Doubt Ful Profiles</asp:HyperLink>&nbsp; [<asp:Label ID="lblDoubtfulprofile" runat="server" Text="Label"></asp:Label>]</td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                          <%--  <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl="~/moderators/suspendedprofiles.aspx">Suspended Profiles</asp:HyperLink>--%>
                            <asp:HyperLink ID="HyperLink15" runat="server" 
                                NavigateUrl="~/moderators/listofsuspended.aspx">Suspended Profiles</asp:HyperLink>&nbsp; [<asp:Label ID="lblsuspendedcount" runat="server" Text="Label"></asp:Label>]</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/moderators/findpartner.aspx">Search Profiles</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink14" runat="server" 
                                NavigateUrl="~/moderators/useronline.aspx">Reset Users Online</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl ="~/moderators/getpiadNonPaidmem.aspx" >Get Unpaid/paid Members</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl ="~/moderators/Paidmembers.aspx" >Paid Members</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
           <%-- <td>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>--%>
          <%--  <td style="vertical-align: top; text-align: left;">
                &nbsp;</td>--%>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td class="style2">
            <a target="_blank" href="../ImportContacts.aspx">Import Contacts</a>
            </td>
          <%--  <td>
            </td>
            <td style="width: 3px">
                </td>--%>
        </tr>
    </table>
    <br />
    <br />
    </div>
    </center>
</asp:Content>

