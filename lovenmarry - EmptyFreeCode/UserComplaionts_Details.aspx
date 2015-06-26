<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="UserComplaionts_Details.aspx.vb" Inherits="UserComplaionts_Details" title="Complain Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <div style="padding:5px;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width:200px;"></td>
                <td>
                </td>
                <td style="width:200px;"></td>
                
            </tr>
            <tr>
                <td  style ="vertical-align : bottom ; padding-right:10px ">
                
                <div>
                    <img src="http://placehold.it/200X200/D3CDBB/fff/&text=Ads 200X200" />
                   
                        <br>
                </div>
                            </td>
                <td>
                <div  style="padding:10px;">
                <h3>Complaints Description</h3>
                <table class ="messagesOne " width="100%" cellpadding="0" cellspacing="0"  style ="margin :0px;font-size:12px;">
                    <tr>
                        <td class ="by_user ">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="messageArea" style ="margin :0px;">
                        <tr>
                            <td runat="server" id="tdCompH"  class ="infoRow ">
                                
                            </td>
                        </tr>
                        <tr>
                            <td runat="server" id="tdCopmD" ></td>
                        </tr>
                        <tr>
                            <td class ="infoRow">&nbsp;</td>
                        </tr>
                        <tr>
                            <td runat="server" id="tdCompBy" class ="infoRow  "></td>
                        </tr>
                    </table>
                        </td>                    
                    </tr>
                </table>
                
                 </div>
                <div id="div_User_Details" runat="server" style="padding:10px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    
                        <tr>
                            <td>&nbsp;</td>
                            <td >&nbsp;</td>
                            <td>
                                
                                Enter Your Mobile and Email ID to Reply</td>
                        </tr>
                    
                        <tr>
                            <td>Mobile</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtMobile" MaxLength="20" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                    ControlToValidate="txtMobile" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
    ErrorMessage="Mobile not valid" ControlToValidate="txtMobile" 
    ValidationExpression="[0-9]{11}|[0-9]{10}" ></asp:RegularExpressionValidator>    
                                    </td>
                             
                        </tr>
                        <tr>
                            <td>Email-ID</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtEmailID" MaxLength="250" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                    ControlToValidate="txtEmailID" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtEmailID" Display="Dynamic" 
                                    ErrorMessage="Not a valid Email ID" SetFocusOnError="True" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Continue" />
                            </td>
                        </tr>
                    </table>
                 </div>
                 <div id="div_CommentsBox" runat="server" visible="false" style="padding:10px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                            <td width="80">Name</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" MaxLength="250" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ControlToValidate="txtName" ErrorMessage="*" SetFocusOnError="True" 
                                    ValidationGroup="SC"></asp:RequiredFieldValidator>
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblMobileMod" runat="server" Text="Mobile" Visible="False"></asp:Label>
                            </td>
                            <td >&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtMobileMod" runat="server" MaxLength="250" Visible="False"></asp:TextBox>
                                        </td>
                        </tr>
                       <tr>
                            <td valign="top">
                                <asp:Label ID="lblEmailMod" runat="server" Text="Email" Visible="False"></asp:Label>
                            </td>
                            <td >&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtEmailMod" runat="server" MaxLength="250" ReadOnly="True" 
                                    Visible="False"></asp:TextBox>
                                        </td>
                        </tr>
                       <tr>
                            <td valign="top">Comments</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtComplaints" TextMode="MultiLine" MaxLength="5000" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txtComplaints" ErrorMessage="*" SetFocusOnError="True" 
                                    ValidationGroup="SC"></asp:RequiredFieldValidator>
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;</td>
                            <td >&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" 
                                    Text="Mark As Resolved" />
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnComments" runat="server" Text="Submit" 
                                    ValidationGroup="SC" />
                            </td>
                        </tr>
                    </table>
                 </div>
                </td>
                <td valign="top">
              <div style="width:180px;margin-left:18px;">
                <br />
                <br />
               
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                <asp:GridView ID="GridView1" AllowPaging="True" AutoGenerateColumns="False" 
                                    PagerSettings-Mode="NumericFirstLast" runat="server" Width="100%" 
                                    Font-Size="Small" 
                            GridLines="None" DataSourceID="ObjectDataSource1">
                                    
                                    <FooterStyle  />
                                    <SelectedRowStyle VerticalAlign="Top" />
                                    <HeaderStyle  />
<PagerSettings Mode="NumericFirstLast"></PagerSettings>

                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                       <div style="width:100%">
                                       
                                            <table width="100%" class ="messagesOne " style="margin:0px;">
                                                <tr>
                                                    
                                                    <td class ="by_me">
                                                       <div class ="messageArea" style="margin:0px">
                                                          <div class ="infoRow " > <span class ="name ">
                                                           
                                                           <strong ><%#Eval("ComplaintHead")%>
                                                            </strong></span>
                                                            
                                                           </div> 
                                                           
                                                           <div style =" margin-left : 10px;margin-top:5px;">
                                                           <%#Eval("Comments")%>
                                                           </div>
                                                           <br />
                                                           <div class ="infoRow " > <span class ="name ">
                                                          
                                                           <strong >By : 
                                                                <%#Eval("CommentsByName")%>
                                                            </strong></span>
                                                            <span style ="float :right ;" >&nbsp;<asp:LinkButton Visible="false" ID="btnDelete" ValidationGroup="N" CommandArgument='<%# Eval("CommentsID")%>' CommandName="IDelete" runat="server" Text="Delete"  style="cursor:pointer;"><i class ="icon-trash"></i></asp:LinkButton>&nbsp;</span>
                                                            <span class ="time"> on : <%#FormatDate(Eval("CommentsDate"))%></span>
                                                           </div> 
                                                           <div align="right" >
                                                           
                                                               
                                                           </div>
                                                         </div>
                                                    </td>
                                                    
                                                </tr>
                                               
                                            </table>
                                                                                             
                                        </div>
                                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsPaged" 
                        TypeName="UserComplaints_DetailsCls">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="TextBox1" Name="sq" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value=""/>
                    <asp:HiddenField ID="HiddenField2" runat="server" Value="" />
                </td>
                <td></td>
            </tr>
        </table>    
   </div>
</div>
</asp:Content>

