using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using AhayouClases;
using System.Data;
using System.Net;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrbanizacionController : ControllerBase
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public UrbanizacionController(IConfiguration configuracion)
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
        public IActionResult ListarUrbanizacionActivo()
        {
            List<Urbanizacion> oUrbanizacion = new List<Urbanizacion>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("[sp_urbanizacion]", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "A");
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUrbanizacion = (from DataRow dr in dt.Rows
                        select new Urbanizacion()
                        {
                            id_urbanizacion = (int)dr["id_urbanizacion"],
                            nombre = (string)dr["nombre"],
                            localizacion_nombre = (string)dr["localizacion_nombre"]

                        }).ToList();

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oUrbanizacion;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oUrbanizacion;
                return BadRequest(oRespuestaAPI);
            }
        }

		[Route("[action]/{id_localizacion}/{activo}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarUrbanizacionActivoDDL(int id_localizacion, bool activo)
		{
			List<Urbanizacion> oUrbanizacion = new List<Urbanizacion>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("[sp_urbanizacion]", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@id_localizacion", id_localizacion);
				comando.Parameters.AddWithValue("@activo", activo);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oUrbanizacion = (from DataRow dr in dt.Rows
								 select new Urbanizacion()
								 {
									 id_urbanizacion = (int)dr["id_urbanizacion"],
									 nombre = (string)dr["nombre"]

								 }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oUrbanizacion;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oUrbanizacion;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
