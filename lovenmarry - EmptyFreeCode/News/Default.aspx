<%@ Page Title="" Language="VB" MasterPageFile="~/news/MasterPage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="news_Default" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <table style="width: 100%">
            <tr>
                <td>
                    
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="newsid" DataSourceID="ObjectDataSource1" EmptyDataText="No Articles found"
                         Width="100%" CellPadding="5" CellSpacing="5">
                        <Columns>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <%#Eval("newsdate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Headlines">
                                <ItemTemplate>
                                    <a href='viewnews.aspx?id=<%#eval("newsid") %>'>
                                        <%#Eval("newsheadline")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <%#cf.BreakWordForWrap(Mid(Eval("newscontent"), 1, 100))%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                       
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server"></asp:Label><asp:TextBox ID="txtCriteria" runat="server"
                        TextMode="MultiLine" Visible="False">1=1</asp:TextBox>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="clsnews">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="txtCriteria" Name="sq" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    
</asp:Content>
