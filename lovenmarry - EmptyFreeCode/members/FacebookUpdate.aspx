<%@ Page Title="Connect Your Account With Facebook" Language="VB" MasterPageFile="~/members/MasterPageFB.master" AutoEventWireup="false" CodeFile="FacebookUpdate.aspx.vb" Inherits="members_FacebookUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
    <div style="padding:30px;">
        <asp:HyperLink style="text-decoration:none;" CssClass="ShareButton" ID="HyperLink1" NavigateUrl="~/members/isfacebookposted.aspx" runat="server">Connect Your Account With Facebook</asp:HyperLink>
    </div>
</div>
</asp:Content>

