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
    public class ObtenerStreamingController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        public ObtenerStreamingController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{PV_COD_CONTENIDO_STR}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ObtenerStreaming(Int64 PV_COD_CONTENIDO_STR)
        {
            List<Obtener_streamings> oRol = new List<Obtener_streamings>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_CONTENIDO_CONTENIDO", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_COD_CONTENIDO_STR", PV_COD_CONTENIDO_STR);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Obtener_streamings()
                        {
                            nombre_contenido = dr["nombre_contenido"] == DBNull.Value ? "" : (string)dr["nombre_contenido"],
                            temporada = dr["temporada"] == DBNull.Value ? 0 : (Int32)dr["temporada"],
                            episodio = dr["episodio"] == DBNull.Value ? 0 : (Int32)dr["episodio"],
                            tiempo_contenido = dr["tiempo_contenido"] == DBNull.Value ? "" : (string)dr["tiempo_contenido"],
                            story_line = dr["story_line"] == DBNull.Value ? "" : (string)dr["story_line"],
                            story_line_ingles = dr["story_line_ingles"] == DBNull.Value ? "" : (string)dr["story_line_ingles"],
                            sinopsis = dr["sinopsis"] == DBNull.Value ? "" : (string)dr["sinopsis"],
                            sinopsis_ingles = dr["sinopsis_ingles"] == DBNull.Value ? "" : (string)dr["sinopsis_ingles"],
                            contenido = dr["contenido_mobile"] == DBNull.Value ? "" : (string)dr["contenido_mobile"],
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
