<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="QuotesCategory.aspx.vb" Inherits="moderators_QuotesCategory" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<div id="body">
        <table style="width: 90%">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <br />
                <table style="width: 90%">
                    <tr>
                        <td style="width: 100px">
                            Category</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox1" runat="server" Width="249px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="Button1" runat="server" Text="Save" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

