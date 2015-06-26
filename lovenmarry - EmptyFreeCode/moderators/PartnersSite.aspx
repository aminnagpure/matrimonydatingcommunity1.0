<%@ Page Title="Partners Website" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="PartnersSite.aspx.vb" Inherits="moderators_PartnersSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="pid" DataSourceID="SqlDataSource1">
        <Columns>
                <asp:TemplateField HeaderText="Partner Name">
                <ItemTemplate>
                <a href='viewprofile.aspx?pid=<%#Eval("pid") %>' title="Click To View Provile"><%#Eval("fname") & " " & Eval("lname") %></a></ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="mobile" HeaderText="mobile" SortExpression="mobile" />
            <asp:BoundField DataField="SiteCount" HeaderText="Total Sites" ReadOnly="True" 
                SortExpression="SiteCount" />
            <asp:BoundField DataField="pub_id" HeaderText="Pub ID" ReadOnly="True" SortExpression="pub_id" />
            <asp:TemplateField HeaderText="WebsiteLists">
                <ItemTemplate>
                   <div><%#Eval("WebsiteLists") %></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approve">
                <ItemTemplate>
                <div <%# if(Eval("IsApprove")="Y","style='Display:None;'","style='Display:Block;'")%>>
                    <asp:Button runat="server" ID="btnApprove" CommandArgument='<%#Eval("pid") %>' CommandName="Approve" Text="Approve"/>
                </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:sqlcon %>" 
        SelectCommand="get_AllPartners" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</div>
</asp:Content>

