using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonitoClases
{
	public class Login
	{
		public int id_usuario { get; set; } = 0;

		[Display(Name = "Usuario")]
		[Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
		public string nombre_usuario { get; set; } = "";

		[Display(Name = "Clave")]
		[Required(ErrorMessage = "Debe ingresar la clave")]
		public string password { get; set; } = "";

		public string rol { get; set; } = "";

		public string token { get; set; } = "";
    }
}
