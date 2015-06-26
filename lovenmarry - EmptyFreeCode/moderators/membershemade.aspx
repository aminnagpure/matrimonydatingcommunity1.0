<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="membershemade.aspx.vb" Inherits="moderators_membershemade" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<asp:Label ID="label1" runat="server">
</asp:Label>
   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="80%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Medium">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center" VerticalAlign="Middle"  Font-Size="XX-Large" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Silver" />
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>     
        <tr>
        <td valign="top" align="left">
        <%#Eval("ipaddress") %>        
        </td>
        </tr>
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
        <%#Eval("countryname")%> <br/><%#Eval("state")%><br />  <%# Eval("cityid") %>
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
        <td <%--style="word-wrap:break-word;word-break:break-all;--%> width:450px;" valign="top">        
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
        <td  style="font-size:16px;"><%# Eval("ethnic") %></td>
        </tr>
        <tr>
        <td  style="font-size:16px;"><%# Eval("religion") %> </td>
        <tr>
        <td style="font-size:10px;">
        <%#Eval("caste")%>
        </td>
        </tr>
        </tr>
        </table>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <a href="approveLead.aspx?id=<%# Eval("pid")%>">Approve Lead</a> <br />
        <a href='viewprofile.aspx?pid=<%# Eval("pid")%>'>
        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    </center>
</asp:Content>

