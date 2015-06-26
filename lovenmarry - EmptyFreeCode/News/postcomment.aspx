<%@ Page Title="" Language="VB" MasterPageFile="~/news/MasterPage.master" AutoEventWireup="false" CodeFile="postcomment.aspx.vb" Inherits="news_postcomment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="body">

    <br />
    <table style="width: 90%">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server" Height="97px" MaxLength="250" Width="415px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="Button1" runat="server" Text="Add Comment" /></td>
        </tr>
    </table></div>
    
</asp:Content>

