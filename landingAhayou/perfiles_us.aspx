<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfiles_us.aspx.cs" Inherits="landingAhayou.perfiles_us" %>

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
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/forms.css" />
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/profiles.css" />
        <link rel="stylesheet" href="css/default-background.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
    </asp:ObjectDataSource>
         <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
             <SelectParameters>
                 <asp:ControlParameter ControlID="lblCodPlanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
             </SelectParameters>
 </asp:ObjectDataSource>
        <asp:Label ID="lblCodPlanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
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
                          <%--<button
                              class="header__button header__button--text header__button--bg-orange"
                            type="button" onclick="location.href='suscribete_us.aspx';">
                              Suscribe
                          </button>
                          <button
                              class="header__button header__button--text header__button--bg-green"
                           type="button" onclick="location.href='login_us.aspx';">
                              Login
                          </button>--%>
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
                           <%-- <input class="options__button" type="button" onclick="location.href='suscribete_us.aspx';" value="Suscribe" />
                            <input class="options__button" type="button" onclick="location.href='login_us.aspx';" value="Login" />--%>
                     </div>
                 </div>
                <asp:Label ID="lblUsuario" runat="server" Visible="true" Text=""></asp:Label>
            </nav>
      </header>
        <main class="main main--flex">
            <section class="profiles">
                <h1>Perfiles</h1>
                <div class="profiles__container">
                      <asp:Repeater ID="Repeater1" DataSourceID="odsAvatares" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton class="profiles__item" ID="lbtnPerfil" CommandArgument='<%# Eval("cod_perfil_suscriptor")+"|"+ Eval("pin") %>' OnClick="lbtnPerfil_Click" runat="server"> <img
                                     src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                     alt="Foto de perfil"
                                     class="profiles__item-image"
                                 />
                                 <span class="profiles__item-text"><%# Eval("nombre_perfil") %></span>
                            </asp:LinkButton>

                        </ItemTemplate>
                          </asp:Repeater>
                    
                    
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
</body>
</html>