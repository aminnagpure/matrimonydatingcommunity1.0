<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="members_login" title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div id="body">
     <div>
   
    <table width="100%">
        <tr>
            <td>
            </td>
            <td align="left" id="sky-form" class="sky-form">
            
    <asp:Login ID="Login1" runat="server" class="one_half">
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;"  width="100%" >
                <tr>
                    <td>
                    <header>
            Log<strong>in</strong>
            </header>
                        <table cellpadding="0" width="100%" >
                          
                            <tr>
                                
                                <td>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                <br />
                                    <label class="input"><i class="icon-append icon-user"></i><asp:TextBox ID="UserName" runat="server"></asp:TextBox></label>
                                    
                                </td>
                            </tr>
                            <tr>
                                
                                <td>
                                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label> <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                 
                                 <br />

                                    <label class="input"><i class="icon-append icon-key"></i><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></label> 
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                        ValidationGroup="Login1" CssClass="button" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PlusSignIn.aspx">Register if You dont have a Alc</asp:HyperLink><br />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <br />
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/forgotpass.aspx">if You Dont Remember Your Password Click Here</asp:HyperLink></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
            
        </td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
     
            </td>
            <td>
            </td>
        </tr>
    </table>
   </div>
</div>
</asp:Content>

