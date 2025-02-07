using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace AhayouClases
{
	public class LocalizacionUsuario
	{
        [Display(Name = "Id. Localización")]
        public int id_localizacionusuario { get; set; } = 0;

        [Display(Name = "Latitud")]
		public string lat { get; set; } = "";

        [Display(Name = "Longitud")]
        public string lon { get; set; } = "";

        [Display(Name = "Fecha Hora")]
        public DateTime fecha_hora { get; set; } = DateTime.Today;

        [Display(Name = "Id. Usuario")]
        public int id_usuario { get; set; } = 0;

        [Display(Name = "Fecha")]
        public string fecha_cadena { get; set; } = "";

        [Display(Name = "Hora")]
        public string hora_cadena { get; set; } = "";

        [Display(Name = "Hora")]
        public TimeSpan hora_timespan { get; set; } = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        [Display(Name = "Nombre Usuario")]
        public string nombre_usuario { get; set; } = "";
    }
}
