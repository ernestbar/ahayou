using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Preguntas_frecuentes
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_CODIGO_PREGUNTA { get; set; }
        public Int64 PB_NRO_PREGUNTA { get; set; }
        public string PV_PREGUNTA { get; set; }
        public string PV_PREGUNTA_INGLES { get; set; }
        public string PV_RESPUESTA { get; set; }
        public string PV_RESPUESTA_INGLES { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Preguntas_frecuentes(Int64 pB_CODIGO_PREGUNTA)
        {
            PB_CODIGO_PREGUNTA = pB_CODIGO_PREGUNTA;
            RecuperarDatos();
        }
        public Preguntas_frecuentes(string pV_TIPO_OPERACION, Int64 pB_CODIGO_PREGUNTA,
            Int64 pB_NRO_PREGUNTA, string pV_PREGUNTA, string pV_PREGUNTA_INGLES,
            string pV_RESPUESTA, string pV_RESPUESTA_INGLES, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_CODIGO_PREGUNTA = pB_CODIGO_PREGUNTA;
            PB_NRO_PREGUNTA = pB_NRO_PREGUNTA;
            PV_PREGUNTA = pV_PREGUNTA;
            PV_PREGUNTA_INGLES = pV_PREGUNTA_INGLES;
            PV_RESPUESTA = pV_RESPUESTA;
            PV_RESPUESTA_INGLES = pV_RESPUESTA_INGLES;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_PREGUNTAS_FRECUENTES()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PREGUNTAS_FRECUENTES";
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
        public static DataTable PR_PAR_GET_DATA_CITY(string pV_PAIS)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_DATA_CITY";
                    cmd.Parameters.AddWithValue("PV_PAIS", pV_PAIS);
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
        public static DataTable PR_PAR_GET_ONLY_DOMINIOS()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_ONLY_DOMINIOS";
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
                    cmd.CommandText = "PR_PAR_GET_PREGUNTAS_FRECUENTES_IND";
                    cmd.Parameters.AddWithValue("PB_CODIGO_PREGUNTA", PB_CODIGO_PREGUNTA);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PB_NRO_PREGUNTA = Int64.Parse(dr["NRO_PREGUNTA"].ToString());
                            if (string.IsNullOrEmpty(dr["PREGUNTA"].ToString()))
                                PV_PREGUNTA = "";
                            else
                                PV_PREGUNTA = (string)dr["PREGUNTA"];

                            if (string.IsNullOrEmpty(dr["PREGUNTA_INGLES"].ToString()))
                                PV_PREGUNTA_INGLES = "";
                            else
                                PV_PREGUNTA_INGLES = (string)dr["PREGUNTA_INGLES"];
                            if (string.IsNullOrEmpty(dr["RESPUESTA"].ToString()))
                                PV_RESPUESTA = "";
                            else
                                PV_RESPUESTA = (string)dr["RESPUESTA"];
                            if (string.IsNullOrEmpty(dr["RESPUESTA_INGLES"].ToString()))
                                PV_RESPUESTA_INGLES = "";
                            else
                                PV_RESPUESTA_INGLES = (string)dr["RESPUESTA_INGLES"];
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
                    cmd.CommandText = "PR_PAR_ABM_PREGUNTAS";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_CODIGO_PREGUNTA", PB_CODIGO_PREGUNTA);
                    cmd.Parameters.AddWithValue("PB_NRO_PREGUNTA", PB_NRO_PREGUNTA);
                    cmd.Parameters.AddWithValue("PV_PREGUNTA", PV_PREGUNTA);
                    cmd.Parameters.AddWithValue("PV_PREGUNTA_INGLES", PV_PREGUNTA_INGLES);
                    cmd.Parameters.AddWithValue("PV_RESPUESTA", PV_RESPUESTA);
                    cmd.Parameters.AddWithValue("PV_RESPUESTA_INGLES", PV_RESPUESTA_INGLES);
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