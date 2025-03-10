using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAhayouAdmin.Clases
{
    public class Contenidos_streaming
    {
        #region Propiedades

        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_CONTENIDO_STR { get; set; }
        public string PV_NOMBRE_CONTENIDO { get; set; }
        public int PI_COD_FORMATO_CONTENIDO { get; set; }
        public string PV_COD_CLASIFIFICACION_CONTENIDO { get; set; }
        public string PV_COD_GENERO { get; set; }
        public string PV_COD_CLASIFICACION_PUBLICO { get; set; }
        public string PV_GESTION { get; set; }
        public string PV_ES_TEMPORADA { get; set; }
        public int PI_TEMPORADAS { get; set; }
        public string PV_TIEMPO_HORA { get; set; }
        public string PV_TIEMPO_MINUTOS { get; set; }
        public string PV_TIPO_AUDIO { get; set; }
        public string PV_STORY_LINE { get; set; }
        public string PV_STORY_LINE_INGLES { get; set; }
        public string PV_SINOPSIS { get; set; }
        public string PV_SINOPSIS_INGLES { get; set; }
        public string PV_DIRECTOR { get; set; }
        public string PV_REPARTO { get; set; }
        public string PV_NACIONALIDAD { get; set; }
        public string PV_IDIOMA_ORIGINAL { get; set; }
        public string PV_ES_SUBTITULADA { get; set; }
        public string PV_CREDITOS { get; set; }
        public string PV_FOTO_VERTICAL { get; set; }
        public string PV_FOTO_MINIATURA { get; set; }
        public string PV_FOTO_HORIZONTAL { get; set; }
        public string PV_TITULO { get; set; }
        public DateTime PD_FECHA_PUBLICACION { get; set; }
        public string PV_ESTADO_CONTENIDO { get; set; }
        public string PV_COD_PRODUCTORA { get; set; }
        public string PV_ES_GRATUITA { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Contenidos_streaming(string pV_COD_CONTENIDO_STR)
        {
            PV_COD_CONTENIDO_STR = pV_COD_CONTENIDO_STR;
            RecuperarDatos();
        }
        public Contenidos_streaming(string pV_TIPO_OPERACION, string pV_COD_CONTENIDO_STR, string pV_NOMBRE_CONTENIDO,
         int pI_COD_FORMATO_CONTENIDO,string pV_COD_CLASIFIFICACION_CONTENIDO,string pV_COD_GENERO, string pV_COD_CLASIFICACION_PUBLICO,
        string pV_GESTION, string pV_ES_TEMPORADA,int pI_TEMPORADAS, string pV_TIEMPO_HORA,string pV_TIEMPO_MINUTOS ,
        string pV_TIPO_AUDIO, string pV_STORY_LINE, string pV_STORY_LINE_INGLES, string pV_SINOPSIS, string pV_SINOPSIS_INGLES,
        string pV_DIRECTOR, string pV_REPARTO, string pV_NACIONALIDAD, string pV_IDIOMA_ORIGINAL, string pV_ES_SUBTITULADA,
        string pV_CREDITOS, string pV_FOTO_VERTICAL, string pV_FOTO_MINIATURA, string pV_FOTO_HORIZONTAL, string pV_TITULO,
         DateTime pD_FECHA_PUBLICACION , string pV_ESTADO_CONTENIDO, string pV_COD_PRODUCTORA, string pV_ES_GRATUITA,
        string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_CONTENIDO_STR = pV_COD_CONTENIDO_STR;
            PV_NOMBRE_CONTENIDO = pV_NOMBRE_CONTENIDO;
            PI_COD_FORMATO_CONTENIDO = pI_COD_FORMATO_CONTENIDO;
            PV_COD_CLASIFIFICACION_CONTENIDO = pV_COD_CLASIFIFICACION_CONTENIDO;
            PV_COD_GENERO = pV_COD_GENERO;
            PV_COD_CLASIFICACION_PUBLICO = pV_COD_CLASIFICACION_PUBLICO;
            PV_GESTION = pV_GESTION;
            PV_ES_TEMPORADA = pV_ES_TEMPORADA;
            PI_TEMPORADAS = pI_TEMPORADAS;
            PV_TIEMPO_HORA = pV_TIEMPO_HORA;
            PV_TIEMPO_MINUTOS = pV_TIEMPO_MINUTOS;
            PV_TIPO_AUDIO = pV_TIPO_AUDIO;
            PV_STORY_LINE = pV_STORY_LINE;
            PV_STORY_LINE_INGLES = pV_STORY_LINE_INGLES;
            PV_SINOPSIS = pV_SINOPSIS;
            PV_SINOPSIS_INGLES = pV_SINOPSIS_INGLES;
            PV_DIRECTOR = pV_DIRECTOR;
            PV_REPARTO = pV_REPARTO;
            PV_NACIONALIDAD = pV_NACIONALIDAD;
            PV_IDIOMA_ORIGINAL = pV_IDIOMA_ORIGINAL;
            PV_ES_SUBTITULADA = pV_ES_SUBTITULADA;
            PV_CREDITOS = pV_CREDITOS;
            PV_FOTO_VERTICAL = pV_FOTO_VERTICAL;
            PV_FOTO_MINIATURA = pV_FOTO_MINIATURA;
            PV_FOTO_HORIZONTAL = pV_FOTO_HORIZONTAL;
            PV_TITULO = pV_TITULO;
            PD_FECHA_PUBLICACION = pD_FECHA_PUBLICACION;
            PV_ESTADO_CONTENIDO = pV_ESTADO_CONTENIDO;
            PV_COD_PRODUCTORA = pV_COD_PRODUCTORA;
            PV_ES_GRATUITA = pV_ES_GRATUITA;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_STR_GET_CONTENIDO_STR()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_STR";
                    //if (PV_ESTADO == "T")
                    //    cmd.Parameters.Add("PV_ESTADO", null);
                    //else
                    //    cmd.Parameters.Add("PV_ESTADO", PV_ESTADO);
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
                    cmd.CommandText = "PR_STR_GET_CONTENIDO_STR_IND";
                    cmd.Parameters.AddWithValue("PV_COD_CONTENIDO_STR", PV_COD_CONTENIDO_STR);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            //PB_AVATAR = (string)dr["AVATAR"];
                            PV_NOMBRE_CONTENIDO = (string)dr["nombre_contenido"];
                            PI_COD_FORMATO_CONTENIDO = int.Parse(dr["cod_formato_contenido"].ToString());
                            PV_COD_CLASIFIFICACION_CONTENIDO = (string)dr["cod_clasifificacion_contenido"];
                            PV_COD_GENERO = (string)dr["cod_genero"];
                            PV_COD_CLASIFICACION_PUBLICO = (string)dr["cod_clasificacion_publico"];
                            PV_GESTION = (string)dr["gestion"];
                            PV_ES_TEMPORADA = (string)dr["es_temporada"];
                            PI_TEMPORADAS = int.Parse(dr["temporadas"].ToString());
                            PV_TIEMPO_HORA = (string)dr["tiempo_hora"];
                            PV_TIEMPO_MINUTOS = (string)dr["tiempo_minutos"];
                            PV_TIPO_AUDIO = (string)dr["cod_tipo_audio"];
                            PV_STORY_LINE = (string)dr["story_line"];
                            PV_STORY_LINE_INGLES = (string)dr["story_line_ingles"];
                            PV_SINOPSIS = (string)dr["sinopsis"];
                            PV_SINOPSIS_INGLES = (string)dr["sinopsis_ingles"];
                            PV_DIRECTOR = (string)dr["director"];
                            PV_REPARTO = (string)dr["reparto"];
                            PV_NACIONALIDAD = (string)dr["cod_nacionalidad"];
                            PV_IDIOMA_ORIGINAL = (string)dr["cod_idioma_original"];
                            PV_ES_SUBTITULADA = (string)dr["es_subtitulada"];
                            PV_CREDITOS = (string)dr["creditos"];
                            PV_FOTO_VERTICAL = (string)dr["foto_vertical"];
                            PV_FOTO_HORIZONTAL = (string)dr["foto_horizontal"];
                            PV_FOTO_MINIATURA = (string)dr["foto_miniatura"];
                            PV_TITULO = (string)dr["titulo"];
                            PD_FECHA_PUBLICACION = DateTime.Parse( dr["fecha_publicacion"].ToString());
                            PV_ESTADO_CONTENIDO = (string)dr["cod_estado_contenido"];
                            PV_COD_PRODUCTORA= (string)dr["cod_productora"];
                            PV_ES_GRATUITA= (string)dr["es_gratuita"];
                            
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
                    cmd.CommandText = "PR_PAR_ABM_AVATARES";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    cmd.Parameters.AddWithValue("PI_COD_FORMATO_CONTENIDO", PI_COD_FORMATO_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_COD_CLASIFIFICACION_CONTENIDO", PV_COD_CLASIFIFICACION_CONTENIDO);
                    cmd.Parameters.AddWithValue("@PV_COD_CLASIFICACION_PUBLICO", @PV_COD_CLASIFICACION_PUBLICO);
                    cmd.Parameters.AddWithValue("PV_GESTION", PV_GESTION);
                    cmd.Parameters.AddWithValue("PV_ES_TEMPORADA", PV_ES_TEMPORADA);
                    cmd.Parameters.AddWithValue("PI_TEMPORADAS", PI_TEMPORADAS);
                    cmd.Parameters.AddWithValue("PV_TIEMPO_HORA", PV_TIEMPO_HORA);
                    cmd.Parameters.AddWithValue("PV_TIEMPO_MINUTOS", PV_TIEMPO_MINUTOS);
                    cmd.Parameters.AddWithValue("PV_TIPO_AUDIO", PV_TIPO_AUDIO);
                    cmd.Parameters.AddWithValue("PV_STORY_LINE", PV_STORY_LINE);
                    cmd.Parameters.AddWithValue("PV_STORY_LINE_INGLES", PV_STORY_LINE_INGLES);
                    cmd.Parameters.AddWithValue("PV_SINOPSIS", PV_SINOPSIS);
                    cmd.Parameters.AddWithValue("PV_SINOPSIS_INGLES", PV_SINOPSIS_INGLES);
                    cmd.Parameters.AddWithValue("PV_DIRECTOR", PV_DIRECTOR);
                    cmd.Parameters.AddWithValue("PV_REPARTO", PV_REPARTO);
                    cmd.Parameters.AddWithValue("PV_NACIONALIDAD", PV_NACIONALIDAD);
                    cmd.Parameters.AddWithValue("PV_IDIOMA_ORIGINAL", PV_IDIOMA_ORIGINAL);
                    cmd.Parameters.AddWithValue("PV_ES_SUBTITULADA", PV_ES_SUBTITULADA);
                    cmd.Parameters.AddWithValue("PV_CREDITOS", PV_CREDITOS);
                    cmd.Parameters.AddWithValue("PV_FOTO_VERTICAL", PV_FOTO_VERTICAL);
                    cmd.Parameters.AddWithValue("PV_FOTO_MINIATURA", PV_FOTO_MINIATURA);
                    cmd.Parameters.AddWithValue("PV_FOTO_HORIZONTAL", PV_FOTO_HORIZONTAL);
                    cmd.Parameters.AddWithValue("PV_TITULO", PV_TITULO);
                    cmd.Parameters.AddWithValue("PD_FECHA_PUBLICACION", PD_FECHA_PUBLICACION);
                    cmd.Parameters.AddWithValue("PV_ESTADO_CONTENIDO", PV_ESTADO_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_COD_PRODUCTORA", PV_COD_PRODUCTORA);
                    cmd.Parameters.AddWithValue("PV_ES_GRATUITA", PV_ES_GRATUITA);
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