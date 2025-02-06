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
    public partial class planes_admin : System.Web.UI.Page
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
            lblCodPlan.Text = "";
            txtCantMes.Text = "";
            txtCaracteristicas.Text = "";
            txtCaracteristicasUs.Text = "";
            txtNroPlan.Text = "";
            txtPlan.Text = "";
            txtPlanUs.Text = "";
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
                if (lblCodPlan.Text == "")
                {
                    Clases.Planes_paquetes obj = new Clases.Planes_paquetes("I", 0, Int64.Parse(txtNroPlan.Text), txtPlan.Text, txtPlanUs.Text,Int64.Parse(txtCantMes.Text),ddlMundo.SelectedValue,ddlMoneda.SelectedValue,decimal.Parse(txtMonto.Text),txtCaracteristicas.Text,txtCaracteristicasUs.Text,Int64.Parse(txtCantPerfiles.Text),lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Planes_paquetes obj = new Clases.Planes_paquetes("U", Int64.Parse(lblCodPlan.Text), Int64.Parse(txtNroPlan.Text), txtPlan.Text, txtPlanUs.Text, Int64.Parse(txtCantMes.Text), ddlMundo.SelectedValue, ddlMoneda.SelectedValue, decimal.Parse(txtMonto.Text), txtCaracteristicas.Text, txtCaracteristicasUs.Text, Int64.Parse(txtCantPerfiles.Text), lblUsuario.Text);
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
                string nombre_archivo = "error_planes_admin" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodPlan.Text = id;
                Clases.Planes_paquetes obj_m = new Clases.Planes_paquetes(Int64.Parse(id));
                txtNroPlan.Text = obj_m.PB_NRO_PLAN.ToString();
                txtPlan.Text = obj_m.PV_PLAN;
                txtPlanUs.Text = obj_m.PV_PLAN_INGLES;
                txtCantMes.Text = obj_m.PB_CANT_MES.ToString();
                txtCantPerfiles.Text = obj_m.PB_CANT_PERFIL.ToString();
                txtCaracteristicas.Text = obj_m.PV_CARACTERISTICAS;
                txtCaracteristicasUs.Text = obj_m.PV_CARACTERISTICAS_INGLES;
                txtMonto.Text=obj_m.PD_MONTO.ToString();
                ddlMoneda.DataBind();
                ddlMoneda.SelectedValue = obj_m.PV_MONEDA;
                ddlMundo.DataBind();
                ddlMundo.SelectedValue=obj_m.PV_MUNDO;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_planes_admin" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodPlan.Text = datos[0];
                if (datos[1] == "ACTIVO")
                {
                    Clases.Planes_paquetes obj_m = new Clases.Planes_paquetes("D", Int64.Parse(lblCodPlan.Text), 0, "", "", 0, "", "", 0, "", "",0, lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }
                else 
                {
                    Clases.Planes_paquetes obj_m = new Clases.Planes_paquetes("A", Int64.Parse(lblCodPlan.Text), 0, "", "", 0, "", "", 0, "", "",0, lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }
                

                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_planes_admin" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }

        protected void ddlMundo_DataBound(object sender, EventArgs e)
        {
            ddlMundo.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlMoneda_DataBound(object sender, EventArgs e)
        {
            ddlMoneda.Items.Insert(0, "SELECCIONAR");
        }
    }
}