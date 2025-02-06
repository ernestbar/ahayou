using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Dominios
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_DOMINIO { get; set; }
        public string PV_CODIGO { get; set; }
        public string PV_DESCRIPCION{ get; set; }
        public string PV_VALOR_CARACTER { get; set; }
        public string PV_VALOR_NUMERICO { get; set; }
        public string PV_VALOR_DATE { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Dominios(string pV_DOMINIO,string pV_CODIGO)
        {
            PV_DOMINIO = pV_DOMINIO;
            PV_CODIGO = pV_CODIGO;
            RecuperarDatos();
        }
        public Dominios(string pV_TIPO_OPERACION, string pV_DOMINIO,
            string pV_CODIGO, string pV_DESCRIPCION, string pV_VALOR_CARACTER,
            string pV_VALOR_NUMERICO, string pV_VALOR_DATE, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_DOMINIO = pV_DOMINIO;
            PV_CODIGO = pV_CODIGO;
            PV_DESCRIPCION = pV_DESCRIPCION;
            PV_VALOR_CARACTER = pV_VALOR_CARACTER;
            PV_VALOR_NUMERICO = pV_VALOR_NUMERICO;
            PV_VALOR_DATE = pV_VALOR_DATE;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_DOMINIOS(string pV_DOMINIO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_DOMINIOS";
                    cmd.Parameters.AddWithValue("PV_DOMINIO", pV_DOMINIO);
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

        public static DataTable PR_PAR_GET_MUNDO()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_MUNDO";
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
                    cmd.CommandText = "PR_PAR_GET_DOMINIOS_IND";
                    cmd.Parameters.AddWithValue("PV_DOMINIO", PV_DOMINIO);
                    cmd.Parameters.AddWithValue("PV_CODIGO", PV_CODIGO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PV_CODIGO = (string)dr["CODIGO"];
                            PV_DESCRIPCION = (string)dr["DESCRIPCION"];
                            if (string.IsNullOrEmpty(dr["VALOR_CARACTER"].ToString()))
                                PV_VALOR_CARACTER = "";
                            else
                                PV_VALOR_CARACTER = (string)dr["VALOR_CARACTER"];
                            if (string.IsNullOrEmpty(dr["VALOR_NUMERICO"].ToString()))
                                PV_VALOR_NUMERICO = "";
                            else
                                PV_VALOR_NUMERICO = (string)dr["VALOR_NUMERICO"];
                            if (string.IsNullOrEmpty(dr["VALOR_DATE"].ToString()))
                                PV_VALOR_DATE = "";
                            else
                                PV_VALOR_DATE = (string)dr["VALOR_DATE"];
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
                    cmd.CommandText = "PR_ABM_DOMINIOS";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    
                    cmd.Parameters.AddWithValue("PV_DOMINIO", PV_DOMINIO);
                    cmd.Parameters.AddWithValue("PV_CODIGO", PV_CODIGO);
                    cmd.Parameters.AddWithValue("PV_DESCRIPCION", PV_DESCRIPCION);
                    cmd.Parameters.AddWithValue("PV_VALOR_CARACTER", PV_VALOR_CARACTER);
                    cmd.Parameters.AddWithValue("PV_VALOR_NUMERICO", PV_VALOR_NUMERICO);
                    cmd.Parameters.AddWithValue("PV_VALOR_DATE", PV_VALOR_DATE);
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.Add("PV_ESTADOPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_DESCRIPCIONPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_ERROR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    PV_ESTADOPR = (string)cmd.Parameters["PV_ESTADOPR"].Value;
                    PV_DESCRIPCIONPR = (string)cmd.Parameters["PV_DESCRIPCIONPR"].Value;
                    if(string.IsNullOrEmpty(cmd.Parameters["PV_ERROR"].Value.ToString()))
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