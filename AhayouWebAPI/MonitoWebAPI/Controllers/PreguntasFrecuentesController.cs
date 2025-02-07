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
    public class PreguntasFrecuentesController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public PreguntasFrecuentesController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPreguntasFrecuentes()
        {
            List<Preguntas_frecuentes> oRol = new List<Preguntas_frecuentes>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_PREGUNTAS_FRECUENTES_STR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("@tipo_operacion", "L");
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Preguntas_frecuentes()
                        {
                            pregunta = (string)dr["PREGUNTA"],
                            pregunta_ingles = (string)dr["PREGUNTA_INGLES"],
                            respuesta = (string)dr["RESPUESTA"],
                            respuesta_ingles = (string)dr["RESPUESTA_INGLES"]
                        }).ToList();

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oRol;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oRol;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
