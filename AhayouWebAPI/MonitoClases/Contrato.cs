using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhayouClases
{
    public class Contrato
    {
        public int id_contrato { get; set; } = 0;
        public int id_moneda { get; set; } = 0;
        public int id_usuario { get; set; } = 0;
        public string numero { get; set; } = "";
        public DateTime fecha { get; set; } = DateTime.Today;
        public bool contado { get; set; } = false;
        public bool preferencial { get; set; } = false;
        public decimal precio { get; set; } = 0;
        public decimal descuento_porcentaje { get; set; } = 0;
        public decimal descuento_efectivo { get; set; } = 0;
        public decimal precio_final { get; set; } = 0;
        public decimal cuota_inicial { get; set; } = 0;
        public int num_cuotas { get; set; } = 0;
        public decimal seguro { get; set; } = 0;
        public decimal mantenimiento_sus { get; set; } = 0;
        public decimal interes_corriente { get; set; } = 0;
        public decimal interes_penal { get; set; } = 0;
        public decimal cuota_base { get; set; } = 0;
        public DateTime fecha_inicio_plan { get; set; } = DateTime.Today;
        public string observacion { get; set; } = "";
        public decimal tipo_cambio { get; set; } = 0;

        public bool venta_lote { get; set; } = true;
        public int id_planpago_vigente { get; set; } = 0;
        public int estado_id { get; set; } = 0;
        public string estado_nombre { get; set; } = "";
        public int id_negociocontrato { get; set; } = 0;
        public string negocio_nombre { get; set; } = "";
        public int id_ultimo_pago { get; set; } = 0;
        public int id_cuota_inicial { get; set; } = 0;
        public int id_promotor_vigente { get; set; } = 0;
        public int id_cobrador_vigente { get; set; } = 0;
        public int id_titular { get; set; } = 0;
        public int id_reversion { get; set; } = 0;
        public decimal capital_pagado { get; set; } = 0;
        public decimal saldo_capital { get; set; } = 0;
        public int cuotas_pagadas { get; set; } = 0;
        public string codigo_moneda { get; set; } = "";
        public string nombre_moneda { get; set; } = "";
        public decimal capital_adeudado { get; set; } = 0;
        public decimal precio_total { get; set; } = 0;
        public int dia_pago { get; set; } = 0;
        public string ubicacion { get; set; } = "";
        public bool bloqueado { get; set; }
    }
}
