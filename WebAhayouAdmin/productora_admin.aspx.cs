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
    public partial class productora_admin : System.Web.UI.Page
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
                }
            }
        }
        public void limpiar_controles()
        {
            lblAviso.Text = "";
            lblCodProductora.Text = "";
            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtNombreSucursal.Text = "";
            txtDireccion.Text = "";
            ddlPais.DataBind();
            ddlCiudad.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ddlPais_DataBound(object sender, EventArgs e)
        {
            ddlPais.Items.Insert(0, "SELECCIONAR");
        }
        protected void ddlCiudad_DataBound(object sender, EventArgs e)
        {
            ddlCiudad.Items.Insert(0, "SELECCIONAR");
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodProductora.Text = id;
                txtCodigo.Text = id;
                txtCodigo.Enabled = false;
                Clases.Productoras cli = new Clases.Productoras(lblCodProductora.Text);
                txtNombreSucursal.Text = cli.PV_NOMBRE_PRODUCTORA;
                txtDireccion.Text = cli.PV_DIRECCION;
                ddlPais.DataBind();
                ddlPais.SelectedValue = cli.PB_ID_PAIS.ToString();
                ddlCiudad.DataBind();
                ddlCiudad.SelectedValue = cli.PB_ID_CIUDAD.ToString();
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_productora_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblCodProductora.Text == "")
                {
                    Clases.Productoras cli = new Clases.Productoras("I", txtCodigo.Text, txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue,ddlCiudad.SelectedValue, lblUsuario.Text);
                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {

                    Clases.Productoras cli = new Clases.Productoras("U", lblCodProductora.Text, txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, ddlCiudad.SelectedValue, lblUsuario.Text);
                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                    MultiView1.ActiveViewIndex = 0;
                }
                Repeater1.DataBind();
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_productora_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                string[] datos = id.Split('|');
                if (datos[1] == "ACTIVO")
                {
                    Clases.Productoras cli = new Clases.Productoras("D", datos[0], txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, ddlCiudad.SelectedValue, lblUsuario.Text);
                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                    Repeater1.DataBind();
                }
                else
                {
                    Clases.Productoras cli = new Clases.Productoras("A", datos[0], txtNombreSucursal.Text, txtDireccion.Text, ddlPais.SelectedValue, ddlCiudad.SelectedValue, lblUsuario.Text);
                    cli.ABM();
                    lblAviso.Text = cli.PV_DESCRIPCIONPR;
                    Repeater1.DataBind();
                }
                string script = string.Format("alert('{0}');", lblAviso.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", script, true);
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_productora_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos problemas en el proceso, verifique los logs con el administrador.";
            }



        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
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

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

       
    }
}