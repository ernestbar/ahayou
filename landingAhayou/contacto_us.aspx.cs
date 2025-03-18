using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class contacto_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ibtnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Clases.Contenidos.PR_PAR_GET_REDES_SOCIALES_STR();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["red_social"].ToString() == "WHATSAPP")
                    Response.Redirect(dr["URL"].ToString());
            }
        }
    }
}