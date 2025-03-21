<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reset_password.aspx.cs" Inherits="landingAhayou.reset_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>Ahayou</title>

        <link
            rel="icon"
            href="/imgs/logos/logo-ahayou-2.png"
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
        <link rel="stylesheet" href="css/containers.css" />
        <link rel="stylesheet" href="css/check.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/arrow.css" />
        <link rel="stylesheet" href="css/settings.css" />
        <link rel="stylesheet" href="css/plans-selection.css" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
 </asp:ObjectDataSource>
         <header class="header">
                    <nav class="header__nav">
                        <a href="home.aspx" class="header__logo">
                            <img
                                class="header__logo-img"
                                src="imgs/logos/logo-ahayou.png"
                                style="background-color:black"
                                alt="Logo Ahayou"
                            />
                        </a>
                        <div class="header__nav-buttons">
                             <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnSuscribete" OnClick="btnSuscribete_Click" runat="server" Text="Suscribete" />
                                <asp:Button class="header__button header__button--text header__button--bg-green" ID="btnInicia" OnClick="btnInicia_Click" runat="server" Text="Iniciar Session" />
                        </div>
                        <div class="header__nav-buttons">
                            <div>
                                <%--<button
                                    class="header__button header__button--icon"
                                ></button>--%>
                             <%--   <button
                                    class="header__button header__button--icon"
                                ></button>--%>
                                <input class="header__button header__button--icon" type="button" onclick="location.href='home.aspx';" />
                                <input class="header__button header__button--icon" type="button" onclick="location.href='home_us.aspx';" />
                                <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
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
                             </div>
                         </div>
                    </nav>
                </header>

        <main class="main main--flex">
            <section
                class="container--flex container--flex-column full-height full-width container--justify-content-center container--align-center"
            >
                <div class="container__wrapper">
                    <h1 class="text text--bold text--left text--extra-large">
                        Reestablecer contrase&ntilde;a
                    </h1>
                    <div class="container--flex container--flex-column container--gap-medium text text--light">
                        <p>Hola, <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></p>
                        <p>
                            Restablezcamos tu contrase&ntilde;a, revisa los accesos
                            recientes a la cuenta en busca de actividad inusual.
                        </p>
                        <p>
                            Si necesitas asistencia, visita el centro de ayuda o
                            cont&aacute;ctanos.
                        </p>
                        <p>El equipo de AHAYOU</p>
                        <p><asp:Label ID="lblAviso" runat="server" Text=""></asp:Label></p>
                    </div>
                    <asp:Button class="button button--orange full-width button--border" OnClick="btnReset_Click" ID="btnReset" runat="server" Text="Resetear contraseña" />
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
