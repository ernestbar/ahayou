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
    public class SuscriptoresController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public SuscriptoresController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GuardarUsuario([FromBody] Suscriptores oUsuario)
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

                string id = oUsuario.pv_usuarioi;
                string operacion = id == "" ? "I" : "U";

                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("SuscriptoresController", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", oUsuario.pv_tipo_operacion);
                comando.Parameters.AddWithValue("@PV_USUARIOI", oUsuario.pv_usuarioi);
                comando.Parameters.AddWithValue("@PV_PASSWORD", oUsuario.pv_password);
                comando.Parameters.AddWithValue("@PV_PASSWORD_ANTERIOR", oUsuario.pv_password_anterior);
                comando.Parameters.AddWithValue("@PV_NOMBRE_COMPLETO", oUsuario.pv_nombre_completo);
                comando.Parameters.AddWithValue("@PN_CELULA", oUsuario.pv_celular);
                comando.Parameters.AddWithValue("@PV_EMAIL", oUsuario.pv_email);
                comando.Parameters.AddWithValue("@PV_USUARIO", oUsuario.pv_usuario);
                comando.Parameters.Add("@PV_ESTADOPR", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@PV_EMAILOUT", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                conexion.Close();

                oUsuario.pv_descripcionpr = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                if (string.IsNullOrEmpty(comando.Parameters["@PV_DESCRIPCIONPR"].Value.ToString()))
                    error = "";
                else
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
                                  nombres = nombre_usuario,
                                  ////password = (string)dr["password"],
                                  //rol = (string)dr["pv_temporal"],
                                  token = ""
                              }).First();

                }
                error = (string)comando.Parameters["@pv_descripcionpr"].Value;
                temporal = (string)comando.Parameters["@pv_temporal"].Value;
                if (error == "Login correcto")
                {
                    // Generar JWT Token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(llaveSecreta);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, oLogin.nombres),
                            new Claim(ClaimTypes.Role, oLogin.rol)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    oLogin.token = tokenHandler.WriteToken(token);
                }

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "Login correcto" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                if (temporal == "1")
                    oRespuestaAPI.temporal = true;
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

        [Route("[action]/{pv_usuario}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarSuscriptorIndividual(string pv_usuario)
        {
            Suscriptores oUsuario = new Suscriptores();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_SUSCRIPTORES_IND", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pv_usuario", pv_usuario);
                //comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                if (dt.Rows.Count > 0)
                {
                    oUsuario = (from DataRow dr in dt.Rows
                                select new Suscriptores()
                                {
                                    pv_usuarioi = (string)dr["usuario"],
                                    pv_password = (string)dr["password"],
                                    pv_nombre_completo = (string)dr["nombre_completo"],
                                    pv_email = (string)dr["email"],
                                    pv_celular = (string)dr["celular"],
                                    pv_estado = (string)dr["desc_estado"]
                                }).First();
                }

                error = "";

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
    }
}
