<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTmam.aspx.cs" Inherits="Planning.Admin.EditTmam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="body" class="width">

              <fieldset>
                  <legend style="margin:0 auto;font-size: 24px;">تعديل التمام</legend>
                  <form id="form1" runat="server"> 
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                      
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate> 
                        <p>
                        <label for="rank">الإســـــم:</label>
                        <asp:Label ID="Label5" runat="server" Text="Label" Visible="true">Name is Required ! (يجب أن يكون الأسم ثلاثيًًاً)</asp:Label>
                      
                        </p>

                            <p>
                        <label for="rank">التـــاريـخ:</label>
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="true">Name is Required ! (يجب أن يكون الأسم ثلاثيا)</asp:Label>
                      
                        </p>

                             <p>
                        <label for="name">التــمام:</label>
              <asp:DropDownList ID="weaponlist" runat="server" style="text-align:right;direction:rtl;" AutoPostBack="true" OnTextChanged="weaponlist_TextChanged"  ></asp:DropDownList>
                               <asp:Label ID="Label4"   runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار سلاح</asp:Label>

                    </p>
                            
                    </ContentTemplate>
                    </asp:UpdatePanel>
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                          <ContentTemplate>
                             <div>
                              <asp:Button  ID="Button1" runat="server" Text="حفظ" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure you want to Change this Field?');"  />
                                 </div>
                          </ContentTemplate>
                      </asp:UpdatePanel>

                                                            </form>

              </fieldset>

</div>

</asp:Content>
