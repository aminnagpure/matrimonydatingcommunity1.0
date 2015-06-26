<%@ Page Title="Paid Members" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="Paidmembers.aspx.vb" Inherits="moderators_Paidmembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<asp:DropDownList runat="server" ID="ddlpremiumType" AutoPostBack="True">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="5">Rs. 250</asp:ListItem>
                                <asp:ListItem Value="10">Rs. 450</asp:ListItem>
                                <asp:ListItem Value="0">Rs. 4750</asp:ListItem>
                            </asp:DropDownList>
<asp:TextBox ID="txtemail" runat="server"></asp:TextBox> 
    <asp:Button ID="btnSearch" runat="server" Text="Search" />

<asp:TextBox ID="txtjointype" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox ID="txtQuery" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast" CssClass="splfor  data"
                    runat="server" Width="100%" CellPadding="3"
                    Font-Size="Small" DataSourceID="ObjectDataSource1" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="XX-Large" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" 
                        Font-Size="Large" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
                        Font-Size="XX-Large" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left; vertical-align: top;">
                                    <tr>
                                        <td style="text-align: left; vertical-align: top;">
                                            <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">
                                                <asp:Image ID="img" runat="server" Height="120px" Width="90px" /></a>
                                        </td>
                                        <td style="text-align: left; vertical-align: top;">
                                            <table style="width: 100%; text-align: left; vertical-align: top;">
                                                <tr>
                                                    <td style="width: 200px; text-align: left; vertical-align: top;">
                                                        <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">
                                                            <%# Eval("fname") %></a>(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
                                                        Gender:<%# Eval("gender") %><br />Purpose:<%# Eval("purpose") %><br /><%#Eval("countryname")%><br /><%#Eval("state")%><br /><%# Eval("cityname") %><br /><%# Eval("ethnic") %><%# Eval("religion") %><%#Eval("caste")%><br /><a href='sendmsg.aspx?pid=<%#Eval("pid") %>'>Send Message</a>
                                                    </td>
                                                    <td colspan="2" style="width: 250px;">
                                                        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 300))%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                </asp:GridView>
                &nbsp;
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetProductsPaged" TypeName="classpartnersearch" EnablePaging="True">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
                        <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
                        <asp:ControlParameter ControlID="txtquery" DefaultValue="1=1" Name="sq" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
</div>
</asp:Content>

