<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="planes_ahayou_us.aspx.cs" Inherits="landingAhayou.planes_ahayou_us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/default-background.css" />
        <link rel="stylesheet" href="css/containers.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/plans-selection.css" />
        <link rel="stylesheet" href="css/ribbon.css" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
            </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
                 </SelectParameters>
             </asp:ObjectDataSource>
            <asp:Label ID="Label1" runat="server" Visible="false" Text="BO"></asp:Label>
             <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
             <asp:Label ID="lblMenu" runat="server" Visible="false" Text="0"></asp:Label>
          <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
          </asp:ObjectDataSource>
           <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLANES_STR" TypeName="landingAhayou.Clases.Contenidos">
             <SelectParameters>
                 <asp:ControlParameter ControlID="lblMundo" Name="PV_MUNDO" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
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
                        <input class="header__button header__button--icon" type="button" onclick="location.href='planes_ahayou.aspx';" />
                        <input class="header__button header__button--icon" type="button" onclick="location.href='planes_ahayou_us.aspx';" />
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
         
                               <input class="options__button" type="button" onclick="location.href='planes_ahayou.aspx';" value="Spanish" />
                            <input class="options__button" type="button" onclick="location.href='planes_ahayou_us.aspx';" value="English" />
                            <input class="options__button" type="button" onclick="location.href='suscribete_us.aspx';" value="Suscribe" />
                            <input class="options__button" type="button" onclick="location.href='login_us.aspx';" value="Login" />
                         </div>
                     </div>
                    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
                </asp:Panel>
                
            </nav>
        </header>
        <main class="main main--flex">
             <section
                class="container--flex container--flex-column full-width plans-selection full-height"
            >
                <span class="text text--light text--center full-width">
                    WE PRESENT OUR STREAMING PLANS
                </span>
                <h1>Select the ideal plan for you</h1>
                <div
                    class="plans-selection__list container--flex-wrap container--flex container--justify-content-center"
                >
                <asp:Repeater ID="Repeater2" DataSourceID="odsPlanes" runat="server">
                    <ItemTemplate>
                    <article
                        class="plans-selection__item container--shiny container--padding-normal container--flex container--flex-column plans-selection--gap"
                    >
                        <div
                            class="container-common container--green container--small-rounded container--no-border plans-selection__padding"
                        >
                            <h2 class="text text--bold text--black">
                               <%# Eval("plan_ingles") %>
                            </h2>
                        </div>
                        <div
                            class="plans-selection__padding plans-selection--gap container--flex container--flex-column"
                        >
                            <div>
                                <h3 class="text text--light"> <%# Eval("plan_ingles") %></h3>
                                <p class="text text--bold"><%# Eval("moneda") %> <%# Eval("monto") %></p>
                                <p><%# Eval("pago_mes_ingles") %></p>
                            </div>
                            <div>
                                <h3 class="text text--light">
                                    Calidad de audio y video
                                </h3>
                                <p class="text text--bold"><%# Eval("caracteristicas_ingles").ToString().Replace("|","<br />") %></p>
                            </div>
                          <%--  <div>
                                <h3 class="text text--light">
                                    Resoluci&oacute;n
                                </h3>
                                <p class="text text--bold">720p (HD)</p>
                            </div>
                           
                            <div>
                                <h3 class="text text--light">
                                    Dispositivos del hogar en los se puede ver
                                    Ahayou al mismo tiempo
                                </h3>
                                <p class="text text--bold">1</p>
                            </div>--%>
                             <div>
                                 <h3 class="text text--light">
                                    Compatible devices
                                 </h3>
                                 <p class="text text--bold">
                                     TV, computer, phone, tablet
                                 </p>
                             </div>
                            <div>
                                <h3 class="text text--light">
                                    <%# Eval("ahorro_mes") %>
                                </h3>
                                <p class="text text--bold"></p>
                            </div>
                              <asp:Button class="button button--orange full-width button--border" CommandArgument='<%# Eval("url_pasarela")+"|"+ Eval("codigo_plan")%>' OnClick="btnComprar_Click" ID="btnComprar" runat="server" Text="Buy" />
                        </div>
                    </article>
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
        <script src="js/show-validation-alert.js" defer></script>

        <script src="js/open-submenu.js"></script>
</body>
</html>