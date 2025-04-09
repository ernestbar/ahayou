<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cartelera.aspx.cs" Inherits="landingAhayou.cartelera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <link rel="stylesheet" href="css/header-movies.css" />
        <link rel="stylesheet" href="css/header-options.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/ribbon.css" />
        <link rel="stylesheet" href="css/playlist.css" />
        <link rel="stylesheet" href="css/backgrounds-divs.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/carousel.css" />
        <link rel="stylesheet" href="css/forms.css" />

        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/default-background.css" />
        <link rel="stylesheet" href="css/search-results.css" />
</head>
<body>
    <form id="form1" runat="server">
       <asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
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
        <asp:ObjectDataSource ID="odsSecciones" runat="server" SelectMethod="PR_STR_GET_VER_SECCIONES_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblUsuario" Name="PV_USUARIO" Type="String" />
            <asp:ControlParameter ControlID="lblplanSuscriptor" Name="PV_COD_PLAN_SUSCRIPTOR" Type="String" />
            <asp:ControlParameter ControlID="lblPerfilSuscriptor" Name="PV_COD_PERFIL_SUSCRIPTOR" Type="String" />
            <asp:ControlParameter ControlID="lblMenu" Name="PI_MENU" Type="String" />
        </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMasVistos" runat="server" SelectMethod="PR_STR_GET_FAVORITOS" TypeName="landingAhayou.Clases.Carteleras">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblUsuario" Name="PV_USUARIO" Type="String" />
            <asp:ControlParameter ControlID="lblplanSuscriptor" Name="PV_COD_PLAN_SUSCRIPTOR" Type="String" />
            <asp:ControlParameter ControlID="lblPerfilSuscriptor" Name="PV_COD_PERFIL_SUSCRIPTOR" Type="String" />
            <asp:ControlParameter ControlID="lblMenu" Name="PI_MENU" Type="String" />
        </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
        <asp:Label ID="lblUsuario1" runat="server" Visible="false" Text=""></asp:Label>
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
                    <div class="header__nav-buttons header__nav-input">
                            <asp:TextBox ID="txtBusqueda" class="header__input" ValidationGroup="busqueda" placeholder="Buscar..." runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Orange" ValidationGroup="busqueda" ControlToValidate="txtBusqueda"></asp:RequiredFieldValidator>
                            <asp:ImageButton ID="btnBusqueda1" class="header__button--search" Height="46px" ImageUrl="~/imgs/icons/search.svg" ValidationGroup="busqueda" OnClick="btnBusqueda_Click" runat="server" />
                    </div>
                <asp:Panel ID="Panel_logout" class="header__nav-buttons" runat="server">
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
                             <%--<button class="options__button">Espa&ntilde;ol</button>
                             <button class="options__button" >Ingl&eacute;s</button>--%>
         
                              <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Español" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="Ingles" />
                         </div>
                     </div>
                </asp:Panel>
                
                   
     
                <asp:Panel ID="Panel_login" class="header__nav-buttons submenu__container options__container--second" runat="server">
                   
                        
                        
                        
                    <asp:ImageButton class="header__button header__button--with-img submenu__button" ID="imgPerfil" runat="server" />
                    <%--<button
                        class="header__button header__button--with-img submenu__button"
                    >
                        <asp:Image class="header__button header__button--with-img submenu__button"  ID="imgPerfil" runat="server"  />
                    </button>--%>
                    <div
                        class="submenu options__menu options__menu--flex options__menu--black options__menu--big"
                    >
                        <div class="container--flex container--flex-column">
                            <asp:Repeater ID="Repeater7" DataSourceID="odsAvatares" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton class="options__button--flex" ID="lbtnPerfiles" CommandArgument='<%# Eval("cod_perfil_suscriptor") %>' OnClick="lbtnPerfiles_Click" runat="server">
                                         <img
                                             src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                             alt="Foto perfil"
                                         />
                                         <p class="text--small text--light"><%# Eval("nombre_perfil") %></p>

                                    </asp:LinkButton>
                                     
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
                                                <b>Streaming</b> con <b>Alma Boliviana</b>
                                            </h2>
                                            <p class="header__description">
                                                Una experiencia mejorada no te pierdas los
                                                estrenos m&aacute;s anticipados y tus
                                                cl&aacute;sicos favoritos
                                            </p>
                                        <%--</div>--%>
                                   </asp:Panel>
                                   <asp:Panel ID="panel_pelicula" HorizontalAlign="Left" class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  Visible="false" runat="server" >
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
                                                    <%--<a
                                                        href=' <%# "ver_streaming.aspx?ID=" + Eval("cod_contenido_str") %>'
                                                        class="movie__button movie__button--white"
                                                    >
                                                        <img
                                                            src="imgs/icons/play.svg"
                                                            alt="Icono reproducir"
                                                        />
                                                        <p>Reproducir</p>
                                                    </a>--%>
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
                                                 </div>
                                            </div>
                        
                                       <div
                                            class="movie__container movie__container--second container-common"
                                        >
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
                                        </div>
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
                    <asp:Repeater ID="Repeater1" DataSourceID="odsRotador1"  runat="server">
                        <ItemTemplate>
                         <asp:Label ID="lblIdNumero" runat="server" Text=' <%# Eval("Numero") %>' Visible="false"></asp:Label>
                          <button id=' <%# Eval("Numero") %>' class="header__pag-button header__pag-button--selected carousel__button">
                         <%--<button class='<%# "header__pag-button carousel__button " + Eval("Numero").ToString().Replace("01","selected") %>'>--%>
                              <%# Eval("Numero") %>
                          </button>
                        </ItemTemplate>
                 </asp:Repeater>
                </div>
            </section>
        </header>

        <main class="main">
            
            <div
                    class="background container--flex container--flex-column container--justify-content-center container--align-center container--no-border-radius container--gap-big playlist__container playlist__start"
                >
                           
                   <asp:Repeater ID="Repeater2" DataSourceID="odsSecciones" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
                       <ItemTemplate>
                        <asp:Label ID="lblSeccion" runat="server" Text=' <%# Eval("descripcion") %>' Visible="false"></asp:Label>
                           <asp:Panel class="playlist__content container--flex container--flex-column container--flex-wrap full-width" ID="Panel_normal" runat="server">
                           
                                <h2
                                    class="text--extra-large text--light text--letter-spacing-small"
                                >
                                    <span class="text--bold"><%# Eval("descripcion") %></span>
                                </h2>
      
                                <div
                                    class="container--flex container--align-start full-width container--gap-medium container--justify-content-space-between carousel__container playlist__container--with-arrows"
                                >
                                    <div
                                        class="arrow__container arrow--rotate carousel__arrow--prev"
                                    >
                                        <div class="arrow absolute"></div>
                                        <div class="green-yellow arrow__border"></div>
                                    </div>
                                    <div
                                            class="container--flex container--justify-content-start playlist__movies full-width carousel__list"
                                        >
                                      <asp:Repeater ID="Repeater1"  runat="server">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNro" runat="server" Visible="false" Text='<%# Eval("contenido") %>'></asp:Label>
                                                <a
                                                    href=' <%# "mas_informacion.aspx?ID=" + Eval("codigo") %>'
                                                    class="playlist__movie container--justify-content-center carousel__item"
                                                    >
                                                    <img
                                                        src='<%# Eval("contenido") %>'
                                                        alt="Pelicula"
                                                    /><!--Put the name of the movie in the alt-->
                                                    </a>
                                        </ItemTemplate>
                                        </asp:Repeater>
           
            
                                    </div>
                                    <div class="arrow__container carousel__arrow--next">
                                        <div class="arrow absolute"></div>
                                        <div class="green-yellow arrow__border"></div>
                                    </div>
                                </div>
                            
                               </asp:Panel>
                           


                       </ItemTemplate>
                </asp:Repeater>
                </div>
                
            <div
                class="background background__two container--flex container--flex-column container--justify-content-start container--align-start container--no-border-radius container--gap-big playlist__container"
            >

                    <asp:Repeater ID="Repeater4" DataSourceID="odsSecciones" OnItemDataBound="Repeater4_ItemDataBound" runat="server">
                           <ItemTemplate>
                               <asp:Label ID="lblSeccion" runat="server" Text=' <%# Eval("descripcion") %>' Visible="false"></asp:Label>
                               <asp:Panel class="playlist__content container--flex container--flex-column container--flex-wrap full-width" ID="Panel_nas_vistos" runat="server">
                               
                                        <h2
                                            class="text--extra-large text--light text--letter-spacing-small"
                                        >
                                            <span class="text--bold"><%# Eval("descripcion") %></span>
                                        </h2>
                                        <div
                                            class="container--flex container--align-start full-width container--gap-medium container--justify-content-space-between carousel__container playlist__container--with-arrows"
                                        >
                                            <div
                                                class="arrow__container arrow--rotate carousel__arrow--prev"
                                            >
                                                <div class="arrow absolute"></div>
                                                <div class="green-yellow arrow__border"></div>
                                            </div>
                                            <div
                                                class="container--flex container--justify-content-start playlist__movies playlist__movies--vertical full-width carousel__list"
                                            >
                                    <asp:Repeater ID="Repeater3"  runat="server">
                                        <ItemTemplate>
                                              <a
                                                      href=' <%# "mas_informacion.aspx?ID=" + Eval("codigo") %>'
                                                      class="playlist__movie playlist__movie--second container--flex container--flex-column container--justify-content-center container--align-end container--no-border-radius carousel__item"
                                                  >
                                                      <div class="playlist__number">
                                                          <p class="text--only-stroke text--green">
                                                              <%# Eval("numero") %>
                                                          </p>
                                                      </div>
                                                  <%--<asp:ImageButton ID="ibtnContenidoNormal" ImageUrl='<%# Eval("contenido") %>'  runat="server" />--%>
                                                      <img
                                                          src='<%# Eval("contenido") %>'
                                                          alt="Pelicula" 
                                                      /><!--Put the name of the movie in the alt-->
                                                      <%--<div class="ribbon--under container--orange">
                                                          <p class="text text--bold">
                                                              Recien agregados
                                                          </p>
                                                      </div>--%>
                                                  </a>
                                            </ItemTemplate>
                                     </asp:Repeater>
                                        </div>
                            <div class="arrow__container carousel__arrow--next">
                                <div class="arrow absolute"></div>
                                <div class="green-yellow arrow__border"></div>
                            </div>
                        </div>
                               </asp:Panel>
                               
                           </ItemTemplate>
                    </asp:Repeater>
           



                
                 </div>
        </main>
        <footer class="footer playlist__footer">
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
        <script src="js/header-background-handler.js"></script>
      <script src="js/carousel-header-index.js"></script>
      <script defer src="js/carousel.js"></script>
      <script src="js/open-menu.js"></script>
      <script src="js/open-submenu.js"></script>
      <script src="js/header-movies-responsive.js"></script>
      <script src="js/movie-container-hover.js"></script>

    </form>
</body>
</html>
