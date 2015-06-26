<%@ Page Language="VB" MasterPageFile="~/members/MasterPageFB.master" AutoEventWireup="false" CodeFile="FB.aspx.vb" Inherits="FB" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--<script>
    window.fbAsyncInit = function() {
        // init the Facebook JavaScript SDK
        FB.init({
            appId: '378178345583448',
            channelUrl: null,
            status: true,
            cookie: false,
            xfbml: false
        });

        FB.getLoginStatus(function(response) {
            if (response.status === 'connected') {
                // connected
                FbLoginOk();
            } else if (response.status === 'not_authorized') {
                // not authorized
                login();
            } else {
                // not_logged_in
                login();
            }
        });
    };

    function login() {

        FB.login(function(response) {
            // handle the response
            if (response.authResponse) {
                // connected
                FbLoginOk();
            } else {
                // cancelled
            }
        }, { scope: 'publish_actions' });


    }

    function postToWall() {
        FB.login(function(response) {
            if (response.authResponse) {
                FB.ui({
                method: 'feed',
                    name: 'Facebook Dialogs',
                    link: 'http://www.fastfastmoney.com/',
                    picture: 'http://www.fastfastmoney.com/images/SM100447Thumbs.jpg',
                    caption: 'Reference Documentation',
                    description: 'Dialogs provide a simple, consistent interface for applications to interface with users.'
                },
        function(response) {
            if (response && response.post_id) {
                alert('Post was published.');
            } else {
                alert('Post was not published.');
            }
        });
            } else {
                alert('User cancelled login or did not fully authorize.');
            }
        }, { scope: 'publish_actions' });
        return false;
    }

    function FbLoginOk() {
        // console.log('Welcome!  Fetching your information... ');
        FB.api('/me', function(response) {
            //   console.log('Good to see you, ' + response.name + '.');

            /******Here we go facebook user details*******/

            var res = "NAME: " + response.name + " <br/> EMAIL: " + response.email;
            document.getElementById("fbresponse").innerHTML = res;
            document.getElementById("fbposttouser").style.display = "";




            /********ends****/


        });
    }

    (function(d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    } (document));
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SecondContent" Runat="Server">
<div id="fb-root"></div>


<INPUT TYPE="button" VALUE="LOGIN USING FACEBOOK" ONCLICK="login();">
<br/>
<div id="fbresponse"></div>
<div id="fbposttouser" style="display:none"><INPUT TYPE="button" VALUE="POST TO USER WALL" ONCLICK="postToWall()"></div>
<fb:add-to-timeline show-faces="true" mode="button" perms="offline_access,publish_actions,publish_stream"></fb:add-to-timeline>
--%>

    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>

