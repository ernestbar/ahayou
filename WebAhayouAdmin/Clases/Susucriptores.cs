using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace WebAhayouAdmin.Clases
{
    public class Susucriptores
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_USUARIOI { get; set; }
        public string PV_PASSWORD { get; set; }
        public string PV_PASSWORD_ANTERIOR { get; set; }
        public string PV_NOMBRE_COMPLETO { get; set; }
        public string PV_CELULAR { get; set; }
        public string PV_EMAIL { get; set; }
        public string PV_AVATAR1 { get; set; }
        public string PV_AVATAR2 { get; set; }


        public string PV_USUARIO { get; set; }
        public string PV_EMAILOUT { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Susucriptores(string pV_USUARIOI)
        {
            PV_USUARIOI = pV_USUARIOI;
            RecuperarDatos();
        }
        public Susucriptores(string pV_TIPO_OPERACION, string pV_USUARIOI, string pV_PASSWORD, string pV_PASSWORD_ANTERIOR,
            string pV_NOMBRE_COMPLETO, string pV_CELULAR, string pV_EMAIL, string pV_AVATAR1, string pV_AVATAR2,
            string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_USUARIOI = pV_USUARIOI;
            PV_NOMBRE_COMPLETO = pV_NOMBRE_COMPLETO;
            PV_AVATAR1 = pV_AVATAR1;
            PV_AVATAR2 = pV_AVATAR2;
            PV_CELULAR = pV_CELULAR;
            PV_EMAIL = pV_EMAIL;
            PV_USUARIOI = pV_USUARIOI;
            PV_PASSWORD = pV_PASSWORD;
            PV_PASSWORD_ANTERIOR = pV_PASSWORD_ANTERIOR;
            PV_USUARIO = pV_USUARIO;

        }
        #endregion
        #region Métodos que NO requieren constructor
        

        public static DataTable PR_PAR_GET_SUSCRIPTORES()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_SUSCRIPTORES";
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
                    cmd.CommandText = "PR_PAR_GET_SUSCRIPTORES_IND";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIOI);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PV_NOMBRE_COMPLETO = (string)dr["NOMBRE_COMPLETO"];
                            PV_EMAIL = (string)dr["EMAIL"];
                            if (string.IsNullOrEmpty(dr["CELULAR"].ToString()))
                                PV_CELULAR = "";
                            else
                                PV_CELULAR = (string)dr["CELULAR"];
                            if (string.IsNullOrEmpty(dr["AVATAR1"].ToString()))
                                PV_AVATAR1 = "";
                            else
                                PV_AVATAR1 = (string)dr["AVATAR1"];
                            if (string.IsNullOrEmpty(dr["AVATAR2"].ToString()))
                                PV_AVATAR2 = "";
                            else
                                PV_AVATAR2 = (string)dr["AVATAR2"];
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
                    cmd.CommandText = "PR_ABM_SUSCRIPTOR";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PV_USUARIOI", PV_USUARIOI);
                    cmd.Parameters.AddWithValue("PV_NOMBRE_COMPLETO", PV_NOMBRE_COMPLETO);
                    cmd.Parameters.AddWithValue("PV_AVATAR1", PV_AVATAR1);
                    cmd.Parameters.AddWithValue("PV_AVATAR2", PV_AVATAR2);
                    cmd.Parameters.AddWithValue("PV_CELULAR", PV_CELULAR);
                    cmd.Parameters.AddWithValue("PV_EMAIL", PV_EMAIL);
                    cmd.Parameters.AddWithValue("PV_PASSWORD", PV_PASSWORD);
                    cmd.Parameters.AddWithValue("PV_PASSWORD_ANTERIOR", PV_PASSWORD_ANTERIOR);
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.Add("PV_ESTADOPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_DESCRIPCIONPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_ERROR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_EMAILOUT", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    PV_ESTADOPR = (string)cmd.Parameters["PV_ESTADOPR"].Value;
                    PV_DESCRIPCIONPR = (string)cmd.Parameters["PV_DESCRIPCIONPR"].Value;
                    if (string.IsNullOrEmpty(cmd.Parameters["PV_EMAILOUT"].Value.ToString()))
                        PV_EMAILOUT = "";
                    else
                        PV_EMAILOUT = (string)cmd.Parameters["PV_EMAILOUT"].Value;
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