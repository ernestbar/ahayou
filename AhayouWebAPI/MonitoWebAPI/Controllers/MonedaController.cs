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
	public class MonedaController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

        public MonedaController(IConfiguration configuracion)
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
		public IActionResult ListarMoneda()
		{
			List<Moneda> oRol = new List<Moneda>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_moneda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oRol = (from DataRow dr in dt.Rows
						select new Moneda()
						{
							id_moneda = (int)dr["id_moneda"],
							codigo = (string)dr["codigo"],
							nombre = (string)dr["nombre"]
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
