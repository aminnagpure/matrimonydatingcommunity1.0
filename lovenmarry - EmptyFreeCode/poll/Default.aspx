<%@ Page Title="Take a Poll" Language="VB" MasterPageFile="~/poll/MasterPageWOLogin.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="poll_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
    .tab1 a{margin-top:4px;margin-bottom:4px;}
    .tab2 a{margin-top:4px;margin-bottom:4px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
        <table style="width: 100%">
            <tr>
                <td>
                    <br />
                    <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td><asp:HyperLink class="Mybutton" ID="HyperLink1" runat="server" NavigateUrl="CreateQue.aspx" Width="150">Post A New Poll</asp:HyperLink>
                    </td><td>
                    <asp:HyperLink class="Mybutton" ID="HyperLink2" runat="server" NavigateUrl="~/poll/Default.aspx?view=Mypoll" Width="220">View poll You have Taken</asp:HyperLink>
                    </td></tr></table>
                    <br />
                    
                </td>
            </tr>
            <tr>
                <td valign="top">
                
                    <div class="module">
                    <header><h3>Poll</h3></header>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                    CssClass="module_content" ShowHeader="false" GridLines="None" 
                    EmptyDataText="No Poll Found" Width="98%" DataSourceID="ObjectDataSource1">
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate >
                                    <table class="" style="width:100%">
                                        <tr >
                                            <td class="tab1" colspan="2"  style="width:940px;font-size:15px;padding-top:5px;padding-left:5px;" align="left">
                                                <a href="polet.aspx?id=<%# Eval("Sno") %>" title="Click To Take this Poll">
                                                    <%#Eval("QsnDesc")%></a>
                                            </td>
                                        </tr>
                                  
                                        <tr>
                                            <td class="contentDesc" style="padding-top:5px;padding-left:5px;" align="left">
                                                Created By :
                                                <%#Eval("Username")%>&nbsp;
                                                <span class="time" style="float:none;">On :<%#Eval("CreationDate")%></span>
                                            </td>
                                            <td width="140px" class="contentDesc">
                                                <div style="margin-bottom:1px;">Poll Taken by <%#Eval("PoleTaken")%> People</div>
                                                <div>Commented by <%#Eval("CommentsTotal")%> People</div>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="message" />
                               </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" 
                        TypeName="ClsShowAllPoll" EnablePaging="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                            <asp:Parameter DefaultValue="300" Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue=" 1=1 " Name="sq" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
