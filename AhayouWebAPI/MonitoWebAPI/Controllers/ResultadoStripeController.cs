using AhayouClases;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoStripeController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public ResultadoStripeController(IConfiguration configuracion)
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
        public async Task<IActionResult> RespuestaStripe()
        {
            try
            {

                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                var str = await reader.ReadToEndAsync();
                string data = str.Replace("\\", "");

                string rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "archivos", "miarchivo.txt");
                // Crear el directorio si no existe
                var directorio = Path.GetDirectoryName(rutaArchivo);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                // Escribir contenido en el archivo (añadir al final)
                await System.IO.File.AppendAllTextAsync(rutaArchivo, str + "\n");


               
                string[] status1 = data.Split("payment_status");
                string[] status2 = status1[1].Split("\"");

                string[] idclient1 = data.Split("client_reference_id");
                string[] idclient2 = idclient1[1].Split("\"");
                string id_session = idclient2[2];
                if (status2[2].Contains("paid"))
                {
                    string estado_id = "";
                    SqlConnection conexion = new SqlConnection(CadenaConexion);
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("PR_SEG_VERIFICA_ESTADO_IDSESION", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("PI_ID", id_session);
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.Close();
                    foreach (DataRow dr in dt.Rows) 
                    {
                        estado_id = (string)dr["estado"];
                    }
                    if (estado_id == "PENDIENTE")
                    {
                        SqlConnection conexion1 = new SqlConnection(CadenaConexion);
                        conexion1.Open();
                        SqlCommand comando1 = new SqlCommand("PR_STR_ABM_PLAN_PAGO_SUSCRIPTOR_IDSESION", conexion1);
                        comando1.CommandType = CommandType.StoredProcedure;
                        comando1.Parameters.AddWithValue("@PV_TIPO_OPERACION", "I");
                        comando1.Parameters.AddWithValue("@PB_ID", id_session);
                        comando1.Parameters.AddWithValue("@PV_DETALLES", str);
                        comando1.Parameters.AddWithValue("@PV_USUARIO", "ADM");
                        comando1.Parameters.Add("@PV_ESTADOPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        comando1.Parameters.Add("@PV_DESCRIPCIONPR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        comando1.Parameters.Add("@PV_ERROR", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        comando1.ExecuteNonQuery();
                        conexion1.Close();


                        oRespuestaAPI.descripcion = (string)comando.Parameters["@PV_DESCRIPCIONPR"].Value;
                        oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                        oRespuestaAPI.exitoso = true;
                        oRespuestaAPI.mensajesError = new List<string>() { error };
                        oRespuestaAPI.resultado = (string)comando.Parameters["@PV_ESTADOPR"].Value;
                    }
                    else
                    {
                        oRespuestaAPI.descripcion = "EL PAGO YA FUE PROCESADO";
                        oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                        oRespuestaAPI.exitoso = true;
                        oRespuestaAPI.mensajesError = new List<string>() { error };
                        oRespuestaAPI.resultado = "";
                    }
                    
                }
                else
                {
                    oRespuestaAPI.descripcion = "No se realizo el pago, estado:";
                    oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                    oRespuestaAPI.exitoso = false;
                    oRespuestaAPI.mensajesError = new List<string>() { error };
                    oRespuestaAPI.resultado = "";
                }

                    return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = "";
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
