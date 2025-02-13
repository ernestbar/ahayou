using landingAhayou.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var apiKey = "the_API_key";
                var apiBaseUrl = "https://www.bbr.com.bo/WSAhayou/";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("apikey", apiKey);


                HttpResponseMessage response = await client.GetAsync("api/Usuario/Login/" +txtEmail.Text +"/"+txtClave.Text);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var objectModels = JsonConvert.DeserializeObject<RespuestaAPI>(await response.Content.ReadAsStringAsync());
                    var resAux = JsonConvert.DeserializeObject<Resultado>(objectModels.resultado.ToString());
                    lblAviso.Text=resAux.token;
                }
            }
            catch (Exception ex)
            {
                
            }

        }
        public class Resultado
        {
            public int id_usuario { get; set; }
            public string nombres { get; set; }
            public string password { get; set; }
            public string rol { get; set; }
            public string token { get; set; }

        }
    }
}