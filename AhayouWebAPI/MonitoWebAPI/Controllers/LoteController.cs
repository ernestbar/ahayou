using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MonitoClases;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace MonitoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;

        public LoteController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            oRespuestaAPI = new();
            error = "";
        }

        [Route("[action]/{id_urbanizacion}")]
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarLoteUrbanizacion(int id_urbanizacion)
        {
            List<Lote> oLote = new List<Lote>();
            try
            {
                SqlConnection conexion = new SqlConnection(CadenaConexion);
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_lote", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@tipo_operacion", "L");
                comando.Parameters.AddWithValue("@id_urbanizacion", id_urbanizacion);
                comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();

                if (dt.Rows.Count > 0)
                {
                    oLote = (from DataRow dr in dt.Rows
                                 select new Lote()
                                 {
                                     id_lote = (int)dr["id_lote"],
                                     codigo = (string)dr["codigo"],
                                     codigo_manzano = (string)dr["codigo_manzano"],
									 nombre_urbanizacion = (string)dr["nombre_urbanizacion"],
									 nombre_localizacion = (string)dr["nombre_localizacion"]
                                 }).ToList();
                }

                error = (string)comando.Parameters["@error"].Value;

                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = error == "" ? true : false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLote;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oLote;
                return BadRequest(oRespuestaAPI);
            }
        }

		[Route("[action]/{id_manzano}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarLoteDisponible(int id_manzano)
		{
			List<Lote> oLote = new List<Lote>();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_lote", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "B");
				comando.Parameters.AddWithValue("@id_manzano", id_manzano);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oLote = (from DataRow dr in dt.Rows
							 select new Lote()
							 {
								 id_lote = (int)dr["id_lote"],
								 codigo = (string)dr["codigo"]
							 }).ToList();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLote;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLote;
				return BadRequest(oRespuestaAPI);
			}
		}


		[Route("[action]/{id_lote}")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ListarLoteIndividual(int id_lote)
		{
			Lote oLote = new Lote();
			try
			{
				SqlConnection conexion = new SqlConnection(CadenaConexion);
				conexion.Open();
				SqlCommand comando = new SqlCommand("sp_lote", conexion);
				comando.CommandType = CommandType.StoredProcedure;
				comando.Parameters.AddWithValue("@tipo_operacion", "R");
				comando.Parameters.AddWithValue("@id_lote", id_lote);
				comando.Parameters.Add("@error", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
				SqlDataAdapter da = new SqlDataAdapter(comando);
				DataTable dt = new DataTable();
				da.Fill(dt);
				conexion.Close();

				if (dt.Rows.Count > 0)
				{
					oLote = (from DataRow dr in dt.Rows
							 select new Lote()
							 {
								 id_lote = (int)dr["id_lote"],
								 id_manzano = (int)dr["id_manzano"],
								 id_usuario = (int)dr["id_usuario"],
								 fecha_registro = (DateTime)dr["fecha_registro"],
								 codigo = (string)dr["codigo"],
								 superficie_m2 = (decimal)dr["superficie_m2"],
								 costo_m2_sus = (decimal)dr["costo_m2_sus"],
								 precio_m2_sus = (decimal)dr["precio_m2_sus"],
								 anterior_propietario = (string)dr["anterior_propietario"],
								 num_partida = (string)dr["num_partida"],
								 con_muro = (bool)dr["con_muro"],
								 con_construccion = (bool)dr["con_construccion"],
								 codigo_manzano = (string)dr["codigo_manzano"],
								 codigo_urbanizacion = (string)dr["codigo_urbanizacion"],
								 codigo_localizacion = (string)dr["codigo_localizacion"],
								 nombre_urbanizacion = (string)dr["nombre_urbanizacion"],
								 nombre_localizacion = (string)dr["nombre_localizacion"],
								 nombre_estado = (string)dr["nombre_estado"],
								 nombre_negocio = (string)dr["nombre_negocio"],
								 id_urbanizacion = (int)dr["id_urbanizacion"],
								 id_localizacion = (int)dr["id_localizacion"],
								 id_estadolote = (int)dr["id_estadolote"],
								 id_negociolote = (int)dr["id_negociolote"],
								 num_contratos = (int)dr["num_contratos"],
								 id_contrato_asignado = (int)dr["id_contrato_asignado"]
							 }).First();
				}

				error = (string)comando.Parameters["@error"].Value;

				oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
				oRespuestaAPI.exitoso = error == "" ? true : false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLote;
				return Ok(oRespuestaAPI);
			}
			catch (Exception ex)
			{
				error = ex.Message;
				oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
				oRespuestaAPI.exitoso = false;
				oRespuestaAPI.mensajesError = new List<string>() { error };
				oRespuestaAPI.resultado = oLote;
				return BadRequest(oRespuestaAPI);
			}
		}

	}
}
