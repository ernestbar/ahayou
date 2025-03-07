using AhayouClases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenidosVistosController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string llaveSecreta;

        public ContenidosVistosController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{PV_USUARIO}/{PV_COD_PLAN_SUSCRIPTOR}/{PV_COD_PERFIL_SUSCRIPTOR}/{PI_MENU}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContenidosVistos(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR,string PV_COD_PERFIL_SUSCRIPTOR,int PI_MENU)
        {
            List<Contenidos_vistos> oUsuario = new List<Contenidos_vistos>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_VISTOS", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_USUARIO", PV_USUARIO);
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PI_MENU", PI_MENU);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Contenidos_vistos()
                            {
                                formato_contenido = (string)dr["formato_contenido"],
                                formato_contenido_ingles = (string)dr["formato_contenido_ingles"],
                                cod_contenido_str = (string)dr["cod_contenido_str"],
                                nombre_contenido = (string)dr["nombre_contenido"],
                                contenido_miniatura = (string)dr["contenido_miniatura"],
                                contenido_vertical = (string)dr["contenido_vertical"],
                                contenido_horizontal = (string)dr["contenido_horizontal"],
                                es_gratuita = (string)dr["es_gratuita"]
                            }).ToList();

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
        [Route("[action]/{PV_USUARIO}/{PV_COD_PLAN_SUSCRIPTOR}/{PV_COD_PERFIL_SUSCRIPTOR}/{PI_MENU}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContenidosSeguirViendo(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, int PI_MENU)
        {
            List<Contenidos_vistos> oUsuario = new List<Contenidos_vistos>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_SEGUIR_VIENDO", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_USUARIO", PV_USUARIO);
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PI_MENU", PI_MENU);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Contenidos_vistos()
                            {
                                formato_contenido = (string)dr["formato_contenido"],
                                formato_contenido_ingles = (string)dr["formato_contenido_ingles"],
                                cod_contenido_str = (string)dr["cod_contenido_str"],
                                nombre_contenido = (string)dr["nombre_contenido"],
                                contenido_miniatura = (string)dr["contenido_miniatura"],
                                contenido_vertical = (string)dr["contenido_vertical"],
                                contenido_horizontal = (string)dr["contenido_horizontal"],
                                es_gratuita = (string)dr["es_gratuita"],
                                tiempo_visto = (string)dr["tiempo_visto"]
                            }).ToList();

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
        [Route("[action]/{PV_USUARIO}/{PV_COD_PLAN_SUSCRIPTOR}/{PV_COD_PERFIL_SUSCRIPTOR}/{PI_MENU}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContenidosFavoritos(string PV_USUARIO, string PV_COD_PLAN_SUSCRIPTOR, string PV_COD_PERFIL_SUSCRIPTOR, int PI_MENU)
        {
            List<Contenidos_vistos> oUsuario = new List<Contenidos_vistos>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_FAVORITOS", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_USUARIO", PV_USUARIO);
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PI_MENU", PI_MENU);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Contenidos_vistos()
                            {
                                formato_contenido = (string)dr["formato_contenido"],
                                formato_contenido_ingles = (string)dr["formato_contenido_ingles"],
                                cod_contenido_str = (string)dr["cod_contenido_str"],
                                nombre_contenido = (string)dr["nombre_contenido"],
                                contenido_miniatura = (string)dr["contenido_miniatura"],
                                contenido_vertical = (string)dr["contenido_vertical"],
                                contenido_horizontal = (string)dr["contenido_horizontal"],
                                es_gratuita = (string)dr["es_gratuita"],
                            }).ToList();

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
    }
}
