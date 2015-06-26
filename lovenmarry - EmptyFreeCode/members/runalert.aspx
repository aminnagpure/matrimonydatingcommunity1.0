<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="runalert.aspx.vb" Inherits="members_runalert" title="Run Alert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body"><div id="searchresults" runat="server">
    <asp:Label ID="Label1" runat="server"></asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">1&lt;&gt;1</asp:TextBox><asp:TextBox
        ID="txtjointype" runat="server" Visible="False"></asp:TextBox><asp:TextBox ID="TextBox2"
            runat="server" Visible="False"></asp:TextBox><br />
    <asp:GridView ID="gridview1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="ObjectDataSource1" EmptyDataText="No records found" CssClass="splfordata"
        Font-Size="Large" ForeColor="#333333" GridLines="None" PagerSettings-Mode="NumericFirstLast"
        Width="80%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" Font-Size="XX-Large" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    
                                <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
                            
        Gender:<%# Eval("gender") %><br />
                            
        Purpose:<%# Eval("purpose") %><br />
                            
        <%#Eval("countryname")%> 
                                <br />
                                <%#Eval("state")%>
                                <br />
                                <%# Eval("cityid") %>
                            
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table width="100%">
                        <tr>
                            <td style="word-wrap: break-word; word-break: break-all; width: 450px;" valign="top">
                                <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 300))%>
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
                        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetProductsPaged" TypeName="classpartnersearch">
        <SelectParameters>
            <asp:Parameter Name="startRowIndex" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="maximumRows" Type="Int32" DefaultValue="0" />
            <asp:ControlParameter ControlID="txtjointype" Name="jointype" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBox1" Name="sq" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp; &nbsp;&nbsp;
        
    
    </div>
    </div>
</asp:Content>

