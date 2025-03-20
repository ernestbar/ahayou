using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
				Response.Redirect("perfiles.aspx");
			}
			else
			{
				string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
			}
		}
        
    }
}