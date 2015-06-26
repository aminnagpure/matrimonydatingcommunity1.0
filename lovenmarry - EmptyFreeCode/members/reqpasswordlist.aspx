<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="reqpasswordlist.aspx.vb" Inherits="members_reqpasswordlist" title="Photo Password Request List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">    &nbsp;
    <asp:Label runat="server" ID="label1">
    </asp:Label>
    <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="XX-Large">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>     
        <tr>
        <td>
            <a href="grantphotoreq.aspx?pid=<%# Eval("frompid") %>">Grant Photo Request </a><br />
            
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
            <a href="../viewprofile.aspx?pid=<%# Eval("frompid") %>">View Profile </a><br />
            
        </td> 
        </tr>
        
       
        </table>
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>        
        
        <asp:ImageField DataAlternateTextField="Photoname" DataImageUrlField="photoname" DataImageUrlFormatString="../App_Themes/{0}" >        
            <ControlStyle Height="80px" Width="100px" />
        </asp:ImageField>
        
        
        <asp:TemplateField>
        <ItemTemplate>
        <table>     
        <tr>
        <td>
            <a href="delpassrequest.aspx?pid=<%# Eval("requestid") %>">Delete Password Request </a><br />
            
        </td> 
        </tr>
        
       
        </table>
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>        
        
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    </div>
</asp:Content>

