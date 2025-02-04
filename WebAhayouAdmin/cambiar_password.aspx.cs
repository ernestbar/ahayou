using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class cambiar_password : System.Web.UI.Page
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
                   
                    lblUsuario.Text = Session["usuario"].ToString();
                    txtPassword.Text = "";
                    txtPasswordAnterior.Text = "";
                }
            }
        }
        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                
                Clases.Usuarios per = new Clases.Usuarios("C", "", "", "", "", "", "", "", "", 0, 0, 0,
                       "", lblUsuario.Text, txtPassword.Text, txtPasswordAnterior.Text, "", DateTime.Now, DateTime.Now, "", lblUsuario.Text);
                per.ABM();
                lblAviso.Text = per.PV_DESCRIPCIONPR;
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);


            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_cambio_password_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}