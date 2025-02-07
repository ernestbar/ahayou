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
	public class AvisoController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public AvisoController(IConfiguration configuracion)
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
		public IActionResult ListarAviso()
		{
			List<Aviso> oAviso = new List<Aviso>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_aviso", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oAviso = (from DataRow dr in dt.Rows
						  select new Aviso()
						  {
							  id_aviso = (int)dr["id_aviso"],
							  id_prospecto = (int)dr["id_prospecto"],
							  descripcion = (string)dr["descripcion"],
							  fecha_envio = (DateTime)dr["fecha_envio"],
							  fecha_lectura = dr["fecha_lectura"] == DBNull.Value ? DateTime.Today : (DateTime)dr["fecha_lectura"],
							  leido = (bool)dr["leido"],
							  activo = (bool)dr["activo"],
							  nombre_prospecto = (string)dr["nombre_prospecto"],
							  fecha_envio_cadena = ((DateTime)dr["fecha_envio"]).ToString("dd/MM/yyyy"),
							  fecha_lectura_cadena = dr["fecha_lectura"] == DBNull.Value ? "" : ((DateTime)dr["fecha_lectura"]).ToString("dd/MM/yyyy"),
							  estado = (string)dr["estado"]
						  }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oAviso;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message }; ;
				oRespuestaAPI.resultado = oAviso;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_aviso}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarAvisoIndividual(int id_aviso)
		{
			Aviso oAviso = new Aviso();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_aviso", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_aviso", id_aviso);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oAviso = (from DataRow dr in dt.Rows
							  select new Aviso()
							  {
								  id_aviso = (int)dr["id_aviso"],
								  id_prospecto = (int)dr["id_prospecto"],
								  descripcion = (string)dr["descripcion"],
								  fecha_envio = (DateTime)dr["fecha_envio"],
								  fecha_lectura = dr["fecha_lectura"] == DBNull.Value ? DateTime.Today : (DateTime)dr["fecha_lectura"],
								  leido = (bool)dr["leido"],
								  activo = (bool)dr["activo"],
								  nombre_prospecto = (string)dr["nombre_prospecto"],
								  fecha_envio_cadena = ((DateTime)dr["fecha_envio"]).ToString("dd/MM/yyyy"),
								  fecha_lectura_cadena = dr["fecha_lectura"] == DBNull.Value ? "" : ((DateTime)dr["fecha_lectura"]).ToString("dd/MM/yyyy"),
								  estado = (string)dr["estado"]
							  }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAviso;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAviso;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_usuario}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarAvisoActivo(int id_usuario)
		{
			List<Aviso> oAviso = new List<Aviso>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_aviso", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				comando.Parameters.AddWithValue("@id_usuario", id_usuario);
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oAviso = (from DataRow dr in dt.Rows
						  select new Aviso()
						  {
							  id_aviso = (int)dr["id_aviso"],
							  id_prospecto = (int)dr["id_prospecto"],
							  descripcion = (string)dr["descripcion"],
							  fecha_envio = (DateTime)dr["fecha_envio"],
							  fecha_lectura = dr["fecha_lectura"] == DBNull.Value ? DateTime.Today : (DateTime)dr["fecha_lectura"],
							  leido = (bool)dr["leido"],
							  activo = (bool)dr["activo"],
							  nombre_prospecto = (string)dr["nombre_prospecto"],
							  fecha_envio_cadena = ((DateTime)dr["fecha_envio"]).ToString("dd/MM/yyyy"),
							  fecha_lectura_cadena = dr["fecha_lectura"] == DBNull.Value ? "" : ((DateTime)dr["fecha_lectura"]).ToString("dd/MM/yyyy"),
							  estado = (string)dr["estado"]
						  }).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oAviso;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oAviso;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarAviso([FromBody] Aviso oAviso)
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
                    oRespuestaAPI.resultado = oAviso;
                    return Ok(oRespuestaAPI);
                }

                int id = oAviso.id_aviso;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_aviso", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_aviso", oAviso.id_aviso);
				comando.Parameters.AddWithValue("@id_prospecto", oAviso.id_prospecto);
				comando.Parameters.AddWithValue("@descripcion", oAviso.descripcion);
				comando.Parameters.AddWithValue("@fecha_envio", oAviso.fecha_envio);
				comando.Parameters.AddWithValue("@fecha_lectura", oAviso.fecha_lectura);
				comando.Parameters.AddWithValue("@leido", oAviso.leido);
				comando.Parameters.AddWithValue("@activo", oAviso.activo);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oAviso.id_aviso = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAviso;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oAviso;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_aviso}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarAviso(int id_aviso)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_aviso", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_aviso", id_aviso);
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
