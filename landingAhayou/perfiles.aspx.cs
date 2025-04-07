using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class perfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                if (Session["usuario"] == null)
                {
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                }
                else
                {
                    lblCodPlanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
                }
              


            }
        }

        protected void lbtnPerfil_Click(object sender, EventArgs e)
        {
            
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            Session["usuario"] = lblUsuario.Text;
            Session["cod_perfil_suscriptor"] = id;
            Response.Redirect("cartelera.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                TextBox texto_pin = (TextBox)e.Item.FindControl("txtPin");
                TextBox texto_pin2 = (TextBox)e.Item.FindControl("txtPin2");
                Panel panel_pin = (Panel)e.Item.FindControl("panel_pin");
                if (texto_pin2.Text == "0")
                {
                    panel_pin.Visible = false;
                }
                else
                {
                    panel_pin.Visible = true;
                }

            }
        }
    }
}