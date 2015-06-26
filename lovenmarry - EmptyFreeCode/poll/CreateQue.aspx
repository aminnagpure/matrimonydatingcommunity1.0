<%@ Page Title="" Language="VB" MasterPageFile="~/poll/MasterPage.master" AutoEventWireup="false"
    CodeFile="CreateQue.aspx.vb" Inherits="pole_CreateQue" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
        <table align="center" width="80%">
            <tr>
                <td>
                    <fieldset style="border-color: Red; width: 98%">
                        <legend style="color: Green;">Create Question</legend>
                        <table width="100%">
                            <tr>
                                <td style="width:141px;">
                                    Question :-
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQue" runat="server" Width="300px" MaxLength="1000" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ErrorMessage="Enter Question" ControlToValidate="txtQue" Display="Dynamic" 
                                        ValidationGroup="Q"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Number of Option:-
                                </td>
                                <td>
                                <asp:UpdatePanel runat="server" ID="Up1">
                                    <ContentTemplate>
                                    
                                    <asp:DropDownList ID="ddloption" runat="server" Width="80" AutoPostBack="true">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="ddloption" ErrorMessage="Select No. of Options" 
                                        Display="Dynamic" InitialValue="0" ValidationGroup="Q"></asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr id="trgrid" runat="server">
                                <td>
                                </td>
                                <td>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvOption" runat="server">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Option">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txttext" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txttext" Display="Dynamic" ValidationGroup="Q"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <%--<tr id="trOptAns" runat="server" visible="false">
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:RadioButton ID="rbtnQ1" runat="server" Text="Op 1" Visible="false" GroupName="OAns" />
                                    <asp:RadioButton ID="rbtnQ2" runat="server" Text="Op 2" Visible="false" GroupName="OAns" />
                                    <asp:RadioButton ID="rbtnQ3" runat="server" Text="OP 3" Visible="false" GroupName="OAns" />
                                    <asp:RadioButton ID="rbtnQ4" runat="server" Text="OP 4" Visible="false" GroupName="OAns" />
                                    <asp:RadioButton ID="rbtnQ5" runat="server" Text="OP 5" Visible="false" GroupName="OAns" />
                                    <asp:RadioButton ID="rbtnQ6" runat="server" Text="OP 6" Visible="false" GroupName="OAns" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmark" runat="server" Width="50px" Visible="False"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr align="center">
                                <td>
                                    
                                </td>
                                <td align="left">
                                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Q" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <center>
            <table border="1" style="border-color: Red;" width="80%">
                <tr>
                    <td>
                        <center>
                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                            <br />
                            <asp:HyperLink ID="HyperLink1" class="Mybutton" runat="server" 
                                NavigateUrl="CreateQue.aspx?view=All" Visible="False">View All Poll</asp:HyperLink>
                                <br /><br />
                            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Data Found" 
                                OnRowCommand="GridView1_RowCommand" AllowPaging="True" 
                                AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkdel" runat="server" OnClientClick='return confirm("Are you sure you wish to delete this Question?")'
                                                CommandArgument='<%# Eval("Sno") %>' OnCommand="Ondelete" Text="Delete"></asp:LinkButton>
                                                
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    <asp:BoundField DataField="Sno" HeaderText="Sno" InsertVisible="False" ReadOnly="True" SortExpression="Sno" />
                                    <asp:BoundField DataField="CreationloginId" HeaderText="CreationloginId" SortExpression="CreationloginId" />
                                    <asp:TemplateField>
                                    <ItemTemplate>
                                    <a href="polet.aspx?id=<%# Eval("Sno") %>" title="Click To Take this Poll" class="Ques">
                                        <%#Eval("QsnDesc") %></a>
                                     </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="NoOfOptions" HeaderText="No. Of Opt." 
                                        SortExpression="NoOfOptions" />
                                    <asp:BoundField DataField="PoleTaken" HeaderText="Poll Taken" 
                                        SortExpression="PoleTaken" />
                                    <asp:BoundField DataField="CommentsTotal" HeaderText="Total Comments" 
                                        SortExpression="CommentsTotal" />
                                    
                                    
                                    
                                </Columns>
                            </asp:GridView>
                        </center>
                    </td>
                </tr>
            </table>
        </center>
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
        <br />
    </div>
</asp:Content>
