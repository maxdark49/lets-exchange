<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOFFICERS.aspx.cs" Inherits="Planning.Admin.EditOFFICERS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div id="body" class="width">

              <fieldset>
                  <legend style="margin:0 auto;font-size: 24px;">تعديل بيانات الضابط</legend>
                  <form id="form1" runat="server"> 
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                      
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate> 
                        <p>
                        <label for="rank">الرتبة:</label>
                        <asp:DropDownList ID="accountType" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="accountType_SelectedIndexChanged">
                         </asp:DropDownList>
                      
                        <asp:Label ID="nameV" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار رتبة</asp:Label>
                        </p>
                            
                    </ContentTemplate>
                    </asp:UpdatePanel>
                     

                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate> 
                            
                        <p>
                        <label for="name">إسم الضابط:</label>
                        <asp:TextBox ID="TextBox1" Text="" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Red">Name is Required ! (يجب أن يكون الأسم ثلاثيا)</asp:Label>
                    </p>
                               <p>
                        <label for="name">إسم السلاح:</label>
              <asp:DropDownList ID="weaponlist" runat="server" style="text-align:right;direction:rtl;" AutoPostBack="true" OnTextChanged="DropDownList2_TextChanged"  ></asp:DropDownList>
                               <asp:Label ID="Label4"   runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار سلاح</asp:Label>

                    </p>
                            
                             <p>
                        <label for="name">العنوان:</label>
                        <asp:TextBox ID="TextBox2" Text="" runat="server" />
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن يكون هناك عنوان</asp:Label>
                    </p>
                                  <p>
                        <label for="name">رقم الهاتف:</label>
                        <asp:TextBox ID="TextBox3" Text="" runat="server" />
                        <asp:Label ID="Label3" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن يكون هناك رقم هاتف</asp:Label>
                    </p>
                    </ContentTemplate>
                    </asp:UpdatePanel>

                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                          <ContentTemplate>
                              <p>
                                  <label for="rank">الوظيفة:</label>
                        <asp:DropDownList ID="joblist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="joblist_SelectedIndexChanged" >
                         </asp:DropDownList>
                      
                        <asp:Label ID="jobv"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار وظيفة</asp:Label>
                              </p>
                               </ContentTemplate>

                      </asp:UpdatePanel>

                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                          <ContentTemplate>
                             <div>
                              <asp:Button  ID="Button1" runat="server" Text="حفظ" OnClick="Button1_Click"  />
                                 </div>
                          </ContentTemplate>
                      </asp:UpdatePanel>

                                                            </form>

              </fieldset>

</div>
</asp:Content>
