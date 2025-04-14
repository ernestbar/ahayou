using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Correo
    {
        public string email_destino { get; set; }
        public string subjet { get; set; }

        public string mensaje { get; set; }

        public string respuesta { get; set; }

        public string smtp_correo { get; set; }
        public string smtp_password { get; set; }
        public string smtp_host { get; set; }
        public int smtp_port { get; set; }

    }
}
