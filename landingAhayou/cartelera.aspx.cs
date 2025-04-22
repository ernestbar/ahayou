using landingAhayou.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class cartelera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Panel_logout.Visible = true;
                    Panel_login.Visible = false;
                    lblUsuario.Text = "";
                    //btnLogin.Visible = true;
                    //btnSuscribete.Visible = true;
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
                            //Response.Redirect("perfiles.aspx");
                        }
                        Session["usuario"] = email;
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

                        //btnLogin.Visible = false;
                        //btnSuscribete.Visible = false;
                        imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                        DataTable dt3 = new DataTable();

                        dt3 = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                        foreach (DataRow dr in dt3.Rows)
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
                else
                {
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        string email = Request.Cookies["UserName"].Value;
                        DataTable dt2 = new DataTable();
                        dt2 = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(email);
                        if (dt2.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt2.Rows)
                            {
                                Session["cod_plan_suscriptor"] = dr["cod_plan_suscriptor"];
                                Session["codigo_plan"] = dr["codigo_plan"];
                            }
                            //Response.Redirect("perfiles.aspx");
                        }
                        Session["usuario"] = email;
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

                        //btnLogin.Visible = false;
                        //btnSuscribete.Visible = false;
                        imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                        DataTable dt3 = new DataTable();

                        dt3 = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                        foreach (DataRow dr in dt3.Rows)
                        {
                            if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                            {
                                imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();

                            }
                        }
                        if (Session["menu"] == null) { lblMenu.Text = "0"; }
                        else { lblMenu.Text = Session["menu"].ToString(); }
                    }
                    Panel_logout.Visible = false;
                    Panel_login.Visible = true;
                    lblUsuario.Text = Session["usuario"].ToString();
                    if (Session["cod_plan_suscriptor"] == null)
                    { lblplanSuscriptor.Text = "0"; Repeater8.Visible=true; } 
                    else
                        lblplanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                    if(Session["cod_perfil_suscriptor"] == null)
                        lblPerfilSuscriptor.Text= "0";
                    else
                        lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();
                    
                    if(Session["codigo_plan"] == null)
                        lblCodigoPlan.Text= "0";
                    else
                        lblCodigoPlan.Text = Session["codigo_plan"].ToString();

                    //btnLogin.Visible = false;
                    //btnSuscribete.Visible = false;
                    //imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                    //DataTable dt = new DataTable();

                    //dt=Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);
                    
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                    //    {
                    //        imgPerfil.ImageUrl = "data:image/jpg;base64," + dr["AVATAR"].ToString();
                                
                    //    }
                    //}
                    if (Session["menu"] == null) { lblMenu.Text = "0"; }
                    else { lblMenu.Text = Session["menu"].ToString(); }
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

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                 e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblSeccion");
                Panel panel1 = (Panel)e.Item.FindControl("Panel_normal");
                //Panel panel2 = (Panel)e.Item.FindControl("Panel_mas_visto");

                if (id != null)
                {
                    
                        if (id.Text.ToUpper().Contains("MAS VISTOS") || id.Text.ToUpper().Contains("MAS VISTAS") || id.Text.ToUpper().Contains("MOST VIEWED"))
                        {
                            panel1.Visible = false;
                        }
                        else
                        {
                            panel1.Visible = true;
                            Repeater rSegmentos = (Repeater)e.Item.FindControl("Repeater1");
                            rSegmentos.DataSource = Clases.Carteleras.PR_STR_GET_VER_CARTELERA(lblUsuario.Text, lblplanSuscriptor.Text, lblPerfilSuscriptor.Text, lblMenu.Text, id.Text);
                            rSegmentos.DataBind();
                        }
                    
                    
                    
                }

                

            }
        }

        

        protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                 e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblSeccion");
                Panel panel1 = (Panel)e.Item.FindControl("Panel_nas_vistos");
                //Panel panel2 = (Panel)e.Item.FindControl("Panel_mas_visto");

                if (id != null)
                {
                    
                        if (id.Text.ToUpper().Contains("MAS VISTOS") || id.Text.ToUpper().Contains("MAS VISTAS") || id.Text.ToUpper().Contains("MOST VIEWED"))
                        {
                            panel1.Visible = true;
                            //panel2.Visible = true;
                            Repeater rSegmentos2 = (Repeater)e.Item.FindControl("Repeater3");
                            rSegmentos2.DataSource = Clases.Carteleras.PR_STR_GET_VER_CARTELERA(lblUsuario.Text, lblplanSuscriptor.Text, lblPerfilSuscriptor.Text, lblMenu.Text, id.Text);
                            rSegmentos2.DataBind();
                        }
                        else
                        {
                            panel1.Visible = false;
                            ////panel2.Visible = false;
                            //Repeater rSegmentos = (Repeater)e.Item.FindControl("Repeater1");
                            //rSegmentos.DataSource = Clases.Carteleras.PR_STR_GET_VER_CARTELERA(lblUsuario1.Text, lblplanSuscriptor.Text, lblPerfilSuscriptor.Text, lblMenu.Text, id.Text);
                            //rSegmentos.DataBind();
                        }


                }



            }

        }

        
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblMenu.Text = id;
            Repeater2.DataBind();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Sesion"] != null)
            {
                Sesiones obj = new Sesiones("D", lblUsuario.Text, Request.Cookies["Sesion"].Value, lblUsuario.Text);
                obj.ABM();
            }
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Sesion"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("home.aspx");
        }

        protected void lbtnReproducir_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            DataTable dtCont = Clases.Contenidos.PR_STR_GET_CONTENIDO_STR_IND(id);
            string pelicula = "";
            string url_streaming = "";
            string es_gratis = "";
            foreach (DataRow drCont in dtCont.Rows)
            {
                pelicula = drCont["contenido_peliculas"].ToString();
                es_gratis = drCont["es_gratuita"].ToString();
            }

            if (pelicula == "SI")
            {
                string cod_contenido_pelicula = "";
                DataTable dtP = Clases.Contenidos.PR_STR_GET_CONTENIDO_PELICULA(id);
                foreach (DataRow dr in dtP.Rows)
                {
                    cod_contenido_pelicula = dr["cod_contenido_pelicula"].ToString();
                }
                
                DataTable dtCP= Clases.Contenidos.PR_STR_GET_CONTENIDO_PELICULA_IND(cod_contenido_pelicula);
                foreach (DataRow dr in dtCP.Rows)
                {
                    url_streaming = dr["contenido"].ToString();
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
                        url_streaming = dr["contenido"].ToString();
                    }
                }
            }
            Session["url_streaming"] = url_streaming + "|" + es_gratis;
            if (Sesiones.PR_PAR_VALIDA_ACCESO_POR_SESIONES(lblUsuario.Text) == true)
            {
                Response.Redirect("ver_streaming.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", "Usted supero los dispositivos permitidos de su plan.");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                //Response.Redirect("mas_informacion.aspx");
            }
        }

        protected void lbtnPerfiles_Click(object sender, EventArgs e)
        {

            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            Session["cod_perfil_suscriptor"] = id[0];
            lblPerfilSuscriptor.Text = id[0];
            Session["pin"]= id[1];
            if (id[1]=="0")
                Response.Redirect("cartelera.aspx");
            else
                Response.Redirect("pin_perfil.aspx");
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            Session["busqueda"]=txtBusqueda.Text;
            Response.Redirect("resultado_busqueda.aspx");
        }

        protected void lbtnCuenta_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["cod_perfil_suscriptor"].ToString() == lblPerfilSuscriptor.Text)
                    {

                        if (dr["es_principal"].ToString() == "SI")
                            Response.Redirect("cuenta_suscriptor.aspx");
                        else
                        {
                            string script = string.Format("alert('{0}');", "Solo el perfil principal puede editar la cuenta.");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("selecciona_plan.aspx");
            }

        }
    }
}