using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {

           
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblIdNumero");
                if (id.Text == "01")
                {
                    string javaScript = "document.getElementById('" + id.Text + "').class = 'header__pag-button carousel__button selected'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                }
                else
                {
                    string javaScript = "document.getElementById('" + id.Text + "').class = 'header__pag-button carousel__button'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                }

            }
        }

        protected void Repeater6_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblIdNumero");
                Panel panel1 = (Panel)e.Item.FindControl("panel_banner");
                Panel panel2 = (Panel)e.Item.FindControl("panel_pelicula");
                if (id.Text == "01")
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                }
                else
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                }

            }
        }
    }
}