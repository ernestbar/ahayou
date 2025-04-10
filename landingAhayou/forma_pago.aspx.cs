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
    public partial class forma_pago : System.Web.UI.Page
    {
        public string video_url = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Panel_logout.Visible = true;
                    Panel_login.Visible = false;
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                    

                }
                else
                {
                    
                    ifrmPago.Src = Session["url_pasarela"].ToString()+"123";
                    ifrmPago.DataBind();
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
                    { lblCodigoPlan.Text = "0"; Repeater7.Visible = false; }
                    else
                        lblCodigoPlan.Text = Session["codigo_plan"].ToString();

                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
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
                    if (Session["menu"] == null) { lblMenu.Text = "0"; }
                    else { lblMenu.Text = Session["menu"].ToString(); }
                }

            }

        }
        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera.aspx");
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
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