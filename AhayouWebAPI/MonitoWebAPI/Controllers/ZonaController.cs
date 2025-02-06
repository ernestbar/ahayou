using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MonitoClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace MonitoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ZonaController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public ZonaController(IConfiguration configuracion)
		{
			CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
			oRespuestaAPI = new();
			error = "";
		}

		[Route("[action]/{id_sector}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarZona(int id_sector)
		{
			List<Zona> oZona = new List<Zona>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_zona", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				comando.Parameters.AddWithValue("@id_sector", id_sector);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oZona = (from DataRow dr in dt.Rows
						 select new Zona()
						 {
							 id_zona = (int)dr["id_zona"],
							 id_sector = (int)dr["id_sector"],
							 nombre = (string)dr["nombre"],
						 }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oZona;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message }; ;
				oRespuestaAPI.resultado = oZona;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
