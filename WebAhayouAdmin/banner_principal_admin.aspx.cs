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
    public partial class banner_principal_admin : System.Web.UI.Page
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
            lblAviso.Text = "";
            lblCodBanner.Text = "";
            txtCodBanner.Text = "";
            txtDescripcion.Text = "";
            txtDescripcion1.Text = "";
            txtDescripcion1Ingles.Text = "";
            txtDescripcionIngles.Text = "";
            ImageVertical.ImageUrl = "";
            lblImagenAnt.Text = "";
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
                string foto_imagen = "";
                if (lblCodBanner.Text == "")
                {
                    if (fuVertical.HasFile)
                    {
                        foto_imagen = fuVertical.FileName;
                    }
                    else
                    {
                        if (lblImagenAnt.Text != "")
                            foto_imagen = lblImagenAnt.Text;
                    }
                    string archivo = "";
                    if (fuVertical.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/0/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        archivo = fuVertical.FileName;
                        fuVertical.PostedFile.SaveAs(Ruta + archivo);
                    }
                    Clases.Banners_principales obj = new Clases.Banners_principales("I", "", txtDescripcion.Text, txtDescripcion1.Text, txtDescripcionIngles.Text, txtDescripcion1Ingles.Text, foto_imagen, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    if (fuVertical.HasFile)
                    {
                        foto_imagen = fuVertical.FileName;
                    }
                    else
                    {
                        if (lblImagenAnt.Text != "")
                            foto_imagen = lblImagenAnt.Text;
                    }
                    string archivo = "";
                    if (fuVertical.HasFile)
                    {
                        string Ruta = Server.MapPath("~/fotos_peliculas/0/");
                        if (!Directory.Exists(Ruta))
                        {
                            Directory.CreateDirectory(Ruta);
                        }
                        archivo = fuVertical.FileName;
                        fuVertical.PostedFile.SaveAs(Ruta + archivo);
                    }
                    Clases.Banners_principales obj = new Clases.Banners_principales("U", lblCodBanner.Text, txtDescripcion.Text, txtDescripcion1.Text,  txtDescripcionIngles.Text, txtDescripcion1Ingles.Text, foto_imagen, lblUsuario.Text);
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
                string nombre_archivo = "error_banner_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodBanner.Text = id;
                txtCodBanner.Text = id;
                txtCodBanner.Enabled = false;
                Clases.Banners_principales obj_m = new Clases.Banners_principales(id);
                txtDescripcion.Text = obj_m.PV_DESCRIPCION;
                txtDescripcion1.Text = obj_m.PV_DESCRIPCION1;
                txtDescripcionIngles.Text = obj_m.PV_DESCRIPCION_INGLES;
                txtDescripcion1Ingles.Text = obj_m.PV_DESCRIPCION1_INGLES;
                if (obj_m.PV_CONTENIDO != "")
                { 
                    ImageVertical.ImageUrl = obj_m.PV_CONTENIDO; 
                    PanelFotos.Visible = true;
                    string[] foto_name = obj_m.PV_CONTENIDO.Split('/');
                    int tamaño = foto_name.Length - 1;
                    lblImagenAnt.Text = foto_name[tamaño];
                }
                else
                    ImageVertical.ImageUrl = "~/Imagenes/sin_imagen.png";

                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_banner_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodBanner.Text = id;
                Clases.Banners_principales obj_m = new Clases.Banners_principales("D", lblCodBanner.Text, txtDescripcion.Text, txtDescripcion1.Text, "", txtDescripcionIngles.Text, txtDescripcion1Ingles.Text, lblUsuario.Text);
                obj_m.ABM();
                lblAviso.Text = obj_m.PV_DESCRIPCIONPR;


                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_banner_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }
    }
}