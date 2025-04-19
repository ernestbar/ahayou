<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporte_vista_contenidos.aspx.cs" Inherits="WebAhayouAdmin.reporte_vista_contenidos" %>
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

	    <asp:ObjectDataSource ID="odsReporte" runat="server" SelectMethod="PR_REP_GET_REGISTRO_PROPIETARIOS" TypeName="WebAhayouAdmin.Clases.Reportes">
	</asp:ObjectDataSource>
	<%--<asp:ObjectDataSource ID="odsDominios" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="WebAhayouAdmin.Clases.Dominios">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlDominio" Name="PV_DOMINIO" Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>--%>
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
			<asp:Label ID="lblCodProductora" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="White" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                             Fecha inicio:
											<input id="fecha_salida" class="form-control col-1"  style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
											Fecha fin:
											<input id="fecha_retorno" class="form-control col-md-1"  style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
											<!-- end page-header --><br /><br />
                                            <asp:Button ID="btnConsultar" class="btn btn-success btn-lg col-md-12" BackColor="Transparent" OnClientClick="recuperarFechaSalida()" OnClick="btnConsultar_Click" runat="server" Text="Generar Reporte" />
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin page-header -->
											<h1 class="page-header">Reporte vista de contenidos<small></small></h1>
											<div class="panel-body">
													<table id="data-table-buttons" width="100%" class="table table-striped table-bordered align-middle text-nowrap" style="background-color:white;">
														<thead>
															<tr>
															<th class="text-wrap">USUARIO</th>
																			<th class="text-nowrap">NOMBRE COMPLETO</th>
																			<th class="text-nowrap">NOMBRE CONTENIDO</th>
																			<th class="text-nowrap">PRODUCTORA</th>
																			<th class="text-nowrap">FECHA</th>
															</tr>
														</thead>
														<tbody>
															<asp:Repeater ID="Repeater1" runat="server">
															<ItemTemplate>
																			<tr class="gradeA">
								
																			<td><asp:Label ID="lblEsPrincipal2" runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label></td>
																							<td><asp:Label ID="Label21" runat="server" Text='<%# Eval("NOMBRE_COMPLETO") %>'></asp:Label></td>
																							<td><asp:Label ID="Label22" runat="server" Text='<%# Eval("NOMBRE_CONTENIDO") %>'></asp:Label></td>
																							<td><asp:Label ID="Label23" runat="server" Text='<%# Eval("PRODUCTORA") %>'></asp:Label></td>
																							<td><asp:Label ID="Label54" runat="server" Text='<%# Eval("FECHA") %>'></asp:Label></td>
															</tr>
															</ItemTemplate>
															</asp:Repeater>
														</tbody>
													</table>
												</div>
												<!-- END panel-body -->
			</asp:View>
		</asp:MultiView>
	
		</div>
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
            document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
        }
        function setearFechaSalida() {

            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
            document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }
    </script>
</asp:Content>
