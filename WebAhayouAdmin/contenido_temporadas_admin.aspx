<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="contenido_temporadas_admin.aspx.cs" Inherits="WebAhayouAdmin.contenido_temporadas_admin" %>
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
	<asp:ObjectDataSource ID="odsContenido" runat="server" SelectMethod="PR_STR_GET_FORMATO_CONTENIDO" TypeName="WebAhayouAdmin.Clases.Contenido">
	</asp:ObjectDataSource>
	   <asp:ObjectDataSource ID="odsGrilla" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_TEMPORADAS" TypeName="WebAhayouAdmin.Clases.Contenido_temporadas">
		   <SelectParameters>
				<asp:ControlParameter ControlID="lblCodContenidoSTR" Name="pV_COD_CONTENIDO_STR" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
	   <asp:ObjectDataSource ID="odsClasificacion" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="WebAhayouAdmin.Clases.Dominios">
	   <SelectParameters>
			<asp:Parameter DefaultValue="CLASIFICACION" Name="pV_DOMINIO" />
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
			<asp:Label ID="lblCodigo" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodContenidoSTR" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnNuevo_Click" runat="server" Text="Nuevo contenido temporadas" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									<br />
						<div class="form-group row m-b-10">
	
									<div class="col-md-6">
							<asp:Button ID="btnVolverContenidosSTR" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnVolverContenidosSTR_Click" runat="server" Text="Volver a contenidos streaming" />
													<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
									</div>
					</div>
										<!-- begin page-header -->
												<!-- begin page-header -->
																<h1 class="page-header">Contenido temporadas admin <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label> <small> </small></h1>
																<%--Contenido:
																<asp:DropDownList ID="ddlFormatoContenido" class="form-select-lg col-lg-4" AutoPostBack="true" OnSelectedIndexChanged="ddlFormatoContenido_SelectedIndexChanged"  DataSourceID="odsFormatoContenido" DataTextField="FORMATO_CONTENIDO" DataValueField="COD_FORMATO_CONTENIDO" OnDataBound="ddlFormatoContenido_DataBound" runat="server"></asp:DropDownList>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFormatoContenido" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>	--%>
												<!-- end page-header -->
											<div class="panel-body">
											<table id="data-table-responsive" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
												<thead>
													<tr>
													<th class="text-wrap">ORDEN</th>
																	<th class="text-nowrap">TEMPORADA</th>
																	<th class="text-nowrap">EPISODIO</th>
																	<th class="text-nowrap">TIEMPO HORA</th>
																	<th class="text-nowrap">TIEMPO MIN</th>
																	<th class="text-nowrap">CONTENIDO</th>
																	<th >CONTENIDO MOBILE</th>
																	
													<th class="text-nowrap" data-orderable="false">OPCIONES</th>
				
													</tr>
												</thead>
												<tbody>
									<asp:Repeater ID="Repeater1" DataSourceID="odsGrilla" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
									<ItemTemplate>
													<tr class="gradeA">
								
													<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
													<td><asp:Label ID="lblEsPrincipal1" runat="server" Text='<%# Eval("ORDEN") %>'></asp:Label></td>
													<td><asp:Label ID="lblEsPrincipal2" runat="server" Text='<%# Eval("TEMPORADA") %>'></asp:Label></td>
													<td><asp:Label ID="lblEsPrincipal3" runat="server" Text='<%# Eval("EPISODIO") %>'></asp:Label></td>
														<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("TIEMPO_HORA") %>'></asp:Label></td>
														<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("TIEMPO_MINUTOS") %>'></asp:Label></td>
														<%--<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("CONTENIDO") %>'></asp:Label></td>--%>
														<td style="width:100%;height:100%">
															<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("CONTENIDO") %>'>

															</asp:Literal></td>
														<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("CONTENIDO_MOBILE") %>'></asp:Label></td>
														
																	
																	<%--<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>--%>
													<td>
																	<asp:Button ID="btnVer" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_TEMPORADAS") %>' OnClick="btnVer_Click" runat="server" Text="Ver informacion" ToolTip="Ver todos los datos" />
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_TEMPORADAS") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																	<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_TEMPORADAS") %>' OnClientClick="return confirm('Estas seguro de eliminar el registro???')" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Elimina el registro" />
        
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
	<div class="col-md-12 offset-md-0">
		
		<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16">Registro de contenido streaming</legend>
		<!-- BEGIN #accordion -->
			<div class="accordion" id="accordion">
				<div class="accordion-item border-0">
					<div class="accordion-header" id="headingOne">
						<button class="accordion-button bg-gray-900 text-white px-3 py-10px pointer-cursor" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne">
							<i class="fa fa-circle fa-fw text-blue me-2 fs-8px"></i> DATOS GENERALES
						</button>
					</div>
					<div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordion">
						<div class="accordion-body bg-gray-800 text-white">
							<!-- begin form-group row -->
								<div class="form-group row m-b-10">
																		<label class="col-md-3 text-md-right col-form-label">Nombre contenido streaming:</label>
																		<div class="col-md-6">
																 <asp:TextBox ID="txtNombreContenido" Enabled="true" class="form-control" runat="server"></asp:TextBox>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNombreContenido" Font-Bold="True"></asp:RequiredFieldValidator>
																		</div>
								</div>
								<!-- end form-group row -->
								
								<!-- begin form-group row -->
								<div class="form-group row m-b-10">
									<label class="col-md-3 text-md-right col-form-label">Orden:</label>
											<div class="col-md-1">
												 <asp:TextBox ID="txtOrden" Enabled="true" TextMode="Number" class="form-control" Text="2000" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtOrden" Font-Bold="True"></asp:RequiredFieldValidator>
										</div>
								</div>
								<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Temporada:</label>
									<div class="col-md-1">
										 <asp:TextBox ID="txtTemporada" Enabled="true" TextMode="Number" class="form-control" Text="2000" runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTemporada" Font-Bold="True"></asp:RequiredFieldValidator>
									</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Episodio:</label>
									<div class="col-md-1">
										 <asp:TextBox ID="txtEpisodio" Enabled="true" TextMode="Number" class="form-control" Text="2000" runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEpisodio" Font-Bold="True"></asp:RequiredFieldValidator>
									</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
								<div class="form-group row m-b-10">
									<label class="col-md-3 text-md-right col-form-label">Duracion(hh:mm):</label>
										<div class="col-md-1">
											 <asp:TextBox ID="txtHoras" Enabled="true"  class="form-control" Text="00" runat="server"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtHoras" Font-Bold="True"></asp:RequiredFieldValidator>
										</div>
										<div class="col-md-1">
											<asp:TextBox ID="txtMinutos" Enabled="true" class="form-control" Text="00" runat="server"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMinutos" Font-Bold="True"></asp:RequiredFieldValidator>
										</div>
								</div>
								<!-- end form-group row -->
								
						</div>
					</div>
				</div>
				<div class="accordion-item border-0">
					<div class="accordion-header" id="headingThree">
						<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree">
							<i class="fa fa-circle fa-fw text-teal me-2 fs-8px"></i> STORY LINES
						</button>
					</div>
					<div id="collapseThree" class="accordion-collapse collapse" data-bs-parent="#accordion">
						<div class="accordion-body bg-gray-800 text-white">
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Story line:</label>
									<div class="col-md-6">
										 <asp:TextBox ID="txtStoryLine" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtStoryLine" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Story line ingles:</label>
									<div class="col-md-6">
										<asp:TextBox ID="txtStoryLineIngles" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtStoryLineIngles" Font-Bold="True"></asp:RequiredFieldValidator>
								</div>
							</div>
							<!-- end form-group row -->
						</div>
					</div>
				</div>
				<div class="accordion-item border-0">
					<div class="accordion-header" id="headingFour">
						<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour">
							<i class="fa fa-circle fa-fw text-info me-2 fs-8px"></i> SINOPSIS
						</button>
					</div>
					<div id="collapseFour" class="accordion-collapse collapse" data-bs-parent="#accordion">
						<div class="accordion-body bg-gray-800 text-white">
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Sinopsis:</label>
									<div class="col-md-6">
										 <asp:TextBox ID="txtSinopsis" TextMode="MultiLine" Height="200" Enabled="true" class="form-control" runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSinopsis" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
							</div>
							<!-- end form-group row -->
							<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">Sinopsis ingles:</label>
									<div class="col-md-6">
										<asp:TextBox ID="txtSinopsisIngles" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSinopsisIngles" Font-Bold="True"></asp:RequiredFieldValidator>
								</div>
							</div>
							<!-- end form-group row -->
						</div>
					</div>
				</div>
				
				<div class="accordion-item border-0">
					<div class="accordion-header" id="headingSix">
						<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix">
							<i class="fa fa-circle fa-fw text-danger me-2 fs-8px"></i> CONTENIDO
						</button>
					</div>
					<div id="collapseSix" class="accordion-collapse collapse" data-bs-parent="#accordion">
						<div class="accordion-body bg-gray-800 text-white">
							<!-- begin form-group row -->
								<div class="form-group row m-b-10">
									<label class="col-md-3 text-md-right col-form-label">Script del contenido:</label>
										<div class="col-md-6">
											<asp:TextBox ID="txtContenido" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContenido" Font-Bold="True"></asp:RequiredFieldValidator>
										</div>
								</div>
								<!-- end form-group row -->	
							<!-- begin form-group row -->
				<div class="form-group row m-b-10">
								<label class="col-md-3 text-md-right col-form-label">URL del contenido mobile:</label>
									<div class="col-md-6">
										<asp:TextBox ID="txtContenidoMobile" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContenidoMobile" Font-Bold="True"></asp:RequiredFieldValidator>
									</div>
				</div>
				<!-- end form-group row -->	
													<!-- begin form-group row -->
