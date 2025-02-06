using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
	public class Manzano
	{
		public int id_manzano { get; set; } = 0;
		public int id_urbanizacion { get; set; } = 0;
		public string codigo { get; set; } = "";
		public bool activo { get; set; } = true;
		public string motivo { get; set; } = "";
	}
}
