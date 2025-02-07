using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Dominios
    {
        public string dominio { get; set; } = "";
        public string codigo { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string valor_caracter { get; set; } = "";
        public decimal valor_numerico { get; set; } = 0;
        public DateTime valor_fecha  { get; set; } = DateTime.Parse("01/01/3000");
    }
}
