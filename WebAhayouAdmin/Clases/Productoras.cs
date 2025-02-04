using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAhayouAdmin.Clases
{
    public class Productoras
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_PRODUCTORA { get; set; }
        public string PV_NOMBRE_PRODUCTORA { get; set; }
        public string PV_DIRECCION { get; set; }
        public string PB_ID_PAIS { get; set; }
        public string PB_ID_CIUDAD { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Productoras(string pV_COD_PRODUCTORA)
        {
            PV_COD_PRODUCTORA = pV_COD_PRODUCTORA;
            RecuperarDatos();
        }
        public Productoras(string pV_TIPO_OPERACION, string pV_COD_PRODUCTORA,
            string pV_NOMBRE_PRODUCTORA, string pV_DIRECCION, string pB_ID_PAIS,
            string pB_ID_CIUDAD, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_PRODUCTORA = pV_COD_PRODUCTORA;
            PV_NOMBRE_PRODUCTORA = pV_NOMBRE_PRODUCTORA;
            PV_DIRECCION = pV_DIRECCION;
            PB_ID_PAIS = pB_ID_PAIS;
            PB_ID_CIUDAD = pB_ID_CIUDAD;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        

        public static DataTable PR_PAR_GET_PRODUCTORA()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PRODUCTORA";
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

        public static DataTable PR_PAR_GET_PRODUCTORA_ACTIVA()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PRODUCTORA_ACTIVA";
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
                    cmd.CommandText = "PR_PAR_GET_PRODUCTORA_IND";
                    cmd.Parameters.AddWithValue("PV_COD_PRODUCTORA", PV_COD_PRODUCTORA);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (string.IsNullOrEmpty(dr["DESCRIPCION"].ToString()))
                                PV_NOMBRE_PRODUCTORA = "";
                            else
                                PV_NOMBRE_PRODUCTORA = dr["DESCRIPCION"].ToString();
                            if (string.IsNullOrEmpty(dr["DIRECCION"].ToString()))
                                PV_DIRECCION = "";
                            else
                                PV_DIRECCION = (string)dr["DIRECCION"];
                            if (string.IsNullOrEmpty(dr["PAIS"].ToString()))
                                PB_ID_PAIS = "";
                            else
                                PB_ID_PAIS = (string)dr["PAIS"];
                            if (string.IsNullOrEmpty(dr["CIUDAD"].ToString()))
                                PB_ID_CIUDAD = "";
                            else
                                PB_ID_CIUDAD = (string)dr["CIUDAD"];
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
                    cmd.CommandText = "PR_PAR_ABM_PRODUCTORA";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    if (PV_COD_PRODUCTORA == "")
                        cmd.Parameters.AddWithValue("PV_CODIGO", "");
                    else
                        cmd.Parameters.AddWithValue("PV_CODIGO", PV_COD_PRODUCTORA);
                    if (PV_NOMBRE_PRODUCTORA == "")
                        cmd.Parameters.AddWithValue("PV_NOMBRE_PRODUCTORA", "");
                    else
                        cmd.Parameters.AddWithValue("PV_NOMBRE_PRODUCTORA", PV_NOMBRE_PRODUCTORA);
                    cmd.Parameters.AddWithValue("PV_DIRECCION", PV_DIRECCION);
                    cmd.Parameters.AddWithValue("PB_ID_PAIS", PB_ID_PAIS);
                    cmd.Parameters.AddWithValue("PB_ID_CIUDAD", PB_ID_CIUDAD);
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_LATITUD", "");
                    cmd.Parameters.AddWithValue("PV_LONGITUD", "");
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