<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDir.aspx.cs" Inherits="Planning.Admin.AddDir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body" class="width">
        <fieldset>
            <legend style="margin:0 auto;font-size: 24px;">إضافة بيانات الإتجاه</legend>
            <form id="form1" runat="server">

                <p>
                    <label for="name" style="float: right; text-align: right;">:إسم الإتجاه</label>
                    <asp:TextBox runat="server" style="float:right;text-align: right;" ID="textbox1" ></asp:TextBox>
                    <asp:Label ID="Label1" style="float:right;" runat="server" Text="Label" Visible="false" ForeColor="Red">Name is Required ! (يجب أن يكون الأسم ثلاثيا)</asp:Label>
                </p>
                <br />
                 
                <br />
                 <asp:Button ID="Button1"  runat="server" Text="تسجيل" OnClick="Button1_Click" />


            </form>
        </fieldset>
    </div>
</asp:Content>
