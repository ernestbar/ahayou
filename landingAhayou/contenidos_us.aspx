<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contenidos_us.aspx.cs" Inherits="landingAhayou.contenidos_us" %>

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
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/information.css" />
    </head>
    <body>
         <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <header class="header--privacy">
            <nav class="header__nav">
                <a href="home_us.aspx" class="header__logo">
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
                              Suscribe
                          </button>
                          <button
                              class="header__button header__button--text header__button--bg-green"
                          >
                              Login
                          </button>
                </div>
                <div class="header__nav-buttons">
                    <div>
                        <%--<button
                            class="header__button header__button--icon"
                        ></button>
                        <button
                            class="header__button header__button--icon"
                            onclick='window.location.href = "FirstPage.html"'
                        ></button>--%>
                         <input class="header__button header__button--icon" type="button" onclick="location.href='home.aspx';" />
                        <input class="header__button header__button--icon" type="button" onclick="location.href='home_us.aspx';" />
                    </div>
                </div>
                 <div class="options__container">
                     <button class="options__principal-button" id="menuButton">
                         <span class="options__div-hamburger"></span>
                         <span class="options__div-hamburger"></span>
                         <span class="options__div-hamburger"></span>
                     </button>
                     <div class="options__menu" id="optionsMenu">
                         <%--<button class="options__button" onclick='window.location.href="home.aspx"'>Spanish</button>
                         <button class="options__button" >English</button>--%>
                          <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Spanish" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="English" />
                     </div>
                 </div>
            </nav>
        </header>
        <main class="main main--information">
            <article class="information__article">
                 <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                         <%# Eval("contenido_ingles") %>
                    </ItemTemplate>
             </asp:Repeater>
            </article>
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
                        <a href="centro_ayuda_us.aspx" target="_blank">Help Center</a>
                         <a href="contenidos_us.aspx?t=avisos legales" target="_blank">Legal Notices</a>
                    </div>
                    <div class="footer__list-item">
                        <a href="contenidos_us.aspx?t=terminos de uso" target="_blank">Terms of Use</a>
                        <a href="contacto_us.aspx" target="_blank">Contacto</a>
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
        <script src="/js/footer-visited-color.js"></script>
        <script src="/js/open-menu.js"></script>
    </body>
</html>
