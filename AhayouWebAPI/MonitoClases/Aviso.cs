using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AhayouClases
{
	public class Aviso
	{
        [Display(Name = "Id. Aviso")]
        public int id_aviso { get; set; } = 0;

        [Display(Name = "Id. Prospecto")]
		[Required(ErrorMessage = "Debe seleccionar un prospecto")]
		public int id_prospecto { get; set; } = 0;

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La descripción debe tener como máximo {1} caracteres.")]
        public string descripcion { get; set; } = "";

        [Display(Name = "Fecha Envío")]
        public DateTime fecha_envio { get; set; } = DateTime.Today;

        [Display(Name = "Fecha Lectura")]
        public DateTime fecha_lectura { get; set; } = DateTime.Today;

        [Display(Name = "Leído")]
        public bool leido { get; set; } = false;

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;


        [Display(Name = "Nombre Prospecto")]
		[Required(ErrorMessage = "Debe seleccionar un prospecto")]
		public string nombre_prospecto { get; set; } = "";
        [Display(Name = "Fecha Envío")]
        public string fecha_envio_cadena { get; set; } = DateTime.Today.ToString("dd/MM/yyyy");
        [Display(Name = "Fecha Lectura")]
        public string fecha_lectura_cadena { get; set; } = "";
        [Display(Name = "Estado")]
        public string estado { get; set; } = "";
	}
}
