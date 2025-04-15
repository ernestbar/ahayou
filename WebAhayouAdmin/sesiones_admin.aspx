<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="sesiones_admin.aspx.cs" Inherits="WebAhayouAdmin.sesiones_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ObjectDataSource ID="odsSesiones" runat="server" SelectMethod="PR_PAR_GET_SESIONES" TypeName="WebAhayouAdmin.Clases.Sesiones">
</asp:ObjectDataSource>
<!-- begin #content -->
	<div class="app-content" style="position: relative;border-radius:30px;
background: rgba(255, 255, 255, 0.2);
backdrop-filter: blur(5px);
background-image: linear-gradient(to bottom right, rgba(0, 0, 0, 0.5), /* Adjust transparency for top side */ transparent);">
		<%--<asp:SiteMapPath ID="SiteMapPath1" Runat="server" Font-Names="Verdana" Font-Size="0.8em" PathSeparator=" : ">
            <CurrentNodeStyle ForeColor="#333333" />
            <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
            <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
            <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
		</asp:SiteMapPath>--%>
		<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblSesionID" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
		  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
		
								
									<!-- begin page-header -->
										<h1 class="page-header">Administrador de sesiones <small></small></h1>
										<div class="panel-body">
						<table id="data-table-responsive" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
							<thead>
								<tr>
								<th class="text-wrap">ID SESION</th>
												<th class="text-nowrap">USUARIO</th>
												<th class="text-nowrap">FECHA LOGIN</th>
												<th class="text-nowrap">FECHA LOGOUT</th>
								<th class="text-nowrap" data-orderable="false">OPCIONES</th>
			
								</tr>
							</thead>
							<tbody>
								<asp:Repeater ID="Repeater1" DataSourceID="odsSesiones"  OnItemDataBound="Repeater1_ItemDataBound" runat="server">
								<ItemTemplate>
												<tr class="gradeA">
							
												<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
												<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("IDSESION") %>'></asp:Label></td>
																
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label></td>
													<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("FECHALOGIN") %>'></asp:Label></td>
													<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("FECHALOGOUT") %>'></asp:Label></td>
												<td>
																
																<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("USUARIO")+"|"+ Eval("IDSESION") %>' OnClick="btnEliminar_Click" runat="server" Text="Desactivar" ToolTip="Desactiva el registro" />
    
																<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
												</td>
			
			
								</tr>
								</ItemTemplate>
								</asp:Repeater>
							</tbody>
						</table>
					</div>
					<!-- END panel-body -->
    </asp:View>
	 <asp:View ID="View2" runat="server">
		<!-- begin row -->
		<div class="row">
			<!-- begin col-8 -->
			<div class="col-md-6 offset-md-2">
				
				<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16">Registro de avatares</legend>
				
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Codigo Avatar:</label>
					<div class="col-md-6">
                         <asp:TextBox ID="txtCodRol" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCodRol" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
			<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Imagen Avatar:</label>
					<div class="col-md-6">
						<asp:FileUpload ID="fuAvatar" CssClass="form-control" runat="server" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="fuAvatar" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
				
				
				
					<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
						<asp:Button ID="btnGuardar" CssClass="btn btn-success" BackColor="Transparent" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
						<asp:Button ID="btnVolverAlta" CssClass="btn btn-success" BackColor="Transparent"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
					</div>
				</div>
			</div>				
			<!-- end col-8 -->
		
    </asp:View>
</asp:MultiView>
	</div>
	<!-- end #content -->
</asp:Content>
