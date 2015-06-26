<%@ Page Title="Forums" Language="VB" MasterPageFile="~/Forums/MasterPagewithads.master"
    EnableEventValidation="false" AutoEventWireup="false" CodeFile="Default.aspx.vb"
    Inherits="Forums_Default"%>
    <%@ OutputCache Duration="60" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    
    <div style="display: none">
        <table>
            <tr>
                <td>
                    User Name :-
                    <asp:TextBox ID="txtserch" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="lbtsearch" runat="server" Text="Search"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    
<div class="Forums">
    
    
    <div style="display: none">
        <table>
            <tr>
                <td>
                    User Name :-
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Search"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
<div class="module">

        <asp:Repeater ID="Repeater1" runat="server" 
        DataSourceID="SqlDataSource1" >
            <ItemTemplate>
                <table border="0.3" cellspacing="0" style="width:100%;">
                    <tr style="border-width: 1px;width:100%; border-style: solid;">
                        <th> <header><h3>
                            <table width="100%" >
                                <tr>
                                    <td style="text-align: left;width:60%">
                                        <%#Eval("Category")%>
                                    </td>
                                    <td  style="text-align: left">
                                        Last Post
                                    </td>
                                </tr>
                            </table></h3></header>
                        </th>
                    </tr>
                    <tr>
                        <td class="tab1">
                            <asp:Repeater ID="Repeater2" runat="server" DataSource='<%# GetProductsInCategory(CType(Eval("catid"), Integer)) %>'
                                EnableViewState="False" OnItemDataBound="repeater2_databound">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                
                                <ItemTemplate>
                                    <table  class="message">
                                        <tr style="cursor: pointer;">
                                            <td  class="tab2" style="width:420px" valign="top">
                                                <a href="topics.aspx?id=<%# Eval("SubCatId") %>&cid=<%# Eval("CatId") %>" >
                                                    <%# Eval("SubCatTitle") %></a>
                                                <br /><span class="Content">
                                                <%#Eval("SubCatDesc")%></span>
                                                <br /><br />
                                            </td>
                                             <td valign="top" style="width: 105px">
                                            <span  class="replay">
                                                 Threads&nbsp;: <asp:Label ID="lblr" runat="server" Font-Size="Small" CssClass="replay"
                                                    Text='<%#Eval("TopicsCount")%>'></asp:Label><br />
                                                Replys&nbsp;&nbsp;&nbsp;: <asp:Label ID="lblre" runat="server" Font-Size="Small" CssClass="replay"
                                                    Text='<%#Eval("ReplyCount")%>'></asp:Label></span>
                                           
                                            
                                            </td>
                                            <td valign="top" style="width:420px;">
                                            <a href="../viewprofile.aspx?pid=<%#Eval("pid")%>" style="text-decoration:none;">
                                            <asp:Image ID="imgstart" runat="server" Width="50" Height="50" align="left"/></a>
                                            <a href="viewtopic.aspx?tid=<%#Eval("LastTopicid")%>&cid=<%#Eval("CatId") %>" title="Click here to view this topic"><%#Eval("TopicTitle")%></a>
                                            <br />by:&nbsp;<a href="../viewprofile.aspx?pid=<%#Eval("UpdatedBy")%>" style="text-decoration:none;"><%#Eval("UpdatedByName")%></a>&nbsp;
                                            <span class="time">On&nbsp;<%#Eval("lastupdate")%></span>
                                            
                                            </td>
                                            <%-- <td width="*">
                               
                               </td>--%>
                                        </tr>
                                        
                                        </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                
            </SeparatorTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fastfastcon %>" 
        SelectCommand="getAllCategory" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="0" Name="id" 
                    PropertyName="Text" Type="Int32" />
            </SelectParameters>
    </asp:SqlDataSource>
        <asp:TextBox ID="TextBox2" runat="server" Visible="false">0</asp:TextBox>
       
        
</div>    
   
    </div>
    
</asp:Content>
