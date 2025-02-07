using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace AhayouClases
{
	public class Prospecto
	{
        [Display(Name = "Id. Prospecto")]
        public int id_prospecto { get; set; } = 0;

        [Display(Name = "C.I.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El C.I. debe tener como máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe ingresar el C.I.")]
        public string ci { get; set; } = "";

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debe ingresar los nombres")]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo nombres debe tener como máximo {1} caracteres.")]
        public string nombres { get; set; } = "";

        [Display(Name = "Ap. Paterno")]
        [Required(ErrorMessage = "Debe ingresar el apellido paterno")]
        [StringLength(maximumLength: 200, ErrorMessage = "El apellido paterno debe tener como máximo {1} caracteres.")]
        public string paterno { get; set; } = "";

        [Display(Name = "Ap. Materno")]
        [Required(ErrorMessage = "Debe ingresar el apellido materno")]
        [StringLength(maximumLength: 200, ErrorMessage = "El apellido materno debe tener como máximo {1} caracteres.")]
        public string materno { get; set; } = "";

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Debe ingresar el número de celular")]
        [StringLength(maximumLength: 20, ErrorMessage = "El número de celular debe tener como máximo {1} caracteres.")]
        public string celular { get; set; } = "";

        [Display(Name = "Telf. Fijo")]
        [Required(ErrorMessage = "Debe ingresar el teléfono fijo")]
        [StringLength(maximumLength: 20, ErrorMessage = "El teléfono fijo debe tener como máximo {1} caracteres.")]
        public string telf_fijo { get; set; } = "";

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe ingresar el email")]
        [EmailAddress(ErrorMessage = "El email debe ser válido")]
        [StringLength(maximumLength: 300, ErrorMessage = "El email debe tener como máximo {1} caracteres.")]
        public string email { get; set; } = "";

        [Display(Name = "Id. Usuario")]
        public int id_usuario { get; set; } = 0;


        [Display(Name = "Nombre Prospecto")]
        public string nombre_prospecto { get; set; } = "";
	}
}
