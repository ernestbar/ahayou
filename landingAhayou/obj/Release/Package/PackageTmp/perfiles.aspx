<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfiles.aspx.cs" Inherits="landingAhayou.perfiles" %>

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
        <link rel="stylesheet" href="css/common/footer.css" />
        <link rel="stylesheet" href="css/forms/forms.css" />
        <link rel="stylesheet" href="css/common/vanilla-page.css" />
        <link rel="stylesheet" href="css/profiles.css" />
        <link rel="stylesheet" href="css/common/default-background.css" />
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
        <asp:Label ID="lblCodPlanSuscriptor" runat="server" Text=""></asp:Label>
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
                 <asp:Button class="header__button header__button--text header__button--bg-green" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Iniciar Session" />   
                  <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
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
            <section class="profiles">
                <h1>Perfiles</h1>
                <div class="profiles__container">
                      <asp:Repeater ID="Repeater1" DataSourceID="odsAvatares" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton class="profiles__item" ID="lbtnPerfil" OnClick="lbtnPerfil_Click" runat="server"> <img
                                     src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                     alt="Foto de perfil"
                                     class="profiles__item-image"
                                 />
                                 <span class="profiles__item-text"><%# Eval("nombre_perfil") %></span>

                            </asp:LinkButton>
<%--                            <button class="profiles__item">
                                    <img
                                        src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                        alt="Foto de perfil"
                                        class="profiles__item-image"
                                    />
                                    <span class="profiles__item-text"><%# Eval("codigo_avatar") %></span>
                                </button>--%>
                        </ItemTemplate>
                          </asp:Repeater>
                    
                    <%--<button class="profiles__item">
                        <img
                            src="imgs/etc/profile_image.png"
                            alt="Foto de perfil"
                            class="profiles__item-image"
                        />
                        <span class="profiles__item-text">Perfil 2</span>
                    </button>
                    <button class="profiles__item">
                        <img
                            src="imgs/etc/profile_image.png"
                            alt="Foto de perfil"
                            class="profiles__item-image"
                        />
                        <span class="profiles__item-text">Perfil 3</span>
                    </button>
                    <button class="profiles__item">
                        <img
                            src="imgs/etc/profile_image.png"
                            alt="Foto de perfil"
                            class="profiles__item-image"
                        />
                        <span class="profiles__item-text">Perfil 4</span>
                    </button>--%>
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
</body>
</html>
