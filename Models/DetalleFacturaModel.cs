using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial3.Models.DetalleFactura
{
    public class DetalleFacturaModel
    {
        public int id { get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public string cantidad_producto { get; set; }
        public string subtotal { get; set; }
    }
}
