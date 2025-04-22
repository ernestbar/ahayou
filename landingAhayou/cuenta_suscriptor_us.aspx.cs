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
    public partial class cuenta_suscriptor_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

                    Clases.Suscriptores objS = new Suscriptores(lblUsuario.Text);
                    txtNombreCompleto.Text = objS.PV_NOMBRE_COMPLETO;
                    txtCelular.Text = objS.PV_CELULAR;
                    txtCodigo_aux.Text = objS.PV_CODIGO_AUXILIAR;
                    lblCuenta.Text = objS.PV_EMAIL;
                    //if (Session["menu"] == null) { lblMenu.Text = "0"; }
                    //else { lblMenu.Text = Session["menu"].ToString(); }
                    //Repeater2.DataBind();
                }

            }
        }

        protected void lbtnCmabiarPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("cambio_password_us.aspx");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_us.aspx");
        }

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete_us.aspx");
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            //lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera_us.aspx");
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
            Response.Redirect("home_us.aspx");
        }

        

        protected void lbtnPerfiles_Click(object sender, EventArgs e)
        {

            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            //Session["usuario"] = lblUsuario.Text;
            Session["cod_perfil_suscriptor"] = id;
            lblPerfilSuscriptor.Text = id;
            Response.Redirect("cartelera_us.aspx");

        }

        protected void lbtnSeleccionPlan_Click(object sender, EventArgs e)
        {
            Response.Redirect("selecciona_plan_us.aspx");
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
                        Response.Redirect("cuenta_suscriptor_us.aspx");
                    else
                    {
                        string script = string.Format("alert('{0}');", "Only the main profile can edit the account.");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                    }

                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.Suscriptores obj = new Suscriptores("U", lblUsuario.Text, "", "", txtNombreCompleto.Text, txtCelular.Text, lblUsuario.Text, txtCodigo_aux.Text, lblUsuario.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
        }

        protected void lbtnPerfil_Click(object sender, EventArgs e)
        {
            Panel_perfil.Visible = false;
            Panel_perfil_edicion.Visible = true;
            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            lblCodPerfilEdicion.Text = id[0];
            lblPinEdicion.Text = id[1];
            txtNombrePerfil.Text = id[2];
            txtNombrePerfil.Focus();
            Repeater4.DataBind();
            DataTable dt = new DataTable();

            dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                {
                    imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                    imgPerfil.DataBind();
                }
            }


        }

        protected void lbtnSeleccionAvatar_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            lblCodigoAvatarSeleccion.Text = id;
            odsAvataresEdicion.FilterExpression = "codigo_avatar='" + id + "'";
            Repeater4.DataBind();
        }

        protected void btnEdicionAvatar_Click(object sender, EventArgs e)
        {
            if (lblCodigoAvatarSeleccion.Text == "")
            {
                string script = string.Format("alert('{0}');", "You must select an avatar for editing.");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            else
            {
                Clases.Avatares obj = new Avatares("U", lblCodPerfilEdicion.Text, lblCodigoAvatarSeleccion.Text, txtNombrePerfil.Text, Int64.Parse(lblPinEdicion.Text), lblUsuario.Text);
                obj.ABM();
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                Panel_perfil_edicion.Visible = false;
                Panel_perfil.Visible = true;
                Repeater1.DataBind();
                Repeater7.DataBind();

            }
        }

        protected void lbtnSolicitarPIN_Click(object sender, EventArgs e)
        {
            Pines obj = new Pines("U", lblUsuario.Text, lblUsuario.Text);
            obj.ABM();

            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            string mensaje = @"<p><strong>Dear usuari@ Ahayou</strong></p>
            <p><strong>&nbsp;</strong></p>
            <p>We have reset your PIN, your new PIN is:" + obj.PB_PIN + " </p>" +
            @"<p>Sincerely.</p>
            <p><strong>Ahayou Support Team.</strong></p>";
            Clases.enviar_correo objC = new Clases.enviar_correo();
            objC.enviar(lblUsuario.Text, "Change user PIN: " + lblUsuario.Text, mensaje, "");
        }
    }
}