<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">URL del contenido playlist:</label>
								<div class="col-md-6">
									<asp:TextBox ID="txtContenidoPlaylist" TextMode="MultiLine" Height="200" Enabled="true" class="form-control"  runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContenidoPlaylist" Font-Bold="True"></asp:RequiredFieldValidator>
								</div>
</div>
<!-- end form-group row -->	
						</div>
					</div>
				</div>
		
			</div>
			<!-- END #accordion -->
		<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
			<asp:Button ID="btnGuardar" CssClass="btn btn-success" BackColor="Transparent" OnClientClick="recuperarFechaSalida()" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
			<asp:Button ID="btnVolverAlta" CssClass="btn btn-success" BackColor="Transparent"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
		</div>
			
		</div>
	</div>				
	<!-- end col-8 -->
			
			
        </asp:View>
				<asp:View ID="View3" runat="server">
			<!-- begin form-group row -->
							<div class="form-group row m-b-10">
								
								<div class="col-md-6">
                                    <asp:Button ID="btnVolver" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnVolver_Click" runat="server" Text="Volver a regsitros" />
									<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
								</div>
							</div>
							<!-- end form-group row -->
			<!-- BEGIN #testimonials -->
		<div id="testimonials" class="py-5">
			<div class="container-xxl p-3 p-lg-5">
				<div class="text-center mb-5">
					<h1 class="mb-3 text-center">
						<asp:Label ID="Label4" runat="server" Text=""></asp:Label></h1>
					<%--<p class="fs-16px text-body text-opacity-50 text-center mb-0">
						Read testimonials from our satisfied customers. <span class="d-none d-md-inline"><br></span>
						Discover how Color Admin Admin Template enhances productivity and exceeds expectations <span class="d-none d-md-inline"><br></span>
						with its ease of use, advanced features, and exceptional support.
					</p>--%>
				</div>
				<div class="row g-3 g-lg-4 mb-4">
					<div class="col-xl-4 col-md-6">
						<div class="card p-4 border-0 h-100 rounded-5">
							<div class="d-flex align-items-center mb-3">
								<%--<img src="../assets/img/user/user-1.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								<div>
									<h5 class="mb-0">Datos Generales del contenido</h5>
									<%--<small class="text-muted">CEO, Company</small>--%>
								</div>
							</div>
							<div class="mb-4 d-flex">
								<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
								<div class="p-3 fs-5">
									<div class="text-warning d-flex mb-2">
										<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
									</div>
									<ul>
										<li><strong>Orden:</strong>  <asp:Label ID="lblOrden" runat="server" Text="Label"></asp:Label></li>
										<li><strong>Temporada:</strong>  <asp:Label ID="lblTemporada" runat="server" Text=""></asp:Label></li>
										<li><strong>Episodio:</strong>  <asp:Label ID="lblEpisodiio" runat="server" Text=""></asp:Label></li>
										<li><strong>Tiempo(hh:mm):</strong>  <asp:Label ID="lblTiempoHoras" runat="server" Text=""></asp:Label>: <asp:Label ID="lblTiempoMinutos" runat="server" Text=""></asp:Label></li>
									</ul>
									<%--Color Admin Admin Template transformed our workflow. 
									The customization options are unparalleled, and the support team is incredibly responsive.
									<img src="../assets/img/user/user-1.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								</div>
								<div class="d-flex align-items-end">
									<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
								</div>
							</div>
						</div>
					</div>
					<div class="col-xl-4 col-md-6">
						<div class="card p-4 border-0 h-100 rounded-5">
							<div class="d-flex align-items-center mb-3">
								<%--<img src="../assets/img/user/user-3.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								<div>
									<h5 class="mb-0">Story Line</h5>
									<%--<small class="text-muted">CTO, Innovate Corp</small>--%>
								</div>
							</div>
							<div class="mb-4 d-flex">
								<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
								<div class="p-3 fs-5">
									<div class="text-warning d-flex mb-2">
										<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
									</div>
									<asp:Label ID="lblStoryLine" runat="server" Text=""></asp:Label>
								</div>
								<div class="d-flex align-items-end">
									<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
								</div>
							</div>
						</div>
					</div>
					<div class="col-xl-4 col-md-6">
						<div class="card p-4 border-0 h-100 rounded-5">
							<div class="d-flex align-items-center mb-3">
							<%--	<img src="../assets/img/user/user-13.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								<div>
									<h5 class="mb-0">Story Line Ingles</h5>
									<%--<small class="text-muted">Project Manager, Creative Agency</small>--%>
								</div>
							</div>
							<div class="mb-4 d-flex">
								<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
								<div class="p-3 fs-5">
									<div class="text-warning d-flex mb-2">
										<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
									</div>
									<asp:Label ID="lblStoryLineIngles" runat="server" Text=""></asp:Label>
								</div>
								<div class="d-flex align-items-end">
									<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
								</div>
							</div>
						</div>
					</div>
					<%--<div class="col-xl-3 d-none d-xl-block"></div>--%>
					<div class="col-xl-4 col-md-6">
						<div class="card p-4 border-0 h-100 rounded-5">
							<div class="d-flex align-items-center mb-3">
								<%--<img src="../assets/img/user/user-8.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								<div>
									<h5 class="mb-0">Sinopsis</h5>
									<%--<small class="text-muted">Founder, Startup Hub</small>--%>
								</div>
							</div>
							<div class="mb-4 d-flex">
								<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
								<div class="p-3 fs-5">
									<div class="text-warning d-flex mb-2">
										<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
									</div>
									<asp:Label ID="lblSinopsis" runat="server" Text=""></asp:Label>
								</div>
								<div class="d-flex align-items-end">
									<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
								</div>
							</div>
						</div>
					</div>
					<div class="col-xl-4 col-md-6">
					<div class="card p-4 border-0 h-100 rounded-5">
						<div class="d-flex align-items-center mb-3">
							<%--<img src="../assets/img/user/user-8.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
							<div>
								<h5 class="mb-0">Sinopsis Ingles</h5>
								<%--<small class="text-muted">Founder, Startup Hub</small>--%>
							</div>
						</div>
						<div class="mb-4 d-flex">
							<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
							<div class="p-3 fs-5">
								<div class="text-warning d-flex mb-2">
									<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
									<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
									<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
									<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
									<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
								</div>
								<asp:Label ID="lblSinopsisIngles" runat="server" Text=""></asp:Label>
							</div>
							<div class="d-flex align-items-end">
								<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
							</div>
						</div>
					</div>
				</div>
					
					<div class="col-xl-4 col-md-6">
						<div class="card p-4 border-0 h-100 rounded-5">
							<div class="d-flex align-items-center mb-3">
								<%--<img src="../assets/img/user/user-5.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
								<div>
									<h5 class="mb-0">Contenido:</h5>
									<%--<small class="text-muted">CEO, Company</small>--%>
								</div>
							</div>
							<div class="mb-4 d-flex">
								<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
								<div class="p-3 fs-5">
									<div class="text-warning d-flex mb-2">
										<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
										<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
									</div>
									<table id="data-table" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
										<thead>
											<tr>
												<th style="width:400px"><asp:Label ID="lblContenido" runat="server" Text=""></asp:Label> </th>
												</tr>
											</thead>
										
								</table>
									
								</div>
								<div class="d-flex align-items-end">
									<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
								</div>
							</div>
						</div>
					</div>

					<div class="col-xl-12 col-md-12">
				<div class="card p-4 border-0 h-100 rounded-5">
					<div class="d-flex align-items-center mb-3">
						<%--<img src="../assets/img/user/user-5.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
						<div>
							<h5 class="mb-0">Contenido mobile:</h5>
							<%--<small class="text-muted">CEO, Company</small>--%>
						</div>
					</div>
					<div class="mb-12 d-flex">
						<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
						<div class="p-3 fs-5">
							<div class="text-warning d-flex mb-2">
								<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
								<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
								<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
								<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
								<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
							</div>
							<table id="data-table" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
								<thead>
									<tr>
										<th style="width:400px"><asp:Label ID="lblContenidoMobile" runat="server" Text=""></asp:Label> </th>
										</tr>
									</thead>
								
						</table>
							
						</div>
						<div class="d-flex align-items-end">
							<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
						</div>
					</div>
				</div>
