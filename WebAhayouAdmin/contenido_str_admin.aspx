<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="contenido_str_admin.aspx.cs" Inherits="WebAhayouAdmin.contenido_str_admin" %>
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
	<asp:ObjectDataSource ID="odsGrilla" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_STR" TypeName="WebAhayouAdmin.Clases.Contenidos_streaming">
	<%--</asp:ObjectDataSource>
	   <asp:ObjectDataSource ID="odsClasificacion" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="WebAhayouAdmin.Clases.Dominios">
	   <SelectParameters>
			<asp:Parameter DefaultValue="CLASIFICACION" Name="pV_DOMINIO" />
	</SelectParameters>--%>
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
			<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClick="btnNuevo_Click" runat="server" Text="Nuevo contenido streaming" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
												<!-- begin page-header -->
																<h1 class="page-header">Contenido streaming admin <small></small></h1>
																<%--Contenido:
																<asp:DropDownList ID="ddlFormatoContenido" class="form-select-lg col-lg-4" AutoPostBack="true" OnSelectedIndexChanged="ddlFormatoContenido_SelectedIndexChanged"  DataSourceID="odsFormatoContenido" DataTextField="FORMATO_CONTENIDO" DataValueField="COD_FORMATO_CONTENIDO" OnDataBound="ddlFormatoContenido_DataBound" runat="server"></asp:DropDownList>
																<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFormatoContenido" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>	--%>
												<!-- end page-header -->
											<div class="panel-body">
											<table id="data-table-responsive" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
												<thead>
													<tr>
													<th class="text-wrap" style="width:10px">CODIGO CONTENIDO STR</th>
																	<th class="text-nowrap">NOMBRE CONTENIDO</th>
																	<th class="text-nowrap">FORMATO CONTENIDO</th>
																	<%--<th class="text-nowrap">CLASIFICACION</th>
																	<th class="text-nowrap">GENERO</th>
																	<th class="text-nowrap">CLASIFICACION PUBLICO</th>
																	<th class="text-nowrap">GESTION</th>
																	<th class="text-nowrap">ES TEMPORADAS</th>
																	<th class="text-nowrap">TEMPORADAS</th>
																	<th class="text-nowrap">TIEMPO HORA</th>
																	<th class="text-nowrap">TIEMPO MINUTOS</th>
																	<th class="text-nowrap">TIPO AUDIO</th>
																	<th class="text-nowrap">STORY LINE</th>
																	<th class="text-nowrap">STORY LINE INGLES</th>
																	<th class="text-nowrap">SINOPSIS</th>
																	<th class="text-nowrap">SINOPSIS INGLES</th>
																	<th class="text-nowrap">DIRECTOR</th>
																	<th class="text-nowrap">REPARTO</th>
																	<th class="text-nowrap">NACIONALIDAD</th>
																	<th class="text-nowrap">IDIOMA ORIGINAL</th>
																	<th class="text-nowrap">ES SUBTITULADA</th>
																	<th class="text-nowrap">CREDITOS</th>
																	<th class="text-nowrap">FOTO VERTICAL</th>
																	<th class="text-nowrap">FOTO HORIZONTAL</th>
																	<th class="text-nowrap">FOTO MINIATURA</th>
																	<th class="text-nowrap">FOTO TITULO</th>--%>
																	<th class="text-nowrap">FECHA PUBLICACION</th>
																	<th class="text-nowrap">ESTADO</th>
																	<%--<th class="text-nowrap">PRODUCTORA</th>
																	<th class="text-nowrap">ES GRATUITA</th>--%>
													<th class="text-nowrap" data-orderable="false">OPCIONES</th>
				
													</tr>
												</thead>
												<tbody>
									<asp:Repeater ID="Repeater1" DataSourceID="odsGrilla" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
									<ItemTemplate>
													<tr class="gradeA">
								
													<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
													<td><asp:Label ID="lblEsPrincipal11" runat="server" Text='<%# Eval("COD_CONTENIDO_STR") %>'></asp:Label></td>
													<td><asp:Label ID="lblEsPrincipal1" runat="server" Text='<%# Eval("	NOMBRE_CONTENIDO") %>'></asp:Label></td>
													<td><asp:Label ID="lblEsPrincipal3" runat="server" Text='<%# Eval("FORMATO_CONTENIDO") %>'></asp:Label></td>
														<%--<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("CLASIFIFICACION_CONTENIDO") %>'></asp:Label></td>
														<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("GENERO") %>'></asp:Label></td>
														<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("CLASIFICACION_PUBLICO") %>'></asp:Label></td>
														<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("GESTION") %>'></asp:Label></td>
														<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("ES_TEMPORADA") %>'></asp:Label></td>
														<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("TEMPORADAS") %>'></asp:Label></td>
														<td><asp:Label ID="Label7" runat="server" Text='<%# Eval("TIEMPO_HORA") %>'></asp:Label></td>
														<td><asp:Label ID="Label8" runat="server" Text='<%# Eval("TIEMPO_MINUTOS") %>'></asp:Label></td>
														<td><asp:Label ID="Label9" runat="server" Text='<%# Eval("TIPO_AUDIO") %>'></asp:Label></td>
														<td><asp:Label ID="Label10" runat="server" Text='<%# Eval("STORY_LINE") %>'></asp:Label></td>
														<td><asp:Label ID="Label11" runat="server" Text='<%# Eval("STORY_LINE_INGLES") %>'></asp:Label></td>
														<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("SINOPSIS") %>'></asp:Label></td>
														<td><asp:Label ID="Label13" runat="server" Text='<%# Eval("SINOPSIS_INGLES") %>'></asp:Label></td>
														<td><asp:Label ID="Label14" runat="server" Text='<%# Eval("DIRECTOR") %>'></asp:Label></td>
														<td><asp:Label ID="Label15" runat="server" Text='<%# Eval("REPARTO") %>'></asp:Label></td>
														<td><asp:Label ID="Label16" runat="server" Text='<%# Eval("NACIONALIDAD") %>'></asp:Label></td>
														<td><asp:Label ID="Label17" runat="server" Text='<%# Eval("IDIOMA_ORIGINAL") %>'></asp:Label></td>
														<td><asp:Label ID="Label18" runat="server" Text='<%# Eval("ES_SUBTITULADA") %>'></asp:Label></td>
														<td><asp:Label ID="Label19" runat="server" Text='<%# Eval("CREDITOS") %>'></asp:Label></td>

														<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%#  Eval("foto_vertical") %>' /></td>
														<td><asp:Image ID="Image2" Height="50px" runat="server" ImageUrl='<%#  Eval("foto_miniatura") %>' /></td>
														<td><asp:Image ID="Image3" Height="50px" runat="server" ImageUrl='<%#  Eval("foto_horizontal") %>' /></td>
														<td><asp:Image ID="Image4" Height="50px" runat="server" ImageUrl='<%#  Eval("titulo") %>' BackColor="Black" /></td>--%>

														<td><asp:Label ID="Label25" runat="server" Text='<%# Eval("FECHA_PUBLICACION") %>'></asp:Label></td>
														<td><asp:Label ID="Label26" runat="server" Text='<%# Eval("ESTADO_CONTENIDO") %>'></asp:Label></td>
														<%--<td><asp:Label ID="Label27" runat="server" Text='<%# Eval("PRODUCTORA") %>'></asp:Label></td>
														<td><asp:Label ID="Label28" runat="server" Text='<%# Eval("ES_GRATUITA") %>'></asp:Label></td>--%>
														
																	
																	<%--<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>--%>
													<td>
																	<asp:Button ID="btnVer" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>' OnClick="btnVer_Click" runat="server" Text="Ver informacion" ToolTip="Ver todos los datos" />
																	<asp:Button ID="btnEditar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																	<asp:Button ID="btnEliminar" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>' OnClientClick="return confirm('Estas seguro de eliminar el registro???')" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" ToolTip="Elimina el registro" />
																	<asp:Button ID="btnTrailer" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>'  OnClick="btnTrailer_Click" runat="server" Text="Trailers" ToolTip="Trailers admin" Visible='<%# Eval("trailers").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' />
																	<asp:Button ID="btnTemporadas" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>'  OnClick="btnTemporadas_Click" runat="server" Text="Temporadas" ToolTip="Temporadas admin" Visible='<%# Eval("temporadas_episodios").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' />
																	<asp:Button ID="btnPeliculas" class="btn btn-success btn-sm" BackColor="Transparent" forecolor="Black" CommandArgument='<%# Eval("COD_CONTENIDO_STR") %>'  OnClick="btnPeliculas_Click" runat="server" Text="Peliculas" ToolTip="Peliculas admin" Visible='<%# Eval("contenido_peliculas").ToString().Equals("SI".ToString()) ? Convert.ToBoolean(1) : Convert.ToBoolean(0) %>' />
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
										<i class="fa fa-circle fa-fw text-blue me-2 fs-8px"></i> Collapsible Group Item #1
									</button>
								</div>
								<div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										<!-- begin form-group row -->
											<div class="form-group row m-b-10">
															<label class="col-md-3 text-md-right col-form-label">Codigo clasificacion contenido:</label>
															<div class="col-md-6">
													 <asp:TextBox ID="txtCodigo" Enabled="false" class="form-control" runat="server"></asp:TextBox>
																<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>--%>
															</div>
											</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
																		<label class="col-md-3 text-md-right col-form-label">Formato contenido:</label>
																		<div class="col-md-6">
																 <asp:TextBox ID="txtFormatoContenido" Enabled="false" class="form-control" runat="server"></asp:TextBox>
																			<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>--%>
																		</div>
											</div>
											<!-- end form-group row -->
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
																		<label class="col-md-3 text-md-right col-form-label">Clasificacion:</label>
																		<div class="col-md-6">
																			<%--<asp:DropDownList ID="ddlClasificacion" class="form-select-lg col-lg-6"  DataSourceID="odsClasificacion" DataTextField="DESCRIPCION" DataValueField="CODIGO" OnDataBound="ddlClasificacion_DataBound" runat="server"></asp:DropDownList>
																			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlFormatoContenido" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>	--%>
																		</div>
											</div>
											<!-- end form-group row -->
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingTwo">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo">
										<i class="fa fa-circle fa-fw text-indigo me-2 fs-8px"></i> Collapsible Group Item #2
									</button>
								</div>
								<div id="collapseTwo" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingThree">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree">
										<i class="fa fa-circle fa-fw text-teal me-2 fs-8px"></i> Collapsible Group Item #3
									</button>
								</div>
								<div id="collapseThree" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingFour">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour">
										<i class="fa fa-circle fa-fw text-info me-2 fs-8px"></i> Collapsible Group Item #4
									</button>
								</div>
								<div id="collapseFour" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingFive">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFive">
										<i class="fa fa-circle fa-fw text-warning me-2 fs-8px"></i> Collapsible Group Item #5
									</button>
								</div>
								<div id="collapseFive" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingSix">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix">
										<i class="fa fa-circle fa-fw text-danger me-2 fs-8px"></i> Collapsible Group Item #6
									</button>
								</div>
								<div id="collapseSix" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
							<div class="accordion-item border-0">
								<div class="accordion-header" id="headingSeven">
									<button class="accordion-button bg-gray-900 text-white px-3 pt-10px pb-10px pointer-cursor collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSeven">
										<i class="fa fa-circle fa-fw text-muted me-2 fs-8px"></i> Collapsible Group Item #7
									</button>
								</div>
								<div id="collapseSeven" class="accordion-collapse collapse" data-bs-parent="#accordion">
									<div class="accordion-body bg-gray-800 text-white">
										Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
									</div>
								</div>
							</div>
					
						</div>
						<!-- END #accordion -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-success" BackColor="Transparent" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-success" BackColor="Transparent"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			<!-- BEGIN #testimonials -->
		<div id="testimonials" class="py-5">
			<div class="container-xxl p-3 p-lg-5">
				<div class="text-center mb-5">
					<h1 class="mb-3 text-center">
						<asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h1>
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
										<li><strong>Formato:</strong>  <asp:Label ID="lblFormato" runat="server" Text="Label"></asp:Label></li>
										<li><strong>Clasificacion contenido:</strong>  <asp:Label ID="lblClasificacionContenido" runat="server" Text=""></asp:Label></li>
										<li><strong>Genero:</strong>  <asp:Label ID="lblGenero" runat="server" Text=""></asp:Label></li>
										<li><strong>Clasificacion publico:</strong>  <asp:Label ID="lblClasificacionPublico" runat="server" Text=""></asp:Label></li>
										<li><strong>Gestion:</strong>  <asp:Label ID="lblGestion" runat="server" Text=""></asp:Label></li>
										<li><strong>Tiempo(hh:mm):</strong>  <asp:Label ID="lblTiempoHoras" runat="server" Text=""></asp:Label>: <asp:Label ID="lblTiempoMinutos" runat="server" Text=""></asp:Label></li>
										<li><strong>Audio:</strong>  <asp:Label ID="lblAudio" runat="server" Text=""></asp:Label></li>
										<li><strong>Fecha de publicacion:</strong>  <asp:Label ID="lblFechaPublicacion" runat="server" Text=""></asp:Label></li>
										<li><strong>Nacionalidad:</strong>  <asp:Label ID="lblNacionalidad" runat="server" Text=""></asp:Label></li>
										<li><strong>Idioma Original:</strong>  <asp:Label ID="lblIdiomaOriginal" runat="server" Text=""></asp:Label></li>
										<li><strong>Es subtitulada:</strong>  <asp:Label ID="lblEsSubtitulada" runat="server" Text=""></asp:Label></li>
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
									<h5 class="mb-0">Director: <asp:Label ID="lblDirector" runat="server" Text=""></asp:Label></h5>
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
								<strong>Reparto:</strong> <asp:Label ID="lblReparto" runat="server" Text=""></asp:Label>
									<br /><br />
								<strong>Creditos:</strong><asp:Label ID="lblCreditos" runat="server" Text=""></asp:Label>
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
							<h5 class="mb-0">Fotos cargadas: <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h5>
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
						<strong>Foto vertical:</strong> <asp:Image ID="imgVertical" runat="server" Height="100" />
							<br /><br />
						<strong>Foto horizontal:</strong> <asp:Image ID="imgHorizontal" runat="server" Width="100" />
							<br /><br />
						<strong>Foto miniatura:</strong> <asp:Image ID="imgMiniatura" runat="server" Width="100" />
							<br /><br />
						<strong>Foto Titulo:</strong> <asp:Image ID="imgTitulo" runat="server" Height="50" BackColor="Black"/>
						</div>
						<div class="d-flex align-items-end">
							<i class="fa fa-quote-right fa-2x text-body text-opacity-15"></i>
						</div>
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
