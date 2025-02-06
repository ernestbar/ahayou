using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
	public class LugarCobro
	{
		public int id_lugarcobro { get; set; } = 0;
		public int id_usuario { get; set; } = 0;
		public string codigo { get; set; } = "";
		public string nombre { get; set; } = "";
		public bool cobrador { get; set; } = true;
	}
}
