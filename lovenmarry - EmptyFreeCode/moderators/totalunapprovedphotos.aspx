<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="totalunapprovedphotos.aspx.vb" Inherits="moderators_totalunapprovedphotos" title="UnApprove Photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:Label ID="label1" runat="server">
    </asp:Label>
    
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
        Font-Size="X-Large" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
        PagerSettings-Mode="NumericFirstLast" Width="80%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td align="left">
                                <a href='DelPic.aspx?pid=<%# Eval("photoid") %>&uid=<%# Eval("pid") %>'>Delete Photo</a><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
           <asp:TemplateField>
           <ItemTemplate>
           <img width="200px" alt='<%# Eval("photoname") %>' src='../App_Themes/<%# Eval("photoname") %>' />
           </ItemTemplate>
           </asp:TemplateField>
            
             <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <table style="font-size:12px;">
                                    <tr>
                                        <td>Full Name</td>
                                        <td><%# Eval("fname")%> <%# Eval("lname")%></td>
                                    </tr>
                                    <tr>
                                        <td>Gender</td>
                                        <td><%# Eval("gender")%></td>
                                    </tr>
                                    <tr>
                                        <td>Paid</td>
                                        <td><%# Eval("Paid")%></td>
                                    </tr>
                                    <tr>
                                        <td>Total Photo</td>
                                        <td><%# Eval("TPhoto")%></td>
                                    </tr>
                                    <tr>
                                        <td>Reg ON</td>
                                        <td><%# Eval("profiledate")%></td>
                                    </tr>
                                    <tr>
                                        <td>Last Visit</td>
                                        <td><%# Eval("LastVisited")%></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href='photogallery.aspx?pid=<%# Eval("pid") %>'>See Member Photos</a><br />
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
                                <a href='approvephoto.aspx?pid=<%# Eval("photoid") %>'>Approve Photo</a><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle Width="10%" />
            </asp:TemplateField>
            
            
            
            
            
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
    </center>
</asp:Content>

