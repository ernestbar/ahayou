using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Planes_paquetes
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_CODIGO_PLAN { get; set; }
        public Int64 PB_NRO_PLAN { get; set; }
        public decimal PD_MONTO { get; set; }
        public Int64 PB_CANT_MES { get; set; }
        public string PV_PLAN { get; set; }
        public string PV_PLAN_INGLES { get; set; }
        public string PV_MUNDO { get; set; }
        public string PV_CARACTERISTICAS { get; set; }
        public string PV_CARACTERISTICAS_INGLES { get; set; }
        public Int64 PB_CANT_PERFIL { get; set; }
        public string PV_MONEDA { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Planes_paquetes(Int64 pB_CODIGO_PLAN)
        {
            PB_CODIGO_PLAN = pB_CODIGO_PLAN;
            RecuperarDatos();
        }
        public Planes_paquetes(string pV_TIPO_OPERACION, Int64 pB_CODIGO_PLAN,
            Int64 pB_NRO_PLAN, string pV_PLAN, string pV_PLAN_INGLES, Int64 pB_CANT_MES,
            string pV_MUNDO, string pV_MONEDA,decimal pD_MONTO, 
            string pV_CARACTERISTICAS,string pV_CARACTERISTICAS_INGLES,
            Int64 pB_CANT_PERFIL,string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_CODIGO_PLAN = pB_CODIGO_PLAN;
            PB_NRO_PLAN = pB_NRO_PLAN;
            PV_PLAN = pV_PLAN;
            PV_PLAN_INGLES = pV_PLAN_INGLES;
            PB_CANT_MES=pB_CANT_MES;
            PV_MUNDO = pV_MUNDO;
            PV_MONEDA = pV_MONEDA;
            PD_MONTO = pD_MONTO;
            PV_CARACTERISTICAS = pV_CARACTERISTICAS;
            PV_CARACTERISTICAS_INGLES = pV_CARACTERISTICAS_INGLES;
            PB_CANT_PERFIL = pB_CANT_PERFIL;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_PLANES()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PLANES";
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
        public static DataTable PR_PAR_GET_PLANES_PROMO(string pV_MUNDO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PLANES_PROMO";
                    cmd.Parameters.AddWithValue("PV_MUNDO", pV_MUNDO);
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
                    cmd.CommandText = "PR_PAR_GET_PLANES_IND";
                    cmd.Parameters.AddWithValue("PV_CODIGO_PLAN", PB_CODIGO_PLAN);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PB_NRO_PLAN = Int64.Parse(dr["NRO_PLAN"].ToString());
                            if (string.IsNullOrEmpty(dr["PLANES"].ToString()))
                                PV_PLAN = "";
                            else
                                PV_PLAN = (string)dr["PLANES"];

                            if (string.IsNullOrEmpty(dr["PLAN_INGLES"].ToString()))
                                PV_PLAN_INGLES = "";
                            else
                                PV_PLAN_INGLES = (string)dr["PLAN_INGLES"];
                            if (string.IsNullOrEmpty(dr["MUNDO"].ToString()))
                                PV_MUNDO = "";
                            else
                                PV_MUNDO = (string)dr["MUNDO"];
                            if (string.IsNullOrEmpty(dr["MONEDA"].ToString()))
                                PV_MONEDA = "";
                            else
                                PV_MONEDA = (string)dr["MONEDA"];
                            if (string.IsNullOrEmpty(dr["CANT_MES"].ToString()))
                                PB_CANT_MES = 0;
                            else
                                PB_CANT_MES = Int64.Parse(dr["CANT_MES"].ToString());
                            if (string.IsNullOrEmpty(dr["MONTO"].ToString()))
                                PD_MONTO = 0;
                            else
                                PD_MONTO = decimal.Parse(dr["MONTO"].ToString());
                            if (string.IsNullOrEmpty(dr["CARACTERISTICAS"].ToString()))
                                PV_CARACTERISTICAS = "";
                            else
                                PV_CARACTERISTICAS = (string)dr["CARACTERISTICAS"];
                            if (string.IsNullOrEmpty(dr["CARACTERISTICAS_INGLES"].ToString()))
                                PV_CARACTERISTICAS_INGLES = "";
                            else
                                PV_CARACTERISTICAS_INGLES = (string)dr["CARACTERISTICAS_INGLES"];
                            if (string.IsNullOrEmpty(dr["CANT_PERFIL"].ToString()))
                                PB_CANT_PERFIL = 0;
                            else
                                PB_CANT_PERFIL = Int64.Parse(dr["CANT_PERFIL"].ToString());
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
                    cmd.CommandText = "PR_PAR_ABM_PLANES";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_CODIGO_PLAN", PB_CODIGO_PLAN);
                    cmd.Parameters.AddWithValue("PB_NRO_PLAN", PB_NRO_PLAN);
                    cmd.Parameters.AddWithValue("PV_PLAN", PV_PLAN);
                    cmd.Parameters.AddWithValue("PV_PLAN_INGLES", PV_PLAN_INGLES);
                    cmd.Parameters.AddWithValue("PV_MUNDO", PV_MUNDO);
                    cmd.Parameters.AddWithValue("PV_MONEDA", PV_MONEDA);
                    cmd.Parameters.AddWithValue("PB_CANT_MES", PB_CANT_MES);
                    cmd.Parameters.AddWithValue("PB_CANT_PERFIL", PB_CANT_PERFIL);
                    cmd.Parameters.AddWithValue("PD_MONTO", PD_MONTO);
                    cmd.Parameters.AddWithValue("PV_CARACTERISTICAS", PV_CARACTERISTICAS);
                    cmd.Parameters.AddWithValue("PV_CARACTERISTICAS_INGLES", PV_CARACTERISTICAS_INGLES);
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