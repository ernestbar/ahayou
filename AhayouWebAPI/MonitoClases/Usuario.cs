using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AhayouClases
{
	public class Usuario : IValidatableObject
    {
        [Display(Name = "Id. Usuario")]
        public int id_usuario { get; set; } = 0;

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

        [Display(Name = "Id. Supervisor")]
        public int? id_supervisor { get; set; } = 0;

        [Display(Name = "C.I.")]
        [Required(ErrorMessage = "Debe ingresar el C.I.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El C.I. debe tener como máximo {1} caracteres.")]
        public string ci { get; set; } = "";

        [Display(Name = "Nombre Usuario")]
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre de usuario debe tener como máximo {1} caracteres.")]
        public string nombre_usuario { get; set; } = "";

        [Display(Name = "Password")]
        [StringLength(maximumLength: 500, ErrorMessage = "El password debe tener como máximo {1} caracteres.")]
        public string password { get; set; } = "";

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe ingresar el email")]
        [EmailAddress(ErrorMessage = "El email debe ser válido")]
        [StringLength(maximumLength: 300, ErrorMessage = "El email debe tener como máximo {1} caracteres.")]
        public string email { get; set; } = "";

        [Display(Name = "Id. Rol")]
		[Required(ErrorMessage = "Debe seleccionar un rol")]
		public int? id_rol { get; set; } = 0;


        [Display(Name = "Rol")]
        public string rol { get; set; } = "";

        public string password_nuevo { get; set; } = "";

		public string password_confirmar { get; set; } = "";

		[Display(Name = "Nombre Completo")]
		public string nombre_completo { get; set; } = "";

		[Display(Name = "Nombre Supervisor")]
		public string nombre_supervisor { get; set; } = "";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (id_rol != null)
            {
                if (id_rol != 3 && id_supervisor > 0)
                {
                    yield return new ValidationResult("Solo se puede seleccionar el supervisor para el rol vendedor");
                }

				if (id_rol == 3 && id_supervisor == null)
				{
					yield return new ValidationResult("Debe seleccionar un supervisor");
				}
			}
        }
    }
}
