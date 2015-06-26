<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="reflink.aspx.vb" Inherits="members_reflink" title="Referal Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">    <table width="90%">
        <tr>
            <td align="left">
            </td>
            <td id="TD1" runat="server" align="left">
            </td>
        </tr>
        <tr>
            <td>
                Your Referal Link</td>
            <td align="left">
                <asp:TextBox ID="txtreflink" runat="server" Width="571px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                email Content<br />
                Copy and Paste Content and Send Email To Your Friends</td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server" Height="228px" TextMode="MultiLine" Width="561px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
	<td>&nbsp;</td>
	<td  class="table-2" style="width:auto;padding:9px;">Referal Account Summary</td>
        </tr>
        <tr>
	<td>
		<asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/members/directmemreferd.aspx">View Refered Members</asp:LinkButton>
	</td>
            <td rowspan="4" style="padding:2px;" class="lightBorder">
            <table style="width: 100%">
                    <tr>
                        <td>
                            Total Referals
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
        
        <tr>
            	<td>
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/members/affprogram.aspx">Referal Program Terms</asp:LinkButton>
            </td>
        </tr>
        
        <tr>
            
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server" 
                    PostBackUrl="~/members/Tutorials.aspx">Watch video Tutorials</asp:LinkButton>
            </td>
        </tr>
        
        <tr>
            
            <td>
                           <asp:HyperLink ID="HyperLink10" runat="server" 
                                NavigateUrl="~/JoinUs.aspx">Share on Social Networking</asp:HyperLink>
                        </td>
        </tr>
        <tr>
            
            <td><br />
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table></div>
</asp:Content>

