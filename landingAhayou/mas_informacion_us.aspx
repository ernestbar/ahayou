<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="mas_informacion_us.aspx.cs" Inherits="landingAhayou.mas_informacion_us" %>

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
        <link rel="stylesheet" href="css/show-list.css" />
    <script src="https://cdn.flowplayer.com/releases/native/3/stable/default/flowplayer.js"></script>
</head>
 <body class="background__black">
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
     <asp:ObjectDataSource ID="odsSoloTemporadas" runat="server" SelectMethod="PR_STR_GET_LISTADO_TEMPORADAS" TypeName="landingAhayou.Clases.Contenidos">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblCodContenidoStr" Name="PV_COD_CONTENIDO_STR" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTemporadas" runat="server" SelectMethod="PR_STR_GET_CONTENIDO_POR_TEMPORADAS" TypeName="landingAhayou.Clases.Contenidos">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblCodContenidoStr" Name="PV_COD_CONTENIDO_STR" Type="String" />
        <asp:ControlParameter ControlID="ddlSoloTemporadas" Name="PV_TEMPORADA" Type="String" />
        
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
     <header
            class="header header--main more-information__header"
            id="header__movies"
        >
        <nav class="header__nav">
            <a href="cartelera.aspx" class="header__logo">
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
                                  Suscribe
                              </button>
                              <button
                                  class="header__button header__button--text header__button--bg-green"
                               type="button" onclick="location.href='login.aspx';">
                                  Login
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
         
                             <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Spanish" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="English" />
                            <input class="options__button" type="button" onclick="location.href='suscribete_us.aspx';" value="Suscribe" />
                            <input class="options__button" type="button" onclick="location.href='login_us.aspx';" value="Login" />
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
                                 Account
                             </p>

                        </asp:LinkButton>
        
           
                        <a href="cartelera.aspx" class="options__button--flex">
                            <img
                                src="imgs/flags/spain.png"
                                alt="Foto perfil"
                            />
                            <p class="text--small text text--light">
                                Spanish
                            </p>
                        </a>
                        <a href="cartelera_us.aspx" class="options__button--flex">
                            <img
                                src="imgs/flags/eeuu.png"
                                alt="Foto perfil"
                            />
                            <p class="text--small text text--light">
                                English
                            </p>
                        </a>
                    </div>
    
                    <asp:Repeater ID="Repeater8" DataSourceID="odsMenus" runat="server">
                     <ItemTemplate>
                         <asp:Button ID="btnMenu" class="options__button--last text--light text--center text--small" CommandArgument='<%# Eval("cod_formato_contenido") %>' OnClick="btnMenu_Click" runat="server" Text='<%# Eval("formato_contenido_ingles") %>' />
                     </ItemTemplate>
                 </asp:Repeater>
                    <asp:Button class="options__button--last text--light text--center text--small" OnClick="btnCerrar_Click" ID="btnCerrar" runat="server" Text="Logout" />
    
                </div>
                        
            </asp:Panel>
        </nav>
      <asp:Repeater ID="Repeater1" DataSourceID="odsContenidoInd" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
            <ItemTemplate>
                     <section
                    class="more-information__header-content"
                    id="itemWithBackground"
                    data-bg='<%# Eval("foto_horizontal") %>'
                >
                         <asp:Label ID="lblVerifica" runat="server" Visible="false" Text='<%# Eval("temporadas_episodios")+"|"+Eval("cod_estado_contenido")%>'></asp:Label>
                    <div class="more-information__header-data">
                        <span class="movie__format"><%# Eval("formato_contenido") %></span>
                        <img
                            src='<%# Eval("titulo") %>'
                            alt=""
                            class="movie__image"
                        />
                        <div class="movie__buttons">
                             <asp:LinkButton ID="lbtnReproducir" CommandArgument='<%# Eval("cod_contenido_str") %>' OnClick="lbtnReproducir_Click" class="movie__button movie__button--white" runat="server">
                                  <img
                                      src="imgs/icons/play.svg"
                                      alt="Icono reproducir"
                                  />
                                  <p>Play</p>
                             </asp:LinkButton>
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnFavoritos_Click" Width="100" ImageUrl="~/imgs/icons/add.svg" ID="ibtnFavoritos" runat="server" />
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnLike_Click" Width="100" ImageUrl="~/imgs/icons/like-favorites.svg" ID="ibtnLike" runat="server" />
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnNoFavoritos_Click" Width="100" ImageUrl="~/imgs/icons/remove.svg" ID="ibtnNoFavoritos" runat="server" />
                            <asp:ImageButton class="movie__button movie__button--only-icon movie__button--black" OnClick="ibtnDislike_Click" Width="100" ImageUrl="~/imgs/icons/dislike-favorites.svg" ID="ibtnDislike" runat="server" />
                        </div>
                        <span class="movie__detail-1"><%# Eval("gestion") %> - <%# Eval("tipo_audio") %></span>
                       <%-- <span class="movie__detail-2">N. 1 en TV Hoy</span>--%>
                        <p class="movie__description">
                            <%# Eval("sinopsis_ingles") %>
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
                                    <span class="text--bold">Producer:</span
                                    >&nbsp;<%# Eval("productora") %>
                                </p>
                            </li>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Guest Cast:</span
                                    >&nbsp;<%# Eval("reparto") %>
                                </p>
                            </li>
                            <li>
                                <p class="text text--light">
                                    <span class="text--bold">Idiom:</span
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
                <asp:Panel ID="Panel_temporadas" class="container--flex container--flex-column container--gap-medium more-information__section" runat="server">
                    <div
                            class="container--flex container--flex-row container--align-center container--justify-content-space-between"
                        >
                     <h2 class="text--large">
                    <asp:Label ID="lblTituloTemporadas" runat="server" Text="Seasons"></asp:Label></h2>
                    <%--<div>
                    <h2 class="text--large">Episodios</h2>
                    <p class="text">
                        Temporada 1&#58;&nbsp;
                        <span class="text--bold"
                            >3&#43;&nbsp;Programas</span
                        >
                    </p>
                </div>--%>
                        
                <div>
                    <asp:DropDownList ID="ddlSoloTemporadas" class="season__selector text text--bold" DataSourceID="odsSoloTemporadas" DataTextField="temporada" DataValueField="cod_temporada" runat="server"></asp:DropDownList>
                    <%--<select class="season__selector text text--bold">
                        <option value="season_1" selected>
                            Temporada 1
                        </option>
                        <option value="season_2">Temporada 2</option>
                        <option value="season_3">Temporada 3</option>
                        <option value="season_4">Temporada 4</option>
                        <option value="season_5">Temporada 5</option>
                    </select>--%>
                    </div>
                </div>
                    <ol class="episodes__list show__list">
                <asp:Repeater ID="Repeater4" DataSourceID="odsTemporadas"  runat="server">
                    <ItemTemplate>
                        <li class="episode show__element">
                           <div class="episode__iframe iframe__video">
                               <%# Eval("contenido") %>
                           </div>
                           
                           
                            <div class="episode__info">
                                <div class="episode__metadata text">
                                    <h3><%# Eval("story_line_ingles") %></h3>
                                    <span>56 min</span>
                                </div>
                                <p class="episode__synopsis text">
                                    <%# Eval("sinopsis_ingles") %>
                                </p>
                            </div>
                            <asp:LinkButton ID="lbtnReproducirT" CommandArgument='<%# Eval("contenido_playlist")+"|"+Eval("cod_contenido_str")+"|"+Eval("contenido") %>' OnClick="lbtnReproducirT_Click" class="movie__button movie__button--white" runat="server">
                                 <img
                                     src="imgs/icons/play.svg"
                                     alt="Icono reproducir"
                                 />
                                 <p>Play</p>
                            </asp:LinkButton>
                        </li>
            
                    </ItemTemplate>
                </asp:Repeater>
                        </ol>
                        <div class="show-more__container">
                            <button class="show-more__button" type="button">
                                <img src="imgs/icons/arrow-down.svg" alt="Ver mas" />
                            </button>
                        </div>
            </asp:Panel>
            
          
                    <asp:Panel ID="Panel_trailers" class="container--flex container--flex-column container--gap-medium more-information__section" runat="server">
                        
                              <h2 class="text--large">
                                  <asp:Label ID="lblTituloTrailers" runat="server" Text="Trailers"></asp:Label></h2>
                              <div
                                  class="container--flex container--flex-row container--justify-content-center container--flex-wrap"
                              >
                        <asp:Repeater ID="Repeater2" DataSourceID="odsTrailers" runat="server">
                            <ItemTemplate>
                                <article
                                        class="container--flex container--flex-column full-width more-information__video"
                                    >     
                                    <div style="width:350px">
                                        <%# Eval("nombre_contenido_str") %>
                                    </div>
                                     
                                    <%--<div style="width:600px;height:300px" class="container--flex container--flex-column full-width more-information__video">
                                    <%# Eval("contenido") %>
                                    </div>--%>
                                    <%# Eval("contenido") %>
                                    <%--<iframe
                                        src='<%# Eval("contenido_mobile") %>'
                                        title='<%# Eval("nombre_contenido_str") %>'
                                        frameborder="0"
                                        allowfullscreen
                                    ></iframe>--%>
                                    <%--<p class="text text--center text--light">
                                       
                                    </p>--%>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
                    </asp:Panel>
                   
                    
                
             <asp:Repeater ID="Repeater3" DataSourceID="odsContenidoInd" runat="server">
                <ItemTemplate>
                    <section
                        class="container--flex container--flex-column container--gap-medium more-information__section"
                    >
                        <h2 class="text--large text--light">
                           About of <span class="text--bold"><%# Eval("nombre_contenido") %></span>
                        </h2>
                        <p class="text text--light">
                            <%# Eval("story_line_ingles") %>
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
                                 FAQ
                             </a>
                             <a href="contenidos_us.aspx?t=privacidad" target="_blank">Privacy</a>
                         </div>
                         <div class="footer__list-item">
                             <a href="centro_ayuda_us.aspx" target="_blank">Help center</a>
                              <a href="contenidos_us.aspx?t=avisos legales" target="_blank">Legal notices</a>
                         </div>
                         <div class="footer__list-item">
                             <a href="contenidos_us.aspx?t=terminos de uso" target="_blank">Terms of use</a>
                             <a href="contacto_us.aspx" target="_blank">Contact</a>
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
        <script src="js/show-list.js"></script>
        <script src="js/open-menu.js"></script>
        <script src="js/open-submenu.js"></script>
        <script src="js/header-movies-responsive.js"></script>
        <script src="js/movie-container-hover.js"></script>
        <script src="js/stop-autoplay.js"></script>
    

    
</body>
</html>
