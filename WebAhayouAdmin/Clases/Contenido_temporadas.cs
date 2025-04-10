using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAhayouAdmin.Clases
{
    public class Contenido_temporadas
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }

        public int PI_COD_CONTENIDO_TEMPORADAS { get; set; }
        public string PV_COD_CONTENIDO_STR { get; set; }
        public int PI_ORDEN { get; set; }
        public int PI_TEMPORADA { get; set; }
        public int PI_EPISODIO { get; set; }
        public string PV_TIEMPO_HORA { get; set; }
        public string PV_TIEMPO_MINUTOS { get; set; }
        public string PV_STORY_LINE { get; set; }
        public string PV_SINOPSIS { get; set; }
        public string PV_STORY_LINE_INGLES { get; set; }
        public string PV_SINOPSIS_INGLES { get; set; }
        public string PV_CONTENIDO { get; set; }
        public string PV_CONTENIDO_MOBILE { get; set; }
        public string PV_CONTENIDO_PLAYLIST { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Contenido_temporadas(int pI_COD_CONTENIDO_TEMPORADAS)
        {
            PI_COD_CONTENIDO_TEMPORADAS = pI_COD_CONTENIDO_TEMPORADAS;
            RecuperarDatos();
        }
        public Contenido_temporadas(string pV_TIPO_OPERACION,  int pI_COD_CONTENIDO_TEMPORADAS ,
         string pV_COD_CONTENIDO_STR, int pI_ORDEN,  int pI_TEMPORADA, int pI_EPISODIO,
        string pV_TIEMPO_HORA, string pV_TIEMPO_MINUTOS, string pV_STORY_LINE, string pV_SINOPSIS,
        string pV_STORY_LINE_INGLES, string pV_SINOPSIS_INGLES,string pV_CONTENIDO, string pV_USUARIO,string pV_CONTENIDO_MOBILE,string pV_CONTENIDO_PLAYLIST)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PI_COD_CONTENIDO_TEMPORADAS = pI_COD_CONTENIDO_TEMPORADAS;
            PV_COD_CONTENIDO_STR = pV_COD_CONTENIDO_STR;
            PI_ORDEN = pI_ORDEN;
            PI_TEMPORADA = pI_TEMPORADA;
            PI_EPISODIO = pI_EPISODIO;
            PV_TIEMPO_HORA = pV_TIEMPO_HORA;
            PV_TIEMPO_MINUTOS = pV_TIEMPO_MINUTOS;
            PV_STORY_LINE = pV_STORY_LINE;
            PV_SINOPSIS = pV_SINOPSIS;
            PV_STORY_LINE_INGLES = pV_STORY_LINE_INGLES;
            PV_SINOPSIS_INGLES = pV_SINOPSIS_INGLES;
            PV_CONTENIDO = pV_CONTENIDO;
            PV_CONTENIDO_MOBILE = pV_CONTENIDO_MOBILE;
            PV_CONTENIDO_PLAYLIST = pV_CONTENIDO_PLAYLIST;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_STR_GET_CONTENIDO_TEMPORADAS(string pV_COD_CONTENIDO_STR)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_TEMPORADAS";
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
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_TEMPORADAS_IND";
                    cmd.Parameters.AddWithValue("PI_COD_CONTENIDO_TEMPORADAS", PI_COD_CONTENIDO_TEMPORADAS);
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
                            PI_ORDEN = int.Parse(dr["orden"].ToString());
                            PI_TEMPORADA = int.Parse(dr["temporada"].ToString());
                            PI_EPISODIO = int.Parse(dr["episodio"].ToString());
                            PV_TIEMPO_HORA = (string)dr["tiempo_hora"];
                            PV_TIEMPO_MINUTOS = (string)dr["tiempo_minutos"];
                            PV_STORY_LINE = (string)dr["story_line"];
                            PV_STORY_LINE_INGLES = (string)dr["story_line_ingles"];
                            PV_SINOPSIS = (string)dr["sinopsis"];
                            PV_SINOPSIS_INGLES = (string)dr["sinopsis_ingles"];
                            if (string.IsNullOrEmpty(dr["contenido"].ToString()))
                                PV_CONTENIDO = "";
                            else
                                PV_CONTENIDO = (string)dr["contenido"];
                            if (string.IsNullOrEmpty(dr["contenido_mobile"].ToString()))
                                PV_CONTENIDO_MOBILE = "";
                            else
                                PV_CONTENIDO_MOBILE = (string)dr["contenido_mobile"];
                            if (string.IsNullOrEmpty(dr["contenido_playlist"].ToString()))
                                PV_CONTENIDO_PLAYLIST = "";
                            else
                                PV_CONTENIDO_PLAYLIST = (string)dr["contenido_playlist"];
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
                    cmd.CommandText = "PR_STR_ABM_CONTENIDO_TEMPORADA";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PI_COD_CONTENIDO_TEMPORADAS", PI_COD_CONTENIDO_TEMPORADAS);
                    cmd.Parameters.AddWithValue("PV_COD_CONTENIDO_STR", PV_COD_CONTENIDO_STR);
                    cmd.Parameters.AddWithValue("PI_ORDEN", PI_ORDEN);
                    cmd.Parameters.AddWithValue("PI_TEMPORADA", PI_TEMPORADA);
                    cmd.Parameters.AddWithValue("PI_EPISODIO", PI_EPISODIO);
                    cmd.Parameters.AddWithValue("PV_TIEMPO_HORA", PV_TIEMPO_HORA);
                    cmd.Parameters.AddWithValue("PV_TIEMPO_MINUTOS", PV_TIEMPO_MINUTOS);
                    cmd.Parameters.AddWithValue("PV_STORY_LINE", PV_STORY_LINE);
                    cmd.Parameters.AddWithValue("PV_SINOPSIS", PV_SINOPSIS);
                    cmd.Parameters.AddWithValue("PV_STORY_LINE_INGLES", PV_STORY_LINE_INGLES);
                    cmd.Parameters.AddWithValue("PV_SINOPSIS_INGLES", PV_SINOPSIS_INGLES);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO", PV_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO_MOBILE", PV_CONTENIDO_MOBILE);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO_PLAYLIST", PV_CONTENIDO_PLAYLIST);
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