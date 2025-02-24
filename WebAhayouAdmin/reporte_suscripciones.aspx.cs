using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class reporte_suscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    lblUsuario.Text = Session["usuario"].ToString();
                    //btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            //if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                            //btnNuevo.Visible = true;
                        }

                    }
                    DateTime fecha1 = DateTime.Now;
                    string dia = "";
                    string mes = "";
                    if (fecha1.Day.ToString().Length == 1)
                        dia = "0" + fecha1.Day.ToString();
                    else
                        dia = fecha1.Day.ToString();
                    if (fecha1.Month.ToString().Length == 1)
                        mes = "0" + fecha1.Month.ToString();
                    else
                        mes = fecha1.Month.ToString();
                    hfFechaSalida.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    hfFechaRetorno.Value = fecha1.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
            }

        }
        
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string fecha_ini = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            string fecha_fin = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            if (hfFechaSalida.Value != "")
                fecha_ini = hfFechaSalida.Value;
            if (hfFechaRetorno.Value != "")
                fecha_fin = hfFechaRetorno.Value;
            Repeater1.DataSource = Clases.Reportes.PR_REP_GET_SUSCRIPCIONES(DateTime.Parse(fecha_ini), DateTime.Parse(fecha_fin));
            Repeater1.DataBind();
        }
    }
}