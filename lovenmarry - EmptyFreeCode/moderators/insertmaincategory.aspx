<%@ Page Title="" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="insertmaincategory.aspx.vb" Inherits="moderators_insertmaincategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                Title</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="479px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="133px" Width="482px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td id="tdmsg" runat="server">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Insert main Category" />
            </td>
        </tr>
    </table>
</asp:Content>

