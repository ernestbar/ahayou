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
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                if (Session["usuario"] == null)
                {
                    lblUsuario.Text = "";
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                }
                //string pais = GetCountryFromRequest();
                //if (pais == "BO")
                //    lblMundo.Text = "BO";
                //else 
                //    lblMundo.Text = "RM";
                ////lblMundo.Text = pais;
                //Repeater2.DataBind();
                //lblMundo.Text= GetClientIpAddress();
                Clases.Suscriptores obj=new Clases.Suscriptores("ernesto.barron@gmail.com","123");
                string salida = obj.PV_DESCRIPCIONPR;


            }
        }

        protected void Repeater1_DataBinding(object sender, EventArgs e)
        {

           
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

            //return Request.UserHostAddress;
            return Request.UserHostAddress;
        }
       
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label id = (Label)e.Item.FindControl("lblIdNumero");
                //if (id.Text == "01")
                //{
                //    string javaScript = "document.getElementById('" + id.Text + "').class = 'header__pag-button carousel__button selected'";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                //}
                //else
                //{
                //    string javaScript = "document.getElementById('" + id.Text + "').class = 'header__pag-button carousel__button'";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                //}

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
    }
}