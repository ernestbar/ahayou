﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="promociones_admin.aspx.cs" Inherits="WebAhayouAdmin.promociones_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
.dataTables_wrapper .myfilter .dataTables_filter {
    float:left
}
.dataTables_wrapper .mylength .dataTables_length {
    float:right
}
</style>

<script type="text/javascript">
    $(document).ready(function () {
        // Se inicializa la tabla con las opciones requeridas
        $('#tabla11').dataTable({
            buttons: [
                { extend: 'copy', className: 'btn-sm', text: 'Copiar' },
                { extend: 'csv', className: 'btn-sm', text: 'CSV' },
                { extend: 'excel', className: 'btn-sm', text: 'Excel' },
                { extend: 'pdf', className: 'btn-sm', text: 'PDF' },
                { extend: 'print', className: 'btn-sm', text: 'Imprimir' }
            ],
            responsive: true,
            autoFill: true,
            colReorder: true,
            keys: true,
            rowReorder: false,
            select: 'single',
            language: {
                "emptyTable": "No information",
                "info": "Showing _START_ of _TOTAL_ entries",
                "infoEmpty": "Showing 0 of 0 entries",
                "infoFiltered": "(Filtered of _MAX_ total records)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Show _MENU_ records",
                "loadingRecords": "Loadin...",
                "processing": "Processing...",
                "search": "Filter records:",
                "zeroRecords": "No records found",
                "paginate": {
                    "first": "First",
                    "last": "Last",
                    "next": "Next",
                    "previous": "Previous"
                },
                "select": {
                    rows: "%d fila(s) seleccionada(s)"
                }
            }
        });

       
    });

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	   <asp:ObjectDataSource ID="odsPlanesPromo" runat="server" SelectMethod="PR_PAR_GET_PLANES_PROMO" TypeName="WebAhayouAdmin.Clases.Planes_paquetes">
		   	<SelectParameters>
		<asp:ControlParameter ControlID="ddlMundo" Name="pV_MUNDO" Type="String" />
	</SelectParameters>
	</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsMundo" runat="server" SelectMethod="PR_PAR_GET_MUNDO" TypeName="WebAhayouAdmin.Clases.Dominios">
	 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPromociones" runat="server" SelectMethod="PR_PAR_GET_PROMOCION" TypeName="WebAhayouAdmin.Clases.Promociones">
 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsMoneda" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="WebAhayouAdmin.Clases.Dominios">
	<SelectParameters>
		<asp:Parameter DefaultValue="MONEDA" Name="pV_DOMINIO" Type="String" />
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
			<asp:Label ID="lblCodPromocion" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnNuevo_Click" runat="server" Text="Nueva promocion" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrador de promociones <small></small></h1>
											<div class="panel-body">
							<table id="data-table-responsive" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
								<thead>
									<tr>
										<th class="text-wrap">CODIGO PROMOCION</th> 
										<th class="text-nowrap">MUNDO</th>			
										<th class="text-nowrap">PLAN</th>
										<th class="text-nowrap">PROMOCION</th>
										<th class="text-nowrap">PORCENTAJE</th>
										<th class="text-nowrap">FECHA DESDE</th>
										<th class="text-nowrap">FECHA HASTA</th>
										<th class="text-nowrap">ESTADO</th>

									<th class="text-nowrap" data-orderable="false">OPCIONES</th>
				
									</tr>
								</thead>
								<tbody>
									<asp:Repeater ID="Repeater1" DataSourceID="odsPromociones" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
									<ItemTemplate>
													<tr class="gradeA">
								
													<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
													<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("CODIGO_PROMOCION") %>'></asp:Label></td>
																	<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("DESC_MUNDO") %>'></asp:Label></td>
																	<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_CODIGO_PLAN") %>'></asp:Label></td>
																	<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("PROMOCION") %>'></asp:Label></td>
																	<td><asp:Label ID="Label31" runat="server" Text='<%# Eval("PORCENTAJE") %>'></asp:Label></td>
																	<td><asp:Label ID="Label32" runat="server" Text='<%# Eval("FECHA_DESDE") %>'></asp:Label></td>
																	<td><asp:Label ID="Label321" runat="server" Text='<%# Eval("FECHA_HASTA") %>'></asp:Label></td>
																	<td><asp:Label ID="Label3233" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
													<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("CODIGO_PROMOCION") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																	<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("CODIGO_PROMOCION")+"|"+ Eval("DESC_ESTADO")%>' OnClick="btnEliminar_Click" runat="server" Text="Activar/Desactivar" ToolTip="Activa o desactiva el registro" />
        
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16">Registro de promociones</legend>
					
									
					<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Mundo:</label>
							<div class="col-md-6">

							<asp:DropDownList ID="ddlMundo" class="form-select-lg col-lg-12" DataSourceID="odsMundo" AutoPostBack="true" OnSelectedIndexChanged="ddlMundo_SelectedIndexChanged" DataTextField="descripcion" OnDataBound="ddlMundo_DataBound" DataValueField="codigo"  ForeColor="Black" runat="server"></asp:DropDownList>  
								<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlMundo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
				<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Plan:</label>
					<div class="col-md-6">

					<asp:DropDownList ID="ddlPanesPromo" class="form-select-lg col-lg-12" DataSourceID="odsPlanesPromo" DataTextField="descripcion" OnDataBound="ddlPanesPromo_DataBound" DataValueField="codigo_plan"  ForeColor="Black" runat="server"></asp:DropDownList>  
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPanesPromo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
					<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Promocion:</label>
					<div class="col-md-6">
             <asp:TextBox ID="txtPromocion" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPromocion" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
					<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Porcentaje:</label>
					<div class="col-md-6">
             <asp:TextBox ID="txtPorcentaje" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPorcentaje" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
									<label class="col-md-3 text-md-right col-form-label">Desde:</label>
									<div class="col-md-6">
										<asp:Label ID="lblFechaDesde" Visible="false" runat="server" Text=""></asp:Label>
										<input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
									</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
									<label class="col-md-3 text-md-right col-form-label">Hasta:</label>
									<div class="col-md-6">
										<asp:Label ID="lblFechaHasta" Visible="false" runat="server" Text=""></asp:Label>
										<input id="fecha_retorno" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
									</div>
					</div>
					<!-- end form-group row -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" BackColor="Transparent" runat="server" OnClientClick="recuperarFechaSalida()" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success" BackColor="Transparent"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
        document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
	}
    function setearFechaSalida() {
        document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
	}
    function setearFechaRetorno() {
        document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }
    </script>
</asp:Content>