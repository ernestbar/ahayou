using landingAhayou.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class pin_perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                        Panel_logout.Visible = false;
                        Panel_login.Visible = true;
                        lblUsuario.Text = Session["usuario"].ToString();
                        Repeater8.Visible = false;
                        if (Session["cod_plan_suscriptor"] == null)
                        { lblplanSuscriptor.Text = "0"; Repeater8.Visible = false; }
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

                        //btnLogin.Visible = false;
                        //btnSuscribete.Visible = false;
                        imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                        DataTable dt3 = new DataTable();

                        dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                        foreach (DataRow dr in dt3.Rows)
                        {
                            if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                            {
                                imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    TextBox1.Focus();
                    lblPin.Text = Session["pin"].ToString();
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        string email = Request.Cookies["UserName"].Value;
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
                        Repeater8.Visible = false;
                        if (Session["cod_plan_suscriptor"] == null)
                        { lblplanSuscriptor.Text = "0"; Repeater8.Visible = false; }
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

                        //btnLogin.Visible = false;
                        //btnSuscribete.Visible = false;
                        imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                        DataTable dt4 = new DataTable();

                        dt4 = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                        foreach (DataRow dr in dt4.Rows)
                        {
                            if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                            {
                                imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                            }
                        }
                    }

                    Panel_logout.Visible = false;
                    Panel_login.Visible = true;
                    lblUsuario.Text = Session["usuario"].ToString();
                    Repeater8.Visible = false;
                    if (Session["cod_plan_suscriptor"] == null)
                    { lblplanSuscriptor.Text = "0"; Repeater8.Visible = false; }
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
        protected void lbtnPerfiles_Click(object sender, EventArgs e)
        {

            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            Session["cod_perfil_suscriptor"] = id[0];
            lblPerfilSuscriptor.Text = id[0];
            if (id[1] == "0")
                Response.Redirect("cartelera.aspx");
            else
                Response.Redirect("pin_perfil.aspx");
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
            //Session["menu"] = id;
            //Response.Redirect("cartelera.aspx");
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

        

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string pin_digitado = TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text;
            if (lblPin.Text == pin_digitado)
            {
                Response.Redirect("cartelera.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", "El pin digitado es incorrecto");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
        }

        protected void lbtnResetPin_Click(object sender, EventArgs e)
        {
            Pines obj = new Pines("U", lblUsuario.Text, lblUsuario.Text);
            obj.ABM();
          
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            string mensaje = @"<p><strong>Estimado usuari@ Ahayou</strong></p>
            <p><strong>&nbsp;</strong></p>
            <p>Hemos realizado el reseteo de su PIN, su nuevo PIN es: "+ obj.PB_PIN+" </p>"+
            @"<p>Atentamente.</p>
            <p><strong>Equipo de soporte Ahayou.</strong></p>";
            lblPin.Text = obj.PB_PIN.ToString();
            Clases.enviar_correo objC = new Clases.enviar_correo();
            objC.enviar(lblUsuario.Text, "Cambio de PIN usuario: " + lblUsuario.Text, mensaje, "");
        }
    }
}