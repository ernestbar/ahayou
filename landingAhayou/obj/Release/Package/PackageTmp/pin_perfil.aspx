<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="pin_perfil.aspx.cs" Inherits="landingAhayou.pin_perfil" %>

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
    <link rel="stylesheet" href="css/pin.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnIngresar">
     <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
     </asp:ObjectDataSource>
     <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
         <SelectParameters>
             <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
         </SelectParameters>
     </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
</asp:ObjectDataSource>
     <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
     <asp:Label ID="lblPin" runat="server" Visible="false" Text=""></asp:Label>
     <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
     <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
     <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
 
   <header class="header">
     <nav class="header__nav">
         <a href="pin_perfil.aspx" class="header__logo">
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
        <%-- <div class="form__input-container form__input-container--main form__input-container--no-gap">
             <asp:TextBox ID="txtBuscqueda" Width="300" Height="30" class="form__input form__input--dark" placeholder="Ingresa tu busqueda" runat="server"></asp:TextBox>
             <asp:Button ID="btnBusqueda" Height="30" Font-Size="Small" class="button button--orange button--border" OnClick="btnBusqueda_Click"  runat="server" Text="Buscar" />
     
         </div>--%>
         
         
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
                              <asp:LinkButton class="options__button--flex" ID="lbtnPerfiles" CommandArgument='<%# Eval("cod_perfil_suscriptor") + "|"+Eval("pin")  %>' OnClick="lbtnPerfiles_Click" runat="server">
                                  <img
                                      src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                      alt="Foto perfil"
                                  />
                                  <p class="text--small text--light"><%# Eval("nombre_perfil") %></p>

                             </asp:LinkButton>
                              
                         </ItemTemplate>
                     </asp:Repeater>

                    <asp:Label ID="lblNusuario" class="text--small text text--light" ForeColor="Orange" runat="server" Text=""></asp:Label>
                         <asp:LinkButton class="options__button--flex"  ID="lbtnCuenta" runat="server">
                             <img
                                 src="imgs/icons/administration.svg"
                                 alt="Foto perfil"
                             />
                             <p class="text--small text text--light">
                                 Cuenta
                             </p>

                        </asp:LinkButton>
        
   
                        <a href="catelera.aspx" class="options__button--flex">
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

        <main class="main main--flex">
    <section class="container__wrapper">
        <form
            class="form container--shiny container--padding-width"
            id="form"
        >
            <span class="text text--light text--center"
                >El bloqueo de perfil est&aacute; activado.</span
            >
            <h1>Ingresa tu PIN para acceder a este perfil</h1>

            <div class="pin__inputs">
                <asp:TextBox class="form__input form__input--dark pin__input" TextMode="Number" autocomplete="off" maxlength="1" ID="TextBox1" required runat="server"></asp:TextBox>
                <asp:TextBox class="form__input form__input--dark pin__input" TextMode="Number" autocomplete="off" maxlength="1" ID="TextBox2" required runat="server"></asp:TextBox>
                <asp:TextBox class="form__input form__input--dark pin__input" TextMode="Number" autocomplete="off" maxlength="1" ID="TextBox3" required runat="server"></asp:TextBox>
                <asp:TextBox class="form__input form__input--dark pin__input" TextMode="Number" autocomplete="off" maxlength="1" ID="TextBox4" required runat="server"></asp:TextBox>
                
            </div>
            <p class="text text--red">
                Tu pin debe tener 4 n&uacute;meros.
            </p>
            <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnIngresar" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" />
            <asp:LinkButton class="form__link" ID="lbtnResetPin" OnClientClick="return confirm('Estas seguro de restear tu PIN???')" OnClick="lbtnResetPin_Click" runat="server">¿Olvidaste tu pin? <br /> Presiona aqui y te enviaremos a tu correo un nuevo PIN.</asp:LinkButton>
            
        </form>
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

    </form>
     <script src="js/pin.js"></script>
     <script src="js/footer-visited-color.js"></script>
    <script src="js/open-menu.js"></script>
    <script src="js/open-submenu.js"></script>
</body>
</html>
