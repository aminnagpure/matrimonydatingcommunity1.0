<%@ Page Title="" Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="compulsorySteps.aspx.vb" Inherits="members_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
    <table width ="100%" cellpadding ="5" cellspacing ="5" >
        <tr>
            <th>
            Steps To complete your profile
            </th>
        </tr>
       <%-- <tr>
            <td>
           step 1: <asp:LinkButton ID="lnkInvites" runat="server" Enabled ="true " PostBackUrl="importcsv.aspx">Invite Your Friends</asp:LinkButton>&nbsp;<asp:Label ID="lblInviteStatus" runat="server" Text=""></asp:Label>
                
            </td>
        </tr>--%>
        <tr>
            <td>
          Step 1 :  
                <asp:LinkButton ID="lnkprofile" runat="server" Enabled ="false" PostBackUrl="editreg.aspx">Update your profile</asp:LinkButton>&nbsp;<asp:Label ID="lblprofileStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            
            </td>
        </tr>
    </table>
</div>
</asp:Content>

