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
	public class RolController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;

		public RolController(IConfiguration configuracion)
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
		public IActionResult ListarRol()
		{
			List<Rol> oRol = new List<Rol>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_rol", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oRol = (from DataRow dr in dt.Rows
						select new Rol()
						{
							id_rol = (int)dr["id_rol"],
							nombre = (string)dr["nombre"],
							activo = (bool)dr["activo"]
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

		[Route("[action]/{id_rol}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarRolIndividual(int id_rol)
		{
			Rol oRol = new Rol();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_rol", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_rol", id_rol);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oRol = (from DataRow dr in dt.Rows
							select new Rol()
							{
								id_rol = (int)dr["id_rol"],
								nombre = (string)dr["nombre"],
								activo = (bool)dr["activo"]
							}).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oRol;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oRol;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarRolActivo()
		{
			List<Rol> oRol = new List<Rol>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_rol", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oRol = (from DataRow dr in dt.Rows
						select new Rol()
						{
							id_rol = (int)dr["id_rol"],
							nombre = (string)dr["nombre"],
							activo = (bool)dr["activo"]
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

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarRol([FromBody] Rol oRol)
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
                    oRespuestaAPI.resultado = oRol;
                    return Ok(oRespuestaAPI);
                }

                int id = oRol.id_rol;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_rol", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_rol", oRol.id_rol);
				comando.Parameters.AddWithValue("@nombre", oRol.nombre);
				comando.Parameters.AddWithValue("@activo", oRol.activo);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oRol.id_rol = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				if (error == "")
				{
					oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
					oRespuestaAPI.exitoso = true;
					oRespuestaAPI.mensajesError = new List<string>() { error };
					oRespuestaAPI.resultado = oRol;
					return Ok(oRespuestaAPI);
				}
				else
				{
					oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
					oRespuestaAPI.exitoso = false;
					oRespuestaAPI.mensajesError = new List<string>() { error };
					oRespuestaAPI.resultado = oRol;
					return BadRequest(oRespuestaAPI);
				}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oRol;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_rol}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarRol(int id_rol)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_rol", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_rol", id_rol);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				error = (string)comando.Parameters["@error"].Value;

				if (error == "")
				{
					oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
					oRespuestaAPI.exitoso = true;
					oRespuestaAPI.mensajesError = new List<string>() { error };
					return Ok(oRespuestaAPI);
				}
				else
				{
					oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
					oRespuestaAPI.exitoso = false;
					oRespuestaAPI.mensajesError = new List<string>() { error };
					return BadRequest(oRespuestaAPI);
				}
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
