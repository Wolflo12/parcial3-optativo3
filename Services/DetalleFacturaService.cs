using parcial3.Models.DetalleFactura;
using parcial3.Repository.IDetalleFactura;
using parcial3.Repository.Factura.DetalleFactura;

namespace parcial3.Services.Factura
{
    public class DetalleFacturaService : IDetalleFacturaRepository
    {
        private DetalleFacturaRepository detallefacturaRepository;

        public DetalleFacturaService(string connectionString)
        {
            detallefacturaRepository = new DetalleFacturaRepository(connectionString);
        }

        public bool add(DetalleFacturaModel detalleFactura)
        {
            return ValidarDatos(detalleFactura) ? detallefacturaRepository.add(detalleFactura) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<DetalleFacturaModel> GetAll()
        {
            return detallefacturaRepository.GetAll();
        }

        public bool DeleteByid(int id)
        {
            return id > 0 ? detallefacturaRepository.DeleteByid(id) : false;
        }

        public bool update(DetalleFacturaModel detalleFactura)
        {
            return ValidarDatos(detalleFactura) ? detallefacturaRepository.update(detalleFactura) : throw new Exception("Error en la validación de datos, corroborar");
        }

        private bool ValidarDatos(DetalleFacturaModel detalleFactura)
        {
            if (detalleFactura == null)
                return false;

            if (string.IsNullOrEmpty(detalleFactura.cantidad_producto))
                return false;
            if (string.IsNullOrEmpty(detalleFactura.subtotal))
                return false;

            return true;
        }
    }
}
