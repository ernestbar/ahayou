using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
	public class RespuestaAPI
	{
		public HttpStatusCode codigoEstado { get; set; }
        public List<string> mensajesError { get; set; }
        public bool exitoso { get; set; } = false;
		public object resultado { get; set; }
	}
}
