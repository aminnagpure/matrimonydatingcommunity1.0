<%@ Page Title="View" Language="VB" MasterPageFile="~/Partner/MasterPageLogin.master" AutoEventWireup="false" CodeFile="ViewWebsites.aspx.vb" Inherits="Partner_ViewWebsites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
                ShowHeaderWhenEmpty="True" Width="100%">
        <Columns>
           <asp:TemplateField HeaderText="Website Url">
                <ItemTemplate><a href='<%# Eval("WebsiteUrl") %>'><%# Replace(Eval("WebsiteUrl"),"http://","",1,-1,CompareMethod.Text).Replace("www.","") %></a></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="WebsiteTitle" HeaderText="Title" 
                ReadOnly="True" SortExpression="WebsiteTitle" />
            <asp:BoundField DataField="WebsitePunchline" HeaderText="Website Quote" 
                ReadOnly="True" SortExpression="WebsitePunchline" />
           
            <asp:TemplateField HeaderText="Google Adsence" >
                <ItemTemplate>
                    <a title="Click TO Edit" href='AdSenceCode.aspx?id=<%#Eval("webid") %>'><%# if(Eval("pub_id")="","Update Adsence Code",Eval("pub_id"))%></a>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField headerText="Forward Your Domain">
                <ItemTemplate>
                    <%# "http://www.yoursite.com?Dom=" & Eval("webid") & "&affid=" & Eval("candiid")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField headerText="Approval">
                <ItemTemplate>
                    <%# If(Eval("IsApprove")="N","Waiting For Approval","Approved")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <a href='EditWebsite.aspx?id=<%#Eval("webid") %>'>Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='viewMembers.aspx?id=<%#Eval("webid") %>'>View Members</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     <%--<asp:TemplateField HeaderText="Banner Ad" >
                <ItemTemplate>
                    <%# Eval("Ads1_ad_client")%><br />
                    <%# Eval("Ads1_Slot")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Big Square Ad" >
                <ItemTemplate>
                    <%# Eval("Ads2_ad_client")%><br />
                    <%# Eval("Ads2_Slot")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Link Ad" >
                <ItemTemplate>
                    <%# Eval("Ads2_ad_client")%><br />
                    <%# Eval("Ads3_Slot")%>
                </ItemTemplate>
            </asp:TemplateField>--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:sqlcon %>" 
        SelectCommand="Get_MyWebsites" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtCID" Name="candiid" PropertyName="Text" 
                Type="Int64" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:TextBox runat="server" ID="txtCID" Visible="false">0</asp:TextBox>
</div>
</asp:Content>

