<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddJob.aspx.cs" Inherits="Planning.Admin.AddJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="body" class="width">
        <fieldset>
            <legend style="margin:0 auto;font-size: 24px;">إضافة بيانات الوظيفه</legend>
            <form id="form1" runat="server">

                <p>
                    <label for="name" style="float: right; text-align: right;">:إسم الوظيفه</label>
                    <asp:TextBox runat="server" style="float:right;text-align: right;" ID="textbox1" ></asp:TextBox>
                    <asp:Label ID="Label1" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">Name is Required ! (يجب أن يكون الأسم ثلاثيا)</asp:Label>
                </p>
                <br />
                 <p>
                            <label for="SR_name" style="float: right; text-align: right;">:السكتور</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="Label6"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار سكتور</asp:Label>
                 </p>
                <br />
                 <p>
                            <label for="dir" style="float: right; text-align: right;">:الإتجاه	</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="Label2"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار إتجاه</asp:Label>
                 </p>
                <br />
                 <p>
                            <label for="BR" style="float: right; text-align: right;">:الفرع</label>
                            <asp:DropDownList ID="DropDownList3" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="Label3"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار فرع</asp:Label>
                 </p>
                <br />
                 <p>
                            <label for="S_name" style="float: right; text-align: right;">:السكشن</label>
                            <asp:DropDownList ID="DropDownList4" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="Label4"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار سكشن</asp:Label>
                 </p>
                <br />
                 <p>
                            <label for="of" style="float: right; text-align: right;">:المسؤل</label>
                            <asp:DropDownList ID="DropDownList5" runat="server" style="float:right; text-align:right;direction:rtl;" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Label ID="Label5"  style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">يجب أن تختار مسؤل</asp:Label>
                 </p>
                <br />
                 <asp:Button ID="Button1"  runat="server" Text="تسجيل" OnClick="Button1_Click" />


            </form>
        </fieldset>
    </div>
</asp:Content>
