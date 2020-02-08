<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tmam.aspx.cs" Inherits="Planning.Admin.Tmam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="body" class="width" style="direction:rtl"">

        <h3 runat="server" style="margin-right:400px; margin-top:50px; margin-bottom:50px">
            <asp:Label ID="subject" runat="server" Text="Our Title will be here"></asp:Label>
        </h3>
        

        <form id="form1" runat="server">

            <asp:Button ID="day" runat="server" OnClick="day_Click" style="font-size:20px; margin-left: 50px; margin-bottom: 20px; border-radius:7%" CssClass="formbutton" Text="التمـام عـن يـوم" Height="40px" />

            <table  style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5);border-collapse:collapse;direction:rtl">
                <tr style="text-align:center">
                    <th  style="width:5%; font-size:20px">الرقم</th>
                    <th style="width:15%; font-size:20px">الرتبه</th>
                    <th style="width:50%; font-size:20px">الأسم</th>
                    <th style="width:20%; font-size:20px">التمام</th>
                </tr>
                <asp:Repeater runat="server" ID="rptrFields">
                    <ItemTemplate>
                        <tr>
                            
                            
                            
                            <td style="text-align:center; font-size:20px"><%= tableIndex %></td>
                                <%tableIndex++; %>
                            <div style="text-align:center; font-size:20px">
                              <td> <asp:Label ID="Label1" runat="server" style="text-align:center; font-size:30px" Text='<%#Eval("rank") %>'></asp:Label></td>
                            </div>
                             <div style="text-align:center; font-size:30px">
                            <td> <asp:Label ID="Label2" runat="server"  style="text-align:center; font-size:30px"  Text='<%#Eval("O_name") %>'></asp:Label></td>
                            </div>
                            <td runat="server" visible="false">  <asp:Label ID="Label3" runat="server"  style="text-align:center; font-size:30px"  Visible="false" Text='<%#Eval("id") %>'></asp:Label></td>

                            
                        
                            <td style="text-align: center;">
                                <asp:DropDownList ID="accountType" Enabled ="true" runat="server" style="width:200px; border-radius:10%; font-size:20px" AutoPostBack="true" OnSelectedIndexChanged="accountType_SelectedIndexChanged">
                                    <asp:ListItem Value="1">موجود</asp:ListItem>
                                    <asp:ListItem Value="2"> سنوية</asp:ListItem>
                                    <asp:ListItem Value="3"> أجازة عارضة</asp:ListItem>
                                    <asp:ListItem Value="4"> عارضة طارئة</asp:ListItem>
                                    <asp:ListItem Value="5"> مرضية</asp:ListItem>
                                    <asp:ListItem Value="6"> بدل راحة</asp:ListItem>
                                    <asp:ListItem Value="7"> فرقة</asp:ListItem>
                                    <asp:ListItem Value="8"> مأمورية خارجية</asp:ListItem>
                                    <asp:ListItem Value="9"> مأمورية</asp:ListItem>
                                    <asp:ListItem Value="10"> تفرغ .د عليا</asp:ListItem>
                                    <asp:ListItem Value="11"> تفرغ بحوث</asp:ListItem>
                                    <asp:ListItem Value="12"> تفرغ جزئى</asp:ListItem>
                                    <asp:ListItem Value="13"> تفرغ كلى</asp:ListItem>
                                    <asp:ListItem Value="14"> علاج طبيعى</asp:ListItem>
                                    <asp:ListItem Value="15"> مستشفى</asp:ListItem>
                                    <asp:ListItem Value="16"> منحة وفاة</asp:ListItem>
                                    <asp:ListItem Value="17"> منحة</asp:ListItem>
                                    <asp:ListItem Value="18"> نوبتجى</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <table style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5);
                    border-collapse: collapse;
                    direction: rtl; margin-top:40px"
            ">

                <tr style="text-align:center">
                    <th style="font-size:20px">قوة</th>
                    <th style="font-size:20px">موجود</th>
                    <th style="font-size:20px">خارج</th>
                    <th style="font-size:20px">سنوية</th>
                    <th style="font-size:20px">أجازة عارضة</th>
                    <th style="font-size:20px">أجازة طارئة</th>
                    <th style="font-size:20px">مرضية</th>
                    <th style="font-size:20px">بدل راحة</th>
                    <th style="font-size:20px">فرقة</th>
                    <th style="font-size:20px">مأمورية خارجية</th>
                    <th style="font-size:20px">مأمورية</th>
                    <th style="font-size:20px">تفرغ .د عليا</th>
                    <th style="font-size:20px">تفرغ بحوث</th>
                    <th style="font-size:20px">تفرغ جزئى</th>
                    <th style="font-size:20px">تفرغ كلى</th>
                    <th style="font-size:20px">علاج طبيعى</th>
                    <th style="font-size:20px">مستشفى</th>
                    <th style="font-size:20px">منحة وفاة</th>
                    <th style="font-size:20px">منحة</th>
                    <th style="font-size:20px">نوبتجى</th>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label91" runat="server" Text='<%#Eval("count") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("mawgod") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text='<%#Eval("khareg") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("sanwya") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("arda") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("tarka") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("mardy") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("raha") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("ferka") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("m_khargy") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("mamorya") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("olya") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("bohos") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("gozy") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("kolly") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text='<%#Eval("elag") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("mostshfa") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("wafah") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text='<%#Eval("menha") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text='<%#Eval("nobatshy") %>'></asp:Label>
                    </td>
                </tr>
                    
                
                <!--
                <asp:Repeater runat="server" ID="Repeater1">
                    <ItemTemplate>
                        <tr>
                            
                            <td style="text-align:center; font-size:20px"><%= tableIndex %></td>
                                <%tableIndex++; %>
                            <div style="text-align:center; font-size:20px">
                              <td> </td>
                            </div>
                             <div style="text-align:center; font-size:30px">
                            <td> <asp:Label ID="Label2" runat="server"  style="text-align:center; font-size:30px"  Text='<%#Eval("O_name") %>'></asp:Label></td>
                            </div>
                            <td runat="server" visible="false">  <asp:Label ID="Label3" runat="server"  style="text-align:center; font-size:30px"  Visible="false" Text='<%#Eval("id") %>'></asp:Label></td>                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>-->

            </table>

            <p>
                <asp:Button ID="save" runat="server" OnClick="SaveButton_Click" style="font-size:20px; margin-left: 50px; margin-right: 600px; margin-top: 20px; border-radius:7%" CssClass="formbutton" Text="حفظ" Height="40px" Width="100px"/>&nbsp;&nbsp;
                <asp:Button ID="print" runat="server" style="font-size:20px; margin-left: 50px; margin-right: 0px; margin-top: 20px; border-radius:7%" Text="طباعه" Height="40px" Width="100px"/>&nbsp;&nbsp;
            </p>&nbsp;&nbsp;
        </form>


        
    </div>

</asp:Content>
