<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="FriendshipRequests.aspx.vb" Inherits="members_FriendshipRequests" title="Pending Requests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
 <table style="width: 100%">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>      <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False"
                EmptyDataText="No records found" PagerSettings-Mode="NumericFirstLast" CssClass="splfordata"
               
                runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Large" DataSourceID="ObjectDataSource1">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="XX-Large" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="Black"  HorizontalAlign="Center" Font-Size="XX-Large" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="XX-Large" />
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
       <a href="viewprofile.aspx?pid=<%# Eval("frommid") %>"><%# Eval("fname") %></a><br />
            
        
        </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField>
        <ItemTemplate>
        <a href='viewprofile.aspx?pid=<%# Eval("frommid")%>'>
        <asp:Image ID="img" runat="server" Height="80px" Width="100px" /></a>
        
        </ItemTemplate>
        </asp:TemplateField>        
        
         <asp:TemplateField>
        <ItemTemplate>
        <a href='delrequest.aspx?id=<%# Eval("fidreq")%>'>
        
        Delete Contact Request
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
                <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>
        
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetProductsPaged" TypeName="clspendingFriendsRequest" EnablePaging="True">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                        <asp:Parameter DefaultValue="10" Name="maximumRows" Type="Int32" />
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Visible="False">1=1</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table></div>
</asp:Content>

