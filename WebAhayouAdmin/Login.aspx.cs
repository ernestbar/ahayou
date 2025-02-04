using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                txtEmail.Focus();
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Clases.Ingreso_app obj=new Clases.Ingreso_app(txtEmail.Text,txtPassword.Text);
            obj.INGRESAR();
            if (obj.PV_DESCRIPCIONPR == "Login correcto")
            {
                Session["usuario"]=txtEmail.Text;
                Response.Redirect("Dashboard.aspx");
            }
            else 
            {
                lblAviso.Text = obj.PV_DESCRIPCIONPR;
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            Clases.Usuarios per = new Clases.Usuarios("R", "", "", "", "", "", "", "", "", 0, 0, 0,
                        "", txtEmail.Text, "", "", "", DateTime.Now, DateTime.Now, "", txtEmail.Text);
            per.ABM();
            Clases.enviar_correo objC = new Clases.enviar_correo();
            string resultado2 = objC.enviar(txtEmail.Text, "Reseteo de password del usuario " + txtEmail.Text, " Querido usuario:" + "<br/><br/>" + txtEmail.Text + "<br/><br/>" + " <br/><br/> Ahora puede logearse con el password 123 y cambiarlo desde el administrador web: <br/><br/>" + "<br/><br/> Saludos.", "");
            if (resultado2 == "OK")
                lblAviso.Text = per.PV_DESCRIPCIONPR + " Enviamos un password temporal a su correo.";
            else
                lblAviso.Text = per.PV_DESCRIPCIONPR + "Hubo un problema en el envio de su password temporal a su correo, comuniquese con el administrador.";
            string script = string.Format("alert('{0}');", lblAviso.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
        }
    }
}