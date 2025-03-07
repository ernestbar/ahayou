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
    public class Clasificacion_contenidos
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_COD_CLASIFICACION_CONTENIDO { get; set; }
        public Int64 PB_COD_FORMATO_CONTENIDO { get; set; }
        public string PV_CLASIFICACION { get; set; }

        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Clasificacion_contenidos(Int64 pB_COD_CLASIFICACION_CONTENIDO)
        {
            PB_COD_CLASIFICACION_CONTENIDO = pB_COD_CLASIFICACION_CONTENIDO;
            RecuperarDatos();
        }
        public Clasificacion_contenidos(string pV_TIPO_OPERACION, Int64 pB_COD_CLASIFICACION_CONTENIDO, Int64 pB_COD_FORMATO_CONTENIDO,
            string pV_CLASIFICACION,  string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_COD_FORMATO_CONTENIDO = pB_COD_FORMATO_CONTENIDO;
            PV_CLASIFICACION = pV_CLASIFICACION;
            PB_COD_CLASIFICACION_CONTENIDO = pB_COD_CLASIFICACION_CONTENIDO;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_STR_GET_CLASIFICACION_CONTENIDO(string pB_COD_FORMATO_CONTENIDO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_CLASIFICACION_CONTENIDO";
                    if(pB_COD_FORMATO_CONTENIDO=="SELECCIONAR")
                        cmd.Parameters.AddWithValue("PB_COD_FORMATO_CONTENIDO", 0);
                    else
                        cmd.Parameters.AddWithValue("PB_COD_FORMATO_CONTENIDO", pB_COD_FORMATO_CONTENIDO);
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
        //public static DataTable PR_SEG_GET_ROLES_ACTIVOS()
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_ROLES_ACTIVOS");
        //        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //        return db1.ExecuteDataSet(cmd).Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        DataTable dt = new DataTable();
        //        return dt;
        //    }

        //}



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
                    cmd.CommandText = "PR_STR_GET_CLASIFICACION_CONTENIDO_IND";
                    cmd.Parameters.AddWithValue("PB_COD_CLASIFIFICACION_CONTENIDO", PB_COD_CLASIFICACION_CONTENIDO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PB_COD_FORMATO_CONTENIDO = Int64.Parse(dr["cod_formato_contenido"].ToString());
                            PV_CLASIFICACION = (string)dr["cod_clafificacion"];
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
                    cmd.CommandText = "PR_STR_ABM_CLASIFICACION_CONTENIDO";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_COD_CLASIFICACION_CONTENIDO", PB_COD_CLASIFICACION_CONTENIDO);
                    cmd.Parameters.AddWithValue("PB_COD_FORMATO_CONTENIDO", PB_COD_FORMATO_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_CLASIFICACION", PV_CLASIFICACION);
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