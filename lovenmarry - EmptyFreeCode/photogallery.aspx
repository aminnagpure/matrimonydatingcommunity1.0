<%@ Page Language="VB" MasterPageFile="~/MasterPagenoads.master" AutoEventWireup="false"
    CodeFile="photogallery.aspx.vb" Inherits="photogallery" Title="Photo Gallery" %>
    <asp:Content runat="server" ID="hh" ContentPlaceHolderID="head">
        <div id="div_Lnk" runat="server">
                         
                </div>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
<meta property="og:title" content="Love N Marry" />
<div id="fb-root"></div>
<div id="Div1"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=404461319606517";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
     <br />

            <script type="text/javascript">
                function comfirmdel() {
                    return confirm("Are you sure you wish to delete this photo?");
                }
            </script>
            <div id="body">
        <table>
            <tr>
               <td id="tdphoto" runat="server" >
                <asp:Label runat="server" ID="lblP">This Photo is Password Protected : </asp:Label><br />
                <asp:TextBox id="photopassw" TextMode="Password" runat="server" placeholder="Enter password Here"></asp:TextBox> 
                    <asp:RequiredFieldValidator ValidationGroup="PP" ControlToValidate="photopassw" Display="Dynamic" SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                <asp:Label runat="server" ID="lblPError" style="display:block"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Insert Password" ValidationGroup="PP"/>        
                </td>
            </tr>
            <tr>
                <td id="tdlink" runat="server" style="width: 100px">
                </td>
            </tr>
        </table>
           <%--  <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
                 ForeColor="#333333" GridLines="None" 
                PagerSettings-Mode="NumericFirstLast" PageSize="1" Width="600px" 
                 ShowHeader="False">
                <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                
                <Columns>
                    <asp:ImageField DataAlternateTextField="Photoname" DataImageUrlField="photoname"
                        DataImageUrlFormatString="App_Themes/{0}" >
                        <ControlStyle />
                    </asp:ImageField>
                </Columns>
                
                <PagerStyle  ForeColor="Black" HorizontalAlign="Left" />
                
            </asp:GridView>--%>
            
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
        <ContentTemplate>--%>
        <table>
           <tr>
           <td valign="top" align="center">
             <asp:ListView  ID="ListView1" runat="server"  GroupItemCount="6" GroupPlaceholderID="groupPlaceholder1" ItemPlaceholderID="itemPlaceholder1">
       <LayoutTemplate>
                    <div>
                         <div ID="groupPlaceholder1" runat="server">
                         </div>
                    </div>
                
                </LayoutTemplate>
                <GroupTemplate>
                        <div style="clear:both">
                            <div ID="itemPlaceholder1" runat="server">
                                 &nbsp;
                            </div>
                        </div>
                 </GroupTemplate>
                 <ItemTemplate>
                 
                        <div style="float:left; margin-right :10px"> 
              <asp:ImageButton runat="server" ID="btnimg" CommandArgument='<%# Eval("photoid") %>'    CommandName="ShowImg" ImageUrl='<%# String.Format("App_Themes/Thumbs/{0}", Eval("photoname")) %>' /></asp:ImageButton >

                        
</div> 
                 </ItemTemplate>
             <GroupSeparatorTemplate>
              <div id="Div1" runat="server">
                <div style="clear:both"><hr /></div>
              </div>
            </GroupSeparatorTemplate>
    </asp:ListView>


  

           </td>
           </tr>
           
           <tr>
           <td id="viewphoto" runat="server" valign="top" align="center" >
           <div>
           <asp:Image id="pic" runat="server" Height="400px" Width="400px" visible="false"/>
           
           </div>
           </td>
           </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/PlusSignIn.aspx" runat="server">Click here to contact This member</asp:HyperLink>
                </td>
           </tr>
           <tr>
           <td id="viewcomment" runat="server" align="center" visible="false" >
           <table>
            <tr>
                <td colspan="2" runat="server" id="facebookcomment">
                <div class="fb-comments" data-href="abcd" data-width="470"></div>
                </td>
                </tr>
                <tr>
                <td colspan="2" runat="server" id="googlecomments">
                <script src="https://apis.google.com/js/plusone.js"></script>
                    <g:comments
                        href="http://www.yoursite.com"
                        width="642"
                        first_party_property="BLOGGER"
                        view_type="FILTERED_POSTMOD">
                    </g:comments>
                </td>
                </tr>
           </table>
           <div align="center">
           <%--<a href="#" id="a_Comment"  style="text-decoration:none" runat="server" onclick="return viewalldiv('div_Comment','ctl00_ContentPlaceHolder1_a_Comment')" class="btnc">Post Comments</a>--%>
<table style="width: 60%;display:none;" id="div_Comment">
                                                            

<tr>
<td>
<asp:Label ID="Label10" runat="server" Text="Comment"></asp:Label>
</td>
<td>

