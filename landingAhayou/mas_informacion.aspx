<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mas_informacion.aspx.cs" EnableEventValidation="false" Inherits="landingAhayou.mas_informacion" %>

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
    <link rel="stylesheet" href="css/more-information.css" />
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
    <asp:ObjectDataSource ID="odsContenidoInd" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_STR_IND" TypeName="landingAhayou.Clases.Contenidos">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblCodContenidoStr" Name="PV_COD_CONTENIDO_STR" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTrailers" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_TRAILER" TypeName="landingAhayou.Clases.Contenidos">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblCodContenidoStr" Name="PV_COD_CONTENIDO_STR" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTemporadas" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_TEMPORADAS" TypeName="landingAhayou.Clases.Contenidos">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblCodContenidoStr" Name="PV_COD_CONTENIDO_STR" Type="String" />
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
        <asp:Label ID="lblCodContenidoStr" runat="server" Visible="false" Text=""></asp:Label>
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
            <div class="header__nav-buttons">
                
                <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnSuscribete" OnClick="btnSuscribete_Click" runat="server" Text="Suscribete" />
                <asp:Button class="header__button header__button--text header__button--bg-green" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Iniciar Session" />
                <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
            </div>
            <div
                class="header__nav-buttons submenu__container options__container--second"
            >
                <button
                    class="header__button header__button--with-img submenu__button"
                >
                    <asp:Image class="header__button header__button--with-img submenu__button" ID="imgPerfil" runat="server"  />
                    <%--<img src="imgs/avatars/Avatar 12.png" alt="Perfil" />--%>
                </button>
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
                    <button
                        class="options__button--last text--light text--center text--small"
                    >
                        Cerrar sesi&oacute;n
                    </button>
                </div>
            </div>
        </nav>
      <asp:Repeater ID="Repeater1" DataSourceID="odsContenidoInd" runat="server">
            <ItemTemplate>
                     <section
                    class="more-information__header-content"
                    id="itemWithBackground"
                    data-bg='<%# Eval("foto_horizontal") %>'
                >
                    <div class="more-information__header-data">
                        <span class="movie__format"><%# Eval("formato_contenido") %></span>
                        <img
                            src='<%# Eval("titulo") %>'
                            alt=""
                            class="movie__image"
                        />
                        <div class="movie__buttons">
                            <a href="#" class="movie__button movie__button--white">
                                <img
                                    src="imgs/icons/play.svg"
                                    alt="Icono reproducir"
                                />
                                <p>Reproducir</p>
                            </a>
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnFavoritos_Click" ImageUrl="imgs/icons/add.svg" ID="ibtnFavoritos" runat="server" />
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnLike_Click" ImageUrl="imgs/icons/like-favorites.svg" ID="ibtnLike" runat="server" />
                            
                        </div>
                        <span class="movie__detail-1"><%# Eval("gestion") %> - <%# Eval("tipo_audio") %></span>
                       <%-- <span class="movie__detail-2">N. 1 en TV Hoy</span>--%>
                        <p class="movie__description">
                            <%# Eval("sinopsis") %>
                        </p>
                        <span class="movie__gender"><%# Eval("genero") %></span>
                    </div>
                    <div class="more-information__header-data">
                        <ul>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Director:</span
                                    >&nbsp;<%# Eval("director") %>
                                </p>
                            </li>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Productora:</span
                                    >&nbsp;<%# Eval("productora") %>
                                </p>
                            </li>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Reparto Invitado:</span
                                    >&nbsp;<%# Eval("reparto") %>
                                </p>
                            </li>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Idioma:</span
                                    >&nbsp;<%# Eval("idioma_original") %>
                                </p>
                            </li>
                        </ul>
                    </div>
                </section>
            </ItemTemplate>
        </asp:Repeater>
         
</header>
           
        <main
            class="main container--flex container--flex-column container--gap-big more-information__main"
        >
            <section
                class="container--flex container--flex-column container--gap-medium more-information__section"
            >
                <h2 class="text--large">
                    <asp:Label ID="lblTituloTrailers" runat="server" Text="Trailers"></asp:Label></h2>
                <div
                    class="container--flex container--flex-row container--justify-content-center container--flex-wrap"
                >
                    <asp:Panel ID="Panel_trailers" class="container--flex container--flex-row container--justify-content-center container--flex-wrap" runat="server">
                        <asp:Repeater ID="Repeater2" DataSourceID="odsTrailers" runat="server">
                            <ItemTemplate>
                                <article
                                    class="container--flex container--flex-column full-width more-information__video"
                                >
                                    <%# Eval("contenido") %>
                                    <%--<iframe
                                        src='<%# Eval("contenido") %>'
                                        title='<%# Eval("nombre_contenido_str") %>'
                                        frameborder="0"
                                        allowfullscreen
                                    ></iframe>--%>
                                    <p class="text text--center text--light">
                                        <%# Eval("nombre_contenido_str") %>
                                    </p>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <h2 class="text--large">
                     <asp:Label ID="lblTituloTemporadas" runat="server" Text="Temporadas"></asp:Label></h2>
                    <asp:Panel ID="Panel_temporadas" class="container--flex container--flex-row container--justify-content-center container--flex-wrap" runat="server">
                    <asp:Repeater ID="Repeater4" DataSourceID="odsTemporadas" runat="server">
                        <ItemTemplate>
                            <article
                                class="container--flex container--flex-column full-width more-information__video"
                            >
                                <%# Eval("contenido") %>
                                <%--<iframe
                                    src='<%# Eval("contenido") %>'
                                    title='<%# Eval("nombre_contenido_str") %>'
                                    frameborder="0"
                                    allowfullscreen
                                ></iframe>--%>
                                <p class="text text--center text--light">
                                    <%# Eval("story_line") %>
                                </p>
                                  <p class="text text--center text--light">
                                      <%# Eval("sinopsis") %>
                                  </p>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
                
                </div>
            </section>
             <asp:Repeater ID="Repeater3" DataSourceID="odsContenidoInd" runat="server">
                <ItemTemplate>
                    <section
                        class="container--flex container--flex-column container--gap-medium more-information__section"
                    >
                        <h2 class="text--large text--light">
                            Acerca de&nbsp;<span class="text--bold"><%# Eval("nombre_contenido") %></span>
                        </h2>
                        <p class="text text--light">
                            <%# Eval("story_line") %>
                        </p>
                    </section>
               </ItemTemplate>
            </asp:Repeater>
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
    </form>
    <script src="js/show-one-bg.js"></script>
    <script src="js/open-menu.js"></script>
    <script src="js/open-submenu.js"></script>
    <script src="js/header-movies-responsive.js"></script>
    <script src="js/movie-container-hover.js"></script>
</body>
</html>
