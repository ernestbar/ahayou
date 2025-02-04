using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Ingreso_app
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string pv_usuario { get; set; }
        public string pv_password { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_TEMPORAL { get; set; }

        #endregion
        #region Constructores
       
        public Ingreso_app(string Pv_usuario, string Pv_password)
        {
            pv_usuario = Pv_usuario;
            pv_password = Pv_password;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_SEG_GET_MENUS_PADRE_ROL(string pV_USUARIO,string pV_SISTEMA)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_MENUS_PADRE_ROL";
                    cmd.Parameters.AddWithValue("PV_USUARIO", pV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_SISTEMA", pV_SISTEMA);
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

        public static DataTable PR_SEG_GET_MENUS_ROL(string pV_USUARIO,Int64 pv_MEN_COD_MENU_PADRE, string pV_SISTEMA)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_MENUS_ROL";
                    cmd.Parameters.AddWithValue("PV_USUARIO", pV_USUARIO);
                    cmd.Parameters.AddWithValue("pv_MEN_COD_MENU_PADRE", pv_MEN_COD_MENU_PADRE);
                    cmd.Parameters.AddWithValue("PV_SISTEMA", pV_SISTEMA);
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
        public static DataTable PR_SEG_GET_OPCIONES_ROLES(Int64 pd_MEN_COD_MENU, string pV_USUARIO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_SEG_GET_OPCIONES_ROLES";
                    cmd.Parameters.AddWithValue("PV_USUARIO", pV_USUARIO);
                    cmd.Parameters.AddWithValue("pd_MEN_COD_MENU", pd_MEN_COD_MENU);
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
                    //cmd.Parameters.AddWithValue("PV_DOMINIO", PV_DOMINIO);
                    //cmd.Parameters.AddWithValue("PV_CODIGO", PV_CODIGO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            //PV_CODIGO = (string)dr["CODIGO"];
                            //PV_DESCRIPCION = (string)dr["DESCRIPCION"];
                            //if (string.IsNullOrEmpty(dr["VALOR_CARACTER"].ToString()))
                            //    PV_VALOR_CARACTER = "";
                            //else
                            //    PV_VALOR_CARACTER = (string)dr["VALOR_CARACTER"];
                            //if (string.IsNullOrEmpty(dr["VALOR_NUMERICO"].ToString()))
                            //    PV_VALOR_NUMERICO = "";
                            //else
                            //    PV_VALOR_NUMERICO = (string)dr["VALOR_NUMERICO"];
                            //if (string.IsNullOrEmpty(dr["VALOR_DATE"].ToString()))
                            //    PV_VALOR_DATE = "";
                            //else
                            //    PV_VALOR_DATE = (string)dr["VALOR_DATE"];
                        }

                    }

                }

            }
            catch { }
        }



        public string INGRESAR()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_INGRESO_APP";
                    
                    cmd.Parameters.AddWithValue("pv_usuario", pv_usuario);
                    cmd.Parameters.AddWithValue("pv_password", pv_password);
                    cmd.Parameters.Add("PV_ESTADOPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_DESCRIPCIONPR", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("PV_TEMPORAL", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    PV_ESTADOPR = (string)cmd.Parameters["PV_ESTADOPR"].Value;
                    PV_DESCRIPCIONPR = (string)cmd.Parameters["PV_DESCRIPCIONPR"].Value;
                    if (string.IsNullOrEmpty(cmd.Parameters["PV_TEMPORAL"].Value.ToString()))
                        PV_TEMPORAL = "";
                    else
                        PV_TEMPORAL = (string)cmd.Parameters["PV_TEMPORAL"].Value;
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