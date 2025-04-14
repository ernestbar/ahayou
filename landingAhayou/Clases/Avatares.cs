using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace landingAhayou.Clases
{
    public class Avatares
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_PERFIL_SUSCRIPTOR { get; set; }
        public string PV_NOMBRE_PERFIL { get; set; }
        public string PV_CODIGO_AVATAR { get; set; }
        public Int64 PI_PIN  { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }
        #endregion
        #region Constructores
        public Avatares(string pV_CODIGO_AVATAR)
        {
            PV_CODIGO_AVATAR = pV_CODIGO_AVATAR;
            RecuperarDatos();
        }
        public Avatares(string pV_TIPO_OPERACION,string pV_COD_PERFIL_SUSCRIPTOR, string pV_CODIGO_AVATAR, string pV_NOMBRE_PERFIL,
            Int64 pI_PIN, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_PERFIL_SUSCRIPTOR = pV_COD_PERFIL_SUSCRIPTOR;
            PV_CODIGO_AVATAR = pV_CODIGO_AVATAR;
            PV_NOMBRE_PERFIL= pV_NOMBRE_PERFIL;
            PI_PIN = pI_PIN;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_AVATARES()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_AVATARES";
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
                    cmd.CommandText = "PR_STR_ABM_PERFIL_SUSCRIPTOR";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_NOMBRE_PERFIL", PV_NOMBRE_PERFIL);
                    cmd.Parameters.AddWithValue("PV_CODIGO_AVATAR", PV_CODIGO_AVATAR);
                    cmd.Parameters.AddWithValue("PI_PIN", PI_PIN);
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