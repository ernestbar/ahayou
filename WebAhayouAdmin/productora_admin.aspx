<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="productora_admin.aspx.cs" Inherits="WebAhayouAdmin.productora_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="WebAhayouAdmin.Clases.Dominios">
    <SelectParameters>
        <asp:Parameter DefaultValue="PAIS" Name="pV_DOMINIO" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="PR_PAR_GET_DATA_CITY" TypeName="WebAhayouAdmin.Clases.Dominios">
    <SelectParameters>
		<asp:ControlParameter ControlID="ddlPais" Name="pV_PAIS" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsSucursales" runat="server" SelectMethod="PR_PAR_GET_PRODUCTORA" TypeName="WebAhayouAdmin.Clases.Productoras">
</asp:ObjectDataSource>    
<!-- begin #content -->

	
		<div class="app-content" style="position: relative;border-radius:30px;
background: rgba(255, 255, 255, 0.2);
backdrop-filter: blur(5px);
background-image: linear-gradient(to bottom right, rgba(0, 0, 0, 0.5), /* Adjust transparency for top side */ transparent);">
		
		<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
		<asp:Label ID="lblCodProductora" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
         <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
		<!-- begin form-group row -->
									<div class="form-group row m-b-10">											
										<div class="col-md-6">
                                            <asp:Button ID="btnNuevo" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnNuevo_Click" runat="server" Text="Nueva productora" />
											<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
										</div>
									</div>
									<!-- end form-group row -->
								
									<!-- begin page-header -->
										<h1 class="page-header">Adminstrador productoras <small></small></h1>
      
										<!-- end page-header -->
										<!-- begin panel -->
										<div class="panel panel-inverse">
											<!-- begin panel-heading -->
											<div class="panel-heading">
												<div class="panel-heading-btn">
													<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
													<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
													<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
													<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
												</div>
												<h4 class="panel-title">Records</h4>
											</div>
											<!-- end panel-heading -->
											
											<div class="table-responsive">
											<!-- begin panel-body -->
											<div class="panel-body">
									<%--<div class="table-responsive">--%>
											<table id="data-table-responsive" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
												<thead>
													<tr>
														<th class="text-nowrap">CODIGO</th>
														<th class="text-nowrap">PAIS</th>
														<th class="text-nowrap">CIUDAD</th>
														<th class="text-nowrap">DIRECCION</th>
														<th class="text-nowrap">NOMBRE</th>
														<th class="text-nowrap">ESTADO</th>
														<th class="text-nowrap" data-orderable="false">OPCIONES</th>															
														</tr>
												</thead>
												<tbody>
                                                    <asp:Repeater ID="Repeater1" DataSourceID="odsSucursales" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
													<ItemTemplate>
														<tr class="gradeA">																
														<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("COD_PRODUCTORA") %>'></asp:Label></td>
															<td><asp:Label ID="lblPias" runat="server" Text='<%# Eval("DESC_PAIS") %>'></asp:Label></td>
														<td><asp:Label ID="lblCiudad" runat="server" Text='<%# Eval("DESC_CIUDAD") %>'></asp:Label></td>
														<td><asp:Label ID="lblCiudad1" runat="server" Text='<%# Eval("DIRECCION") %>'></asp:Label></td>
														<td><asp:Label ID="lblNombreSucursal" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
														<td>
															<asp:Button ID="btnEditar" class="btn btn-success btn-sm" BackColor="Transparent" ForeColor="Black" CommandArgument='<%# Eval("COD_PRODUCTORA") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
															<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" ForeColor="Black" CommandArgument='<%# Eval("COD_PRODUCTORA") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click"  runat="server" Text="Activar/Desactivar" ToolTip="Activa o desactiva registro" />
															<%--<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("SUC_ID_SUCURSAL") +"|" + Eval("DESC_ESTADO")  %>' OnClick="btnEliminar_Click" runat="server" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" Text="Activar/Desactivar" ToolTip='<%# Eval("CLI_ESTADO") %>' />--%>
                                                            
															<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
														</td>
														
														
													</tr>
													</ItemTemplate>
													</asp:Repeater>
													
												
												</tbody>
											</table>
										</div>
										<!-- end table-responsive -->
												</div>
									</div>
    </asp:View>
	 <asp:View ID="View2" runat="server">
					<!-- begin row -->
		<div class="row">
			<!-- begin col-8 -->
			<div class="col-md-6 offset-md-2">
				
				<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-white">Datos productora</legend>
                <!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Codigo:</label>
					<div class="col-md-6">
                        <asp:TextBox ID="txtCodigo" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Nombre productora:</label>
					<div class="col-md-6">
                        <asp:TextBox ID="txtNombreSucursal" class="form-control" style="text-transform:uppercase" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNombreSucursal" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Direction:</label>
					<div class="col-md-6">
                        <asp:TextBox ID="txtDireccion" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtDireccion" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
                <!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Pais:</label>
					<div class="col-md-6">
					        <asp:DropDownList ID="ddlPais" class="form-select-lg col-lg-12" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"  OnDataBound="ddlPais_DataBound" AutoPostBack="true"  DataSourceID="odsPais" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPais" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>  
				</div>
				<!-- end form-group row -->  
                <!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Ciudad:</label>
					<div class="col-md-6">
					         <asp:DropDownList ID="ddlCiudad"  class="form-select-lg col-lg-12"  DataSourceID="odsCiudad" OnDataBound="ddlCiudad_DataBound" DataTextField="descripcion" DataValueField="codigo"  ForeColor="Black" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMesssage="*" ForeColor="Red" ControlToValidate="ddlCiudad" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
				<%--	<div class="col-md-1">
						<asp:ImageButton ID="imgNew" OnClick="imgNew_Click" ImageUrl="~/Imagenes/agregar.png" CausesValidation="false" Height="40px" ToolTip="Add new city" runat="server" />
					</div>--%>
				</div>
				<!-- end form-group row -->
				 
				<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
						<asp:Button ID="btnGuardar" CssClass="btn btn-success" BackColor="Transparent"  runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
						<asp:Button ID="btnVolver" CssClass="btn btn-success" BackColor="Transparent"   runat="server" CausesValidation="false" OnClick="btnVolver_Click" Text="Cancelar" />
					</div>
				</div>
			</div>				
			<!-- end col-8 -->
    </asp:View>
</asp:MultiView>
		
	</div>

</asp:Content>
