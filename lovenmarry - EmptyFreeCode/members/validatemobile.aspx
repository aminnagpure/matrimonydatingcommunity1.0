<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="validatemobile.aspx.vb" Inherits="members_validatemobile" title="Validate Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body"><center>
<asp:TextBox ID="txtmobileno" runat="server" Visible="False"></asp:TextBox><br />
    <asp:TextBox ID="txtvalidationcode" runat="server" Visible="False">?</asp:TextBox><br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="#C00000"></asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Check Code" />

</center></div>
</asp:Content>

