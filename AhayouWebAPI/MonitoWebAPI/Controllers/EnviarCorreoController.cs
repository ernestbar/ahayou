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
using System.Net.Mail;

namespace AhayouWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviarCorreoController : Controller
    {
        private string CadenaConexion = "";
        private RespuestaAPI oRespuestaAPI;
        private string error;
        private string temporal;
        private string llaveSecreta;

        public EnviarCorreoController(IConfiguration configuracion)
        {
            CadenaConexion = configuracion.GetConnectionString("CadenaConexion");
            llaveSecreta = configuracion.GetValue<string>("ApiSettings:LlaveSecreta");
            oRespuestaAPI = new();
            error = "";
            temporal = "";
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EnviarCorreo([FromBody] Correo oPago)
        {
            try
            {
                string strHost = oPago.smtp_host;
                int port = oPago.smtp_port;
                string strUserName = oPago.smtp_correo;
                string strFromPass = oPago.smtp_password;
                string strFromName = "";

                SmtpClient smtp = new SmtpClient(strHost, port);
                NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
                smtp.Credentials = cert;
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage(oPago.smtp_correo, oPago.email_destino);
                msg.Subject = oPago.subjet;
                msg.IsBodyHtml = true;
                msg.Body = oPago.mensaje;
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(adjunto);
                //msg.Attachments.Add(attachment);
                smtp.Send(msg);
                oPago.respuesta = "OK";

                

                oRespuestaAPI.descripcion = "Email enviado correctamente";
                oRespuestaAPI.codigoEstado = HttpStatusCode.OK;
                oRespuestaAPI.exitoso = true;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return Ok(oRespuestaAPI);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                oRespuestaAPI.codigoEstado = HttpStatusCode.BadRequest;
                oRespuestaAPI.exitoso = false;
                oRespuestaAPI.mensajesError = new List<string>() { error };
                oRespuestaAPI.resultado = oPago;
                return BadRequest(oRespuestaAPI);
            }
        }
    }
}
