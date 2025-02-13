<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" Async="true" CodeBehind="login.aspx.cs" Inherits="WebAhayouAdmin.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
  <div id="contact" class="content bg-light" data-scrollview="true">
      <div class="container">

				<h2 class="content-title">LOGIN</h2>
                     <div class="form-floating col-auto">
                         <asp:TextBox ID="txtEmail" class="form-control" placeholder="name@example.com" runat="server"></asp:TextBox>
                     </div>
                         <div class="form-floating col-auto">
                             <asp:TextBox ID="txtClave" class="form-control" placeholder="password" runat="server"></asp:TextBox>
                </div>
                     <div class="col-auto">
                         <asp:Button ID="btnIngresar" class="btn btn-primary" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" />
                     </div>
      <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>              
        </div>
      
       </div>
</asp:Content>
