using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class home_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
                }

            }
        }
        private string GetCountryFromRequest()
        {
            string clientIP = GetClientIpAddress();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://ipinfo.io/" + clientIP + "/json").Result;
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var data = JObject.Parse(json);
                        return (data["country"] == null) ? "Unknown" : data["country"].ToString();
                    }
                    catch
                    {
                        return "Unknown";
                    }
                }
            }

            return "Unknown";
        }
        private string GetClientIpAddress()
        {
            // ... Helper function from previous examples ...
            return Request.UserHostAddress;
        }
        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {


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

                    // string javaScript = "document.getElementById('" + panel1.ClientID + "').class = 'header__pag-button carousel__button selected'";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                }
                else
                {
                    panel1.Visible = false;
                    panel2.Visible = true;
                }

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
        protected void btnSuscribeteEmail_Click(object sender, EventArgs e)
        {
            Session["email"] = email.Text;
            Response.Redirect("suscribete.aspx");
        }

        protected void lbtnSeleccionPlan_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            Session["url_pasarela"] = id;
            Response.Redirect("forma_pago.aspx");
        }
    }
}