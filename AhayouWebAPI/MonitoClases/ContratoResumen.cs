using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public  class ContratoResumen
    {
        public Contrato contrato { get ; set; }
        public ContratoVenta contrato_venta { get; set; }
        public Cliente cliente { get; set; }
    }
}
