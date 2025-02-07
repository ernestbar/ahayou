using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using AhayouClases;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace AhayouWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProspectoController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public ProspectoController(IConfiguration configuracion)
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
		public IActionResult ListarProspecto()
		{
			List<Prospecto> oProspecto = new List<Prospecto>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_prospecto", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oProspecto = (from DataRow dr in dt.Rows
							  select new Prospecto()
							  {
								  id_prospecto = (int)dr["id_prospecto"],
								  ci = (string)dr["ci"],
								  nombres = (string)dr["nombres"],
								  paterno = (string)dr["paterno"],
								  materno = (string)dr["materno"],
								  activo = (bool)dr["activo"],
								  celular = (string)dr["celular"],
								  telf_fijo = (string)dr["telf_fijo"],
								  email = (string)dr["email"],
								  id_usuario = (int)dr["id_usuario"],
								  nombre_prospecto = (string)dr["nombre_prospecto"]
							  }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oProspecto;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oProspecto;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_prospecto}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarProspectoIndividual(int id_prospecto)
		{
			Prospecto oProspecto = new Prospecto();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_prospecto", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_prospecto", id_prospecto);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oProspecto = (from DataRow dr in dt.Rows
								  select new Prospecto()
								  {
									  id_prospecto = (int)dr["id_prospecto"],
									  ci = (string)dr["ci"],
									  nombres = (string)dr["nombres"],
									  paterno = (string)dr["paterno"],
									  materno = (string)dr["materno"],
									  activo = (bool)dr["activo"],
									  celular = (string)dr["celular"],
									  telf_fijo = (string)dr["telf_fijo"],
									  email = (string)dr["email"],
									  id_usuario = (int)dr["id_usuario"],
									  nombre_prospecto = (string)dr["nombre_prospecto"]
								  }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oProspecto;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oProspecto;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_usuario}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarProspectoActivo(int id_usuario)
		{
			List<Prospecto> oProspecto = new List<Prospecto>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_prospecto", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				comando.Parameters.AddWithValue("@id_usuario", id_usuario);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oProspecto = (from DataRow dr in dt.Rows
							  select new Prospecto()
							  {
								  id_prospecto = (int)dr["id_prospecto"],
								  ci = (string)dr["ci"],
								  nombres = (string)dr["nombres"],
								  paterno = (string)dr["paterno"],
								  materno = (string)dr["materno"],
								  activo = (bool)dr["activo"],
								  celular = (string)dr["celular"],
								  telf_fijo = (string)dr["telf_fijo"],
								  email = (string)dr["email"],
								  id_usuario = (int)dr["id_usuario"],
								  nombre_prospecto = (string)dr["nombre_prospecto"]
							  }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oProspecto;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oProspecto;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarProspecto([FromBody] Prospecto oProspecto)
		{
			try
			{
                if (!ModelState.IsValid)
                {
                    var errores = (from state in ModelState.Values
	                               from error in state.Errors
                                   select error.ErrorMessage).ToList();

                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = false;
                    oRespuestaAPI.mensajesError = errores;
                    oRespuestaAPI.resultado = oProspecto;
                    return Ok(oRespuestaAPI);
                }

                int id = oProspecto.id_prospecto;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_prospecto", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_prospecto", oProspecto.id_prospecto);
				comando.Parameters.AddWithValue("@ci", oProspecto.ci);
				comando.Parameters.AddWithValue("@nombres", oProspecto.nombres);
				comando.Parameters.AddWithValue("@paterno", oProspecto.paterno);
				comando.Parameters.AddWithValue("@materno", oProspecto.materno);
				comando.Parameters.AddWithValue("@activo", oProspecto.activo);
				comando.Parameters.AddWithValue("@celular", oProspecto.celular);
				comando.Parameters.AddWithValue("@telf_fijo", oProspecto.telf_fijo);
				comando.Parameters.AddWithValue("@email", oProspecto.email);
				comando.Parameters.AddWithValue("@id_usuario", oProspecto.id_usuario);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oProspecto.id_prospecto = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oProspecto;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oProspecto;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_prospecto}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarProspecto(int id_prospecto)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_prospecto", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_prospecto", id_prospecto);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
