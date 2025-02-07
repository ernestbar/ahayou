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
	public class CapitalAdeudadoUrbanizacionController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

        public CapitalAdeudadoUrbanizacionController(IConfiguration configuracion)
        {
			CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
			oRespuestaAPI = new();
			error = "";
		}

		[Route("[action]/{id_urbanizacion}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult VerificarUrbanizacion(int id_urbanizacion)
		{
			bool verificar = false;
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_capital_adeudado_urbanizacion", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@id_urbanizacion", id_urbanizacion);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					if (dt.Rows.Count > 0)
					{
						foreach (DataRow dr in dt.Rows)
						{
							verificar = (bool)dr["verificar"];
						}
					}
				}

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = verificar;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = verificar;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_urbanizacion}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarUrbanizacionParametro(int id_urbanizacion)
		{
			CapitalAdeudadoUrbanizacion oCapitalAdeudadoUrbanizacion = new CapitalAdeudadoUrbanizacion();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_capital_adeudado_urbanizacion", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "C");
				comando.Parameters.AddWithValue("@id_urbanizacion", id_urbanizacion);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oCapitalAdeudadoUrbanizacion = (from DataRow dr in dt.Rows
								select new CapitalAdeudadoUrbanizacion()
								{
									id_parametrocapitaldeudor = (int)dr["id_parametrocapitaldeudor"],
									pocentaje_capital_deudor = (decimal)dr["pocentaje_capital_deudor"]
								}).First();
				}

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oCapitalAdeudadoUrbanizacion;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oCapitalAdeudadoUrbanizacion;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
