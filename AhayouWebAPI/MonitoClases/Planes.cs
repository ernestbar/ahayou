using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Planes
    {
        public Int64 codigo_plan { get; set; }
        public Int64 cant_perfiles { get; set; }
        public decimal monto { get; set; }
        public string pago_mes { get; set; }
        public string pago_mes_ingles { get; set; }
        public string ahorro { get; set; }
        public string ahorro_mes { get; set; }
        public string plan { get; set; }
        public string plan_ingles { get; set; }
        public string caracteristicas { get; set; }
        public string caracteristicas_ingles { get; set; }
        public string moneda { get; set; }
        public string url_pasarela { get; set; }
    }
}
