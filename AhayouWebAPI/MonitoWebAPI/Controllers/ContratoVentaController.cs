using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MonitoClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace MonitoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoVentaController : ControllerBase
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public ContratoVentaController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{id_contrato}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContratoVentaIndividual(int id_contrato)
        {
            ContratoVenta oContratoVenta = new ContratoVenta();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_contrato_venta", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "R");
                comando.Parameters.AddWithValue("@id_contrato", id_contrato);
                comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                if (dt.Rows.Count > 0)
                {
                    oContratoVenta = (from DataRow dr in dt.Rows
                                 select new ContratoVenta()
                                 {
                                     id_contrato = (int)dr["id_contrato"],
                                     id_lote = (int)dr["id_lote"],
                                     superficie_m2 = (decimal)dr["superficie_m2"],
                                     precio_m2_sus = (decimal)dr["precio_m2_sus"],
                                     costo_m2_sus = (decimal)dr["costo_m2_sus"],
                                     localizacion_nombre = (string)dr["localizacion_nombre"],
                                     urbanizacion_nombre = (string)dr["urbanizacion_nombre"],
                                     urbanizacion_nombre_corto = (string)dr["urbanizacion_nombre_corto"],
                                     manzano_codigo = (string)dr["manzano_codigo"],
                                     lote_codigo = (string)dr["lote_codigo"]
                                 }).First();
                }

                error = (string)comando.Parameters["@error"].Value;

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oContratoVenta;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oContratoVenta;
                return BadRequest(oRespuestaAPI);
            }
        }

		[Route("[action]")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult SiguienteNumero()
		{
            string nroContrato = "";
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_contrato_venta", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
                    foreach(DataRow dr in dt.Rows)
                    {
                        nroContrato = (string)dr["num"];
					}
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = nroContrato;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = nroContrato;
				return BadRequest(oRespuestaAPI);
			}
		}
	}
}
