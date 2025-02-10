using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace landingAhayou.Clases
{
    public class Promociones
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_CODIGO_PROMOCION { get; set; }
        public string PV_MUNDO { get; set; }
        public Int64 PB_CODIGO_PLAN { get; set; }
        public string PV_PROMOCION { get; set; }
        public decimal PD_PROCENTAJE { get; set; }
        public DateTime PD_FECHA_DESDE { get; set; }
        public DateTime PD_FECHA_HASTA { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Promociones(Int64 pB_CODIGO_PROMOCION)
        {
            PB_CODIGO_PROMOCION = pB_CODIGO_PROMOCION;
            RecuperarDatos();
        }
        public Promociones(string pV_TIPO_OPERACION, Int64 pB_CODIGO_PROMOCION,
            Int64 pB_CODIGO_PLAN, string pV_PROMOCION, DateTime pD_FECHA_DESDE, 
            string pV_MUNDO, string pV_MONEDA, decimal pD_PROCENTAJE,
            DateTime pD_FECHA_HASTA,  string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_CODIGO_PROMOCION = pB_CODIGO_PROMOCION;
            PB_CODIGO_PLAN = pB_CODIGO_PLAN;
            PV_PROMOCION = pV_PROMOCION;
            PD_FECHA_DESDE = pD_FECHA_DESDE;
            PV_MUNDO = pV_MUNDO;
            PD_PROCENTAJE = pD_PROCENTAJE;
            PD_FECHA_HASTA = pD_FECHA_HASTA;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_PROMOCION()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PROMOCION";
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
        public static DataTable PR_PAR_GET_PROMOCIONES_PROMO(string pV_MUNDO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PROMOCIONES_PROMO";
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
                    cmd.CommandText = "PR_PAR_GET_PROMOCION_IND";
                    cmd.Parameters.AddWithValue("PB_CODIGO_PROMOCION", PB_CODIGO_PROMOCION);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PB_CODIGO_PLAN = Int64.Parse(dr["CODIGO_PLAN"].ToString());

                            if (string.IsNullOrEmpty(dr["PROMOCION"].ToString()))
                                PV_PROMOCION = "";
                            else
                                PV_PROMOCION = (string)dr["PROMOCION"];

                            if (string.IsNullOrEmpty(dr["FECHA_DESDE"].ToString()))
                                PD_FECHA_DESDE = DateTime.Parse("01/01/3000");
                            else
                                PD_FECHA_DESDE = DateTime.Parse(dr["FECHA_DESDE"].ToString());

                            if (string.IsNullOrEmpty(dr["MUNDO"].ToString()))
                                PV_MUNDO = "";
                            else
                                PV_MUNDO = (string)dr["MUNDO"];
                           
                            if (string.IsNullOrEmpty(dr["PORCENTAJE"].ToString()))
                                PD_PROCENTAJE = 0;
                            else
                                PD_PROCENTAJE = decimal.Parse(dr["PORCENTAJE"].ToString());

                            if (string.IsNullOrEmpty(dr["FECHA_HASTA"].ToString()))
                                PD_FECHA_HASTA = DateTime.Parse("01/01/3000");
                            else
                                PD_FECHA_DESDE = DateTime.Parse(dr["FECHA_HASTA"].ToString());

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
                    cmd.CommandText = "PR_PAR_ABM_PROMOCIONES";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_CODIGO_PROMOCION", PB_CODIGO_PROMOCION);
                    cmd.Parameters.AddWithValue("PB_CODIGO_PLAN", PB_CODIGO_PLAN);
                    cmd.Parameters.AddWithValue("PV_PROMOCION", PV_PROMOCION);
                    cmd.Parameters.AddWithValue("PD_FECHA_DESDE", PD_FECHA_DESDE);
                    cmd.Parameters.AddWithValue("PV_MUNDO", PV_MUNDO);
                    cmd.Parameters.AddWithValue("PD_PORCENTAJE", PD_PROCENTAJE);
                    cmd.Parameters.AddWithValue("PD_FECHA_HASTA", PD_FECHA_HASTA);
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