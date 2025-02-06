using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoClases
{
	public class VentaContratoLote
	{
		public AsignacionPromotor asignacion_promotor { get; set; }
		public Lote lote { get; set; }
		public Contrato contrato { get; set; }
		public ContratoVenta contrato_venta { get; set; }
		public CapitalAdeudado capital_adeudado { get; set; }
		public BeneficiarioFactura beneficiario_factura { get; set; }
		public SeguroProvida seguro_provida { get; set; }
		public Cliente cliente { get; set; }
		public List<Cliente> lista_cliente { get; set; }
	}
}
