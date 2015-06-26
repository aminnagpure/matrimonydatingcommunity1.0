<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadImage_.aspx.vb" Inherits="UploadImage_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
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
    </form>
</body>
</html>
