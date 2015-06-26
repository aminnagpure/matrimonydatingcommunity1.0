<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="addnews.aspx.vb" Inherits="moderators_addnews" title="Write Article Page" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="style1">
        <tr>
            <td>
                News Headline
            </td>
            <td>
                <asp:TextBox ID="txtheadlines" runat="server" Width="536px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Articles Headline Required" ControlToValidate="txtheadlines"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtnewscontent" runat="server" Height="308px" Width="643px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewscontent"
                    ErrorMessage="Articles Content Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Website
            </td>
            <td>
                <asp:TextBox ID="txtwebsite" runat="server" Width="525px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Post Article" Width="138px" />
            </td>
        </tr>
    </table>
</asp:Content>
