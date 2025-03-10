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
    public class ListasContenidoController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        public ListasContenidoController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{pv_cod_formato_contenido}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListasContenidos(Int64 pv_cod_formato_contenido)
        {
            List<Listas_contenidos> oRol = new List<Listas_contenidos>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_LISTA_CONTENIDO", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pv_cod_formato_contenido", pv_cod_formato_contenido);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Listas_contenidos()
                        {
                            cod_contenido_str = (Int64)dr["cod_contenido_str"],
                            nombre_contenido = (string)dr["nombre_contenido"],
                            formato_contenido = (string)dr["formato_contenido"],
                            formato_contenido_ingles = (string)dr["formato_contenido_ingles"],
                            nombre_foto_titulo = (string)dr["nombre"],
                            detalle1 = (string)dr["detalle1"],
                            detalle1_ingles = (string)dr["detalle1_ingles"],
                            detalle2 = (string)dr["detalle2"],
                            detalle2_ingles = (string)dr["detalle2_ingles"],
                            resumen = (string)dr["resumen"],
                            resumen_ingles = (string)dr["resumen_ingles"],
                            genero = (string)dr["genero"],
                            genero_ingles = (string)dr["genero_ingles"],
                            contenido_url_foto_horizontal = (string)dr["contenido"],
                            contenido_url_foto_vertical = (string)dr["contenido_vertical"],
                            contenido_url_foto_miniatura = (string)dr["contenido_miniatura"],
                            sinopsis = (string)dr["sinopsis"],
                            sinopsis_ingles = (string)dr["sinopsis_ingles"],
                            tiempo_contenido = dr["tiempo_contenido"] == DBNull.Value ? "" : (string)dr["tiempo_contenido"],
                            director = (string)dr["director"],
                            reparto = dr["reparto"] == DBNull.Value ? "" : (string)dr["reparto"],
                            creditos = dr["creditos"] == DBNull.Value ? "" : (string)dr["creditos"],
                            nacionalidad = (string)dr["nacionalidad"],
                            nacionalidad_ingles = (string)dr["nacionalidad_ingles"],
                            idioma_original = (string)dr["idioma_original"],
                            idioma_original_ingles = (string)dr["idioma_original_ingles"],
                            es_subtitulada = (string)dr["es_subtitulada"],
                            es_gratuita = (string)dr["es_gratuita"],
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
