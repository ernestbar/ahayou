<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avisos_legales.aspx.cs" Inherits="WebAhayouAdmin.avisos_legales" %>

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
                <h1 class="information__title">Avisos legales</h1>
                <div class="information__content">
                    <div class="information__paragraphs">
                        <p>
                            El servicio de Ahayou, incluidos todos los contenidos del servicio de Ahayou, 
                            está protegido por las leyes de derechos de autor, marcas registradas, 
                            secreto comercial u otras leyes o tratados de propiedad intelectual.
                        </p>
                        <p>
                            Derechos de autor
                        </p>
                        <p>
                            Los derechos de autor del contenido de nuestro servicio son propiedad de productores y 
                            empresas de producción importantes, Ahayou entre ellas. Si considera que se están violando 
                            los derechos de autor propios o de alguien más en el servicio de Ahayou, complete el formulario 
                            de reclamación de violación de derechos de autor (www.Ahayou.bo/copyrights).

                        </p>
                        <p>
                            Marcas registradas
                        </p>
                         <p>
                             Ahayou, el logotipo N y el identificador sónico Tudum son marcas registradas de Ahayou, Inc.<br />
                                No se puede usar ninguna marca registrada de Ahayou como si fuera una marca propia o patrocinada 
                             a menos que se cuente con el permiso explícito de Ahayou.<br />
                                Cualquier producto con el nombre o el logotipo de Ahayou es un reflejo directo de Ahayou. 
                             A menos que se tenga licencia, está terminantemente prohibido fabricar, vender o ceder bienes
                             o servicios con nuestro nombre o logotipo impreso.


                         </p>

                        <p>
                            Patentes
                        </p>
                        <p>
                            Los servicios y las aplicaciones de Ahayou están patentados. Para obtener más información sobre 
                            patentes relacionadas con nuestros servicios, visite www.Ahayou.bo/patents.

                        </p>
                        <p>
                            Avisos de terceros
                        </p>
                        <p>
                            Las aplicaciones de Ahayou, los kits de desarrollo de software (SDK) y otros productos de Ahayou 
                            pueden contener software de código abierto o licencias gratuitas («Software de código abierto»). 
                            Los términos de uso de Ahayou no modifican ningún derecho u obligación que usted pueda tener con 
                            esas licencias de software de código abierto. Para obtener más información sobre software de 
                            código abierto, incluidos los reconocimientos requeridos, los términos de licencia y avisos, 
                            consulte a continuación.
                        </p>
                    </div>
                    
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
