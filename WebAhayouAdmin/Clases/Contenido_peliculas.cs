using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Contenido_peliculas
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }

        public int PI_COD_CONTENIDO_PELICULA { get; set; }
        public string PV_COD_CONTENIDO_STR { get; set; }
        public string PV_NOMBRE_CONTENIDO_STR { get; set; }
        public string PV_CONTENIDO { get; set; }
        public string PV_CONTENIDO_MOBILE { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Contenido_peliculas(int pI_COD_CONTENIDO_PELICULA)
        {
            PI_COD_CONTENIDO_PELICULA = pI_COD_CONTENIDO_PELICULA;
            RecuperarDatos();
        }
        public Contenido_peliculas(string pV_TIPO_OPERACION, int pI_COD_CONTENIDO_PELICULA,
         string pV_COD_CONTENIDO_STR, string pV_NOMBRE_CONTENIDO_STR,string pV_CONTENIDO, string pV_USUARIO, string pV_CONTENIDO_MOBILE)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PI_COD_CONTENIDO_PELICULA = pI_COD_CONTENIDO_PELICULA;
            PV_COD_CONTENIDO_STR = pV_COD_CONTENIDO_STR;
            PV_NOMBRE_CONTENIDO_STR = pV_NOMBRE_CONTENIDO_STR;
            PV_CONTENIDO = pV_CONTENIDO;
            PV_USUARIO = pV_USUARIO;
            PV_CONTENIDO_MOBILE = pV_CONTENIDO_MOBILE;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_STR_GET_CONTENIDO_PELICULA(string pV_COD_CONTENIDO_STR)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_PELICULA";
                    cmd.Parameters.AddWithValue("PV_COD_CONTENIDO_STR", pV_COD_CONTENIDO_STR);
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
        //public static DataTable PR_SEG_GET_ROLES_ACTIVOS()
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_ROLES_ACTIVOS");
        //        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //        return db1.ExecuteDataSet(cmd).Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //        DataTable dt = new DataTable();
        //        return dt;
        //    }

        //}



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
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_PELICULA_IND";
                    cmd.Parameters.AddWithValue("PI_COD_CONTENIDO_PELICULA", PI_COD_CONTENIDO_PELICULA);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            PV_COD_CONTENIDO_STR = (string)dr["cod_contenido_str"];
                            PV_NOMBRE_CONTENIDO_STR = (string)dr["nombre_contenido_str"];
                            PV_CONTENIDO = (string)dr["contenido"];
                            PV_CONTENIDO_MOBILE= (string)dr["contenido_mobile"];
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
                    cmd.CommandText = "PR_STR_ABM_CONTENIDO_PELICULA";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PI_COD_CONTENIDO_PELICULA", PI_COD_CONTENIDO_PELICULA);
                    cmd.Parameters.AddWithValue("PV_COD_CONTENIDO_STR", PV_COD_CONTENIDO_STR);
                    cmd.Parameters.AddWithValue("PV_NOMBRE_CONTENIDO_STR", PV_NOMBRE_CONTENIDO_STR);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO", PV_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO_MOBILE", PV_CONTENIDO_MOBILE);
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