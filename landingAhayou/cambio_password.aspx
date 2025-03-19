<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambio_password.aspx.cs" Inherits="WebAhayouAdmin.cambio_password" %>

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
        <link rel="stylesheet" href="css/common/main.css" />
        <link rel="stylesheet" href="css/header/header.css" />
        <link rel="stylesheet" href="css/header/header-options.css" />
        <link rel="stylesheet" href="css/common/vanilla-page.css" />
        <link rel="stylesheet" href="css/common/containers.css" />
        <link rel="stylesheet" href="css/common/check.css" />
        <link rel="stylesheet" href="css/common/footer.css" />
        <link rel="stylesheet" href="css/common/buttons.css" />
        <link rel="stylesheet" href="css/common/hamburger.css" />
        <link rel="stylesheet" href="css/common/arrow.css" />
        <link rel="stylesheet" href="css/forms/forms.css" />
        <link rel="stylesheet" href="css/settings.css" />
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
                 <div class="header__nav-buttons">
                     <button
                         class="header__button header__button--text header__button--bg-orange"
                     >
                         Suscr&iacute;bete
                     </button>
   
                     <button
                         class="header__button header__button--text header__button--bg-green"
                     >
                         Iniciar Sesi&oacute;n
                     </button>
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
                        Cambiar contrase&ntilde;a
                    </h1>
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
                            <input
                                type="email"
                                name="email"
                                id="email"
                                minlength="6"
                                maxlength="320"
                                autocomplete="off"
                                class="form__input container--border-gray"
                            />
                        </div>
                        <div class="form__input-container">
                            <input
                                type="password"
                                name="password"
                                id="password"
                                autocomplete="off"
                                class="form__input container--border-gray"
                                placeholder="Contraseña nueva (6-60 caracteres)"
                            />
                        </div>
                        <div class="form__input-container">
                            <input
                                type="password"
                                name="password"
                                id="password"
                                autocomplete="off"
                                class="form__input container--border-gray"
                                placeholder="Reescribe la contraseña nueva"
                            />
                        </div>
                        <div
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
                        </div>
                        <div
                            class="container--flex full-width container--justify-content-start container--align-center"
                        >
                            <input
                                type="submit"
                                value="Guardar"
                                class="button button--sky-blue full-width button--border"
                            />
                            <input
                                type="reset"
                                value="Cancelar"
                                class="button button--gray full-width button--border"
                            />
                        </div>
                    </form>
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


        <script src="js/footer-visited-color.js"></script>
    <script src="js/open-menu.js"></script>
    <script src="js/show-validation-alert.js" defer></script>

    </form>
</body>
</html>
