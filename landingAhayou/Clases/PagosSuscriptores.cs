using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting;

namespace landingAhayou.Clases
{
    public class PagosSuscriptores
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public Int64 PB_ID { get; set; }
        public string PV_DETALLES { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }
        #endregion
        #region Constructores
       
        public PagosSuscriptores(string pV_TIPO_OPERACION, Int64 pB_ID, string pV_DETALLES, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PB_ID = pB_ID;
            PV_DETALLES = pV_DETALLES;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static Int64 PR_REG_DEVUELVE_IDSESION(string pV_USUARIO,Int64 pB_CODIGO_PLAN)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_REG_DEVUELVE_IDSESION";
                    cmd.Parameters.AddWithValue("PB_CODIGO_PLAN", pB_CODIGO_PLAN);
                    cmd.Parameters.AddWithValue("PV_USUARIO", pV_USUARIO);
                    cmd.Parameters.Add("PI_ID", SqlDbType.BigInt, 250).Direction = ParameterDirection.Output;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Int64 ID = 0;
                    if (cmd.Parameters["PI_ID"].Value != null)
                        ID =Int64.Parse(cmd.Parameters["PI_ID"].Value.ToString());
                    conn.Close();
                    return ID;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }

        }

        public static string PR_SEG_VERIFICA_ESTADO_IDSESION(Int64 pI_ID)
        {
            try
            {
                string resultado = "";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_VERIFICA_ESTADO_IDSESION";
                    cmd.Parameters.AddWithValue("PI_ID", pI_ID);
                    cmd.Connection = conn;
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    foreach (DataRow row in dataTable.Rows) {
                        resultado = row["estado"].ToString();
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return "";
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
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "PR_PAR_GET_AVATARES_IND";
                    //cmd.Parameters.AddWithValue("PV_CODIGO_AVATAR", PV_CODIGO_AVATAR);
                    //cmd.Connection = conn;
                    //conn.Open();
                    //var dataReader = cmd.ExecuteReader();
                    //var dataTable = new DataTable();
                    //dataTable.Load(dataReader);
                    //if (dataTable.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dataTable.Rows)
                    //    {
                    //        PB_AVATAR = (string)dr["AVATAR"];
                    //    }

                    //}

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
                    cmd.CommandText = "PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR_IDSESION";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PB_ID", PB_ID);
                    cmd.Parameters.AddWithValue("PV_DETALLES", PV_DETALLES);
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