<%@ Page Title="" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="insertSubCategory.aspx.vb" Inherits="moderators_insertSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                Main Category</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="719px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="236px" Width="718px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td  id="tdmsg" runat="server">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
        </tr>
    </table>
</asp:Content>

