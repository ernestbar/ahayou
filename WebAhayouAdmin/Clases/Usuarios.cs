using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Usuarios
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_PERSONAL { get; set; }
        public string PV_SUPERVISOR_INMEDIATO { get; set; }
        public string PV_COD_SUCURSAL { get; set; }
        public string PV_NOMBRE_COMPLETO { get; set; }
        public string PV_TIPO_DOCUMENTO { get; set; }
        public string PV_NUMERO_DOCUMENTO { get; set; }
        public string PV_EXPEDIDO { get; set; }
        public string PV_COD_CARGO { get; set; }

        public int PN_CELULAR { get; set; }
        public int PN_FIJO { get; set; }
        public int PN_INTERNO { get; set; }
        public string PV_EMAIL { get; set; }

        public string PV_USUARIOI { get; set; }
        public string PV_PASSWORD { get; set; }
        public string PV_PASSWORD_ANTERIOR { get; set; }
        public string PV_DESCRIPCION { get; set; }
        public DateTime PD_FECHA_DESDE { get; set; }
        public DateTime PD_FECHA_HASTA { get; set; }
        public string PV_ROL { get; set; }


        public string PV_USUARIO { get; set; }
        public string PV_EMAILOUT { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Usuarios(string pV_USUARIO, string pV_COD_PERSONAL)
        {
            PV_USUARIO = pV_USUARIO;
            PV_COD_PERSONAL = pV_COD_PERSONAL;
            RecuperarDatos();
        }
        public Usuarios(string pV_TIPO_OPERACION, string pV_COD_PERSONAL, string pV_SUPERVISOR_INMEDIATO,
            string pV_COD_SUCURSAL, string pV_NOMBRE_COMPLETO, string pV_TIPO_DOCUMENTO, string pV_NUMERO_DOCUMENTO,
            string pV_EXPEDIDO, string pV_COD_CARGO, int pN_CELULAR, int pN_FIJO, int pN_INTERNO, string pV_EMAIL,
            string pV_USUARIOI, string pV_PASSWORD, string pV_PASSWORD_ANTERIOR, string pV_DESCRIPCION,
            DateTime pD_FECHA_DESDE, DateTime pD_FECHA_HASTA, string pV_ROL, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_PERSONAL = pV_COD_PERSONAL;
            PV_SUPERVISOR_INMEDIATO = pV_SUPERVISOR_INMEDIATO;
            PV_COD_SUCURSAL = pV_COD_SUCURSAL;
            PV_NOMBRE_COMPLETO = pV_NOMBRE_COMPLETO;
            PV_TIPO_DOCUMENTO = pV_TIPO_DOCUMENTO;
            PV_NUMERO_DOCUMENTO = pV_NUMERO_DOCUMENTO;
            PV_EXPEDIDO = pV_EXPEDIDO;
            PV_COD_CARGO = pV_COD_CARGO;
            PN_CELULAR = pN_CELULAR;
            PN_FIJO = pN_FIJO;
            PN_INTERNO = pN_INTERNO;
            PV_EMAIL = pV_EMAIL;
            PV_USUARIOI = pV_USUARIOI;
            PV_PASSWORD = pV_PASSWORD;
            PV_PASSWORD_ANTERIOR = pV_PASSWORD_ANTERIOR;
            PV_DESCRIPCION = pV_DESCRIPCION;
            PD_FECHA_DESDE = pD_FECHA_DESDE;
            PD_FECHA_HASTA = pD_FECHA_HASTA;
            PV_ROL = pV_ROL;
            PV_USUARIO = pV_USUARIO;

        }
        #endregion
        #region Métodos que NO requieren constructor
        public  string PR_SEG_CAMBIOPASSWORD(string PV_COD_USUARIO, string PV_PASSWORDANTERIOR, string PV_PASSWORDNUEVO, string PV_USUARIO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_CAMBIOPASSWORD";
                    cmd.Parameters.AddWithValue("PV_COD_USUARIO", PV_COD_USUARIO);
                    cmd.Parameters.AddWithValue("PV_PASSWORDANTERIOR", PV_PASSWORDANTERIOR);
                    cmd.Parameters.AddWithValue("PV_PASSWORDNUEVO", PV_PASSWORDNUEVO);
                    cmd.Parameters.AddWithValue("PV_PASSWORDNUEVO", PV_PASSWORDNUEVO);
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
                    return PV_DESCRIPCIONPR;
                }
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                PV_DESCRIPCIONPR = "ERROR EN CAPA DE NEGOCIOS";
                return PV_DESCRIPCIONPR;
            }

        }

        public static DataTable PR_PAR_GET_PERSONAL()
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PERSONAL";
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

        public static DataTable PR_PAR_GET_USUARIOS(string PV_COD_PERSONAL)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_PERSONAL";
                    cmd.Parameters.AddWithValue("PV_COD_PERSONAL", PV_COD_PERSONAL);
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
                    cmd.Parameters.AddWithValue("PV_COD_PERSONAL", PV_COD_PERSONAL);
                    cmd.Parameters.AddWithValue("PV_SUPERVISOR_INMEDIATO", PV_SUPERVISOR_INMEDIATO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PV_SUPERVISOR_INMEDIATO = (string)dr["CODIGO"];
                            PV_COD_SUCURSAL = (string)dr["DESCRIPCION"];
                            if (string.IsNullOrEmpty(dr["VALOR_CARACTER"].ToString()))
                                PV_NOMBRE_COMPLETO = "";
                            else
                                PV_NOMBRE_COMPLETO = (string)dr["VALOR_CARACTER"];
                            if (string.IsNullOrEmpty(dr["VALOR_NUMERICO"].ToString()))
                                PV_TIPO_DOCUMENTO = "";
                            else
                                PV_TIPO_DOCUMENTO = (string)dr["VALOR_NUMERICO"];
                            if (string.IsNullOrEmpty(dr["VALOR_DATE"].ToString()))
                                PV_NUMERO_DOCUMENTO = "";
                            else
                                PV_NUMERO_DOCUMENTO = (string)dr["VALOR_DATE"];
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
                    if (PV_COD_PERSONAL == "")
                        cmd.Parameters.AddWithValue("PV_COD_PERSONAL", null);
                    else
                        cmd.Parameters.AddWithValue("PV_COD_PERSONAL", PV_COD_PERSONAL);
                    cmd.Parameters.AddWithValue("PV_SUPERVISOR_INMEDIATO", PV_SUPERVISOR_INMEDIATO);
                    cmd.Parameters.AddWithValue("PV_COD_SUCURSAL", PV_COD_SUCURSAL);
                    cmd.Parameters.AddWithValue("PV_NOMBRE_COMPLETO", PV_NOMBRE_COMPLETO);
                    cmd.Parameters.AddWithValue("PV_TIPO_DOCUMENTO", PV_TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("PV_NUMERO_DOCUMENTO", PV_NUMERO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("PV_EXPEDIDO", PV_EXPEDIDO);
                    cmd.Parameters.Add("PV_ESTADOPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_COD_SUCURSALPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
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