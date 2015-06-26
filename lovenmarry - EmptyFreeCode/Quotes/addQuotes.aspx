<%@ Page Language="VB" MasterPageFile="~/Quotes/MasterPage.master" AutoEventWireup="false" CodeFile="addQuotes.aspx.vb" Inherits="Quotes_addQuotes" title="Untitled Page" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">
        <table style="width: 90%">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <table style="width: 90%">
                        <tr>
                            <td>
                                Category</td>
                            <td>
                                <asp:DropDownList ID="dpCategory" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dpCategory"
                                    Display="Dynamic" ErrorMessage="Category Not Selected" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quote Headline
                            </td>
                            <td>
                                <asp:TextBox ID="txtsubject" runat="server" Height="16px" Width="394px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsubject"
                                    Display="Dynamic" ErrorMessage="Headline Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quote
                            </td>
                            <td>
                                <asp:TextBox ID="txtdescription" runat="server" Height="113px" Width="608px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Save Ad" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td id="TD1" runat="server">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
