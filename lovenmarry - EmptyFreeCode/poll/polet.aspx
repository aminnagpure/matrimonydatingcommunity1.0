<%@ Page Title="" Language="VB" MasterPageFile="~/poll/MasterPageWOLogin.master"
    AutoEventWireup="false" CodeFile="polet.aspx.vb" Inherits="pole_polet" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="headContent">
    <style type="text/css">
        .PollQues {
            font-size: 10pt;
            color: Black;
            font-family: 'Droid Sans', sans-serif;
        }

        .PollOpt {
            border: 2px #979797 solid;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
        }

        #ctl00_ContentPlaceHolder1_rblist td {
            background: White;
            padding: 2px;
        }

            #ctl00_ContentPlaceHolder1_rblist td:hover, label:hover {
                background: #EBEBEB;
                cursor: pointer;
            }

        #ctl00_ContentPlaceHolder1_PollGraph {
            border: 2px #979797 solid;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            padding: 9px 2px 5px;
        }

        .Graphtbl {
            font-size: 13px;
            margin-bottom: 13px;
        }

            .Graphtbl div {
                float: left;
            }

        .pollsummary {
            text-align: center;
            font-size: 18px;
            padding: 5px;
        }

        .pollvalue {
            padding-right: 2px;
        }

        .scal {
            background: url(http://www.websolnetwork.com/Scal.gif);
            background-repeat: repeat-x;
            line-height: 8px;
            background-color: #9FCF8F;
        }

        .PollCpmments tr {
            background: #F2F6F8 url(http://www.websolnetwork.com/App_Themes/Blue/FuoumImages/grey-up.png) repeat-x left bottom;
            width: 100%;
            clear: both;
            position: relative;
        }

        .PollCpmments td {
            padding: 7px 2px 7px;
        }

        .tab1 a {
            color: rgb(59, 89, 152);
            text-decoration: underline;
            font-family: arial,lucida console,sans-serif;
            font-size: 12px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            letter-spacing: normal;
            line-height: 17px;
            orphans: 2;
            text-align: left;
            text-indent: 0px;
            text-transform: none;
            white-space: normal;
            widows: 2;
            word-spacing: 0px;
            -webkit-text-size-adjust: auto;
            -webkit-text-stroke-width: 0px;
            text-decoration: none;
        }

            .tab1 a:hover {
                text-decoration: underline;
                color: #FF4400;
            }

        .Content {
            color: rgb(59, 89, 152);
            text-decoration: underline;
            font-family: arial,lucida console,sans-serif;
            font-size: 12px;
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            letter-spacing: normal;
            line-height: 17px;
            orphans: 2;
            text-align: left;
            text-indent: 0px;
            text-transform: none;
            white-space: normal;
            widows: 2;
            word-spacing: 0px;
            -webkit-text-size-adjust: auto;
            -webkit-text-stroke-width: 0px;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function GetRadioButtonSelectedValue() {
            var AspRadio = document.getElementsByName('rblist');

            for (var i = 0; i < AspRadio.length; i++) {

                if (AspRadio[i].checked) {
                    var lblAspradiobuttonValue = document.getElementById('<%= lbldis.ClientID %>');

                    lblAspradiobuttonValue.innerHTML = '<b>Selected Value:</b> ' + AspRadio[i].value + '<br/>';
                    lblAspradiobuttonValue.innerHTML += '<b>Selected Text:</b> ' + AspRadio[i].parentNode.getElementsByTagName('label')[0].innerHTML;
                } //end if

            } // end for

        } //end function
        function GoTo(url) { window.parent.location = url; return false; }
    </script>
    <div id="body">
        <table style="width: 100%">
            <tr>
                <td></td>
                <td colspan="2"></td>
            </tr>
            <tr valign="top">
                <td style="width: 20%; text-align: left; vertical-align: top">
                    <table style="width: 100%">
                        <tr>
                            <td id="tdmainimg" style="height: 200px; width: 180px" runat="server" valign="top"></td>
                        </tr>
                        <tr>
                            <td class="Forums">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="Sno" Width="100%" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <strong>Users Recent Polls</strong>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table class="SubTopic" style="width: 100%">
                                                    <tr>
                                                        <td class="tab1">
                                                            <a href='polet.aspx?id=<%# Eval("Sno") %>'>
                                                                <%#Eval("QsnDesc")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                                    <RowStyle Font-Size="Small" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="Small" />
                                    <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Size="Small" />
                                    <AlternatingRowStyle />
                                </asp:GridView>
                                <br />
                                <a id="UserMore" href="Default.aspx" runat="server">More... </a>
                                <br>
                                <br>

                                <div style="width: 200px; margin-left: 10px;" runat="server" id="div1">
                                    <img src="http://placehold.it/200X90/D3CDBB/fff/&text=Ads 200X90" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 60%" valign="top" class="Forums">
                    <fieldset style="border-color: Red; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
                        <legend style="color: Green;">Poll Question</legend>
                        <div id="divPoll" runat="server">
                            <table width="100%" class="PollQues">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Q ). "></asp:Label>
                                        <asp:Label ID="lblque" Font-Bold="true" runat="server"></asp:Label>
                                        <asp:Label ID="lblqid" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="PollOpt">
                                        <asp:RadioButtonList ID="rblist" runat="server" Width="100%">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblist"
                                            Display="Dynamic" ErrorMessage="Please Select  one option" ValidationGroup="P"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span>Your Comments</span><br />
                                        <asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--<tr id="trRating" runat="server">
                                <td colspan="2">
                                 Rate This Poll
                                 <table border="0" cellpadding="0" cellspacing="0" width="100%" class="PollOpt">
                                 <tr>
                                    <td width="80" style="padding-left:3px;">
                                        Rating Type:</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlRatingType">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        
                                        <asp:ListItem Value="+">Positive</asp:ListItem>   
                                        <asp:ListItem Value="-">Negative</asp:ListItem>    
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ErrorMessage="Please Select Rating Type" Display="Dynamic" 
                                            ControlToValidate="ddlRatingType" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:3px;">
                                        <asp:Label ID="Label3" runat="server" Text="Rating"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRating" runat="server">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="ddlRating" Display="Dynamic" 
                                            ErrorMessage="Please Select Rating" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 </table>   
                                 </td>
                            </tr>--%>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="Mybutton" Style="cursor: pointer; float: left;"
                                            ValidationGroup="P" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" class="Mybutton" OnClientClick="return confirm('Do You Really Want to Delete This Poll?');"
                                            Style="cursor: pointer; float: right;" Visible="False" />
                                    </td>
                                    <td width="100">
                                        <asp:LinkButton ID="btnReportAbuse" runat="server" class="Mybutton" Style="color: White;">Report Abuse</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                    <table width="100%" class="PollQues">
                        <tr>
                            <td colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <div runat="server" id="div_pollrate">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="False">LinkButton</asp:LinkButton>
                                            <asp:Label ID="lbldis" runat="server"></asp:Label>
                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                            <div runat="server" id="PollGraph">
                                            </div>
                                            <br />
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="CreateQue.aspx" class="Mybutton"
                                                Width="125">Post A New Poll</asp:HyperLink>
                                            <br />
                                            <br />
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                Width="100%" DataKeyNames="SNo" DataSourceID="ObjectDataSource1" GridLines="Horizontal"
                                                class="PollCpmments">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkdel" runat="server" OnClientClick='return confirm("Are you sure you wish to delete this reply?")'
                                                                CommandName="Rdelete" CommandArgument='<%#Eval("SNo") %>' OnCommand="OnDelete"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <a href='../members/viewprofile.aspx?pid=<%# Eval("CreationLogInId") %>'>
                                                                <asp:Image ID="img" runat="server" Height="30px" Width="25px" /></a><br />
                                                            <a href='../members/viewprofile.aspx?pid=<%# Eval("CreationLogInId") %>'>
                                                                <%#Eval("fname")%></a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                        <ItemStyle Width="110px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Poll Details">
                                                        <ItemTemplate>
                                                            <div>
                                                                Voted:<span class="Content">
                                                                    <%#Eval("poleAns")%></span>
                                                            </div>
                                                            <br />
                                                            <div class="contentDesc">
                                                                <%#Eval("polecomment")%>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Font-Size="14px" />
                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle Font-Size="Large" />
                                            </asp:GridView>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetProductsPaged" TypeName="clsShowAllPollComments">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                            <asp:Parameter DefaultValue="100" Name="maximumRows" Type="Int32" />
                            <asp:ControlParameter ControlID="txtcriteria1" DefaultValue="" Name="sq" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:TextBox ID="txtcriteria1" Visible="false" Text=" 1=1 " runat="server"></asp:TextBox>
                    <br />
                </td>
                <td style="width: 20%; text-align: left; vertical-align: top" valign="top" class="Forums">
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" EmptyDataText="No Polls found"
                        AutoGenerateColumns="False" DataKeyNames="Sno" Width="100%" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <strong>Recent Polls</strong>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="SubTopic">
                                        <tr>
                                            <td class="tab1">
                                                <a href='polet.aspx?id=<%# Eval("Sno") %>'>
                                                    <%#Eval("QsnDesc")%>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                        <RowStyle Font-Size="Small" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="Small" />
                        <HeaderStyle Font-Bold="True" ForeColor="Black" Font-Size="Small" />
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <br />
                    <a href="Default.aspx">More... </a>
                    <br>
                    <br>
                    <div style="width: 200px; margin-left: 10px;" runat="server" id="div_LinkAd">
                        <img src="http://placehold.it/200X90/D3CDBB/fff/&text=Ads 200X90" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>
