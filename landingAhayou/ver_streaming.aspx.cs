using landingAhayou.Clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class ver_streaming : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string[] datos_streaming= Session["url_streaming"].ToString().Split('|');
                //lblMenu.Text = Session["busqueda"].ToString();
                if (Session["usuario"] == null)
                {
                    Panel_logout.Visible = true;
                    Panel_login.Visible = false;
                    lblUsuario.Text = "";
                    //btnLogin.Visible = true;
                    //btnSuscribete.Visible = true;
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
                        Panel_logout.Visible = false;
                        Panel_login.Visible = true;
                        lblUsuario.Text = Session["usuario"].ToString();
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

                        if (lblplanSuscriptor.Text == "0")
                        {
                            if (datos_streaming[1] == "NO")
                                Response.Redirect("selecciona_plan_us.aspx");
                            else
                                Literal1.Text = datos_streaming[0];
                        }
                        else
                        {
                            Carteleras obj = new Carteleras("V", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), datos_streaming[2], "", lblUsuario.Text);
                            obj.ABM();
                            Literal1.Text = datos_streaming[0];
                        }
                    }
                    else
                    {
                        if (datos_streaming[1] == "NO")
                            Response.Redirect("login_us.aspx");
                        else
                            Literal1.Text = datos_streaming[0];
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
                    
                        
                    if (lblplanSuscriptor.Text == "0")
                    {
                        if (datos_streaming[1] == "NO")
                            Response.Redirect("selecciona_plan.aspx");
                        else
                            Literal1.Text = datos_streaming[0];
                    }
                    else
                    {
                        Carteleras obj = new Carteleras("V", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), datos_streaming[2], "", lblUsuario.Text);
                        obj.ABM();
                        Literal1.Text = datos_streaming[0];
                    
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
            string[] id = obj.CommandArgument.ToString().Split('|');
            Session["cod_perfil_suscriptor"] = id[0];
            lblPerfilSuscriptor.Text = id[0];
            Session["pin"] = id[1];
            Response.Cookies["cod_perfil_suscriptor"].Value = id[0];
            if (id[1] == "0")
                Response.Redirect("cartelera.aspx");
            else
                Response.Redirect("pin_perfil.aspx");

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