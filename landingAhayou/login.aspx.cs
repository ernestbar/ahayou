using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace landingAhayou
{
	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//MultiView1.ActiveViewIndex = 0;
			}
		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
			Clases.Suscriptores obj = new Clases.Suscriptores(email.Text, password.Text);
			if (obj.PV_DESCRIPCIONPR == "Login correcto")
			{
                Session["usuario"] = email.Text;
                lblUsuario.Text = email.Text;
                if (obj.PV_TEMPORAL == "1")
				{
                    Session["password_anterior"] = password.Text;
					Response.Redirect("cambio_password.aspx");
				}
				else
				{
                    Session["password_anterior"] = password.Text;

                    DataTable dt = new DataTable();
                    dt = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                            Session["codigo_plan"] = dr["codigo_plan"];
                        }
                        Response.Redirect("perfiles.aspx");
                    }
                    else
                    {
                        Response.Redirect("home.aspx");
                    }
                }
				
				
			}
			else
			{
				string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
			}
		}
        

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete.aspx");
        }

        protected void btnInicia_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void lbtnReset_Click(object sender, EventArgs e)
        {
			Session["email"]=email.Text;
			Response.Redirect("reset_password.aspx");
        }

        protected void lbtnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete.aspx");
        }
    }
}