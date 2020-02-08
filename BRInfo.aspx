<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BRInfo.aspx.cs" Inherits="Planning.Admin.BRInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body" class="width" style="direction:rtl"">

        <h3> الفروع</h3>

        <form id="form1" runat="server">
            <table style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5);
                    border-collapse: collapse;
                    direction: rtl
            ">
                <tr style="text-align:center">
                    <th style="font-size:20px">الرقم</th>
                    <th style="font-size:20px">الأسم</th>
                    <th style="font-size:20px">السكتور</th>
                    <th style="font-size:20px">التعديل</th>
                </tr>
                <asp:Repeater runat="server" ID="rptrFields">
                    <ItemTemplate>
                        <tr>
                            
                            
                            
                            <td style="text-align:center; font-size:20px"><%= tableIndex %></td>
                                <%tableIndex++; %>
                            <td style="text-align:center; font-size:20px"><%#Eval("B_name") %></td>
                            <td style="text-align:center; font-size:20px"><%#Eval("SR_name") %></td>

                            <td style="text-align:center; font-size:20px"">
                                <a href="#">Edit</a>
                                &nbsp;-&nbsp;
                              <asp:LinkButton ID="DeleteButton" runat="server" CommandArgument='<%#Eval("id") %>'
                                  OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this Field?\nPS: it will be deleted from all companies!!');">Delete</asp:LinkButton>
                            </td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            

          
        </form>


        
    </div>
</asp:Content>
