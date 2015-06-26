<%@ Page Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="searchprofile.aspx.vb" Inherits="moderators_searchprofile" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<div id="searchform" runat="server">
    <br />
    <table width="90%">
        <tr>
            <td>
            </td>
            <td align="left" valign="top">
    <table>
        <tr>
            <td>
                Country</td>
            <td>
                <asp:DropDownList ID="dpcountry" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                State</td>
            <td>
                <asp:TextBox ID="txtstate" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Pincode</td>
            <td>
                <asp:TextBox ID="txtpincode" runat="server" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Sex</td>
            <td>
            <asp:RadioButtonList runat="server" ID="gender">
            <asp:ListItem Value="M">Male</asp:ListItem>
            <asp:ListItem Value="F">Female</asp:ListItem>
            </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Age Group</td>
            <td>
                <asp:DropDownList ID="dpage1" runat="server">
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                    <asp:ListItem>61</asp:ListItem>
                    <asp:ListItem>62</asp:ListItem>
                    <asp:ListItem>63</asp:ListItem>
                    <asp:ListItem>64</asp:ListItem>
                    <asp:ListItem>65</asp:ListItem>
                    <asp:ListItem>66</asp:ListItem>
                    <asp:ListItem>67</asp:ListItem>
                    <asp:ListItem>68</asp:ListItem>
                    <asp:ListItem>69</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
                    <asp:ListItem>71</asp:ListItem>
                    <asp:ListItem>72</asp:ListItem>
                    <asp:ListItem>73</asp:ListItem>
                    <asp:ListItem>74</asp:ListItem>
                    <asp:ListItem>75</asp:ListItem>
                </asp:DropDownList>-<asp:DropDownList ID="dpage2" runat="server">
                <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>
                    <asp:ListItem>60</asp:ListItem>
                    <asp:ListItem>61</asp:ListItem>
                    <asp:ListItem>62</asp:ListItem>
                    <asp:ListItem>63</asp:ListItem>
                    <asp:ListItem>64</asp:ListItem>
                    <asp:ListItem>65</asp:ListItem>
                    <asp:ListItem>66</asp:ListItem>
                    <asp:ListItem>67</asp:ListItem>
                    <asp:ListItem>68</asp:ListItem>
                    <asp:ListItem>69</asp:ListItem>
                    <asp:ListItem>70</asp:ListItem>
                    <asp:ListItem>71</asp:ListItem>
                    <asp:ListItem>72</asp:ListItem>
                    <asp:ListItem>73</asp:ListItem>
                    <asp:ListItem>74</asp:ListItem>
                    <asp:ListItem Selected="True">75</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Ethnicity</td>
            <td>
                <asp:DropDownList ID="dpRace" runat="server">
                 <asp:ListItem Value="">-</asp:ListItem>
                    <asp:ListItem Value="NON Caucasian">NON Caucasian</asp:ListItem>
                    <asp:ListItem Value="Black">Black</asp:ListItem>
                    <asp:ListItem Value="Caucasian/White">Caucasian/White</asp:ListItem>
                    <asp:ListItem Value="Hispanic">Hispanic</asp:ListItem>
                    <asp:ListItem Value="Indian">Indian</asp:ListItem>
                    <asp:ListItem Value="Middle Eastern">Middle Eastern</asp:ListItem>
                    <asp:ListItem Value="Native American">Native American</asp:ListItem>
                    <asp:ListItem Value="Asian">Asian</asp:ListItem>
                    <asp:ListItem Value="Mixed Race">Mixed Race</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Religion</td>
            <td>
                <asp:DropDownList ID="dpreligion" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Hindu</asp:ListItem>
                    <asp:ListItem>Christain</asp:ListItem>
                    <asp:ListItem>Muslim</asp:ListItem>
                    <asp:ListItem>Jain</asp:ListItem>
                    <asp:ListItem>Sikh</asp:ListItem>
                    <asp:ListItem>Jew</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Caste</td>
            <td>
                <asp:TextBox ID="txtCaste" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Star Sign</td>
            <td>
                <asp:DropDownList ID="dpstarsign" runat="server">
                <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Aquarius</asp:ListItem>
                    <asp:ListItem>Aries</asp:ListItem>
                    <asp:ListItem>Cancer</asp:ListItem>
                    <asp:ListItem>Capricorn</asp:ListItem>
                    <asp:ListItem>Gemini</asp:ListItem>
                    <asp:ListItem>Leo</asp:ListItem>
                    <asp:ListItem>Libra</asp:ListItem>
                    <asp:ListItem>Pisces</asp:ListItem>
                    <asp:ListItem>Sagittarius</asp:ListItem>
                    <asp:ListItem>Scorpio</asp:ListItem>
                    <asp:ListItem>Taurus</asp:ListItem>
                    <asp:ListItem>Virgo</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Profile ID</td>
            <td>
                <asp:TextBox ID="txtprofileid" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>
        Email
        </td>
        <td>
        <asp:TextBox ID="txtemail" runat="server" Width="219px"></asp:TextBox>
        </td>
        </tr>
        <tr>
            <td>
                Marital Status</td>
            <td>
                <asp:DropDownList ID="dpmaritalstatus" runat="server">
                <asp:ListItem Value="">-</asp:ListItem>
                    <asp:ListItem Value="Never Married">Never Married</asp:ListItem>
                    <asp:ListItem Value="Divorced">Divorced</asp:ListItem>
                    <asp:ListItem Value="Widow">Widow</asp:ListItem>
                    <asp:ListItem Value="Married But Looking">Married But Looking</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Height</td>
            <td>
                <asp:DropDownList ID="dpheight1" runat="server">
                    <asp:ListItem Value="">-</asp:ListItem>
                    <asp:ListItem Value="1">4.10(1.47 mts)</asp:ListItem>
                    <asp:ListItem Value="2">4.11(1.50 mts)</asp:ListItem>
                    <asp:ListItem Value="3">5.0(1.52 mts)</asp:ListItem>
                    <asp:ListItem Value="4">5.1(1.55 mts)</asp:ListItem>
                    <asp:ListItem Value="5">5.2(1.58 mts)</asp:ListItem>
                    <asp:ListItem Value="6">5.3(1.60 mts)</asp:ListItem>
                    <asp:ListItem Value="7">5.4(1.63 mts)</asp:ListItem>
                    <asp:ListItem Value="8">5.5(1.65 mts)</asp:ListItem>
                    <asp:ListItem Value="9">5.6(1.68 mts)</asp:ListItem>
                    <asp:ListItem Value="10">5.7(1.70 mts)</asp:ListItem>
                    <asp:ListItem Value="11">5.8(1.73 mts)</asp:ListItem>
                    <asp:ListItem Value="12">5.9(1.75 mts)</asp:ListItem>
                    <asp:ListItem Value="13">5.10(1.78 mts)</asp:ListItem>
                    <asp:ListItem Value="14">5.11(1.80 mts)</asp:ListItem>
                    <asp:ListItem Value="15">6.0(1.83 mts)</asp:ListItem>
                    <asp:ListItem Value="16">6.1(1.85 mts)</asp:ListItem>
                    <asp:ListItem Value="17">6.2(1.88 mts)</asp:ListItem>
                    <asp:ListItem Value="18">6.3(1.91 mts)</asp:ListItem>
                    <asp:ListItem Value="19">6.4(1.93 mts)</asp:ListItem>
                    <asp:ListItem Value="20">6.5(1.96 mts)</asp:ListItem>
                    <asp:ListItem Value="21">6.6(1.98 mts)</asp:ListItem>
                    <asp:ListItem Value="22">6.7(2.01 mts)</asp:ListItem>
                    <asp:ListItem Value="23">6.8(2.03 mts)</asp:ListItem>
                    <asp:ListItem Value="24">6.9(2.06 mts)</asp:ListItem>
                    <asp:ListItem Value="25">6.10(2.08 mts)</asp:ListItem>
                    <asp:ListItem Value="26">6.11(2.11 mts)</asp:ListItem>
                    <asp:ListItem Value="27">7.(2.13 mts)</asp:ListItem>
                </asp:DropDownList>-<asp:DropDownList ID="dpheight2" runat="server">
                    <asp:ListItem Value="">-</asp:ListItem>
                    <asp:ListItem Value="1">4.10(1.47 mts)</asp:ListItem>
                    <asp:ListItem Value="2">4.11(1.50 mts)</asp:ListItem>
                    <asp:ListItem Value="3">5.0(1.52 mts)</asp:ListItem>
                    <asp:ListItem Value="4">5.1(1.55 mts)</asp:ListItem>
                    <asp:ListItem Value="5">5.2(1.58 mts)</asp:ListItem>
                    <asp:ListItem Value="6">5.3(1.60 mts)</asp:ListItem>
                    <asp:ListItem Value="7">5.4(1.63 mts)</asp:ListItem>
                    <asp:ListItem Value="8">5.5(1.65 mts)</asp:ListItem>
                    <asp:ListItem Value="9">5.6(1.68 mts)</asp:ListItem>
                    <asp:ListItem Value="10">5.7(1.70 mts)</asp:ListItem>
                    <asp:ListItem Value="11">5.8(1.73 mts)</asp:ListItem>
                    <asp:ListItem Value="12">5.9(1.75 mts)</asp:ListItem>
                    <asp:ListItem Value="13">5.10(1.78 mts)</asp:ListItem>
                    <asp:ListItem Value="14">5.11(1.80 mts)</asp:ListItem>
                    <asp:ListItem Value="15">6.0(1.83 mts)</asp:ListItem>
                    <asp:ListItem Value="16">6.1(1.85 mts)</asp:ListItem>
                    <asp:ListItem Value="17">6.2(1.88 mts)</asp:ListItem>
                    <asp:ListItem Value="18">6.3(1.91 mts)</asp:ListItem>
                    <asp:ListItem Value="19">6.4(1.93 mts)</asp:ListItem>
                    <asp:ListItem Value="20">6.5(1.96 mts)</asp:ListItem>
                    <asp:ListItem Value="21">6.6(1.98 mts)</asp:ListItem>
                    <asp:ListItem Value="22">6.7(2.01 mts)</asp:ListItem>
                    <asp:ListItem Value="23" Selected="True">6.8(2.03 mts)</asp:ListItem>
                    <asp:ListItem Value="24">6.9(2.06 mts)</asp:ListItem>
                    <asp:ListItem Value="25">6.10(2.08 mts)</asp:ListItem>
                    <asp:ListItem Value="26">6.11(2.11 mts)</asp:ListItem>
                    <asp:ListItem Value="27">7.(2.13 mts)</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                Photos</td>
            <td>
                <asp:CheckBox ID="chkphoto" runat="server" Text="Only With Photo" /></td>
        </tr>
        <tr>
            <td>
                Online</td>
            <td>
                <asp:CheckBox ID="chkonlinenow" runat="server" Text="Online Now" /></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Search" /></td>
        </tr>
    </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    &nbsp;</div>
   </center>
   <center>
    <div id="searchresults" runat="server">
        <asp:GridView ID="gridViewPublishers" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No records found"
            Font-Size="Medium" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gridViewPublishers_PageIndexChanging"
            PagerSettings-Mode="NumericFirstLast" Width="80%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" Font-Size="XX-Large" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                        <tr>
                        <td align="left" valign="top">
                        Ipaddress:<%# Eval("ipaddress") %>
                        </td>
                        </tr>
                            <tr>
                                <td align="left">
                                    <a href='viewprofile.aspx?pid=<%# Eval("pid") %>'>View Profile</a><br />
            Age(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Email:<%# Eval("email") %><br />
                                    Password:<%# Eval("passw") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        Gender:<%# Eval("gender") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        Purpose:<%# Eval("purpose") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
        <%#Eval("countryname")%> 
                                    <br />
                                    <%#Eval("state")%>
                                    <br />
                                    <%# Eval("cityid") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ControlStyle Width="10%" />
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <a href='editreg.aspx?pid=<%# Eval("pid") %>'>Edit Profile</a><br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <table width="100%">
                            <tr>
                                <td style="word-wrap: break-word; word-break: break-all; width: 450px;" valign="top">
        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 400))%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ControlStyle Width="50%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td style="font-size: 16px;">
                                    <%# Eval("ethnic") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 16px;">
                                    <%# Eval("religion") %> 
                                </td>
                                <tr>
                                    <td style="font-size: 10px;">
        <%#Eval("caste")%>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField AccessibleHeaderText="imgname" DataAlternateTextField="photoname"
                    DataImageUrlField="photoname" DataImageUrlFormatString="../App_Themes/{0}" NullImageUrl="../App_Themes/no_avatar.gif">
                    <ControlStyle Height="80px" Width="100px" />
                </asp:ImageField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <a href='removeprofile.aspx?pid=<%# Eval("pid") %>'>Delete Profile</a><br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
            <ItemTemplate>           
           <a href='sendmsg.aspx?pid=<%# Eval("pid") %>'>Send Message</a><br />
            </ItemTemplate>
            </asp:TemplateField>
            
            </Columns>
            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        </asp:GridView>
        <br />
        <asp:Label ID="label1" runat="server"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        
    
    </div>
</center>     
</asp:Content>

