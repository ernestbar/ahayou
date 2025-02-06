using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
    public class ContratoVenta
    {
        public int id_contrato { get; set; } = 0;
        public int id_lote { get; set; } = 0;
        public decimal superficie_m2 { get; set; } = 0;
        public decimal precio_m2_sus { get; set; } = 0;
        public decimal costo_m2_sus { get; set; } = 0;

        public string localizacion_nombre { get; set; } = "";
        public string urbanizacion_nombre { get; set; } = "";
        public string urbanizacion_nombre_corto { get; set; } = "";
        public string manzano_codigo { get; set; } = "";
        public string lote_codigo { get; set; } = "";
    }
}
