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
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    email.Text = Request.Cookies["UserName"].Value;
                    password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
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
                    if (cbRecuerdame.Checked)
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Sesion"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Sesion"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Cookies["UserName"].Value = email.Text.Trim();
                    Response.Cookies["Password"].Value = password.Text.Trim();
                    Response.Cookies["Sesion"].Value = obj.PV_SESION;
                    Session["password_anterior"] = password.Text;

                    DataTable dt = new DataTable();
                    dt = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        //Response.Cookies["cod_plan_susucriptor"].Expires = DateTime.Now.AddDays(30);
                        //Response.Cookies["codigo_plan"].Expires = DateTime.Now.AddDays(30);
                        foreach (DataRow dr in dt.Rows)
                        {
                            Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                            Session["codigo_plan"] = dr["codigo_plan"];
                            //Response.Cookies["cod_plan_susucriptor"].Value = dr["cod_plan_suscriptor"].ToString();
                            //Response.Cookies["codigo_plan"].Value = dr["codigo_plan"].ToString();
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