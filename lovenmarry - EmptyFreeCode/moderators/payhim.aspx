<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="payhim.aspx.vb" Inherits="moderators_payhim" title="Untitled Page" %>

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
            <td style="width: 100px; height: 92px">
                <table style="width: 90%">
                    <tr>
                        <td style="width: 100px">
                            Affiliate ID</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtAffid" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Affiliate Name</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtAffname" runat="server" Width="196px" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 21px">
                            Payment Description</td>
                        <td style="width: 100px; height: 21px">
                            <asp:TextBox ID="txtpaymentDescrip" runat="server" Width="501px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Paid to</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtpaidto" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Payment Amount</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtPayAmount" runat="server" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Tracking No.</td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txttrackingno" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtAffEmail" runat="server" Visible="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="Button1" runat="server" Text="Make Payment" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;</td>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
        </tr>
</asp:Content>

