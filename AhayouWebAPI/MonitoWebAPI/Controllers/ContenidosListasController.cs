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
    public class ContenidosListasController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public ContenidosListasController(IConfiguration configuracion)
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
        public IActionResult OperacionesContenidosLista([FromBody] Contenido_listas oUsuario)
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

                //string id = oUsuario.pv_usuarioi;
                //string operacion = id == "" ? "I" : "U";

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_ABM_CONTENIDO_LISTA", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_TIPO_OPERACION", oUsuario.PV_TIPO_OPERACION);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", oUsuario.PV_COD_PERFIL_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", oUsuario.PV_COD_PLAN_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_USUARIO_STR", oUsuario.PV_USUARIO_STR);
                comando.Parameters.AddWithValue("@PI_CODIGO_PLAN", oUsuario.PI_CODIGO_PLAN);
                comando.Parameters.AddWithValue("@PV_COD_CONTENIDO_STR", oUsuario.PV_COD_CONTENIDO_STR);
                comando.Parameters.AddWithValue("@PV_TIEMPO_VISTO", oUsuario.PV_TIEMPO_VISTO);
                comando.Parameters.AddWithValue("@PV_USUARIO", oUsuario.PV_USUARIO);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_EMAILOUT", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oUsuario.PV_DESCRIPCIONPR = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@error"].Value.ToString()))
                    error = "";
                else
                    error = (string)comando.Parameters["@error"].Value;

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
