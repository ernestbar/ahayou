using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AhayouClases
{
	public class Rol
	{
        [Display(Name = "Id. Rol")]
        public int id_rol { get; set; } = 0;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre debe tener como máximo {1} caracteres.")]
        public string nombre { get; set; } = "";

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;
	}
}
