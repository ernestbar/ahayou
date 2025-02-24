﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebAhayouAdmin.home" %>

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
     <link rel="stylesheet" href="css/main.css" />
     <link rel="stylesheet" href="css/containers.css" />
     <link rel="stylesheet" href="css/arrow.css" />
     <link rel="stylesheet" href="css/header.css" />
     <link rel="stylesheet" href="css/new-releases.css" />
     <link rel="stylesheet" href="css/plans.css" />
     <link rel="stylesheet" href="css/web-app-section.css" />
     <link rel="stylesheet" href="css/footer.css" />
     <link rel="stylesheet" href="css/frequent-questions.css" />
     <link rel="stylesheet" href="css/header-movies.css" />


    <link rel="manifest" href="<%=  this.ResolveClientUrl("~/")   %>manifest.json" />
    <script src="<%=  this.ResolveClientUrl("~/")   %>Scripts/pwacompat.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="odsRotador1" runat="server" SelectMethod="PR_STR_GET_BANNER_PRINCIPAL" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsUltimos" runat="server" SelectMethod="PR_STR_GET_NUEVOS_AGREGADOS" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPreguntas" runat="server" SelectMethod="PR_PAR_GET_PREGUNTAS_FRECUENTES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLANES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblMundo" Name="PV_MUNDO" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
        <header class="header" id="header__movies">
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
                        <button
                            class="header__button header__button--icon"
                        ></button>
                        <button
                            class="header__button header__button--icon"
                        ></button>
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
                                   <asp:Panel ID="panel_banner" class="header__item carousel__item active" data-bg=' <%# Eval("contenido") %>'  runat="server" >
                                       <%--<div class="header__item carousel__item active" data-bg=' <%# Eval("contenido") %>'>--%>
                                            <h2 class="header__title">
                                                <b>Streaming</b> con <b>Alma Boliviana</b>
                                            </h2><br /><br /><br />
                                            <p class="header__description">
                                                Una experiencia mejorada no te pierdas los
                                                estrenos m&aacute;s anticipados y tus
                                                cl&aacute;sicos favoritos
                                            </p>
                                        <%--</div>--%>
                                   </asp:Panel>
                                   <asp:Panel ID="panel_pelicula" class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  Visible="false" runat="server" >
                                        <%--<div class="header__item carousel__item" data-bg=' <%# Eval("contenido") %>'  >--%>
                                         <div class="movie__container" >
                                             <span class="movie__format"><%# Eval("formato_contenido") %></span>
                                             <img
                                                 src=' <%# Eval("nombre") %>'
                                                 alt='<%# Eval("nombre_contenido") %>'
                                                 class="movie__image"
                                             />
                                             <span class="movie__detail-1">
                                                 <%# Eval("detalle1") %>
                                             </span>
                                             <span class="movie__detail-2">
                                                <%# Eval("detalle2") %>
                                             </span>
                                             <p class="movie__description">
                                                 <%# Eval("resumen") %>
                                             </p>
                                             <span class="movie__gender"><%# Eval("genero") %></span>
                                        <%-- </div>--%>
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
                          <button id=' <%# Eval("Numero") %>' class="header__pag-button carousel__button">
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
                    <span>Nuevos</span>&nbsp;<span>agregados</span>
                </h2>
                <div class="new-releases__content">
                    <div class="arrow__container arrow--rotate carousel__arrow--prev" >
                        <div class="arrow absolute"></div>
                        <div class="arrow__border"></div>
                    </div>
                    <div class="new-releases__list">
                          <asp:Repeater ID="Repeater4" DataSourceID="odsUltimos" runat="server">
		                            <ItemTemplate>
                                            <article class="new-releases__item container">
                                                <img src='<%# Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />
                                                   <%--<img src='<%# "data:image/jpg;base64," + Eval("contenido") %>' alt='<%# Eval("nombre_contenido") %>' />--%>
                                                <div>
                                                    <h3><%# Eval("nombre_contenido") %></h3>
                                                    <p><%# Eval("descripcion") %></p>
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
                    <span>Elige</span><span>&nbsp;tu Plan</span>
                </h2>
                <div class="plans__list">
                     <asp:Repeater ID="Repeater2" DataSourceID="odsPlanes" runat="server">
	                    <ItemTemplate>
                            <a href="#" class="plans__item">
                                <div class="plans__item--type-2">
                                    <div class="plans__item-content container">
                                        <div class="arrow green absolute arrow__corner"></div>
                                        <h3 class="plans__item-title">
                                            <%# Eval("planes") %>
                                        </h3>
                                        <ul class="plans__item-descriptions">
                                            <li><%# Eval("caracteristicas").ToString().Replace("|","<br />") %></li>
                                        </ul>
                                    </div>
                                    <div class="plans__item-price container">
                                        <div>
                                            <span class="bs">Bs</span>
                                            <div class="price__content">
                                                <span class="price__description">Pago &uacute;nico</span>
                                                <span class="price__number"><%# Eval("monto") %></span>
                                                <span class="price__description"><%# Eval("pago_mes") %></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="plans__item-footer">
                                    <p><%# Eval("ahorro") %></p>
                                </div>
                            </a>
	                    </ItemTemplate>
                     </asp:Repeater>
                </div>
            </section>
            <section class="frequent-questions" id="frequent-questions">>
                <h2 class="frequent-questions__title">
                    <span>Preguntas</span>&nbsp;<span>frecuentes</span>
                </h2>
                <div class="frequent-questions__content container">
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
                                             <span><%# Eval("pregunta") %></span>
                                             <div class="arrow green-yellow"></div>
                                         </summary>
                                         <p>
                                            <%# Eval("respuesta") %>
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
            <div class="web-app-section__content container" id="downloadContainer">
                <h2 class="web-app-section__title" id="downloadTitle">
                    Descarga la Web APP
                </h2>
                <div class="web-app-section__container-description">
                    <img
                        src="imgs/logos/pwa_logo.png"
                        alt="PWA"
                        class="web-app-section__image"
                    />
                    <p class="web-app-section__description">
                        Con esta PWA tendr&aacute; un sitio web que se ve y se
                        comporta como si fuera una aplicaci&oacute;n
                        m&oacute;vil ahorrando espacio en tu dispositivo
                    </p>
                </div>
            </div>
            <form class="web-app-section__form">
                <label for="email" class="web-app-section__label">
                    Ya est&aacute;s listo para vivir la experiencia
                    Ah&aacute;you<br />crea tu cuenta ¡¡¡AQU&lacute;!!!
                </label>
                <div class="web-app-section__container-input">
                    <input
                        type="email"
                        name="email"
                        placeholder="Ingresa tu correo"
                    />
                    <input type="button" value="Suscríbete" />
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
                            <a href="#frequent-questions">Preguntas frecuentes</a>
                            <a href="privacidad.aspx" target="_blank">Privacidad</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="#">Centro de Ayuda</a>
                            <a href="#">Avisos Legales</a>
                        </div>
                        <div class="footer__list-item">
                            <a href="#">T&eacute;rminos de uso</a>
                            <a href="#">Contacto</a>
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

       <script src="js/carousel.js"></script>
        <script src="js/carousel-new-releases.js"></script>
        <script src="js/web-app-title.js"></script>
    </form>
</body>
</html>
