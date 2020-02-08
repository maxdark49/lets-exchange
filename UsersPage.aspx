<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="Planning.UsersPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="body" class="width">
        <h3 style="direction:rtl">المستخدمين</h3>
 <form id="form1" runat="server">
         <asp:Button ID="addNew" runat="server" Text="إضافة مستخدم" CssClass="formbutton" OnClick="addNew_Click" />
                <br />
                <div style="direction:rtl; margin:30px; margin-right:0px">
                        <asp:Button ID="searchBtn" runat="server" Text="بـحـث" CssClass="formbutton" OnClick="searchBtn_Click" />
                       &nbsp;
                        <asp:TextBox  ID="searchTxt" runat="server" CssClass="textright"></asp:TextBox>
                   </div>
 

        <table style="box-shadow: 0px 0px 10px 1px rgba(0,0,0,0.5); border-collapse:collapse; direction:rtl">
                <tr style="text-align:center;">
                    <th style="width:1%;">No.</th>
                    <th style="width:15%;">Name</th>
                    <th style="width:15%;">Job</th>
                   <th style="width:8%;">Operations</th>
                </tr>
     
              <asp:Repeater runat="server" ID="rptrUsers">

                  <ItemTemplate>

                      <tr style="text-align:center;">
                          <td><%= tableIndex %></td>
                          <%tableIndex++; %>
                          <td><%# capFirst(Eval("name").ToString()) %></td>
                          <td><%#Eval("job") %></td>
                          
                         <td style="text-align: center;">
                              <a href="EditUser.aspx?id=<%# Eval("id")%>">Edit</a>
                              &nbsp;-&nbsp;
                              <asp:LinkButton ID="DeleteButton" runat="server" CommandArgument='<%#Eval("id") %>'
                                  OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this User?');"
                                   >Delete</asp:LinkButton>
                          </td>
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