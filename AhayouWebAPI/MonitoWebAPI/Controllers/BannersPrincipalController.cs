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
    public class BannersPrincipalController : Controller
    {
        

        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        public BannersPrincipalController(IConfiguration configuracion)
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
        public IActionResult ListarBannersPrincipal()
        {
            List<Banners_principal> oRol = new List<Banners_principal>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_BANNER_PRINCIPAL", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("@tipo_operacion", "L");
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Banners_principal()
                        {
                            nro =(string)dr["numero"],
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
