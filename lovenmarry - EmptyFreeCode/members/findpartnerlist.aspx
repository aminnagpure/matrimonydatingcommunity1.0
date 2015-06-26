<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false"
    CodeFile="findpartnerlist.aspx.vb" Inherits="members_findpartnerlist" Title="Search Results" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
        <center>
            <div id="searchresults" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">1&lt;&gt;1</asp:TextBox><asp:TextBox
                    ID="txtjointype" runat="server" Visible="False"></asp:TextBox><br />
                <br />
                <asp:Label ID="label1" runat="server"></asp:Label>
                &nbsp; &nbsp;&nbsp;
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast" CssClass="splfor  data"
                    runat="server" Width="100%" CellPadding="3"
                     DataSourceID="ObjectDataSource1" >
                   
                    
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
                                                        Gender:<%# Eval("gender") %><br />
                                                        Purpose:<%# Eval("purpose") %><br />
                                                        <%#Eval("countryname")%>
                                                        <br />
                                                        <%#Eval("state")%><br />
                                                        <%# Eval("cityname") %>
                                                        <br />
                                                        <%# Eval("ethnic") %>
                                                        <%# Eval("religion") %>
                                                        <%#Eval("caste")%>
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
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="1&lt;&gt;1" Name="sq" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
               
            </div>
        </center>
    </div>
</asp:Content>
