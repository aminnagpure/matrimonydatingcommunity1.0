<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="doubtfulprofiles.aspx.vb" Inherits="moderators_doubtfulprofiles" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 These Profiles could be possible scammers<br />
    we mark profiles from nigeria, senegal as doubtful profiles<br />
    <center>
<asp:Label ID="label1" runat="server"></asp:Label>
    <br />
    
      <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
            Font-Size="Medium" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
            PagerSettings-Mode="NumericFirstLast" Width="80%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="XX-Large" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                        <tr>
                        <td align="left" valign="top">
                        Ipaddress:<%#Eval("ipaddress")%>
                        </td>
                        </tr>
                            <tr>
                               <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Email:<%# Eval("email") %><br />
                                    Password:<%# Eval("passw") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        Gender:<%# Eval("gender") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        Purpose:<%# Eval("purpose") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        <%#Eval("countryname")%> 
                                    <br />
                                    <%#Eval("state")%>
                                    <br />
                                    <%# Eval("cityid") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ControlStyle Width="10%" />
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <a href='editreg.aspx?pid=<%# Eval("pid") %>'>Edit Profile</a><br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="word-wrap: break-word; word-break: break-all; width: 450px;" valign="top">
        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 400))%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ControlStyle Width="50%" />
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td style="font-size: 16px;">
                                    <%# Eval("ethnic") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 16px;">
                                    <%# Eval("religion") %> 
                                </td>
                                <tr>
                                    <td style="font-size: 10px;">
        <%#Eval("caste")%>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField AccessibleHeaderText="imgname" DataAlternateTextField="photoname"
                    DataImageUrlField="photoname" DataImageUrlFormatString="../App_Themes/{0}" NullImageUrl="../App_Themes/no_avatar.gif">
                    <ControlStyle Height="80px" Width="100px" />
                </asp:ImageField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <a href='removeprofile.aspx?pid=<%# Eval("pid") %>'>Delete Profile</a><br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
            <ItemTemplate>           
           <a href='sendmsg.aspx?pid=<%# Eval("pid") %>'>Send Message</a><br />
            </ItemTemplate>
            </asp:TemplateField>
            
            </Columns>
            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        </asp:GridView>
        <br />
    </center>

</asp:Content>

