<%@ Page Language="VB" MasterPageFile="~/Forums/MasterPagewithads.master" AutoEventWireup="false" CodeFile="topics.aspx.vb" Inherits="moderators_topics" title="Untitled Page" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="SecondBar" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
       function comfirmdel() {
           return confirm("Are you sure you wish to delete this topic?");
       }
    </script>

    
       <table style="background-image: url('../Images/HorizontalLine.gif'); background-repeat: repeat-x;width: 100%;margin-left:-1px;" class="Forums">
    <tr><td>
                    
                    <br />
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MainTable">
                        <tr class="theader">
                            <th width="150" id="tdstartdate" runat="server" class="time" style="color:White;" colspan ="2"></th>
                            
                        </tr>
                        <tr>
                            <td valign="top" class="UserDetails" style="width: 150px;">
                                <div id="divStartedby" runat="server" class="Content UserName"></div>
                                <asp:Image ImageUrl="~/App_Themes/no_avatar.gif" runat="server" ID="imgposter" style="width:50px"/>
                                <div id="divTotalTopic" runat="server" class="Content"></div>
                            </td>
                            <td class="contentArea" valign="top">
                                <div class="Content" runat="server" id="divTopic"></div>
                                <hr size="1" style="color:#CECECE; background-color:#CECECE">
                                <div runat="server" id="divTopicDesc" class="contentDesc" style="min-height:78px;"></div>
                                <asp:HyperLink ID="HyperLink1"  runat="server" class="delbutton">Post New Topic</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" Width="100%"              
                        DataKeyNames="TopicId" DataSourceID="ObjectDataSource1"
                        EmptyDataText="No Topics Found" GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left"> 
                                <ItemTemplate>
                                    <a href='../viewprofile.aspx?pid=<%#eval("CandiId") %>'><asp:Image ID="img" runat="server" Height="30px" Width="30px" /></a>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Topic" HeaderStyle-HorizontalAlign="Left"> 
                                <ItemTemplate>
                                <div class="tab1"><a href='viewtopic.aspx?tid=<%#eval("TopicId") %>' >
                                        <%#Eval("TopicTitle")%></a></div>
                                       
                                        By: <span class="Content"> <a href='../viewprofile.aspx?pid=<%#eval("CandiId") %>' title="Click to view Priofile"><%#Eval("fname")%></a></span>
                                    <span class="time">&nbsp;On&nbsp;<%#Eval("starteddate")%></span>
                                </ItemTemplate>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Replies">
                            <HeaderStyle HorizontalAlign="Left" Width="60"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"/>
                            <ItemTemplate>
                            
                                    <%#Eval("ReplayCount")%>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Update" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle VerticalAlign="Top" Width="160"/>
                                <ItemTemplate>
                               
                               <span class="Content">By:&nbsp;<a href='../viewprofile.aspx?pid=<%#eval("UpdateCandiId") %>' title="Click to view Priofile"><%#Eval("UpdateCandiName") %></a></span><br />
                               <span class="time">&nbsp;On:&nbsp;<%#Eval("updatedate")%></span>
                                </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:TemplateField>
                            
                        <asp:BoundField DataField="TopicId" HeaderText="Delete">
                                <ItemStyle Width="50px" HorizontalAlign="Center"/>
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle Font-Size="Large" />
                        <%--    <HeaderStyle BackColor="LightBlue" ForeColor="White" BorderWidth="1" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle Font-Size="XX-Large" />
                  <AlternatingRowStyle BackColor="Silver" />--%>
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server"></asp:Label><asp:TextBox ID="txtCriteria" runat="server"
                        TextMode="MultiLine" Visible="False">1</asp:TextBox>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="clsForumtopics">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="txtCriteria" Name="sq" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
          
        </table>
        <asp:HiddenField ID="forumqnaid" runat="server" />
   
</asp:Content>

