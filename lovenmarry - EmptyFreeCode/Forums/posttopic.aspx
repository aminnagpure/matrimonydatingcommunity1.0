<%@ Page Title="" Language="VB" MasterPageFile="~/Forums/MasterPagewithads.master" AutoEventWireup="false"
    CodeFile="posttopic.aspx.vb" Inherits="Forums_posttopic" ValidateRequest="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
        <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Verdana" Font-Size="0.9em"
            PathSeparator=" : ">
            <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
            <CurrentNodeStyle ForeColor="#333333" />
            <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
            <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
        </asp:SiteMapPath>
        <br />
        <br />
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="MainTable">
                        <tr class="theader">
                            <th colspan="2" width="150" id="tdstartdate" runat="server" class="time" style="color:White;"></th>
                            
                        </tr>
                        <tr>
                            <td valign="top" class="UserDetails" style="width:170px;">
                                <div id="divStartedby" runat="server" class="Content UserName"></div>
                                <asp:Image ImageUrl="~/App_Themes/no_avatar.gif" runat="server" ID="imgposter" style="width:50px"/>
                                <div id="divTotalTopic" runat="server" class="Content"></div>
                            </td>
                            <td class="contentArea" valign="top">
                                <div class="Content" runat="server" id="divTopic"></div>
                                <hr size="1" style="color:#CECECE; background-color:#CECECE">
                                <div runat="server" id="divTopicDesc" class="contentDesc" style="min-height:78px;"></div>
                                
                            </td>
                        </tr>
                    </table>
    <br />
    <table class="style1">
        <tr>
            <td>
                Topic</td>
            <td>
                <asp:TextBox ID="txttopic" runat="server" MaxLength="250" Width="635px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txttopic" Display="Dynamic" ErrorMessage="Topic Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="325px" 
                    style="margin-right: 15px" TextMode="MultiLine" Width="636px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Content Required" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Post Topic" />
            </td>
        </tr>
    </table>

</asp:Content>
