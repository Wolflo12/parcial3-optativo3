using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial3.Models.Producto
{
    public class ProductoModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string cantidad_minima { get; set; }
        public string cantidad_stock { get; set; }
        public string precio_compra { get; set; }
        public string precio_venta { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string estado { get; set; }
    }
}
