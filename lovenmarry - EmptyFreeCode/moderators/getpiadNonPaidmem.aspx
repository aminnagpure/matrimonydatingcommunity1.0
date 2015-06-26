<%@ Page Title="" Language="VB" MasterPageFile="~/moderators/MasterPage.master" AutoEventWireup="false" CodeFile="getpiadNonPaidmem.aspx.vb" Inherits="getpiadNonPaidmem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="body">
<div id="searchform" runat="server">
            <table width="100%">
                <tr>
                    <td style="height: 662px">
                    </td>
                    <td align="left" style="height: 662px">
                        <table>
                            <tr>
                                <td>
                                    Country
                                </td>
                                <td>
                                    <asp:DropDownList ID="dpcountry" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    State
                                </td>
                                <td>
                                    <asp:TextBox ID="txtstate" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Pincode
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpincode" runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sex
                                </td>
                                <td>
                                    <asp:RadioButtonList runat="server" ID="gender">
                                        <asp:ListItem Value="M" Selected ="True" >Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Age Group
                                </td>
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
                                    </asp:DropDownList>
                                    -<asp:DropDownList ID="dpage2" runat="server">
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
                                        <asp:ListItem Selected="True">30</asp:ListItem>
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
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ethnicity
                                </td>
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
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Religion
                                </td>
                                <td>
                                    <asp:DropDownList ID="dpreligion" runat="server">
                                        <asp:ListItem Value="">-</asp:ListItem>
                                        <asp:ListItem>Hindu</asp:ListItem>
                                        <asp:ListItem>Christain</asp:ListItem>
                                        <asp:ListItem>Muslim</asp:ListItem>
                                        <asp:ListItem>Jain</asp:ListItem>
                                        <asp:ListItem>Sikh</asp:ListItem>
                                        <asp:ListItem>Jew</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td id="TD1" runat="server" visible="false">
                                    Caste
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Star Sign
                                </td>
                                <td>
                                    <asp:DropDownList ID="dpstarsign" runat="server">
                                        <asp:ListItem Value="">-</asp:ListItem>
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
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Marital Status
                                </td>
                                <td>
                                    <asp:DropDownList ID="dpmaritalstatus" runat="server">
                                        <asp:ListItem Value="">-</asp:ListItem>
                                        <asp:ListItem Value="Never Married">Never Married</asp:ListItem>
                                        <asp:ListItem Value="Divorced">Divorced</asp:ListItem>
                                        <asp:ListItem Value="Widow">Widow</asp:ListItem>
                                        <asp:ListItem Value="Married But Looking">Married But Looking</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Height
                                </td>
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
                                    </asp:DropDownList>
                                    -<asp:DropDownList ID="dpheight2" runat="server">
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
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Photos
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkphoto" runat="server" Text="Only With Photo" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Online
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkonlinenow" runat="server" Text="Online Now" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Order By
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="profiledate">Newly Registered First</asp:ListItem>
                                        <asp:ListItem Value="lastvisited">Most Active </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Save The Query
                                </td>
                                <td>
                                    <asp:TextBox ID="txtqueryname" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email
                                </td>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                                    <br />
                                    (if you wish to recieve
                                    email alerts, needs verification)
                                </td>
                            </tr>
                            <tr>
                                <td>type premiummem or non</td>
                                <td><asp:DropDownList ID="ddlPaidNone" runat="server">
     <asp:ListItem Value ="N" Selected ="True"  >Non Paid</asp:ListItem>
        <asp:ListItem Value ="Y" >Paid</asp:ListItem>
       
    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Search" />
                                    <asp:TextBox ID="txtquery" runat="server" Height="25px" TextMode="MultiLine" 
                                        Width="176px" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 314px; height: 662px;">
                    
                    </td>
                </tr>
            </table></div>
        
     <div id="searchresults" runat="server" visible = "false" >
    
    
    
 <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="False">1=1</asp:TextBox><asp:TextBox
                    ID="txtjointype" runat="server" Visible="False"></asp:TextBox><br />
    <asp:GridView ID="gridview1" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No records found"
                    PagerSettings-Mode="NumericFirstLast" CssClass="splfor  data" runat="server"
                    Width="80%" CellPadding="3" Font-Size="Small" DataSourceID="ObjectDataSource1"
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Font-Size="XX-Large" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" Font-Size="Large" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" Font-Size="XX-Large" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left; vertical-align: top;">
                                    <tr>
                                       
                                        <td style="text-align: left; vertical-align: top;">
                                            <table style="width: 100%; text-align: left; vertical-align: top;">
                                                <tr>
                                                    <td style="width: 200px; text-align: left; vertical-align: top;">
                                                        <a href="viewprofile.aspx?pid=<%# Eval("pid") %>">
                                                            <%# Eval("fname") %></a>(<%#DateDiff(DateInterval.Year, Eval("bdate"), Date.Now)%>)<br />
                                                        Gender:<%# Eval("gender") %><br />
                                                        Email:<%#Eval("email")%><br />
                                                        Mobile:<%#Eval("mobile")%><br />
                                                        premiummem:<%#Eval("premiummem")%><br />
                                                        Purpose:<%# Eval("purpose") %><br />
                                                        <%#Eval("countryname")%>
                                                        <br />
                                                        <%#Eval("state")%><br />
                                                        <%# Eval("cityname") %>
                                                        <br />
                                                        <%# Eval("ethnic") %>
                                                        <%# Eval("religion") %>
                                                        <%#Eval("caste")%>
                                                    </td>
                                                    <td colspan="2" style="width: 250px;">
                                                        <%#cf.BreakWordForWrap(Mid(Eval("whoami"), 1, 300))%>
                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                </asp:GridView>
                &nbsp;
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetProductsPaged" TypeName="classpartnersearch" EnablePaging="True">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
                        <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
                        <asp:Parameter DefaultValue="left join" Name="jointype" Type="String" />
                        <asp:ControlParameter ControlID="txtquery" DefaultValue="1=1" Name="sq" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </div>
       
    </div>                                                                   
</asp:Content>

