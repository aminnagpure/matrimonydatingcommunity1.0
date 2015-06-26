<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="JoinUs.aspx.vb" Inherits="JoinUs" title="Join With Me" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding:20px;">
    <center><table style="width:397px;"  cellspacing="0">
        <tr>
            <td id="tdimage" runat="server" style="width:110px;">
                Photo
            </td>
            <td runat="server" id="tdMsg"></td>
            </tr> 
            <tr>
                <td colspan="2">
                <table class="table">
            <tr>
                <td colspan ="2"> 
                    Its a free site, you can send email to other members free Join with me here you 
                    can find your Buddy All Cool People are Registered Here Come Join have fun.
                </td>
            </tr>
            <tr>
            
                <td>facebook</td>
                <td>
                    <a name="fb_share"></a> 
                    <script src="http://static.ak.fbcdn.net/connect.php/js/FB.Share" type="text/javascript"></script>
                </td>
            </tr>
            <tr>
                <td>
                Orkut
                </td>
                <td>
                 <div id="orkut-button"></div>
                                    <script type="text/javascript" src="http://www.google.com/jsapi"></script>
                                    <script type="text/javascript">
                                        google.load('orkut.share', '1');
                                        google.setOnLoadCallback(function() {
                                            new google.orkut.share.Button({
                                                summary: 'So much to see here.'
                                            }).draw('orkut-button');
                                        });
                                    </script>&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                Linkedin
                </td>
                <td>
                <script type="text/javascript" src="http://platform.linkedin.com/in.js"></script><script type="in/share" data-counter="top"></script>
                </td>
            </tr>
            <tr>
                <td>
                Twitter
                </td>
                <td>
                  <a href="http://twitter.com/share" class="twitter-share-button" data-count="vertical" data-via="jobdhundo">Tweet</a><script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
                </td>
            </tr>
           
        </table>
              
                     
                </td>
            </tr>
     </table>
     </center>
</div>
</asp:Content>


