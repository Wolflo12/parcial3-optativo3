using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parcial3.Models.DetalleFactura;

namespace parcial3.Models.Factura
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public int Id_sucursal { get; set; }
        public string Nro_factura { get; set; }
        public DateTime Fecha_hora { get; set; }
        public decimal Total { get; set; }
        public decimal Total_iva5 { get; set; }
        public decimal Total_iva10 { get; set; }
        public decimal Total_iva { get; set; }
        public string Total_letras { get; set; }
        public string Sucursal { get; set; }
        public List<DetalleFacturaModel> detallefactura { get; set; }
    }
}
