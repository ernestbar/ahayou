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
                    //btnLogin.Visible = true;
                    //btnSuscribete.Visible = true;
                }
                else
                {
                    lblCodPlanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    lblUsuario.Text = Session["usuario"].ToString();
                    //btnLogin.Visible = false;
                    //btnSuscribete.Visible = false;
                }
              


            }
        }

        protected void lbtnPerfil_Click(object sender, EventArgs e)
        {
            
            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            Session["usuario"] = lblUsuario.Text;
            Session["cod_perfil_suscriptor"] = id[0];
            Session["pin"] = id[1];
            Response.Cookies["cod_perfil_suscriptor"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["cod_perfil_suscriptor"].Value = id[0];
            if (id[1] == "0")
                Response.Redirect("cartelera.aspx");
            else
            {
                Response.Redirect("pin_perfil.aspx");
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

       
    }
}