using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AhayouClases;
using System.Collections.Generic;
using System.Data;
using System.Net;


namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominiosController : Controller
    {

        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string llaveSecreta;

        public DominiosController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{pv_dominio}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarDominiosxDominio(string pv_dominio)
        {
            List<Dominios> oUsuario = new List<Dominios>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_DOMINIOS", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pv_dominio", pv_dominio);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Dominios()
                            {
                                dominio = (string)dr["dominio"],
                                codigo = (string)dr["codigo"],
                                descripcion = (string)dr["descripcion"],
                                valor_caracter = (string)dr["valor_caracter"],
                                valor_numerico = (decimal)dr["valor_numerico"],
                                valor_fecha = (DateTime)dr["valor_date"]
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
    }
}
