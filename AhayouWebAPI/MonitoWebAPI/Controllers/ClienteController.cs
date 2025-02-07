using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using AhayouClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public ClienteController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{id_cliente}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarClienteIndividual(int id_cliente)
        {
            Cliente oCliente = new Cliente();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_cliente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "R");
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                if (dt.Rows.Count > 0)
                {
                    oCliente = (from DataRow dr in dt.Rows
                                 select new Cliente()
                                 {
                                     id_lugarcedula = (int)dr["id_lugarcedula"],
                                     id_lugarcobro = (int)dr["id_lugarcobro"],
                                     id_usuario = (int)dr["id_usuario"],
                                     ci = (string)dr["ci"],
                                     nit = (string)dr["nit"],
                                     nombres = (string)dr["nombres"],
                                     paterno = (string)dr["paterno"],
                                     materno = (string)dr["materno"],
                                     fecha_nacimiento = (DateTime)dr["fecha_nacimiento"],
                                     celular = (string)dr["celular"],
                                     fax = (string)dr["fax"],
                                     email = (string)dr["email"],
                                     casilla = (string)dr["casilla"],
                                     domicilio_direccion = (string)dr["domicilio_direccion"],
                                     domicilio_fono = (string)dr["domicilio_fono"],
                                     domicilio_id_zona = (int)dr["domicilio_id_zona"],
                                     oficina_direccion = (string)dr["oficina_direccion"],
                                     oficina_fono = (string)dr["oficina_fono"],
                                     oficina_id_zona = (int)dr["oficina_id_zona"],
                                     transitorio = (bool)dr["transitorio"],
                                     codigo_lugarcedula = (string)dr["codigo_lugarcedula"],
                                     nombre_lugarcobro = (string)dr["nombre_lugarcobro"],
                                     nombre_zona_domicilio = (string)dr["nombre_zona_domicilio"],
                                     nombre_zona_oficina = (string)dr["nombre_zona_oficina"],
                                     num_contratos = (int)dr["num_contratos"],
                                     num_servicios = (int)dr["num_servicios"],
                                     num_audit = (int)dr["num_audit"]
                                 }).First();
                }

                error = (string)comando.Parameters["@error"].Value;

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oCliente;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oCliente;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
