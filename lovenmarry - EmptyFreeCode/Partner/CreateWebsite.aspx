<%@ Page Title="Create Website" Language="VB" MasterPageFile="~/Partner/MasterPageLogin.master" AutoEventWireup="false" CodeFile="CreateWebsite.aspx.vb" Inherits="Partner_CreateWebsite" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>Website Url</td>
        <td><asp:TextBox runat="server" ID="txtWebUrl"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtWebUrl" Display="Dynamic" ErrorMessage="Url Required" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtWebUrl" ErrorMessage="Url should Starts wth http://www." 
                SetFocusOnError="True" 
                ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>Website Title</td>
        <td><asp:TextBox runat="server" ID="txtWebTitle"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtWebTitle" Display="Dynamic" ErrorMessage="*" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Website Punchline</td>
        <td><asp:TextBox runat="server" ID="txtPunchLine"></asp:TextBox></td>
    </tr>
    
     <tr>
        <td></td>
        <td>
            <asp:Button ID="btnAd" runat="server" Text="Create Website And Add Adsence Code" CssClass="action-button input-submit" style="float:none;"/> </td>
    </tr>
</table>
</div>
</asp:Content>


