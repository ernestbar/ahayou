<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="suscriptores_admin.aspx.cs" Inherits="WebAhayouAdmin.suscriptores_admin" %>
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

	   <asp:ObjectDataSource ID="odsSuscriptores" runat="server" SelectMethod="PR_PAR_GET_SUSCRIPTORES" TypeName="WebAhayouAdmin.Clases.Suscriptores">
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
			<asp:Label ID="lblCodSuscriptor" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-lg col-md-12" Visible="false" BackColor="Transparent" OnClick="btnNuevo_Click" runat="server" Text="Nuevo suscriptor" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrador de suscriptores <small></small></h1>
											<div class="panel-body">
							<table id="data-table-buttons" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
								<thead>
									<tr>
									<th class="text-wrap">USUARIO</th>
													<th class="text-nowrap">PASSWSORD</th>
													<th class="text-nowrap">NOMBRE COMPLETO</th>
													<th class="text-nowrap">EMAIL</th>
													<th class="text-nowrap">CELULAR</th>
													<th class="text-nowrap">ESTADO</th>
									<th class="text-nowrap" data-orderable="false">OPCIONES</th>
				
									</tr>
								</thead>
								<tbody>
									<asp:Repeater ID="Repeater1" DataSourceID="odsSuscriptores" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
									<ItemTemplate>
													<tr class="gradeA">
								
													<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
													<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label></td>
																	<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("PASSWORD") %>'></asp:Label></td>
																	<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("NOMBRE_COMPLETO") %>'></asp:Label></td>
																	<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label></td>
																	<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("CELULAR") %>'></asp:Label></td>
																	<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
													<td>
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																	<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("USUARIO") + "|" + Eval("DESC_ESTADO") %>' OnClientClick="return confirm('Estas seguro de eliminar el registro???')" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Elimina el registro" />
																	<asp:Button ID="btnResetear" BackColor="Transparent" ForeColor="Black" class="btn btn-success btn-sm" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnResetear_Click" OnClientClick="return confirm('Esta seguro de resetear el password???')" runat="server" Text="Resetear Password" ToolTip="Resetea el password a 123" />
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16">Registro de suscriptores</legend>
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Usuario:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtUsuario" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsuario" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Password:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Nombre completo:</label>
					<div class="col-md-6">
             <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombre" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
					<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Email:</label>
					<div class="col-md-6">
             <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
					</div>
				</div>
				<!-- end form-group row -->
					<!-- begin form-group row -->
				<div class="form-group row m-b-10">
					<label class="col-md-3 text-md-right col-form-label">Celular:</label>
					<div class="col-md-6">
             <asp:TextBox ID="txtCelular" class="form-control" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
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