<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="login_us.aspx.cs" Inherits="landingAhayou.login_us" %>

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
        <link rel="stylesheet" href="css/login.css" />
        <link rel="stylesheet" href="css/alerts.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnLogin">
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
                            type="button" onclick="location.href='suscribete_us.aspx';">
                              Suscribe
                          </button>
                          <button
                              class="header__button header__button--text header__button--bg-green"
                           type="button" onclick="location.href='login_us.aspx';">
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
                    <section class="container__wrapper">
                        <h1>Login</h1>
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
                                    Enter your email
                                </label>
                                <%--<input
                                    type="email"
                                    name="email"
                                    id="email"
                                    minlength="6"
                                    maxlength="320"
                                    autocomplete="off"
                                    class="form__input form__input--dark"
                                />--%>
                                <asp:TextBox class="form__input form__input--dark" ID="email" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Proporcione un email" ForeColor="Orange" ControlToValidate="email"></asp:RequiredFieldValidator>
                            <div class="form__input-container">
                                
                                <label
                                    for="password"
                                    class="form__label form__label--second"
                                >
                                    
                                    Password
                                </label>
                                <%--<input
                                    type="password"
                                    name="password"
                                    id="password"
                                    autocomplete="off"
                                    class="form__input form__input--dark"
                                />--%>
                                 <asp:TextBox class="form__input form__input--dark" TextMode="Password" ID="password" runat="server"></asp:TextBox>
                                
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="* Provide a password" ForeColor="Orange" ControlToValidate="password"></asp:RequiredFieldValidator>
                            <%--<input
                                type="submit"
                                value="Suscríbete"
                                class="button button--orange full-width button--border"
                            />--%>
                            <asp:Button class="button button--orange full-width button--border" OnClick="btnLogin_Click" ID="btnLogin" runat="server" Text="Login" />
                            <p>o</p>
                            <div class="form__input-container">
                                <label
                                    for="code"
                                    class="form__label form__label--second form__label--center form__label--bold"
                                >
                                    Use login code
                                </label>
                                <input
                                    type="text"
                                    name="code"
                                    id="code"
                                    autocomplete="off"
                                    class="form__input form__input--dark"
                                    maxlength="50"
                                />
                            </div>
                            <asp:LinkButton class="form__link" OnClick="lbtnReset_Click" ID="lbtnReset" runat="server">Forgot your password?</asp:LinkButton>
                            
                            <div
                                class="form__input-container form__input-container--checkbox"
                            >
                               <asp:CheckBox ID="cbRecuerdame" class="form__input" Font-Size="X-Large" Text="Remind me of this device" runat="server" />
                               <%-- <input
                                    type="checkbox"
                                    name="remember"
                                    id="remember"
                                    class="form__input form__checkbox"
                                />
                                 --%>
                                <%--<label
                                    for="remember"
                                    class="form__label form__label--second"
                                >
                                    Recordarme este dispositivo
                                </label>--%>
                            </div>
                        </form>
                        <p class="login-footer__text">
                            First time at Ahayou?
                            <asp:LinkButton class="login-footer__link" OnClick="lbtnSuscribete_Click"  CausesValidation="false" ID="lbtnSuscribete" runat="server">Subscribe now.</asp:LinkButton>
                        </p>
                        <p class="text text--light full-width">
                            This page is protected by Google reCAPTCHA to verify that you are not a robot.<br />
                            The information collected by Google reCAPTCHA is subject to the
                            <a href="contenidos.aspx?t=privacidad" target="_blank" class="common-paragraph__link"
                                >Privacy Policy</a
                            >
                           and at
                            <a href="" class="common-paragraph__link"
                                >Google Terms of Service</a
                            >, and is used to provide and maintain the reCPTCHA service, as well as for general security purposes (Google does not use it to personalize advertising).
                        </p>
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
