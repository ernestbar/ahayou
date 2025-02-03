<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="menu_rol_admin.aspx.cs" Inherits="WebAhayouAdmin.menu_rol_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsRolesActivos" runat="server" SelectMethod="PR_GET_ROLES" TypeName="WebAhayouAdmin.Clases.Roles">
	<SelectParameters>
			<asp:Parameter DefaultValue="A" Name="PV_ESTADO" Type="String" />
		</SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="odsMenusNoAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_A_ASIGNAR" TypeName="WebAhayouAdmin.Clases.Menus_roles">
	<SelectParameters>
		<asp:ControlParameter ControlID="ddlRol" Name="pB_ROL_ID_ROL" Type="String" />
		<asp:Parameter DefaultValue="AHAYOUADM" Name="pV_SISTEMA" Type="String" />
    </SelectParameters>
	</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsMenusAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_ASIGNADOS" TypeName="WebAhayouAdmin.Clases.Menus_roles">
	<SelectParameters>
		<asp:ControlParameter ControlID="ddlRol" Name="pB_ROL_ID_ROL" Type="String" />
<asp:Parameter DefaultValue="AHAYOUADM" Name="pV_SISTEMA" Type="String" />
    </SelectParameters>
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
		<asp:Label ID="lblCodMenu" runat="server" Text="" Visible="false"></asp:Label>
		<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
        <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
		<!-- begin form-group row -->
									<div class="form-group row m-b-10">
										
										<div class="col-md-6">
                                           
											<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
										</div>
									</div>
									<!-- end form-group row -->
								
									<!-- begin page-header -->
										<h1 class="page-header">Asignar menus a roles <small></small></h1>
										Rol:
										<asp:DropDownList ID="ddlRol" class="form-select-lg col-lg-4" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"  DataSourceID="odsRolesActivos" DataTextField="DESCRIPCION" DataValueField="ROL" OnDataBound="ddlRol_DataBound" runat="server"></asp:DropDownList>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRol" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>	
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
											<table id="tabla1" class="table table-striped table-bordered" style="background-color:transparent">
												<thead>
													<tr>
														<th class="text-wrap">MENU ASIGNADO</th>
														<th class="text-nowrap">MENU SIN ASIGNAR</th>
													</tr>
												</thead>
												<tbody>
													<tr>
														<td>
															<table id="asignados">
																<tr>
																	
																	<td>
																		MENU
																	</td>
																	<td>
																		OPCIONES
																	</td>
																</tr>
																 <asp:Repeater ID="Repeater1" DataSourceID="odsMenusAsignado" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
																	<ItemTemplate>
																		<tr class="gradeA">
																		
																			<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																			<td>
																				<asp:Button ID="btnQuitar" BackColor="Transparent" forecolor="Black"  class="btn btn-success btn-sm"  CommandArgument='<%# Eval("ROL_MENU")+ "|" + Eval("COD_MENU") %>' OnClick="btnQuitar_Click" runat="server" Text="QUITAR" ToolTip="QUITAR MENU ASIGNADO" />
																			</td>
																		</tr>
																	</ItemTemplate>
																</asp:Repeater>
															</table>
														</td>
														<td>
															<table id="noasignados">
																<tr>
																	
																	<td>
																		MENU
																	</td>
																	<td>
																		OPCIONES
																	</td>
																</tr>
																 <asp:Repeater ID="Repeater2" DataSourceID="odsMenusNoAsignado" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
																	<ItemTemplate>
																		<tr class="gradeA">
																			
																			<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																			<td>
																				<asp:Button ID="btnAgregar" BackColor="Transparent" forecolor="Black"  class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_MENU") %>' OnClick="btnAgregar_Click" runat="server" Text="AGREGAR" ToolTip="AGREGAR MENU" />
																			</td>
																		</tr>
																	</ItemTemplate>
																</asp:Repeater>
															</table>
														</td>
													</tr>
												</tbody>
											</table>
										</div>
										<!-- end table-responsive -->
												</div>
									</div>
    

		
	</div>
	<!-- end #content -->
</asp:Content>
