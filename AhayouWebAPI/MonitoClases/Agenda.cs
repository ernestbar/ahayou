using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace MonitoClases
{
	public class Agenda
	{
        [Display(Name = "Id. Agenda")]
        public int id_agenda { get; set; } = 0;

        [Display(Name = "Id. Prospecto")]
        [Required(ErrorMessage = "Debe seleccionar un prospecto")]
        public int id_prospecto { get; set; } = 0;

        [Display(Name = "Nro. Visita")]
        public int nro_visita { get; set; } = 0;

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La descripción debe tener como máximo {1} caracteres.")]
        public string descripcion { get; set; } = "";

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;

        [Display(Name = "Fecha Creación")]
        public DateTime fecha_creacion { get; set; } = DateTime.Today;

        [Display(Name = "Fecha Agendada")]
        [Required(ErrorMessage = "Debe ingresar una fecha agendada")]
        public DateTime fecha_agendada { get; set; } = DateTime.Today;


        [Display(Name = "Nombre Prospecto")]
		[Required(ErrorMessage = "Debe seleccionar un prospecto")]
		public string nombre_prospecto { get; set; } = "";

		[Display(Name = "Fecha Agendada")]
        public string fecha_agendada_cadena { get; set; } = "";

        [Display(Name = "Hora Agendada")]
        public string hora_agendada_cadena { get; set; } = "";

        [Display(Name = "Hora Agendada")]
        public TimeSpan hora_agendada_timespan { get; set; } = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

	}
}
