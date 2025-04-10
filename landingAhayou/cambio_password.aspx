<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="cambio_password.aspx.cs" Inherits="landingAhayou.cambio_password" %>

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
            <link rel="stylesheet" href="css/header.css" />
            <link rel="stylesheet" href="css/header-options.css" />
            <link rel="stylesheet" href="css/forms.css" />
            <link rel="stylesheet" href="css/vanilla-page.css" />
            <link rel="stylesheet" href="css/default-background.css" />
            <link rel="stylesheet" href="css/containers.css" />
            <link rel="stylesheet" href="css/footer.css" />
            <link rel="stylesheet" href="css/buttons.css" />
            <link rel="stylesheet" href="css/hamburger.css" />
            <link rel="stylesheet" href="css/search-results.css" />

            <link rel="stylesheet" href="css/arrow.css" />
            <link rel="stylesheet" href="css/header-movies.css" />
            <link rel="stylesheet" href="css/hamburger.css" />
            <link rel="stylesheet" href="css/ribbon.css" />
            <link rel="stylesheet" href="css/playlist.css" />
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
 
       <header class="header">
         <nav class="header__nav">
            <a href="home.aspx" class="header__logo">
                <img
                    class="header__logo-img"
                    src="imgs/logos/logo-ahayou.png"
                    alt="Logo Ahayou"
                />
            </a>
               <%-- <div class="header__nav-buttons header__nav-input">
                        <asp:TextBox ID="txtBusqueda" class="header__input" ValidationGroup="busqueda" placeholder="Buscar..." runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Orange" ValidationGroup="busqueda" ControlToValidate="txtBusqueda"></asp:RequiredFieldValidator>
                        <asp:ImageButton ID="btnBusqueda1" class="header__button--search" Height="46px" ImageUrl="~/imgs/icons/search.svg" ValidationGroup="busqueda" OnClick="btnBusqueda_Click" runat="server" />
                </div>--%>
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
                        <asp:LinkButton class="options__button--flex" OnClick="lbtnCuenta_Click" ID="lbtnCuenta" runat="server">
                             <img
                                 src="imgs/icons/administration.svg"
                                 alt="Foto perfil"
                             />
                             <p class="text--small text text--light">
                                 Cuenta
                             </p>

                        </asp:LinkButton>
        
               
                        <a href="cambio_password.aspx" class="options__button--flex">
                            <img
                                src="imgs/flags/spain.png"
                                alt="Foto perfil"
                            />
                            <p class="text--small text text--light">
                                Idioma español
                            </p>
                        </a>
                        <a href="cambio_password_us.aspx" class="options__button--flex">
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
          </header>
        <main class="main main--flex">
            <section
                class="container--flex container--flex-column full-height full-width container--justify-content-center container--align-center"
            >
                <div class="container__wrapper">
                    <h1 class="text text--bold text--left text--extra-large">
                        Cambiar contrase&ntilde;a
                    </h1>
                    <p><asp:Label ID="lblPasswordAnterior" Visible="false" runat="server" Text=""></asp:Label></p>
                    <form class="form" id="form">
                        <p class="text text--light">
                            Proteger tu cuenta con una contrase&ntilde;a
                            exclusiva de al menos 6 caracteres.
                        </p>
                        <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second text--bold"
                            >
                                Email actual
                            </label>
                            <asp:TextBox ID="email" ReadOnly="true" class="form__input container--border-gray" runat="server"></asp:TextBox>
                        </div>
                         <div class="form__input-container">
                                <label
                                    for="email"
                                    class="form__label form__label--second text--bold"
                                >
                                    Password anterior
                                </label>
                                <asp:TextBox ID="txtPassAnt"  class="form__input container--border-gray" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="password"  ControlToValidate="txtPassAnt" runat="server" ErrorMessage="* Campo requerido" ForeColor="Orange"></asp:RequiredFieldValidator>
                            </div>
                        <div class="form__input-container">
                            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Contraseña nueva (6-60 caracteres)" class="form__input container--border-gray" runat="server"></asp:TextBox>
                        </div>
                        <div class="form__input-container">
                            <asp:TextBox ID="txtPassword2" TextMode="Password"  placeholder="Contraseña nueva (6-60 caracteres)" class="form__input container--border-gray" runat="server"></asp:TextBox>
                        </div>
                        <asp:CompareValidator ID="cfvNumeroCelular" runat="server"  ControlToCompare="txtPassword" ValidationGroup="password" ControlToValidate="txtPassword2" Operator="Equal" Type="Integer" Display="Dynamic" ErrorMessage="* Las nuevas contraseñas no coinciden." ></asp:CompareValidator>
                        <p><asp:Label ID="lblAviso" runat="server" Text=""></asp:Label></p>
                        <%--<div
                            class="form__input-container form__input-container--checkbox"
                        >
                            <input
                                type="checkbox"
                                name="remember"
                                id="remember"
                                class="form__input form__checkbox form__checkbox--sky-blue"
                            />
                            <label
                                for="remember"
                                class="form__label form__label--second"
                            >
                                Cerrar sesi&oacute;n en todos los dispositivos
                            </label>
                        </div>--%>
                        <div
                            class="container--flex full-width container--justify-content-start container--align-center"
                        >
                            <asp:Button ID="btnGuardar" class="button button--orange full-width button--border" ValidationGroup="password" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                            <asp:Button ID="btnCancelar" class="button button--green full-width button--border" OnClick="btnCancelar_Click" runat="server" Text="Cancelar" />
                        </div>
                    </form>
                </div>
            </section>
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


        <script src="js/footer-visited-color.js"></script>
    <script src="js/open-menu.js"></script>
    <script src="js/show-validation-alert.js" defer></script>

    </form>
</body>
</html>
