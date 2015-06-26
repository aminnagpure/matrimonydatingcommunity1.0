<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false"
    CodeFile="browsemembers.aspx.vb" Inherits="browsemembers" Title="Browse Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div id="body">
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">hid='N' and approved='Y' and DateDiff(yyyy,profile.bdate,getdate())&gt;=18</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gridview1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast" runat="server"
                        Width="100%" CellPadding="4" 
                        DataSourceID="ObjectDataSource1">
                        
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">View Profile</a><br />
                                                Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)
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
                                                <%#Eval("state")%><br />
                                                <%# Eval("cityid") %>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ControlStyle Width="10%" />
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='viewprofile.aspx?pid=<%# Eval("pid")%>'>
                                        <asp:Image ID="img" runat="server" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="passw" Visible="False" />
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="classpartnersearch" EnablePaging="True">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
