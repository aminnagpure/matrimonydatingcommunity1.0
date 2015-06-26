<%@ Page Language="VB" MasterPageFile="~/Quotes/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Quotes_Default" title="Love Quotes" %>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
        <table style="width: 100%">
            <tr>
                <td>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Quotes/addQuotes.aspx">Post A New Quote</asp:HyperLink>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        EmptyDataText="No Quotes Found" Width="100%" 
                        DataSourceID="ObjectDataSource1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td colspan="4">
                                                <strong><a href="ViewQuotes.aspx?id=<%# Eval("quotesid") %>">
                                                    <%#Eval("Quotessub")%></a></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                           <%--     <asp:Rating ID="Rating1" runat="server" MaxRating="5" CurrentRating='<%#Eval("Rating")%>'
                                                    CssClass="ratingStar" StarCssClass="ratingItem" WaitingStarCssClass="Saved" FilledStarCssClass="Filled"
                                                    ReadOnly="true" EmptyStarCssClass="Empty" Width="100%">
                                                </asp:Rating>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Posted By :
                                                <%#Eval("Username")%>
                                                Date :<%#Eval("quotesdate")%></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" 
                        TypeName="clsShowAllQuotes">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                            <asp:Parameter DefaultValue="300" Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


