using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class suscribete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete.aspx");
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Clases.Suscriptores obj = new Clases.Suscriptores("I",email.Text,password.Text,"",nombre.Text,celular.Text,email.Text,codigo_aux.Text,email.Text);
            //obj.ABM();
            //string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            Response.Redirect("verificar_correo.aspx");

        }
    }
}