<asp:TextBox ID="TextBox2" runat="server" Height="71px" TextMode="MultiLine" Width="424px" onKeyDown="limitText('ctl00_ContentPlaceHolder1_TextBox2','countdown',500);" 
onKeyUp="limitText('ctl00_ContentPlaceHolder1_TextBox2','countdown',500);"></asp:TextBox>
<div  id="countdown">You have 500 characters left.</div> 
</td>
</tr>
<tr>
<td>
</td>
<td>
&nbsp;&nbsp;
<asp:Button ID="btnPostComment" runat="server" Text="Post Comments" class="btnc" style="width: 138px"
ValidationGroup="R" />
&nbsp;
<asp:Button ID="Button4" runat="server" Text="Cancel" class="btnc" OnClientClick="return viewalldiv('div_Comment','ctl00_ContentPlaceHolder1_a_Comment')"/>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
ErrorMessage="Comment Required" ValidationGroup="R"></asp:RequiredFieldValidator>
</td>
</tr>
</table>    
         
         
<div style="min-height:111px; width:510px;">
<%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True">
    <Columns>
        <asp:TemplateField HeaderText="Comments">
            <ItemTemplate>
                <table class="SubTopic" style="min-height: 80px;padding-top: 6px">
                    <tr>
                        <td valign="top">
                            <div style="float:left;">
                                <a href='../dostizone/viewprofile.aspx?id=<%# Eval("candiid")%>'>
                                    <asp:Image ID="img" runat="server" Height="50px" Width="50px" />
                                </a>
                            </div>
                            <div><a href='../dostizone/viewprofile.aspx?id=<%# Eval("candiid")%>'>
                                                            <%#Eval("firstname")%>
                                                            </a></div>
                                                    </td>
                                                        <td class="Content1" rowspan="2" valign="top" width="100%">
                                                        <div>
                                                            
                                                            
                                                            <div style="min-height:50px;">
                                                            <%#Eval("comment")%>
                                                            </div>
                                                            <div style="float:left;margin-top: 13px;font-weight:normal;"><span class="time">On : <%#Eval("commentdate")%></span></div>
                                                            <div  style="float:right;">
                                                                <asp:Button ID="btnDelete" CommandArgument='<%# Eval("commentid")%>' CommandName="IDelete" OnClientClick='return confirm("Are you sure you wish to delete this comment?")' 
                                                                runat="server" Text="Delete" style="cursor:pointer;" class="btnc"/>
                                                            </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                               </table>
                                        </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetProductsPaged" TypeName="ClsPhotocomment" 
                                EnablePaging="True">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                                    <asp:Parameter DefaultValue="10" Name="maximumRows" Type="Int32" />
                                    <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="sq" 
                                        PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>--%>
</div>
<asp:TextBox runat="server" ID="isVerivied" Visible="false"></asp:TextBox>
                         
           </div>
           </td>
           </tr>
           
           
           </table>
        
       <%-- </ContentTemplate>
        
        </asp:UpdatePanel>
                  --%>
          

</div>
            <%--<div id="body">
                <table>
                    <tr>
                        <td id="tdphoto" runat="server" style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td id="tdlink" runat="server" style="width: 100px">
                        </td>
                    </tr>
                     <tr>
                    <td width="400px">
                    <a href="GoogleSignIn.aspx">Register To Contact This Member</a>
                    <br /><br /><br />
                    </td>
                    </tr>
                </table>
                <center>
                    <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
                        DataKeyNames="photoid" Font-Size="XX-Large" ForeColor="#333333" GridLines="None"
                        OnPageIndexChanging="gridViewPublishers_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
                        PageSize="1" Width="100%">
                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField></asp:TemplateField>
                            <asp:ImageField DataAlternateTextField="Photoname" DataImageUrlField="photoname"
                                DataImageUrlFormatString="App_Themes/{0}">
                                <ControlStyle Width="500px" Height="500px" />
                            </asp:ImageField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="Silver" />
                    </asp:GridView>
                    <br />
                    <table>
                    <tr>
                    <td colspan="2">
                    <a href="GoogleSignIn.aspx">Register To Contact This Member</a>
                    <br /><br /><br />
                    </td>
                    </tr>
 <tr>
        <td colspan="2" runat="server" id="facebookcomment">
        <div class="fb-comments" data-href="abcd" data-width="470"></div>
        </td>
        </tr>
        <tr>
        <td colspan="2" runat="server" id="googlecomments">
        <script src="https://apis.google.com/js/plusone.js"></script>
<g:comments
    href="http://www.yoursite.com"
    width="642"
    first_party_property="BLOGGER"
    view_type="FILTERED_POSTMOD">
</g:comments>
        </td>
        </tr>
</table>
                </center>
            </div>--%>
        
</asp:Content>
