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
    public partial class mas_informacion_us : System.Web.UI.Page
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
                        if (Request.Cookies["cod_perfil_suscriptor"] != null)
                        {
                            lblPerfilSuscriptor.Text = Request.Cookies["cod_perfil_suscriptor"].Value;
                        }
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
                    else
                        Response.Redirect("login_us.aspx");
                }
                else
                {
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        string email = Request.Cookies["UserName"].Value;
                        DataTable dt3 = new DataTable();
                        dt3 = Clases.Suscriptores.PR_PAR_GET_PLAN_SUSCRIPTOR(email);
                        if (dt3.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt3.Rows)
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
                        if (Request.Cookies["cod_perfil_suscriptor"] != null)
                        {
                            lblPerfilSuscriptor.Text = Request.Cookies["cod_perfil_suscriptor"].Value;
                        }
                        //btnLogin.Visible = false;
                        //btnSuscribete.Visible = false;
                        imgPerfil.ImageUrl = "~/imgs/icons/profile.svg";
                        DataTable dt4 = new DataTable();

                        dt4 = Suscriptores.PR_PAR_GET_PERFILES_SUSCRIPTOR(lblplanSuscriptor.Text);

                        foreach (DataRow dr in dt4.Rows)
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
                    lblCodContenidoStr.Text = Request.QueryString["ID"];

                    if (Request.Cookies["cod_perfil_suscriptor"] != null)
                    {
                        lblPerfilSuscriptor.Text = Request.Cookies["cod_perfil_suscriptor"].Value;
                    }
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

                    DataTable dt2 = new DataTable();
                    dt2 = Contenidos.PR_STR_GET_CONTENIDO_STR_IND(lblCodContenidoStr.Text);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (dr2["trailers"].ToString() == "SI")
                        {
                            lblTituloTrailers.Visible = true;
                            Panel_trailers.Visible = true;
                        }
                        else
                        {
                            lblTituloTrailers.Visible = false;
                            Panel_trailers.Visible = false;
                        }
                        if (dr2["temporadas_episodios"].ToString() == "SI")
                        {
                            lblTituloTemporadas.Visible = true;
                            Panel_temporadas.Visible = true;
                        }
                        else
                        {
                            lblTituloTemporadas.Visible = false;
                            Panel_temporadas.Visible = false;
                        }
                    }

                    //if (Session["cod_plan_suscriptor"] == null)
                    //    Response.Redirect("selecciona_plan.aspx");
                    //else 
                    //{

                    //}


                }

            }
        }
        protected void lbtnPerfiles_Click(object sender, EventArgs e)
        {

            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            Session["cod_perfil_suscriptor"] = id[0];
            lblPerfilSuscriptor.Text = id[0];
            Response.Cookies["cod_perfil_suscriptor"].Value = id[0];
            if (id[1] == "0")
                Response.Redirect("cartelera_us.aspx");
            else
                Response.Redirect("pin_perfil_us.aspx");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_us.aspx");
        }

        protected void btnSuscribete_Click(object sender, EventArgs e)
        {
            Response.Redirect("suscribete_us.aspx");
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera_us.aspx");
            //Repeater2.DataBind();
        }

        protected void ibtnFavoritos_Click(object sender, ImageClickEventArgs e)
        {
            if (lblplanSuscriptor.Text == "0")
            { Response.Redirect("selecciona_plan_us.aspx"); }
            else
            {
                Carteleras obj = new Carteleras("F", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text, "", lblUsuario.Text);
                obj.ABM();
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }

        }

        protected void ibtnLike_Click(object sender, ImageClickEventArgs e)
        {
            if (lblplanSuscriptor.Text == "0")
            { Response.Redirect("selecciona_plan_us.aspx"); }
            else
            {
                Carteleras obj = new Carteleras("L", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text, "", lblUsuario.Text);
                obj.ABM();
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
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

                DataTable dtCP = Clases.Contenidos.PR_STR_GET_CONTENIDO_PELICULA_IND(cod_contenido_pelicula);
                foreach (DataRow dr in dtCP.Rows)
                {
                    url_streaming = dr["contenido"].ToString();
                }
            }
            else
            {
                DataTable dtT = Clases.Contenidos.PR_STR_GET_CONTENIDO_TEMPORADAS(id);
                foreach (DataRow dr in dtT.Rows)
                {
                    //cod_contenido_pelicula = dr["cod_contenido_pelicula"].ToString();
                    if (dr["episodio"].ToString() == "1")
                    {
                        url_streaming = dr["contenido"].ToString();
                    }
                }
            }
            Session["url_streaming"] = url_streaming + "|" + es_gratis + "|" + id;
            if (Sesiones.PR_PAR_VALIDA_ACCESO_POR_SESIONES(lblUsuario.Text) == true)
            {
                Response.Redirect("ver_streaming_us.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", "You have exceeded the devices allowed by your plan.");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                //Response.Redirect("mas_informacion.aspx");
            }
        }

        protected void lbtnReproducirT_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string[] id = obj.CommandArgument.ToString().Split('|');
            DataTable dtCont = Clases.Contenidos.PR_STR_GET_CONTENIDO_STR_IND(id[1]);
            string es_gratis = "";
            foreach (DataRow drCont in dtCont.Rows)
            {
                es_gratis = drCont["es_gratuita"].ToString();
            }
            if (id[0] != "")
                Session["url_streaming"] = id[0] + "|" + es_gratis + "|" + id[1];
            else
                Session["url_streaming"] = id[2] + "|" + es_gratis + "|" + id[1];

            if (Sesiones.PR_PAR_VALIDA_ACCESO_POR_SESIONES(lblUsuario.Text) == true)
            {
                Response.Redirect("ver_streaming_us.aspx");
            }
            else
            {
                string script = string.Format("alert('{0}');", "You have exceeded the devices allowed by your plan.");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                //Response.Redirect("mas_informacion.aspx");
            }

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
            Response.Redirect("home_us.aspx");
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
                            Response.Redirect("cuenta_suscriptor_us.aspx");
                        else
                        {
                            string script = string.Format("alert('{0}');", "Only the main profile can edit the account.");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
                        }

                    }
                }
            }
            else
            {
                Response.Redirect("selecciona_plan_us.aspx");
            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
              e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label id = (Label)e.Item.FindControl("lblVerifica");
                string[] datos = id.Text.Split('|');

                LinkButton lbtnRepro = (LinkButton)e.Item.FindControl("lbtnReproducir");

                if (datos[1] == "PES")
                {
                    lbtnRepro.Visible = false;
                }
                else
                {
                    if (datos[0] == "SI")
                        lbtnRepro.Visible = false;
                    else
                        lbtnRepro.Visible = true;
                }

            }
        }

        protected void ibtnNoFavoritos_Click(object sender, ImageClickEventArgs e)
        {
            if (lblplanSuscriptor.Text == "0")
            { Response.Redirect("selecciona_plan_us.aspx"); }
            else
            {
                Carteleras obj = new Carteleras("NF", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text, "", lblUsuario.Text);
                obj.ABM();
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
        }

        protected void ibtnDislike_Click(object sender, ImageClickEventArgs e)
        {
            if (lblplanSuscriptor.Text == "0")
            { Response.Redirect("selecciona_plan_us.aspx"); }
            else
            {
                Carteleras obj = new Carteleras("NL", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text, "", lblUsuario.Text);
                obj.ABM();
                string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
        }

        //protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    
        //}
    }
}