<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="terminos_uso.aspx.cs" Inherits="WebAhayouAdmin.terminos_uso" %>

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
                <h1 class="information__title">Términos de uso de Ahayou</h1>
                <div class="information__content">
                    <div class="information__paragraphs">
                        <p>
                            Ahayou brinda un servicio de membresía personalizado que permite a nuestros miembros acceder 
                            a contenido de entretenimiento (el «contenido de Ahayou») a través de internet en ciertas TV, 
                            computadoras y otros dispositivos conectados a internet («dispositivos listos para Ahayou»).<br /><br />
                            El proveedor del servicio de Ahayou es Ahayou Inc. Los presentes Términos de uso rigen la 
                            utilización que haga de nuestro servicio. Según se utilicen en estos Términos de uso, 
                            «el servicio de Ahayou», «nuestro servicio» o «el servicio» se refieren al servicio personalizado 
                            brindado por Ahayou para descubrir y acceder al contenido de Ahayou, incluidas todas las características 
                            y funcionalidades, recomendaciones y críticas, nuestros sitios web y las interfaces de usuario, 
                            así como todo el contenido y software asociado a nuestro servicio. Las referencias a «usted» en estos 
                            Términos de uso señalan al miembro que creó la cuenta de Ahayou y al que se le facturan los cargos 
                            a través de su forma de pago.
                        </p>
                        <p>
                            1.	Membresía
                        </p>
                        <p>
                            1.1. Su membresía de Ahayou continuará hasta que la cancele. Para usar el servicio de Ahayou, 
                            debe tener acceso a internet y un dispositivo listo para Ahayou, y proporcionar una o más Formas 
                            de pago. «Forma de pago» significa una forma de pago actual, válida y aceptada, que pueda actualizarse 
                            periódicamente y que admita pagos a través de su cuenta con terceros. A menos que cancele su membresía 
                            antes de la fecha de facturación, nos autoriza a cobrarle la cuota de membresía del siguiente ciclo de 
                            facturación a su Forma de pago (ver «Cancelación» a continuación).

                        </p>
                        <p>
                            1.2. Podemos ofrecer una gran variedad de planes de membresía, incluidas las membresías que se 
                            ofrecen a través de terceros junto con la provisión de sus propios productos y servicios. No somos 
                            responsables por los productos y servicios provistos por dichos terceros. Ciertos planes de membresía 
                            pueden incluir diversas condiciones y limitaciones, las cuales se aclaran en el acuerdo de suscripción 
                            o en otras comunicaciones. Podrá encontrar la información específica sobre su membresía de Ahayou 
                            visitando el sitio web Ahayou.com y haciendo clic en el vínculo «Cuenta», disponible en la parte 
                            superior de las páginas bajo su nombre de perfil.

                        </p>
                        
                         <p>
                            2.	Ofertas promocionales.     
                         </p>
                         <p>
                             Ocasionalmente, podríamos hacer ofertas especiales de promociones, planes o membresías («Ofertas»). 
                             Ahayou determina los requisitos para acceder a la Oferta a su exclusivo criterio, y nos reservamos 
                             el derecho de revocar una Oferta y suspender su cuenta si determinamos que usted no es elegible. 
                             Los miembros de hogares con una membresía de Ahayou existente o reciente podrían no ser elegibles 
                             para ciertas Ofertas introductorias. Podemos utilizar información como el Id. del dispositivo, 
                             la forma de pago o la dirección de email de la cuenta utilizada con una membresía de Ahayou 
                             existente o reciente para determinar la elegibilidad de la Oferta. Los requisitos de elegibilidad 
                             y otras limitaciones y condiciones se le informarán cuando se suscriba a la Oferta o en otras 
                             comunicaciones puestas a su disposición.

                         </p>
                         <p>
                            3.	Facturación y cancelación
                         </p>
                         <p>
                            3.1. Ciclo de facturación. La cuota de membresía por el servicio de Ahayou y cualquier otro cargo en el que incurra en relación con el uso que haga del servicio de Ahayou, como los impuestos y las tarifas de cualquier posible transacción, se cobrarán mediante su Forma de pago en la fecha de pago específica indicada en la página «Cuenta». La duración de su ciclo de facturación dependerá del tipo de membresía que haya seleccionado al suscribirse al servicio. En ciertos casos, su fecha de pago podría cambiar, por ejemplo, si no se pudo hacer el cobro con su Forma de pago satisfactoriamente, cuando cambie su plan de membresía, o si su membresía pagada comenzó un día que no está incluido en un determinado mes. Visite el sitio web Ahayou.com y haga clic en el vínculo «Información de facturación» en la página «Cuenta» para ver su próxima fecha de pago. Podemos autorizar su Forma de pago antes del cobro de los cargos relacionados con la membresía o el servicio a través de varios métodos, e incluso autorizarla durante aproximadamente un mes de servicio desde su registro. Si se suscribió a Ahayou usando su cuenta con un tercero como Forma de pago, puede encontrar la información sobre la facturación de su membresía de Ahayou en su cuenta del servicio del tercero correspondiente.
                         </p>
                        <p>
                           3.2. Formas de pago. Para usar el servicio de Ahayou, debe proveer una o más Formas de pago. Nos autoriza a hacer cargos a cualquier Forma de pago asociada con su cuenta en caso de rechazo o indisponibilidad de su Forma de pago principal para cobrar el cargo de su membresía. Cualquier cargo pendiente le corresponderá a usted. Si el pago no se pudiera hacer satisfactoriamente, debido a la fecha de vencimiento, la falta de fondos u otros motivos, y si usted no cancela su cuenta, podemos suspender su acceso al servicio hasta que obtengamos una Forma de pago válida. Para algunas Formas de pago, el emisor puede cobrarle ciertos cargos, como cargos de transacción extranjera u otros cargos relacionados con el procesamiento de su Forma de pago. Los impuestos locales varían en función de la Forma de pago usada. Consulte con el proveedor de servicios de su Forma de pago para obtener información.
                        </p>
                        <p>
                           3.3. Actualización de sus Formas de pago. Usted puede actualizar su Forma de pago en la página «Cuenta». También podemos actualizar su Forma de pago usando la información provista por los proveedores de servicios de pago correspondientes. Luego de cualquier actualización, nos autoriza a hacer cargos a las Formas de pago correspondientes.
                        </p>
                        <p>
                           3.4. Cancelación. Puede cancelar la membresía de Ahayou en cualquier momento, y continuará teniendo acceso al servicio hasta el final de su periodo de facturación. En la medida permitida por la ley aplicable, los pagos no son reembolsables y no se otorgarán reembolsos ni créditos por los periodos de membresía utilizados parcialmente o por el contenido de Ahayou no usado. Para cancelar, visite la página «Cuenta» y siga las instrucciones de cancelación. Si cancela su membresía, su cuenta se cerrará automáticamente al final de su periodo de facturación actual. Para ver cuándo se cerrará su cuenta, haga clic en «Información de facturación» en la página «Cuenta». Si se suscribió a Ahayou usando su cuenta con un tercero como Forma de pago y desea cancelar su membresía de Ahayou, es posible que tenga que hacerlo a través de dicho tercero, ya sea visitando su cuenta con el tercero correspondiente para desactivar su renovación automática o cancelando la membresía al servicio de Ahayou a través de ese tercero.
                        </p>
                        <p>
                           3.5. Cambios en el precio y planes de membresía. Podemos cambiar nuestros planes de membresía y el precio de nuestro servicio de vez en cuando. Le informaremos los cambios en el precio del servicio o en sus planes de membresía con al menos un mes de anticipación a la fecha de entrada en vigencia. Si no desea aceptar el cambio de precio o la modificación del plan, puede cancelar su membresía antes de que el cambio entre en vigor.
                        </p>
                          <p>
                                4.	Servicio de Ahayou
                            </p>
                         <p>
                            4.1. Debe tener, al menos, 18 años, o la mayoría de edad en su provincia, territorio o país, para ser miembro del servicio de Ahayou. Los menores solamente pueden usar el servicio bajo la supervisión de un adulto.
                         </p>
                        <p>
                           4.2. El servicio de Ahayou y todo el contenido al que se accede en él son solo para uso personal, no comercial, y no debe compartirse con otras personas que no sean miembros de su hogar, a menos que su plan de membresía lo permita. Durante su membresía de Ahayou, le otorgamos un derecho limitado, no exclusivo e intransferible para acceder al servicio y al contenido de Ahayou. Más allá de esto, no se le transferirá ningún otro derecho, título o interés. Usted acepta que no usará el servicio para presentaciones públicas.
                        </p>
                        <p>
                           4.3. Usted puede acceder al contenido de Ahayou principalmente en el país donde estableció su cuenta y solo en los lugares geográficos en los que ofrecemos nuestro servicio y donde se tenga licencia para ese contenido. El contenido que puede estar disponible puede variar según la ubicación geográfica y cambia periódicamente. La cantidad de dispositivos en los que puede ver simultáneamente depende del plan de membresía elegido y se especifica en la página «Cuenta».
                        </p>
                        <p>
                            4.4. El servicio de Ahayou, incluida la biblioteca de contenido, se actualiza con frecuencia, y podremos darle la oportunidad de ver eventos especiales o en vivo (lo que incluye volver a ver ese contenido) o disfrutar de nuevas funciones adicionales. Dicho contenido y las nuevas funciones pueden contener espacios para comerciales y otros tipos de mensajes comerciales. Ahayou no avala ni patrocina ningún producto o servicio anunciado, y cualquier interacción con los anunciantes, incluso a través de la interacción con anuncios interactivos, es por elección suya y a su propio riesgo. Además, probamos regularmente varios aspectos de nuestro servicio, tales como nuestros sitios web, las interfaces de usuario y las funciones promocionales. Usted puede desactivar en cualquier momento su participación en pruebas visitando la página «Cuenta» y cambiando la configuración de «Participación en pruebas».
                        </p>
                        <p>
                           4.5. Parte del contenido de Ahayou está disponible para la descarga temporal y para ver offline en ciertos dispositivos compatibles («Títulos offline»). Se aplican restricciones, incluidas las restricciones a la cantidad de Títulos offline por cada cuenta, la cantidad máxima de dispositivos que pueden contener Títulos offline, el periodo en el cual deberá comenzar a ver los Títulos offline y cuánto tiempo permanecerán accesibles los Títulos offline. Es posible que algunos Títulos offline no se puedan reproducir en determinados países y que, si se conecta en un país en el que no se puede hacer streaming de ese Título offline, dicho título no se pueda reproducir mientras esté en ese país.
                        </p>
                        <p>
                           4.6. Usted acepta usar el servicio de Ahayou, incluidas todas las características y funcionalidades asociadas con este, conforme a lo establecido en todas las leyes, normas y reglamentaciones vigentes, o cualquier otra restricción al uso del servicio o su contenido. Salvo que lo autoricemos explícitamente, usted acepta:
                           <br /> (i) no archivar, reproducir, distribuir, modificar, mostrar, presentar, publicar, otorgar licencias, crear obras derivadas, ofrecer en venta, o usar contenido e información contenida en el servicio de Ahayou, u obtenida de o a través de él;
                           <br /> (ii) no eludir, eliminar, alterar, desactivar, disminuir, bloquear, ocultar ni obstaculizar ninguna de las medidas de protección de contenido u otros elementos del servicio de Ahayou, incluida la interfaz gráfica de usuario, los avisos de derechos de autor y las marcas comerciales;
                            <br />(iii) no usar ningún robot, spider, scraper u otra forma automatizada para acceder al servicio de Ahayou; ni descompilar, realizar ingeniería inversa, desarmar el software u otro producto o proceso a los que se acceda a través del servicio de Ahayou;
                            <br />(iv) no introducir de ninguna manera un código o producto ni manipular el contenido del servicio de Ahayou;
                            <br />(v) no usar método alguno de minería, recolección o extracción de datos;
                            <br />(vi) no subir, publicar, enviar por email ni transmitir de cualquier otra forma ningún material diseñado para interrumpir, destruir o limitar la funcionalidad del software o hardware de computación, o equipos de telecomunicaciones asociados con el servicio de Ahayou, incluido material que contenga virus de software o cualquier otro código, archivos o programas.
                            <br />Podríamos cancelar o restringir su uso de nuestro servicio si usted viola estos Términos de uso o está involucrado en el uso del servicio de forma ilegal o fraudulenta.
                        </p>
                         <p>
                            4.7. La calidad de la imagen del contenido de Ahayou puede variar de dispositivo a dispositivo y puede verse afectada por diversos factores, tales como la ubicación, el ancho de banda disponible o la velocidad de la conexión a internet. La disponibilidad del contenido en alta definición (HD), ultra alta definición (Ultra HD) y alto rango dinámico (HDR) depende de su servicio de internet y del dispositivo en uso. No todo el contenido está disponible en todos los formatos, como HD, Ultra HD o HDR, ni todos los planes de membresía le permiten recibir contenido en todos los formatos. La velocidad de conexión mínima para obtener una calidad de video HD (definida como una resolución de 720p o superior) es de 3.0 Mb/s por stream. Sin embargo, recomendamos una conexión más rápida para mejorar la calidad de video. Se recomienda una velocidad de conexión de, al menos, 5.0 Mb/s por stream para recibir contenido con calidad de video Full HD (definida como una resolución de 1080p o superior). Se recomienda una velocidad de conexión de, al menos, 15.0 Mb/s por stream para recibir contenido con calidad de video Ultra HD (definida como una resolución de 4K o superior). Usted es responsable de todos los cargos por acceso a internet. Solicite a su proveedor de internet información acerca de los posibles cargos de consumo de datos por uso de internet. El tiempo que lleva comenzar a ver contenido de Ahayou variará según diversos factores, incluidos su ubicación, el ancho de banda disponible en ese momento, el contenido que haya seleccionado y la configuración de su dispositivo listo para Ahayou.
                            </p>
                           <p>
                            4.8. El software de Ahayou es desarrollado por Ahayou o para Ahayou, y solamente puede ser utilizado para el streaming autorizado y para acceder al contenido de Ahayou a través de dispositivos listos para Ahayou. Este software puede variar según el dispositivo y el medio, y las funcionalidades y las características también pueden variar de un dispositivo a otro. Usted reconoce que el uso del servicio puede requerir software de terceros que esté sujeto a licencias de terceros. Usted acepta que puede recibir automáticamente versiones actualizadas del software de Ahayou y el software relacionado de terceros.
                            </p>
                          <p>
                            5.	Contraseñas y acceso a la cuenta. Usted es responsable de cualquier actividad que ocurra en la cuenta de Ahayou. Al permitir que otras personas accedan a la cuenta (lo que incluye el acceso a la información sobre la actividad de visualización de la cuenta), usted acepta que dichas personas actúan en su nombre y que tendrá que aceptar cualquier cambio que puedan realizar en la cuenta, incluidos, entre otros, los cambios en el plan de membresía. Para ayudar a mantener el control sobre la cuenta y evitar que cualquier usuario no autorizado acceda a esta, debe mantener el control sobre los dispositivos que se utilizan para acceder al servicio, y no revelar a nadie la contraseña o los detalles de la Forma de pago asociada a la cuenta. Usted se compromete a proporcionar y mantener información precisa en relación con su cuenta, incluida una dirección de email válida para que podamos enviarle notificaciones acerca de su cuenta. Podemos cancelar su cuenta o suspenderla para protegerlo a usted, a Ahayou o a nuestros socios contra el robo de identidad u otra actividad fraudulenta.
                            </p>
                         <p>
                               6.	Exclusión de garantías y limitaciones a la responsabilidad. El servicio de Ahayou se ofrece «tal cual», sin garantía ni condición. En particular, nuestro servicio no se declara sin interrupciones ni sin errores. Usted renuncia a todos los daños especiales, indirectos y consecuentes contra nosotros. Estos términos no limitarán las garantías no renunciables ni los derechos de protección al consumidor a los que usted tenga derecho bajo las leyes obligatorias de su país de residencia.
                               </p>
                         <p>
                           7.	Renuncia a la acción colectiva. EN LA MEDIDA EN QUE LAS LEYES APLICABLES LO PERMITAN, USTED Y AHAYOU ACUERDAN QUE CADA UNO PUEDE PRESENTAR RECLAMOS CONTRA LA OTRA PARTE SOLO EN NOMBRE PROPIO, Y NO COMO ACTORA O PARTE DE UN GRUPO EN UNA ACCIÓN COLECTIVA O REPRESENTATIVA. Además, si la ley aplicable lo permite, a menos que tanto usted como Ahayou acuerden lo contrario, el tribunal no podrá acumular las causas de más de una persona con su causa o, de lo contrario, no podrá presidir ninguna acción representativa o colectiva.
                           </p>
                         <p>
                           8.	Disposiciones varias
                           </p>
                         <p>
                           8.1. Ley vigente. Estos Términos de uso se regirán e interpretarán de conformidad con las leyes del estado de Delaware, EE. UU., sin perjuicio de cualquier disposición de derecho internacional privado sobre conflicto de intereses. Estos términos no limitarán los derechos de protección al consumidor que le correspondan bajo las leyes obligatorias de su país de residencia.
                           </p>
                         <p>
                           8.2. Material no solicitado. Ahayou no acepta materiales ni ideas no solicitados para su contenido, y no es responsable por la similitud entre los contenidos o la programación de cualquier medio con los materiales o ideas transmitidos a Ahayou.
                           </p>
                                                 <p>
                           8.3. Servicio al Cliente. Si necesita obtener más información sobre nuestro servicio y sus funciones, o si necesita asistencia con su cuenta, visite el Centro de ayuda de Ahayou, al que puede acceder a través del sitio web Ahayou.com. En algunos casos, el Servicio al Cliente podrá ayudarlo mejor utilizando una herramienta de asistencia de acceso remoto con la que se accede completamente a su computadora. Si no desea que tengamos este acceso, usted no debería autorizar la asistencia a través de la herramienta de acceso remoto, y nosotros le ayudaremos de otra forma. En el caso en que haya un conflicto entre estos Términos de uso y la información proporcionada por el Servicio al Cliente u otras secciones de nuestros sitios web, estos Términos de uso dirimirán cualquier diferencia.
                           </p>
                                                 <p>
                           8.4. Vigencia. Si alguna o algunas de las disposiciones de estos Términos de uso es declarada nula, ilegal o inaplicable, la validez, legalidad y aplicabilidad de las restantes disposiciones continuarán en plena vigencia.
                           </p>
                                                 <p>
                           8.5. Cambios en los Términos de uso y Cesión. Ahayou puede cambiar estos Términos de uso cuando sea necesario. En caso de cambios materiales, le informaremos con al menos un mes de anticipación a que dichos cambios le sean aplicables. Si no desea aceptar los cambios, puede cancelar su membresía antes de que estos entren en vigor. Podemos ceder o transferir nuestro acuerdo con usted, incluidos nuestros derechos y obligaciones asociadas, en cualquier momento y usted acepta cooperar con nosotros en relación con dicha cesión o transferencia.
                           </p>
                                                 <p>
                           8.6. Comunicaciones electrónicas. Le enviaremos la información relativa a su cuenta (por ejemplo, las autorizaciones de pago, las facturas, los cambios de contraseña o de la Forma de pago, los mensajes de confirmación, los avisos) de manera electrónica únicamente, por ejemplo, mediante emails a la dirección de email proporcionada durante el registro.
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
