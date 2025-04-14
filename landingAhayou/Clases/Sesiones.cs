using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.UI.WebControls;


namespace landingAhayou.Clases
{
    public class Sesiones
    { 
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_USUARIOREG { get; set; }
        public string PV_SESIONID { get; set; }

        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

#endregion
        #region Constructores
        //public Sesiones(string pV_USUARIOREG)
        //{
        //    PV_USUARIOREG = pV_USUARIOREG;
        //    RecuperarDatos();
        //}
        //public Sesiones(string pV_USUARIOREG, string pV_SESIONID)
        //{
        //    PV_USUARIOREG = pV_USUARIOREG;
        //    PV_SESIONID = pV_SESIONID;
        //    PR_INGRESO_APP(pV_USUARIOREG, pV_SESIONID);
        //}
        public Sesiones(string pV_TIPO_OPERACION, string pV_USUARIOREG, string pV_SESIONID, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_USUARIOREG = pV_USUARIOREG;
            PV_SESIONID = pV_SESIONID;
            PV_USUARIO = pV_USUARIO;

        }
        #endregion
        #region Métodos que NO requieren constructor


        public static DataTable PR_PAR_GET_SESIONES()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_SESIONES";
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

        public static bool PR_PAR_VALIDA_ACCESO_POR_SESIONES(string pV_USUARIO)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_VALIDA_ACCESO_POR_SESIONES ";
                    cmd.Parameters.AddWithValue("PV_USUARIO", pV_USUARIO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    bool permitido = false;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[0].ToString() == "0")
                            permitido = true;
                        else
                            permitido= false;
                    }
                    return permitido;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        #endregion
        #region Métodos que requieren constructor
        //private void RecuperarDatos()
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "PR_PAR_GET_SUSCRIPTORES_IND";
        //            cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIOREG);
        //            cmd.Connection = conn;
        //            conn.Open();
        //            var dataReader = cmd.ExecuteReader();
        //            var dataTable = new DataTable();
        //            dataTable.Load(dataReader);
        //            if (dataTable.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dataTable.Rows)
        //                {
        //                    PV_NOMBRE_COMPLETO = (string)dr["NOMBRE_COMPLETO"];
        //                    PV_EMAIL = (string)dr["EMAIL"];
        //                    if (string.IsNullOrEmpty(dr["CELULAR"].ToString()))
        //                        PV_CELULAR = "";
        //                    else
        //                        PV_CELULAR = (string)dr["CELULAR"];

        //                }

        //            }

        //        }


        //    }
        //    catch { }
        //}



        public string ABM()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_ABM_SESIONES";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PV_USUARIOREG", PV_USUARIOREG);
                    cmd.Parameters.AddWithValue("PV_SESIONID", PV_SESIONID);
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