using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAhayouAdmin
{
    public partial class reporte_propietarios : System.Web.UI.Page
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
                }
            }

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
               e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Button bEdit = (Button)e.Item.FindControl("btnEditar");
                //Button bEliminar = (Button)e.Item.FindControl("btnEliminar");
                //bEdit.Visible = false;
                //bEliminar.Visible = false;
                //DataTable dt = Clases.Ingreso_app.PR_SEG_GET_OPCIONES_ROLES(Int64.Parse(lblCodMenuRol.Text), lblUsuario.Text);
                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "EDITAR")
                //            bEdit.Visible = true;
                //        if (dr["DESCRIPCION"].ToString().ToUpper() == "ELIMINAR")
                //            bEliminar.Visible = true;
                //    }

                //}
            }
        }
    }
}