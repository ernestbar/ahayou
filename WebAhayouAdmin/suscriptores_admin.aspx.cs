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
    public partial class suscriptores_admin : System.Web.UI.Page
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
            lblCodSuscriptor.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtPassword.Text = "";
            txtUsuario.Text = "";
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
                if (lblCodSuscriptor.Text == "")
                {
                    Clases.Suscriptores obj = new Clases.Suscriptores("I", txtUsuario.Text, txtPassword.Text, "",txtNombre.Text,txtCelular.Text,txtEmail.Text, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Suscriptores obj = new Clases.Suscriptores("U", txtUsuario.Text, txtPassword.Text, "", txtNombre.Text, txtCelular.Text, txtEmail.Text, lblUsuario.Text);
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
                string nombre_archivo = "error_susucriptores_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodSuscriptor.Text = id;
                Clases.Suscriptores obj_m = new Clases.Suscriptores(id);
                txtUsuario.Text = obj_m.PV_USUARIOI;
                txtPassword.Text = obj_m.PV_PASSWORD;
                txtNombre.Text = obj_m.PV_NOMBRE_COMPLETO;
                txtCelular.Text = obj_m.PV_CELULAR;
                txtEmail.Text = obj_m.PV_EMAIL;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_susucriptores_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                string[] datos = id.Split('|');
                lblCodSuscriptor.Text = datos[0];
                if (datos[1] == "ACTIVO")
                {
                    Clases.Suscriptores obj_m = new Clases.Suscriptores("D",lblCodSuscriptor.Text, txtPassword.Text, "", txtNombre.Text, txtCelular.Text, txtEmail.Text, lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }
                //else
                //{
                //    Clases.Suscriptores obj_m = new Clases.Suscriptores("A", lblCodSuscriptor.Text, txtPassword.Text, "", txtNombre.Text, txtCelular.Text, txtEmail.Text, lblUsuario.Text);
                //    obj_m.ABM();
                //    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                //}

                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_susucriptores_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }
        protected void btnResetear_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Clases.Suscriptores obj_m = new Clases.Suscriptores("R", id,"", "", "", "","", lblUsuario.Text);
                obj_m.ABM();
                lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                Clases.enviar_correo objC = new Clases.enviar_correo();
                string resultado2 = objC.enviar(id, "Reseteo de password del usuario " + id, " Querido usuario:" + "<br/><br/>" + id + "<br/><br/>" + " <br/><br/> Ahora puede logearse con el password 123 y cambiarlo desde el administrador web: <br/><br/>" + "<br/><br/> Saludos.", "");
                if (resultado2 == "OK")
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR + " Enviamos un password temporal a su correo.";
                else
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR + "Hubo un problema en el envio de su password temporal a su correo, comuniquese con el administrador.";
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_suscriptores_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }
    }
}