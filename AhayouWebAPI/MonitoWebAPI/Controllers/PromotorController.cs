using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MonitoClases;
using System.Data;
using System.Net;

namespace MonitoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PromotorController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

        public PromotorController(IConfiguration configuracion)
        {
			CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
			oRespuestaAPI = new();
			error = "";
		}

		[Route("[action]/{id_grupoventa}/{id_grupopromotor}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarPromotorActivoXGrupo(int id_grupoventa, int id_grupopromotor)
		{
			List<Promotor> oPromotor = new List<Promotor>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_promotor", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@id_grupoventa", id_grupoventa);
				comando.Parameters.AddWithValue("@id_grupopromotor", id_grupopromotor);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oPromotor = (from DataRow dr in dt.Rows
							 select new Promotor()
							 {
								 id_grupopromotor = (int)dr["id_grupopromotor"],
								 id_usuario = (int)dr["id_usuario"],
								 nombre_completo = (string)dr["nombre_completo"],
								 ci = (string)dr["ci"]
							 }).ToList();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oPromotor;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oPromotor;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
