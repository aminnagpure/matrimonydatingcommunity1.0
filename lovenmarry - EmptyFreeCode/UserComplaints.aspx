<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false" CodeFile="UserComplaints.aspx.vb" Inherits="UserComplaints" title="User Complaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
#ctl00_ContentPlaceHolder1_GridView1 .messageAreaP {
background: #fafeff;
border-color: #b5cdd7;
margin-left: 20px;}
#ctl00_ContentPlaceHolder1_GridView1 .messageAreaR {
background: #D7EED7;
border-color: #b5cdd7;
margin-left: 20px;}
</style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
    <div style="padding:5px;">
        <table border="0" cellpadding="5" cellspacing="0" width="100%">
            <tr>
                <td style="width:200px;"></td>
                <td>
                    
                </td>
                <td style="width:200px;"></td>
            </tr>
            <tr>
                <td style ="vertical-align :top;" >
                     <img src="http://placehold.it/200X200/D3CDBB/fff/&text=Ads 200X200" />
                
                    <br>

                </td>
                <td>
                <div  style="padding:10px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="80">Name</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" MaxLength="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ControlToValidate="txtName" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
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
                            <td>Subject</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtSubject" MaxLength="500" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                    ControlToValidate="txtSubject" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top">Complaint</td>
                            <td ></td>
                            <td>
                                <asp:TextBox ID="txtComplaints" TextMode="MultiLine" MaxLength="5000" 
                                    runat="server" Height="227px" Width="449px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtComplaints" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                        </tr>
                        <tr><td>
                   
             <label>Enter Character</label><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtCaptcha" Display="Dynamic" ErrorMessage="Kindly input captcha code" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>                 
                   <asp:TextBox ID="txtCaptcha" runat="server" placeholder="Enter Code" CssClass="form-control"></asp:TextBox>
                    
                    <label>Code</label> 
                      <asp:Image ID="Image2" runat="server" ImageUrl="~/Captcha.aspx" Height="27px" style="padding:0;margin-bottom:-8px;"/>
                            
                    </div>
               
         </div> </td></tr>
                        <tr>
                            <td valign="top"></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                            </td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                <center><h3>User Complaint List</h3></center>
                    <asp:GridView ID="GridView1" AllowPaging="True" AutoGenerateColumns="False" 
                                    PagerSettings-Mode="NumericFirstLast" runat="server" Width="100%" 
                                    Font-Size="Small" 
                            GridLines="None" DataSourceID="ObjectDataSource1" 
                        EnableTheming="False">
                                    
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
                                                    
                                                    <td class ="by_user">
                                                       <div class ='messageArea <%#Eval("BGCls")%>' style="margin:0px;">
                                                          <div class ="infoRow " > <span class ="name ">
                                                           
                                                           <strong >Subject : 
                                                               <a href='UserComplaionts_Details.aspx?id=<%#Eval("ComplaintID") %>'> <%#Eval("ComplaintHead")%></a>
                                                            </strong></span>
                                                            
                                                           </div> 
                                                           
                                                           <div style =" margin-left : 10px;margin-top:5px;">
                                                           <%#Eval("ComplaintDesc")%>
                                                           </div>
                                                           <hr class ="line1 "/>
                                                           <div class ="infoRow " > <span class ="name ">
                                                           
                                                           <strong >By : 
                                                                <%#Eval("UserName")%>
                                                            </strong></span>
                                                            <span class ="time"> on : <%#FormatDate(Eval("ComplaintDate"))%></span>
                                                           </div> 
                                                           <hr class ="line1 "/>
                                                           <div align="right" >
                                                                <a style="text-decoration:none;" href='UserComplaionts_Details.aspx?id=<%#Eval("ComplaintID") %>'>View & Reply</a>
                                                                <asp:LinkButton Visible="false" ID="btnDelete" ValidationGroup="N" CommandArgument='<%# Eval("ComplaintID")%>' CommandName="IDelete" runat="server" Text="Delete"  style="cursor:pointer;"><i class ="icon-trash"></i></asp:LinkButton>
                                                           </div>
                                                         </div>
                                                    </td>
                                                    <td width="5px">
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
                        TypeName="User_ComplaintsCls">
                        <SelectParameters>
                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                            <asp:Parameter Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="TextBox1" Name="sq" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
    </div>
</div>
</asp:Content>

