<%@ Page Title="Signup with google account" Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="PlusSignIn.aspx.vb" Inherits="PlusSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
    .Gplus{background:url('images/Red-signin-Long-base-20dp.png');background-repeat:no-repeat;padding:0;border: 0px;
           cursor:pointer;
           background-position-x: -9px;
           background-position-y: -9px;
}
    .Gplus:hover{background:url('images/Red-signin-Long-hover-20dp.png');background-repeat:no-repeat;padding:0;border: 0px;
           cursor:pointer;
           background-position-x: -9px;
           background-position-y: -9px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="body">
    <span class="style1">
<asp:Label runat="server" ID="lblDomainName" Text="yoursite.com"></asp:Label> is available only for people of india, each and every profile is checked, so that we only have genuine members<br><br><br>
to double verify, We are allowing only gmail users, to create Alc with us, to avoid fake registration
        <br> google also verifies each registration by there automated systems</span><br 
            class="style1" />
        <br />
    <center><button id="authorize-button" style="visibility:hidden; width: 288px; height: 55px;" 
            class="Gplus"></button></center>

            <center><a id="btnContinue"  style="visibility:hidden; width: 206px; height: 49px;" href="Members/editreg.aspx"
        class="ShareButton">Click Here To Continue</a></center>

    <script src="jquery.min.js" type="text/javascript"></script>
<script>
    //change this client id and api key with yours 
    //var clientId = '864996194772-c8ge4td0rtpdqltlbousji8o0nd497sf.apps.googleusercontent.com';
    //var apiKey = 'AIzaSyACn0j0wdEJNgSYhog0uTgtMciKXjdulkc';
    var clientId = 'yourclientid';
    var apiKey = 'your apikey';
    var scopes = 'https://www.googleapis.com/auth/userinfo.email https://www.google.com/m8/feeds'; //  https://www.google.com/m8/feeds'; // https://www.googleapis.com/auth/userinfo.email';// https://www.google.com/m8/feeds';  //https://www.googleapis.com/auth/plus.me'; //'https://www.google.com/m8/feeds/';  //

    var TotalReferesh = 0;
</script>    
    
    <script type="text/javascript">
       
        var D;

        // Use a button to handle authentication the first time.
        function handleClientLoad() {
            gapi.client.setApiKey(apiKey);
            window.setTimeout(checkAuth, 1);
        }

        function checkAuth() {
            gapi.auth.authorize({ client_id: clientId, scope: scopes, immediate: true }, handleAuthResult);
        }


        function handleAuthResult(authResult) {
            var authorizeButton = document.getElementById('authorize-button');
            if (authResult && !authResult.error) {
                authorizeButton.style.visibility = 'hidden';

                document.getElementById('content').innerHTML = "";
                var heading = document.createElement('h4');
                var image = document.createElement('img');
                image.src = "http://www.yoursite.com/Images/loading.gif";
                heading.appendChild(image);
                document.getElementById('content').appendChild(heading);
                
                makeApiCall();
                document.getElementById('content').innerHTML = "";
                heading = document.createElement('h4');
                image = document.createElement('img');
                heading.appendChild(document.createTextNode("Wait.."));
                image.src = "http://www.yoursite.com/Images/loading.gif";
                heading.appendChild(image);

                document.getElementById('content').appendChild(heading);

                getContact(authResult);

                // document.getElementById('content').innerHTML = "";
            } else {
                authorizeButton.style.visibility = '';
                authorizeButton.onclick = handleAuthClick;
            }
        }
        function getContact(a) {

            var authParams = { access_token: a.access_token, token_type: a.token_type, 'max-results': '9999', alt: 'json' }; // from Google oAuth

            $.ajax({
                url: 'https://www.google.com/m8/feeds/contacts/default/full',
                dataType: 'jsonp',
                data: authParams,
                success: function (data) {
                    //C = data;
                    ReadContact(data);
                }
            });

        }

        function handleAuthClick(event) {
            gapi.auth.authorize({ client_id: clientId, scope: scopes, immediate: false }, handleAuthResult);
            return false;
        }

        // Load the API and make an API call.  Display the results on the screen.
        function makeApiCall() {
            gapi.client.load('plus', 'v1', function () {
                var request = gapi.client.plus.people.get({
                    'userId': 'me'
                });
                request.execute(function (resp) {

                    //                    var heading = document.createElement('h4');
                    //                    var image = document.createElement('img');
                    //                    image.src = resp.image.url;
                    //                    heading.appendChild(image);
                    //                    heading.appendChild(document.createTextNode(resp.displayName));
                    //                    heading.appendChild(document.createTextNode(resp.gender));
                    //                    heading.appendChild(document.createTextNode(resp.emails));
                    //                    document.getElementById('content').appendChild(heading);
                    //alert(resp);

                    D = resp;
                    Dosomething();


                });
            });
        }

        function OnSuccess1(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var pageCount = xml.find("pid").eq(0).find("pid").text();
            //alert(pageCount);

           // window.location = 'members/editreg.aspx';
            //            var xmlDoc = $.parseXML(response.d);
            //            var xml = $(xmlDoc);
        }
        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var pageCount = xml.find("pid").eq(0).find("pid").text();
            // alert(pageCount);
            var linkbtn = document.getElementById('btnContinue');
            linkbtn.style.visibility = '';
            document.getElementById('content').innerHTML = "";
            //window.location = 'Members/editreg.aspx';
            //            var xmlDoc = $.parseXML(response.d);
            //            var xml = $(xmlDoc);
        }
    </script>

    <script src="https://apis.google.com/js/client.js?onload=handleClientLoad"></script>
    <script>
        function Dosomething() {
            var dd = 'A';
            $.ajax({
                type: "POST",
                url: "PlusSignIn.aspx/ReadData",
                data: "{UD: " + JSON.stringify(D) + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess1,
                failure: function (response) {
                    alert(response.d + ' Fail');
                },
                error: function (response) {
                   // alert("Err ReadData" & response.ResponseText);
                    t = setTimeout(function () { Referesh() }, 500);
                }
            });
        }

    </script>
    <script>
        function ReadContact(C) {
            var dd = 'A';
            $.ajax({
                type: "POST",
                url: "ReadContact.aspx/ReadContact",
                data: "{UD: " + JSON.stringify(C) + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d + ' Fail');
                },
                error: function (response) {
                    //alert("Err ReadContact");
                }
            });
        }


    </script>
        <center><div id="content"></div></center>
    <asp:HiddenField ID="referby" runat="server" />
    </div>
</asp:Content>

