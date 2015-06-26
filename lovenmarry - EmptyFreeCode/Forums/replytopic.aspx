<%@ Page Title="" Language="VB" MasterPageFile="~/Forums/MasterPagewithads.master" AutoEventWireup="false" CodeFile="replytopic.aspx.vb" Inherits="Forums_replytopic" ValidateRequest="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
    <p>
    <br />
</p>
<table class="style1">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Height="317px" TextMode="MultiLine" 
                Width="741px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Content Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Post Reply" />
        </td>
    </tr>
</table>
</div>
</asp:Content>

