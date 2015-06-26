<%@ Page Title="" Language="VB" MasterPageFile="~/members/MasterPage.master" AutoEventWireup="false" CodeFile="Chat.aspx.vb" Inherits="members_Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <link rel="stylesheet" href="https://www.webrtc-experiment.com/style.css">

    <style>
        input {
            border: 1px solid #d9d9d9;
            border-radius: 1px;
            font-size: 2em;
            margin: .2em;
            width: 60%;
        }

        p {
            padding: 1em;
        }

        li {
            border-bottom: 1px solid rgb(189, 189, 189);
            border-left: 1px solid rgb(189, 189, 189);
            padding: .5em;
        }

        #chat-table blockquote {
            border: 1px dotted gray;
            margin: 1em 5em;
            padding: 1em 2em;
        }

            #chat-table blockquote hr {
                border: 0;
                border-top: 1px dotted #BBA9A9;
                margin: 1em -2em;
            }
    </style>
    <script>
        document.createElement('article');
        document.createElement('footer');
    </script>

    <article>
        <header style="text-align: center;">
            
            

            <p>
             
            </p>
        </header>

        

        <section class="experiment">

            <!-- <HTML code for you> ::: just copy this section! -->
            <table class="visible">
                <tr>
                    <td style="text-align: right;">
                        <input type="text" id="conference-name" placeholder="Hangout Name...">
                    </td>
                    <td>
                        <button id="start-conferencing" href="#">Start Chat-Hangout</button>
                    </td>
                </tr>
            </table>

            <table id="rooms-list" class="visible"></table>

            <table class="visible">
                <tr>
                    <td style="text-align: center;">
                        <strong>Private chat-hangout</strong> ?? <a href="" target="_blank"
                                                                    title="Open this link in new tab. Then your chat-hangout room will be private!">
                            <code>
                                <strong id="unique-token">#123456789</strong>
                            </code>
                        </a>
                    </td>
                </tr>
            </table>

            <table id="chat-table" class="center-table hidden">
                <tr>
                    <td style="text-align: center;">
                        <input type="text" id="chat-message" disabled>
                        <button id="post-chat-message">Post Message</button>
                    </td>
                </tr>
            </table>
            <table id="chat-output" class="hidden"></table>

            <p>
               all participants can share text messages in a group!
            </p>
        </section>

        <script src="https://www.webrtc-experiment.com/firebase.js"> </script>
        <script src="https://www.webrtc-experiment.com/RTCPeerConnection-v1.6.js"> </script>
        <script src="https://www.webrtc-experiment.com/chat-hangout/hangout.js"> </script>
        <script src="https://www.webrtc-experiment.com/chat-hangout/hangout-ui.js"> </script>

        <!-- </HTML code for you> ::: end copy this section! -->

        
       
    </article>

    

    <footer>
        <p>
          
        </p>
    </footer>

    <!-- commits.js is useless for you! -->
    <script src="https://www.webrtc-experiment.com/commits.js" async> </script>

</asp:Content>

