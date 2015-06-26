<%@ Page Title="" Language="VB" MasterPageFile="~/members/MasterPage.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="chatroom.aspx.vb" Inherits="members_chatroom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
     <script src='https://cdn.firebase.com/js/client/2.0.4/firebase.js'></script>
    <script src='https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js'></script>
    <link rel='stylesheet' type='text/css' href='http://www.firebase.com/resources/tutorial/css/example.css'>
    <script src='https://cdn.firebase.com/js/client/2.0.4/firebase.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id='messagesDiv'></div>
    <input type="text"   id="imgphot" visible="false" value="<%= Request.Cookies("Photo").ToString()%>" />
    <input type='text'  id='nameInput' placeholder='Name' visible="false"  value='<%=Session("fname")%>' >

    <input type='text' id='messageInput' placeholder='Message'>
    
    <script>
        var myDataRef = new Firebase('https://lovenmarrychat.firebaseio.com/');
        $('#messageInput').keypress(function (e) {
            if (e.keyCode == 13) {
                var name = $('#nameInput').val();
                var text = $('#messageInput').val();
                var imgn = $('#imgphot').val();
                myDataRef.push({imgn : imgn,name: name, text: text });
                $('#messageInput').val('');
            }
        });
        myDataRef.on('child_added', function (snapshot) {
            var message = snapshot.val();
            displayChatMessage(message.imgn, message.name, message.text);
        });
        function displayChatMessage(imgn,name, text) {
            $('<div/>').text(text).prepend($('<em/>').text(name + ': ').prepend('<img src="../App_Themes/' + imgn + '" width="30px"/>')).appendTo($('#messagesDiv'));
            $('#messagesDiv')[0].scrollTop = $('#messagesDiv')[0].scrollHeight;
        };

    </script>
     <script type="text/jscript">
         $(function () {


             $('#messageInput').ready(function () {

                 $('#messageInput').val('Hi i am online now');
                 var name = $('#nameInput').val();
                 var text = $('#messageInput').val();
                 var imgn = $('#imgphot').val();
                 myDataRef.push({ imgn: imgn, name: name, text: text });
                 $('#messageInput').val('');
             });
             
         });
    </script>
</asp:Content>

