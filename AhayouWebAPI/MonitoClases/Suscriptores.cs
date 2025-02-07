using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Suscriptores
    {
        public string pv_tipo_operacion { get; set; }
        
        [Display(Name = "usuario")]
        public string pv_usuarioi { get; set; }
        
        [Display(Name = "Password")]
        [StringLength(maximumLength: 500, ErrorMessage = "El password debe tener como máximo {1} caracteres.")]
        public string pv_password { get; set; }
        
        [Display(Name = "Password Anterior")]
        [StringLength(maximumLength: 500, ErrorMessage = "El password debe tener como máximo {1} caracteres.")]
        public string pv_password_anterior { get; set; }
        
        [Display(Name = "nombre completo")]
        [Required(ErrorMessage = "Debe ingresar el nombre completo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo nombres debe tener como máximo {1} caracteres.")]
        public string pv_nombre_completo { get; set; }
        
        [Display(Name = "Celular")]
        [StringLength(maximumLength: 20, ErrorMessage = "El password debe tener como máximo {1} caracteres.")]
        public string pv_celular { get; set; }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Debe ingresar el email")]
        [EmailAddress(ErrorMessage = "El email debe ser válido")]
        [StringLength(maximumLength: 300, ErrorMessage = "El email debe tener como máximo {1} caracteres.")]
        public string pv_email { get; set; }

        public string pv_usuario { get; set; }
        public string pv_estado{ get; set; }
        public string pv_emailout { get; set; }
        public string pv_estadopr { get; set; }
        public string pv_descripcionpr { get; set; }
        public string pv_error { get; set; }
    }
}
