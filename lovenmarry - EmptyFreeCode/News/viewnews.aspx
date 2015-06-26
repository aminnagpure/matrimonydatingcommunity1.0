<%@ Page Title="" Language="VB" MasterPageFile="~/News/MasterPage.master" AutoEventWireup="false"
    CodeFile="viewnews.aspx.vb" Inherits="news_viewnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <table class="pageText">
        <tr>
        <td><a href="../members/addnews.aspx">Write Article</a></td>
        </yr>
        <tr>
        <td id="profiledetails" runat="server">sdfsd
        </td>
        </tr>
            <tr>
                <td id="tdheadline" runat="server" style="font-weight:bold;">
                    
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td id="tdcontent" runat="server">
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td id="tddate" runat="server">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 90%">
                        <tr>
            
                            <td style="width: 100px">
                            Comments
                            </td>
                        </tr>
                        <tr>
            
                            <td style="width: 100px">
                                <asp:TextBox ID="txtComments" runat="server" Height="76px" MaxLength="250" 
                                    Width="693px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td style="width: 100px">
                                <asp:Button ID="btnPostComments" runat="server" Text="Add Comment" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                        AllowPaging="True" EmptyDataText="No comments found" 
                        Width="80%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td width="20%">
                                                <a href='../viewprofile.aspx?pid=<%# Eval("candiid")%>'>
                                                    <%# Eval("firstname")%>
                                                    &nbsp;
                                                    <br />
                                                    <asp:Image ID="img" runat="server"  /></a>
                                            </td>
                                            <td>
                                                <%#cf.BreakWordForWrap(Eval("comment"))%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnDelete" CommandArgument='<%# Eval("ncommentid")%>' CommandName="IDelete"
                                                    runat="server" Text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle Font-Size="XX-Large" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="clsnewscomments" EnablePaging="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                            <asp:Parameter DefaultValue="10" Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    
</asp:Content>
