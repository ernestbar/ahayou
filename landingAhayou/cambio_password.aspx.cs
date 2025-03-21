using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class cambio_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblPasswordAnterior.Text = Session["password_anterior"].ToString();
                if (Session["usuario"] == null)
                {
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
                    email.Text = lblUsuario.Text;
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

        protected void btnSuscribeteEmail_Click(object sender, EventArgs e)
        {
            Session["email"] = email.Text;
            Response.Redirect("suscribete.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.Suscriptores obj = new Clases.Suscriptores("C", email.Text, password.Text, lblPasswordAnterior.Text, "", "", email.Text, "", email.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            

            //Clases.enviar_correo objC = new Clases.enviar_correo();
            //objC.enviar(email.Text, "Reseteo de contraseña usuario: " + lblEmail.Text, mensaje, "");
            lblAviso.Text = obj.PV_DESCRIPCIONPR;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario") ;
            Response.Redirect("home.aspx");
        }
    }
}