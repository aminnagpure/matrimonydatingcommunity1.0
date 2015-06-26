<%@ Page Title="Awaiting Members" Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="awaitingMembers.aspx.vb" Inherits="members_awaitingMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                    runat="server" Width="100%" CellPadding="3"
                    DataSourceID="ObjectDataSource1"
                    >
                    
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left; vertical-align: top;">
                                    <tr>
                                        <td style="text-align: left; vertical-align: top;">
                                            <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">
                                                <asp:Image ID="img" runat="server" BorderWidth="5px" /></a>
                                        </td>
                                        <td style="text-align: left; vertical-align: top;">
                                            <table style="width: 100%; text-align: left; vertical-align: top;">
                                                <tr>
                                                    <td style="width: 200px; text-align: left; vertical-align: top;">
                                                        <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">
                                                            <%# Eval("fname") %></a>(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
                                                        Gender:<%# Eval("gender") %><br />Purpose:<%# Eval("purpose") %><br /><%#Eval("countryname")%>,<%#Eval("state")%><br /><%# Eval("cityname") %><br /><%# Eval("ethnic") %><%# Eval("religion") %><%#Eval("caste")%><br />Interest For <%#Eval("InterestFor") %><br />
                                                        <asp:Button CommandName='Y' CommandArgument='<%# Eval("pid") %>' ID="btnAccept" runat="server" Text="Accept" /> 
                                                        <asp:Button CommandName='N' CommandArgument='<%# Eval("pid") %>' ID="BtnNotInterested" runat="server" Text="Not Interested" />
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
                    SelectMethod="GetProductsPaged" 
        TypeName="awaiting_Members_cls" EnablePaging="True">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
                        <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
                        <asp:ControlParameter ControlID="TextBox2" DefaultValue="1=1" Name="sq" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="txtCid" DefaultValue="" Name="candiid" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox runat="server" ID="txtCid" Visible="false">0</asp:TextBox>
</div>
</asp:Content>

