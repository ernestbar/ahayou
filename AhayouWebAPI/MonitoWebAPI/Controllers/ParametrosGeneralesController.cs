using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MonitoClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MonitoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParametrosGeneralesController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public ParametrosGeneralesController(IConfiguration configuracion)
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
		public IActionResult ListarParametrosGenerales()
		{
			List<ParametrosGenerales> oParametrosGenerales = new List<ParametrosGenerales>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_parametros_generales", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oParametrosGenerales = (from DataRow dr in dt.Rows
										select new ParametrosGenerales()
										{
											id_parametrogeneral = (int)dr["id_parametrogeneral"],
											id_tipodato = (int)dr["id_tipodato"],
											codigo = (string)dr["codigo"],
											nombre = (string)dr["nombre"],
                                            valor_numerico = dr["valor_numerico"] == DBNull.Value ? 0 : (decimal)dr["valor_numerico"],
                                            valor_caracter = dr["valor_caracter"] == DBNull.Value ? "" : (string)dr["valor_caracter"],
                                            valor_fecha = dr["valor_fecha"] == DBNull.Value ? DateTime.Today : (DateTime)dr["valor_fecha"],
                                            activo = (bool)dr["activo"],
											fecha_creacion = (DateTime)dr["fecha_creacion"],
											tipo_dato = (string)dr["tipo_dato"],
											valor_numerico_cadena = dr["valor_numerico"] == DBNull.Value ? "" : Convert.ToString(dr["valor_numerico"]),
											valor_fecha_cadena = dr["valor_fecha"] == DBNull.Value ? "" : ((DateTime)dr["valor_fecha"]).ToString("dd/MM/yyyy")
										}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_parametrogeneral}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarParametrosGeneralesIndividual(int id_parametrogeneral)
		{
			ParametrosGenerales oParametrosGenerales = new ParametrosGenerales();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_parametros_generales", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_parametrogeneral", id_parametrogeneral);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oParametrosGenerales = (from DataRow dr in dt.Rows
											select new ParametrosGenerales()
											{
												id_parametrogeneral = (int)dr["id_parametrogeneral"],
												id_tipodato = (int)dr["id_tipodato"],
												codigo = (string)dr["codigo"],
												nombre = (string)dr["nombre"],
                                                valor_numerico = dr["valor_numerico"] == DBNull.Value ? 0 : (decimal)dr["valor_numerico"],
                                                valor_caracter = dr["valor_caracter"] == DBNull.Value ? "" : (string)dr["valor_caracter"],
                                                valor_fecha = dr["valor_fecha"] == DBNull.Value ? DateTime.Today : (DateTime)dr["valor_fecha"],
                                                activo = (bool)dr["activo"],
												fecha_creacion = (DateTime)dr["fecha_creacion"],
												tipo_dato = (string)dr["tipo_dato"],
												valor_numerico_cadena = dr["valor_numerico"] == DBNull.Value ? "" : Convert.ToString(dr["valor_numerico"]),
												valor_fecha_cadena = dr["valor_fecha"] == DBNull.Value ? "" : ((DateTime)dr["valor_fecha"]).ToString("dd/MM/yyyy")

											}).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarParametrosGeneralesActivo()
		{
			List<ParametrosGenerales> oParametrosGenerales = new List<ParametrosGenerales>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_parametros_generales", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oParametrosGenerales = (from DataRow dr in dt.Rows
										select new ParametrosGenerales()
										{
											id_parametrogeneral = (int)dr["id_parametrogeneral"],
											id_tipodato = (int)dr["id_tipodato"],
											codigo = (string)dr["codigo"],
											nombre = (string)dr["nombre"],
											valor_numerico = dr["valor_numerico"] == DBNull.Value ? 0 : (decimal)dr["valor_numerico"],
											valor_caracter = dr["valor_caracter"] == DBNull.Value ? "" : (string)dr["valor_caracter"],
                                            valor_fecha = dr["valor_fecha"] == DBNull.Value ? DateTime.Today : (DateTime)dr["valor_fecha"],
                                            activo = (bool)dr["activo"],
											fecha_creacion = (DateTime)dr["fecha_creacion"],
											tipo_dato = (string)dr["tipo_dato"],
											valor_numerico_cadena = dr["valor_numerico"] == DBNull.Value ? "" : Convert.ToString(dr["valor_numerico"]),
											valor_fecha_cadena = dr["valor_fecha"] == DBNull.Value ? "" : ((DateTime)dr["valor_fecha"]).ToString("dd/MM/yyyy")
										}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarParametrosGenerales([FromBody] ParametrosGenerales oParametrosGenerales)
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
                    oRespuestaAPI.resultado = oParametrosGenerales;
                    return Ok(oRespuestaAPI);
                }

                int id = oParametrosGenerales.id_parametrogeneral;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_parametros_generales", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_parametrogeneral", oParametrosGenerales.id_parametrogeneral);
                comando.Parameters.AddWithValue("@id_tipodato", oParametrosGenerales.id_tipodato);
                comando.Parameters.AddWithValue("@codigo", oParametrosGenerales.codigo);
				comando.Parameters.AddWithValue("@nombre", oParametrosGenerales.nombre);
				comando.Parameters.AddWithValue("@valor_numerico", oParametrosGenerales.valor_numerico);
				comando.Parameters.AddWithValue("@valor_caracter", oParametrosGenerales.valor_caracter);
				comando.Parameters.AddWithValue("@valor_fecha", oParametrosGenerales.valor_fecha);
				comando.Parameters.AddWithValue("@activo", oParametrosGenerales.activo);
				comando.Parameters.AddWithValue("@fecha_creacion", oParametrosGenerales.fecha_creacion);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oParametrosGenerales.id_parametrogeneral = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oParametrosGenerales;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_parametrogeneral}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarParametrosGenerales(int id_parametrogeneral)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_parametros_generales", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_parametrogeneral", id_parametrogeneral);
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