</div>		</div>
				<div class="col-xl-12 col-md-12">
					<div class="card p-4 border-0 h-100 rounded-5">
				<div class="d-flex align-items-center mb-3">
					<%--<img src="../assets/img/user/user-5.jpg" class="rounded-circle me-3 w-50px" alt="Client 1">--%>
					<div>
						<h5 class="mb-0">Contenido playlist:</h5>
						<%--<small class="text-muted">CEO, Company</small>--%>
					</div>
				</div>
				<div class="mb-4 d-flex">
					<i class="fa fa-quote-left fa-2x text-body text-opacity-15"></i>
					<div class="p-3 fs-5">
						<div class="text-warning d-flex mb-2">
							<%--<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
							<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
							<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
							<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>
							<iconify-icon icon="ic:baseline-star" class="fs-18px"></iconify-icon>--%>
						</div>
						<table id="data-table" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
							<thead>
								<tr>
									<th style="width:800px;height:400px"> 
										<asp:Literal ID="litPlaylist" runat="server"></asp:Literal> </th>
									</tr>
								</thead>
							
					</table>
						
					</div>
					<div class="d-flex align-items-end">
						<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
					</div>
				</div>
</div>

				</div>
			</div>
		</div>
		<!-- END #testimonials -->
		</asp:View>
    </asp:MultiView>
	
			
		</div>
		<!-- end #content -->
</asp:Content>
