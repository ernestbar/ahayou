using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class promociones_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                                btnNuevo.Visible = true;
                        }

                    }
                    MultiView1.ActiveViewIndex = 0;

                }

            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                Button bEdit = (Button)e.Item.FindControl("btnEditar");
                bEdit.Visible = false;
                bEliminar.Visible = false;
                DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                            bEdit.Visible = true;
                        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                            bEliminar.Visible = true;
                    }

                }


            }
        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodPromocion.Text = "";
            txtPorcentaje.Text = "0";
            txtPromocion.Text = "";
            lblFechaDesde.Text = "";
            lblFechaHasta.Text = "";
            ddlMundo.DataBind();
            ddlPanesPromo.DataBind();

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 1;
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodPromocion.Text = id;
                Clases.Promociones cli = new Clases.Promociones(Int64.Parse(lblCodPromocion.Text));
                txtPromocion.Text = cli.PV_PROMOCION;
                txtPorcentaje.Text = cli.PD_PROCENTAJE.ToString();   
                ddlMundo.DataBind();
                ddlMundo.SelectedValue = cli.PV_MUNDO;
                ddlPanesPromo.DataBind();
                ddlPanesPromo.SelectedValue = cli.PB_CODIGO_PLAN.ToString();

                if (cli.PD_FECHA_DESDE.ToString() == "")
                {
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
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
                else
                {
                    DateTime fecha1 = DateTime.Parse(cli.PD_FECHA_DESDE.ToString());
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
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta", "setearFechaSalida();", true);
                }
                if (cli.PD_FECHA_DESDE.ToString() != "")
                {
                    DateTime fecha2 = DateTime.Parse(cli.PD_FECHA_DESDE.ToString());
                    string dia = "";
                    string mes = "";
                    if (fecha2.Day.ToString().Length == 1)
                        dia = "0" + fecha2.Day.ToString();
                    else
                        dia = fecha2.Day.ToString();

                    if (fecha2.Month.ToString().Length == 1)
                        mes = "0" + fecha2.Month.ToString();
                    else
                        mes = fecha2.Month.ToString();
                    hfFechaRetorno.Value = fecha2.Year.ToString() + "-" + mes + "-" + dia;
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "myFuncionAlerta2", "setearFechaRetorno();", true);
                }

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_promociones_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] dat = id.Split('|');
                lblCodPromocion.Text=dat[0];
                if (dat[1] == "ACTIVO")
                {
                    Clases.Promociones cli = new Clases.Promociones("D", Int64.Parse(lblCodPromocion.Text),0, "", DateTime.Now,
                      "", "", 0, DateTime.Now, lblUsuario.Text);

                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                }
                else
                {
                    Clases.Promociones cli = new Clases.Promociones("A", Int64.Parse(lblCodPromocion.Text), 0, "", DateTime.Now,
                      "", "", 0, DateTime.Now, lblUsuario.Text);
                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                }

                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_promociones_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }


        }

       
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //string s;
                //string fecha = "";
                //s = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                string fecha_retorno = "01/01/3000";
                if (hfFechaRetorno.Value != "")
                    fecha_retorno = hfFechaRetorno.Value;
                string fecha_salida = DateTime.Now.ToShortDateString();
                if (hfFechaSalida.Value != "")
                    fecha_salida = hfFechaSalida.Value;
                string interno = "";
                string fijo = "";
                if (lblCodPromocion.Text == "")
                {

                    Clases.Promociones per = new Clases.Promociones("I",0,Int64.Parse(ddlPanesPromo.SelectedValue), txtPromocion.Text,DateTime.Parse(fecha_salida),
                        ddlMundo.SelectedValue, "",decimal.Parse(txtPorcentaje.Text),DateTime.Parse(fecha_retorno),lblUsuario.Text);
                    per.ABM();
                    lblAviso.Text = per.PV_DESCRIPCIONPR;
                    
                }
                else
                {

                    Clases.Promociones per = new Clases.Promociones("U", Int64.Parse(lblCodPromocion.Text), Int64.Parse(ddlPanesPromo.SelectedValue), txtPromocion.Text, DateTime.Parse(fecha_salida),
                       ddlMundo.SelectedValue, "", decimal.Parse(txtPorcentaje.Text), DateTime.Parse(fecha_retorno), lblUsuario.Text);
                    per.ABM();
                    lblAviso.Text = per.PV_DESCRIPCIONPR;
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_promociones_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }

        protected void btnVolverUser_Click(object sender, EventArgs e)
        {
            lblAviso.Text = "";
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ddlMundo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMundo_DataBound(object sender, EventArgs e)
        {
            ddlMundo.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlPanesPromo_DataBound(object sender, EventArgs e)
        {
            ddlPanesPromo.Items.Insert(0, "SELECCIONAR");
        }
    }
}