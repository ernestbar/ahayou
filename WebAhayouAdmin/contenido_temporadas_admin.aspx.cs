using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebAhayouAdmin
{
    public partial class contenido_temporadas_admin : System.Web.UI.Page
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
                    lblCodContenidoSTR.Text= Session["cod_contenido_str"].ToString();
                    Clases.Contenidos_streaming obj=new Clases.Contenidos_streaming(lblCodContenidoSTR.Text);
                    lblTitulo.Text = obj.PV_NOMBRE_CONTENIDO;
                    txtNombreContenido.Text = obj.PV_NOMBRE_CONTENIDO;
                    //btnNuevo.Visible = false;
                    //lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}
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
            lblContenido.Text = "";
            lblEpisodiio.Text = "";
            lblOrden.Text = "";
            lblSinopsis.Text = "";
            lblSinopsisIngles.Text = "";
            lblStoryLine.Text = "";
            lblStoryLineIngles.Text = "";
            lblTemporada.Text = "";
            lblTiempoHoras.Text = "";
            lblTiempoMinutos.Text = "";
            txtContenido.Text = "";
            txtEpisodio.Text = "";
            txtHoras.Text = "";
            txtMinutos.Text = "";
            txtOrden.Text = "";
            txtSinopsis.Text = "";
            txtSinopsisIngles.Text = "";
            txtStoryLine.Text = "";
            txtStoryLineIngles.Text = "";
            txtTemporada.Text = "";
            
            //txtFormatoContenido.Text = ddlFormatoContenido.SelectedItem.Text;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bEdit = (Button)e.Item.FindControl("btnEditar");
                //Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                //bEdit.Visible = false;
                //bEliminar.Visible = false;
                //DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                //            bEdit.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                //            bEliminar.Visible = true;
                //    }

                //}
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {


                if (lblCodigo.Text == "")
                {
                    Clases.Contenido_temporadas obj = new Clases.Contenido_temporadas("I", 0, lblCodContenidoSTR.Text, int.Parse(txtOrden.Text),int.Parse(txtTemporada.Text),
                        int.Parse(txtEpisodio.Text),txtHoras.Text,txtMinutos.Text,txtStoryLine.Text,txtSinopsis.Text,txtStoryLineIngles.Text,
                        txtSinopsisIngles.Text,txtContenido.Text,lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {

                    Clases.Contenido_temporadas obj = new Clases.Contenido_temporadas("U",int.Parse(lblCodigo.Text), lblCodContenidoSTR.Text, int.Parse(txtOrden.Text), int.Parse(txtTemporada.Text),
                        int.Parse(txtEpisodio.Text), txtHoras.Text, txtMinutos.Text, txtStoryLine.Text, txtSinopsis.Text, txtStoryLineIngles.Text,
                        txtSinopsisIngles.Text, txtContenido.Text, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
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
               
                Clases.Contenido_temporadas obj_m = new Clases.Contenido_temporadas(int.Parse(lblCodigo.Text));
                txtOrden.Text=obj_m.PI_ORDEN.ToString();
                txtEpisodio.Text = obj_m.PI_EPISODIO.ToString();
                txtTemporada.Text = obj_m.PI_TEMPORADA.ToString();
                txtMinutos.Text = obj_m.PV_TIEMPO_MINUTOS.ToString();
                txtHoras.Text = obj_m.PV_TIEMPO_HORA.ToString();
                txtSinopsis.Text = obj_m.PV_SINOPSIS.ToString();
                txtSinopsisIngles.Text = obj_m.PV_SINOPSIS_INGLES.ToString();
                txtStoryLine.Text = obj_m.PV_STORY_LINE.ToString();
                txtStoryLineIngles.Text = obj_m.PV_STORY_LINE_INGLES.ToString();
                txtContenido.Text=obj_m.PV_CONTENIDO.ToString(); 
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
                Clases.Contenido_temporadas obj_m = new Clases.Contenido_temporadas("D", int.Parse(id), lblCodContenidoSTR.Text, 0, 0,
                        0, "", "", "", "", "", "", "", lblUsuario.Text);
                obj_m.ABM();
                lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
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

        

        protected void btnVer_Click(object sender, EventArgs e)
        {
            limpiar();
            string id = "";
            Button obj = (Button)sender;
            id = obj.CommandArgument.ToString();
            lblCodigo.Text = id;
            Clases.Contenido_temporadas temporada = new Clases.Contenido_temporadas(int.Parse(id));
            lblOrden.Text = temporada.PI_ORDEN.ToString();
            lblTemporada.Text=temporada.PI_TEMPORADA.ToString();
            lblEpisodiio.Text=temporada.PI_EPISODIO.ToString();
            lblTiempoHoras.Text = temporada.PV_TIEMPO_HORA.ToString();
            lblTiempoMinutos.Text=temporada.PV_TIEMPO_MINUTOS.ToString();
            lblSinopsis.Text = temporada.PV_SINOPSIS;
            lblSinopsisIngles.Text = temporada.PV_SINOPSIS_INGLES;
            lblStoryLine.Text = temporada.PV_STORY_LINE;
            lblStoryLineIngles.Text = temporada.PV_STORY_LINE_INGLES;
            lblContenido.Text = temporada.PV_CONTENIDO;

            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            limpiar();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnVolverContenidosSTR_Click(object sender, EventArgs e)
        {
            Response.Redirect("contenido_str_admin.aspx?RME=119");
        }
    }
}