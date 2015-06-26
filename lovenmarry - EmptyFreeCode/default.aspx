<%@ Page Language="VB" MasterPageFile="~/mainpage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" Title="" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="body">

        <table style="width: 100%">
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td>

                                <div class="default-Wrap">
                                    <div class="container">
                                        <div class="feature04_leftcol " style="">
                                            <b>Now With Video Calling For Free</b>
                                            <iframe width="400" height="250" src="//www.youtube.com/embed/K_KK7yLGdD8" frameborder="0" allowfullscreen ></iframe>

                                        </div>
                                        <div class=" feature04_rightcol ">
                                            <div class="default-inner">

                                                <div class="feature_section1_bg">
                                                    <h3 style=""><strong><span>Sign Up </span>with<br>
                                                        Google </strong></h3>

                                                </div>
                                                <div class="big_text1">
                                                    Create your account Now<br/>



                                                    <div class="clearfix mar_top2"></div>

                                                    <a href="Login.aspx" class=" list2"><i class="fa fa-heart "></i>Sign up Now</a>
                                                </div>

                                            </div>

                                        </div>

                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div class="default-wrap2">
                                    <div class="container">
                                        <table width="100%">
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div class="dropcap"><i class="fa fa-dollar"></i></div>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TopEarners.aspx">Top Earners</asp:HyperLink>
                                                </td>
                                                <td align="center">
                                                    <div class="dropcap"><i class="fa fa-globe"></i></div>
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;
                                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/onlinemem.aspx">Members Online Now</asp:HyperLink>
                                                </td>
                                                <td align="center">
                                                    <div class="dropcap"><i class="fa fa-users"></i></div>
                                                    <asp:HyperLink ID="HyperLink4" runat="server" Font-Italic="True" Font-Size="Large" NavigateUrl="~/browsemembers.aspx">HyperLink</asp:HyperLink>...
                                            
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="default-wrap3">
                                    <div class="container">
                                        <div class="clearfix mar_top4"></div>
                                        <ul id="listDefault">
                                            <li>We hate Fake Profiles as much as you do</li>
                                            <li>We delete fake profiles, So only real and genuine people register</li>
                                            <li>For The People Who Treat Each other as Equals</li>
                                            <li>For The People Who are open and believe in democratic relationship</li>
                                            <li>All Real Profiles</li>
                                            <li>Mobile Validated Profiles</li>
                                            <li>Only For Serious people who want to get into relationship</li>
                                            <li>Full Privacy, Your mobile number is not shown</li>
                                            <li>You Can also Password Protect Your Photos</li>
                                            <li>Profiles Verified So That you get Real People</li>
                                        </ul>
                                        <div class="clearfix mar_top4"></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="font-size: medium; text-align: center">

                                    <tr>
                                        <td>
                                            <div class="clearfix mar_top2"></div>
                                            <h4>Recently Joined</h4>
                                            <asp:Literal runat="server" ID="LiteralNewMem"></asp:Literal>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>


                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div>
    </div>

</asp:Content>
