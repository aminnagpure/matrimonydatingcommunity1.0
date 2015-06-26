<%@ Page Title="Stop Invites" Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="stopemails.aspx.vb" Inherits="stopemails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
    <br />
    <br />
    <br />
    <table style="width: 90%">
        <tr>
            <td colspan="2">
                We respect your privacy, and you do not want anymore invites from us, kindly input
                the email address you wish to block</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Your Email"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="439px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Block My Email" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    <br />
    </div>
</asp:Content>

