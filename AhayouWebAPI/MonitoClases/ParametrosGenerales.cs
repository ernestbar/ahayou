using MonitoClases.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace MonitoClases
{
	public class ParametrosGenerales : IValidatableObject
    {
        [Display(Name = "Id. Param. Gral.")]
        public int id_parametrogeneral { get; set; } = 0;

        [Display(Name = "Tipo Dato")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de dato")]
        public int? id_tipodato { get; set; } = 0;

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Debe ingresar un código")]
        [StringLength(maximumLength: 10, ErrorMessage = "El código debe tener como máximo {1} caracteres.")]
        public string codigo { get; set; } = "";

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre debe tener como máximo {1} caracteres.")]
        public string nombre { get; set; } = "";

		[Display(Name = "Valor Numérico")]
		[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Debe ingresar un valor numérico válido")]
		[NumeroDecimal(ErrorMessage = "Debe ingresar un valor numérico válido")]
		public decimal? valor_numerico { get; set; } = 0;

        [Display(Name = "Valor Carácter")]
        [StringLength(maximumLength: 500, ErrorMessage = "El valor carácter debe tener como máximo {1} caracteres.")]
        public string? valor_caracter { get; set; } = "";

        [Display(Name = "Valor Fecha")]
        public DateTime? valor_fecha { get; set; } = DateTime.Today;

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;

        [Display(Name = "Fecha Creación")]
        public DateTime fecha_creacion { get; set; } = DateTime.Today;


		[Display(Name = "Tipo Dato")]
		public string tipo_dato { get; set; } = "";

		[Display(Name = "Valor Numérico")]
		public string valor_numerico_cadena { get; set; } = "";

        [Display(Name = "Valor Fecha")]
        public string valor_fecha_cadena { get; set; } = "";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (id_tipodato != null)
            {
                switch (id_tipodato)
                {
                    case 1:
						if (valor_numerico == 0)
                        {
                            yield return new ValidationResult("Debe ingresar un valor numérico válido");
                        }
                        break;
                    case 2:
                        if (String.IsNullOrEmpty(valor_caracter))
                        {
                            yield return new ValidationResult("Debe ingresar un valor caracter");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
