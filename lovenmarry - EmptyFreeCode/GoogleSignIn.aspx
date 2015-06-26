<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GoogleSignIn.aspx.vb" Inherits="GoogleSignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="body">
        <span class="style1">
<asp:Label runat="server" ID="lblDomainName" Text="yoursite.com"></asp:Label> is available only for people of india, each and every profile is checked, so that we only have genuine members<br><br><br>
to double verify, We are allowing only gmail users, to create Alc with us, to avoid fake registration
        <br> google also verifies each registration by there automated systems</span><br 
            class="style1" />
        <br />
    <asp:HyperLink ID="GotoAuthSubLink"  runat="server" />

    </div>
    
    </form>
</body>
</html>
