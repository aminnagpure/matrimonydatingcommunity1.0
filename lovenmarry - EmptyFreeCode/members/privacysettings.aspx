<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="privacysettings.aspx.vb" Inherits="members_privacysettings" title="Privacy Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">    <table style="width:100%">
        <tr>
            <td>
                Visibility</td>
            <td>
                <asp:CheckBox ID="chkvisibleall" runat="server" Text="Visible to All (Even Un Registered Members)" /></td>
<td rowspan="6" valign="top">

<iframe name="webads" width="200" height="200" id="webads" frameBorder="0" marginWidth="0" marginHeight="0" scrolling="no" vspace="0" hspace="0" allowTransparency="allowtransparency" src="http://www.websolnetwork.com/websolads.aspx?adid=27"></iframe>

</td>
        </tr>
        <tr>
            <td>
                Password Protect Photo</td>
            <td>
                <asp:CheckBox ID="chkphotpassword" runat="server" AutoPostBack="True" />
                <asp:TextBox ID="txtphotopassword" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:CheckBox ID="chkEmailfromAdmin" runat="server" Text="Email From Admin" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:CheckBox ID="chkoffers" runat="server" Text="Offer Emails" /></td>
        </tr>
        <tr>
            <td>
                Match Alert</td>
            <td align="left">
                <asp:CheckBox ID="chkMatchAlert" runat="server" Text="Match Alert" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" /></td>
        </tr>

    </table>
    <asp:Label ID="Label1" runat="server" ForeColor="Blue"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="Blue"></asp:Label><br />
    </div>
</asp:Content>

