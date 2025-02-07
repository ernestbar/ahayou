using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AhayouClases;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Reflection.PortableExecutable;

namespace AhayouWebAPI.Controllers
{
    public class PlanesController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string llaveSecreta;

        public PlanesController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
        }
        [Route("[action]/{pv_mundo}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPlanesxMundo(string pv_mundo)
        {
            List<Planes> oUsuario = new List<Planes>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("PR_PAR_GET_PLANES_STR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pv_mundo", pv_mundo);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oUsuario = (from DataRow dr in dt.Rows
                            select new Planes()
                            {
                                plan = (string)dr["PLANES"],
                                plan_ingles = (string)dr["PLAN_INGLES"],
                                moneda = (string)dr["MONEDA"],
                                monto = decimal.Parse(dr["MONTO"].ToString()),
                                caracteristicas= (string)dr["CARACTERISTICAS"],
                                caracteristicas_ingles= (string)dr["CARACTERISTICAS_INGLES"],
                                pago_mes = (string)dr["PAGO_MES"],
                                pago_mes_ingles = (string)dr["PAGO_MES_INGLES"],
                                ahorro = (string)dr["AHORRO"],
                                ahorro_mes = (string)dr["AHORRO_MES"]
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
