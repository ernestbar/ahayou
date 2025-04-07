using landingAhayou.Clases;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    string email = Request.Cookies["UserName"].Value;
                    DataTable dt = new DataTable();
                    dt = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(email);
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                            Session["codigo_plan"] = dr["codigo_plan"];
                        }
                        Response.Redirect("perfiles.aspx");
                    }
                    Session["usuario"]=email;
                }

                if (Session["usuario"] == null)
                {
                    Panel_logout.Visible = true;
                    Panel_login.Visible = false;
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                   

                }
                else
                {
                    Panel_logout.Visible = false;
                    Panel_login.Visible = true;
                    lblUsuario.Text = Session["usuario"].ToString();
                    if (Session["cod_plan_suscriptor"] == null)
                    { lblplanSuscriptor.Text = "0"; Repeater8.Visible = true; }
                    else
                        lblplanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    if (Session["cod_perfil_suscriptor"] == null)
                        lblPerfilSuscriptor.Text = "0";
                    else
                        lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();

                    if (Session["codigo_plan"] == null)
                        lblCodigoPlan.Text = "0";
                    else
                        lblCodigoPlan.Text = Session["codigo_plan"].ToString();

                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
                    imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                    DataTable dt = new DataTable();

                    dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                        {
                            imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                        }
                    }
                    if (Session["menu"] == null) { lblMenu.Text = "0"; }
                    else { lblMenu.Text = Session["menu"].ToString(); }
                }

            }
        }
       
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("home.aspx");
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
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera.aspx");
        }

        protected void lbtnReproducir_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            DataTable dtCont = Clases.Contenidos.PR_STR_GET_CONTENIDO_STR_IND(id);
            string pelicula = "";
            string url_streaming = "";
            foreach (DataRow drCont in dtCont.Rows)
            {
                pelicula = drCont["contenido_peliculas"].ToString();
            }

            if (pelicula == "SI")
            {
                string cod_contenido_pelicula = "";
                DataTable dtP = Clases.Contenidos.PR_STR_GET_CONTENIDO_PELICULA(id);
                foreach (DataRow dr in dtP.Rows)
                {
                    cod_contenido_pelicula = dr["cod_contenido_pelicula"].ToString();
                }

                DataTable dtCP = Clases.Contenidos.PR_STR_GET_CONTENIDO_PELICULA_IND(cod_contenido_pelicula);
                foreach (DataRow dr in dtCP.Rows)
                {
                    url_streaming = dr["contenido_mobile"].ToString();
                }
            }
            else
            {
                DataTable dtT = Clases.Contenidos.PR_STR_GET_CONTENIDO_TEMPORADAS(id);
                DataTable dtTemp1 = new DataTable();
                foreach (DataRow dr in dtT.Rows)
                {
                    //cod_contenido_pelicula = dr["cod_contenido_pelicula"].ToString();
                    if (dr["episodio"].ToString() == "1")
                    {
                        url_streaming = dr["contenido_mobile"].ToString();
                    }
                }
            }
            Session["url_streaming"] = url_streaming;
            Response.Redirect("ver_streaming.aspx");
        }
        protected void lbtnSeleccionPlan_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            
            Response.Redirect("mas_informacion.aspx?ID="+id);
        }

        protected void lbtnNuevoAgregado_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();

            Response.Redirect("mas_informacion.aspx?ID=" + id);
        }

        protected void lbtnBanner_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();

            Response.Redirect("mas_informacion.aspx?ID=" + id);
        }
    }
}