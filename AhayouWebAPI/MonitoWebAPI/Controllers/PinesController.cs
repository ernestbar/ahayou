using AhayouClases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinesController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public PinesController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CambioPin([FromBody] Pines oUsuario)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    var errores = (from state in ModelState.Values
                //                   from error in state.Errors
                //                   select error.ErrorMessage).ToList();

                //    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                //    oRespuestaAPI.exitoso = false;
                //    oRespuestaAPI.mensajesError = errores;
                //    oRespuestaAPI.resultado = oUsuario;
                //    return Ok(oRespuestaAPI);
                //}

                

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_ABM_CAMBIO_PIN", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", oUsuario.PV_TIPO_OPERACION);
                comando.Parameters.AddWithValue("@PV_USUARIO_STR", oUsuario.PV_USUARIO_STR);
                comando.Parameters.AddWithValue("@PV_USUARIO", oUsuario.PV_USUARIO);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PB_PIN", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oUsuario.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                oUsuario.PV_ESTADOPR = (string)comando.Parameters["@PV_ESTADOPR"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@PV_ERROR"].Value.ToString()))
                {
                    error = "";
                    oUsuario.PV_ERROR = "";
                }
                else
                {
                    error = (string)comando.Parameters["@PV_ERROR"].Value;
                    oUsuario.PV_ERROR = (string)comando.Parameters["@pv_error"].Value;
                }

                if (string.IsNullOrEmpty(comando.Parameters["@PB_PIN"].Value.ToString()))
                {
                    oUsuario.PB_PIN = "0";
                }
                else
                {
                    oUsuario.PB_PIN = (string)comando.Parameters["@PB_PIN"].Value;
                }


                oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
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
