<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="contactus.aspx.vb" Inherits="contactus" title="Contact Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="body">
<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=404461319606517";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <table  cellpadding ="5" width="100%">
    <tr>
        <td>
        <table>
                <tr>
                    <td>
                      Name  
                    </td><td>
                        <asp:TextBox ID="txtname" runat="server" Width="232px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtname" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" Width="232px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Subject</td>
                    <td>
                        <asp:TextBox ID="txtSub" runat="server" Width="232px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtSub" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Message</td>
                    <td>
                        <asp:TextBox ID="txtcomments" TextMode="MultiLine" runat="server" 
                            Height="150px" Width="280px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtcomments" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               
                <tr>
                    <td align="right">Enter Character: </td>
                        <td>
                            <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Captcha.aspx" Height="27px" style="padding:0;margin-bottom:-8px;"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="*" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        If You Have any Complaints Or Problem <a href="UserComplaints.aspx">Click Here</a>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Submit" /></td>
                </tr>
            </table>
        </td>
    </tr>
        <tr>
            <td>



<div class="fb-comments" data-href="http://www.yoursite.com" data-width="470"></div>
</td>
<td style="width:360px">
  
</td>
        </tr>
        
        <tr>
        <td colspan="2" runat="server" id="googlecomments">
        <script src="https://apis.google.com/js/plusone.js"></script>
<g:comments
    href="http://www.yoursite.com"
    width="642"
    first_party_property="BLOGGER"
    view_type="FILTERED_POSTMOD">
</g:comments>
        </td>
        </tr>
    </table>

</div>    
</asp:Content>

