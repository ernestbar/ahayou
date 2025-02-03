using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Opciones_roles
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PB_ROL_OPCION { get; set; }
        public string PB_ROL_MENU { get; set; }
        public string PB_ID_ROL { get; set; }
        public string PB_COD_MENU { get; set; }
        public string PB_OPCION { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Opciones_roles(string pB_ROL_OPCION)
        {
            PB_ROL_OPCION = pB_ROL_OPCION;
            RecuperarDatos();
        }
        public Opciones_roles(string pV_TIPO_OPERACION, string pB_ROL_OPCION,
            string pB_ROL_MENU,string pB_ID_ROL, string pB_COD_MENU,
            string pB_OPCION, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_ROL_OPCION = pB_ROL_OPCION;
            PB_ROL_MENU = pB_ROL_MENU;
            PB_ID_ROL = pB_ID_ROL;
            PB_COD_MENU = pB_COD_MENU;
            PB_OPCION = pB_OPCION;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_OPCIONES_A_ASIGNAR(string pD_MEN_COD_MENU, string pB_ROL_ID_ROL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_OPCIONES_A_ASIGNAR";
                    cmd.Parameters.AddWithValue("PD_MEN_COD_MENU", pD_MEN_COD_MENU);
                    cmd.Parameters.AddWithValue("PB_ROL_ID_ROL", pB_ROL_ID_ROL);
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

        public static DataTable PR_SEG_GET_OPCIONES_ASIGNADOS(string pD_MEN_COD_MENU, string pB_ROL_ID_ROL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_OPCIONES_ASIGNADOS";
                    cmd.Parameters.AddWithValue("PD_MEN_COD_MENU", pD_MEN_COD_MENU);
                    cmd.Parameters.AddWithValue("PB_ROL_ID_ROL", pB_ROL_ID_ROL);
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
                    cmd.CommandText = "PR_GET_ROLES_IND";
                    cmd.Parameters.AddWithValue("PV_COD_ROL", PB_ROL_OPCION);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PB_ROL_MENU = (string)dr["DESCRIPCION"];
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
                    cmd.CommandText = "PR_SEG_ABM_OPCIONES_ROLES";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    if (PB_ROL_OPCION == "")
                        cmd.Parameters.AddWithValue("PB_ROL_OPCION", "");
                    else
                        cmd.Parameters.AddWithValue("PB_ROL_OPCION", PB_ROL_OPCION);
                    cmd.Parameters.AddWithValue("PB_ROL_MENU", PB_ROL_MENU);
                    cmd.Parameters.AddWithValue("PB_ID_ROL", PB_ID_ROL);
                    cmd.Parameters.AddWithValue("PB_COD_MENU", PB_COD_MENU);
                    cmd.Parameters.AddWithValue("PB_OPCION", PB_OPCION);
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