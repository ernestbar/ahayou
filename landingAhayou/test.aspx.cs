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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string pais = GetCountryFromRequest();
                //Label1.Text = pais;
            }
        }
        private string GetCountryFromRequest()
        {
            string clientIP = "190.104.29.18";// GetClientIpAddress();

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
    }

}