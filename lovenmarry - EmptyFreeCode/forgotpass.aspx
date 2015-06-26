<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="forgotpass.aspx.vb" Inherits="forgotpass" title="Get Password in Your Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<%  If Page.IsPostBack = False Then%>
<br /><br />
    <table>
        <tr>
            <td>
                Email Address For your Alc</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Send Me The Password" /></td>
        </tr>
    </table>
    <% end if %>
                <asp:Label ID="Label1" Text="" runat="server"></asp:Label>
                <br /><br />
                </div>
</asp:Content>

