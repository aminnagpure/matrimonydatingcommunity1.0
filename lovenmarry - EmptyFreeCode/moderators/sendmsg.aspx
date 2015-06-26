<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="sendmsg.aspx.vb" Inherits="moderators_sendmsg" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <table>
        <tr>
            <td align="left">
                Subject :<asp:TextBox ID="txtsubject" runat="server" Width="347px">Message From Admin</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server" Columns="50" MaxLength="2000" Rows="10"
                    TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="Send Message" Width="132px" /></td>
        </tr>
    </table>
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </center>
    
</asp:Content>

