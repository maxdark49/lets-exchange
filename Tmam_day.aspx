<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tmam_day.aspx.cs" Inherits="Planning.Admin.Tmam_day" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="body" class="width" style="direction:rtl">
        <form id="form1" runat="server">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <label for="name" style="font-size:20px">عـن يـوم : </label>
            <input type="date" runat="server" ID="test5" value="date" name="test5"  min="2013-01-01" max="dayDate" />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="DateTime"></asp:TextBox>

            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="TextBox1"   Format="dd/MM/yyyy"/>
            <asp:Button ID="show" runat="server" OnClick="show_Click" style="font-size:20px; border-radius:7%" CssClass="formbutton" Text="عـرض" Height="40px" Width="100px"/>
        
            <table  style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5);border-collapse:collapse;direction:rtl">
                <tr style="text-align:center">
                    <th  style="font-size:20px">الرقم</th>
                    <th  style="font-size:20px">الرتبه</th>
                    <th style="font-size:20px">الأسم</th>
                    <th style="font-size:20px">التاريخ</th>
                    <th style="font-size:20px">التمام</th>
                    <th style="font-size:20px">تعديل</th>
                </tr>
                <asp:Repeater runat="server" ID="rptrFields">
                    <ItemTemplate>
                        <tr>
                            
                            <td style="text-align:center; font-size:30px"><%= tableIndex %></td>
                                <%tableIndex++; %>
                            <div style="text-align:center; font-size:30px">
                              <td> <asp:Label ID="Label5" runat="server" style="text-align:center; font-size:30px" Text='<%#Eval("rank") %>'></asp:Label></td>
                            </div>
                            <div style="text-align:center; font-size:30px">
                              <td> <asp:Label ID="Label1" runat="server" style="text-align:center; font-size:30px" Text='<%#Eval("O_name") %>'></asp:Label></td>
                            </div>
                             <div style="text-align:center; font-size:30px">
                            <td> <asp:Label ID="Label2" runat="server"  style="text-align:center; font-size:30px"  Text='<%#Eval("Date") %>'></asp:Label></td>
                            </div>
                            <div style="text-align:center; font-size:30px">
                            <td> 
                                <asp:Label ID="Label4" runat="server"  style="text-align:center; font-size:30px"  Text='<%#Label4_Load(int.Parse(Eval("st").ToString())) %>'></asp:Label>


                            </td>
                            </div>
                            <td style="text-align:center; font-size:20px">
                              <a href="EditTmam.aspx?id=<%# Eval("id")%>">Edit</a>
                          </td>
                            <td runat="server" visible="false">  <asp:Label ID="Label3" runat="server"  style="text-align:center; font-size:30px"  Visible="false" Text='<%#Eval("id") %>'></asp:Label></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        
        </form>
    </div>

</asp:Content>
