<%@ Page Language="VB" MasterPageFile="~/Quotes/MasterPage.master" AutoEventWireup="false"
    CodeFile="ViewQuotes.aspx.vb" Inherits="Quotes_ViewQuotes" Title="Untitled Page" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
<div id="fb-root"></div>

<script>    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=404461319606517";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
     <br />




    
        <table style="width: 100%">
            <tr>
                <td>
                </td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Quotes/addQuotes.aspx">Post A New Quote</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td style="width: 20%; text-align: left; vertical-align: top">
                    <table style="width: 80%">
                        <tr>
                            <td id="tdmainimg" style="height: 200px; width: 180px" runat="server">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" EmptyDataText="No Quotes found"
                                    AutoGenerateColumns="False" DataKeyNames="quotesid" Width="100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <strong>Users Recent Quotes</strong>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <a href='ViewQuotes.aspx?id=<%# Eval("quotesid") %>'>
                                                                <%#Eval("Quotessub")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                                    <RowStyle Font-Size="Small" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="Small" />
                                    <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Size="Small" />
                                    <AlternatingRowStyle />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 60%">
                    <fieldset style="border-color: Red; width: 90%">
                        <legend style="color: Green;">Quote</legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblque" Font-Bold="true" runat="server"></asp:Label>
                                    <asp:Label ID="lblqid" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td id="tdfundescr" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <td id="tdPostdate" runat="server">
                                    Post Date :
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <br />
                    <table width="400px">
                        <tr>
                            <td>
                                <table width="400px">
                                    <tr>
                                        <td width="100px">
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </td>
                                        <td style="text-align:right;">
                                            <asp:Button ID="btnDel" runat="server" Text="Delete" Visible="false"/>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                     <tr>
        <td colspan="2" runat="server" id="facebookcomment">
        <div class="fb-comments" data-href="abcd" data-width="470"></div>
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
                </td>
                <td style="width: 20%; text-align: left; vertical-align: top">
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" EmptyDataText="No Quotes found"
                        AutoGenerateColumns="False" DataKeyNames="quotesid" Width="100%" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <strong>Recents Quotes</strong>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <a href='ViewQuotes.aspx?id=<%# Eval("quotesid") %>'>
                                                    <%#Eval("Quotessub")%>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                        <RowStyle Font-Size="Small" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="Small" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Size="Small" />
                        <AlternatingRowStyle />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
