<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="centro_ayuda_us.aspx.cs" Inherits="landingAhayou.centro_ayuda_us" %>


<!DOCTYPE html>
<html lang="en">
    <head>
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
        <link rel="stylesheet" href="css/containers.css" />
        <link rel="stylesheet" href="css/forms.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />




    </head>
    <body>
           <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
          </asp:ObjectDataSource>
           <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
               <SelectParameters>
                   <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
               </SelectParameters>
           </asp:ObjectDataSource>
          <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
           <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
           <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
           <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
           <asp:Label ID="lblMenu" runat="server" Visible="false" Text="0"></asp:Label>
         <form id="form1" runat="server">
        <header class="header">
            <nav class="header__nav">
                <a href="home_us.aspx" class="header__logo">
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
                                         Account
                                     </p>

                                </asp:LinkButton>
        
           
                                <a href="centro_ayuda.aspx" class="options__button--flex">
                                    <img
                                        src="imgs/flags/spain.png"
                                        alt="Foto perfil"
                                    />
                                    <p class="text--small text text--light">
                                        Spanish
                                    </p>
                                </a>
                                <a href="centro_ayuda_us.aspx" class="options__button--flex">
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
                        
                         <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
</asp:ObjectDataSource>
      <main class="main main--flex">
            <div class="container__wrapper container__wrapper--black">
                <form class="form">
                <h1 class="form__title">Centro de ayuda</h1>
                     <label
                        for="question"
                        class="form__label form__label--first text--black"
                    >
                        How can we help?
                    </label>
                     <div
                        class="form__input-container form__input-container--row form__input-container--no-gap"
                    >
                         <asp:TextBox class="form__input form--shadow-left" placeholder="Write a question, a topic or a problem" ID="txtConsulta" runat="server"></asp:TextBox>
                        <%--<input
                            type="text"
                            name="question"
                            placeholder="Escribe una pregunta, un tema o un problema"
                            id="question"
                            autocomplete="false"
                            class="form__input form--shadow-left"
                        />--%>
                         <asp:ImageButton ID="ibtnEnviar" class="button button--orange form--shadow-right" OnClick="ibtnEnviar_Click" ImageUrl="~/imgs/etc/arrow.svg" runat="server" />
                        <%--<button type="submit" class="form__button form--shadow-right">
                            <img src="imgs/etc/arrow.svg" alt="Enviar" />
                        </button>--%>
                    </div>
                    </form>
            </div>
        </main>
                 
        <footer class="footer footer--black">
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
                            <%-- <asp:Repeater ID="Repeater5" DataSourceID="odsRedesSociales" runat="server">
                                    <ItemTemplate>
                                         <a href="<%# Eval("url") %>"  target="_blank" class="social-media__link">
                                             <img
                                                 src='<%# "imgs/logos/" + Eval("red_social") + ".svg" %>'
                                                 alt='<%# Eval("red_social") %>'
                                                 class="social-media__img"
                                             />
                                         </a>
 
                                    </ItemTemplate>
                             </asp:Repeater>--%>
               
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
    </body>
</html>