﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAhayouAdmin.Clases
{
    public class Contenidos
    {
        #region Propiedades


        //Propiedades públicas
        public string PV_TIPO_OPERACION { get; set; }
        public string PV_COD_CONTENIDO { get; set; }
        public string PV_DESCRIPCION { get; set; }
        public string PV_CONTENIDO { get; set; }
        public string PV_CONTENIDO_INGLES { get; set; }
        public string PV_USUARIO { get; set; }
        public string PV_ESTADOPR { get; set; }
        public string PV_DESCRIPCIONPR { get; set; }
        public string PV_ERROR { get; set; }

        #endregion
        #region Constructores
        public Contenidos(string pV_COD_CONTENIDO)
        {
            PV_COD_CONTENIDO = pV_COD_CONTENIDO;
            RecuperarDatos();
        }
        public Contenidos(string pV_TIPO_OPERACION, string pV_COD_CONTENIDO,
            string pV_DESCRIPCION, string pV_CONTENIDO, string pV_CONTENIDO_INGLES, string pV_USUARIO)
        {
            PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            PV_COD_CONTENIDO = pV_COD_CONTENIDO;
            PV_DESCRIPCION = pV_DESCRIPCION;
            PV_CONTENIDO = pV_CONTENIDO;
            PV_CONTENIDO_INGLES = pV_CONTENIDO_INGLES;
            PV_USUARIO = pV_USUARIO;
        }
        #endregion
        #region Métodos que NO requieren constructor
        public static DataTable PR_PAR_GET_CONTENIDOS()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_PAR_GET_CONTENIDOS";
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
        //public static DataTable PR_SEG_GET_CONTENIDOES_ACTIVOS()
        //{
        //    try
        //    {
        //        DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CONTENIDOES_ACTIVOS");
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
                    cmd.CommandText = "PR_PAR_GET_CONTENIDOS_IND";
                    cmd.Parameters.AddWithValue("PV_CODIGO_CONTENIDO", PV_COD_CONTENIDO);
                    cmd.Connection = conn;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (String.IsNullOrEmpty(dr["DESCRIPCION"].ToString()))
                                PV_DESCRIPCION = "";
                            else
                                PV_DESCRIPCION = (string)dr["DESCRIPCION"];
                            if (String.IsNullOrEmpty(dr["CONTENIDO"].ToString()))
                                PV_CONTENIDO = "";
                            else
                                PV_CONTENIDO = (string)dr["CONTENIDO"];
                            if (String.IsNullOrEmpty(dr["CONTENIDO_INGLES"].ToString()))
                                PV_CONTENIDO_INGLES = "";
                            else
                                PV_CONTENIDO_INGLES = (string)dr["CONTENIDO_INGLES"];
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
                    cmd.CommandText = "PR_PAR_ABM_CONTENIDOS";
                    cmd.Parameters.AddWithValue("PV_TIPO_OPERACION", PV_TIPO_OPERACION);
                    if (PV_CONTENIDO == "")
                        cmd.Parameters.AddWithValue("PV_COD_CONTENIDO", "");
                    else
                        cmd.Parameters.AddWithValue("PV_COD_CONTENIDO", PV_COD_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO", PV_CONTENIDO);
                    cmd.Parameters.AddWithValue("PV_CONTENIDO_INGLES", PV_CONTENIDO_INGLES);
                    cmd.Parameters.AddWithValue("PV_DESCRIPCION", PV_DESCRIPCION);
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