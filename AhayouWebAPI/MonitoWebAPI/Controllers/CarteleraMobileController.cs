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
    public class CarteleraMobileController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public CarteleraMobileController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{PV_USUARIO}/{PV_COD_PLAN_SUSCRIPTOR}/{PV_COD_PERFIL_SUSCRIPTOR}/{PI_MENU}/{PV_SECCION}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarRedes(string PV_USUARIO,string PV_COD_PLAN_SUSCRIPTOR,string PV_COD_PERFIL_SUSCRIPTOR,int PI_MENU,string PV_SECCION)
        {
            List<Cartelera_mobile> oRol = new List<Cartelera_mobile>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_STR_GET_VER_CARTELERA_MOBILE", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PV_USUARIO", PV_USUARIO);
                comando.Parameters.AddWithValue("@PV_COD_PLAN_SUSCRIPTOR", PV_COD_PLAN_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PV_COD_PERFIL_SUSCRIPTOR", PV_COD_PERFIL_SUSCRIPTOR);
                comando.Parameters.AddWithValue("@PI_MENU", PI_MENU);
                comando.Parameters.AddWithValue("@PV_SECCION", PV_SECCION);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oRol = (from DataRow dr in dt.Rows
                        select new Cartelera_mobile()
                        {
                            numero = (string)dr["numero"],
                            descripcion = (string)dr["descripcion"],
                            descripcion_ingles = (string)dr["descripcion_ingles"],
                            codigo = (string)dr["codigo"],
                            contenido = (string)dr["contenido"],
                            gratis = (string)dr["gratis"],
                            tiempo_visto = (string)dr["tiempo_visto"],
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
