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
            if (!Page.IsPostBack)
            {
                if (Session["email"] == null)
                {
                    email.Text = "";
                }
                else
                {
                    email.Text=Session["email"].ToString();
                }
            }
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
            Clases.Suscriptores obj = new Clases.Suscriptores("I", email.Text, password.Text, "", nombre.Text, celular.Text, email.Text, codigo_aux.Text, email.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            string mensaje = @"<p><strong>Estimado usuari@ Ahayou</strong></p>
            <p><strong>&nbsp;</strong></p>
            <p>Bienvenido a Ahayou, nos alegra tenerte como suscriptor por favor ingrese al siguiente enlace o vuelva al login con la contrase&ntilde;a <em>&ldquo;123&rdquo;</em>, una vez colocada la contrase&ntilde;a se le pedir&aacute; que cambie su password por seguridad.</p>
            <p><a href=""https://www.bbr.com.bo/landingTest/login.aspx"">https://www.bbr.com.bo/landingTest/login.aspx</a></p>
            <p>Atentamente.</p>
            <p><strong>Equipo de soporte Ahayou.</strong></p>";
            Session["email"] = email.Text;
            Clases.enviar_correo objC = new Clases.enviar_correo();
            objC.enviar(email.Text, "Bienvenido usuario: " + email.Text, mensaje, "");
            Response.Redirect("verificar_correo.aspx");

        }
    }
}