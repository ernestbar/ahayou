using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
	public  class GrupoVenta
	{
		public int id_grupoventa { get; set; } = 0;
		public int id_director { get; set; } = 0;
		public string nombre { get; set; } = "";
		public bool activo { get; set; } = true;
		public bool en_planilla { get; set; } = true;

		public int num_promotor { get; set; } = 0;
		public int num_promotor_activo { get; set; }  = 0;
		public int num_asignacion { get; set; } = 0;
		public string nombre_director { get; set; }  = "";
	}
}
