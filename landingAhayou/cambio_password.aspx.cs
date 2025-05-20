using landingAhayou.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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
                if (Session["password_anterior"] == null || Session["password_anterior"] == "")
                {
                    txtPassAnt.ReadOnly = false;
                }
                else
                {
                    lblPasswordAnterior.Text = Session["password_anterior"].ToString();
                    txtPassAnt.Text = Session["password_anterior"].ToString();
                    txtPassAnt.ReadOnly = false;
                }
                if (Session["usuario"] == null)
                {
                    Panel_logout.Visible = true;
                    Panel_login.Visible = false;
                    lblUsuario.Text = "";
                    //btnLogin.Visible = true;
                    //btnSuscribete.Visible = true;
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        Panel_logout.Visible = false;
                        Panel_login.Visible = true;
                        string email = Request.Cookies["UserName"].Value;
                        lblNusuario.Text = email;
                        DataTable dt = new DataTable();
                        dt = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(email);
                        if (dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                                Session["codigo_plan"] = dr["codigo_plan"];
                            }
                            //Response.Redirect("perfiles.aspx");
                        }
                        Session["usuario"] = email;
                    }
                }
                else
                {
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        string email = Request.Cookies["UserName"].Value;
                        lblNusuario.Text = email;
                        DataTable dt2 = new DataTable();
                        dt2 = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(email);
                        if (dt2.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt2.Rows)
                            {
                                Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                                Session["codigo_plan"] = dr["codigo_plan"];
                            }
                            //Response.Redirect("perfiles.aspx");
                        }
                        Session["usuario"] = email;
                    }

                    Panel_logout.Visible = false;
                    Panel_login.Visible = true;
                    lblUsuario.Text = Session["usuario"].ToString();
                    email.Text = Session["usuario"].ToString();
                    lblNusuario.Text = Session["usuario"].ToString();
                    if (Session["cod_plan_suscriptor"] == null)
                    { lblplanSuscriptor.Text = "0"; Repeater8.Visible = true; }
                    else
                        lblplanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    if (Session["cod_perfil_suscriptor"] == null)
                        lblPerfilSuscriptor.Text = "0";
                    else
                        lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();

                    if (Session["codigo_plan"] == null)
                        lblCodigoPlan.Text = "0";
                    else
                        lblCodigoPlan.Text = Session["codigo_plan"].ToString();
                    if (Request.Cookies["cod_perfil_suscriptor"] != null)
                    {
                        lblPerfilSuscriptor.Text = Request.Cookies["cod_perfil_suscriptor"].Value;
                    }
                    //btnLogin.Visible = false;
                    //btnSuscribete.Visible = false;
                    imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                    DataTable dt = new DataTable();

                    dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                        {
                            imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                        }
                    }
                    //if (Session["menu"] == null) { lblMenu.Text = "0"; }
                    //else { lblMenu.Text = Session["menu"].ToString(); }
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
            Clases.Suscriptores obj = new Clases.Suscriptores("C", email.Text, txtPassword.Text, txtPassAnt.Text, "", "", email.Text, "", email.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            

            //Clases.enviar_correo objC = new Clases.enviar_correo();
            //objC.enviar(email.Text, "Reseteo de contraseña usuario: " + lblEmail.Text, mensaje, "");
            lblAviso.Text = obj.PV_DESCRIPCIONPR;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (lblPasswordAnterior.Text == "123")
            {
                Session.Remove("usuario") ;
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("cartelera.aspx");
            }

        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            //lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Sesion"] != null)
            {
                Sesiones obj = new Sesiones("D", lblUsuario.Text, Request.Cookies["Sesion"].Value, lblUsuario.Text);
                obj.ABM();
            }
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Sesion"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("home.aspx");
        }
        protected void lbtnPerfiles_Click(object sender, EventArgs e)
        {

            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            //Session["usuario"] = lblUsuario.Text;
            Response.Cookies["cod_perfil_suscriptor"].Value = id;
            Session["cod_perfil_suscriptor"] = id;
            lblPerfilSuscriptor.Text = id;
            Response.Redirect("cartelera.aspx");

        }
        protected void lbtnCuenta_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                {

                    if (dr["es_principal"].ToString() == "SI")
                        Response.Redirect("cuenta_suscriptor.aspx");
                    else
                    {
                        string script = string.Format("alert('{0}');", "Solo el perfil principal puede editar la cuenta.");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                    }

                }
            }

        }
    }
}