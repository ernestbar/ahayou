using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace AhayouClases
{
	public class Producto
	{
        [Display(Name = "Id. Producto")]
        public int id_producto { get; set; } = 0;

        [Display(Name = "Urbanización")]
        [Required(ErrorMessage = "Debe ingresar una urbanización")]
        [StringLength(maximumLength: 300, ErrorMessage = "La urbanización debe tener como máximo {1} caracteres.")]
        public string urbanizacion { get; set; } = "";

        [Display(Name = "Id. Urbanización")]
        public int? id_urbanizacion { get; set; } = 0;
       
        [Display(Name = "Lote")]
        [Required(ErrorMessage = "Debe ingresar un lote")]
        [StringLength(maximumLength: 300, ErrorMessage = "El lote debe tener como máximo {1} caracteres.")]
        public string lote { get; set; } = "";

        [Display(Name = "Id. Lote")]
        public int? id_lote { get; set; } = 0;

        [Display(Name = "Activo")]
        public bool activo { get; set; } = true;

        [Display(Name = "Id. Prospecto")]
        public int id_prospecto { get; set; } = 0;

        [Display(Name = "Fecha Creación")]
        public DateTime fecha_creacion { get; set; } = DateTime.Today;

        [Display(Name = "Lote en Inventario")]
        public bool lote_inventario { get; set; } = false;
    }
}
