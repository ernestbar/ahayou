<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificar_correo_us.aspx.cs" Inherits="landingAhayou.verificar_correo_us" %>

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
</head>
<body>
    <form id="form1" runat="server">
          <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
          </asp:ObjectDataSource>
          <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_AVATARES" TypeName="landingAhayou.Clases.Avatares">
          </asp:ObjectDataSource>
        <header class="header">
            <nav class="header__nav">
                <a href="home_us.aspx" class="header__logo">
                    <img
                        class="header__logo-img"
                        src="imgs/logos/logo-ahayou.png"
                        alt="Logo Ahayou"
                    />
                </a>
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
            </nav>
        </header>
        <main class="main main--flex">
            <section
                class="container__wrapper container--shiny container--padding-width"
            >
                <span class="text text--light text--center full-width"
                    >STEP 2 of 2</span
                >
                <div
                    class="check check--orange check--border-orange check--small"
                >
                    <svg
                        viewBox="0 0 48 48"
                        xmlns="http://www.w3.org/2000/svg"
                        class="check--shield check--orange"
                    >
                        <defs>
                            <style>
                                .a {
                                    fill: none;
                                    stroke: var(--color-primary);
                                    stroke-linecap: round;
                                    stroke-linejoin: round;
                                }
                            </style>
                        </defs>
                        <path
                            class="a"
                            d="M24,43.5c9.0432-3.1174,15.4885-10.3631,16.5-19.5889a79.36,79.36,0,0,0-.0714-12.0267,2.5414,2.5414,0,0,0-2.4677-2.3663c-4.0911-.126-8.8455-.8077-12.52-4.4273a2.0516,2.0516,0,0,0-2.881,0C18.885,8.71,14.1306,9.3921,10.04,9.5181a2.5414,2.5414,0,0,0-2.4677,2.3663A79.36,79.36,0,0,0,7.5,23.9111C8.5115,33.1369,14.9568,40.3826,24,43.5Z"
                        />
                    </svg>
                </div>
                <h1>Excellent! Now let's check your email.</h1>
                <p class="text text--light text--center full-width">
                    Click on the link we sent to
                    <span class="text--bold"
                        >
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label> </span
                    >
                   to complete the verification.
                </p>
                <p class="text text--light text--center full-width">
                    By verifying your email, you can improve account security and receive important communications from AHAYOU.
                </p>
               
                <asp:Button class="button button--green full-width button--border" ID="Button1" OnClick="Button1_Click" runat="server" Text="Next" />
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
    <script src="js/footer-visited-color.js"></script>
    <script src="js/open-menu.js"></script>
    <script src="js/open-submenu.js"></script>
    <script src="js/show-validation-alert.js" defer></script>
</body>
</html>

