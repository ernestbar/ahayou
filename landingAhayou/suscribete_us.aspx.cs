using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class suscribete_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["email"] == null)
                {
                    email.Text = "";
                }
                else
                {
                    email.Text = Session["email"].ToString();
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_us.aspx");
        }

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete_us.aspx");
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Clases.Suscriptores obj = new Clases.Suscriptores("I", email.Text, password.Text, "", nombre.Text, celular.Text, email.Text, codigo_aux.Text, email.Text);
            obj.ABM();
            if (obj.PV_ESTADOPR == "1")
            {
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            else
            {
                string mensaje = @"<p><strong>Dear user Ahayou</strong></p>
                <p><strong>&nbsp;</strong></p>
                <p>Welcome to Ahayou, we are glad to have you as a subscriber. Please enter the following link.</p>
                <p><a href=""https://ahayou.bo/login_us.aspx"">https://ahayou.bo/login_us.aspx</a></p>
                <p>Sincerely.</p>
                <p><strong>Ahayou Support Team.</strong></p>";
                Session["email"] = email.Text;
                Clases.enviar_correo objC = new Clases.enviar_correo();
                objC.enviar(email.Text, "Welcome user: " + email.Text, mensaje, "");
                Response.Cookies["UserName"].Value = email.Text.Trim();
                Response.Cookies["Password"].Value = password.Text.Trim();
                Response.Redirect("verificar_correo_us.aspx");
            }

                

        }
    }
}