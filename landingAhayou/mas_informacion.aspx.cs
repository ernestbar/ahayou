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
    public partial class mas_informacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;

                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblplanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();

                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
                    DataTable dt = new DataTable();
                    dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                        {
                            imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                        }
                    }
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
            lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera.aspx");
            //Repeater2.DataBind();
        }
    }
}