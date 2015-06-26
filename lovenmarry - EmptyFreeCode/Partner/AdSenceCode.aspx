<%@ Page Title="Google Adsence" Language="VB" MasterPageFile="~/Partner/MasterPageLogin.master" AutoEventWireup="false" CodeFile="AdSenceCode.aspx.vb" Inherits="Partner_AdSenceCode" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
    <script type="text/javascript">
//  function Encode() {
//   var value = (document.getElementById('ctl00_ContentPlaceHolder1_txtAd1_ClientID').value);
//   value = value.replace('<', "&lt;");
//   value = value.replace('>', "&gt;");
//   document.getElementById('ctl00_ContentPlaceHolder1_txtAd1_ClientID').value = value;

//   value = (document.getElementById('ctl00_ContentPlaceHolder1_txtAd2_ClientID').value);
//   value = value.replace('<', "&lt;");
//   value = value.replace('>', "&gt;");
//   document.getElementById('ctl00_ContentPlaceHolder1_txtAd2_ClientID').value = value;

//   value = (document.getElementById('ctl00_ContentPlaceHolder1_txtAd3_ClientID').value);
//   value = value.replace('<', "&lt;");
//   value = value.replace('>', "&gt;");
//   document.getElementById('ctl00_ContentPlaceHolder1_txtAd3_ClientID').value = value;

//  }
 </script>
    <style type="text/css">
        #txtADCODE
        {
            height: 160px;
            width: 264px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <table width="100%">
    <tr>
        <td>&nbsp;</td>
        <td><h6>Copy And Paste Your Google Ads pub code</h6></td>
        <td rowspan="3">
            <img src="../images/pub.GIF" alt=""/>
        </td>
    </tr>
   <%-- <tr>
        <td>Google Ads<br />
        (Size:728 X 90)<br />
            (Leaderboard)
            
        </td>
        <td><asp:TextBox runat="server" ID="txtAd1_ClientID" TextMode="MultiLine" Height="119px" Width="241px"></asp:TextBox>
                
                
        </td>
    </tr>
    <tr>
        <td>Google Ads<br />(Size:336 X 280)<br />
            (Large rectangle)</td>
        <td><asp:TextBox runat="server" ID="txtAd2_ClientID" TextMode="MultiLine" Height="119px" Width="241px"></asp:TextBox>
        
        
        </td>
    </tr>
    <tr>
        <td>
            
            Links Ad</td>
                <td><asp:TextBox runat="server" ID="txtAd3_ClientID" TextMode="MultiLine" Height="119px" Width="241px"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td>
            
             Google Ads<br />(Size  160 X 600)<br />Wide Skyscraper</td>
                <td><asp:TextBox runat="server" ID="txtAd4_ClientID" TextMode="MultiLine" Height="119px" Width="241px"></asp:TextBox>
        
        </td>
    </tr>--%>
    <tr>
        <td>Pub ID</td>
        <td><asp:TextBox runat="server" ID="txtPub"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Label runat="server" ID="lblMsg"></asp:Label></td>
    </tr>
    <tr>
        <td></td>
        <td><table><tr><td>
            <asp:Button ID="btnUpdate" runat="server" Text="Update Adsence Code" 
                CssClass="action-button input-submit" style="float:none; height: 26px;" /></td><td> <a href="ViewWebsites.aspx">Back To website List</a></td></tr></table> </td>
        <td>&nbsp;</td>
    </tr>
</table>
</div>
</asp:Content>

