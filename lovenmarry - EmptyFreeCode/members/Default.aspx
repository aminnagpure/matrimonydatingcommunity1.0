<%@ Page Language="VB" MasterPageFile="~/members/DefaultMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="members_Default" title="Welcome to Your Member Area" %>
<asp:Content runat="server" ID="hh" ContentPlaceHolderID="headContent">
<style>
#body .module {
border: 1px solid #9BA0AF;
margin: 20px 1px 0 0px;
margin-top: 20px;
-webkit-border-radius: 5px;
-moz-border-radius: 5px;
border-radius: 5px;
background: #ffffff;
font-size:small;
}
</style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="body">
          
 

           
    <table style="width:100%" >
        <tr>
            <td colspan="3">
            <asp:DataList ID="dlThumbnails" runat="server" RepeatColumns="10" RepeatDirection="Horizontal"
                DataKeyField="pid" ItemStyle-VerticalAlign="Top" CssClass="divlist " 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%">
                <ItemTemplate>
                    <div style="margin-top:5px;margin-right:5px;margin-bottom:3px;text-align:center;">
                    <div style="margin-bottom:2px;text-align:center;"><a href='viewprofile.aspx?Pid=<%# Eval("pid")%>'> <asp:Image ID="img" runat="server" Height="80px" Width="80px" class="ft1" /> </a></div>
                <h6><%#Eval("fname")%></h6>
                    <p style="margin-top:-15px;font-size:13px;text-align:center;"><%# If( Eval("cityname")<>"","From " & Eval("cityname"),"") %></p>
                    <p style="margin-top:-15px;font-size:13px;text-align:center;"><%# Eval("profession")%></p>
 </ItemTemplate>
 </asp:DataList>
            </td>
        </tr>
            <tr>
            <td align ="center" valign="top">
   <img src="http://placehold.it/336X280/D3CDBB/fff/&text=Ads 336X280" />
    <br /><br />
    
    <br /><br />
    
            </td>

            <td align ="center" colspan="2" valign="top">
            <img src="http://placehold.it/336X280/D3CDBB/fff/&text=Ads 336X280" />
            </td>
            
        </tr>
        <tr>
            <td colspan="3">
            <div class="module">
                                            <header><h3>Site Activity</h3></header>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    
                    
                    <tr>
                        <td valign="top" style="width:25%;">
                    
                                            
                                            <asp:GridView ID="GridViewsiteactivity" runat="server" 
                                                AutoGenerateColumns="False" DataKeyNames="siteactivityid" 
                                            GridLines="None" CssClass="module_content" ShowHeader="False" AllowPaging="True" 
                                                PageSize="5">
                                                            <PagerSettings FirstPageText="" LastPageText='' Mode="NextPrevious" 
                            NextPageText="&lt;a target=&quot;_blank&quot; href=&quot;../browsemembers.aspx&quot;&gt;View All members&lt;/a&gt;" 
                            PreviousPageText="" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image align="left" runat="server" ID="imgAct" ImageUrl="~/App_Themes/no_avatar.gif" Width="50" Height="50" /> <%#Eval("activity")%>
                                                        <span class="time" title='<%#Eval("activitydate") %>'><%#DateFormatUpdates(Eval("activitydate"))%></span>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="message" />
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                            
                        </td>
                        <td valign="top" style="width:25%;">
                           
                                            <asp:GridView ID="gridForums" runat="server" 
                                                AutoGenerateColumns="False" DataKeyNames="siteactivityid" 
                                            GridLines="None" CssClass="module_content" ShowHeader="False" AllowPaging="True" 
                                                PageSize="5">
                                                            <PagerSettings FirstPageText="" LastPageText='' Mode="NextPrevious" 
                            NextPageText="&lt;a href=&quot;../Forums&quot;&gt;View All Post&lt;/a&gt;" 
                            PreviousPageText="" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image align="left" runat="server" ID="imgAct" ImageUrl="~/App_Themes/no_avatar.gif" Width="50" Height="50" /> <%#Eval("activity")%>
                                                        <span class="time" title='<%#Eval("activitydate") %>'><%#DateFormatUpdates(Eval("activitydate"))%></span>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="message" />
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                            
                                            
                        </td>
                        <td valign="top" style="width:25%;">
                         
                                           
                                            <asp:GridView ID="gridArticals" runat="server" 
                                                AutoGenerateColumns="False" DataKeyNames="siteactivityid" 
                                            GridLines="None" CssClass="module_content" ShowHeader="False" AllowPaging="True" 
                                                PageSize="5">
                                                            <PagerSettings FirstPageText="" LastPageText='' Mode="NextPrevious" 
                            NextPageText="&lt;a href=&quot;../News&quot;&gt;View All Articles&lt;/a&gt;" 
                            PreviousPageText="" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image align="left" runat="server" ID="imgAct" ImageUrl="~/App_Themes/no_avatar.gif" Width="50" Height="50" /> <%#Eval("activity")%>
                                                        <span class="time" title='<%#Eval("activitydate") %>'><%#DateFormatUpdates(Eval("activitydate"))%></span>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="message" />
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                            
                                       
                        </td>
                        <td valign="top" style="width:25%;">
                            
                                            <asp:GridView ID="gridPoll" runat="server" 
                                                AutoGenerateColumns="False" DataKeyNames="siteactivityid" 
                                            GridLines="None" CssClass="module_content" ShowHeader="False" AllowPaging="True" 
                                                PageSize="5">
                                                            <PagerSettings FirstPageText="" LastPageText='' Mode="NextPrevious" 
                            NextPageText="&lt;a href=&quot;../Poll&quot;&gt;View All Poll&lt;/a&gt;" 
                            PreviousPageText="" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image align="left" runat="server" ID="imgAct" ImageUrl="~/App_Themes/no_avatar.gif" Width="50" Height="50" /> <%#Eval("activity")%>
                                                        <span class="time" title='<%#Eval("activitydate") %>'><%#DateFormatUpdates(Eval("activitydate"))%></span>
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="message" />
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                            
                                            
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
         <tr>
            <td colspan="3">


  
