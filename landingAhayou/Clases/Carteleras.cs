using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace landingAhayou.Clases
{
    public class Carteleras
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_PERFIL_SUSCRIPTOR { get; set; }
        public string PV_COD_PLAN_SUSCRIPTOR { get; set; }
        public string PV_USUARIO_STR { get; set; }
        public int PI_CODIGO_PLAN { get; set; }
        public string PV_COD_CONTENIDO_STR { get; set; }
        public string PV_TIEMPO_VISTO { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion

        #region Constructores
        public Carteleras(string pV_USUARIOI)
        {
            //PV_USUARIOI = pV_USUARIOI;
            //RecuperarDatos();
        }
     
         public Carteleras(string pV_TIPO_OPERACION, string pV_COD_PERFIL_SUSCRIPTOR, string pV_COD_PLAN_SUSCRIPTOR,
         string pV_USUARIO_STR, int pI_CODIGO_PLAN, string pV_COD_CONTENIDO_STR, string pV_TIEMPO_VISTO,
         string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_PERFIL_SUSCRIPTOR = pV_COD_PERFIL_SUSCRIPTOR;
            PV_COD_PLAN_SUSCRIPTOR = pV_COD_PLAN_SUSCRIPTOR;
            PV_USUARIO_STR = pV_USUARIO_STR;
            PI_CODIGO_PLAN = pI_CODIGO_PLAN;
            PV_COD_CONTENIDO_STR = pV_COD_CONTENIDO_STR;
            PV_TIEMPO_VISTO = pV_TIEMPO_VISTO;
            PV_USUARIO = pV_USUARIO;

        }
        #endregion


        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_MENU_CARTELERA()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_MENU_CARTELERA";
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
        public static DataTable PR_STR_GET_VER_SECCIONES_BUSQUEDA(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, string PV_BUSQUEDA)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_VER_SECCIONES_BUSQUEDA";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_BUSQUEDA", PV_BUSQUEDA);
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
        public static DataTable PR_STR_GET_VER_SECCIONES_CARTELERA(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, string PI_MENU)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_VER_SECCIONES_CARTELERA";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PI_MENU", PI_MENU);
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

        public static DataTable PR_STR_GET_VER_CARTELERA(string PV_USUARIO,string PV_COD_PLAN_SUSCRIPTOR,string PV_COD_PERFIL_SUSCRIPTOR,string PI_MENU, string PV_SECCION)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_VER_CARTELERA";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PI_MENU", PI_MENU);
                    cmd.Parameters.AddWithValue("PV_SECCION", PV_SECCION);
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

        public static DataTable PR_STR_GET_VER_CARTELERA_CONSULTA(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, string PI_MENU, string PV_SECCION)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_VER_CARTELERA_CONSULTA";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_BUSQUEDA", PI_MENU);
                    cmd.Parameters.AddWithValue("PV_SECCION", PV_SECCION);
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
        public static DataTable PR_STR_GET_FAVORITOS(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, int PI_MENU)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_FAVORITOS";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PI_MENU", PI_MENU);
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

        public static DataTable PR_STR_GET_SEGUIR_VIENDO(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, int PI_MENU)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_SEGUIR_VIENDO";
                    cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIO);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PI_MENU", PI_MENU);
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
                    //cmd.CommandText = "PR_PAR_GET_SUSCRIPTORES_IND";
                    //cmd.Parameters.AddWithValue("PV_USUARIO", PV_USUARIOI);
                    //cmd.Connection = conn;
                    //conn.Open();
                    //var dataReader = cmd.ExecuteReader();
                    //var dataTable = new DataTable();
                    //dataTable.Load(dataReader);
                    //if (dataTable.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dataTable.Rows)
                    //    {
                    //        PV_NOMBRE_COMPLETO = (string)dr["NOMBRE_COMPLETO"];
                    //        PV_EMAIL = (string)dr["EMAIL"];
                    //        if (string.IsNullOrEmpty(dr["CELULAR"].ToString()))
                    //            PV_CELULAR = "";
                    //        else
                    //            PV_CELULAR = (string)dr["CELULAR"];

                    //    }

                    //}

                }


            }
            catch { }
        }

        /// <summary>
        /// V para agregar a vistos
        /// S actualizar avance del streaming
        /// F agregar a favoritos
        /// NF quitar de favoritos
        /// L dar like
        /// NL no like
        /// 
        /// </summary>
        /// <returns></returns>

        public string ABM()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_ABM_CONTENIDO_LISTA";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                    cmd.Parameters.AddWithValue("PV_USUARIO_STR", PV_USUARIO_STR);
                    cmd.Parameters.AddWithValue("PI_CODIGO_PLAN", PI_CODIGO_PLAN);
                    cmd.Parameters.AddWithValue("PV_COD_CONTENIDO_STR", PV_COD_CONTENIDO_STR);
                    cmd.Parameters.AddWithValue("PV_TIEMPO_VISTO", PV_TIEMPO_VISTO);
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