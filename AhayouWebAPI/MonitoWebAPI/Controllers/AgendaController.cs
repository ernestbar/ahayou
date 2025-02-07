using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using AhayouClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace AhayouWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AgendaController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public AgendaController(IConfiguration configuracion)
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
		public IActionResult ListarAgenda()
		{
			List<Agenda> oAgenda = new List<Agenda>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_agenda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oAgenda = (from DataRow dr in dt.Rows
						   select new Agenda()
						   {
							   id_agenda = (int)dr["id_agenda"],
							   id_prospecto = (int)dr["id_prospecto"],
							   nro_visita = (int)dr["nro_visita"],
							   descripcion = (string)dr["descripcion"],
							   activo = (bool)dr["activo"],
							   fecha_creacion = (DateTime)dr["fecha_creacion"],
							   fecha_agendada = (DateTime)dr["fecha_agendada"],
							   nombre_prospecto = (string)dr["nombre_prospecto"],
							   fecha_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("dd/MM/yyyy"),
							   hora_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("HH:mm:ss"),
							   hora_agendada_timespan = new TimeSpan(((DateTime)dr["fecha_agendada"]).Hour,
															((DateTime)dr["fecha_agendada"]).Minute,
															((DateTime)dr["fecha_agendada"]).Second)
						   }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oAgenda;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oAgenda;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_agenda}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarAgendaIndividual(int id_agenda)
		{
			Agenda oAgenda = new Agenda();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_agenda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_agenda", id_agenda);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oAgenda = (from DataRow dr in dt.Rows
							   select new Agenda()
							   {
								   id_agenda = (int)dr["id_agenda"],
								   id_prospecto = (int)dr["id_prospecto"],
								   nro_visita = (int)dr["nro_visita"],
								   descripcion = (string)dr["descripcion"],
								   activo = (bool)dr["activo"],
								   fecha_creacion = (DateTime)dr["fecha_creacion"],
								   fecha_agendada = (DateTime)dr["fecha_agendada"],
								   nombre_prospecto = (string)dr["nombre_prospecto"],
								   fecha_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("dd/MM/yyyy"),
								   hora_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("HH:mm"),
								   hora_agendada_timespan = new TimeSpan(((DateTime)dr["fecha_agendada"]).Hour,
																((DateTime)dr["fecha_agendada"]).Minute,
																((DateTime)dr["fecha_agendada"]).Second)
							   }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAgenda;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAgenda;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_usuario}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarAgendaActivo(int id_usuario)
		{
			List<Agenda> oAgenda = new List<Agenda>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_agenda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				comando.Parameters.AddWithValue("@id_usuario", id_usuario);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oAgenda = (from DataRow dr in dt.Rows
						   select new Agenda()
						   {
							   id_agenda = (int)dr["id_agenda"],
							   id_prospecto = (int)dr["id_prospecto"],
							   nro_visita = (int)dr["nro_visita"],
							   descripcion = (string)dr["descripcion"],
							   activo = (bool)dr["activo"],
							   fecha_creacion = (DateTime)dr["fecha_creacion"],
							   fecha_agendada = (DateTime)dr["fecha_agendada"],
							   nombre_prospecto = (string)dr["nombre_prospecto"],
							   fecha_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("dd/MM/yyyy"),
							   hora_agendada_cadena = ((DateTime)dr["fecha_agendada"]).ToString("HH:mm"),
							   hora_agendada_timespan = new TimeSpan(((DateTime)dr["fecha_agendada"]).Hour,
															((DateTime)dr["fecha_agendada"]).Minute,
															((DateTime)dr["fecha_agendada"]).Second)
						   }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oAgenda;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oAgenda;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarAgenda([FromBody] Agenda oAgenda)
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
                    oRespuestaAPI.resultado = oAgenda;
                    return Ok(oRespuestaAPI);
                }

                int id = oAgenda.id_agenda;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_agenda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_agenda", oAgenda.id_agenda);
				comando.Parameters.AddWithValue("@id_prospecto", oAgenda.id_prospecto);
				comando.Parameters.AddWithValue("@nro_visita", oAgenda.nro_visita);
				comando.Parameters.AddWithValue("@descripcion", oAgenda.descripcion);
				comando.Parameters.AddWithValue("@activo", oAgenda.activo);
				comando.Parameters.AddWithValue("@fecha_creacion", oAgenda.fecha_creacion);
				comando.Parameters.AddWithValue("@fecha_agendada", oAgenda.fecha_agendada);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oAgenda.id_agenda = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAgenda;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAgenda;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_agenda}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarAgenda(int id_agenda)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_agenda", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_agenda", id_agenda);
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
