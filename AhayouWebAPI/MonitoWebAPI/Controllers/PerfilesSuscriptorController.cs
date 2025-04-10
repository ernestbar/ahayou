using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AhayouClases;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesSuscriptorController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string llaveSecreta;

        public PerfilesSuscriptorController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{PV_COD_PLAN_SUSCRIPTOR}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PerfilesSuscriptor(string PV_COD_PLAN_SUSCRIPTOR)
        {
            List<Perfiles_suscriptor> oUsuario = new List<Perfiles_suscriptor>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_PERFILES_SUSCRIPTOR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Perfiles_suscriptor()
                            {
                                cod_perfil_suscriptor = (string)dr["cod_perfil_suscriptor"],
                                nombre_perfil = (string)dr["nombre_perfil"],
                                codigo_avatar = (string)dr["codigo_avatar"],
                                pin = (Int64)dr["pin"],
                                avatar = (string)dr["avatar"]
                            }).ToList();


                //if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                //    error = "";
                //else
                //    error = (string)comando.Parameters["@PV_ERROR"].Value;
                //oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oUsuario;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oUsuario;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdecuarDatosPerfilSuscriptor([FromBody] Perfiles_suscriptor oUsuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errores = (from state in ModelState.Values
                                   from error in state.Errors
                                   select error.ErrorMessage).ToList();

                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = false;
                    oRespuestaAPI.mensajesError = errores;
                    oRespuestaAPI.resultado = oUsuario;
                    return Ok(oRespuestaAPI);
                }

                string id = oUsuario.cod_perfil_suscriptor;
                string operacion = id == "" ? "I" : "U";

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_ABM_PERFIL_SUSCRIPTOR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pv_tipo_operacion", oUsuario.pv_tipo_operacion);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", oUsuario.cod_perfil_suscriptor);
                comando.Parameters.AddWithValue("@PV_NOMBRE_PERFIL", oUsuario.nombre_perfil);
                comando.Parameters.AddWithValue("@PV_CODIGO_AVATAR", oUsuario.codigo_avatar);
                comando.Parameters.AddWithValue("@PI_PIN", oUsuario.pin);
                comando.Parameters.AddWithValue("@PV_USUARIO", oUsuario.usuario);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oUsuario.pv_descripcionpr = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oUsuario.pv_estadopr = (string)comando.Parameters["@pv_estadopr"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                {
                    error = "";
                    oUsuario.pv_error = "";
                }
                else
                {
                    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    oUsuario.pv_error = (string)comando.Parameters["@pv_error"].Value;
                }

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oUsuario;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oUsuario;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
