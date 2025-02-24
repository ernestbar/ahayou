using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Reportes
    {
        #region Métodos que NO requieren constructor
        public static DataTable PR_REP_GET_REGISTRO_PROPIETARIOS()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_REGISTRO_PROPIETARIOS";
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

        public static DataTable PR_REP_GET_SUSCRIPCIONES_PERIODO()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_SUSCRIPCIONES_PERIODO";
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

        public static DataTable PR_REP_GET_SUSCRIPCIONES_NO_RENOVADAS_MES_PASADO()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_SUSCRIPCIONES_NO_RENOVADAS_MES_PASADO";
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
        public static DataTable PR_REP_GET_VISTAS_CONTENIDO(DateTime pd_fechaIni,DateTime pd_fechaFin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_VISTAS_CONTENIDO";
                    cmd.Parameters.AddWithValue("pd_fechaIni", pd_fechaIni);
                    cmd.Parameters.AddWithValue("pd_fechaFin", pd_fechaFin);
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
        public static DataTable PR_REP_GET_SUSCRIPCIONES(DateTime pd_fechaIni, DateTime pd_fechaFin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_SUSCRIPCIONES";
                    cmd.Parameters.AddWithValue("pd_fechaIni", pd_fechaIni);
                    cmd.Parameters.AddWithValue("pd_fechaFin", pd_fechaFin);
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

        public static DataTable PR_REP_GET_REGISTRO_CONTENIDO(DateTime pd_fechaIni, DateTime pd_fechaFin,string pv_nombre_contenido)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_REGISTRO_CONTENIDO";
                    cmd.Parameters.AddWithValue("pd_fechaIni", pd_fechaIni);
                    cmd.Parameters.AddWithValue("pd_fechaFin", pd_fechaFin);
                    cmd.Parameters.AddWithValue("pv_nombre_contenido", pv_nombre_contenido);
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

        public static DataTable PR_REP_GET_SUSCRIPCIONES_PAGOS(DateTime pd_fechaIni, DateTime pd_fechaFin, string pv_nombre_contenido,string pv_email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REP_GET_SUSCRIPCIONES_PAGOS";
                    cmd.Parameters.AddWithValue("pd_fechaIni", pd_fechaIni);
                    cmd.Parameters.AddWithValue("pd_fechaFin", pd_fechaFin);
                    cmd.Parameters.AddWithValue("pv_nombre", pv_nombre_contenido);
                    cmd.Parameters.AddWithValue("pv_email", pv_email);
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
    }
}