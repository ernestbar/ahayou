using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace landingAhayou.Clases
{
    public class Opciones
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PB_COD_MENU { get; set; }
        public string PB_COD_OPCION { get; set; }
        public string PV_DESCRIPCIONMEN { get; set; }
        public string PV_DETALLE { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Opciones(string pB_COD_OPCION)
        {
            PB_COD_OPCION = pB_COD_OPCION;
            RecuperarDatos();
        }
        public Opciones(string pV_TIPO_OPERACION, string pB_COD_MENU,
            string pB_COD_OPCION, string pV_DESCRIPCIONMEN, string pV_DETALLE,
            string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_COD_MENU = pB_COD_MENU;
            PB_COD_OPCION = pB_COD_OPCION;
            PV_DESCRIPCIONMEN = pV_DESCRIPCIONMEN;
            PV_DETALLE = pV_DETALLE;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_OPCIONES(string pD_MEN_COD_MENU)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_OPCIONES";
                    cmd.Parameters.AddWithValue("PD_MEN_COD_MENU", pD_MEN_COD_MENU);
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
                    cmd.CommandText = "PR_SEG_GET_OPCIONES_IND";
                    cmd.Parameters.AddWithValue("PD_OPC_OPCION", Int64.Parse(PB_COD_OPCION));
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (string.IsNullOrEmpty(dr["COD_MENU"].ToString()))
                                PB_COD_MENU = "";
                            else
                                PB_COD_MENU = (string)dr["COD_MENU"];
                            if (string.IsNullOrEmpty(dr["DESCRIPCION"].ToString()))
                                PV_DESCRIPCIONMEN = "";
                            else
                                PV_DESCRIPCIONMEN = (string)dr["DESCRIPCION"];
                            if (string.IsNullOrEmpty(dr["DETALLE"].ToString()))
                                PV_DETALLE = "";
                            else
                                PV_DETALLE = (string)dr["DETALLE"];
                           
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
                    cmd.CommandText = "PR_SEG_ABM_OPCION";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    if (PB_COD_MENU == "")
                        cmd.Parameters.AddWithValue("PB_COD_MENU", null);
                    else
                        cmd.Parameters.AddWithValue("PB_COD_MENU", PB_COD_MENU);
                    if (PB_COD_OPCION == "")
                        cmd.Parameters.AddWithValue("PB_COD_OPCION", "");
                    else
                        cmd.Parameters.AddWithValue("PB_COD_OPCION", PB_COD_OPCION);
                    cmd.Parameters.AddWithValue("PV_DESCRIPCIONMEN", PV_DESCRIPCIONMEN);
                    cmd.Parameters.AddWithValue("PV_DETALLE", PV_DETALLE);
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