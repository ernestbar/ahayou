using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
    public class Urbanizacion
    {
        public int id_urbanizacion { get; set; } = 0;
        public int id_localizacion { get; set; } = 0;
        public string codigo { get; set; } = "";
        public string nombre_corto { get; set; } = "";
        public string nombre { get; set; } = "";
        public decimal mantenimiento_sus { get; set; } = 0;
        public decimal costo_m2_sus { get; set; } = 0;
        public decimal precio_m2_sus { get; set; } = 0;
        public string imagen { get; set; } = "";
        public bool activo { get; set; } = false;
        public string clasificacion { get; set; } = "";

        public string localizacion_nombre { get; set; } = "";
    }
}
