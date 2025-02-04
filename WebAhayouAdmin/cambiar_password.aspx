<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cambiar_password.aspx.cs" Inherits="WebAhayouAdmin.cambiar_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<div class="app-content" style="position: relative;border-radius:30px;
background: rgba(255, 255, 255, 0.2);
backdrop-filter: blur(5px);
background-image: linear-gradient(to bottom right, rgba(0, 0, 0, 0.5), /* Adjust transparency for top side */ transparent);">
	
		<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
<!-- begin row -->
		<div class="row">
			<!-- begin col-8 -->
			<div class="col-md-8 offset-md-1">
				
				<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-white">Change password</legend>
		<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Password actual:</label>
					<div class="col-md-6">
                        <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPasswordAnterior" Font-Bold="True"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtPasswordAnterior" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
					</div>
				</div>
				<!-- end form-group row -->
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Nuevo Password:</label>
					<div class="col-md-6">
                        <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtPassword" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
					</div>
				</div>
				<!-- end form-group row -->
				<!-- end form-group row -->
					<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
						<asp:Button ID="btnGuardar2" BackColor="Transparent" ForeColor="White" CssClass="btn btn-success" runat="server"  OnClick="btnGuardar2_Click" Text="Guardar" />
						<asp:Button ID="btnCancelar2" BackColor="Transparent" ForeColor="White" CssClass="btn btn-success"  runat="server" CausesValidation="false" OnClick="btnCancelar2_Click" Text="Cancelar" />
					</div>
				</div>
			</div>				
			<!-- end col-8 -->
</div>
</asp:Content>
