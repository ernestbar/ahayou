using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MonitoClases;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace MonitoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public ContratoController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{ci}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContratoCliente(string ci)
        {
            List<Contrato> oContratoCliente = new List<Contrato>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_contrato", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "L");
                comando.Parameters.AddWithValue("@ci", ci);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                oContratoCliente = (from DataRow dr in dt.Rows
                           select new Contrato()
                           {
                               id_contrato = (int)dr["id_contrato"],
                               numero = (string)dr["numero"],
                               ubicacion = (string)dr["ubicacion"],
							   bloqueado = (bool)dr["bloqueado"]
						   }).ToList();

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { "" };
                oRespuestaAPI.resultado = oContratoCliente;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { ex.Message };
                oRespuestaAPI.resultado = oContratoCliente;
                return BadRequest(oRespuestaAPI);
            }
        }

        [Route("[action]/{id_contrato}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarContratoIndividual(int id_contrato)
        {
            Contrato oContrato = new Contrato();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_contrato", conexion);
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
                    oContrato = (from DataRow dr in dt.Rows
                               select new Contrato()
                               {
                                   id_contrato = (int)dr["id_contrato"],
                                   id_moneda = (int)dr["id_moneda"],
                                   id_usuario = (int)dr["id_usuario"],
                                   numero = (string)dr["numero"],
                                   fecha = (DateTime)dr["fecha"],
                                   contado = (bool)dr["contado"],
                                   preferencial = (bool)dr["preferencial"],
                                   precio = (decimal)dr["precio"],
                                   descuento_porcentaje = (decimal)dr["descuento_porcentaje"],
                                   descuento_efectivo = (decimal)dr["descuento_efectivo"],
                                   precio_final = (decimal)dr["precio_final"],
                                   cuota_inicial = (decimal)dr["cuota_inicial"],
                                   num_cuotas = (int)dr["num_cuotas"],
                                   seguro = (decimal)dr["seguro"],
                                   mantenimiento_sus = (decimal)dr["mantenimiento_sus"],
                                   interes_corriente = (decimal)dr["interes_corriente"],
                                   interes_penal = (decimal)dr["interes_penal"],
                                   cuota_base = (decimal)dr["cuota_base"],
                                   fecha_inicio_plan = (DateTime)dr["fecha_inicio_plan"],
                                   observacion = (string)dr["observacion"],
                                   venta_lote = (bool)dr["venta_lote"],
                                   id_planpago_vigente = (int)dr["id_planpago_vigente"],
                                   estado_id = (int)dr["estado_id"],
                                   estado_nombre = (string)dr["estado_nombre"],
                                   id_negociocontrato = (int)dr["id_negociocontrato"],
                                   negocio_nombre = (string)dr["negocio_nombre"],
                                   id_ultimo_pago = (int)dr["id_ultimo_pago"],
                                   id_cuota_inicial = (int)dr["id_cuota_inicial"],
                                   id_promotor_vigente = (int)dr["id_promotor_vigente"],
                                   id_cobrador_vigente = (int)dr["id_cobrador_vigente"],
                                   id_titular = (int)dr["id_titular"],
                                   id_reversion = (int)dr["id_reversion"],
                                   capital_pagado = (decimal)dr["capital_pagado"],
                                   saldo_capital = (decimal)dr["saldo_capital"],
                                   cuotas_pagadas = (int)dr["cuotas_pagadas"],
                                   codigo_moneda = (string)dr["codigo_moneda"],
                                   nombre_moneda = (string)dr["nombre_moneda"],
                                   capital_adeudado = (decimal)dr["capital_adeudado"],
                                   precio_total = (decimal)dr["precio_total"],
                                   dia_pago = (int)dr["dia_pago"]
                               }).First();
                }

                error = (string)comando.Parameters["@error"].Value;

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oContrato;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oContrato;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
