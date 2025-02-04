using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Menus
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_COD_MENU { get; set; }
        public Int64 PB_COD_MENU_PADRE { get; set; }
        public string PV_DESCRIPCIONMEN { get; set; }
        public string PV_DETALLE { get; set; }
        public string PV_SISTEMAS { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Menus(Int64 pB_COD_MENU)
        {
            PB_COD_MENU = pB_COD_MENU;
            RecuperarDatos();
        }
        public Menus(string pV_TIPO_OPERACION, Int64 pB_COD_MENU,
            Int64 pB_COD_MENU_PADRE, string pV_DESCRIPCIONMEN, string pV_DETALLE,
            string pV_SISTEMAS, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_COD_MENU = pB_COD_MENU;
            PB_COD_MENU_PADRE = pB_COD_MENU_PADRE;
            PV_DESCRIPCIONMEN = pV_DESCRIPCIONMEN;
            PV_DETALLE = pV_DETALLE;
            PV_SISTEMAS = pV_SISTEMAS;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_MENUS(string pV_SISTEMA)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_MENUS";
                    cmd.Parameters.AddWithValue("PV_SISTEMA", pV_SISTEMA);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    return dataTable;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_SEG_GET_MENUS_PADRE()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_MENUS_PADRE";
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    return dataTable;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

       


        #endregion
        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_MENUS_IND";
                    cmd.Parameters.AddWithValue("PV_COD_MENU", PB_COD_MENU);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (string.IsNullOrEmpty(dr["COD_MENU_PADRE"].ToString()))
                                PB_COD_MENU_PADRE = 0;
                            else
                                PB_COD_MENU_PADRE = Int64.Parse(dr["COD_MENU_PADRE"].ToString());
                            if (string.IsNullOrEmpty(dr["DESCRIPCION"].ToString()))
                                PV_DESCRIPCIONMEN = "";
                            else
                                PV_DESCRIPCIONMEN = (string)dr["DESCRIPCION"];
                            if (string.IsNullOrEmpty(dr["DETALLE"].ToString()))
                                PV_DETALLE = "";
                            else
                                PV_DETALLE = (string)dr["DETALLE"];
                            if (string.IsNullOrEmpty(dr["SISTEMA"].ToString()))
                                PV_SISTEMAS = "";
                            else
                                PV_SISTEMAS = (string)dr["SISTEMA"];
                        }

                    }

                }

            }
            catch { }
        }



        public string ABM()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_ABM_MENUS";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    if (PB_COD_MENU == 0)
                        cmd.Parameters.AddWithValue("PB_COD_MENU", "");
                    else
                        cmd.Parameters.AddWithValue("PB_COD_MENU", PB_COD_MENU);
                    if (PB_COD_MENU_PADRE == 0)
                        cmd.Parameters.AddWithValue("PB_COD_MENU_PADRE", 0);
                    else
                        cmd.Parameters.AddWithValue("PB_COD_MENU_PADRE", PB_COD_MENU_PADRE);
                    cmd.Parameters.AddWithValue("PV_DESCRIPCIONMEN", PV_DESCRIPCIONMEN);
                    cmd.Parameters.AddWithValue("PV_DETALLE", PV_DETALLE);
                    cmd.Parameters.AddWithValue("PV_SISTEMAS", PV_SISTEMAS);
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.Add("PV_ESTADOPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_DESCRIPCIONPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_ERROR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    PV_ESTADOPR = (string)cmd.Parameters["PV_ESTADOPR"].Value;
                    PV_DESCRIPCIONPR = (string)cmd.Parameters["PV_DESCRIPCIONPR"].Value;
                    if (string.IsNullOrEmpty(cmd.Parameters["PV_ERROR"].Value.ToString()))
                        PV_ERROR = "";
                    else
                        PV_ERROR = (string)cmd.Parameters["PV_ERROR"].Value;
                    conn.Close();
                }

                return PV_DESCRIPCIONPR;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                PV_DESCRIPCIONPR = "ERROR EN CAPA DE NEGOCIOS";
                return PV_DESCRIPCIONPR;
            }
        }

        #endregion
    }
}