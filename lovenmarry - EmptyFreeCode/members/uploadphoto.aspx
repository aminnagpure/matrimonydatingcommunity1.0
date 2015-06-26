<%@ Page Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="uploadphoto.aspx.vb" Inherits="members_uploadphoto" title="Upload Your Photo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
function formsettings()
{
aspnetForm.enctype="multipart/form-data"
aspnetForm.method="post"
    
}
</script>
<div id="body">
    <br />
    You Are Requested to Upload only your photo<br />

    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
    <br />
    Junk photos wud be deleted<br />
    Maximum Size of Phot is 5 Mb, Check the Size of photo before upload<br />
    <span style="color: #ff3366">Do Not Upload Photos of Kids</span><br />
    Do Not Upload Nude Photos<br />
    <span style="color: #ff0066">All Photos are checked<br />
    </span>Only Upload your Photo, Junk Photos Are Deleted<br />
    <br />
    <asp:Button ID="upimage" text="Save Photo" runat="server" /><br />
    <table>
        <tr>
            <td id="TD1" runat="server" style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Width="238px"></asp:Label>
</div>    
</asp:Content>