</td>
        </tr>
        
        
        <tr>
            <td valign="top" align ="left">
                <table style="width:100%"  class="table">
                    <tr>
                        <th valign="top">
                            Search</th>
                    </tr>

                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/members/chat.html">Chat With Members</asp:HyperLink></td>
                    </tr>

                      <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/members/videocall.aspx">Video Call With Members</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/members/findpartner.aspx">Find Partner</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 21px">
                            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/members/awaitingMembers.aspx">Awaiting Members</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 21px">
                            <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/members/awatingForResponse.aspx">Waiting For Response</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/members/AcceptedMembers.aspx">Accepted Members</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 21px">
                            <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/members/IAccepetd.aspx">Members I accepted</asp:HyperLink></td>
                    </tr>
                    
                </table>
                <br />
               
            </td>
            
            <td valign="top" align ="left" >
                <table  style="width:100%" class="table">
                    <tr>
                        <th>
                            Groups</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/members/fouvritemem.aspx">favourite Members</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/members/blockedmem.aspx">Blocked Member</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                            </td>
                    </tr>
                </table>
                <br />
               
            </td>
            <td align ="left">
                <table  style="width:100%"  class="table">
                    <tr>
                        <th>
                            Profile</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/members/editreg.aspx">Edit Profile</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/members/uploadphoto.aspx">Upload Photo</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/members/removephoto.aspx">Remove Photo</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink7" runat="server">View Your Profile</asp:HyperLink></td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/members/PartnerProfile.aspx">My Desired Partner Profile</asp:HyperLink></td>
                    </tr>
                </table>
                <br />
                
            </td>
        </tr>
        <tr>
            <td valign="top" align ="left">
             <table  style="width:100%"  class="table">
             <tr>
                <th> Links</th>
             </tr>
                <tr>                    
                        <td style="width: 100px">
                            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/members/reflink.aspx">Referal Link</asp:HyperLink></td>
                    </tr>
                    <%--<tr>
                        <td style="width: 100px">
                            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/members/importcsv.aspx">Invite Your Friends</asp:HyperLink></td>
                    </tr>--%>
                    <tr>
                        <td style="width: 100px">
                            <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/JoinUs.aspx">Share on Social Networking</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
             <td valign="top" align ="left">
             <table  style="width:100%"  class="table">
                <tr>
                <th>Views</th>
                </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/members/whoviewdyourprofile.aspx">Who Viewed My Profile?</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/members/profileviewedbyyou.aspx">Profiles You Viewed</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
             <td valign="top" align ="left">
            <% If cf.affprogram = "Y" Then%>
                <table  style="width:100%"  class="table">
                <tr>
                <th>Money Earned</th>
                </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/members/affprogram.aspx">Ref Program Details</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                           <asp:HyperLink ID="hypUnpaid" runat="server" Text="Total Unpaid Money Earned" NavigateUrl="~/members/reflink.aspx"></asp:HyperLink>
                            </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="hypdirectref" runat="server" NavigateUrl="~/members/directmemreferd.aspx">Your Referals</asp:HyperLink></td>
                    </tr>
                </table>
                <% end if %>
            </td>
        </tr>
        <tr>
            <td align ="left">                
                <table  style="width:100%"  class="table">
                    <tr>
                        <th>
                            Alerts</th>
                    </tr>
                    <tr>
                        <td align="left">
                          
             
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top">
                <table  style="width:100%"  class="table">
                    <tr>
                        <th>
                            Privacy Settings</th>
                    </tr>
                    <tr>
                        <td align="left"> 
                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/members/privacysettings.aspx">Privacy Settings</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/members/reqpasswordlist.aspx"
                                >Photo Password Request List</asp:HyperLink></td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top"> 
                <table  style="width:100%"  class="table">
                    <tr>
                        <th>
                            Removal</th>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/members/RemoveProfile.aspx">Remove Profile</asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td align="left">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align ="left" colspan="3">                
           
               </td>
        </tr>
        <tr>
        <td align ="left" colspan="3">                
        <br /><br />
        </td>
        </tr>
      
    </table>
    
    </div>
    
    
</asp:Content>

