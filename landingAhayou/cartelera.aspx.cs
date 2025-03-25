using System;
using System.Collections.Generic;
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
                    lblUsuario.Text = "";
                    btnLogin.Visible = true;
                    btnSuscribete.Visible = true;
                    
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblPerfilSuscriptor.Text= Session["cod_plan_suscriptor"].ToString();
                    lblPerfilSuscriptor.Text = Session["cod_perfil_suscriptor"].ToString();
                    btnLogin.Visible = false;
                    btnSuscribete.Visible = false;
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
                            rSegmentos.DataSource = Clases.Carteleras.PR_STR_GET_VER_CARTELERA(lblUsuario1.Text, lblplanSuscriptor.Text, lblPerfilSuscriptor.Text, lblMenu.Text, id.Text);
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
                            rSegmentos2.DataSource = Clases.Carteleras.PR_STR_GET_VER_CARTELERA(lblUsuario1.Text, lblplanSuscriptor.Text, lblPerfilSuscriptor.Text, lblMenu.Text, id.Text);
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

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            lblMenu.Text = "0";
            Repeater2.DataBind();
        }

        protected void btnPeliculas_Click(object sender, EventArgs e)
        {
            lblMenu.Text = "1";
            Repeater2.DataBind();
        }

        protected void btnTV_Click(object sender, EventArgs e)
        {
            lblMenu.Text = "4";
            Repeater2.DataBind();

        }
    }
}