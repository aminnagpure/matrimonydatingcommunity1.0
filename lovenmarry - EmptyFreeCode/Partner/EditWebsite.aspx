<%@ Page Title="Edit" Language="VB" MasterPageFile="~/Partner/MasterPageLogin.master" AutoEventWireup="false" CodeFile="EditWebsite.aspx.vb" Inherits="Partner_EditWebsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>Website Url</td>
        <td>
            <asp:Label ID="lblUrl" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>Website Title</td>
        <td><asp:TextBox runat="server" ID="txtWebTitle"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Website Punchline</td>
        <td><asp:TextBox runat="server" ID="txtPunchLine"></asp:TextBox></td>
    </tr>
   <%-- <tr>
        <td>Google Ads<br />(size:728 X 90)</td>
        <td><table><tr><td>Client ID</td><td><asp:TextBox runat="server" ID="txtAd1_ClientID" ></asp:TextBox></td></tr>
        <tr><td>Ad Slot</td><td><asp:TextBox runat="server" ID="txtAd1_Slot" ></asp:TextBox></td>
        </tr>
        </table>
        </td>
    </tr>
    <tr>
        <td>Google Ads<br />(Size:336 X 280)</td>
        <td><table><tr><td>Client ID</td><td><asp:TextBox runat="server" ID="txtAd2_ClientID"></asp:TextBox></td></tr>
        <tr><td>Ad Slot</td><td><asp:TextBox runat="server" ID="txtAd2_Slot" ></asp:TextBox></td>
        </tr>
        </table>
        
        </td>
    </tr>
    <tr>
        <td>Google Ads<br />(Size:Links Ad)</td>
        <td><table><tr><td>Client ID</td><td><asp:TextBox runat="server" ID="txtAd3_ClientID"></asp:TextBox></td></tr>
        <tr><td>Ad Slot</td><td><asp:TextBox runat="server" ID="txtAd3_Slot" ></asp:TextBox>
        </td>
        </tr>
        </table>
        </td>
    </tr>--%>
     <tr>
        <td></td>
        <td>
            <asp:Button ID="btnUpdate" runat="server" Text="Udate Website" CssClass="action-button input-submit" style="float:none;"/> </td>
    </tr>
</table>
</div>
</asp:Content>


