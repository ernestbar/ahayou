<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagar_stripe.aspx.cs" Inherits="landingAhayou.pagar_stripe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/default-background.css" />
        <link rel="stylesheet" href="css/containers.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/plans-selection.css" />
        <link rel="stylesheet" href="css/ribbon.css" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
            </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
                 </SelectParameters>
             </asp:ObjectDataSource>
            <asp:Label ID="Label1" runat="server" Visible="false" Text="BO"></asp:Label>
             <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblMenu" runat="server" Visible="false" Text="0"></asp:Label>
          <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
          </asp:ObjectDataSource>
           <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLANES_STR" TypeName="landingAhayou.Clases.Contenidos">
             <SelectParameters>
                 <asp:ControlParameter ControlID="lblMundo" Name="PV_MUNDO" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
        <header class="header">
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
        </header>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        
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
    </form>
    <script src="js/footer-visited-color.js"></script>
        <script src="js/open-menu.js"></script>
        <script src="js/show-validation-alert.js" defer></script>

        <script src="js/open-submenu.js"></script>
</body>
</html>
