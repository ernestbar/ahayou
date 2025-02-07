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
    public class AvataresController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public AvataresController(IConfiguration configuracion)
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
        public IActionResult ListaAvatares()
        {
            List<Avatares> oRol = new List<Avatares>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_AVATARES", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("@tipo_operacion", "L");
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Avatares()
                        {
                            codigo_avatar = (string)dr["codigo_avatar"],
                            avatar = (string)dr["avatar"]
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
