<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="suscribete.aspx.cs" Inherits="landingAhayou.suscribete" %>

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
        <link rel="stylesheet" href="css/common/main.css" />
        <link rel="stylesheet" href="css/header/header.css" />
        <link rel="stylesheet" href="css/header/header-options.css" />
        <link rel="stylesheet" href="css/forms/forms.css" />
        <link rel="stylesheet" href="css/common/vanilla-page.css" />
        <link rel="stylesheet" href="css/common/default-background.css" />
        <link rel="stylesheet" href="css/common/containers.css" />
        <link rel="stylesheet" href="css/login.css" />
        <link rel="stylesheet" href="css/common/alerts.css" />
        <link rel="stylesheet" href="css/common/footer.css" />
        <link rel="stylesheet" href="css/common/buttons.css" />
        <link rel="stylesheet" href="css/common/hamburger.css" />
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
                         <asp:Button class="header__button header__button--text header__button--bg-orange" ID="btnSuscribete" OnClick="btnSuscribete_Click" runat="server" Text="Suscribete" />
                        <asp:Button class="header__button header__button--text header__button--bg-green" ID="Button1" OnClick="btnLogin_Click" runat="server" Text="Iniciar Session" />
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
                class="container__wrapper container--shiny container--padding-width"
            >
                <img
                    src="/imgs/etc/electronics.png"
                    alt="Imagen computadoras"
                    class="container__wrapper-image"
                />
                <span class="text text--light text--center full-width"
                    >PASO 1 de 4</span
                >
                <h1>Completa la configuraci&oacute;n de tu cuenta</h1>
                <p class="text text--center text--light">
                    AHAYOU está personalizado para ti.
                </p>
                <p class="text text--center text--light">
                    Crea una contraseña para comenzar a ver AHAYOU
                </p>
                    <div class="alert container--green">
                        <p class="alert__text alert__text--center">
                            <span class="alert__text--bold"
                                >Contraseña incorrecta</span
                            >
                            para
                            <span class="alert__text--bold"
                                >gustavo.zalles.arrieta@gmail.com</span
                            >
                            Puedes usar un código de inicio de sesión, restablecer
                            tu contraseña o reintentarlo.
                        </p>
                    </div>
                    <form class="form container--shiny container--padding-width" id="form">
                        <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second"
                            >
                                Email
                            </label>
                            <asp:TextBox class="form__input form__input--dark" ID="email" runat="server"></asp:TextBox>
                        </div>
                        <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second"
                            >
                                Celular
                            </label>
                            <asp:TextBox class="form__input form__input--dark" ID="celular" runat="server"></asp:TextBox>
                        </div>
                        <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second"
                            >
                                Nombre completo
                            </label>
                            <asp:TextBox class="form__input form__input--dark" ID="nombre" runat="server"></asp:TextBox>
                        </div>
                        <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second"
                            >
                                Codigo auxiliar
                            </label>
                            <asp:TextBox class="form__input form__input--dark" ID="codigo_aux" runat="server"></asp:TextBox>
                        </div>
                        <div class="form__input-container">
                            <label
                                for="password"
                                class="form__label form__label--second"
                            >
                                Contrase&ntilde;a
                            </label>
                             <asp:TextBox class="form__input form__input--dark" TextMode="Password" ID="password" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button class="button button--orange full-width button--border" OnClick="btnSiguiente_Click" ID="btnSiguiente" runat="server" Text="Siguiente" />
        
                    </form>
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
</body>
</html>
