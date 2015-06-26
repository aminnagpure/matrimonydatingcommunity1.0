<%@ Page Title="" Language="VB" MasterPageFile="~/Forums/MasterPagewithads.master"  AutoEventWireup="false" CodeFile="viewtopic.aspx.vb" Inherits="Forums_viewtopic" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function comfirmdel() {
            return confirm("Are you sure you wish to delete this entry?");
        }
    </script>
    
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>


<script type="text/javascript" language="javascript">    // <![CDATA[

    function viewalldiv(prodiv, imgsrc) {
        var pro = document.getElementById(prodiv);
        // var varimg = document.getElementById(imgsrc);
        
        if (pro.style.display == "block") {
            // varimg.src = "images/others/icon-vall.jpg";
            $('#' + prodiv).hide('slow').siblings();
            pro.style.display = "none";
            document.getElementById(imgsrc).style.display = "block";  // value = "Replay";
        }
        else {
            //varimg.src = "images/others/icon-minus.jpg";
            document.getElementById(imgsrc).style.display = "none";  // value = "Close";
            $('#' + prodiv).show('slow').siblings();
            pro.style.display = "block";
        }
        return false;
    }
    function GoTo(url) { window.parent.location = url; return false; }

         </script>
         
       <table style="width: 100%;margin-left:-1px;" class="Forums">
    <tr><td>
        <br /><br />
        <div id="forumcat" runat="server">
           
        </div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MainTable">
           <tr class="theader"><th  id="tdstartdate" runat="server" class="time" style="color: White;" colspan ="2"></th></tr>
           <tr><td valign="top" class="UserDetails" style="width:150px;">
           <div id="divStartedby" runat="server" class="Content UserName"></div>
           <asp:Image ImageUrl="~/App_Themes/no_avatar.gif" runat="server" ID="imgposter" style="width:50px"/>
           
           
           <div id="divTotalTopic" runat="server" class="Content"></div>
           </td><td class="contentArea" valign="top">
           <div class="Content" runat="server" id="divTopic">Hi</div>
           <hr size="1" style="color:#CECECE; background-color:#CECECE">
           <div runat="server" id="divTopicDesc" class="contentDesc" style="min-height:78px;"></div>
                   <asp:Button ID="btnDelRel" runat="server" Text="Delete Topic" class="delbutton"/>
        
           </td></tr>
           </table>
        <br />
        <asp:HyperLink ID="HyperLink1" NavigateUrl="" onclientclick="return viewalldiv('div_replay','')" runat="server" Visible="false">Reply</asp:HyperLink>
        <div style="display:none;" id="div_replay">
<table>
    <tr><td>
            &nbsp;</td>
        <td>
        Write Your Replay here:<br />
            <asp:TextBox ID="TextBox1" runat="server" Height="140px" TextMode="MultiLine" 
                Width="590px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="A"
                ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Content Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Post Reply" ValidationGroup="A" class="Comments"
                style="height: 26px" /><asp:Button runat="server" ID="Button2"  class="Comments" OnClientClick="return viewalldiv('div_replay','ctl00_ContentPlaceHolder1_btnReplay')" Text="Close" style="margin-left:20px;"/>
        </td>
    </tr>
</table>
</div>
        <asp:Button runat="server" ID="btnReplay"  class="Comments" OnClientClick="return viewalldiv('div_replay','ctl00_ContentPlaceHolder1_btnReplay')" Text="Reply"/>
        <br /> <a runat="server" ID="Button3" href="" class="Comments" Visible="false" style="padding:4px;padding-left: 43px;padding-right: 43px">Reply</a><br />
       <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="AnsId" DataSourceID="ObjectDataSource1"  GridLines="None" 
                                                    Width="100%" ShowHeader="False" class="TopicDetails">
            <Columns>
                <asp:BoundField DataField="CandiId" Visible="false" />
                <asp:TemplateField ControlStyle-Width="600px">
                    <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MainTable">
                        <tr class="theader"><td width="150"class="time" style="color: White;"><%#Eval("AnsDate")%></td><td align="right"></td></tr>
                        <tr><td valign="top" class="UserDetails">
                        <div class="Content UserName"><a href='../viewprofile.aspx?pid=<%#eval("CandiId") %>' title=""><%#Eval("fname")%></a> </div>
                        <asp:Image ID="img" runat="server" style="Width:50px" />
                        
                        </td><td class="contentArea" valign="top">
                        <div class="Content">Re: </div>
                        <hr size="1" style="color:#CECECE; background-color:#CECECE">
                        <div class="contentDesc" style="min-height: 30px;"> <%#Eval("TopicAns")%></div>
                        <asp:Button ID="btnDelete" CommandArgument='<%# Eval("AnsId")%>' CommandName="IDelete" style="Width:100px;" class="delbutton"
                                        runat="server" Text="Delete" />
                        </td></tr>
                    </table>
                    
                    
                    
                         
                    </ItemTemplate>
                    <ItemStyle></ItemStyle>


<ControlStyle Width="600px"></ControlStyle>


                </asp:TemplateField>
                
                
            </Columns>
            <PagerStyle CssClass="Footer"/>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:TextBox ID="txtCriteria" runat="server" Visible="False">1</asp:TextBox>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsPaged" TypeName="clstopicreplies">
            <SelectParameters>
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:ControlParameter ControlID="txtCriteria" Name="sq" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
</td></tr></table> 

</asp:Content>
