using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class contenido_str_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                                btnNuevo.Visible = true;
                        }

                    }
                }

            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            MultiView1.ActiveViewIndex = 1;
        }
        public void limpiar()
        {
            PanelFotos.Visible = false;
            ImageVertical.ImageUrl = "";
            ImageHorizontal.ImageUrl = "";
            ImageMiniatura.ImageUrl = "";
            ImageTitulo.ImageUrl = "";
            lblAviso.Text = "";
            lblCodigo.Text = "";
            txtCreditos.Text = "";
            txtDirector.Text = "";
            txtGestion.Text = "2000";
            txtHoras.Text = "00";
            txtMinutos.Text = "00";
            txtNombreContenido.Text = "";
            txtReparto.Text = "";
            txtSinopsis.Text = "";
            txtSinopsisIngles.Text = "";
            txtStoryLine.Text = "";
            txtStoryLineIngles.Text = "";
            txtTemporadas.Text = "0";
            ddlClasificacionContenido.DataBind();
            ddlClasificacionPublico.DataBind();
            ddlEsGratis.DataBind();
            ddlEsSubtitulada.DataBind();
            ddlEsTemporadas.DataBind();
            ddlFormato.DataBind();
            ddlIdiomaOriginal.DataBind();
            ddlNacionalidad.DataBind();
            ddlProductora.DataBind();
            ddlTipoAudio.DataBind();
            cblGenero.DataBind();
            ddlEstadoContenido.DataBind();
            lblFotoVerticalAnt.Text = "";
            lblFotoHorizontalAnt.Text = "";
            lblFotoMiniaturaAnt.Text = "";
            lblFotoTituloAnt.Text = "";
            //txtCodigo.Text = "";
            //ddlClasificacion.DataBind();
            //txtFormatoContenido.Text = ddlFormatoContenido.SelectedItem.Text;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                bEdit.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                            bEliminar.Visible = true;
                    }

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string foto_vertical = "";
                string foto_horizontal = "";
                string foto_miniatura = "";
                string foto_titulo = "";

                string fecha_salida = DateTime.Now.ToShortDateString();
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaSalida.Value;
                string cod_genero = "";
                int i = 0;
                foreach (ListItem item in cblGenero.Items)
                {
                    if (item.Selected == true)
                    {
                        if (i == 0)
                            cod_genero = item.Value;
                        else
                            cod_genero = cod_genero + "," + item.Value;
                        i++;
                    }
                    
                }
                if (lblCodigo.Text == "")
                {
                    if (fuHorizontal.HasFile)
                    {
                        foto_horizontal = fuHorizontal.FileName;
                    }
                    else 
                    { 
                        if(lblFotoHorizontalAnt.Text!="")
                            foto_horizontal= lblFotoHorizontalAnt.Text;
                    }
                    if (fuVertical.HasFile)
                    {
                        foto_vertical = fuVertical.FileName;
                    }
                    else
                    {
                        if (lblFotoVerticalAnt.Text != "")
                            foto_vertical = lblFotoVerticalAnt.Text;
                    }
                    if (fuMiniatura.HasFile)
                    {
                     
                        foto_miniatura=fuMiniatura.FileName;
                    }
                    else
                    {
                        if (lblFotoMiniaturaAnt.Text != "")
                            foto_miniatura = lblFotoMiniaturaAnt.Text;
                    }
                    if (fuTitulo.HasFile)
                    {
                        foto_titulo=fuTitulo.FileName;
                    }
                    else
                    {
                        if (lblFotoTituloAnt.Text != "")
                            foto_titulo = lblFotoTituloAnt.Text;
                    }
                    Clases.Contenidos_streaming obj = new Clases.Contenidos_streaming("I", "", txtNombreContenido.Text, int.Parse(ddlFormato.SelectedValue), ddlClasificacionContenido.SelectedValue,
                        cod_genero, ddlClasificacionPublico.SelectedValue, txtGestion.Text, ddlEsTemporadas.SelectedValue, int.Parse(txtTemporadas.Text),
                        txtHoras.Text, txtMinutos.Text, ddlTipoAudio.SelectedValue, txtStoryLine.Text, txtStoryLineIngles.Text, txtSinopsis.Text, txtSinopsisIngles.Text,
                        txtDirector.Text, txtReparto.Text, ddlNacionalidad.SelectedValue, ddlIdiomaOriginal.SelectedValue, ddlEsSubtitulada.SelectedValue, txtCreditos.Text,
                        foto_vertical, foto_miniatura, foto_horizontal, foto_titulo, DateTime.Parse(fecha_salida), ddlEstadoContenido.SelectedValue,
                        ddlProductora.SelectedValue, ddlEsGratis.SelectedValue, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    if (obj.PV_COD_CONTENIDO_STR_OUT != "")
                    {
                        if (fuHorizontal.HasFile)
                        {
                            string Ruta = Server.MapPath("~/fotos_peliculas/" + obj.PV_COD_CONTENIDO_STR_OUT + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);
                            }
                            string archivo = fuHorizontal.FileName;
                            fuHorizontal.PostedFile.SaveAs(Ruta + archivo);
                        }
                        if (fuVertical.HasFile)
                        {
                            string Ruta = Server.MapPath("~/fotos_peliculas/" + obj.PV_COD_CONTENIDO_STR_OUT + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);
                            }
                            string archivo = fuVertical.FileName;
                            fuVertical.PostedFile.SaveAs(Ruta + archivo);
                        }
                        if (fuMiniatura.HasFile)
                        {
                            string Ruta = Server.MapPath("~/fotos_peliculas/" + obj.PV_COD_CONTENIDO_STR_OUT + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);
                            }
                            string archivo = fuMiniatura.FileName;
                            fuMiniatura.PostedFile.SaveAs(Ruta + archivo);
                        }
                        if (fuTitulo.HasFile)
                        {
                            string Ruta = Server.MapPath("~/fotos_peliculas/" + obj.PV_COD_CONTENIDO_STR_OUT + "/");
                            if (!Directory.Exists(Ruta))
                            {
                                Directory.CreateDirectory(Ruta);
                            }
                            string archivo = fuTitulo.FileName;
                            fuTitulo.PostedFile.SaveAs(Ruta + archivo);
                        }
                    }
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    if (fuHorizontal.HasFile)
                    {
                        foto_horizontal = fuHorizontal.FileName;
                    }
                    else
                    {
                        if (lblFotoHorizontalAnt.Text != "")
                            foto_horizontal = lblFotoHorizontalAnt.Text;
                    }
                    if (fuVertical.HasFile)
                    {
                        foto_vertical = fuVertical.FileName;
                    }
                    else
                    {
                        if (lblFotoVerticalAnt.Text != "")
                            foto_vertical = lblFotoVerticalAnt.Text;
                    }
                    if (fuMiniatura.HasFile)
                    {

                        foto_miniatura = fuMiniatura.FileName;
                    }
                    else
                    {
                        if (lblFotoMiniaturaAnt.Text != "")
                            foto_miniatura = lblFotoMiniaturaAnt.Text;
                    }
                    if (fuTitulo.HasFile)
                    {
                        foto_titulo = fuTitulo.FileName;
                    }
                    else
                    {
                        if (lblFotoTituloAnt.Text != "")
                            foto_titulo = lblFotoTituloAnt.Text;
                    }
                    Clases.Contenidos_streaming obj = new Clases.Contenidos_streaming("U", lblCodigo.Text, txtNombreContenido.Text, int.Parse(ddlFormato.SelectedValue), ddlClasificacionContenido.SelectedValue,
                       cod_genero, ddlClasificacionPublico.SelectedValue, txtGestion.Text, ddlEsTemporadas.SelectedValue, int.Parse(txtTemporadas.Text),
                       txtHoras.Text, txtMinutos.Text, ddlTipoAudio.SelectedValue, txtStoryLine.Text, txtStoryLineIngles.Text, txtSinopsis.Text, txtSinopsisIngles.Text,
                       txtDirector.Text, txtReparto.Text, ddlNacionalidad.SelectedValue, ddlIdiomaOriginal.SelectedValue, ddlEsSubtitulada.SelectedValue, txtCreditos.Text,
                       foto_vertical, foto_miniatura, foto_horizontal, foto_titulo, DateTime.Parse(fecha_salida), ddlEstadoContenido.SelectedValue,
                       ddlProductora.SelectedValue, ddlEsGratis.SelectedValue, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    if (fuHorizontal.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/" + lblCodigo.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        string archivo = fuHorizontal.FileName;
                        fuHorizontal.PostedFile.SaveAs(Ruta + archivo);
                    }
                    if (fuVertical.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/" + lblCodigo.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        string archivo = fuVertical.FileName;
                        fuVertical.PostedFile.SaveAs(Ruta + archivo);
                    }
                    if (fuMiniatura.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/" + lblCodigo.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        string archivo = fuMiniatura.FileName;
                        fuMiniatura.PostedFile.SaveAs(Ruta + archivo);
                    }
                    if (fuTitulo.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/" + lblCodigo.Text + "/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        string archivo = fuTitulo.FileName;
                        fuTitulo.PostedFile.SaveAs(Ruta + archivo);
                    }
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clasificacion_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            limpiar();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodigo.Text = id;
            
                Clases.Contenidos_streaming obj_m = new Clases.Contenidos_streaming(lblCodigo.Text);
                txtCreditos.Text =obj_m.PV_CREDITOS;
                txtDirector.Text = obj_m.PV_DIRECTOR;
                txtGestion.Text = obj_m.PV_GESTION;
                txtHoras.Text = obj_m.PV_TIEMPO_HORA;
                txtMinutos.Text = obj_m.PV_TIEMPO_MINUTOS;
                txtNombreContenido.Text = obj_m.PV_NOMBRE_CONTENIDO;
                txtReparto.Text = obj_m.PV_REPARTO;
                txtSinopsis.Text = obj_m.PV_SINOPSIS;
                txtSinopsisIngles.Text = obj_m.PV_SINOPSIS_INGLES;
                txtStoryLine.Text = obj_m.PV_STORY_LINE;
                txtStoryLineIngles.Text = obj_m.PV_STORY_LINE_INGLES;
                txtTemporadas.Text = obj_m.PI_TEMPORADAS.ToString();
                ddlFormato.SelectedValue = obj_m.PI_COD_FORMATO_CONTENIDO.ToString();
                ddlClasificacionContenido.DataBind();
                ddlClasificacionContenido.SelectedValue= obj_m.PV_COD_CLASIFIFICACION_CONTENIDO;
                ddlClasificacionPublico.SelectedValue = obj_m.PV_COD_CLASIFICACION_PUBLICO;
                ddlEsGratis.SelectedValue = obj_m.PV_ES_GRATUITA;
                ddlEsSubtitulada.SelectedValue = obj_m.PV_ES_SUBTITULADA;
                ddlEsTemporadas.SelectedValue = obj_m.PV_ES_TEMPORADA;
                ddlIdiomaOriginal.SelectedValue = obj_m.PV_IDIOMA_ORIGINAL;
                ddlNacionalidad.SelectedValue = obj_m.PV_NACIONALIDAD;
                ddlProductora.SelectedValue = obj_m.PV_COD_PRODUCTORA;
                ddlTipoAudio.SelectedValue = obj_m.PV_TIPO_AUDIO;
                ddlEstadoContenido.SelectedValue = obj_m.PV_ESTADO_CONTENIDO;
                cblGenero.DataBind();
                string[] genero = obj_m.PV_COD_GENERO.Split(',');
                foreach (string s in genero)
                {
                    foreach (ListItem item in cblGenero.Items)
                    {
                        if (s == item.Value)
                            item.Selected = true;
                    }
                }
                if (obj_m.PD_FECHA_PUBLICACION == DateTime.Parse("3000/01/01"))
                { }
                else
                {
                    DateTime fecha1 = obj_m.PD_FECHA_PUBLICACION;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();
                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
                if (obj_m.PV_FOTO_VERTICAL != "")
                { 
                    ImageVertical.ImageUrl = obj_m.PV_FOTO_VERTICAL;
                    PanelFotos.Visible = true;
                    string[] foto_name = obj_m.PV_FOTO_VERTICAL.Split('/');
                    int tamaño = foto_name.Length-1;
                    lblFotoVerticalAnt.Text = foto_name[tamaño];
                }
                 else
                    ImageVertical.ImageUrl = "~/Imagenes/sin_imagen.png";
                if (obj_m.PV_FOTO_HORIZONTAL != "")
                { 
                    ImageHorizontal.ImageUrl = obj_m.PV_FOTO_HORIZONTAL; 
                    PanelFotos.Visible = true;
                    string[] foto_name = obj_m.PV_FOTO_HORIZONTAL.Split('/');
                    int tamaño = foto_name.Length - 1;
                    lblFotoHorizontalAnt.Text = foto_name[tamaño];
                }
                else
                    ImageHorizontal.ImageUrl = "~/Imagenes/sin_imagen.png";
                if (obj_m.PV_FOTO_MINIATURA != "")
                { 
                    ImageMiniatura.ImageUrl = obj_m.PV_FOTO_MINIATURA; 
                    PanelFotos.Visible = true;
                    string[] foto_name = obj_m.PV_FOTO_MINIATURA.Split('/');
                    int tamaño = foto_name.Length - 1;
                    lblFotoMiniaturaAnt.Text = foto_name[tamaño];
                }
                else
                 ImageMiniatura.ImageUrl = "~/Imagenes/sin_imagen.png";
                if (obj_m.PV_TITULO != "")
                { 
                    ImageTitulo.ImageUrl = obj_m.PV_TITULO;
                    PanelFotos.Visible = true;
                    string[] foto_name = obj_m.PV_TITULO.Split('/');
                    int tamaño = foto_name.Length - 1;
                    lblFotoTituloAnt.Text = foto_name[tamaño];
                }
                else
                    ImageTitulo.ImageUrl = "~/Imagenes/sin_imagen.png";

                //txtCodigo.Text = obj_m.PB_COD_CLASIFICACION_CONTENIDO.ToString();
                // txtFormatoContenido.Text = ddlFormatoContenido.SelectedItem.Text;
                //ddlClasificacion.DataBind();
                //ddlClasificacion.SelectedValue = obj_m.PV_CLASIFICACION;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clasificacion_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodigo.Text = id;
                //Clases.Clasificacion_contenidos obj_m = new Clases.Clasificacion_contenidos("D", Int64.Parse(lblCodigo.Text), Int64.Parse(ddlFormatoContenido.SelectedValue), "", lblUsuario.Text);
                //obj_m.ABM();
                //lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clasificacion_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }

        protected void ddlFormatoContenido_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //protected void ddlClasificacion_DataBound(object sender, EventArgs e)
        //{
        //    ddlClasificacion.Items.Insert(0, "SELECCIONAR");
        //}

        

        protected void btnTrailer_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["cod_contenido_str"] = id;
            Response.Redirect("contenido_trailers_admin.aspx");
        }

        protected void btnTemporadas_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["cod_contenido_str"] = id;
            Response.Redirect("contenido_temporadas_admin.aspx");
        }

        protected void btnPeliculas_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            Session["cod_contenido_str"] = id;
            Response.Redirect("contenido_peliculas_admin.aspx");
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodigo.Text = id;
            MultiView1.ActiveViewIndex = 2;
            Clases.Contenidos_streaming obj_c = new Clases.Contenidos_streaming(id);
            lblTitulo.Text = obj_c.PV_NOMBRE_CONTENIDO;
            lblFormato.Text = obj_c.FORMATO_CONTENIDO;
            lblClasificacionContenido.Text = obj_c.CLASIFICACION_CONTENIDO;
            lblGenero.Text = obj_c.GENERO;
            lblClasificacionPublico.Text = obj_c.CLASIFICACION_PUBLICO;
            lblGestion.Text = obj_c.PV_GESTION;
            lblTiempoHoras.Text = obj_c.PV_TIEMPO_HORA;
            lblTiempoMinutos.Text = obj_c.PV_TIEMPO_MINUTOS;
            lblAudio.Text = obj_c.PV_TIPO_AUDIO;
            lblFechaPublicacion.Text = obj_c.PD_FECHA_PUBLICACION.ToShortDateString();
            lblNacionalidad.Text = obj_c.PV_NACIONALIDAD_DESC;
            lblIdiomaOriginal.Text = obj_c.PV_IDIOMA_ORIGINAL_DESC;
            lblEsSubtitulada.Text = obj_c.PV_ES_SUBTITULADA;

            lblEstado.Text = obj_c.PV_ESTADO_CONTENIDO_DESC;
            lblStoryLine.Text=obj_c.PV_STORY_LINE;
            lblStoryLineIngles.Text=obj_c.PV_STORY_LINE_INGLES;
            lblSinopsis.Text = obj_c.PV_SINOPSIS;
            lblSinopsisIngles.Text = obj_c.PV_SINOPSIS_INGLES;

            lblDirector.Text = obj_c.PV_DIRECTOR;
            lblReparto.Text = obj_c.PV_REPARTO;
            lblCreditos.Text = obj_c.PV_CREDITOS;

            if(obj_c.PV_FOTO_HORIZONTAL!="")
                imgHorizontal.ImageUrl= obj_c.PV_FOTO_HORIZONTAL;
            else
                imgHorizontal.ImageUrl = "~/Imagenes/sin_imagen.png";

            if (obj_c.PV_FOTO_VERTICAL != "")
                imgVertical.ImageUrl = obj_c.PV_FOTO_VERTICAL;
            else
                imgVertical.ImageUrl = "~/Imagenes/sin_imagen.png";

            if (obj_c.PV_FOTO_MINIATURA != "")
                imgMiniatura.ImageUrl = obj_c.PV_FOTO_MINIATURA;
            else
                imgMiniatura.ImageUrl = "~/Imagenes/sin_imagen.png";

            if (obj_c.PV_TITULO != "")
                imgTitulo.ImageUrl =  obj_c.PV_TITULO;
            else
                imgTitulo.ImageUrl = "~/Imagenes/sin_imagen.png";

        }

        protected void ddlFormato_DataBound(object sender, EventArgs e)
        {
            ddlFormato.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClasificacionContenido_DataBound(object sender, EventArgs e)
        {
            ddlClasificacionContenido.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlClasificacionPublico_DataBound(object sender, EventArgs e)
        {
            ddlClasificacionPublico.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlEsTemporadas_DataBound(object sender, EventArgs e)
        {
            ddlEsTemporadas.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoAudio_DataBound(object sender, EventArgs e)
        {
            ddlTipoAudio.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlNacionalidad_DataBound(object sender, EventArgs e)
        {
            ddlNacionalidad.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlIdiomaOriginal_DataBound(object sender, EventArgs e)
        {
            ddlIdiomaOriginal.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlEsSubtitulada_DataBound(object sender, EventArgs e)
        {
            ddlEsSubtitulada.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlEsGratis_DataBound(object sender, EventArgs e)
        {
            ddlEsGratis.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlProductora_DataBound(object sender, EventArgs e)
        {
            ddlProductora.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ddlEstadoContenido_DataBound(object sender, EventArgs e)
        {
            ddlEstadoContenido.Items.Insert(0, "SELECCIONAR");
        }
    }
}