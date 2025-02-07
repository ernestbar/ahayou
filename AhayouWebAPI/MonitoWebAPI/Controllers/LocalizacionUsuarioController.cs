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
	public class LocalizacionUsuarioController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public LocalizacionUsuarioController(IConfiguration configuracion)
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
		public IActionResult ListarLocalizacion()
		{
			List<LocalizacionUsuario> oLocalizacion = new List<LocalizacionUsuario>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_localizacion_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oLocalizacion = (from DataRow dr in dt.Rows
								 select new LocalizacionUsuario()
								 {
                                     id_localizacionusuario = (int)dr["id_localizacionusuario"],
									 lat = (string)dr["lat"],
									 lon = (string)dr["lon"],
									 fecha_hora = (DateTime)dr["fecha_hora"],
									 id_usuario = (int)dr["id_usuario"],
									 fecha_cadena = ((DateTime)dr["fecha_hora"]).ToString("dd/MM/yyyy"),
									 hora_cadena = ((DateTime)dr["fecha_hora"]).ToString("HH:mm:ss"),
									 hora_timespan = new TimeSpan(((DateTime)dr["fecha_hora"]).Hour,
																  ((DateTime)dr["fecha_hora"]).Minute,
																  ((DateTime)dr["fecha_hora"]).Second)
								 }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oLocalizacion;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oLocalizacion;
				return BadRequest(oRespuestaAPI);
			}
		}


		[Route("[action]/{id_localizacionusuario}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarLocalizacionIndividual(int id_localizacionusuario)
		{
			LocalizacionUsuario oLocalizacion = new LocalizacionUsuario();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_localizacion_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_localizacionusuario", id_localizacionusuario);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oLocalizacion = (from DataRow dr in dt.Rows
									 select new LocalizacionUsuario()
									 {
                                         id_localizacionusuario = (int)dr["id_localizacionusuario"],
										 lat = (string)dr["lat"],
										 lon = (string)dr["lon"],
										 fecha_hora = (DateTime)dr["fecha_hora"],
										 id_usuario = (int)dr["id_usuario"],
										 fecha_cadena = ((DateTime)dr["fecha_hora"]).ToString("dd/MM/yyyy"),
										 hora_cadena = ((DateTime)dr["fecha_hora"]).ToString("HH:mm:ss"),
										 hora_timespan = new TimeSpan(((DateTime)dr["fecha_hora"]).Hour,
																	  ((DateTime)dr["fecha_hora"]).Minute,
																	  ((DateTime)dr["fecha_hora"]).Second)
									 }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLocalizacion;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLocalizacion;
				return BadRequest(oRespuestaAPI);
			}
		}

        [Route("[action]/{id_usuario}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarUltimaLocalizacion(int id_usuario)
        {
            LocalizacionUsuario oLocalizacion = new LocalizacionUsuario();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_localizacion_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "A");
                comando.Parameters.AddWithValue("@id_usuario", id_usuario);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oLocalizacion = (from DataRow dr in dt.Rows
									 select new LocalizacionUsuario()
									 {
                                         id_localizacionusuario = (int)dr["id_localizacionusuario"],
										 lat = (string)dr["lat"],
										 lon = (string)dr["lon"],
										 fecha_hora = (DateTime)dr["fecha_hora"],
										 id_usuario = (int)dr["id_usuario"],
										 fecha_cadena = ((DateTime)dr["fecha_hora"]).ToString("dd/MM/yyyy"),
										 hora_cadena = ((DateTime)dr["fecha_hora"]).ToString("HH:mm:ss"),
										 hora_timespan = new TimeSpan(((DateTime)dr["fecha_hora"]).Hour,
																	 ((DateTime)dr["fecha_hora"]).Minute,
																	 ((DateTime)dr["fecha_hora"]).Second),
                                         nombre_usuario = (string)dr["nombre_usuario"]
                                     }).First();
				}

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLocalizacion;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLocalizacion;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarLocalizacion([FromBody] LocalizacionUsuario oLocalizacion)
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
                    oRespuestaAPI.resultado = oLocalizacion;
                    return Ok(oRespuestaAPI);
                }

                int id = oLocalizacion.id_localizacionusuario;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_localizacion_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_localizacionusuario", oLocalizacion.id_localizacionusuario);
				comando.Parameters.AddWithValue("@lat", oLocalizacion.lat);
				comando.Parameters.AddWithValue("@lon", oLocalizacion.lon);
				comando.Parameters.AddWithValue("@fecha_hora", oLocalizacion.fecha_hora);
				comando.Parameters.AddWithValue("@id_usuario", oLocalizacion.id_usuario);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oLocalizacion.id_localizacionusuario = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLocalizacion;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLocalizacion;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_localizacionusuario}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarLocalizacion(int id_localizacionusuario)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_localizacion_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_localizacionusuario", id_localizacionusuario);
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
