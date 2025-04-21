<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="landingAhayou.home" %>

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
        <asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUltimos" runat="server" SelectMethod="PR_STR_GET_NUEVOS_AGREGADOS" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="PR_PAR_GET_PREGUNTAS_FRECUENTES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLANES_STR" TypeName="landingAhayou.Clases.Contenidos">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblMundo" Name="PV_MUNDO" Type="String" />
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
                <a href="home.aspx" class="header__logo">
                    <img
                        class="header__logo-img"
                        src="imgs/logos/logo-ahayou.png"
                        alt="Logo Ahayou"
                    />
                </a>
                
                <asp:Panel ID="Panel_logout" class="header__nav-buttons" runat="server">
                    <div class="repetitive-buttons">
                        <input class="header__button header__button--icon" type="button" onclick="location.href='home.aspx';" />
                        <input class="header__button header__button--icon" type="button" onclick="location.href='home_us.aspx';" />
                            <div class="header__nav-buttons header__nav-buttons--with-text">
                              <button
                                  class="header__button header__button--text header__button--bg-orange"
                                type="button" onclick="location.href='suscribete.aspx';">
                                  Suscr&iacute;bete
                              </button>
                              <button
                                  class="header__button header__button--text header__button--bg-green"
                               type="button" onclick="location.href='login.aspx';">
                                  Iniciar Sesi&oacute;n
                              </button>
                          </div> 
                        
                    </div>
                     <div class="options__container">
                         <button class="hamburger__button" id="menuButton">
                               <span class="hamburger__line hamburger__line--white"></span>
                            <span class="hamburger__line hamburger__line--white"></span>
                            <span class="hamburger__line hamburger__line--white"></span>
                         </button>
                         <div class="options__menu" id="optionsMenu">
                             <%--<button class="options__button">Espa&ntilde;ol</button>
                             <button class="options__button" >Ingl&eacute;s</button>--%>
         
                              <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Español" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="Ingles" />
                            <input class="options__button" type="button" onclick="location.href='suscribete.aspx';" value="Suscribete" />
                            <input class="options__button" type="button" onclick="location.href='login.aspx';" value="Login" />
                         </div>
                     </div>
                    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
                </asp:Panel>

   
     
                <asp:Panel ID="Panel_login" class="header__nav-buttons submenu__container options__container--second" runat="server">
                    <asp:ImageButton class="header__button header__button--with-img submenu__button" ID="imgPerfil" runat="server" />
                    <div
                        class="submenu options__menu options__menu--flex options__menu--black options__menu--big"
                    >
                        <div class="container--flex container--flex-column">
                            <asp:Repeater ID="Repeater7" DataSourceID="odsAvatares" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton class="options__button--flex" ID="lbtnPerfiles" CommandArgument='<%# Eval("cod_perfil_suscriptor") + "|"+Eval("pin")  %>' OnClick="lbtnPerfiles_Click" runat="server">
                                         <img
                                             src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                             alt="Foto perfil"
                                         />
                                         <p class="text--small text--light"><%# Eval("nombre_perfil") %></p>

                                    </asp:LinkButton>
                     
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:LinkButton class="options__button--flex" OnClick="lbtnCuenta_Click" ID="lbtnCuenta" runat="server">
                                 <img
                                     src="imgs/icons/administration.svg"
                                     alt="Foto perfil"
                                 />
                                 <p class="text--small text text--light">
                                     Cuenta
                                 </p>

                            </asp:LinkButton>
        
           
                            <a href="cartelera.aspx" class="options__button--flex">
                                <img
                                    src="imgs/flags/spain.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Idioma español
                                </p>
                            </a>
                            <a href="cartelera_us.aspx" class="options__button--flex">
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
                        
                </asp:Panel>
            </nav>
            <section class="header__main-content carousel">
                <div class="header__items-container">
                    <div
                        class="arrow__container arrow--rotate carousel__arrow--prev"
                    >
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    <div class="header__list carousel__slides">
                         
                            <asp:Repeater ID="Repeater6" DataSourceID="odsRotador1" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
                               <ItemTemplate>
                                <asp:Label ID="lblIdNumero"  runat="server" Text=' <%# Eval("Numero") %>' Visible="false"></asp:Label>
                                   <asp:Panel ID="panel_banner" class="header__item carousel__item carousel__item--active" data-bg=' <%# Eval("contenido") %>'  runat="server" >
                                                                
                                       <%--<div class="header__item carousel__item active" data-bg=' <%# Eval("contenido") %>'>--%>
                                            <h2 class="header__title">
                                                Streaming <span>con</span> Alma Boliviana
                                            </h2>
                                            <p class="header__description">
                                                Una experiencia mejorada no te pierdas los
                                                estrenos m&aacute;s anticipados y tus
                                                cl&aacute;sicos favoritos
                                            </p>
                                        <%--</div>--%>
                                   </asp:Panel>
                                   <asp:Panel ID="panel_pelicula" class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  Visible="false" runat="server" >
                                        <%--<div class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  >--%>
                                         <div
                                                class="movie__container movie__container--active"
                                            >
                                             <div>
                                             <span class="movie__format"><%# Eval("formato_contenido") %></span>
                                             <img
                                                 src=' <%# Eval("nombre") %>'
                                                 alt='<%# Eval("nombre_contenido") %>'
                                                 class="movie__image"
                                             />
                                              <div class="movie__buttons">
                                                          <asp:LinkButton ID="lbtnReproducir" CommandArgument='<%# Eval("cod_contenido_str") %>' OnClick="lbtnReproducir_Click" class="movie__button movie__button--white" runat="server">
                                                              <img
                                                                  src="imgs/icons/play.svg"
                                                                  alt="Icono reproducir"
                                                              />
                                                              <p>Reproducir</p>
                                                         </asp:LinkButton>
                                                         <a
                                                             href=' <%# "mas_informacion.aspx?ID=" + Eval("cod_contenido_str") %>'
                                                             class="movie__button movie__button--gray"
                                                         >
                                                             <img
                                                                 src="imgs/icons/help-center.svg"
                                                                 alt="Icono mas informacion"
                                                             />
                                                             <p>M&aacute;s informaci&oacute;n</p>
                                                         </a>
                                                     </div>
                                                 </div>
                                             <div>
                                             <span class="movie__detail-1">
                                                <%# Eval("detalle1") %>
                                             </span>
                                             <span class="movie__detail-2">
                                                <%# Eval("detalle2") %>
                                             </span>
                                             <p class="movie__description">
                                                 <%# Eval("resumen") %>
                                             </p>
                                             <span class="movie__gender"><%# Eval("genero") %></span>
                                                 <span class="movie__gender"><%# Eval("genero") %></span>
                                                 </div>
                                            </div>
                                       <asp:LinkButton ID="lbtnBanner" class="movie__container movie__container--second container-common" CommandArgument='<%# Eval("cod_contenido_str") %>' OnClick="lbtnBanner_Click" runat="server">
                                           <%--<div
                                                 class="movie__container movie__container--second container-common"
                                             >--%>
                                                 <img
                                                    src=' <%# Eval("contenido_vertical") %>'
                                                     alt='<%# Eval("nombre_contenido") %>'
                                                 />
                                                 <h3 class="movie__title--small"><%# Eval("nombre_contenido") %></h3>
        
                                                <ul class="movie__data--small">
                                                     <li class="movie__data-item--small">
                                                         <%# Eval("genero") %>
                                                     </li>
                                                     <li class="movie__data-item--small">
                                                          <%# Eval("detalle1") %>
                                                     </li>
                                                     <li class="movie__data-item--small">
                                                          <%# Eval("detalle2") %>
                                                     </li>
                                                     <li class="movie__data-item--small">
                                                         <%# Eval("formato_contenido") %>
                                                     </li>
                                                 </ul>
       
                                             <%--</div>--%>

                                       </asp:LinkButton>
                                       
                                   </asp:Panel>
         
                               </ItemTemplate>
                        </asp:Repeater>
                             </div>
                    <div class="arrow__container carousel__arrow--next">
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    </div>
                <div class="header__pag-buttons">
                    <asp:Repeater ID="Repeater1" DataSourceID="odsRotador1" runat="server">
	                    <ItemTemplate>

                        <%-- <asp:Label ID="lblIdNumero" runat="server" Text=' <%# Eval("Numero") %>' Visible="false"></asp:Label>--%>
                          <button  class="header__pag-button header__pag-button--selected carousel__button">
                         <%--<button class='<%# "header__pag-button carousel__button " + Eval("Numero").ToString().Replace("01","selected") %>'>--%>
                              <%# Eval("Numero") %>
                          </button>
	                    </ItemTemplate>
                 </asp:Repeater>
                </div>
            </section>
        </header>
      
        <main>
            <section class="new-releases carousel">
                <h2 class="new-releases__title">
                     Nuevos <span>agregados</span>
                </h2>
                <div class="new-releases__content">
                    <div class="arrow__container arrow--rotate carousel__arrow--prev" >
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    <div class="new-releases__list">
                          <asp:Repeater ID="Repeater4" DataSourceID="odsUltimos" runat="server">
		                            <ItemTemplate>
                                        <asp:LinkButton class="new-releases__item container-common" ID="lbtnNuevoAgregado" OnClick="lbtnNuevoAgregado_Click" CommandArgument='<%# Eval("cod_contenido_str") %>' runat="server">
                                           <%--<article class="new-releases__item container-common">--%>
                                             <img src='<%# Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />
                                                <%--<img src='<%# "data:image/jpg;base64," + Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />--%>
                                             <div>
                                                 <h3><%# Eval("nombre_contenido") %></h3>
                                                 <p><%# Eval("descripcion") %></p>
                                             </div>
                                         <%--</article>--%>

                                        </asp:LinkButton>
                                           
                                   
		                            </ItemTemplate>
                          </asp:Repeater>
                    </div>
                    <div class="arrow__container carousel__arrow--next">
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                </div>
            </section>
            <section class="plans">
                <h2 class="plans__title">
                    <span>Elige</span> tu Plan
                </h2>
                <div class="plans__list">
                     <asp:Repeater ID="Repeater2" DataSourceID="odsPlanes" runat="server">
	                    <ItemTemplate>
                            <asp:LinkButton ID="lbtnSeleccionPlan" CommandArgument='<%# Eval("url_pasarela")+"|"+ Eval("codigo_plan")%>' OnClick="lbtnSeleccionPlan_Click" class="plans__item" runat="server">
                            <%--<a href="#" class="plans__item">--%>
                                <div class="plans__item--type-2">
                                   <div class="plans__item-content container-common">
                                        <div
                                            class="arrow green absolute arrow__corner"
                                        ></div>
                                        <h3 class="plans__item-title">
                                            <%# Eval("planes") %>
                                        </h3>
                                        <ul class="plans__item-descriptions">
                                            <li><%# Eval("caracteristicas").ToString().Replace("|","<br />") %></li>
                                        </ul>
                                    </div>
                                   <div class="plans__item-price container-common">
                                        <div>
                                            <span class="bs"> <%# Eval("moneda") %></span>
                                            <div class="price__content">
                                                <span class="price__description">Pago &uacute;nico</span>
                                                <span class="price__number"><%# Eval("monto") %></span>
                                                <span class="price__description"><%# Eval("pago_mes") %></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="plans__item-footer">
                                    <p><%# Eval("ahorro") %></p>
                                </div>
                           <%-- </a>--%>
                                </asp:LinkButton>
	                    </ItemTemplate>
                     </asp:Repeater>
                </div>
            </section>
            <section class="frequent-questions" id="frequent-questions">
                <h2 class="frequent-questions__title">
                    <span>Preguntas</span> frecuentes
                </h2>
                 <div class="frequent-questions__content container-common">
                    <div class="frequent-questions__image">
                        <img
                            src="imgs/etc/electronics.png"
                            alt="Dispositivos"
                            id="frequentQuestionsImg"
                        />
                    </div>
                    <ul class="frequent-questions__list">
                         <asp:Repeater ID="Repeater3" DataSourceID="odsPreguntas" runat="server">
                            <ItemTemplate>
                                 <li class="frequent-questions__item underline">
                                     <details name="frequent-questions" class="frequent-questions-detail">
                                         <summary>
                                             <span><%# Eval("pregunta") %></span>
                                             <div class="arrow green-yellow"></div>
                                         </summary>
                                         <p>
                                            <%# Eval("respuesta") %>
                                         </p>
                                     </details>
                                 </li>
                            </ItemTemplate>
                             </asp:Repeater>
                    </ul>
                </div>
            </section>
        </main>
       <section class="web-app-section" id="webAppSection">
             <%--<button
                 class="web-app-section__content container-common"
                 id="downloadContainer" 
             >
                 <h2 class="web-app-section__title" id="downloadTitle">
                     Descarga la Web APP
                 </h2>
                 <div class="web-app-section__container-description">
                     <img
                         src="imgs/logos/pwa_logo.png"
                         alt="PWA"
                         class="web-app-section__image" style="width:250px"
                     />
                     <p class="web-app-section__description">
                         Con esta PWA tendr&aacute; un sitio web que se ve y se
                         comporta como si fuera una aplicaci&oacute;n
                         m&oacute;vil ahorrando espacio en tu dispositivo
                     </p>
                 </div>
             </button>--%>
           <asp:LinkButton class="web-app-section__content container-common" OnClientClick="event.preventDefault();"  BorderColor="Black" ID="downloadContainer" runat="server">
             
               <h2 class="web-app-section__title" id="downloadTitle">
                        Descarga la Web APP
                    </h2>
                    <div class="web-app-section__container-description">
                        <img
                            src="imgs/logos/pwa_logo.png"
                            alt="PWA"
                            class="web-app-section__image" style="width:250px"
                        />
                        <p class="web-app-section__description">
                            Con esta PWA tendr&aacute; un sitio web que se ve y se
                            comporta como si fuera una aplicaci&oacute;n
                            m&oacute;vil ahorrando espacio en tu dispositivo
                        </p>
                    </div>
                  
           </asp:LinkButton>
            <form class="web-app-section__form">
                <label for="email" class="form__label form__label--white">
                    Ya est&aacute;s listo para vivir la experiencia
                    Ah&aacute;you<br />crea tu cuenta ¡¡¡AQU&lacute;!!!
                </label>
                <div class="form__input-container form__input-container--main form__input-container--no-gap">
                    <asp:TextBox ID="email" class="form__input form__input--big-font form__input--specific-width" placeholder="Ingresa tu correo" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSuscribeteEmail" OnClick="btnSuscribeteEmail_Click" class="button button--orange button--no-wrap" runat="server" Text="Suscríbete" />
                    
                </div>
            </form>
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
