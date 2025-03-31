<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forma_pago.aspx.cs" Inherits="landingAhayou.forma_pago" %>

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
</head>
<body>
    <form id="form1" runat="server">
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
                <div class="header__nav-buttons header__nav-buttons--with-text">
       
                    <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnSuscribete" OnClick="btnSuscribete_Click" runat="server" Text="Suscribete" />
                    <asp:Button class="header__button header__button--text header__button--bg-green" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Iniciar Session" />
                    <asp:Label ID="lblUsuario" Visible="false" runat="server" Text=""></asp:Label>
                </div>
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
            </nav>
        </header>
        <main class="main main--flex">
            <section
                class="container__wrapper container--shiny container--padding-width"
            >
                <span class="text text--light text--center full-width">
                    PASO 4 de 4
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
                <h1>Elige cómo quieres pagar</h1>
                <p class="text text--light text--center full-width">
                    Tu forma de pago está encriptada y puedes cambiarla cuando
                    quieras.
                </p>
                <p class="text text--light text--center full-width">
                    Transacciones seguras y confiables. Cancela fácilmente
                    online.
                </p>
                <div class="full-width">
                    <div
                        class="full-width container--flex container--flex-row container--justify-content-end container--align-center"
                    >
                        <p class="text text--small text--right text-light">Encriptado de extremo a extremo</p>
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
                    <div
                        class="full-width container-common container--flex container--flex-row container--justify-content-space-between container--align-center container--white type-payment__container"
                    >
                        <p class="text text--bold">
                            Tarjetas de cr&eacute;dito o d&eacute;bito
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
</body>
</html>

