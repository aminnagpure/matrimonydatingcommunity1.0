<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="paymentapproved.aspx.vb" Inherits="moderators_paymentapproved" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<center>
<asp:Label ID="label1" runat="server">
</asp:Label>

   <asp:GridView ID="gridViewPublishers" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast"               
                runat="server" Width="100%" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Font-Size="Medium" DataSourceID="ObjectDataSource1">
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
        
        Money Earned $<%#Eval("sum1")%><br />
            <a href="viewprofile.aspx?pid=<%# Eval("mid") %>">View Profile</a><br />
            
        
        
        Gender:<%# Eval("gender") %><br />
        
        Purpose:<%# Eval("purpose") %><br />
        
        
        <%#Eval("countryname")%> <br/><%#Eval("state")%><br />  <%# Eval("cityid") %>
        
        </ItemTemplate>
            <ControlStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField>
        <ItemTemplate>  
        <a href="payhim.aspx?id=<%# Eval("mid") %>">Pay Him</a><br />              
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
        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="passw" Visible="False" />
            <asp:TemplateField>
            <ItemTemplate>
            <a href="membershemade.aspx?pid=<%# Eval("mid")%>&pstatus=Approved">Members he Referd</a>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
           <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
        
    </asp:GridView>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<br />
    </center>
    <table width="90%">
    <tr>
    <td align="left">
    <a href=""> Check Program Details</a>
    
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
        <asp:TextBox ID="TextBox1" runat="server" Visible="False">r1.pstatus=&#39;Approved&#39;</asp:TextBox>
    
    </td>
    </tr>
    </table></div>
</asp:Content>

