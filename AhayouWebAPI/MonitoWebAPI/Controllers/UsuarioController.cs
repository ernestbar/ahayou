using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using AhayouClases;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AhayouWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private string CadenaConexion = "";
		private RespuestaAPI oRespuestaAPI;
		private string error;
		private string llaveSecreta;

		public UsuarioController(IConfiguration configuracion)
		{
			CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
			llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
			oRespuestaAPI = new();
			error = "";
		}

		[Route("[action]")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarUsuario()
		{
			List<Usuario> oUsuario = new List<Usuario>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "L");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oUsuario = (from DataRow dr in dt.Rows
							select new Usuario()
							{
								id_usuario = (int)dr["id_usuario"],
								nombres = (string)dr["nombres"],
								paterno = (string)dr["paterno"],
								materno = (string)dr["materno"],
								activo = (bool)dr["activo"],
								id_supervisor = (int)dr["id_supervisor"],
								ci = (string)dr["ci"],
								nombre_usuario = (string)dr["nombre_usuario"],
								password = (string)dr["password"],
								email = (string)dr["email"],
								id_rol = (int)dr["id_rol"],
								rol = (string)dr["rol"],
								nombre_completo = (string)dr["nombre_completo"],
								nombre_supervisor = (string)dr["nombre_supervisor"]
							}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oUsuario;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oUsuario;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_usuario}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarUsuarioIndividual(int id_usuario)
		{
			Usuario oUsuario = new Usuario();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_usuario", id_usuario);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oUsuario = (from DataRow dr in dt.Rows
								select new Usuario()
								{
									id_usuario = (int)dr["id_usuario"],
									nombres = (string)dr["nombres"],
									paterno = (string)dr["paterno"],
									materno = (string)dr["materno"],
									activo = (bool)dr["activo"],
									id_supervisor = (int)dr["id_supervisor"],
									ci = (string)dr["ci"],
									nombre_usuario = (string)dr["nombre_usuario"],
									password = (string)dr["password"],
									email = (string)dr["email"],
									id_rol = (int)dr["id_rol"],
									rol = (string)dr["rol"],
                                    nombre_completo = (string)dr["nombre_completo"]
                                }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarUsuarioActivo()
		{
			List<Usuario> oUsuario = new List<Usuario>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "A");
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				oUsuario = (from DataRow dr in dt.Rows
							select new Usuario()
							{
								id_usuario = (int)dr["id_usuario"],
								nombres = (string)dr["nombres"],
								paterno = (string)dr["paterno"],
								materno = (string)dr["materno"],
								activo = (bool)dr["activo"],
								id_supervisor = (int)dr["id_supervisor"],
								ci = (string)dr["ci"],
								nombre_usuario = (string)dr["nombre_usuario"],
								password = (string)dr["password"],
								email = (string)dr["email"],
								id_rol = (int)dr["id_rol"],
								rol = (string)dr["rol"],
								nombre_completo = (string)dr["nombre_completo"],
								nombre_supervisor = (string)dr["nombre_supervisor"]
							}).ToList();

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = true;
				oRespuestaAPI.mensajesError = new List<string>() { "" };
				oRespuestaAPI.resultado = oUsuario;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
				oRespuestaAPI.resultado = oUsuario;
				return BadRequest(oRespuestaAPI);
			}
		}

        [Route("[action]/{id_usuario}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarVendedorXSupervisor(int id_usuario)
        {
            List<Usuario> oUsuario = new List<Usuario>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "E");
                comando.Parameters.AddWithValue("@id_usuario", id_usuario);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Usuario()
                            {
                                id_usuario = (int)dr["id_usuario"],
                                nombre_completo = (string)dr["nombre_completo"],
                                email = (string)dr["email"]
                            }).ToList();

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oUsuario;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oUsuario;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarUsuarioSupervisor()
        {
            List<Usuario> oUsuario = new List<Usuario>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_usuario", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "F");
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Usuario()
                            {
                                id_usuario = (int)dr["id_usuario"],
                                nombre_completo = (string)dr["nombre_completo"]
                            }).ToList();

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oUsuario;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oUsuario;
                return BadRequest(oRespuestaAPI);
            }
        }

		[Route("[action]/{nombre_usuario}/{password}")]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult Login(string nombre_usuario, string password)
		{
			Login oLogin = new Login();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("PR_INGRESO_APP", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				//comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@pv_usuario", nombre_usuario);
				comando.Parameters.AddWithValue("@pv_password", password);
				comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_TEMPORAL", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oLogin = (from DataRow dr in dt.Rows
							  select new Login()
							  {
								  //id_usuario = (int)dr["id_usuario"],
								  nombre_usuario = (string)dr[0],
								  ////password = (string)dr["password"],
								  //rol = (string)dr["pv_temporal"],
								  token = ""
							  }).First();

				}
				error = (string)comando.Parameters["@pv_descripcionpr"].Value;
				if (error == "Login correcto")
				{
					// Generar JWT Token
					var tokenHandler = new JwtSecurityTokenHandler();
					var key = Encoding.ASCII.GetBytes(llaveSecreta);
					var tokenDescriptor = new SecurityTokenDescriptor
					{
						Subject = new ClaimsIdentity(new Claim[]
						{
							new Claim(ClaimTypes.Name, oLogin.nombre_usuario),
							new Claim(ClaimTypes.Role, oLogin.rol)
						}),
						Expires = DateTime.UtcNow.AddDays(1),
						SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
					};
					var token = tokenHandler.CreateToken(tokenDescriptor);
					oLogin.token = tokenHandler.WriteToken(token);
				}

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true: false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLogin;
                return Ok(oRespuestaAPI);
            }
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLogin;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult GuardarUsuario([FromBody] Usuario oUsuario)
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
                    oRespuestaAPI.resultado = oUsuario;
                    return Ok(oRespuestaAPI);
                }

                int id = oUsuario.id_usuario;
				string operacion = id == 0 ? "I" : "U";

				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", operacion);
				comando.Parameters.AddWithValue("@id_usuario", oUsuario.id_usuario);
				comando.Parameters.AddWithValue("@nombres", oUsuario.nombres);
				comando.Parameters.AddWithValue("@paterno", oUsuario.paterno);
				comando.Parameters.AddWithValue("@materno", oUsuario.materno);
				comando.Parameters.AddWithValue("@activo", oUsuario.activo);
				comando.Parameters.AddWithValue("@id_supervisor", oUsuario.id_supervisor);
				comando.Parameters.AddWithValue("@ci", oUsuario.ci);
				comando.Parameters.AddWithValue("@nombre_usuario", oUsuario.nombre_usuario);
				comando.Parameters.AddWithValue("@password", oUsuario.password);
				comando.Parameters.AddWithValue("@email", oUsuario.email);
				comando.Parameters.AddWithValue("@id_rol", oUsuario.id_rol);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				oUsuario.id_usuario = (int)comando.Parameters["@id_aux"].Value;
				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult CambiarPasswordUsuario([FromBody] Usuario oUsuario)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "C");
				comando.Parameters.AddWithValue("@id_usuario", oUsuario.id_usuario);
				comando.Parameters.AddWithValue("@password", oUsuario.password);
				comando.Parameters.AddWithValue("@password_nuevo", oUsuario.password_nuevo);
				comando.Parameters.Add("@id_aux", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				comando.ExecuteNonQuery();
				conexion.Close();

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oUsuario;
				return BadRequest(oRespuestaAPI);
			}
		}

		[Route("[action]/{id_usuario}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult EliminarUsuario(int id_usuario)
		{
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_usuario", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "D");
				comando.Parameters.AddWithValue("@id_usuario", id_usuario);
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
