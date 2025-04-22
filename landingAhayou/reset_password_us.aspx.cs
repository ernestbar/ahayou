using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class reset_password_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblEmail.Text = Session["email"].ToString();
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clases.Suscriptores obj = new Clases.Suscriptores("R", lblEmail.Text, "", "", "", "", lblEmail.Text, "", lblEmail.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            string mensaje = @"<p><strong>Dear user Ahayou</strong></p>
            <p><strong>&nbsp;</strong></p>
            <p>We have reset your password. Please enter the following link or log back in with the password ""123."" Once you enter the password, you will be prompted to change it for security reasons.</p>
            <p><a href=""https://ahayou.bo/login_us.aspx"">https://ahayou.bo/login_us.aspx</a></p>
            <p>Sincerely.</p>
            <p><strong>Ahayou Support Team.</strong></p>";

            Clases.enviar_correo objC = new Clases.enviar_correo();
            objC.enviar(lblEmail.Text, "User password reset: " + lblEmail.Text, mensaje, "");
            lblAviso.Text = obj.PV_DESCRIPCIONPR + " We send an email to your address." + lblEmail.Text;
        }
    }
}