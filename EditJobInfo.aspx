<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditJobInfo.aspx.cs" Inherits="Planning.Admin.EditJobInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="body" class="width">

        <fieldset>
            <legend style="margin:0 auto;font-size: 24px;">تعديل بيانات الوظيفه</legend>
            <form id="form1" runat="server">
                <p>
                    <label for="job_name">إسم الوظيفه:</label>
                    <asp:TextBox ID="TextBox1" Text="" runat="server" />
                </p>

                <p>
                        <label for="rank">السكتور:</label>
                        <asp:DropDownList ID="SRlist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="SRlist_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Label ID="jobv"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار سكتور</asp:Label>
                </p>

                <p>
                        <label for="dirlist">الإتجاه:</label>
                        <asp:DropDownList ID="dirlist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="dirlist_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Label ID="Label1"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار إتجاه</asp:Label>
                </p>

                 <p>
                        <label for="BRlist">الفرع:</label>
                        <asp:DropDownList ID="BRlist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="BRlist_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Label ID="Label2"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار الفرع</asp:Label>
                </p>

                <p>
                        <label for="Slist">السكشن:</label>
                        <asp:DropDownList ID="Slist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="Slist_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Label ID="Label3"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار السكشن</asp:Label>
                </p>

                <p>
                        <label for="asslist">المسؤل:</label>
                        <asp:DropDownList ID="asslist" Enabled ="true" runat="server" style="text-align:right;" AutoPostBack="true" OnSelectedIndexChanged="asslist_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Label ID="Label4"  runat="server" Text="Label" Visible="false" ForeColor="Red" >يجب أن تختار المسؤل</asp:Label>
                </p>

                             <div>
                              <asp:Button  ID="Button1" runat="server" Text="حفظ" OnClick="Button1_Click"  />
                                 </div>
            </form>
        </fieldset>

    </div>

</asp:Content>
