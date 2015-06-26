<%@ Page Title="" Language="VB" MasterPageFile="~/Forums/MasterPage.master" AutoEventWireup="false" CodeFile="forumsubcat.aspx.vb" Inherits="Forums_forumsubcat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
        <asp:Repeater ID="Repeater1" runat="server"  
             DataSourceID="ObjectDataSource1" >
        <ItemTemplate>
            <table  border="0.3" cellspacing="0" cellpadding ="5" width="100%" style="border-style: groove; font-size :14px;border: solid 1px #929292;">
            <tr>
                <th colspan ="2" style ="text-align :left ;"><%#Eval("lastupdate", "{0:MMMM/d/yyyy}")%></th>
            </tr>
                            <tr>
                                <td width="200px">
                                <a  href="../viewprofile.aspx?pid=<%# Eval("updatebyid") %>"><%#Eval("firstname")%></a><br />
                               <a href="../viewprofile.aspx?pid=<%# Eval("updatebyid") %>"> 
                               <asp:Image ID="imgstart" runat="server" Width="50" Height="50" />
                               </a>
                               
                                </td>
                                <td style =" vertical-align :top "><b><%#Eval("forumtitle")%></b><br />
                                <%#Eval("topicsdescription")%><br />
                                
                                <span style ="float:right ;">
                                <br />
                               
                               Total <%#Eval("TopicsCount")%><br />
                                Total <%#Eval("ReplyCount")%>
                                </span>
                                <br />
                                
                                    
                                </td>
                            </tr>
                            <tr>
                                
                                <td></td>
                            </tr>
                        </table>
         </ItemTemplate>
        </asp:Repeater>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" 
            TypeName="forumsubcategorycls">
            <SelectParameters>
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:QueryStringParameter Name="sq" QueryStringField="id" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:TextBox ID="txtsq" runat="server" Visible ="false"></asp:TextBox>
        <br />
        <span style ="float :right "> <asp:HyperLink ID="HyperLink1" style="color:#6666FF;  font-weight: bold;" runat="server">Post Topic</asp:HyperLink></span>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Cssclass="topicgrid" DataKeyNames="forumqnaid" DataSourceID="ObjectDataSource2" EmptyDataText="No Topics Found"
                     Width="100%">
                    <Columns>                    
                   
                     <asp:BoundField DataField="forumqnaid" HeaderText="Delete" ItemStyle-Width="10%" >
                    
<ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                    
                        <asp:TemplateField HeaderText="Topic" ItemStyle-Width="50%">
                        
                            <ItemTemplate>
                             <a href='viewtopic.aspx?id=<%#eval("forumqnaid") %>&tid=<%# eval("forumtopid") %>'> <%#Eval("question")%></a>
                            </ItemTemplate>

<ItemStyle Width="50%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Started By" ItemStyle-Width="20%" ItemStyle-Height="2%">
                            <ItemTemplate>
                                <a href='../viewprofile.aspx?pid=<%#eval("startedbyid") %>'>
                                    <%#Eval("startedby")%> 
                                
                                <%--<asp:Image ID="imgstart" runat="server" Width="25" Height="25" ImageUrl="App_Themes/no_avatar.gif"/>--%>
                                <asp:Image ID="img" runat="server" Height="30px" Width="30px" />
                                </a>
                                <br />
                                    <%#Eval("starteddate")%> <br />
                                 <asp:Label ID="lblreply" runat="server" Font-Size="X-Small"></asp:Label>                               
                            </ItemTemplate>

<ItemStyle Height="2%" Width="20%"></ItemStyle>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Last Update" ItemStyle-Width="20%">
                            <ItemTemplate>
                            <a href='../viewprofile.aspx?pid=<%#eval("updatebyid") %>'>
                                    <%#Eval("updatedby") %>
                                    </a><br />
                                <%#Eval("updateddate")%>
                              
                            </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Updated By">
                            <ItemTemplate>
                                 <a href='../viewprofile.aspx?id=<%#eval("updatebyid") %>'>
                                    <%#Eval("updatedby") %>
                                    </a>
                                
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                    </Columns>
                    <PagerStyle Font-Size="Large" />
                  <%--    <HeaderStyle BackColor="LightBlue" ForeColor="White" BorderWidth="1" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle Font-Size="XX-Large" />
                  <AlternatingRowStyle BackColor="Silver" />--%>
                </asp:GridView>
                <asp:Label ID="Label1" runat="server"></asp:Label><asp:TextBox ID="txtCriteria" runat="server"
                    TextMode="MultiLine" Visible="False">1</asp:TextBox>
                <asp:ObjectDataSource
                        ID="ObjectDataSource2" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="clsForumtopics">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:QueryStringParameter Name="sq" QueryStringField="id" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
    </div>

</asp:Content>

