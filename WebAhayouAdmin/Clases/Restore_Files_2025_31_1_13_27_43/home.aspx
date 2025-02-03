<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<%@ Register Src="~/Common/AttachmentsWebUserControl.ascx" TagPrefix="uc1" TagName="AttachmentsWebUserControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <meta http-equiv="refresh" content="90">--%>

    <asp:HiddenField ID="SuperCategoriaIdHiddenField1" runat="server" Value="0" />
    <asp:HiddenField ID="UsuarioIdHiddenField1" runat="server" Value="0" />
    <asp:HiddenField ID="PerfilHiddenField1" runat="server" Value="0" />
    <div class="container-fluid" style="background-color: #000000">
        <style>
            /* width */
            ::-webkit-scrollbar {
                width: 8px;
            }

            /* Track */
            ::-webkit-scrollbar-track {
                box-shadow: inset 0 0 5px grey;
                border-radius: 5px;
            }

            /* Handle */
            ::-webkit-scrollbar-thumb {
                background: rgba(77,77,77,.99);
                border-radius: 5px;
            }

                /* Handle on hover */
                ::-webkit-scrollbar-thumb:hover {
                    background: #66cc99 !important;
                }
        </style>
        <style>
            .img-responsive {
                min-width: 30%;
                max-width: 100%;
            }

            .text-white {
                /* text-shadow: 2px 2px 5px black;*/
                /* color: white;*/
            }

            .subrayado {
                /*border-bottom: 5px #660098;*/
                text-decoration-line: underline;
                text-decoration-thickness: 5px;
                /*text-decoration-color: #660098;*/
                /* text-decoration-color: #660098;*/
                text-decoration-color: #33ffcc;
            }

            .btnlila {
                /*                background-color: #660099;
                border-color: #660099;*/
                /*       background-color: #33ffcc;
                border-color: #33ffcc;*/
            }

            #wowza_player {
                width: 560px;
            }

            .flowplayer {
                width: 560px !important;
            }

            .bItem {
                z-index: 2;
                display: flex;
                justify-content: flex-end;
                flex-direction: column;
                position: absolute;
                top: 0;
                right: 9px;
                bottom: 0;
                left: 9px;
                padding: 18px;
                /*background-size: auto;*/
                /*  background-position: center center;*/
                background-repeat: no-repeat;
                background-attachment: fixed;
                background-position: fixed;
                /* background-image: url(http://kenwheeler.github.io/slick/img/fonz1.png);*/
                /* background: linear-gradient(217deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%), linear-gradient(127deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%), linear-gradient(336deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%);*/

                background-size: cover !important;
                -webkit-background-size: cover;
                -moz-background-size: cover;
                -o-background-size: cover;
                /*background-attachment: fixed !important;*/
                /* background-position: left top;*/
                background-attachment: scroll;
            }

            /*.bItem::after {
                    content: "";
                    position: fixed;*/ /* stretch a fixed position to the whole screen */
            /*top: 0;
                    height: 100vh;*/ /* fix for mobile browser address bar appearing disappearing */
            /*left: 0;
                    right: 0;
                    z-index: -1;*/ /* needed to keep in the background */

            /*-webkit-background-size: cover;
                    -moz-background-size: cover;
                    -o-background-size: cover;
                    background-size: cover;
                }*/

            .carousel-indicators li {
                box-sizing: content-box;
                -ms-flex: 0 1 auto;
                flex: 0 1 auto;
                width: 30px;
                height: 33px;
                margin-right: 3px;
                margin-left: 3px;
                text-indent: -999px;
                cursor: pointer;
                background-color: #fff;
                background-clip: padding-box;
                border-top: 10px solid transparent;
                border-bottom: 10px solid transparent;
                opacity: .5;
                transition: opacity 0.6s ease;
            }

            .Resumen {
                font-size: 1.1rem;
            }
        </style>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT TOP (4) PeliculaId, Peliculas.CategoriaId, Peliculas.Nombre, Resumen, InformacionPelicula, Director, Reparto, Edad, LogoPelicula, FotoMiniatura, FotoCompletaHorizontal, FotoCompletaVertical, Pais, IdiomaOriginal, Comentarios, TipoDeAudio, Creditos, FechaCreacion, Creador, Estado, FechaInicio, FechaFinal, EsCover, LadoCover FROM Peliculas JOIN Categorias ON Peliculas.CategoriaId = Categorias.CAtegoriaId AND Peliculas.Estado = 'Publicado' JOIN SuperCategorias ON Categorias.SuperCategoriaId = SuperCategorias.SupercategoriaID WHERE (Estado = 'Publicado') AND (SuperCategorias.SupercategoriaID = @SuperCategoriaID OR @SuperCategoriaId = 0) ORDER BY PeliculaId">
            <SelectParameters>
                <asp:ControlParameter ControlID="SuperCategoriaIdHiddenField1" PropertyName="Value" Name="SuperCategoriaId" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>



        <%--    <div id='wowza_player'></div> 
    <script id='player_embed' src='//player.video.wowza.com/hosted/jbt46tpj/wowza.js' type='text/javascript'></script>--%>
        <div class="container-fluid animated fadeIn">
            <div class="banner3" style="width: 100%; min-height: 1025px; max-width: 1920px; margin: auto; overflow: hidden" runat="server" visible="false" id="suscribeUnlogged">
                <div class="container-fluid banner5x banner4" style="min-height: 1025px; max-height: 100%">
                    <style>
                        .banner3 {
                            /* background-image: url("../Images/banner4.png");*/
                            background-color: black;
                            background-size: 100%;
                            background-repeat: no-repeat;
                            background-size: cover; /* Ensures the image covers the entire area */
                            background-position: center; /* Center the image horizontally and vertically */
                        }

                        .banner4 {
                            background-image: url("../Images/DivisionVerde.png");
                            background-size: 140% !important;
                            background-repeat: no-repeat;
                            background-size: cover; /* Ensures the image covers the entire area */
                            background-position: bottom; /* Center the image horizontally and vertically */
                        }

                        .banner5 {
                            background-image: url("../Images/banner5.png");
                            background-size: 100%;
                            background-repeat: no-repeat;
                            background-size: cover; /* Ensures the image covers the entire area */
                            background-position: center; /* Center the image horizontally and vertically */
                        }

                        .img-responsive {
                            min-width: 30%;
                            max-width: 100%;
                        }

                        .text-white {
                            /*     text-shadow: 2px 2px 5px black;*/
                        }

                        .subrayado {
                            /*                border-bottom: 5px #660098;*/
                            text-decoration-line: underline;
                            text-decoration-thickness: 5px;
                            /*text-decoration-color: #660098;*/
                            text-decoration-color: #33ffcb;
                        }

                        .btnlila {
                            color: #cccccc;
                            /*   
                            background-color: #000000;
                            border-color: #000000;*/
                        }

                        .bItem {
                            z-index: 2;
                            display: flex;
                            justify-content: flex-end;
                            flex-direction: column;
                            position: absolute;
                            top: 0;
                            right: 9px;
                            bottom: 0;
                            left: 9px;
                            padding: 18px;
                            background-size: auto;
                            background-position: center center;
                            background-repeat: no-repeat;
                            background-attachment: fixed;
                            background-position: center top;
                            /* background-image: url(http://kenwheeler.github.io/slick/img/fonz1.png);*/
                            /* background: linear-gradient(217deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%), linear-gradient(127deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%), linear-gradient(336deg, rgba(0,0,0,.9), rgba(0,0,0,0) 70.71%);*/
                        }

                        /*.bItem::after {
                content: '';
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                background: linear-gradient(217deg, rgba(255,0,0,.1), rgba(0,0,0,0) 70.71%), linear-gradient(127deg, rgba(0,0,0,.1), rgba(0,0,0,0) 70.71%), linear-gradient(336deg, rgba(0,0,0,.1), rgba(0,0,0,0) 70.71%);
            }*/

                        .glass-container {
                            /* Set container size and desired positioning */
                            /*                width: 200px;
            height: 150px;*/
                            position: relative;
                            /* Create the glass background effect */
                            background: rgba(255, 255, 255, 0.3); /* Adjust transparency as needed */
                            backdrop-filter: blur(5px); /* Blur effect for frosted glass */
                            /* Add the diagonal effect using a linear gradient */
                            background-image: linear-gradient(to bottom right, rgba(0, 0, 0, 0.5), /* Adjust transparency for top side */
                            transparent); /* Transparent for bottom side */
                        }
                    </style>

                    <br />
                    <br />
                    <div class="animated slideInUp" style="padding: 10px">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div style="color: white">
                            <center>
                                <h1 style="font-size: 3.5em; margin-bottom: 5px">Disfruta de
                            <br />
                                    contenido exclusivo
                                </h1>
                                Listo para entrar en el mundo de Ahayou? Ingresa tu email para crear una cuenta.<br />
                                <br />
                                <table style="width: 100%">
                                    <tr>

                                        <td>
                                            <div style="width: 100%">

                                                <div style="margin: auto; max-width: 500px">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: right; display: flex; justify-content: flex-end;">
                                                                <asp:TextBox ID="TextBox1" placeholder="Correo" CssClass="form-control" Style="margin-right: 0; border-radius: 3px 0px 0px 3px; width: 100%; max-width: 450px; line-height: 2" runat="server"></asp:TextBox></td>
                                                            <td>
                                                                <%--<asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text=" Suscríbete  > " Style="margin-left: -2px; border-radius: 0px 3px 3px 0px; width: 100%; max-width: 250px; line-height: 2" OnClick="Button1_Click" /></td>--%>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>

                                </table>




                            </center>
                        </div>
                        <br />


                    </div>

                </div>

            </div>
            <%--     <div class="container-fluid " style="">
                      
                 <img src="Images/DivisionVerde.png" />
                    
              </div>--%>
            <div style="width: 100%; margin: auto; background-color: #000; min-height: 700px; max-height: 1100px;" runat="server" visible="true" id="carouselLogged">


                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3" aria-label="Slide 4"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="4" aria-label="Slide 5"></button>
                    </div>
                    <div class="carousel-item active" style="background-color: #000; min-height: 700px; max-height: 1100px;">

                        <style>
                            .classA {
                                z-index: 1;
                                background-position: center;
                                background-image: linear-gradient(0deg, rgba(0,0,0,1), rgba(0,0,0,0) 30%), linear-gradient(270deg, rgba(77,77,77,.99), rgba(77,77,77,0) 0%), linear-gradient(90deg, rgba(77,77,77,.99), rgba(77,77,77,0) 0%), linear-gradient(360deg, rgba(77,77,77,.99), rgba(77,77,77,0) 50%), url('/Images/FondoPipocas.png') !important;
                            }
                        </style>
                        <div class="bItem classA">
                            <div id="pan1" class="" style="vertical-align: bottom; z-index: 10; margin: auto; min-width: 50%; max-width: 100%; width: 100%; /*max-width: 900px; */ min-height: 800px; max-height: 1100px;">
                                <br />
                                <br />



                                <%--<asp:Label CssClass="text-white subrayado" Text='<%# Eval("Nombre") %>' Visible="true" Font-Size="XX-Large" runat="server" ID="NombreLabel" />--%>
                                <div class="row" style="/*text-align: right; display: flex; justify-content: flex-end; */">
                                    <div class="col-md-4">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />

                                    </div>
                                    <div class="col-md-8">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div style="text-align: center; display: block;">
                                            <br />
                                           <br />
                                            <br />
                                            <div >
                                                <div style="margin:auto;max-width:500px">
                                            <table style="width:100%">
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Image ImageUrl="~/Images/IconoCuadrados.png" Width="120" Height="120" Style="min-width: 30px !important" ID="Image9" runat="server" />
                                                    </td>
                                                    <td>
                                                        <span style="font-size: 2.1em; color: white">Bienvenidos
                                                            <br />
                                                            <b>al Streaming</b> con<br />
                                                            <b>Alma Boliviana</b>

                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                                </div>

                                        </div>

                                        </div>

                                    </div>
                                </div>
                                <hr style="border-top: 1px solid rgba(0, 0, 0, 0.0);" />

                            </div>
                        </div>

                    </div>
                    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" Visible="true" DataKeyNames="PeliculaId">

                        <EmptyDataTemplate>
                            <span></span>
                        </EmptyDataTemplate>

                        <ItemTemplate>
                            <div class="carousel-item <%# (Container.DataItemIndex +1 == 0  )? "active": "" %>" style="background-color: #000; min-height: 700px; max-height: 1100px;">
                                <%-- <center>--%>

                                <asp:Label Text='<%# Eval("PeliculaId") %>' Visible="false" runat="server" ID="PeliculaIdLabel" />
                                <asp:Label Text='<%# Eval("CategoriaId") %>' Visible="false" runat="server" ID="CategoriaIdLabel" />

                                
                                <div class="bItem class<%# Container.DataItemIndex %>">
                                    <div id="pan1" class="" style="vertical-align: bottom; z-index: 10; margin: auto; min-width: 50%; max-width: 100%; width: 100%; /*max-width: 900px; */ min-height: 800px; max-height: 1100px;">
                                        <br />
                                        <br />



                                        <%--<asp:Label CssClass="text-white subrayado" Text='<%# Eval("Nombre") %>' Visible="true" Font-Size="XX-Large" runat="server" ID="NombreLabel" />--%>
                                        <div class="row" style="/*text-align: right; display: flex; justify-content: flex-end; */">
                                            <div class="col-md-4">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />

                                            </div>
                                            <div class="col-md-8">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                          
                                            </div>
                                        </div>
                                        <hr style="border-top: 1px solid rgba(0, 0, 0, 0.0);" />
                                        <asp:Label CssClass="text-white" Text='<%# Eval("Pais") %>' Visible="false" runat="server" ID="Label1" /><br />
                                        <%--&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                    </div>
                                </div>
                                <%--<asp:Image CssClass="d-block w-100a " ImageUrl='<%# System.Web.VirtualPathUtility.ToAbsolute("~/") +  "Files/" + fileName("FotoHorizontalPelicula", Eval("PeliculaId").ToString()) %>' ID="Image1" runat="server" />--%>
                                <asp:Label Text='<%# Eval("Resumen") %>' Visible="false" runat="server" ID="ResumenLabel" />
                                <asp:Label Text='<%# Eval("InformacionPelicula") %>' Visible="false" runat="server" ID="InformacionPeliculaLabel" />
                                <asp:Label Text='<%# Eval("Director") %>' Visible="false" runat="server" ID="DirectorLabel" />
                                <asp:Label Text='<%# Eval("Reparto") %>' Visible="false" runat="server" ID="RepartoLabel" />
                                <asp:Label Text='<%# Eval("Edad") %>' Visible="false" runat="server" ID="EdadLabel" />
                                <asp:Label Text='<%# Eval("LogoPelicula") %>' Visible="false" runat="server" ID="LogoPeliculaLabel" />
                                <asp:Label Text='<%# Eval("FotoMiniatura") %>' Visible="false" runat="server" ID="FotoMiniaturaLabel" />
                                <asp:Label Text='<%# Eval("FotoCompletaHorizontal") %>' Visible="false" runat="server" ID="FotoCompletaHorizontalLabel" />
                                <asp:Label Text='<%# Eval("FotoCompletaVertical") %>' Visible="false" runat="server" ID="FotoCompletaVerticalLabel" />
                                <asp:Label Text='<%# Eval("Pais") %>' Visible="false" runat="server" ID="PaisLabel" />
                                <asp:Label Text='<%# Eval("IdiomaOriginal") %>' Visible="false" runat="server" ID="IdiomaOriginalLabel" />
                                <asp:Label Text='<%# Eval("Comentarios") %>' Visible="false" runat="server" ID="ComentariosLabel" />
                                <asp:Label Text='<%# Eval("TipoDeAudio") %>' Visible="false" runat="server" ID="TipoDeAudioLabel" />
                                <asp:Label Text='<%# Eval("Creditos") %>' Visible="false" runat="server" ID="CreditosLabel" />
                                <asp:Label Text='<%# Eval("FechaCreacion") %>' Visible="false" runat="server" ID="FechaCreacionLabel" />
                                <asp:Label Text='<%# Eval("Creador") %>' Visible="false" runat="server" ID="CreadorLabel" />
                                <%--</center>--%>
                            </div>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div runat="server" id="itemPlaceholderContainer" class="carousel-inner" style="min-height: 600px; max-height: 1100px;">
                                <div runat="server" id="itemPlaceholder" />

                            </div>
                        </LayoutTemplate>

                    </asp:ListView>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
        </div>
        <%--  Seccion Listas--%>
        <style>
            .BlackBackgroundListas {
                min-height: 500px;
                /* background-image: url("../Images/FondoApp.png");*/
                background-size: 100%;
                background-repeat: repeat-x;
                background-position: center; /* Center the image horizontally and vertically */
            }

            .ArtBackgroundListas {
                min-height: 500px;
                background-image: url("../Images/Fondo304.png");
                background-size: 600px;
                background-color: transparent !important;
                background-repeat: no-repeat;
                background-position: bottom right; /* Center the image horizontally and vertically */
            }

            .PointedListas {
                min-height: 500px;
                background-image: url("../Images/Fondo302.png");
                background-size: 30%;
                background-color: transparent !important;
                background-repeat: repeat;
                background-position: center; /* Center the image horizontally and vertically */
            }
        </style>


        <asp:Panel ID="Panel7" runat="server" Visible="true" CssClass="BlackBackgroundListas">
            <asp:Panel ID="Panel8" runat="server" Visible="true" CssClass="ArtBackgroundListas">
                <asp:Panel ID="Panel9" runat="server" Visible="true" CssClass="PointedListas">

                    <div style="color: #ffffff; background-color: transparent; max-width: 1920px; margin: auto">

                        <div id="AhoraTienesDiv" runat="server" style="padding: 10px">
                            <br />
                            <center>
                                <span style="font-size: x-large; font-weight: 300; color: white">¡Ahora tienes aún más contenido para disfrutar! 
                            <br />
                                    Experimenta una experiencia mejorada y no te pierdas los estrenos más anticipados y tus clásicos favoritos.</span>

                            </center>
                            <br />
                        </div>

                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT [CategoriaId], [Categoria] FROM [Categorias]"></asp:SqlDataSource>

                            <asp:DropDownList Visible="false" ID="DropDownList1" AppendDataBoundItems="true" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource6" Style="max-width: 300px; font-size: larger" DataTextField="Categoria" CssClass="form-control" DataValueField="CategoriaId">
                                <asp:ListItem Text="Todas las Categorias" Value="0" />
                            </asp:DropDownList>
                            <center></center>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT -1 [CategoriaId],'Mi Lista' [Categoria], (SELECT COUNT(1) FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Plus' AND @SuperCategoriaId = '0') Peliculas  UNION ALL SELECT -2 [CategoriaId],'Me Gustan' [Categoria], (SELECT COUNT(1) FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Like' AND  @SuperCategoriaId = '0') Peliculas  UNION ALL SELECT -3 [CategoriaId],'Continuar viendo' [Categoria], (SELECT COUNT(1) FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Seen' AND @SuperCategoriaId = '0') Peliculas  UNION ALL  SELECT Categorias.[CategoriaId], [Categoria], COUNT(1) Peliculas FROM [Categorias] JOIN Supercategorias ON Categorias.SuperCategoriaId = Supercategorias.SuperCategoriaId JOIN Peliculas ON Peliculas.CategoriaId = Categorias.CategoriaId AND (Peliculas.Estado = 'Publicado') WHERE (Categorias.[SuperCategoriaId] = @SuperCategoriaId OR @SuperCategoriaId = '0') GROUP BY Categorias.[CategoriaId], [Categoria]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="SuperCategoriaIdHiddenField1" PropertyName="Value" Name="SuperCategoriaId" Type="Int32"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="UsuarioIdHiddenField1" PropertyName="Value" Name="UsuarioId" Type="Int32"></asp:ControlParameter>
                                    <asp:ControlParameter ControlID="PerfilHiddenField1" PropertyName="Value" Name="Perfil" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:ListView ID="ListView4" runat="server" DataSourceID="SqlDataSource4" DataKeyNames="CategoriaId">
                                <AlternatingItemTemplate>

                                    <div runat="server" visible='<%# Convert.ToInt32(Eval("Peliculas")) > 0 %>' style="">
                                        <asp:Label Text='<%# Eval("CategoriaId") %>' Visible="false" runat="server" ID="CategoriaIdLabel" /><br />

                                        <h3>
                                            <asp:Label Text='<%# Eval("Categoria") %>' runat="server" ID="CategoriaLabel" /></h3>

                                        <div style="overflow-x: scroll">
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT TOP 10     Peliculas.PeliculaId,     Peliculas.CategoriaId,     Peliculas.Nombre,     Peliculas.Resumen,     Peliculas.InformacionPelicula,    Peliculas.FotoMiniatura,     Peliculas.LogoPelicula,     Capitulos.CapituloId,     Capitulos.LinkTrailer1,     Capitulos.FotoMiniatura AS Expr1
                                                        FROM   Peliculas 
                                                        INNER JOIN     (  SELECT PeliculaId, MAX(CapituloId) AS PrimerCapituloId FROM Capitulos GROUP BY PeliculaId) AS PrimerosCapitulos 
                                                        ON 
                                                            Peliculas.PeliculaId = PrimerosCapitulos.PeliculaId 
                                                        INNER JOIN 
                                                            Capitulos ON PrimerosCapitulos.PrimerCapituloId = Capitulos.CapituloId
                                                        AND 
                                                            Peliculas.Estado = 'Publicado'
                                                        WHERE (Peliculas.CategoriaId =  @CategoriaId ) OR (@CategoriaId = -1 AND Peliculas.PeliculaId 
                                                        IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Plus') ) OR (@CategoriaId = -2 AND Peliculas.PeliculaId IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Like') ) OR (@CategoriaId = -3 AND Peliculas.PeliculaId IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Seen') )">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="CategoriaIdLabel" PropertyName="Text" Name="CategoriaId" Type="Int32"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="UsuarioIdHiddenField1" PropertyName="Value" Name="UsuarioId" Type="Int32"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="PerfilHiddenField1" PropertyName="Value" Name="Perfil" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataSource3" DataKeyNames="PeliculaId,CapituloId" GroupItemCount="10">
                                                <EmptyDataTemplate>
                                                    <table runat="server" style="">
                                                        <tr>
                                                            <td><%--No hay videos en esta categoria aun.--%></td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <EmptyItemTemplate>
                                                    <td runat="server" />
                                                </EmptyItemTemplate>
                                                <GroupTemplate>
                                                    <tr runat="server" id="itemPlaceholderContainer">
                                                        <td runat="server" id="itemPlaceholder"></td>
                                                    </tr>
                                                </GroupTemplate>

                                                <ItemTemplate>
                                                    <td runat="server" style="vertical-align: top">
                                                        <div class="xxborderroundedwithshadowlightW" style="margin: 4px;">
                                                            <center>
                                                                <asp:HyperLink CssClass="text-white btnxx btnlila" ID="LinkButton1" NavigateUrl='<%# "Detalle?id=" + Eval("PeliculaId") %>' runat="server">
                                                                    <asp:Label Visible="false" Text='<%# Eval("PeliculaId") %>' runat="server" ID="PeliculaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CategoriaId") %>' runat="server" ID="CategoriaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Resumen") %>' runat="server" ID="ResumenLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("InformacionPelicula") %>' runat="server" ID="InformacionPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("FotoMiniatura") %>' runat="server" ID="FotoMiniaturaLabel" />
                                                                    <%--<asp:Image CssClass="d-block w-100a " style="min-height: 200px; max-height: 200px; max-width: 2500px" ImageUrl='<%# System.Web.VirtualPathUtility.ToAbsolute("~/") +  "Files/" + fileName("FotoHorizontalPelicula", Eval("PeliculaId").ToString()) %>' ID="Image1" runat="server" />--%>
                                                                    
                                                                    <asp:Label Visible="false" Text='<%# Eval("LogoPelicula") %>' runat="server" ID="LogoPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CapituloId") %>' runat="server" ID="CapituloIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("LinkTrailer1") %>' runat="server" ID="LinkTrailer1Label" />

                                                                    <asp:Label Visible="false" Text='<%# Eval("Expr1") %>' runat="server" ID="Expr1Label" />



                                                                    <%--<b style="font-size: larger; font-weight: 900; color: #666666 !important;"><%# Eval("Nombre") %></b>--%>
                                                                    <%-- <br />
                                                                <br />--%>
                                                                </asp:HyperLink>

                                                            </center>
                                                        </div>
                                                    </td>
                                                </ItemTemplate>
                                                <LayoutTemplate>
                                                    <table runat="server">
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                                                    <tr runat="server" id="groupPlaceholder"></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" style=""></td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>

                                            </asp:ListView>
                                        </div>
                                    </div>
                                </AlternatingItemTemplate>
                                <ItemTemplate>
                                    <div runat="server" visible='<%# Convert.ToInt32(Eval("Peliculas"))>0 %>' style="">
                                        <asp:Label Text='<%# Eval("CategoriaId") %>' Visible="false" runat="server" ID="CategoriaIdLabel" /><br />

                                        <h3>
                                            <asp:Label Text='<%# Eval("Categoria") %>' runat="server" ID="CategoriaLabel" /></h3>

                                        <div style="overflow-x: scroll">
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT TOP 10     Peliculas.PeliculaId,     Peliculas.CategoriaId,     Peliculas.Nombre,     Peliculas.Resumen,     Peliculas.InformacionPelicula,    Peliculas.FotoMiniatura,     Peliculas.LogoPelicula,     Capitulos.CapituloId,     Capitulos.LinkTrailer1,     Capitulos.FotoMiniatura AS Expr1
                                                        FROM   Peliculas 
                                                        INNER JOIN     (  SELECT PeliculaId, MAX(CapituloId) AS PrimerCapituloId FROM Capitulos GROUP BY PeliculaId) AS PrimerosCapitulos 
                                                        ON 
                                                            Peliculas.PeliculaId = PrimerosCapitulos.PeliculaId 
                                                        INNER JOIN 
                                                            Capitulos ON PrimerosCapitulos.PrimerCapituloId = Capitulos.CapituloId
                                                        AND 
                                                            Peliculas.Estado = 'Publicado'
                                                        WHERE (Peliculas.CategoriaId =  @CategoriaId ) OR (@CategoriaId = -1 AND Peliculas.PeliculaId 
                                                        IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Plus') ) OR (@CategoriaId = -2 AND Peliculas.PeliculaId IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Like') ) OR (@CategoriaId = -3 AND Peliculas.PeliculaId IN 
                                                        (SELECT PeliculaId FROM MisListas WHERE UsuarioId = @UsuarioId AND Perfil = @Perfil AND Tipo = 'Seen') )">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="CategoriaIdLabel" PropertyName="Text" Name="CategoriaId" Type="Int32"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="UsuarioIdHiddenField1" PropertyName="Value" Name="UsuarioId" Type="Int32"></asp:ControlParameter>
                                                    <asp:ControlParameter ControlID="PerfilHiddenField1" PropertyName="Value" Name="Perfil" Type="Int32"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataSource3" DataKeyNames="PeliculaId,CapituloId" GroupItemCount="10">
                                                <EmptyDataTemplate>
                                                    <table runat="server" style="">
                                                        <tr>
                                                            <td><%--No hay videos en esta categoria aun.--%></td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <EmptyItemTemplate>
                                                    <td runat="server" />
                                                </EmptyItemTemplate>
                                                <GroupTemplate>
                                                    <tr runat="server" id="itemPlaceholderContainer">
                                                        <td runat="server" id="itemPlaceholder"></td>
                                                    </tr>
                                                </GroupTemplate>

                                                <ItemTemplate>
                                                    <td runat="server" style="vertical-align: top">
                                                        <div class="xxborderroundedwithshadowlightW" style="margin: 4px;">
                                                            <center>
                                                                <asp:HyperLink CssClass="text-white btnxx btnlila" ID="LinkButton1" NavigateUrl='<%# "Detalle?id=" + Eval("PeliculaId") %>' runat="server">
                                                                    <asp:Label Visible="false" Text='<%# Eval("PeliculaId") %>' runat="server" ID="PeliculaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CategoriaId") %>' runat="server" ID="CategoriaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Resumen") %>' runat="server" ID="ResumenLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("InformacionPelicula") %>' runat="server" ID="InformacionPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("FotoMiniatura") %>' runat="server" ID="FotoMiniaturaLabel" />
                                                                    <%--<asp:Image CssClass="d-block w-100a " style="min-height: 200px; max-height: 200px; max-width: 2500px" ImageUrl='<%# System.Web.VirtualPathUtility.ToAbsolute("~/") +  "Files/" + fileName("FotoHorizontalPelicula", Eval("PeliculaId").ToString()) %>' ID="Image1" runat="server" />--%>
                                                                    <asp:Label Visible="false" Text='<%# Eval("LogoPelicula") %>' runat="server" ID="LogoPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CapituloId") %>' runat="server" ID="CapituloIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("LinkTrailer1") %>' runat="server" ID="LinkTrailer1Label" />

                                                                    <asp:Label Visible="false" Text='<%# Eval("Expr1") %>' runat="server" ID="Expr1Label" />



                                                                    <%-- <b style="font-size: larger; font-weight: 900; color: #666666 !important;"><%# Eval("Nombre") %></b>--%>
                                                                    <%--<br />
                                  <br />--%>
                                                                </asp:HyperLink>

                                                            </center>
                                                        </div>
                                                    </td>
                                                </ItemTemplate>
                                                <LayoutTemplate>
                                                    <table runat="server">
                                                        <tr runat="server">
                                                            <td runat="server">
                                                                <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                                                    <tr runat="server" id="groupPlaceholder"></tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server">
                                                            <td runat="server" style=""></td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>

                                            </asp:ListView>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div runat="server" id="itemPlaceholderContainer" style=""><span runat="server" id="itemPlaceholder" /></div>
                                    <div style="">
                                    </div>
                                </LayoutTemplate>

                            </asp:ListView>

                        </asp:Panel>

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT top 10 SuperCategoriaId, Nombre FROM  SuperCategorias"></asp:SqlDataSource>
                        <style>
                            .image-container {
                                position: relative; /* Enable positioning of child element */
                                overflow: hidden; /* Prevent image overflow */
                            }

                                .image-container::after {
                                    content: "";
                                    position: absolute;
                                    top: 70%;
                                    left: 0;
                                    width: 100%;
                                    height: 30%;
                                    background-image: linear-gradient(to top, #66cc99, transparent); /* Green with 85% opacity to transparent */
                                }

                            .image {
                                width: 100%;
                                height: auto; /* Maintain image aspect ratio */
                            }
                        </style>
                        <asp:Panel ID="Panel2" runat="server" CssClass="text-center">

                            <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2" DataKeyNames="SuperCategoriaId">

                                <ItemTemplate>
                                    <td class="col-xs-2x" style="padding: 1px; min-width: 300px">



                                        <asp:Label Text='<%# Eval("SuperCategoriaId") %>' Visible="false" runat="server" ID="SuperCategoriaIdLabel" />


                                        <%--   <asp:Label Text='<%# Eval("Nombre") %>' runat="server" ID="CategoriaLabel" />--%>
                                        <asp:SqlDataSource ID="SqlDataSource33" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT TOP (1) Peliculas.PeliculaId, Peliculas.CategoriaId, Peliculas.Nombre, Peliculas.Resumen, Peliculas.InformacionPelicula, Peliculas.FotoMiniatura, Peliculas.LogoPelicula, Capitulos.CapituloId, Capitulos.LinkTrailer1, Capitulos.FotoMiniatura AS Expr1, Categorias.SuperCategoriaId, SuperCategorias.Nombre AS SuperCategoria FROM Peliculas INNER JOIN Capitulos ON Peliculas.PeliculaId = Capitulos.PeliculaId INNER JOIN Categorias ON Peliculas.CategoriaId = Categorias.CategoriaId INNER JOIN SuperCategorias ON Categorias.SuperCategoriaId = SuperCategorias.SuperCategoriaId WHERE (Categorias.SuperCategoriaId = @SuperCategoriaId AND Peliculas.Estado = 'Publicado')">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="SuperCategoriaIdLabel" PropertyName="Text" Name="SuperCategoriaId"></asp:ControlParameter>
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataSource33" DataKeyNames="PeliculaId,CapituloId">
                                            <EmptyDataTemplate>
                                            </EmptyDataTemplate>
                                            <EmptyItemTemplate>
                                            </EmptyItemTemplate>


                                            <ItemTemplate>
                                                <div style="vertical-align: top" class="image-containerXX">
                                                    <div class="xxxborderroundedwithshadowlightW">
                                                        <center>
                                                            <asp:HyperLink CssClass=" btnxx btnlilaxx" ID="LinkButton1" NavigateUrl='<%# "Detalle?id=" + Eval("PeliculaId") %>' runat="server">
                                                                <div class="image-containerXX">
                                                                    <asp:Label Visible="false" Text='<%# Eval("PeliculaId") %>' runat="server" ID="PeliculaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CategoriaId") %>' runat="server" ID="CategoriaIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("Resumen") %>' runat="server" ID="ResumenLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("InformacionPelicula") %>' runat="server" ID="InformacionPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("FotoMiniatura") %>' runat="server" ID="FotoMiniaturaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("LogoPelicula") %>' runat="server" ID="LogoPeliculaLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("CapituloId") %>' runat="server" ID="CapituloIdLabel" />
                                                                    <asp:Label Visible="false" Text='<%# Eval("LinkTrailer1") %>' runat="server" ID="LinkTrailer1Label" />

                                                                    <asp:Label Visible="false" Text='<%# Eval("Expr1") %>' runat="server" ID="Expr1Label" />

                                                                </div>
                                                                <br />
                                                                <b style="font-size: x-large; font-weight: 700; color: #666666 !important;"><%# Eval("SuperCAtegoria") %></b>

                                                                <br />
                                                                <span style="font-size: large; font-weight: 300; color: #666666 !important;"><%# Eval("Nombre") %></span>
                                                                <br />
                                                                <br />
                                                                <br />

                                                            </asp:HyperLink>

                                                        </center>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <LayoutTemplate>
                                                <div runat="server" id="itemPlaceholderContainer" class="" style="">
                                                    <div class="" runat="server" id="itemPlaceholder" />
                                                </div>
                                            </LayoutTemplate>

                                        </asp:ListView>
                                        <%-- <div style="overflow-x: scroll">--%>

                                        <%--  </div>--%>
                                    </td>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div style="overflow-x: scroll">
                                        <table>
                                            <tr runat="server" id="itemPlaceholderContainer" class="rowx row-cols-6x" style="padding: 0px; margin: 0px; min-width: 960px !important;">
                                                <td class="" runat="server" id="itemPlaceholder" />
                                            </tr>
                                        </table>
                                    </div>
                                </LayoutTemplate>

                            </asp:ListView>


                        </asp:Panel>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>





        <%--    <div style="color: #33ffcc; background-color: #4d4d4d">
        <center>
            <img src="Images/Banner.png" style="" />
        </center>
    </div>--%>
        <%-- --%>
        <%--        <div style="color: #ffffff;">
            <br />
            <h3>Trailers</h3>
            <div style="overflow-x: scroll">
                <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' SelectCommand="SELECT TOP 10 Peliculas.PeliculaId, Peliculas.CategoriaId, Peliculas.Nombre, Peliculas.Resumen, Peliculas.InformacionPelicula, Peliculas.FotoMiniatura, Peliculas.LogoPelicula, Capitulos.CapituloId, Capitulos.LinkTrailer1, Capitulos.FotoMiniatura AS Expr1 FROM Peliculas INNER JOIN Capitulos ON Peliculas.PeliculaId = Capitulos.PeliculaId"></asp:SqlDataSource>
                <asp:ListView ID="ListView21" runat="server" DataSourceID="SqlDataSource21" DataKeyNames="PeliculaId,CapituloId" GroupItemCount="10">
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>No hay peliculas en esta categoria</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <td runat="server" />
                    </EmptyItemTemplate>
                    <GroupTemplate>
                        <tr runat="server" id="itemPlaceholderContainer">
                            <td runat="server" id="itemPlaceholder"></td>
                        </tr>
                    </GroupTemplate>

                    <ItemTemplate>
                        <td runat="server" style="">
                            <div class="borderroundedwithshadowlightW" style="width:400px">
                                <asp:Label Visible="false" Text='<%# Eval("PeliculaId") %>' runat="server" ID="PeliculaIdLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("CategoriaId") %>' runat="server" ID="CategoriaIdLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("Nombre") %>' runat="server" ID="NombreLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("Resumen") %>' runat="server" ID="ResumenLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("InformacionPelicula") %>' runat="server" ID="InformacionPeliculaLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("FotoMiniatura") %>' runat="server" ID="FotoMiniaturaLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("LogoPelicula") %>' runat="server" ID="LogoPeliculaLabel" />
                                <asp:Label Visible="false" Text='<%# Eval("CapituloId") %>' runat="server" ID="CapituloIdLabel" />

                                <asp:Label Visible="true" Text='<%# Eval("LinkTrailer1").ToString().Replace("560", "100%") %>' runat="server" ID="LinkTrailer1Label" />
                                <br />
                                <asp:Label Visible="false" Text='<%# Eval("Expr1") %>' runat="server" ID="Expr1Label" />
                                <center>
                                    <asp:HyperLink CssClass="text-white btn btnlila" style="width: 100%" ID="LinkButton1" NavigateUrl='<%# "Detalle?id=" + Eval("PeliculaId") %>' runat="server">
                                     
                                        <%# Eval("Nombre") %>
                                    </asp:HyperLink>
                                </center>
                            </div>
                        </td>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table runat="server" id="groupPlaceholderContainer" style="" border="0">
                                        <tr runat="server" id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style=""></td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                </asp:ListView>
            </div>
        </div>--%>
        <style>
            .BlackBackground {
                min-height: 500px;
                /*  background-image: url("../Images/FondoApp.png");*/
                background-size: 100%;
                background-repeat: repeat-x;
                background-position: center; /* Center the image horizontally and vertically */
            }

            .ArtBackground {
                min-height: 500px;
                background-image: url("../Images/Fondo303.png");
                background-size: 600px;
                background-color: transparent !important;
                background-repeat: no-repeat;
                background-position: bottom left; /* Center the image horizontally and vertically */
            }

            .Pointed {
                min-height: 500px;
                background-image: url("../Images/Fondo302.png");
                background-size: 30%;
                background-color: transparent !important;
                background-repeat: repeat;
                background-position: center; /* Center the image horizontally and vertically */
            }
        </style>
        <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="BlackBackground">
            <asp:Panel ID="Panel4" runat="server" Visible="true" CssClass="ArtBackground">
                <asp:Panel ID="Panel6" runat="server" Visible="true" CssClass="Pointed">
                    <div class="container" id="App">
                        <center>
                            <h2 style="color: white"></h2>
                        </center>

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="row" style="padding: 0; margin: 0">
                            <div class="col">
                                <center>
                                    <img src="Images/Fondo301.png" style="max-width: 400px" /></center>
                            </div>
                            <div class="col" style="color: white">
                                <center>
                                    <h2>Descarga la Web App</h2>
                                    <p>
                                        Con esta PWA tendrás un sitio web que se
                                        ve y se comporta como si fuera una
                                        aplicación móvil ahorrando espacio en tu
                                        dispositivo
                                    </p>
                                    <div id="install" style="width: 200px; background-color: #00000; border-color: #000000; border-radius: 5px; color: black" disabled>
                                        <img src="Images/IconoPWA.png" />
                                    </div>
                                </center>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>

                    </div>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>



        <%--  Seccion PF--%>
        <style>
            .BlackBackgroundPF {
                min-height: 500px;
                /* background-image: url("../Images/FondoApp.png");*/
                background-size: 100%;
                background-repeat: repeat-x;
                background-position: center; /* Center the image horizontally and vertically */
            }

            .ArtBackgroundPF {
                min-height: 500px;
                background-image: url("../Images/Fondo1.png");
                background-size: 600px;
                background-color: transparent !important;
                background-repeat: no-repeat;
                background-position: bottom right; /* Center the image horizontally and vertically */
            }

            .PointedPF {
                min-height: 500px;
                background-image: url("../Images/Fondo302.png");
                background-size: 30%;
                background-color: transparent !important;
                background-repeat: repeat;
                background-position: center; /* Center the image horizontally and vertically */
            }
        </style>
        <asp:Panel ID="Panel10" runat="server" CssClass="BlackBackgroundPF">
            <asp:Panel ID="Panel11" runat="server" Visible="true" CssClass="ArtBackgroundPF">
                <asp:Panel ID="Panel12" runat="server" Visible="true" CssClass="PointedPF">

                    <div runat="server" id="planesUnlogged" style="">

                        <div class="container-fluid blacktogreenX" style="">
                            <br />
                            <%--   <hr style="border: 1px solid black" />--%>
                            <br />
                            <br />
                        </div>
                        <div class="container">

                            <h2 style="color: white">
                                <asp:Image ImageUrl="~/Images/IconoCuadrados.png" Width="70" Height="70" Style="min-width: 30px !important" ID="ImageIconoCuadrado" runat="server" />
                                Elije el Plan que se ajusta a tus necesidades
                            <asp:Label ID="CountryLabel3" runat="server" Text="BO"></asp:Label>
                            </h2>

                            <div>
                                <div class="row" style="text-align: left; margin: auto">
                                    <div class="col-md-12 mx-auto">
                                        <asp:Panel ID="BoliviaPanel4" runat="server">
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <br />

                                                    <a href="PagosNet?plan=28" style="color: white; font-size: small" class="btn btn-primary">
                                                        <asp:Image ImageUrl="~/Images/bs_1.jpg" Style="min-width: 30px !important" ID="Image3" runat="server" />
                                                    </a>

                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Panel ID="SemestralPanel4" runat="server">
                                                        <br />
                                                        <a href="PagosNet?plan=147" style="color: white; font-size: small" class="btn btn-primary">
                                                            <asp:Image ImageUrl="~/Images/bs_2.jpg" Style="min-width: 30px !important" ID="Image7" runat="server" />
                                                        </a>
                                                    </asp:Panel>
                                                </div>
                                                <div class="col-md-4">
                                                    <br />
                                                    <a href="PagosNet?plan=294" style="color: white; font-size: small" class="btn btn-primary">
                                                        <asp:Image ImageUrl="~/Images/bs_3.jpg" Style="min-width: 30px !important" ID="Image8" runat="server" />
                                                    </a>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="ExtranjeroPanel4" runat="server">
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <br />
                                                    <a href="PagosNet?plan=63" style="color: white; font-size: small" class="btn btn-primary">
                                                        <asp:Image ImageUrl="~/Images/sus_1.jpg" Style="min-width: 30px !important" ID="Image4" runat="server" />
                                                    </a>

                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Panel ID="Panel5" runat="server">
                                                        <br />
                                                        <a href="PagosNet?plan=336" style="color: white; font-size: small" class="btn btn-primary">
                                                            <asp:Image ImageUrl="~/Images/sus_2.jpg" Style="min-width: 30px !important" ID="Image5" runat="server" />
                                                        </a>
                                                    </asp:Panel>
                                                </div>
                                                <div class="col-md-4">
                                                    <br />
                                                    <a href="PagosNet?plan=672" style="color: white; font-size: small" class="btn btn-primary">
                                                        <asp:Image ImageUrl="~/Images/sus_3.jpg" Style="min-width: 30px !important" ID="Image6" runat="server" />
                                                    </a>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>

                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>


                    <asp:Panel ID="PreguntasFecuentesPanel1" runat="server" Visible="true">
                        <div class="container" id="PreguntasFrecuentes">

                            <h2 style="color: white">
                                <asp:Image ImageUrl="~/Images/IconoCuadrados.png" Width="70" Height="70" Style="min-width: 30px !important" ID="Image2" runat="server" />
                                Preguntas frecuentes
                            </h2>

                            <style>
                                .accordion-button {
                                    background-color: #000000 !important;
                                    border: 1px solid white;
                                }

                                .accordion-header {
                                    background-color: #000000;
                                        border: 1px solid white;
                                }

                                .accordion-body {
                                    background-color: #000000 !important;
                                        border: 1px solid white;
                                }

                                .accordion-button:focus {
                                    border-color: white;
                                }

                                .accordion {
                                    --bs-accordion-color: #000;
                                    --bs-accordion-bg: #fff;
                                    --bs-accordion-transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out, border-radius 0.15s ease;
                                    --bs-accordion-border-color: var(--bs-border-color);
                                    --bs-accordion-border-width: 1px;
                                    --bs-accordion-border-radius: 0.375rem;
                                    --bs-accordion-inner-border-radius: calc(0.375rem - 1px);
                                    --bs-accordion-btn-padding-x: 1.25rem;
                                    --bs-accordion-btn-padding-y: 1rem;
                                    --bs-accordion-btn-color: var(--bs-body-color);
                                    --bs-accordion-btn-bg: var(--bs-accordion-bg);
                                    --bs-accordion-btn-icon: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16' fill='var%28--bs-body-color%29'%3e%3cpath fill-rule='evenodd' d='M1.646 4.646a.5.5 0 0 1 .708 0L8 10.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z'/%3e%3c/svg%3e");
                                    --bs-accordion-btn-icon-width: 1.25rem;
                                    --bs-accordion-btn-icon-transform: rotate(-180deg);
                                    --bs-accordion-btn-icon-transition: transform 0.2s ease-in-out;
                                    --bs-accordion-btn-active-icon: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16' fill='%23ffffff'%3e%3cpath fill-rule='evenodd' d='M1.646 4.646a.5.5 0 0 1 .708 0L8 10.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z'/%3e%3c/svg%3e");
                                    --bs-accordion-btn-focus-border-color: #ffffff;
                                    --bs-accordion-btn-focus-box-shadow: 0 0 0 0.25rem rgba(255, 255, 255, 0.25);
                                    --bs-accordion-body-padding-x: 1.25rem;
                                    --bs-accordion-body-padding-y: 1rem;
                                    --bs-accordion-active-color: #ffffff;
                                    --bs-accordion-active-bg: #e7f1ff;
                                }
                            </style>
                            <asp:SqlDataSource ID="SqlDataSource55" runat="server" ConnectionString='<%$ ConnectionStrings:AhayouConnectionString %>' DeleteCommand="DELETE FROM [PreguntasFrecuentes] WHERE [PreguntaFrecuenteId] = @PreguntaFrecuenteId" InsertCommand="INSERT INTO [PreguntasFrecuentes] ([Pregunta], [Respuesta]) VALUES (@Pregunta, @Respuesta)" SelectCommand="SELECT [PreguntaFrecuenteId], [Pregunta], [Respuesta] FROM [PreguntasFrecuentes]" UpdateCommand="UPDATE [PreguntasFrecuentes] SET [Pregunta] = @Pregunta, [Respuesta] = @Respuesta WHERE [PreguntaFrecuenteId] = @PreguntaFrecuenteId">
                                <DeleteParameters>
                                    <asp:Parameter Name="PreguntaFrecuenteId" Type="Int32"></asp:Parameter>
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Pregunta" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="Respuesta" Type="String"></asp:Parameter>
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Pregunta" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="Respuesta" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="PreguntaFrecuenteId" Type="Int32"></asp:Parameter>
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:ListView ID="ListView5" runat="server" DataSourceID="SqlDataSource55" DataKeyNames="PreguntaFrecuenteId" InsertItemPosition="None">

                                <EditItemTemplate>
                                    <span style="">PreguntaFrecuenteId:
           <asp:Label Text='<%# Eval("PreguntaFrecuenteId") %>' runat="server" ID="PreguntaFrecuenteIdLabel1" /><br />
                                        Pregunta:
           <asp:TextBox Text='<%# Bind("Pregunta") %>' runat="server" ID="PreguntaTextBox" /><br />
                                        Respuesta:
           <asp:TextBox Text='<%# Bind("Respuesta") %>' runat="server" ID="RespuestaTextBox" /><br />
                                        <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" /><asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" /><br />
                                        <br />
                                    </span>
                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <span></span>
                                </EmptyDataTemplate>
                                <InsertItemTemplate>
                                    <span style="">Pregunta:
           <asp:TextBox Text='<%# Bind("Pregunta") %>' runat="server" ID="PreguntaTextBox" /><br />
                                        Respuesta:
           <asp:TextBox Text='<%# Bind("Respuesta") %>' runat="server" ID="RespuestaTextBox" /><br />
                                        <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" /><asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" /><br />
                                        <br />
                                    </span>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <div class="accordion-item form-item">
                                        <div class="accordion-header">
                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse<%# Container.DataItemIndex %>" aria-expanded="false" aria-controls="flush-collapseOne">
                                                <asp:Label Text='<%# Eval("PreguntaFrecuenteId") %>' Visible="false" runat="server" ID="PreguntaFrecuenteIdLabel" /><br />

                                                <asp:Label Text='<%# Eval("Pregunta") %>' ForeColor="White" Style="font-size: 20px" runat="server" ID="PreguntaLabel" /><br />
                                            </button>
                                        </div>
                                        <div id="flush-collapse<%# Container.DataItemIndex %>" class="accordion-collapse collapse" data-bs-parent="#accordionFlushExample">
                                            <div class="accordion-body" style="text-align: left; color: white">
                                                <asp:Label Text='<%# Eval("Respuesta") %>' runat="server" ID="RespuestaLabel" /><br />
                                                <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" Visible='<%# PermisosClass.TengoPermiso("PreguntasFrecuentes") %>' />
                                                <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" Visible='<%# PermisosClass.TengoPermiso("PreguntasFrecuentes") %>' />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <div>
                                        <div runat="server" id="itemPlaceholderContainer" class="text-center" style="margin: auto; max-width: 700px">
                                            <center>
                                                <div class="accordion accordion-flush" id="accordionFlushExample">

                                                    <div runat="server" class="accordion-item" id="itemPlaceholder" />
                                                </div>

                                            </center>
                                        </div>

                                    </div>
                                    <div style="">
                                    </div>
                                </LayoutTemplate>

                            </asp:ListView>
                        </div>
                        <div style="color: white">
                            <center>
                                <br />
                                <br />
                                <br />
                                Listo para entrar en el mundo de Ahayou? Ingresa tu email para crear una cuenta.<br />
                                <br />
                                <table style="width: 100%">
                                    <tr>

                                        <td>
                                            <div style="width: 100%">

                                                <div style="margin: auto; max-width: 500px">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td></td>
                                                            <td style="text-align: right; display: flex; justify-content: flex-end;">
                                                                <asp:TextBox ID="TextBox2" placeholder="Correo" CssClass="form-control" Style="margin-right: 0; border-radius: 3px 0px 0px 3px; width: 100%; max-width: 450px; line-height: 2;" runat="server"></asp:TextBox></td>
                                                            <td>
                                                                
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>

                                </table>


                                <br />
                                <br />
                                <br />
                            </center>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="RegistratePanel1" runat="server" Visible="false">

                        <div style="background-color: #ffffff; color: #660098">
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Register.aspx">
            <h1 style="color: #660098"><center><img src="Images/LogoLila2.png" style="width:150px !important; min-width:150px !important" />Registrate</center></h1>

                            </asp:HyperLink>
                            <br />
                            <br />
                            <br />
                            <br />

                        </div>

                    </asp:Panel>
                </asp:Panel>

            </asp:Panel>

        </asp:Panel>
    </div>
</asp:Content>
