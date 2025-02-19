<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contenidos.aspx.cs" Inherits="WebAhayouAdmin.contenidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ahayou</title>
    <link
        rel="icon"
        href="imgs/logos/logo-ahayou-2.png"
        type="image/x-icon"
    />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
        href="https://fonts.googleapis.com/css2?family=Tajawal:wght@200;300;400;500;700;800;900&display=swap"
        rel="stylesheet"
    />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/containers.css" />
    <link rel="stylesheet" href="css/arrow.css" />
    <link rel="stylesheet" href="css/header.css" />
    <link rel="stylesheet" href="css/new-releases.css" />
    <link rel="stylesheet" href="css/plans.css" />
    <link rel="stylesheet" href="css/web-app-section.css" />
    <link rel="stylesheet" href="css/frequent-questions.css" />
    <link rel="manifest" href="<%=  this.ResolveClientUrl("~/")   %>manifest.json" />
    <script src="<%=  this.ResolveClientUrl("~/")   %>Scripts/pwacompat.min.js"></script>
</head>
<body style="background-color:black">
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUltimos" runat="server" SelectMethod="PR_STR_GET_NUEVOS_AGREGADOS" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="PR_PAR_GET_PREGUNTAS_FRECUENTES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsContenidos" runat="server" SelectMethod="PR_PAR_GET_CONTENIDOS_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblContenido" Name="PV_CONTENIDO" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblContenido" runat="server" Visible="false" Text="privacidad"></asp:Label>
            <nav class="header__nav">
                <img class="header__logo" src="imgs/logos/logo-ahayou.png" alt="Logo Ahayou"/>
                <div class="header__nav-buttons">
                    <button class="header__button header__button--text header__button--bg-orange">
                        Suscr&iacute;bete
                    </button>
                    <button class="header__button header__button--text header__button--bg-green">
                        Iniciar Sesi&oacute;n
                    </button>
                </div>
                           </nav>
           <asp:Repeater ID="Repeater3" DataSourceID="odsContenidos" runat="server">
           <ItemTemplate>
                <%# Eval("contenido") %>
               
           </ItemTemplate>
         </asp:Repeater>
            
            <footer class="footer">
                <div class="footer__image-container">
                    <img
                        src="imgs/logos/logo-ahayou-2.png"
                        alt="Logo Ahayou"
                        class="footer__image"
                    />
                </div>
                <div class="footer__content">
                    <div class="footer__list">
                        <div class="footer__list-item">
                            <a href="#">Preguntas frecuentes</a>
                            <a href="#">Privacidad</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="#">Centro de Ayuda</a>
                            <a href="#">Avisos Legales</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="#">T&eacute;rminos de uso</a>
                            <a href="#">Contacto</a>
                        </div>
                    </div>
                    <div class="footer__data">
                        <div class="footer__contacts">
                            <div>
                                <span>+(591) 75874441</span>
                            </div>
                            <div class="social-media">
                                 <asp:Repeater ID="Repeater5" DataSourceID="odsRedesSociales" runat="server">
	                                    <ItemTemplate>
                                             <a href="<%# Eval("url") + ",_blank" %>" class="social-media__link">
                                                 <img
                                                     src='<%# "imgs/logos/" + Eval("red_social") + ".svg" %>'
                                                     alt='<%# Eval("red_social") %>'
                                                     class="social-media__img"
                                                 />
                                             </a>
 
	                                    </ItemTemplate>
                                 </asp:Repeater>
                            </div>
                        </div>
                        <div class="footer__copyright">
                            <p>Copyright 2025 Bolivia</p>
                            <p>Ahayou</p>
                        </div>
                    </div>
                </div>
            </footer>
       <script src="js/carousel.js"></script>
        <script src="js/carousel-new-releases.js"></script>
        <script src="js/web-app-title.js"></script>
        <script src="js/open-accordion-image.js"></script>
    </form>
</body>
</html>