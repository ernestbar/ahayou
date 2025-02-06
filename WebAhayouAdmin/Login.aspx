<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAhayouAdmin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <meta charset="utf-8" />
	<title>Ahayou Admin Login</title>
	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN core-css ================== -->
	<link href="assets/css/vendor.min.css" rel="stylesheet" />
	<link href="assets/css/default/app.min.css" rel="stylesheet" />
	<!-- ================== END core-css ================== -->

	<!-- ================== BEGIN page-css ================== -->
	<link href="assets/plugins/datatables.net-bs5/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
	<link href="assets/plugins/datatables.net-responsive-bs5/css/responsive.bootstrap5.min.css" rel="stylesheet" />
	<!-- ================== END page-css ================== -->
	
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnIngresar">


	<!-- BEGIN #app -->
	<div id="app" class="app">
		<!-- BEGIN login -->
		<div class="login login-v1"   style="background-image:url('Imagenes/fondo_negro.png'); background-repeat: no-repeat; background-size: 100% 100%;">
			<!-- BEGIN login-container -->
			<div class="login-container">
				<!-- BEGIN login-header -->
				<div class="login-header">
					<div class="brand">
						<div class="d-flex align-items-center">
							<asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/logo-ahayou.png" /> 
						</div>
						
					</div>
				
				</div>
				<!-- END login-header -->
				
				<!-- BEGIN login-body -->
				<div class="login-body"  style="border-radius:30px;background-image:url('Imagenes/fondo_negro.png');opacity:0.9" >
			<!-- BEGIN scrollbar -->
			<div class="app-sidebar-content" data-height="100%" style="position: relative;border-radius:30px;
						background: rgba(255, 255, 255, 0.2);
						backdrop-filter: blur(5px);
						background-image: linear-gradient(to bottom right, rgba(0, 0, 0, 0.5),transparent)">
				<asp:Label ID="lblAviso" runat="server" ForeColor="White" Text=""></asp:Label>
				<br />	<br />	
					<!-- BEGIN login-content -->
					<div class="login-content fs-13px">
							<div class="form-floating mb-20px">
								<asp:TextBox ID="txtEmail"  class="form-control fs-13px h-45px"  runat="server"></asp:TextBox>
								<label for="emailAddress" class="d-flex align-items-center">Correo Electronico</label>
							</div>
							<div class="form-floating mb-20px">
								<asp:TextBox ID="txtPassword" TextMode="Password"  class="form-control fs-13px h-45px" runat="server"></asp:TextBox>
								<label for="password" class="d-flex align-items-center">Password</label>
							</div>
							<div class="form-check mb-20px">
								<input class="form-check-input" type="checkbox" value="" id="rememberMe" />
								<label class="form-check-label" for="rememberMe">
									Recuerdame
								</label>
							</div>
							<div class="login-buttons">
								<asp:Button ID="btnIngresar"  BackColor="Transparent" BorderColor="White" class="btn btn-theme h-45px d-block w-100 btn-lg" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
							</div><br />
						<div class="login-buttons">
										<asp:Button ID="btnResetear"  BackColor="Transparent" BorderColor="Red" ForeColor="Red" class="btn btn-danger h-45px d-block w-100 btn-lg" runat="server" Text="Resetear contraseña" OnClientClick="return confirm('Esta seguro de resetear su password???')"  OnClick="btnResetear_Click" />
						</div>

					</div>
				<br />	<br />	
					<!-- END login-content -->
				</div>
				<!-- END login-body -->
			</div>
			<!-- END login-container -->
		</div>
		<!-- END login -->
		
		</div>
	</div>
	<!-- END #app -->
    </form>
	<!-- ================== BEGIN core-js ================== -->
	<script src="assets/js/vendor.min.js"></script>
	<script src="assets/js/app.min.js"></script>
	<!-- ================== END core-js ================== -->
</body>
</html>
