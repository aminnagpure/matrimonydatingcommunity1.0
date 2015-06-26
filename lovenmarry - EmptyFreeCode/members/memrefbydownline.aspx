<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="memrefbydownline.aspx.vb" Inherits="members_memrefbydownline" title="Only Unpaid Members are Shown" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><div id="body">
<asp:Label ID="label1" runat="server">
</asp:Label>
   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="gridViewPublishers_PageIndexChanging" 
                runat="server" Width="80%" CellPadding="4">
       
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>     
        <tr>
        <td>
            <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)
        </td> 
        </tr>
        
        <tr>
        <td>
        Gender:<%# Eval("gender") %>
        </td>
        </tr>
        
        <tr>
        <td>
        Purpose:<%# Eval("purpose") %>
        </td>
        </tr>
        
        <tr>
        <td>
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
        <asp:Image ID="img" runat="server" BorderWidth="5px"/></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
</div>    </center>

</asp:Content>

