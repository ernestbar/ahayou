using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                }


            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                 e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblCodPadre");
                if (id != null)
                {
                    string consulta = "id_datos='" + id.Text + "'";
                    Repeater rSegmentos = (Repeater)e.Item.FindControl("Repeater2");
                    rSegmentos.DataSource = Clases.Ingreso_app.PR_SEG_GET_MENUS_ROL(lblUsuario.Text, Int64.Parse(id.Text),"AHAYOUADM");
                    rSegmentos.DataBind();
                }

            }
        }

        protected void lbtnMenuHijo_Click(object sender, EventArgs e)
        {
            string id = "";
            LinkButton obj = (LinkButton)sender;
            id = obj.CommandArgument.ToString();
            Response.Redirect(id);
        }
    }
}