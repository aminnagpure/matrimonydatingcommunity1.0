<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="whoviewdyourprofile.aspx.vb" Inherits="members_whoviewdyourprofile" title="Who Viewed Your Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<center>
<asp:Label ID="label1" runat="server">
</asp:Label>
   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="100%" CellPadding="4">
       
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>
        <tr>
        <td align="left">
        Viewed On <%#Eval("vieweddate")%>
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
        <td style="word-wrap:break-word;word-break:break-all;width:450px;" valign="top">        
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
        
        <a href='viewprofile.aspx?pid=<%# Eval("pid")%>'>
        <asp:Image ID="img" runat="server" BorderWidth="5px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    </center></div>
</asp:Content>

