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
    public partial class dominios_admin : System.Web.UI.Page
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
            if (ddlDominio.SelectedIndex > 0)
                txtDominio.Text = ddlDominio.SelectedValue;
            else
                txtDominio.Text = "";
            MultiView1.ActiveViewIndex = 1;
        }
        public void limpiar()
        {
            lblAviso.Text = "";
            lblCodigo.Text = "";
            txtDominio.Text = "";
            txtDescripcion.Text = "";
            txtValCar.Text = "";
            txtCodigo.Text = "";
            txtValNum.Text = "";
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
                    Clases.Dominios obj = new Clases.Dominios("I",txtDominio.Text, txtCodigo.Text, txtDescripcion.Text,txtValCar.Text,txtValNum.Text,hfFechaSalida.Value, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                    ddlDominio.DataBind();
                }
                else
                {
                    Clases.Dominios obj = new Clases.Dominios("U", lblDominio.Text, txtCodigo.Text, txtDescripcion.Text, txtValCar.Text, txtValNum.Text, hfFechaSalida.Value, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                    ddlDominio.DataBind();
                }
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_dominios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                Clases.Dominios obj_m = new Clases.Dominios(lblDominio.Text,id);
                txtDescripcion.Text = obj_m.PV_DESCRIPCION;
                txtValCar.Text=obj_m.PV_VALOR_CARACTER;
                txtValNum.Text = obj_m.PV_VALOR_NUMERICO;
                txtDominio.Text = ddlDominio.SelectedValue;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_dominios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodigo.Text = datos[0];
                if (datos[1] == "ACTIVO")
                {
                    Clases.Dominios obj_m = new Clases.Dominios("D", lblDominio.Text, lblCodigo.Text, "", "", "", "", lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }
                else
                {
                    Clases.Dominios obj_m = new Clases.Dominios("A", lblDominio.Text, lblCodigo.Text, "", "", "", "", lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }

                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_roles_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }
        protected void ddlDominio_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsDominios.DataBind();
            Repeater1.DataBind();
            lblDominio.Text = ddlDominio.SelectedValue;
            txtDominio.Text = ddlDominio.SelectedValue;
        }

        protected void ddlDominio_DataBound(object sender, EventArgs e)
        {
            ddlDominio.Items.Insert(0, "SELECCIONAR");
        }
    }
}