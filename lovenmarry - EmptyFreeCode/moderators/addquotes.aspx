<%@ Page Title="" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="addquotes.aspx.vb" Inherits="moderators_addquotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
  <p>
        <br />
    </p>
    <p>
                <asp:TextBox ID="txtshare" runat="server" Width="518px" 
                    Height="86px"></asp:TextBox>
                </p>
    <p>
                <asp:Button ID="btnshare" runat="server" Text="Share" 
                    Width="96px" />
                    <asp:CustomValidator runat="server" id="cusCustom" 
                    controltovalidate="txtshare" onservervalidate="cusCustom_ServerValidate" 
                    errormessage="You Must Say Something meaningful" SetFocusOnError="True" 
                    ValidateEmptyText="True" />
    </p></div>
</asp:Content>

