<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home_us.aspx.cs" Inherits="landingAhayou.home_us" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <link rel="stylesheet" href="css/common/containers.css" />
        <link rel="stylesheet" href="css/common/arrow.css" />
        <link rel="stylesheet" href="css/header/header.css" />
        <link rel="stylesheet" href="css/new-releases.css" />
        <link rel="stylesheet" href="css/plans.css" />
        <link rel="stylesheet" href="css/web-app-section.css" />
        <link rel="stylesheet" href="css/forms/forms.css" />
        <link rel="stylesheet" href="css/frequent-questions.css" />
        <link rel="stylesheet" href="css/header/header-movies.css" />
        <link rel="stylesheet" href="css/forms/forms.css" />
        <link rel="stylesheet" href="css/header/header-options.css" />
        <link rel="stylesheet" href="css/common/footer.css" />
        <link rel="stylesheet" href="css/common/buttons.css" />
        <link rel="stylesheet" href="css/common/hamburger.css" />


    <link rel="manifest" href="<%=  this.ResolveClientUrl("~/")   %>manifest.json" />
    <script src="<%=  this.ResolveClientUrl("~/")   %>Scripts/pwacompat.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUltimos" runat="server" SelectMethod="PR_STR_GET_NUEVOS_AGREGADOS" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="PR_PAR_GET_PREGUNTAS_FRECUENTES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLANES_STR" TypeName="landingAhayou.Clases.Contenidos">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblMundo" Name="PV_MUNDO" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
         <header class="header header--main" id="header__movies">
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
                      <button class="hamburger__button" id="menuButton">
                           <span class="hamburger__line hamburger__line--white"></span>
                        <span class="hamburger__line hamburger__line--white"></span>
                        <span class="hamburger__line hamburger__line--white"></span>
                     </button>
                     <div class="options__menu" id="optionsMenu">
                         <%--<button class="options__button" onclick='window.location.href="home.aspx"'>Spanish</button>
                         <button class="options__button" >English</button>--%>
                          <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Spanish" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="English" />
                     </div>
                 </div>
            </nav>
            <section class="header__main-content carousel">
                <div class="header__items-container">
                    <div
                        class="arrow__container arrow--rotate carousel__arrow--prev"
                    >
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    <div class="header__list carousel__slides">
                         
                            <asp:Repeater ID="Repeater6" DataSourceID="odsRotador1" OnItemDataBound="Repeater6_ItemDataBound" runat="server">
                               <ItemTemplate>
                                <asp:Label ID="lblIdNumero"  runat="server" Text=' <%# Eval("Numero") %>' Visible="false"></asp:Label>
                                   <asp:Panel ID="panel_banner" class="header__item carousel__item carousel__item--active" data-bg=' <%# Eval("contenido") %>'  runat="server" >
                                                                
                                       <%--<div class="header__item carousel__item active" data-bg=' <%# Eval("contenido") %>'>--%>
                                            <h2 class="header__title">
                                                <b>Streaming</b> with  <b>Bolivian Soul</b>
                                            </h2>
                                            <p class="header__description">
                                                An improved experience don't miss the
                                                most anticipated releases and your
                                                favorite classics
                                            </p>
                                        <%--</div>--%>
                                   </asp:Panel>
                                   <asp:Panel ID="panel_pelicula" class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  Visible="false" runat="server" >
                                        <%--<div class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  >--%>
                                         <div
                                                class="movie__container movie__container--active"
                                            >
                                             <div>
                                             <span class="movie__format"><%# Eval("formato_contenido_ingles") %></span>
                                             <img
                                                 src=' <%# Eval("nombre") %>'
                                                 alt='<%# Eval("nombre_contenido") %>'
                                                 class="movie__image"
                                             />
                                                 </div>
                                             <div>
                                             <span class="movie__detail-1">
                                                 <%# Eval("detalle1_ingles") %>
                                             </span>
                                             <span class="movie__detail-2">
                                                <%# Eval("detalle2_ingles") %>
                                             </span>
                                             <p class="movie__description">
                                                 <%# Eval("resumen_ingles") %>
                                             </p>
                                             <span class="movie__gender"><%# Eval("genero_ingles") %></span>
                                                 </div>
                                            </div>
                                
                                       <div
                                            class="movie__container movie__container--second container-common"
                                        >
                                            <img
                                               src=' <%# Eval("contenido_vertical") %>'
                                                alt='<%# Eval("nombre_contenido") %>'
                                            />
                                            <h3 class="movie__title--small"><%# Eval("nombre_contenido") %></h3>
                                           <ul class="movie__data--small">
                                                <li class="movie__data-item--small">
                                                    <%# Eval("genero_ingles") %>
                                                </li>
                                                <li class="movie__data-item--small">
                                                     <%# Eval("detalle1_ingles") %>
                                                </li>
                                                <li class="movie__data-item--small">
                                                     <%# Eval("detalle2_ingles") %>
                                                </li>
                                                <li class="movie__data-item--small">
                                                    <%# Eval("formato_contenido_ingles") %>
                                                </li>
                                            </ul>
                                        </div>
                                   </asp:Panel>
         
                               </ItemTemplate>
                        </asp:Repeater>
                             </div>
                    <div class="arrow__container carousel__arrow--next">
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    </div>
                <div class="header__pag-buttons">
                    <asp:Repeater ID="Repeater1" DataSourceID="odsRotador1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
	                    <ItemTemplate>
                         <asp:Label ID="lblIdNumero" runat="server" Text=' <%# Eval("Numero") %>' Visible="false"></asp:Label>
                          <button id=' <%# Eval("Numero") %>' class="header__pag-button header__pag-button--selected carousel__button">
                         <%--<button class='<%# "header__pag-button carousel__button " + Eval("Numero").ToString().Replace("01","selected") %>'>--%>
                              <%# Eval("Numero") %>
                          </button>
	                    </ItemTemplate>
                 </asp:Repeater>
                </div>
            </section>
        </header>
      
        <main>
            <section class="new-releases carousel">
                <h2 class="new-releases__title">
                    <span>New</span>&nbsp;<span>additions</span>
                </h2>
                <div class="new-releases__content">
                    <div class="arrow__container arrow--rotate carousel__arrow--prev" >
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    <div class="new-releases__list">
                          <asp:Repeater ID="Repeater4" DataSourceID="odsUltimos" runat="server">
		                            <ItemTemplate>
                                           <article class="new-releases__item container-common">
                                                <img src='<%# Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />
                                                   <%--<img src='<%# "data:image/jpg;base64," + Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />--%>
                                                <div>
                                                    <h3><%# Eval("nombre_contenido") %></h3>
                                                    <p><%# Eval("descripcion_ingles") %></p>
                                                </div>
                                            </article>
                                   
		                            </ItemTemplate>
                          </asp:Repeater>
                    </div>
                    <div class="arrow__container carousel__arrow--next">
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                </div>
            </section>
            <section class="plans">
                <h2 class="plans__title">
                    <span>Choose</span><span>&nbsp;you Plan</span>
                </h2>
                <div class="plans__list">
                     <asp:Repeater ID="Repeater2" DataSourceID="odsPlanes" runat="server">
	                    <ItemTemplate>
                            <a href="#" class="plans__item">
                                <div class="plans__item--type-2">
                                   <div class="plans__item-content container-common">
                                        <div
                                            class="arrow green absolute arrow__corner"
                                        ></div>
                                        <h3 class="plans__item-title">
                                            <%# Eval("plan_ingles") %>
                                        </h3>
                                        <ul class="plans__item-descriptions">
                                            <li><%# Eval("caracteristicas_ingles").ToString().Replace("|","<br />") %></li>
                                        </ul>
                                    </div>
                                   <div class="plans__item-price container-common">
                                        <div>
                                            <span class="bs"><%# Eval("moneda") %></span>
                                            <div class="price__content">
                                                <span class="price__description">single Payment</span>
                                                <span class="price__number"><%# Eval("monto") %></span>
                                                <span class="price__description"><%# Eval("pago_mes_ingles") %></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="plans__item-footer">
                                    <p><%# Eval("ahorro_mes") %></p>
                                </div>
                            </a>
	                    </ItemTemplate>
                     </asp:Repeater>
                </div>
            </section>
            <section class="frequent-questions" id="frequent-questions">
                <h2 class="frequent-questions__title">
                    <span>Frequently</span>&nbsp;<span>asked</span>&nbsp;<span>questions</span>
                </h2>
                 <div class="frequent-questions__content container-common">
                    <div class="frequent-questions__image">
                        <img
                            src="imgs/etc/electronics.png"
                            alt="Dispositivos"
                            id="frequentQuestionsImg"
                        />
                    </div>
                    <ul class="frequent-questions__list">
                         <asp:Repeater ID="Repeater3" DataSourceID="odsPreguntas" runat="server">
                            <ItemTemplate>
                                 <li class="frequent-questions__item underline">
                                     <details name="frequent-questions" class="frequent-questions-detail">
                                         <summary>
                                             <span><%# Eval("pregunta_ingles") %></span>
                                             <div class="arrow green-yellow"></div>
                                         </summary>
                                         <p>
                                            <%# Eval("respuesta_ingles") %>
                                         </p>
                                     </details>
                                 </li>
                            </ItemTemplate>
                             </asp:Repeater>
                    </ul>
                </div>
            </section>
        </main>
       <section class="web-app-section" id="webAppSection">
             <button
                 class="web-app-section__content container-common"
                 id="downloadContainer"
             >
                 <h2 class="web-app-section__title" id="downloadTitle">
                    Download the Web APP
                 </h2>
                 <div class="web-app-section__container-description">
                     <img
                         src="imgs/logos/pwa_logo.png"
                         alt="PWA"
                         class="web-app-section__image"
                     />
                     <p class="web-app-section__description">
                        With this PWA you will have a website that looks and feels
                         behaves as if it were an application
                         mobile saving space on your device
                     </p>
                 </div>
             </button>
            <form class="web-app-section__form">
                <label for="email" class="form__label form__label--white">
                    You are now ready to live the Aháyou experience
                    create your account HERE!!!
                </label>
                <div class="form__input-container form__input-container--main">
                    <input
                        type="email"
                        name="email"
                        placeholder="Email"
                        id="email"
                        autocomplete="false"
                        class="form__input form__input--big-font form__input--specific-width"
                    />
                    <input
                        type="submit"
                        value="Suscribe"
                        class="form__button"
                    />
                </div>
            </form>
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
        </section>

       <script src="js/header-background-handler.js"></script>
 <script src="js/carousel-header-index.js"></script>
 <script src="js/carousel-new-releases.js"></script>
 <script src="js/web-app-title.js"></script>
 <script src="js/open-menu.js"></script>
 <script src="js/header-movies-responsive.js"></script>
 <script src="js/movie-container-hover.js"></script>
    </form>
</body>
</html>
