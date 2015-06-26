<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="TopEarners.aspx.vb" Inherits="TopEarners" title="Top Earners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">

<asp:Label ID="label1" runat="server">
</asp:Label>

   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"               
                runat="server" Width="100%" CellPadding="4"  
        DataSourceID="ObjectDataSource1">
        
         
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        
        Money Earned Rs. <%#Eval("sum1")%><br /><a href="viewprofile.aspx?pid=<%# Eval("mid") %>">View Profile</a><br />
            
        
        
        Gender:<%# Eval("gender") %><br />Purpose:<%# Eval("purpose") %><br /><%#Eval("countryname")%><br/><%#Eval("state")%><br /> 
        
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>                
        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 400))%>
          </ItemTemplate>        
            <ControlStyle Width="50%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <%# Eval("ethnic") %><br />
        <%# Eval("religion") %> <br />        
        <%#Eval("caste")%><br />
         </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>
        <a href='viewprofile.aspx?pid=<%# Eval("mid")%>'>
        <asp:Image ID="img" runat="server" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    
    <table width="90%">
    <tr>
    <td align="left">
    <a href="members/affprogram.aspx"> Check Program Details</a>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" 
            TypeName="cltopearner">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                <asp:Parameter DefaultValue="10" Name="maximumRows" Type="Int32" />
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False">1=1</asp:TextBox>
    
    </td>
    </tr>
    </table></div>
</asp:Content>

