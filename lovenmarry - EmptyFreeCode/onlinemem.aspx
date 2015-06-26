<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="onlinemem.aspx.vb" Inherits="onlinemem" title="Members Online" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
 <div id="body">
<asp:Label ID="label1" runat="server">
</asp:Label>
   <div id="searchresults" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">1&lt;&gt;1</asp:TextBox><br />
        <br />
        <asp:Label ID="label2" runat="server"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        <br />
             <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"
               
                runat="server" Width="100%" CellPadding="4"  DataSourceID="ObjectDataSource1">
        
         
        <Columns>
        <asp:TemplateField>                  
        <ItemTemplate>        
            <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
        
        Gender:<%# Eval("gender") %><br />
        
        Purpose:<%# Eval("purpose") %><br />
        
        <%#Eval("countryname")%> <br/><%#Eval("state")%><br />  <%# Eval("cityid") %>
        
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <table width="100%">
        <tr>
        <td style="word-wrap:break-word;word-break:break-all;width:450px;" valign="top">        
        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 300))%>
        </td>
        </tr>
        </table>
        </ItemTemplate>        
            <ControlStyle Width="50%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        
        <%# Eval("ethnic") %><br />
        <%# Eval("religion") %> <br />
        
        <%#Eval("caste")%>
        
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
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
        &nbsp;
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsPaged" TypeName="classpartnersearch" EnablePaging="True">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
                <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
                <asp:ControlParameter ControlID="TextBox1" DefaultValue=" isonlinenow='Y'" 
                    Name="sq" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
    
    </div>
</center>     </div>
</asp:Content>

