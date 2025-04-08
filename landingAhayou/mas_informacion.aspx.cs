using landingAhayou.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace landingAhayou
{
    public partial class mas_informacion : System.Web.UI.Page
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
                    Response.Redirect("login.aspx");

                }
                else
                {
                    
                    if (Session["cod_plan_suscriptor"] == null)
                        Response.Redirect("selecciona_plan.aspx");
                    else 
                    {
                        lblUsuario.Text = Session["usuario"].ToString();
                        lblplanSuscriptor.Text = Session["cod_plan_suscriptor"].ToString();
                        lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();
                        lblCodigoPlan.Text = Session["codigo_plan"].ToString();
                        lblCodContenidoStr.Text = Request.QueryString["ID"];
                        btnLogin.Visible = false;
                        btnSuscribete.Visible = false;
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
                    }
                    

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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            string id = obj.CommandArgument.ToString();
            lblMenu.Text = id;
            Session["menu"] = id;
            Response.Redirect("cartelera.aspx");
            //Repeater2.DataBind();
        }

        protected void ibtnFavoritos_Click(object sender, ImageClickEventArgs e)
        {
            Carteleras obj = new Carteleras("F",lblPerfilSuscriptor.Text,lblplanSuscriptor.Text,lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text,"",lblUsuario.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
        }

        protected void ibtnLike_Click(object sender, ImageClickEventArgs e)
        {
            Carteleras obj = new Carteleras("L", lblPerfilSuscriptor.Text, lblplanSuscriptor.Text, lblUsuario.Text, int.Parse(lblCodigoPlan.Text), lblCodContenidoStr.Text, "", lblUsuario.Text);
            obj.ABM();
            string script = string.Format("alert('{0}');", obj.PV_DESCRIPCIONPR);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
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

        protected void lbtnReproducirT_Click(object sender, EventArgs e)
        {
            LinkButton obj = (LinkButton)sender;
            string id = obj.CommandArgument.ToString();
            Session["url_streaming"] = id;
            Response.Redirect("ver_streaming.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Sesion"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("home.aspx");
        }
    }
}