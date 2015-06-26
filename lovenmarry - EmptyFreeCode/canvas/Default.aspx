<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="canvas_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
</head>
<body>
<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=404461319606517";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
    <form id="form1" runat="server">
    <div id="body">
    <table>
    <tr>
    <td id="tdimage" runat="server">
    </td>
    </tr>
    <tr>
    <td><div class="fb-like"  data-send="true" data-width="450" data-show-faces="true"></div>
    </td>
    </tr>
    <tr>
    <td>
    <img src="http://yoursite.com/App_Themes/201261352743117.jpg" />
    </td>
    </tr>
    </table>
        </div>
    </form>
</body>
</html>
