using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
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
            lblAviso.Text = "";
            lblCodigo.Text = "";
            txtCodigo.Text = "";
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


                if (lblCodigo.Text == "")
                {
                    //Clases.Clasificacion_contenidos obj = new Clases.Clasificacion_contenidos("I", 0, Int64.Parse(ddlFormatoContenido.SelectedValue), ddlClasificacion.SelectedValue, lblUsuario.Text);
                    //obj.ABM();
                    //lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {

                    //Clases.Clasificacion_contenidos obj = new Clases.Clasificacion_contenidos("U", Int64.Parse(lblCodigo.Text), Int64.Parse(ddlFormatoContenido.SelectedValue), ddlClasificacion.SelectedValue, lblUsuario.Text);
                    //obj.ABM();
                    //lblAviso.Text = obj.PV_DESCRIPCIONPR;
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
                txtCodigo.Text = id;
                txtCodigo.Enabled = false;
                Clases.Clasificacion_contenidos obj_m = new Clases.Clasificacion_contenidos(Int64.Parse(lblCodigo.Text));
                txtCodigo.Text = obj_m.PB_COD_CLASIFICACION_CONTENIDO.ToString();
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

        }

        protected void btnTemporadas_Click(object sender, EventArgs e)
        {

        }

        protected void btnPeliculas_Click(object sender, EventArgs e)
        {

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
            

            lblStoryLine.Text=obj_c.PV_STORY_LINE;
            lblStoryLineIngles.Text=obj_c.PV_STORY_LINE_INGLES;
            lblSinopsis.Text = obj_c.PV_SINOPSIS;
            lblSinopsisIngles.Text = obj_c.PV_SINOPSIS_INGLES;

            lblDirector.Text = obj_c.PV_DIRECTOR;
            lblReparto.Text = obj_c.PV_REPARTO;
            lblCreditos.Text = obj_c.PV_CREDITOS;

            if(obj_c.PV_FOTO_HORIZONTAL!="")
                imgHorizontal.ImageUrl="~/fotos_peliculas/"+id+"/" + obj_c.PV_FOTO_HORIZONTAL;

            if (obj_c.PV_FOTO_VERTICAL != "")
                imgVertical.ImageUrl = "~/fotos_peliculas/" + id + "/" + obj_c.PV_FOTO_VERTICAL;

            if (obj_c.PV_FOTO_MINIATURA != "")
                imgMiniatura.ImageUrl = "~/fotos_peliculas/" + id + "/" + obj_c.PV_FOTO_MINIATURA;
            
            if (obj_c.PV_TITULO != "")
                imgTitulo.ImageUrl = "~/fotos_peliculas/" + id + "/" + obj_c.PV_TITULO;

        }
    }
}