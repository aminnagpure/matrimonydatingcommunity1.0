<%@ Page Title="Partner Program" Language="VB" MasterPageFile="~/Partner/MasterPageLogin.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Partner_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <meta property="og:title" content="Love N Marry" />
<div id="fb-root"></div>
<script>    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=404461319606517";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
     <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td colspan="2" align="center">
            <h3>
                Partner Menu
            </h3>
            <hr />
        </td>
    </tr>
        <tr>
            <td align="center">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Partner/CreateWebsite.aspx">Create Website</asp:HyperLink>
            </td>
            <td align="center" style="line-height:60px;">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Partner/ViewWebsites.aspx">View Website</asp:HyperLink>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table style="width: 100%">
                    <tr>
                        <td>
                            Total Members
                            </td>
                        <td>
                            : <asp:Label ID="lblreferals" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="120">
                            Money Earned </td>
                        <td>
                            : <span class="WebRupee">Rs.</span> <asp:Label ID="lblmoneyearned" runat="server" Text="Label"></asp:Label>&nbsp;Pending</td>
                    </tr>
                    <tr>
                        <td>
                            Amount Approved
                            </td>
                        <td>
                           : <span class="WebRupee">Rs.</span> <asp:Label ID="lblAmtApproved" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Amount Paid&nbsp;</td>
                        <td>
                            : <span class="WebRupee">Rs.</span> <asp:Label ID="lblAmountPaid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        
    </table>
</div>
</asp:Content>

