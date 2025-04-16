using AhayouClases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoStripeController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public ResultadoStripeController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{json_stripe}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RespuestaStripe2(string json_stripe)
        {
            Login oLogin = new Login();
            try
            {
                RespuestaStripes RespStripe = JsonConvert.DeserializeObject<RespuestaStripes>(json_stripe);
                if (RespStripe.data.@object.payment_status == "paid")
                {
                    SqlConnection conexion = new SqlConnection(CadenaConexion);
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", "I");
                    comando.Parameters.AddWithValue("@PV_USUARIO_SUSCRIPTOR", "");
                    comando.Parameters.AddWithValue("@PI_CODIGO_PLAN", "");
                    comando.Parameters.AddWithValue("@PV_DETALLES", "");
                    comando.Parameters.AddWithValue("@PV_USUARIO", "ADM");
                    comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    //oPago.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                    //oPago.PV_ESTADOPR = (string)comando.Parameters["@pv_estadopr"].Value;
                    //if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                    //{
                    //    error = "";
                    //    oPago.PV_ERROR = "";
                    //}
                    //else
                    //{
                    //    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    //    oPago.PV_ERROR = (string)comando.Parameters["@pv_error"].Value;
                    //}

                    oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = true;
                    oRespuestaAPI.mensajesError = new List<string>() { error };
                    oRespuestaAPI.resultado = (string)comando.Parameters["@PV_ESTADOPR"].Value;
                }
                else
                {
                    oRespuestaAPI.descripcion = "No se realizo el pago, estado:" + RespStripe.data.@object.payment_status;
                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = false;
                    oRespuestaAPI.mensajesError = new List<string>() { error };
                    oRespuestaAPI.resultado = RespStripe.data.@object.payment_status;
                }

                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLogin;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RespuestaStripe([FromBody] Firebase oUsuario)
        {
            try
            {
                string datos = oUsuario.resultado;
                var RespStripe = JsonConvert.DeserializeObject<RespuestaStripes>(oUsuario.resultado);
                if (RespStripe.data.@object.payment_status == "paid")
                {
                    SqlConnection conexion = new SqlConnection(CadenaConexion);
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", "I");
                    comando.Parameters.AddWithValue("@PV_USUARIO_SUSCRIPTOR", "");
                    comando.Parameters.AddWithValue("@PI_CODIGO_PLAN", "");
                    comando.Parameters.AddWithValue("@PV_DETALLES", "");
                    comando.Parameters.AddWithValue("@PV_USUARIO", "ADM");
                    comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    //oPago.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                    //oPago.PV_ESTADOPR = (string)comando.Parameters["@pv_estadopr"].Value;
                    //if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                    //{
                    //    error = "";
                    //    oPago.PV_ERROR = "";
                    //}
                    //else
                    //{
                    //    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    //    oPago.PV_ERROR = (string)comando.Parameters["@pv_error"].Value;
                    //}

                    oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = true;
                    oRespuestaAPI.mensajesError = new List<string>() { error };
                    oRespuestaAPI.resultado = (string)comando.Parameters["@PV_ESTADOPR"].Value; 
                }
                else
                {
                    oRespuestaAPI.descripcion = "No se realizo el pago, estado:"+ RespStripe.data.@object.payment_status;
                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = false;
                    oRespuestaAPI.mensajesError = new List<string>() { error };
                    oRespuestaAPI.resultado = RespStripe.data.@object.payment_status;
                }

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
