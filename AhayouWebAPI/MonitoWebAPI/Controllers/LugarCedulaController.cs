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
	public class LugarCedulaController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

        public LugarCedulaController(IConfiguration configuracion)
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
		public IActionResult ListarLugarCedula()
		{
			List<LugarCedula> oLugarCedula = new List<LugarCedula>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_lugar_cedula", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oLugarCedula = (from DataRow dr in dt.Rows
								select new LugarCedula()
								{
									id_lugarcedula = (int)dr["id_lugarcedula"],
									codigo = (string)dr["codigo"],
									nombre = (string)dr["nombre"],
								}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oLugarCedula;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message }; ;
				oRespuestaAPI.resultado = oLugarCedula;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
