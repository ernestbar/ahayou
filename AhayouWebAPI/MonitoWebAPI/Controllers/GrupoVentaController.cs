using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AhayouClases;
using System.Data;
using System.Net;

namespace AhayouWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GrupoVentaController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;
		public GrupoVentaController(IConfiguration configuracion)
        {
			CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
			oRespuestaAPI = new();
			error = "";
		}

		[Route("[action]/{id_grupoventa}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarGrupoVentaActivoConPromotor(int id_grupoventa)
		{
			List<GrupoVenta> oGrupoVenta = new List<GrupoVenta>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("[sp_grupo_venta]", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@id_grupoventa", id_grupoventa);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oGrupoVenta = (from DataRow dr in dt.Rows
							select new GrupoVenta()
							{
								id_grupoventa = (int)dr["id_grupoventa"],
								id_director = (int)dr["id_director"],
								nombre = (string)dr["nombre"],
								nombre_director = (string)dr["nombre_director"]
							}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oGrupoVenta;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oGrupoVenta;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
