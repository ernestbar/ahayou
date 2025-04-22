<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forma_pago_us.aspx.cs" Inherits="landingAhayou.forma_pago_us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <link rel="stylesheet" href="css/alerts.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/type-payment.css" />

         <script src="https://js.stripe.com/v3/"></script>
       <%-- <script src="checkout.js" defer></script>--%>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
            </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
                 </SelectParameters>
             </asp:ObjectDataSource>
            <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
             <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblMenu" runat="server" Visible="false" Text="0"></asp:Label>
          <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
          </asp:ObjectDataSource>
          <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_AVATARES" TypeName="landingAhayou.Clases.Avatares">
          </asp:ObjectDataSource>
        <header class="header">
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
                                     Account
                                 </p>

                            </asp:LinkButton>
        
           
                            <a href="forma_pago.aspx" class="options__button--flex">
                                <img
                                    src="imgs/flags/spain.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Spanish
                                </p>
                            </a>
                            <a href="forma_pago_us.aspx" class="options__button--flex">
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
        </header>
        <main class="main main--flex">
            <asp:Label runat="server" id="Label1"></asp:Label>
             
           
            <section
                class="container__wrapper container--shiny container--padding-width"
            >
                <span class="text text--light text--center full-width">
                    STEP 4 of 4
                </span>
                <div class="check check--border-orange">
                    <svg
                        viewBox="0 0 64 64"
                        xmlns="http://www.w3.org/2000/svg"
                        fill="none"
                        class="check--orange"
                    >
                        <rect x="12" y="28" width="40" height="28" rx="4" />
                        <line x1="32" y1="48" x2="32" y2="36" />
                        <path d="M20 28v-8a12 12 0 0 1 24 0v8" />
                    </svg>
                </div>
                <h1>Choose how you want to pay</h1>
                <p class="text text--light text--center full-width">
                   Your payment method is encrypted and you can change it whenever you want.
                </p>
                <p class="text text--light text--center full-width">
                    Secure and reliable transactions. Cancel easily online.
                </p>
                <div class="full-width">
                    <div
                        class="full-width container--flex container--flex-row container--justify-content-end container--align-center"
                    >
                        <p class="text text--small text--right text-light">End-to-end encryption</p>
                        <svg
                            viewBox="0 0 64 64"
                            xmlns="http://www.w3.org/2000/svg"
                            fill="none"
                            class="icon--little check--white"
                        >
                            <rect x="12" y="28" width="40" height="28" rx="4" />
                            <line x1="32" y1="48" x2="32" y2="36" />
                            <path d="M20 28v-8a12 12 0 0 1 24 0v8" />
                        </svg>
                    </div>
                    <%--<div id="checkout">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                      </div>--%>
                    <iframe runat="server" id="ifrmPago" frameborder="0" style="width:100%;height:100%" ></iframe>
                    <div
                        class="full-width container-common container--flex container--flex-row container--justify-content-space-between container--align-center container--white type-payment__container"
                    >
                        <p class="text text--bold">
                            Credit or debit cards
                        </p>
                        <div
                            class="container--flex container--flex-row container--align-center"
                        >
                            <img
                                src="/imgs/type-payment/american express.png"
                                alt="American Express"
                                class="type-payment__image"
                            />
                            <img
                                src="/imgs/type-payment/mastercard.png"
                                alt="MasterCard"
                                class="type-payment__image"
                            />
                            <img
                                src="/imgs/type-payment/visa.png"
                                alt="VISA"
                                class="type-payment__image"
                            />
                            <div
                                class="arrow green-yellow arrow__container--small"
                            ></div>
                        </div>
                    </div>
                </div>
            </section>
        </main>
        
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
                             FAQ
                         </a>
                         <a href="contenidos_us.aspx?t=privacidad" target="_blank">Privacy</a>
                     </div>
                     <div class="footer__list-item">
                         <a href="centro_ayuda_us.aspx" target="_blank">Centro de Ayuda</a>
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
    <script src="js/footer-visited-color.js"></script>
        <script src="js/open-menu.js"></script>
        <script src="js/show-validation-alert.js" defer></script>

     <script src="js/open-submenu.js"></script>
     
   
</body>
</html>
