<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="fouvritemem.aspx.vb" Inherits="members_fouvritemem" title="Members i like" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><div id="body">
<asp:Label ID="label1" runat="server">
</asp:Label>
    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
          OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
        PagerSettings-Mode="NumericFirstLast" Width="100%">
        
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <a href='DelFav.aspx?pid=<%# Eval("memberidfav") %>'>Delete Favorities</a><br />
                            </td>
                        </tr>
                        <tr>
                        <td>
                        <%# Eval("fname") %>&nbsp;<%# Eval("lname") %>
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
                                <a href='viewprofile.aspx?pid=<%# Eval("memberidfav") %>'>View Profile</a><br />
                            </td>
                        </tr>                        
                    </table>
                </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                <ItemTemplate>
                <a href='viewprofile.aspx?pid=<%# Eval("memberidfav")%>'>
                <asp:Image ID="img" runat="server" BorderWidth="5px" /></a>        
                </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />

                
        </Columns>
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
    </asp:GridView>
   </div> </center>
</asp:Content>

