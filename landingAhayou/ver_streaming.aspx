<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ver_streaming.aspx.cs" Inherits="landingAhayou.ver_streaming" %>

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
        <link rel="stylesheet" href="css/header-movies.css" />
        <link rel="stylesheet" href="css/forms.css" />
        <link rel="stylesheet" href="css/header-options.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />


    <link rel="manifest" href="<%=  this.ResolveClientUrl("~/")   %>manifest.json" />
    <script src="<%=  this.ResolveClientUrl("~/")   %>Scripts/pwacompat.min.js"></script>
   <script>
       if ('serviceWorker' in navigator) {
           window.addEventListener('load', () => {
               navigator.serviceWorker.register('service-worker.js')
                   .then(registration => {
                       console.log('Service Worker registered with scope:', registration.scope);
                   })
                   .catch(error => {
                       console.error('Service Worker registration failed:', error);
                   });
           });
       }
   </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUltimos" runat="server" SelectMethod="PR_STR_GET_NUEVOS_AGREGADOS" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="PR_PAR_GET_PREGUNTAS_FRECUENTES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>--%>
        <asp:ObjectDataSource ID="odsContenidoInd" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_STR_IND" TypeName="landingAhayou.Clases.Contenidos">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblMundo" Name="PV_COD_CONTENIDO_STR" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
        </asp:ObjectDataSource>
         <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
             <SelectParameters>
                 <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
             </SelectParameters>
         </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
         <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
         <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
         <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
         <asp:Label ID="lblMenu" runat="server" Visible="false" Text="0"></asp:Label>
         <header class="header header--main" id="header__movies">
            <nav class="header__nav">
                <a href="cartelera.aspx" class="header__logo">
                    <img
                        class="header__logo-img"
                        src="imgs/logos/logo-ahayou.png"
                        alt="Logo Ahayou"
                    />
                </a>
                <asp:Button ID="btnVoler"  class="header__button header__button--text header__button--bg-orange" OnClick="btnVoler_Click" runat="server" Text="Volver" />
                <%--<asp:Panel ID="Panel_logout" class="header__nav-buttons" runat="server">
                    <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnSuscribete" OnClick="btnSuscribete_Click" runat="server" Text="Suscribete" />
                    <asp:Button class="header__button header__button--text header__button--bg-green" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Iniciar Session" />
                    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
                    <div class="repetitive-buttons">
                    <input class="header__button header__button--icon" type="button" onclick="location.href='home.aspx';" />
                    <input class="header__button header__button--icon" type="button" onclick="location.href='home_us.aspx';" />
                    </div>
                     <div class="options__container">
                         <button class="hamburger__button" id="menuButton">
                               <span class="hamburger__line hamburger__line--white"></span>
                            <span class="hamburger__line hamburger__line--white"></span>
                            <span class="hamburger__line hamburger__line--white"></span>
                         </button>
                         <div class="options__menu" id="optionsMenu">
                             
                              <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Español" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="Ingles" />
                         </div>
                     </div>
                </asp:Panel>
                <asp:Panel ID="Panel_login" class="header__nav-buttons submenu__container options__container--second" runat="server">
                    <asp:ImageButton class="header__button header__button--with-img submenu__button" ID="imgPerfil" runat="server" />
                   
                    <div
                        class="submenu options__menu options__menu--flex options__menu--black options__menu--big"
                    >
                        <div class="container--flex container--flex-column">
                            <asp:Repeater ID="Repeater7" DataSourceID="odsAvatares" runat="server">
                                <ItemTemplate>
                                     <a href="#" class="options__button--flex">
                                         <img
                                             src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                             alt="Foto perfil"
                                         />
                                         <p class="text--small text--light"><%# Eval("nombre_perfil") %></p>
                                     </a>
                                </ItemTemplate>
                            </asp:Repeater>
       
        
                            <a href="#" class="options__button--flex">
                                <img
                                    src="imgs/icons/administration.svg"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Administraci&oacute;n
                                </p>
                            </a>
                            <a href="#" class="options__button--flex">
                                <img
                                    src="imgs/icons/profile.svg"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Cuenta
                                </p>
                            </a>
                            <a href="#" class="options__button--flex">
                                <img
                                    src="imgs/icons/help-center.svg"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Centro de ayuda
                                </p>
                            </a>
                            <a href="#" class="options__button--flex">
                                <img
                                    src="imgs/flags/spain.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Idioma español
                                </p>
                            </a>
                            <a href="#" class="options__button--flex">
                                <img
                                    src="imgs/flags/eeuu.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Idioma ingles
                                </p>
                            </a>
                        </div>
    
                        <asp:Repeater ID="Repeater8" DataSourceID="odsMenus" runat="server">
                         <ItemTemplate>
                             <asp:Button ID="btnMenu" class="options__button--last text--light text--center text--small" CommandArgument='<%# Eval("cod_formato_contenido") %>' OnClick="btnMenu_Click" runat="server" Text='<%# Eval("formato_contenido") %>' />
                         </ItemTemplate>
                     </asp:Repeater>
                        <asp:Button class="options__button--last text--light text--center text--small" OnClick="btnCerrar_Click" ID="btnCerrar" runat="server" Text="Cerrar Sessión" />
    
                    </div>
                </asp:Panel>--%>
            </nav>
              <iframe  runat="server" id="ifrm1"
                 src=""
                 title=""
                 frameborder="0"
                 allowfullscreen="1"
                 allow="autoplay"
                 style="position:page; top:0; left:0; bottom:0; right:0; width:100%; height:100%; border:none; margin:0; padding:0; overflow:revert-layer; z-index:999999;"
             ></iframe>
            <section class="header__main-content carousel">
                <div class="header__items-container">
                       <%--<asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                               
                            </ItemTemplate>
                        </asp:Repeater>--%>
                    
                    </div>
                
            </section>
        </header>
      
        
       <section class="web-app-section" id="webAppSection">
           
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
                            <a href="#frequent-questions">
                                Preguntas frecuentes
                            </a>
                            <a href="contenidos.aspx?t=privacidad" target="_blank">Privacidad</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="centro_ayuda.aspx" target="_blank">Centro de Ayuda</a>
                             <a href="contenidos.aspx?t=avisos legales" target="_blank">Avisos Legales</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="contenidos.aspx?t=terminos de uso" target="_blank">T&eacute;rminos de uso</a>
                            <a href="contacto.aspx" target="_blank">Contacto</a>
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
                                             <a href="<%# Eval("url") %>"  target="_blank" class="social-media__link">
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
        </section>

       <script src="js/header-background-handler.js"></script>
        <script src="js/carousel-header-index.js"></script>
        <script src="js/carousel-new-releases.js"></script>
        <script src="js/web-app-title.js"></script>
        <script src="js/open-menu.js"></script>
        <script src="js/header-movies-responsive.js"></script>
        <script src="js/movie-container-hover.js"></script>

        <script defer src="js/carousel.js"></script>
        <script src="js/open-submenu.js"></script>
        <script src="js/header-movies-responsive.js"></script>
        <script src="js/movie-container-hover.js"></script>
      
         <script>
             let deferredPrompt;

             function isIOS() {
                 return /iPhone|iPad|iPod/i.test(navigator.userAgent);
             }

             if (isIOS()) {
                 const iosInstructions = document.getElementById('ios-instructions');
                 iosInstructions.style.display = 'block';

                 document.getElementById('ios-close-btn').addEventListener('click', () => {
                     iosInstructions.style.display = 'none';
                 });
             }

             window.addEventListener('beforeinstallprompt', (e) => {
                 e.preventDefault();
                 deferredPrompt = e;
                 document.getElementById('downloadContainer').style.display = 'block';
             });

             document.getElementById('downloadContainer').addEventListener('click', async () => {
                 if (deferredPrompt) {
                     deferredPrompt.prompt();
                     const { outcome } = await deferredPrompt.userChoice;
                     console.log(`User response: ${outcome}`);
                     deferredPrompt = null;
                 }
             });

             window.addEventListener('appinstalled', () => {
                 console.log('PWA installed');
                 document.getElementById('downloadContainer').style.display = 'none';
             });
         </script>
    </form>
</body>
</html>
