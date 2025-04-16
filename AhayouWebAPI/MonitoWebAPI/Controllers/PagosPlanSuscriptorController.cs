using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using AhayouClases;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosPlanSuscriptorController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public PagosPlanSuscriptorController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
            temporal = "";
        }
        [Route("[action]/{PV_USUARIO}/{PB_CODIGO_PLAN}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PR_REG_DEVUELVE_IDSESION(string PV_USUARIO, Int64 PB_CODIGO_PLAN)
        {
            Login oLogin = new Login();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_REG_DEVUELVE_IDSESION", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_USUARIO", PV_USUARIO);
                comando.Parameters.AddWithValue("@PB_CODIGO_PLAN", PB_CODIGO_PLAN);
                comando.Parameters.Add("@PI_ID", SqlDbType.BigInt, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRespuestaAPI.descripcion = "";
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                if (comando.Parameters["@PI_ID"].Value == null)
                    oRespuestaAPI.resultado = "0";
                else
                    oRespuestaAPI.resultado = comando.Parameters["@PI_ID"].Value.ToString();
                
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = "";
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]/{PI_ID}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PR_SEG_VERIFICA_ESTADO_IDSESION(Int64 PI_ID)
        {
            Login oLogin = new Login();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_SEG_VERIFICA_ESTADO_IDSESION", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PI_ID", PI_ID);
                //comando.Parameters.Add("@PI_ID", SqlDbType.BigInt, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                if (dt.Rows.Count > 0)
                {
                    oLogin = (from DataRow dr in dt.Rows
                              select new Login()
                              {
                                  //id_usuario = (int)dr["id_usuario"],
                                  nombres = (string)dr["estado"],
                                  ////password = (string)dr["password"],
                                  //rol = (string)dr["pv_temporal"],
                                  token = ""
                              }).First();

                }
                oRespuestaAPI.descripcion = "";
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLogin.nombres;

                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = "";
                return BadRequest(oRespuestaAPI);
            }
        }
        [Route("[action]")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR_IDSESION([FromBody] PagoSesiones oPago)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR_IDSESION", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", oPago.PV_TIPO_OPERACION);
                comando.Parameters.AddWithValue("@PB_ID", oPago.PB_ID);
                comando.Parameters.AddWithValue("@PV_DETALLES", oPago.PV_DETALLES);
                comando.Parameters.AddWithValue("@PV_USUARIO", oPago.PV_USUARIO);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oPago.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oPago.PV_ESTADOPR = (string)comando.Parameters["@pv_estadopr"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                {
                    error = "";
                    oPago.PV_ERROR = "";
                }
                else
                {
                    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    oPago.PV_ERROR = (string)comando.Parameters["@pv_error"].Value;
                }

                oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PagosPlanSuscriptor([FromBody] Plan_pagos_suscriptor oPago)
        {
            try
            {
                
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", oPago.PV_TIPO_OPERACION);
                comando.Parameters.AddWithValue("@PV_USUARIO_SUSCRIPTOR", oPago.PV_USUARIO_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PI_CODIGO_PLAN", oPago.PI_CODIGO_PLAN);
                comando.Parameters.AddWithValue("@PV_DETALLES", oPago.PV_DETALLES);
                comando.Parameters.AddWithValue("@PV_USUARIO", oPago.PV_USUARIO);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oPago.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oPago.PV_ESTADOPR = (string)comando.Parameters["@pv_estadopr"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                {
                    error = "";
                    oPago.PV_ERROR = "";
                }
                else
                {
                    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    oPago.PV_ERROR = (string)comando.Parameters["@pv_error"].Value;
                }

                oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
