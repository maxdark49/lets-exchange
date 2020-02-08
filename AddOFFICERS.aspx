<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOFFICERS.aspx.cs" Inherits="Planning.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body" class="width">
        <fieldset>
            
             <legend style="margin:0 auto;font-size: 24px;">إضافة بيانات الضابط</legend>
            <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <label for="rank" style="float:right; width: 70px; text-align:right">:الرتبة  </label>
                       <label style="float:right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" style="text-align:right; float:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                             <asp:ListItem></asp:ListItem>
                            <asp:ListItem   Text="لواء أح" Value="لواء أح"></asp:ListItem>
                            <asp:ListItem Text="لواء" Value="لواء"></asp:ListItem>
                            <asp:ListItem Text="عميد" Value="عميد"></asp:ListItem>
                            <asp:ListItem Text="عميد أح" Value="عميد أح"></asp:ListItem>
                            <asp:ListItem Text="عميد بحرى" Value="عميد بحرى"></asp:ListItem>
                            <asp:ListItem Text="عقيد أح" Value="عقيد أح"></asp:ListItem>
                            <asp:ListItem Text="عقيد بحرى" Value="عقيد بحرى"></asp:ListItem>
                            <asp:ListItem Text="عقيد" Value="عقيد"></asp:ListItem>
                            <asp:ListItem Text="مقدم أح" Value="مقدم أح"></asp:ListItem>
                             <asp:ListItem Text="مقدم بحرى" Value="مقدم بحرى"></asp:ListItem>
                            <asp:ListItem Text="مقدم" Value="مقدم"></asp:ListItem>
                            <asp:ListItem Text="رائد" Value="رائد"></asp:ListItem>
                            <asp:ListItem Text="نقيب" Value="نقيب"></asp:ListItem>
                            <asp:ListItem Text="نقيب فنى" Value="نقيب فنى"></asp:ListItem>
                            <asp:ListItem Text="ملازم أول" Value="ملازم أول"></asp:ListItem>
                            <asp:ListItem Text="ملازم" Value="ملازم"></asp:ListItem>
                            <asp:ListItem Text="رائد ش" Value="رائد ش"></asp:ListItem>
                            <asp:ListItem Text="نقيب ش" Value="نقيب ش"></asp:ListItem>
                            <asp:ListItem Text="ملازم أول ش" Value="ملازم أول ش"></asp:ListItem>
                            <asp:ListItem Text="ملازم ش" Value="ملازم ش"></asp:ListItem>
                        </asp:DropDownList>
                        <label style="float:right">&nbsp;&nbsp;</label>
                        <div style="float:right">
                         <asp:Label ID="nameV" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار رتبة</asp:Label>
                                                    </div>
                        <br />
                       
                               </ContentTemplate>
                </asp:UpdatePanel>
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                       <ContentTemplate>
                           <p>
                               <label for="name" style="float: right; text-align: right;">:إسم الضابط</label>
                               <asp:TextBox runat="server" style="float:right;text-align: right;" ID="textbox1" ></asp:TextBox>
                               <asp:Label ID="Label1" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">Name is Required ! (يجب أن يكون الأسم ثلاثيا)</asp:Label>
                          </p>
                           <br />
                        <br />
                           <p>
                               <label for="name" style="float: right; text-align: right;">:السلاح</label>
                               <asp:DropDownList ID="DropDownList2" runat="server" style="float:right;text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                               <asp:Label ID="Label4"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار سلاح</asp:Label>
                           </p>
                           <br />
                       
                            <p>
                               <label for="name" style="float: right; text-align: right;">:رقم الاقدمية</label>
                               <asp:TextBox runat="server" style="float:right;" ID="textbox4" TextMode="Number" ></asp:TextBox>
                               <asp:Label ID="Label5" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن يكون هناك رقم أقدمية</asp:Label>
                          </p>
                           <br />
                             <p>
                               <label for="name" style="float: right; text-align: right;">:العنوان</label>
                               <asp:TextBox runat="server" style="float:right;text-align:right;direction:rtl;" ID="textbox2" ></asp:TextBox>
                               <asp:Label ID="Label2" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن يكون هناك عنوان</asp:Label>
                          </p>
                           <br />
                        
                           <p>
                               <label for="name" style="float: right; text-align: right;">:رقم الهاتف</label>
                               <asp:TextBox runat="server" style="float:right;text-align: right;" ID="textbox3" TextMode="Number" ></asp:TextBox>
                               <asp:Label ID="Label3" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن يكون هناك رقم هاتف</asp:Label>
                          </p>
                           <br />
                           <p>
                               <label for="name" style="float: right; text-align: right;">:الوظيفة</label>
                         <asp:DropDownList ID="DropDownList3" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
                               <asp:Label ID="Label6"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار وظيفة</asp:Label>

                           </p>
                           <br />
                       </ContentTemplate>

                       
                   </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>

                     <h3 style="text-align:center">
                         
                         <asp:Button ID="Button1"  runat="server" Text="تسجيل" OnClick="Button1_Click" />
                         <br />
                     <asp:Label ID="Label7"   runat="server" Text="Label" Visible="false" ForeColor="Red">تأكد من بياناتك مرة أخرى</asp:Label>


                     </h3>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </form>
        </fieldset>
        </div>
</asp:Content>
