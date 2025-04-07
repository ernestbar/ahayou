using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class contenido_peliculas_admin : System.Web.UI.Page
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
                    lblCodContenidoSTR.Text = Session["cod_contenido_str"].ToString();
                    Clases.Contenidos_streaming obj = new Clases.Contenidos_streaming(lblCodContenidoSTR.Text);
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
            txtContenido.Text = "";
            txtContenidoMobile.Text = "";
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
                    Clases.Contenido_peliculas obj = new Clases.Contenido_peliculas("I", 0, lblCodContenidoSTR.Text,txtNombreContenido.Text,
                        txtContenido.Text, lblUsuario.Text,txtContenidoMobile.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {

                    Clases.Contenido_peliculas obj = new Clases.Contenido_peliculas("U", int.Parse(lblCodigo.Text), lblCodContenidoSTR.Text, txtNombreContenido.Text,
                        txtContenido.Text, lblUsuario.Text,txtContenidoMobile.Text);
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
                Clases.Contenido_peliculas obj_m = new Clases.Contenido_peliculas(int.Parse(lblCodigo.Text));
                txtNombreContenido.Text = obj_m.PV_NOMBRE_CONTENIDO_STR.ToString();
                txtContenido.Text = obj_m.PV_CONTENIDO.ToString();
                txtContenidoMobile.Text = obj_m.PV_CONTENIDO_MOBILE.ToString();
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
                Clases.Contenido_peliculas obj_m = new Clases.Contenido_peliculas("D", int.Parse(lblCodigo.Text), lblCodContenidoSTR.Text,"","",lblUsuario.Text,"");
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

        protected void btnVolverContenidosSTR_Click(object sender, EventArgs e)
        {
            Response.Redirect("contenido_str_admin.aspx?RME=119");
        }
    }
}