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
    public partial class menus_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                lblUsuario.Text = "1";//aqui debe ir el usuario logeado
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
            lblCodMenu.Text = "";
            txtDetalle.Text = "";
            txtDescripcion.Text = "";
            ddlSistema.DataBind();
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 menu_padre = 0;
                if (ddlMenuPadre.SelectedIndex == 0)
                    menu_padre = 0;
                else
                    menu_padre = Int64.Parse(ddlMenuPadre.SelectedValue);

                if (lblCodMenu.Text == "")
                {
                    Clases.Menus obj = new Clases.Menus("I", 0, menu_padre, txtDescripcion.Text, txtDetalle.Text, ddlSistema.SelectedValue, lblUsuario.Text);
                    obj.ABM();
                    lblAviso.Text = obj.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Menus obj = new Clases.Menus("U", Int64.Parse(lblCodMenu.Text), menu_padre, txtDescripcion.Text, txtDetalle.Text, ddlSistema.SelectedValue, lblUsuario.Text);
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
                string nombre_archivo = "error_MENUS_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodMenu.Text = id;
                Clases.Menus obj_m = new Clases.Menus(Int64.Parse(id));
                txtDescripcion.Text = obj_m.PV_DESCRIPCIONMEN;
                txtDetalle.Text = obj_m.PV_DETALLE;
                ddlSistema.DataBind();
                ddlSistema.SelectedValue = obj_m.PV_SISTEMAS;
                ddlMenuPadre.DataBind();
                if(obj_m.PB_COD_MENU_PADRE>0)
                    ddlMenuPadre.SelectedValue = obj_m.PB_COD_MENU_PADRE.ToString();
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menus_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodMenu.Text = datos[0];
                Int64 menu_padre = 0;
                if (ddlMenuPadre.SelectedIndex == 0)
                    menu_padre = 0;
                else
                    menu_padre=Int64.Parse(ddlMenuPadre.SelectedValue);
                if (datos[1] == "ACTIVO")
                {
                    Clases.Menus obj_m = new Clases.Menus("D",Int64.Parse(lblCodMenu.Text) ,menu_padre, txtDescripcion.Text, txtDetalle.Text, ddlSistema.SelectedValue, lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }
                else
                {
                    Clases.Menus obj_m = new Clases.Menus("A", Int64.Parse(lblCodMenu.Text), menu_padre, txtDescripcion.Text, txtDetalle.Text, ddlSistema.SelectedValue, lblUsuario.Text);
                    obj_m.ABM();
                    lblAviso.Text = obj_m.PV_DESCRIPCIONPR;
                }

                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_menus_admin_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "We have some problems consult with the administrator.";
            }
        }

        protected void ddlSistema_DataBound(object sender, EventArgs e)
        {
            ddlSistema.SelectedValue = "AHAYOUADM";
            
        }

        protected void ddlMenuPadre_DataBound(object sender, EventArgs e)
        {
            ddlMenuPadre.Items.Insert(0, "ES PADRE");
        }
    }
}