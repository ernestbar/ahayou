<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="privacidad.aspx.cs" Inherits="WebAhayouAdmin.privacidad" %>

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
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/privacy.css" />
    </head>
    <body>
         <form id="form1" runat="server">
         <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="WebAhayouAdmin.Clases.Contenidos">
        </asp:ObjectDataSource>
        <header class="header--privacy">
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
        </header>
        <main class="information">
            <article class="information__article">
                <h1 class="information__title">Aviso de privacidad</h1>
                <div class="information__content">
                    <div class="information__paragraphs">
                        <p>
                            En este Aviso de privacidad, se explica cómo
                            recopilamos, usamos y divulgamos su información
                            personal cuando usa el «Servicio de Ahayou» para
                            acceder al «Contenido de Ahayou», según se definen
                            estos términos en los Términos de uso de Ahayou
                            (Ahayou.com/terms). También se explican sus
                            derechos de privacidad y cómo puede ejercerlos. Es
                            posible que, mediante determinadas funcionalidades o
                            apps que son parte del servicio de Ahayou, obtenga
                            información u opciones de privacidad contextuales,
                            además de la información y las opciones que se
                            describen en este Aviso de privacidad. Tenga en
                            cuenta que puede ser más fácil navegar por este
                            Aviso de privacidad cuando se visualiza desde su
                            navegador web. Contacto
                        </p>
                        <p>
                            Si tiene alguna pregunta respecto de este Aviso de
                            privacidad, o nuestro uso de su información
                            personal, o sobre cómo ejercer sus derechos de
                            privacidad, escriba a nuestro responsable de
                            Protección de Datos o a la Oficina de Privacidad al
                            email privacy@Ahayou.com. Si tiene preguntas
                            generales sobre el servicio de Ahayou, su cuenta o
                            cómo ponerse en contacto con nuestro Servicio al
                            Cliente, visite help.Ahayou.com. La información
                            sobre la entidad (o entidades) de Ahayou
                            específica(s) responsable(s) de la información
                            personal (conocido como «responsable de los datos»
                            en ciertos países) está disponible en
                            Ahayou.com/legal/corpinfo. Sección A: Recopilación,
                            uso y divulgación de la información personal
                            Categorías de información personal que recopilamos
                        </p>
                        <p>
                            Recopilamos las siguientes categorías de información
                            personal sobre usted:
                        </p>
                    </div>
                    <ul
                        class="information__paragraphs information__paragraphs--points"
                    >
                        <li>
                            Información personal: Cuando crea su cuenta de
                            Ahayou, recopilamos su información de contacto
                            (como su dirección de email) e información de
                            autenticación para el inicio de sesión (como su
                            contraseña). Según la forma en que configure luego
                            su cuenta y la forma de pago, y qué funciones
                            utilice, también recopilamos uno o más de los
                            siguientes datos: nombre y apellido, número de
                            teléfono, dirección postal y otros identificadores
                            que nos proporcione. Si se suscribe a un plan de
                            membresía con anuncios, también recopilamos su
                            género y fecha de nacimiento.
                        </li>
                        <li>
                            Información de pago: Recopilamos su información de
                            pago y otra información para procesar los pagos,
                            incluido el historial de pagos, la dirección de
                            facturación y las tarjetas de regalo que haya
                            canjeado.
                        </li>
                        <li>
                            Información del perfil/cuenta de Ahayou:
                            Recopilamos información relacionada con su cuenta de
                            Ahayou o los perfiles en su cuenta (como el nombre
                            de perfil y el icono, el alias de juegos de Ahayou,
                            las calificaciones y los comentarios que proporciona
                            sobre el contenido de Ahayou), «Mi lista» (lista de
                            visualización de títulos), información de «Continuar
                            viendo», configuración de la cuenta o del perfil y
                            opciones en relación con el uso que hace del
                            servicio de Ahayou.
                        </li>
                        <li>
                            Información de uso: Recopilamos información sobre su
                            interacción con el servicio de Ahayou (incluidos
                            los eventos de reproducción, como reproducir,
                            pausar, etc.), las opciones que haya seleccionado al
                            interactuar con títulos interactivos, la actividad
                            de juego en Ahayou (como jugabilidad, uso de juegos
                            e información de interacción, e información de los
                            juegos guardados y del progreso), el historial de
                            juegos y de visualización de Ahayou, las consultas
                            de búsqueda en el servicio de Ahayou, y otra
                            información sobre el uso y las interacciones con el
                            servicio de Ahayou (como clics en la app, texto
                            ingresado, hora y duración del acceso, y acceso a la
                            cámara o a las fotos para escanear un código QR y
                            usar funcionalidades similares).
                        </li>
                        <li>
                            Información de publicidad: Si se suscribe a un plan
                            de membresía con anuncios, recopilamos información
                            sobre los anuncios en Ahayou («Anuncios», según se
                            define en los Términos de uso de Ahayou) que ve o
                            con los que interactúa, información del dispositivo
                            (como identificadores de dispositivos
                            reconfigurables), direcciones IP e información
                            proporcionada por agencias publicitarias (como
                            información sobre sus posibles intereses que
                            recopilaron o infieren en función de las visitas que
                            hace a otros sitios web o apps). Usamos esta
                            información para mostrar Anuncios en el servicio de
                            Ahayou (incluidas las publicidades conductuales de
                            acuerdo con sus preferencias).
                        </li>
                    </ul>
                </div>
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
                    <%--<div class="footer__list-item">
                        <a href="#frequent-questions"> Preguntas frecuentes </a>
                        <a href="privacy.html">Privacidad</a>
                    </div>
                    <div class="footer__list-item">
                        <a href="#">Centro de Ayuda</a>
                        <a href="#">Avisos Legales</a>
                    </div>
                    <div class="footer__list-item">
                        <a href="#">T&eacute;rminos de uso</a>
                        <a href="#">Contacto</a>
                    </div>--%>
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
    </body>
</html>
