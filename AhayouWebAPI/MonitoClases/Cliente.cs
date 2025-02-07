using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Cliente
    {
        public int id_cliente { get; set; } = 0;
        public int id_lugarcedula { get; set; } = 0;
        public int id_lugarcobro { get; set; } = 0;
        public int id_usuario { get; set; } = 0;
        public string ci { get; set; } = "";
        public string nit { get; set; } = "";
        public string nombres { get; set; } = "";
        public string paterno { get; set; } = "";
        public string materno { get; set; } = "";
        public DateTime fecha_nacimiento { get; set; } = DateTime.Today;
        public string celular { get; set; } = "";
        public string fax { get; set; } = "";
        public string email { get; set; } = "";
        public string casilla { get; set; } = "";
        public string domicilio_direccion { get; set; } = "";
        public string domicilio_fono { get; set; } = "";
        public int domicilio_id_zona { get; set; } = 0;
        public string oficina_direccion { get; set; } = "";
        public string oficina_fono { get; set; } = "";
        public int oficina_id_zona { get; set; } = 0;
        public bool transitorio { get; set; } = false;

        public string codigo_lugarcedula { get; set; } = "";
        public string nombre_lugarcobro { get; set; } = "";
        public string nombre_zona_domicilio { get; set; } = "";
        public string nombre_zona_oficina { get; set; } = "";
        public int num_contratos { get; set; } = 0;
        public int num_servicios { get; set; } = 0;
        public int num_audit { get; set; } = 0;
    }
}
