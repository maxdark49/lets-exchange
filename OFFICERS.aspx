<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OFFICERS.aspx.cs" Inherits="Planning.CompanyFields" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <div id="body" class="width">
              <h3 style="direction:rtl">ضباط المركز</h3>
               <form id="form1" runat="server">

                   <asp:Button ID="addNew" runat="server" Text="إضافة ضابط" CssClass="formbutton" OnClick="addNew_Click" />
                   <br />
                   <div style="direction:rtl; margin:30px; margin-right:0px">
                        <asp:Button ID="searchBtn" runat="server" Text="بـحـث" CssClass="formbutton" OnClick="searchBtn_Click" />
                       &nbsp;
                        <asp:TextBox  ID="searchTxt" runat="server" CssClass="textright"></asp:TextBox>
                   </div>
            
          <table style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5);
                    border-collapse: collapse;">

                <tr style="text-align:center">
                    <th style="width:20%; font-size:20px">التعديل</th>
                    <th style="width:30%; font-size:20px">الوظيفة</th>
                    <th style="width:20%; font-size:20px">الاسم</th>
                    <th style="width:10%; font-size:20px">الرتبة</th>
                     <th style="width:2%; font-size:20px">الرقم.</th>
                </tr>
              <asp:Repeater runat="server" ID="rptrFields">

                  <ItemTemplate>

                      <tr>
                         
                          <td style="text-align:center; font-size:20px">
                              <a href="EditOFFICERS.aspx?id=<%# Eval("id")%>">Edit</a>
                              &nbsp;-&nbsp;
                              <asp:LinkButton ID="DeleteButton" style="text-align:center;font-size:20px" runat="server" CommandArgument='<%#Eval("id") %>'
                                  OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this Field?\nPS: it will be deleted from all companies!!');">Delete</asp:LinkButton>
                          </td>
                           
                          
                          <td style="text-align:center; font-size:20px"><%#Eval("job_name") %></td> 
                          <td style="text-align:center; font-size:20px"><%#Eval("O_name") %></td>
                          <td style="text-align: center; font-size:20px"><%#Eval("rank") %></td>
                          <td style="text-align: center; font-size:20px"><%= tableIndex %></td>
                              <%tableIndex++; %> 
                      </tr>
                  </ItemTemplate>
            </asp:Repeater>
            </table>  
                           <input id="txtHidden" style="width: 28px" type="hidden" value="0"
		runat="server" />

         <div style="text-align:center"> 
             <asp:LinkButton ID="lnkBtnPrev" runat="server" Font-Underline="False"
		OnClick="lnkBtnPrev_Click" Font-Bold="True"><< Prev </asp:LinkButton>
		&nbsp;&nbsp;
		<asp:LinkButton ID="lnkBtnNext" runat="server" Font-Underline="False"
		OnClick="lnkBtnNext_Click" Font-Bold="True">Next >></asp:LinkButton>

        </div>
               </form>

              </div>
</asp:Content>
