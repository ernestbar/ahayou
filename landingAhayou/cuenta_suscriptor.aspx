<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="cuenta_suscriptor.aspx.cs" Inherits="landingAhayou.cuenta_suscriptor" %>

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
        <link rel="stylesheet" href="css/forms.css" />
        <link rel="stylesheet" href="css/vanilla-page.css" />
        <link rel="stylesheet" href="css/default-background.css" />
        <link rel="stylesheet" href="css/containers.css" />
        <link rel="stylesheet" href="css/footer.css" />
        <link rel="stylesheet" href="css/buttons.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/search-results.css" />
     <link rel="stylesheet" href="css/plans.css" />
        <link rel="stylesheet" href="css/arrow.css" />
        <link rel="stylesheet" href="css/header-movies.css" />
        <link rel="stylesheet" href="css/hamburger.css" />
        <link rel="stylesheet" href="css/ribbon.css" />
        <link rel="stylesheet" href="css/playlist.css" />
    <link rel="stylesheet" href="css/profiles.css" />
        <%--<link rel="stylesheet" href="css/backgrounds-divs.css" />--%>

</head>
<body>
    <form id="form1" runat="server">
       
        <asp:ObjectDataSource ID="odsMenus" runat="server" SelectMethod="PR_PAR_GET_MENU_CARTELERA" TypeName="landingAhayou.Clases.Carteleras">
        </asp:ObjectDataSource>
       <asp:ObjectDataSource ID="odsAvataresEdicion" runat="server" SelectMethod="PR_PAR_GET_AVATARES" TypeName="landingAhayou.Clases.Avatares">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPlanes" runat="server" SelectMethod="PR_PAR_GET_PLAN_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblUsuario" Name="nombre_usuario" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
         <asp:ObjectDataSource ID="odsSesiones" runat="server" SelectMethod="PR_GET_DISPOSITIVOS_SESION" TypeName="landingAhayou.Clases.Sesiones">
             <SelectParameters>
                 <asp:ControlParameter ControlID="lblUsuario" Name="pV_USUARIO" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsRedesSociales" runat="server" SelectMethod="PR_PAR_GET_REDES_SOCIALES_STR" TypeName="landingAhayou.Clases.Contenidos">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsAvatares" runat="server" SelectMethod="PR_PAR_GET_PERFILES_SUSCRIPTOR" TypeName="landingAhayou.Clases.Suscriptores">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblplanSuscriptor" Name="pV_COD_PLAN_SUSCRIPTOR" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblMundo" runat="server" Visible="false" Text="BO"></asp:Label>
        <asp:Label ID="lblUsuario1" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblplanSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblPerfilSuscriptor" runat="server" Visible="false" Text=""></asp:Label>
        <asp:Label ID="lblCodigoPlan" runat="server" Visible="false" Text=""></asp:Label>
        
          <header class="header">
            <nav class="header__nav">
                <a href="cartelera.aspx" class="header__logo">
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
                                type="button" onclick="location.href='suscribete.aspx';">
                                  Suscr&iacute;bete
                              </button>
                              <button
                                  class="header__button header__button--text header__button--bg-green"
                               type="button" onclick="location.href='login.aspx';">
                                  Iniciar Sesi&oacute;n
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
         
                              <input class="options__button" type="button" onclick="location.href='home.aspx';" value="Español" />
                            <input class="options__button" type="button" onclick="location.href='home_us.aspx';" value="Ingles" />
                            <input class="options__button" type="button" onclick="location.href='suscribete.aspx';" value="Suscribete" />
                            <input class="options__button" type="button" onclick="location.href='login.aspx';" value="Login" />
                         </div>
                     </div>
                    <asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label>
                </asp:Panel>
               <%-- <div class="form__input-container form__input-container--main form__input-container--no-gap">
                    <asp:TextBox ID="txtBuscqueda" Width="300" Height="30" class="form__input form__input--dark" placeholder="Ingresa tu busqueda" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBusqueda" Height="30" Font-Size="Small" class="button button--orange button--border" OnClick="btnBusqueda_Click"  runat="server" Text="Buscar" />
     
                </div>--%>
                
                
                <asp:Panel ID="Panel_login" class="header__nav-buttons submenu__container options__container--second" runat="server">
                    <asp:ImageButton class="header__button header__button--with-img submenu__button" ID="imgPerfil" runat="server" />
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
                                     Cuenta
                                 </p>

                            </asp:LinkButton>
        
           
                            <a href="cuenta_suscriptor.aspx" class="options__button--flex">
                                <img
                                    src="imgs/flags/spain.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Idioma español
                                </p>
                            </a>
                            <a href="cuenta_suscriptor_us.aspx" class="options__button--flex">
                                <img
                                    src="imgs/flags/eeuu.png"
                                    alt="Foto perfil"
                                />
                                <p class="text--small text text--light">
                                    Idioma ingles
                                </p>
                            </a>
                        </div>
    
                        <asp:Repeater ID="Repeater8" DataSourceID="odsMenus" runat="server">
                         <ItemTemplate>
                             <asp:Button ID="btnMenu" class="options__button--last text--light text--center text--small" CommandArgument='<%# Eval("cod_formato_contenido") %>' OnClick="btnMenu_Click" runat="server" Text='<%# Eval("formato_contenido") %>' />
                         </ItemTemplate>
                     </asp:Repeater>
                        <asp:Button class="options__button--last text--light text--center text--small" OnClick="btnCerrar_Click" ID="btnCerrar" runat="server" Text="Cerrar Sessión" />
    
                    </div>
        
                </asp:Panel>
            </nav>
             </header>


        


            <main class="main main--flex">
                
            <section
                    class="container__wrapper container--shiny container--padding-width"
                >
                      
                         <asp:Repeater ID="Repeater2" DataSourceID="odsPlanes" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSeleccionPlan" OnClick="lbtnSeleccionPlan_Click" class="plans__item" runat="server">
                                    <div class="plans__item--type-2">
                                       <div class="plans__item-content container-common">
                                            <div
                                                class="arrow green absolute arrow__corner"
                                            ></div>
                                            <h3 class="plans__item-title">
                                                <%# Eval("planes") %>
                                            </h3>
                                            
                                        </div>
                                       <div class="plans__item-price container-common">
                                            <div>
                                                <span class="bs"> <%# Eval("cod_moneda") %></span>
                                                <div class="price__content">
                                                    <span class="price__description">Pago &uacute;nico</span>
                                                    <span class="price__number"><%# Eval("monto") %></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="plans__item-footer">
                                        <p>PRESIONA PARA CAMBIAR O RENOVAR TU PLAN</p>
                                    </div>
                                    </asp:LinkButton>
                            </ItemTemplate>
                         </asp:Repeater>
               
            <span class="text text--light text--center full-width"
                ></span
            >
            <h1>Datos generales de la cuenta</h1>
            <p class="text text--center text--light">
                Puedes actualizar los siguientes datos de tu cuenta. AHAYOU está personalizado para ti.
            </p>
                <form class="form container--shiny container--padding-width" id="form">
                     <div class="form__input-container">
                         <label
                             for="email"
                             class="form__label form__label--second"
                         >
                             Cuenta
                         </label>
                         <asp:Label ID="lblCuenta"  class="form__label form__label--second" runat="server" Text=""></asp:Label>
                     </div>
                    <div class="form__input-container">
                        <label
                            for="email"
                            class="form__label form__label--second"
                        >
                            Celular
                        </label>
                        <asp:TextBox class="form__input form__input--dark" ID="txtCelular" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="datosgenerales"  ControlToValidate="txtCelular" runat="server" ErrorMessage="* Campo requerido" ForeColor="Orange"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form__input-container">
                        <label
                            for="email"
                            class="form__label form__label--second"
                        >
                            Nombre completo
                        </label>
                        <asp:TextBox class="form__input form__input--dark" ID="txtNombreCompleto" ValidationGroup="datosgenerales" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="datosgenerales"  ControlToValidate="txtNombreCompleto" runat="server" ErrorMessage="* Campo requerido" ForeColor="Orange"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form__input-container">
                        <label
                            for="email"
                            class="form__label form__label--second"
                        >
                            Codigo auxiliar
                        </label>
                        <asp:TextBox class="form__input form__input--dark" ValidationGroup="datosgenerales"  ID="txtCodigo_aux" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button class="button button--orange full-width button--border" ValidationGroup="datosgenerales" OnClick="btnGuardar_Click"   ID="btnGuardar" runat="server"  Text="Guardar datos generales" />
                    <asp:LinkButton ID="lbtnCmabiarPass" Font-Size="X-Large" ForeColor="Orange" OnClick="lbtnCmabiarPass_Click" runat="server">Cambiar Contrase&ntilde;a</asp:LinkButton>
                    <asp:LinkButton ID="lbtnSolicitarPIN" Font-Size="X-Large"  ForeColor="Orange" OnClick="lbtnSolicitarPIN_Click" runat="server">Presiona y enviaremos un nuevo PIN a tu email</asp:LinkButton>
                    <div class="form__input-container">
                        <label
                            for="password"
                            class="form__label form__label--second"
                        >
                           Presiona en el perfil que deseas editar
                            
                        </label>
                        <asp:Panel ID="Panel_perfil" runat="server">
                             <section class="profiles" style="width:70px">
                               <asp:Repeater ID="Repeater1" DataSourceID="odsAvatares" runat="server">
                             <ItemTemplate>
                                 <asp:LinkButton class="profiles__item" ID="lbtnPerfil" OnClick="lbtnPerfil_Click" CommandArgument='<%# Eval("cod_perfil_suscriptor")+"|"+ Eval("pin")+"|"+ Eval("nombre_perfil") %>'  runat="server"> <img
                                          src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                          alt="Foto de perfil"
                                          class="profiles__item-image"
                                      />
                                      <span class="profiles__item-text"><%# Eval("nombre_perfil") %></span>
                                 </asp:LinkButton>

                             </ItemTemplate>
                               </asp:Repeater>
                            </section>
                        </asp:Panel>
                        <asp:Panel ID="Panel_perfil_edicion" Visible="false" runat="server">
                            <asp:Label ID="lblCodPerfilEdicion" runat="server" Visible="false" Text=""></asp:Label>
                             <asp:Label ID="lblPinEdicion" runat="server" Visible="false" Text=""></asp:Label>
                            <div class="form__input-container">
                                <label
                                    for="email"
                                    class="form__label form__label--second"
                                >
                                    Nombre perfil
                                </label>
                                <asp:TextBox class="form__input form__input--dark" ID="txtNombrePerfil" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="avatares"  ControlToValidate="txtNombrePerfil" runat="server" ErrorMessage="* Campo requerido" ForeColor="Orange"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form__input-container">
                            <label
                                for="email"
                                class="form__label form__label--second"
                            >
                                Selecciona tu avatar
                            </label>
                                <asp:Label ID="lblCodigoAvatarSeleccion" runat="server" Visible="false" Text=""></asp:Label>
                                <div
                                        class="container--flex container--justify-content-start playlist__movies carousel__list" style="width:600px;overflow-x:scroll;"
                                    >
                                <asp:Repeater ID="Repeater4" DataSourceID="odsAvataresEdicion" runat="server">
                                   <ItemTemplate>
                                         <asp:LinkButton class="profiles__item" ID="lbtnSeleccionAvatar" OnClick="lbtnSeleccionAvatar_Click" CommandArgument='<%# Eval("codigo_avatar") %>'  runat="server"> <img
                                                  src='<%# "data:image/jpg;base64," + Eval("AVATAR") %>'
                                                  alt="Foto de perfil"
                                                  class="profiles__item-image"
                                              />
                                                  <span class="profiles__item-text"><%# Eval("codigo_avatar") %></span>
                                            </asp:LinkButton>
                                   </ItemTemplate>
                            </asp:Repeater>
                                    </div>
                                
                                <asp:Button class="button button--orange full-width button--border" ValidationGroup="avatares" OnClick="btnEdicionAvatar_Click"   ID="btnEdicionAvatar" runat="server"  Text="Guardar perfil" />
                        </div>
                        </asp:Panel>
                            


                    </div>
                    
                        <div class="form__input-container">
                                <label
                                    for="email"
                                    class="form__label form__label--second"
                                >
                                    Dispositivos activos con tu cuenta
                                </label>
                                   <table style="" border="1" cellpadding="0">
                                       <thead>
                                           <tr>
                                               <th class="text-wrap">Dispositivo</th>
                                               <th class="text-wrap">Fecha</th>
                                               <th class="text-wrap" data-orderable="false">OPCIONES</th>
                                               </tr>
                                           </thead>
                                       <tbody>
                                        <asp:Repeater ID="Repeater3" DataSourceID="odsSesiones" runat="server">
                                           <ItemTemplate>
                                                 <tr class="gradeA">
                                                     <td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("dispositivo") %>'></asp:Label></td>
										             <td><asp:Label ID="lblEsPrincipal2" runat="server" Text='<%# Eval("FechaLogin") %>'></asp:Label></td>
										             <td>
                                                         <asp:ImageButton ID="ibtnEliminarSession" ImageUrl="~/Images/Icons/Plomos/delete.png" Height="20" ToolTip="Eliminar dispositivo" OnClick="ibtnEliminarSession_Click" CommandArgument='<%# Eval("idsesion") %>' runat="server" />
										             </td>
                                                </tr>
                                           </ItemTemplate>
                                    </asp:Repeater>
                                      </tbody>
                                </table>      
                            </div>
                
                    <asp:LinkButton ID="lbtnEliminarSuscriptor" OnClick="lbtnEliminarSuscriptor_Click" OnClientClick="return confirm('Estas seguro de eliminar tu usuario, si lo haces ya no podras disfrutar del contenido de Ahayou')" runat="server"><p class="text text--orange">Eliminar mi cuenta</p></asp:LinkButton>                              
   
                </form>
                  </section>
   
        
           <%-- <section class="profiles">--%>
             
        
                </main>
                <footer class="footer playlist__footer">
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

       
        

          <script src="js/header-background-handler.js"></script>
        <script src="js/carousel-header-index.js"></script>
        <script defer src="js/carousel.js"></script>
        <script src="js/open-menu.js"></script>
        <script src="js/open-submenu.js"></script>
        <script src="js/header-movies-responsive.js"></script>
        <script src="js/movie-container-hover.js"></script>

    </form>
</body>
</html>