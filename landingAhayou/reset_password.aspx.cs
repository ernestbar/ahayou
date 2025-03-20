using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class reset_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblEmail.Text = Session["email"].ToString();
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

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}