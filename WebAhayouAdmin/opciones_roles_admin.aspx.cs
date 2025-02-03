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
    public partial class opciones_roles_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //MultiView1.ActiveViewIndex = 0;
                lblUsuario.Text = "1";//aqui debe ir el usuario logeado
            }
        }
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRol_DataBound(object sender, EventArgs e)
        {
            ddlRol.Items.Insert(0, "SELECCIONAR");

        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                Clases.Opciones_roles obj_mr = new Clases.Opciones_roles("D", datos[0], ddlMenuRol.SelectedValue,ddlRol.SelectedValue, datos[2], datos[1], lblUsuario.Text);
                obj_mr.ABM();
                lblAviso.Text = obj_mr.PV_DESCRIPCIONPR;
                Repeater1.DataBind();
                Repeater2.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                Clases.Opciones_roles obj_mr = new Clases.Opciones_roles("I","", ddlMenuRol.SelectedValue, ddlRol.SelectedValue, datos[1], datos[0], lblUsuario.Text);
                obj_mr.ABM();
                lblAviso.Text = obj_mr.PV_DESCRIPCIONPR;
                Repeater1.DataBind();
                Repeater2.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menu_rol_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void ddlMenuRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMenuRol_DataBound(object sender, EventArgs e)
        {
            ddlMenuRol.Items.Insert(0, "SELECCIONAR");
        }
    }
}