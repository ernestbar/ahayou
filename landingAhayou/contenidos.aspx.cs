using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class contenidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                if (Request.QueryString["t"] != null)
                {
                    string tipo = Request.QueryString["t"].ToString();
                    Repeater1.DataSource = Clases.Contenidos.PR_PAR_GET_CONTENIDOS_STR(tipo);
                    Repeater1.DataBind();
                }
                
            }
        }
    }
}