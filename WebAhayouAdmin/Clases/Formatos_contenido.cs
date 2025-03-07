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
    public class Formatos_contenido
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_COD_FORMATO_CONTENIDO { get; set; }
        public string PV_FORMATO_CONTENIDO { get; set; }
        public string PV_FORMATO_CONTENIDO_INGLES { get; set; }
        public Int64 PB_ORDEN { get; set; }

        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Formatos_contenido(Int64 pB_COD_FORMATO_CONTENIDO)
        {
            PB_COD_FORMATO_CONTENIDO = pB_COD_FORMATO_CONTENIDO;
            RecuperarDatos();
        }
        public Formatos_contenido(string pV_TIPO_OPERACION, Int64 pB_COD_FORMATO_CONTENIDO,
            string pV_FORMATO_CONTENIDO,string pV_FORMATO_CONTENIDO_INGLES, Int64 pB_ORDEN, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_COD_FORMATO_CONTENIDO = pB_COD_FORMATO_CONTENIDO;
            PV_FORMATO_CONTENIDO = pV_FORMATO_CONTENIDO;
            PV_FORMATO_CONTENIDO_INGLES = pV_FORMATO_CONTENIDO_INGLES;
            PB_ORDEN = pB_ORDEN;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_STR_GET_FORMATO_CONTENIDO()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_FORMATO_CONTENIDO";
                    //if (PV_ESTADO == "T")
                    //    cmd.Parameters.Add("PV_ESTADO", null);
                    //else
                    //    cmd.Parameters.Add("PV_ESTADO", PV_ESTADO);
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
                    cmd.CommandText = "PR_STR_GET_FORMATO_CONTENIDO_IND";
                    cmd.Parameters.AddWithValue("PB_COD_FORMATO_CONTENIDO", PB_COD_FORMATO_CONTENIDO);
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
                            PV_FORMATO_CONTENIDO = (string)dr["formato_contenido"];
                            PV_FORMATO_CONTENIDO_INGLES = (string)dr["formato_contenido_ingles"];
                            PB_ORDEN = Int64.Parse(dr["orden"].ToString());
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
                    cmd.CommandText = "PR_STR_ABM_FORMATO_CONTENIDO";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_COD_FORMATO_CONTENIDO", PB_COD_FORMATO_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_FORMATO_CONTENIDO", PV_FORMATO_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_FORMATO_CONTENIDO_INGLES", PV_FORMATO_CONTENIDO_INGLES);
                    cmd.Parameters.AddWithValue("PB_ORDEN", PB_ORDEN);
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