<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Planning.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div id="body" class="width">

   
         
          
            <fieldset>
                <legend>Edit User Information</legend>
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <p>
                        <label for="name">Name:</label>
                        <asp:TextBox ID="name" Text="" runat="server" />
                        <asp:Label ID="nameV" runat="server" Text="Label" Visible="false" ForeColor="Red">Name is Required ! (3 Letters Minimum)</asp:Label>

                    </p>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <p>
                        <label for="password">Password:</label>
                        <asp:TextBox ID="password" Text="" runat="server" TextMode="Password" Enabled="false" BackColor="#cccccc" />
                        <asp:CheckBox ID="passwordCB" runat="server" OnCheckedChanged="passwordCB_CheckedChanged" AutoPostBack="true"/>
                        <asp:Label ID="passwordV" runat="server" Text="Label" Visible="false" ForeColor="Red">Password is Required !</asp:Label>
                    </p>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    <p>
                        <label for="job">Job:</label>
                        <asp:TextBox ID="job" Text="" runat="server" />
                        <asp:Label ID="jobV" runat="server" Text="Label" Visible="false" ForeColor="Red">Job is Required !</asp:Label>

                    </p><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                     <p>
                        <label for="isAdmin">Is Admin:</label>
                        <asp:CheckBox ID="isAdmin" runat="server" OnCheckedChanged="isAdmin_CheckedChanged" AutoPostBack="true"/>
                    </p>
                    
                    <p>
                        <label for="accountType">Account Type:</label>
                        <asp:DropDownList ID="accountType" Enabled ="true" runat="server" style="text-align:right;">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="officer">ضابط</asp:ListItem>
                            <asp:ListItem Value="archiverSold">الأرشيف</asp:ListItem>
                            <asp:ListItem Value="techSold">قسم المعلومات ومتابعة التكنولوجيا</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:Label ID="accountTypeV" runat="server" Text="Label" Visible="false" ForeColor="Red">Account Type is Required !</asp:Label>

                    </p>
                    </ContentTemplate>
                    </asp:UpdatePanel>

                    <p><asp:Button ID="save" runat="server" style="margin-left: 150px;" CssClass="formbutton" Text="Save" OnClick="save_Click"/>&nbsp;&nbsp;
                       <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="formbutton" OnClick="cancel_Click"/>
                    </p>
                    
                </form>
            </fieldset>






    </div>


</asp:Content>
