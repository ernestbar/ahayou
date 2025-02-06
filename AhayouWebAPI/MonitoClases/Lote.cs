using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
    public class Lote
    {
        public int id_lote { get; set; } = 0;
        public int id_manzano { get; set; } = 0;
        public int id_usuario { get; set; } = 0;
        public DateTime fecha_registro { get; set; } = DateTime.Today;
        public string codigo { get; set; } = "";
        public decimal superficie_m2 { get; set; } = 0;
        public decimal costo_m2_sus { get; set; } = 0;
        public decimal precio_m2_sus { get; set; } = 0;
        public string anterior_propietario { get; set; } = "";
        public string num_partida { get; set; } = "";
        public bool con_muro { get; set; } = false;
        public bool con_construccion { get; set; } = false;

		public string codigo_manzano { get; set; } = "";
		public string codigo_urbanizacion { get; set; } = "";
		public string codigo_localizacion { get; set; } = "";
		public string nombre_urbanizacion { get; set; } = "";
		public string nombre_localizacion { get; set; } = "";
		public string nombre_estado { get; set; } = "";
		public string nombre_negocio { get; set; } = "";
		public int id_urbanizacion { get; set; } = 0;
		public int id_localizacion { get; set; } = 0;
		public int id_estadolote { get; set; } = 0;
		public int id_negociolote { get; set; } = 0;
		public int num_contratos { get; set; } = 0;
		public int id_contrato_asignado { get; set; } = 0;
		public decimal precio_total { get; set; } = 0;
	}
}
